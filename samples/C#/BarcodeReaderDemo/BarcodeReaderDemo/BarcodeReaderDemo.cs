using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Barcode_Reader_Demo.Properties;
using Dynamsoft.Barcode;

using ContentAlignment = System.Drawing.ContentAlignment;
using Dynamsoft.Common;
using Dynamsoft.TWAIN;
using Dynamsoft.UVC;
using Dynamsoft.Core;
using Dynamsoft.PDF;
using Dynamsoft.TWAIN.Enums;
using Dynamsoft.Core.Enums;
using Dynamsoft.Core.Annotation;

namespace Barcode_Reader_Demo
{
    public partial class BarcodeReaderDemo : Form,Dynamsoft.TWAIN.Interface.IAcquireCallback,Dynamsoft.PDF.IConvertCallback,Dynamsoft.PDF.ISave
    {
        #region field

        // For move the window
        private Point _mouseOffset;
        // For move the result panel/
        private Point _mouseOffset2;
        private int _currentImageIndex = -1;
        private delegate void CrossThreadOperationControl();
        private delegate void PostShowFrameResultsHandler(Bitmap bitmap, TextResult[] textResults, int timeElapsed,Exception ex);

        private PostShowFrameResultsHandler mPostShowFrameResults; 
        private bool mIsToCrop;
        private string mLastOpenedDirectory;
        private string mTemplateFileDirectory;
        private Label nInfoLabel;

        private RoundedRectanglePanel mRoundedRectanglePanelAcquireLoad;
        private RoundedRectanglePanel mRoundedRectanglePanelBarcode;
        //private TabHead mThReadMoreSetting;
        private TabHead mThLoadImage;
        private TabHead mThAcquireImage;
        private TabHead mThWebCamImage;

        private TabHead mThResult;
        private RoundedRectanglePanel mPanelResult;
        EnumBarcodeFormat mEmBarcodeFormat = 0;
        private readonly BarcodeReader mBarcodeReader;
        PublicRuntimeSettings mCustomRuntimeSettings;

        private bool mIsWebCamErrorOccur = false;
        private bool mIsTurnOnReading = false;

        private TwainManager mTwainManager = null;
        private CameraManager mCameraManager = null;
        private ImageCore mImageCore = null;
        private PDFRasterizer mPDFRasterizer = null;
        string dbrLicenseKeys = System.Configuration.ConfigurationManager.AppSettings["DBRLicense"];
        string dntLicenseKeys = System.Configuration.ConfigurationManager.AppSettings["DNTLicense"];
        private bool mIfHasAddedOnFrameCaptureEvent = false;

        private int miRecognitionMode = 2;//best converage

        private bool mbCustom = false;
        private PublicRuntimeSettings mNormalRuntimeSettings;
        #endregion

        #region property

        public bool ExistWebCam
        {
            get
            {
                var exist = false;
                if(mCameraManager.GetCameraNames()!=null)
                {
                    exist = true;
                }

                return exist;
            }
        }

        #endregion

        public BarcodeReaderDemo()
        {
            InitializeComponent();
            InitializeComponentForCustomControl();

            // Draw the background for the main form
            DrawBackground();

            Initialization();
            InitLastOpenedDirectoryStr();

            dsViewer.MouseShape = true;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumNone;
            mBarcodeReader = new BarcodeReader(dbrLicenseKeys);
            mPostShowFrameResults = new PostShowFrameResultsHandler(this.postShowFrameResults);
            mNormalRuntimeSettings = mBarcodeReader.GetRuntimeSettings();
            UpdateBarcodeFormat();
            toolTipExport.SetToolTip(btnExportSettings, "out put settings");
           
        }

        #region form relevant

        /// <summary>
        /// Click to minimize the form
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;
                var cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;
                return cp;
            }
        }

        private void DotNetTWAINDemo_Load(object sender, EventArgs e)
        {
            InitUI();
            InitDefaultValueForTwain();
            cbxViewMode.Select();
        }

        #endregion

        #region init

        private void InitializeComponentForCustomControl()
        {
            mRoundedRectanglePanelAcquireLoad = new RoundedRectanglePanel();
            mRoundedRectanglePanelBarcode = new RoundedRectanglePanel();
            mThLoadImage = new TabHead();
            mThAcquireImage = new TabHead();
            mThWebCamImage = new TabHead();
            mThResult = new TabHead();
            mPanelResult = new RoundedRectanglePanel();

            mRoundedRectanglePanelAcquireLoad.SuspendLayout();
            mRoundedRectanglePanelBarcode.SuspendLayout();
            mPanelResult.SuspendLayout();
            
            //
            // _panelResult
            //
            mPanelResult.AutoSize = true;
            mPanelResult.BackColor = SystemColors.Control;
            mPanelResult.Controls.Add(lblCloseResult);
            mPanelResult.Controls.Add(mThResult);
            mPanelResult.Controls.Add(this.tbxResult);
            mPanelResult.Location = new Point(12, 12);
            mPanelResult.Margin = new Padding(10, 12, 12, 0);
            mPanelResult.Name = "_panelResult";
            mPanelResult.Padding = new Padding(1);
            mPanelResult.Size = new Size(311, 500);
            mPanelResult.TabIndex = 2;

            // 
            // _thResult
            // 
            mThResult.BackColor = Color.Transparent;
            mThResult.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mThResult.ImageAlign = ContentAlignment.MiddleRight;
            mThResult.Index = 4;
            mThResult.Location = new Point(1, 1);
            mThResult.Margin = new Padding(0);
            mThResult.MultiTabHead = false;
            mThResult.Name = "_thResult";
            mThResult.Size = new Size(309, 25);
            mThResult.State = TabHead.TabHeadState.SELECTED;
            mThResult.TabIndex = 0;
            mThResult.Text = "Barcode Results";
            mThResult.TextAlign = ContentAlignment.MiddleLeft;

            //
            // this.panelNormalSettings
            //
            this.panelNormalSettings.Location = new Point(1, 41);

            // 
            // roundedRectanglePanelAcquireLoad
            // 
            mRoundedRectanglePanelAcquireLoad.AutoSize = true;
            mRoundedRectanglePanelAcquireLoad.BackColor = Color.Transparent; ;
            mRoundedRectanglePanelAcquireLoad.Controls.Add(panelLoad);
            mRoundedRectanglePanelAcquireLoad.Controls.Add(panelAcquire);
            mRoundedRectanglePanelAcquireLoad.Controls.Add(panelWebCam);
            mRoundedRectanglePanelAcquireLoad.Controls.Add(mThLoadImage);
            mRoundedRectanglePanelAcquireLoad.Controls.Add(mThAcquireImage);
            mRoundedRectanglePanelAcquireLoad.Controls.Add(mThWebCamImage);
            mRoundedRectanglePanelAcquireLoad.Location = new Point(12, 12);
            mRoundedRectanglePanelAcquireLoad.Margin = new Padding(10, 12, 12, 0);
            mRoundedRectanglePanelAcquireLoad.Name = "roundedRectanglePanelAcquireLoad";
            mRoundedRectanglePanelAcquireLoad.Padding = new Padding(1);
            mRoundedRectanglePanelAcquireLoad.Size = new Size(311, 265);
            mRoundedRectanglePanelAcquireLoad.TabIndex = 0;
            // 
            // roundedRectanglePanelBarcode
            // 
            mRoundedRectanglePanelBarcode.AutoSize = false;
            mRoundedRectanglePanelBarcode.Controls.Add(this.panelNormalSettings);
          

            mRoundedRectanglePanelBarcode.Location = new Point(12, 376);
            mRoundedRectanglePanelBarcode.Margin = new Padding(10, 12, 12, 0);
            mRoundedRectanglePanelBarcode.Name = "roundedRectanglePanelBarcode";
            mRoundedRectanglePanelBarcode.Size = new Size(312, 376);
            mRoundedRectanglePanelBarcode.TabIndex = 1;

 
            // 
            // thLoadImage
            // 
            mThLoadImage.BackColor = Color.Transparent;
            mThLoadImage.Font = new Font("Open Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
            mThLoadImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            mThLoadImage.Index = 0;
            mThLoadImage.Location = new Point(1, 1);
            mThLoadImage.Margin = new Padding(0);
            mThLoadImage.Padding = new Padding(10,0,0,0);
            mThLoadImage.MultiTabHead = true;
            mThLoadImage.Name = "_thLoadImage";
            mThLoadImage.Size = new Size(103, 40);
            mThLoadImage.State = TabHead.TabHeadState.SELECTED;
            mThLoadImage.TabIndex = 1;
            mThLoadImage.Text = "Files";
            mThLoadImage.TextAlign = ContentAlignment.MiddleCenter;
            mThLoadImage.Click += TabHead_Click;
            // 
            // thAcquireImage
            // 
            mThAcquireImage.BackColor = Color.Transparent;
            mThAcquireImage.Font = new Font("Open Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
            mThAcquireImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));

            mThAcquireImage.Index = 1;
            mThAcquireImage.Location = new Point(104, 1);
            mThAcquireImage.Margin = new Padding(0);
            mThAcquireImage.Padding = new Padding(10, 0, 0, 0);
            mThAcquireImage.MultiTabHead = true;
            mThAcquireImage.Name = "_thAcquireImage";
            mThAcquireImage.Size = new Size(103, 40);
            mThAcquireImage.State = TabHead.TabHeadState.FOLDED;
            mThAcquireImage.TabIndex = 2;
            mThAcquireImage.Text = "Scanner";
            mThAcquireImage.TextAlign = ContentAlignment.MiddleCenter;
            mThAcquireImage.Click += TabHead_Click;
            // 
            // thWebCamImage
            // 
            mThWebCamImage.BackColor = Color.Transparent;
            mThWebCamImage.Font = new Font("Open Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
            mThWebCamImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            mThWebCamImage.Index = 2;
            mThWebCamImage.Location = new Point(207, 1);
            mThWebCamImage.Margin = new Padding(0);
            mThWebCamImage.Padding = new Padding(8, 0, 0, 0);
            mThWebCamImage.MultiTabHead = true;
            mThWebCamImage.Name = "_thWebCamImage";
            mThWebCamImage.Size = new Size(103, 40);
            mThWebCamImage.State = TabHead.TabHeadState.FOLDED;
            mThWebCamImage.TabIndex = 3;
            mThWebCamImage.Text = "Webcam";
            mThWebCamImage.TextAlign = ContentAlignment.MiddleCenter;
            mThWebCamImage.Click += TabHead_Click;

            mPanelResult.ResumeLayout(false);
            mRoundedRectanglePanelAcquireLoad.ResumeLayout(false);
            mRoundedRectanglePanelBarcode.ResumeLayout(false);

            flowLayoutPanel2.Controls.Add(mPanelResult);
            flowLayoutPanel2.Controls.Add(mRoundedRectanglePanelAcquireLoad);
            flowLayoutPanel2.Controls.Add(mRoundedRectanglePanelBarcode);
            
            mPanelResult.Visible = false;
        }

        protected void Initialization()
        {
            var appPath = Application.StartupPath;
            mTwainManager = new TwainManager(dntLicenseKeys);
            mCameraManager = new CameraManager(dntLicenseKeys);
            mPDFRasterizer = new PDFRasterizer(dntLicenseKeys);
            mImageCore = new ImageCore();
            dsViewer.Bind(mImageCore);
            mImageCore.ImageBuffer.MaxImagesInBuffer = 64;
        }


        private void InitCbxResolution()
        {
            cbxResolution.Items.Clear();
            cbxResolution.Items.Insert(0, "150");
            cbxResolution.Items.Insert(1, "200");
            cbxResolution.Items.Insert(2, "300");
        }

        private void InitCbxWebCamRes()
        {
            cbxWebCamRes.Items.Clear();
            if (mCameraManager.GetCameraNames() != null)
            {
                try
                {
                    if (cbxWebCamSrc.SelectedIndex != -1)
                    {
                        Camera tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                        foreach (var resolution in tempCamera.SupportedResolutions)
                        {
                            if (resolution.Width < 400 && resolution.Height < 400)
                            {
                            }
                            else
                            {
                                var strResolution = resolution.Width + " x " + resolution.Height;
                                cbxWebCamRes.Items.Add(strResolution);
                            }

                        }
                        cbxWebCamRes.SelectedIndex = 0;
                        mIsWebCamErrorOccur = false;
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Webcam error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mIsWebCamErrorOccur = true;
                }
            }

        }

        private void InitCbxWebCamSrc()
        {
            BindCbxWebCamSrc();
        }

        private void BindCbxWebCamSrc()
        {
            cbxWebCamSrc.Items.Clear();
            if(mCameraManager.GetCameraNames()!=null)
            {
                for (short i = 0; i < mCameraManager.GetCameraNames().Count;i++)
                {
                    var strSourceName = mCameraManager.SelectCamera(i).GetCameraName();
                    cbxWebCamSrc.Items.Add(strSourceName);
                }
                mCameraManager.SelectCamera(0);
                if (cbxWebCamSrc.Items.Count > 0)
                    cbxWebCamSrc.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Init the UI for the demo
        /// </summary>
        private void InitUI()
        {
            panelAcquire.Visible = false;
            panelLoad.Visible = true;
            panelReadSetting.Visible = true;
            panelReadMoreSetting.Visible = false;

            dsViewer.Visible = false;

            DisableAllFunctionButtons();

            // Init the View mode
            cbxViewMode.Items.Clear();
            cbxViewMode.Items.Insert(0, "1 x 1");
            cbxViewMode.Items.Insert(1, "2 x 2");
            cbxViewMode.Items.Insert(2, "3 x 3");
            cbxViewMode.Items.Insert(3, "4 x 4");
            cbxViewMode.Items.Insert(4, "5 x 5");

            // Init the cbxResolution
            InitCbxResolution();

            // Init the Scan Button
            DisableControls(picboxScan);

            // For the popup tip label
            nInfoLabel = new Label
            {
                Text = "",
                Visible = false,
                AutoSize = true,
                Name = "Info",
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            nInfoLabel.BringToFront();          
            Controls.Add(nInfoLabel);

            // For the load image button
            picboxLoadImage.MouseLeave += picbox_MouseLeave;
            picboxLoadImage.Click += picboxLoadImage_Click;
            picboxLoadImage.MouseDown += picbox_MouseDown;
            picboxLoadImage.MouseUp += picbox_MouseUp;
            picboxLoadImage.MouseEnter += picbox_MouseEnter;

            //Tab Heads
            _mTabHeads[0] = mThLoadImage;
            _mTabHeads[1] = mThAcquireImage;
            _mTabHeads[2] = mThWebCamImage;
            _mPanels[0] = panelLoad;
            _mPanels[1] = panelAcquire;
            _mPanels[2] = panelWebCam;
            _mPanels[3] = panelReadSetting;
            _mPanels[4] = panelReadMoreSetting;
            mThLoadImage.State = TabHead.TabHeadState.SELECTED;
            
            DisableControls(picboxReadBarcode);
            DisableControls(pictureBoxCustomize);

            picBoxWebCam.BringToFront();
        }

        /// <summary>
        /// Init the default value for TWAIN
        /// </summary>
        private void InitDefaultValueForTwain()

        {
            try
            {
                dsViewer.IfFitWindow = true;
                dsViewer.SetViewMode(-1,-1);
                cbxViewMode.SelectedIndex = 0;

                cbxWebCamSrc.SelectedIndexChanged += cbxWebCamSrc_SelectedIndexChanged;
                cbxWebCamSrc.DropDown += cbxWebCamSrc_DropDown;

                cbxWebCamRes.SelectedIndexChanged += cbxWebCamRes_SelectedIndexChanged;
                cbxSource.SelectedIndexChanged += cbxSource_SelectedIndexChanged;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SetScannerControlsEnable(bool isEnable)
        {
            cbxResolution.Enabled = isEnable;
            rdbtnGray.Checked = isEnable;
            if (isEnable)
            {
                cbxResolution.SelectedIndex = 0;
                EnableControls(picboxScan);
            }
            else
            {
                cbxSource.SelectedIndex = -1;
                DisableControls(picboxScan);
            }
        }

        private void DrawBackground()
        {
            var img = Resources.main_bg;
            // Set the form properties
            Size = new Size(img.Width, img.Height);
            BackgroundImage = new Bitmap(Width, Height);

            // Draw it
            var g = Graphics.FromImage(BackgroundImage);
            g.DrawImage(img, 0, 0, img.Width, img.Height);
            g.Dispose();
        }

        private void InitLastOpenedDirectoryStr()
        {
            mLastOpenedDirectory = Application.ExecutablePath;
            mLastOpenedDirectory = mLastOpenedDirectory.Replace("/", "\\");
            var index = mLastOpenedDirectory.LastIndexOf("Samples");
            if (index > 0)
            {
                mLastOpenedDirectory = mLastOpenedDirectory.Substring(0, index);
                mLastOpenedDirectory += "Images\\";
                mTemplateFileDirectory = mLastOpenedDirectory.Substring(0,index);
                mTemplateFileDirectory += "Templates\\";
                
            }

            if (!Directory.Exists(mLastOpenedDirectory))
                mLastOpenedDirectory = string.Empty;
        }

        #endregion

        #region enable/disable function buttons

        /// <summary>
        /// Disable all the function buttons in the left and bottom panel
        /// </summary>
        private void DisableAllFunctionButtons()
        {
            DisableControls(picboxZoomIn);
            DisableControls(picboxZoomOut);

            DisableControls(picboxDelete);
            DisableControls(picboxDeleteAll);

            DisableControls(picboxFirst);
            DisableControls(picboxPrevious);
            DisableControls(picboxNext);
            DisableControls(picboxLast);

            DisableControls(picboxFit);
            DisableControls(picboxOriginalSize);
        }
        
        /// <summary>
        /// Enable all the function buttons in the left and bottom panel
        /// </summary>
        private void EnableAllFunctionButtons()
        {
            EnableControls(picboxZoomIn);
            EnableControls(picboxZoomOut);

            EnableControls(picboxDelete);
            EnableControls(picboxDeleteAll);

            EnableControls(picboxFit);
            EnableControls(picboxOriginalSize);

            if (mImageCore.ImageBuffer.HowManyImagesInBuffer > 1)
            {
                EnableControls(picboxFirst);
                EnableControls(picboxPrevious);
                EnableControls(picboxNext);
                EnableControls(picboxLast);

                if (mImageCore.ImageBuffer.CurrentImageIndexInBuffer == 0)
                {
                    DisableControls(picboxPrevious);
                    DisableControls(picboxFirst);
                }
                if (mImageCore.ImageBuffer.CurrentImageIndexInBuffer + 1 == mImageCore.ImageBuffer.HowManyImagesInBuffer)
                {
                    DisableControls(picboxNext);
                    DisableControls(picboxLast);
                }
            }

            CheckZoom();
        }

        #endregion

        #region regist Event For All PictureBox Buttons

        private void picbox_MouseEnter(object sender, EventArgs e)
        {
            if (!(sender is PictureBox) || !(sender as PictureBox).Enabled) return;
            
            (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Enter");
        }

        private void picbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is PictureBox) || !(sender as PictureBox).Enabled) return;

            (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Down");
        }

        private void picbox_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                nInfoLabel.Text = "";
                nInfoLabel.Visible = false;
            }
            if (!(sender is PictureBox) || !(sender as PictureBox).Enabled) return;

            (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Leave");
            nInfoLabel.Text = "";
            nInfoLabel.Visible = false;
        }

        private void picbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!(sender is PictureBox) || !(sender as PictureBox).Enabled) return;
            (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Enter");
        }

        private void picbox_MouseHover(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox != null) nInfoLabel.Text = pictureBox.Tag.ToString();
            nInfoLabel.Location = new Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 20);
            nInfoLabel.Visible = true;
            nInfoLabel.BringToFront();
        }

        private void picboxScan_Click(object sender, EventArgs e)
        {
            if (!picboxScan.Enabled) return;

            picboxScan.Focus();
            if (cbxSource.SelectedIndex < 0)
            {
                if(cbxSource.Items.Count > 0)
                    MessageBox.Show(this, "Please select a scanner first.", "Information");
                else
                    MessageBox.Show(this, "There is no scanner detected!\n " +
                                      "Please ensure that at least one (virtual) scanner is installed.", "Information");
            }
            else
            {
                DisableControls(picboxScan);
                AcquireImage();
            }
        }

        private void SwitchButtonState(bool bStop)
        {
            if (bStop)
            {
                this.picboxStopBarcode.Visible = true;
                this.picboxReadBarcode.Visible = false;
            }
            else
            {
                this.picboxStopBarcode.Visible = false;
                this.picboxReadBarcode.Visible = true;
            }
        }

        private void DisableControls(object sender)
        {
            DisableControls(sender, string.Empty);

        }

        private void DisableControls(object sender, string suffix)
        {
            if (string.IsNullOrEmpty(suffix)) suffix = "_Disabled";

            if (sender is PictureBox)
            {
                (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + suffix);
                (sender as PictureBox).Enabled = false;
            }
            else
            {
                var control = sender as Control;
                if (control != null) control.Enabled = false;
            }
        }

        private static void EnableControls(object sender)
        {
            if (sender is PictureBox)
            {
                (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Leave");
                (sender as PictureBox).Enabled = true;
            }
            else
            {
                var control = sender as Control;
                if (control != null) control.Enabled = true;
            }
        }

        #endregion

        # region functions for the form, ignore them please

        /// <summary>
        /// Mouse down when move the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMoveBar_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseOffset = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// Mouse move when move the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMoveBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var mousePos = MousePosition;
            mousePos.Offset(_mouseOffset.X, _mouseOffset.Y);
            Location = mousePos;
        }

        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picboxClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            mTwainManager.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Minimize the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picboxMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region operate image

        /// <summary>
        /// Acquire image from the selected source
        /// </summary>
        private void AcquireImage()
        {
            bool bRet = false;
            try
            {
                // Select the source for TWAIN
                var srcIndex = -1;
                for (short i = 0; i < mTwainManager.SourceCount; i++)
                {
                    if (mTwainManager.SourceNameItems(i) != cbxSource.Text) continue;
                    srcIndex = i;
                    break;
                }

                mTwainManager.SelectSourceByIndex(srcIndex == -1 ? cbxSource.SelectedIndex : srcIndex);
                mTwainManager.OpenSource();
                mTwainManager.IfShowUI = false;
                mTwainManager.IfDisableSourceAfterAcquire = true;

                if (rdbtnBW.Checked)
                {
                    mTwainManager.PixelType = TWICapPixelType.TWPT_BW;
                    mTwainManager.BitDepth = 1;
                }
                else if (rdbtnGray.Checked)
                {
                    mTwainManager.PixelType = TWICapPixelType.TWPT_GRAY;
                    mTwainManager.BitDepth = 8;
                }
                else
                {
                    mTwainManager.PixelType = TWICapPixelType.TWPT_RGB;
                    mTwainManager.BitDepth = 24;
                }


                mTwainManager.Resolution = int.Parse(cbxResolution.Text);

                
                
                bRet = mTwainManager.AcquireImage(this as Dynamsoft.TWAIN.Interface.IAcquireCallback);
                if (!bRet)
                {
                    MessageBox.Show("An error occurred while scanning.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (TwainException ex)
            {
                MessageBox.Show("An exception occurs: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(!bRet)
                {
                    EnableControls(picboxScan);
                }
            }
        }

        private void picboxPoint_Click(object sender, EventArgs e)
        {
            dsViewer.MouseShape = false;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumNone;
        }

        // Change mouse shape to hand, for move image
        private void picboxHand_Click(object sender, EventArgs e)
        {
            dsViewer.MouseShape = true;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumNone;
        }

        private void picboxFit_Click(object sender, EventArgs e)
        {
            dsViewer.IfFitWindow = true;
            CheckZoom();
        }

        private void picboxOriginalSize_Click(object sender, EventArgs e)
        {
            dsViewer.IfFitWindow = false;
            dsViewer.Zoom = 1.0f;
            CheckZoom();
        }

        private void CropPicture(int imageIndex, Rectangle rc)
        {
            mImageCore.ImageProcesser.Crop((short)imageIndex,rc.X,rc.Y,rc.X + rc.Width,rc.Y + rc.Height);
        }

        private void picboxZoomIn_Click(object sender, EventArgs e)
        {
            var zoom = dsViewer.Zoom + 0.1F;
            dsViewer.IfFitWindow = false;
            dsViewer.Zoom = zoom;
            CheckZoom();
        }

        private void picboxZoomOut_Click(object sender, EventArgs e)
        {
            var zoom = dsViewer.Zoom - 0.1F;
            dsViewer.IfFitWindow = false;
            dsViewer.Zoom = zoom;
            CheckZoom();
        }

        private void CheckZoom()
        {
            if (cbxViewMode.SelectedIndex != 0 || mImageCore.ImageBuffer.HowManyImagesInBuffer == 0 )
            {
                DisableControls(picboxZoomIn);
                DisableControls(picboxZoomOut);
                DisableControls(picboxFit);
                DisableControls(picboxOriginalSize);
                return;
            }
            if (picboxFit.Enabled == false)
                EnableControls(picboxFit);
            if (picboxOriginalSize.Enabled == false)
                EnableControls(picboxOriginalSize);

            //  the valid range of zoom is between 0.02 to 65.0,
           
            if (dsViewer.Zoom <= 0.02F)
            {
                DisableControls(picboxZoomOut);
            }
            else
            {
                EnableControls(picboxZoomOut);
            }

            if (dsViewer.Zoom >= 65F)         
            {
                DisableControls(picboxZoomIn);
            }
            else
            {
                EnableControls(picboxZoomIn);
            }
        }

        private void picboxDelete_Click(object sender, EventArgs e)
        {
            mImageCore.ImageBuffer.RemoveImage(mImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            CheckImageCount();
        }

        private void picboxDeleteAll_Click(object sender, EventArgs e)
        {
            mImageCore.ImageBuffer.RemoveAllImages();
            CheckImageCount();
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetScannerControlsEnable(true);
        }

        /// <summary>
        /// If the image count changed, some features should changed.
        /// </summary>
        private void CheckImageCount()
        {
            _currentImageIndex = mImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            var currentIndex = _currentImageIndex + 1;
            int imageCount = mImageCore.ImageBuffer.HowManyImagesInBuffer;
            if (imageCount == 0)
                currentIndex = 0;

            tbxCurrentImageIndex.Text = currentIndex.ToString();
            tbxTotalImageNum.Text = imageCount.ToString();

            if (imageCount > 0)
            {
                EnableAllFunctionButtons();
                EnableControls(picboxReadBarcode);
                EnableControls(pictureBoxCustomize);
            }
            else
            {
                DisableAllFunctionButtons();
                dsViewer.Visible = false;
                DisableControls(picboxReadBarcode);
                DisableControls(pictureBoxCustomize);
            }

            if (imageCount > 1)
            {
                EnableControls(picboxFirst);
                EnableControls(picboxLast);
                EnableControls(picboxPrevious);
                EnableControls(picboxNext);

                if (currentIndex == 1)
                {
                    DisableControls(picboxPrevious);
                    DisableControls(picboxFirst);
                }
                if (currentIndex == imageCount)
                {
                    DisableControls(picboxNext);
                    DisableControls(picboxLast);
                }
            }
            else
            {
                DisableControls(picboxFirst);
                DisableControls(picboxLast);
                DisableControls(picboxPrevious);
                DisableControls(picboxNext);
            }

            ShowSelectedImageArea();
        }

        private void cbxLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbxViewMode.SelectedIndex)
            {
                case 0:
                    dsViewer.SetViewMode(-1,-1);
                    break;
                case 1:
                    dsViewer.SetViewMode(2, 2);
                    break;
                case 2: 
                    dsViewer.SetViewMode(3, 3);
                    break;
                case 3:
                    dsViewer.SetViewMode(4, 4);
                    break;
                case 4:
                    dsViewer.SetViewMode(5, 5);
                    break;
                default:
                    dsViewer.SetViewMode(-1, -1);
                    break;
            }
            CheckZoom();
        }     

        private void picboxFirst_Click(object sender, EventArgs e)
        {
            if(mImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                mImageCore.ImageBuffer.CurrentImageIndexInBuffer = 0;
            CheckImageCount();
        }

        private void picboxLast_Click(object sender, EventArgs e)
        {
            if (mImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                mImageCore.ImageBuffer.CurrentImageIndexInBuffer = (short)(mImageCore.ImageBuffer.HowManyImagesInBuffer - 1);
            CheckImageCount();
        }

        private void picboxPrevious_Click(object sender, EventArgs e)
        {
            if (mImageCore.ImageBuffer.HowManyImagesInBuffer > 0 && mImageCore.ImageBuffer.CurrentImageIndexInBuffer > 0)
                --mImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            CheckImageCount();
        }

        private void picboxNext_Click(object sender, EventArgs e)
        {
            if (mImageCore.ImageBuffer.HowManyImagesInBuffer > 0 &&
                mImageCore.ImageBuffer.CurrentImageIndexInBuffer < mImageCore.ImageBuffer.HowManyImagesInBuffer - 1)
                ++mImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            CheckImageCount();
        }

        private void picboxLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*GIF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF|PDF|*.PDF";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = mLastOpenedDirectory;

            mImageCore.ImageBuffer.IfAppendImage = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mLastOpenedDirectory = System.IO.Directory.GetParent(openFileDialog.FileName).FullName;

                foreach (var strFileName in openFileDialog.FileNames)
                {
                    var pos = strFileName.LastIndexOf(".");
                    if (pos != -1)
                    {
                        var strSuffix = strFileName.Substring(pos, strFileName.Length - pos).ToLower();
                        if (strSuffix.CompareTo(".pdf") == 0)
                        {
                            try
                            {
                                mPDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                                mPDFRasterizer.ConvertToImage(strFileName, "", 300, this as IConvertCallback);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message, "Loading image error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                            mImageCore.IO.LoadImage(strFileName);
                    }
                    else
                        mImageCore.IO.LoadImage(strFileName);
                }
                dsViewer.Visible = true;
            }
            CheckImageCount();
        }

        #endregion

        #region dynamicDotNetTwain event

        private void dynamicDotNetTwain_OnMouseClick(short sImageIndex)
        {
            if (mImageCore.ImageBuffer.CurrentImageIndexInBuffer != _currentImageIndex)
                CheckImageCount();
        }

        /// <summary>
        /// 
        /// </summary>
        private void dynamicDotNetTwain_OnPostAllTransfers()
        {
            CrossThreadOperationControl crossDelegate = delegate()
                {
                    dsViewer.Visible = true;
                    CheckImageCount();
                    EnableControls(picboxScan);
                };
            Invoke(crossDelegate);
        }

        private void dynamicDotNetTwain_OnMouseDoubleClick(short sImageIndex)
        {
            try
            {
                var rc = dsViewer.GetSelectionRect(sImageIndex);

                if (mIsToCrop && !rc.IsEmpty)
                {
                    CropPicture(sImageIndex, rc);
                }
                mIsToCrop = false;
            }
            catch
            {
            }
            EnableAllFunctionButtons();
        }

        private void dynamicDotNetTwain_OnMouseRightClick(short sImageIndex)
        {
            if (mIsToCrop) mIsToCrop = false;
            dsViewer.ClearSelectionRect(sImageIndex);
            EnableAllFunctionButtons();
        }

        private void dynamicDotNetTwain_OnImageAreaDeselected(short sImageIndex)
        {
            if (mIsToCrop) mIsToCrop = false;
            EnableAllFunctionButtons();
            ShowSelectedImageArea();
        }

        private void dynamicDotNetTwain_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
            ShowSelectedImageArea();
        }


        private void dynamicDotNetTwain_OnSourceUIClose()
        {
            EnableControls(picboxScan);
        }

        #endregion

        #region tab head relevant

        private readonly TabHead[] _mTabHeads = new TabHead[5];
        private readonly Panel[] _mPanels = new Panel[5];

        private void TabHead_Click(object sender, EventArgs e)
        {
            var thHead = sender as TabHead;
            if(thHead == null) return;

            #region toggle thHeads
            if (thHead.State == TabHead.TabHeadState.SELECTED)
                return;
            else
            {
                thHead.State = TabHead.TabHeadState.SELECTED;
                _mPanels[thHead.Index].Visible = true;

                foreach (var tabHead in GetNeighborTabHead(thHead))
                {
                   _mTabHeads[tabHead.Index].State = TabHead.TabHeadState.FOLDED;
                   _mPanels[tabHead.Index].Visible = false;
                }
            }
            #endregion


            var isPicBoxWebCamVisible = picBoxWebCam.Visible;

            switch (thHead.Name)
            {
                case "_thLoadImage":
                    if(mCameraManager.GetCameraNames()!=null)
                    {
                        mCameraManager.SelectCamera(mCameraManager.CurrentSourceName).Close();
                    }
                   
                    CheckImageCount();
                    mIsTurnOnReading = false;
                    picBoxWebCam.Visible = false;
                    this.SwitchButtonState(false);
                    break;
                case "_thAcquireImage":
                    var hasTwainSource = false;
                    cbxSource.Focus();
                    if(cbxSource.Items.Count>0)
                    {
                        cbxSource.Items.Clear();
                    }

                    for (var i = 0; i < mTwainManager.SourceCount; i++)
                    {
                        hasTwainSource = true;
                        cbxSource.Items.Add(mTwainManager.SourceNameItems((short)i));
                    }
                    if (cbxSource.Items.Count > 0)
                    {
                        cbxSource.SelectedIndex = 0;
                    }
                    if (hasTwainSource)
                    {
                        SetScannerControlsEnable(true);
                    }
                    

                    if(mCameraManager.GetCameraNames()!=null)
                    {
                        mCameraManager.SelectCamera(mCameraManager.CurrentSourceName).Close();
                    }
                   
                    CheckImageCount();
                    mTwainManager.CloseSource();
                    
                    mIsTurnOnReading = false;
                    picBoxWebCam.Visible = false;
                    this.SwitchButtonState(false);

                    break;

                case "_thWebCamImage":
                    cbxWebCamSrc.Focus();
                    if (mIsWebCamErrorOccur)
                    {
                        DisableControls(picboxReadBarcode);
                        DisableControls(pictureBoxCustomize);
                        break;
                    }

                    InitWebCamControls();

                    if (mIsWebCamErrorOccur)
                    {
                        DisableControls(picboxReadBarcode);
                        DisableControls(pictureBoxCustomize);
                        break;
                    }

                    if(mCameraManager.GetCameraNames()!=null&& mCameraManager.GetCameraNames().Count!=0)
                    {
                        if(cbxWebCamSrc.SelectedIndex>=0 && cbxWebCamSrc.SelectedIndex<mCameraManager.GetCameraNames().Count)
                        {
                            Camera tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                            if (tempCamera == null)
                            {
                                return;
                            }
                            tempCamera.SetVideoContainer(picBoxWebCam.Handle);
                            tempCamera.Open();
                            tempCamera.CurrentResolution = GetCamResolution();
                            ResizeVideoWindow(0);
                            picBoxWebCam.Visible = true;
                            picBoxWebCam.BringToFront();
                        }
                    }

                    if (ExistWebCam && !string.IsNullOrEmpty(cbxWebCamSrc.Text) && !string.IsNullOrEmpty(cbxWebCamRes.Text))
                    {
                        EnableControls(picboxReadBarcode);
                        EnableControls(pictureBoxCustomize);
                    }
                    else
                    {
                        DisableControls(picboxReadBarcode);
                        DisableControls(pictureBoxCustomize);
                    }
                    break;
                    default:
                    break;
            }
        }


        private static IEnumerable<TabHead> GetNeighborTabHead(TabHead curTabHead)
        {
            if (curTabHead == null || curTabHead.Parent == null) return new List<TabHead>();

            var neighborTabs = new List<TabHead>();

            foreach (var control in curTabHead.Parent.Controls)
            {
                if((control as TabHead != null) && control != curTabHead) neighborTabs.Add(control as TabHead);
            }

            return neighborTabs;
        }

        #endregion

        #region read Barcode


        private void picboxReadBarcode_Click(object sender, EventArgs e)
        {
               
            if (picBoxWebCam.Visible)
            {
                picBoxWebCam.Image = null;
                if (!ExistWebCam)
                {
                    MessageBox.Show(this, "There is no WebCam detected!\n " +
                                          "Please ensure that at least one (virtual) WebCam is installed.", "Information");
                    return;
                }
               
                TurnOnReading(true);
            }
            else
            {
                ReadFromImage();
            }
        }

        private void picboxStopBarcode_Click(object sender, EventArgs e)
        {
            if (picBoxWebCam.Visible)
            {
                TurnOnReading(false);
            }
        }
		
        private void postShowFrameResults(Bitmap bitmap, TextResult[] textResults, int timeElapsed,Exception ex)
        {
            this.TurnOnReading(false);

            if (textResults != null)
            {
                picBoxWebCam.Image = null;

                var tempBitmap = new Bitmap(bitmap.Width, bitmap.Height);
                using (var g = Graphics.FromImage(tempBitmap))
                {
                    g.DrawImage(bitmap, 0, 0);
                    for (int i = 0; i < textResults.Length;i++)
                    {
                        Rectangle tempRectangle = ConvertLocationPointToRect(textResults[i].LocalizationResult.ResultPoints);
                        g.DrawRectangle(new Pen(Color.FromArgb(255, 0, 0), 2), tempRectangle);
                    }
                }

                Camera tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                tempCamera.Close();
                tempCamera.Dispose();
                picBoxWebCam.Image = tempBitmap;
                this.ShowResult(textResults, timeElapsed);
            }
            if(ex !=null)
            {
                MessageBox.Show(ex.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //int imageindex = 0;
        private void ReadFromFrame(Bitmap bitmap)
        {
            UpdateRuntimeSettingsWithUISetting();
            TextResult[] bars = null;
            Bitmap tempBitmap = ((Bitmap)(bitmap)).Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
            int timeElapsed = 0;
            
            try
            {
                DateTime beforeRead = DateTime.Now;

                bars = mBarcodeReader.DecodeBitmap(bitmap,"");
               
                DateTime afterRead = DateTime.Now;
                timeElapsed = (int)(afterRead - beforeRead).TotalMilliseconds;

                if (bars == null || bars.Length <= 0)
                {
                    return;
                }

                this.BeginInvoke(mPostShowFrameResults, tempBitmap,bars, timeElapsed,null);
            }
            catch (Exception ex)
            {
                this.Invoke(mPostShowFrameResults, new object[] { bitmap, bars, timeElapsed,ex});
            }
        }
		        
        private static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;

            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2") + " ");
                }

                hexString = strB.ToString();

            }

            return hexString;
        }
        private void UpdateRuntimeSettingsWithUISetting()
        {
            mBarcodeReader.ResetRuntimeSettings();
            UpdateBarcodeFormat();
            if (mbCustom)
            {
                PublicRuntimeSettings runtimeSettings = mBarcodeReader.GetRuntimeSettings();
                runtimeSettings.BarcodeFormatIds = (int)this.mEmBarcodeFormat;
                if (!this.tbExpectedBarcodesCount.Text.Equals(""))
                    runtimeSettings.ExpectedBarcodesCount = Int32.Parse(this.tbExpectedBarcodesCount.Text);
                runtimeSettings.DeblurLevel = cmbDeblurLevel_SelectedIndex;// this.cmbDeblurLevel.SelectedIndex;
                for (int i = 0; i < runtimeSettings.LocalizationModes.Length; i++)
                    runtimeSettings.LocalizationModes[i] = EnumLocalizationMode.LM_SKIP;
                switch (this.cmbLocalizationModes_SelectedIndex)
                {
                    case 0:
                        runtimeSettings.LocalizationModes = mNormalRuntimeSettings.LocalizationModes;
                        break;
                    case 1:
                        runtimeSettings.LocalizationModes[0] = EnumLocalizationMode.LM_CONNECTED_BLOCKS;
                        break;
                    case 2:
                        runtimeSettings.LocalizationModes[0] = EnumLocalizationMode.LM_STATISTICS;
                        break;
                    case 3:
                        runtimeSettings.LocalizationModes[0] = EnumLocalizationMode.LM_LINES;
                        break;
                    case 4:
                        runtimeSettings.LocalizationModes[0] = EnumLocalizationMode.LM_SCAN_DIRECTLY;
                        break;
                    case 5:
                        runtimeSettings.LocalizationModes[0] = EnumLocalizationMode.LM_CONNECTED_BLOCKS;
                        runtimeSettings.LocalizationModes[1] = EnumLocalizationMode.LM_STATISTICS;
                        break;
                }

                runtimeSettings.FurtherModes.TextFilterModes[0] = (this.cbTextFilterMode.CheckState == CheckState.Checked) ? EnumTextFilterMode.TFM_GENERAL_CONTOUR : EnumTextFilterMode.TFM_SKIP;
                runtimeSettings.FurtherModes.RegionPredetectionModes[0] = (this.cbRegionPredetectionMode.CheckState == CheckState.Checked) ? EnumRegionPredetectionMode.RPM_GENERAL_RGB_CONTRAST : EnumRegionPredetectionMode.RPM_SKIP;

                runtimeSettings.ScaleDownThreshold = (Int32.Parse(this.tbScaleDownThreshold.Text) < 512) ? 512 : Int32.Parse(this.tbScaleDownThreshold.Text);
                switch (this.cmbGrayscaleTransformationModes_SelectedIndex)
                {
                    case 0:
                        runtimeSettings.FurtherModes.GrayscaleTransformationModes[0] = EnumGrayscaleTransformationMode.GTM_ORIGINAL;
                        runtimeSettings.FurtherModes.GrayscaleTransformationModes[1] = EnumGrayscaleTransformationMode.GTM_INVERTED;
                        break;
                    case 1:
                        runtimeSettings.FurtherModes.GrayscaleTransformationModes[0] = EnumGrayscaleTransformationMode.GTM_INVERTED;
                        runtimeSettings.FurtherModes.GrayscaleTransformationModes[1] = EnumGrayscaleTransformationMode.GTM_SKIP;
                        break;
                    case 2:
                        runtimeSettings.FurtherModes.GrayscaleTransformationModes[0] = EnumGrayscaleTransformationMode.GTM_ORIGINAL;
                        runtimeSettings.FurtherModes.GrayscaleTransformationModes[1] = EnumGrayscaleTransformationMode.GTM_SKIP;
                        break;
                }

                switch (this.cmbImagePreprocessingModes_SelectedIndex)
                {
                    case 0:
                        runtimeSettings.FurtherModes.ImagePreprocessingModes[0] = EnumImagePreprocessingMode.IPM_GENERAL;
                        break;
                    case 1:
                        runtimeSettings.FurtherModes.ImagePreprocessingModes[0] = EnumImagePreprocessingMode.IPM_GRAY_EQUALIZE;
                        break;
                    case 2:
                        runtimeSettings.FurtherModes.ImagePreprocessingModes[0] = EnumImagePreprocessingMode.IPM_GRAY_SMOOTH;
                        break;
                    case 3:
                        runtimeSettings.FurtherModes.ImagePreprocessingModes[0] = EnumImagePreprocessingMode.IPM_SHARPEN_SMOOTH;
                        break;
                }

                runtimeSettings.MinResultConfidence = this.cmbMinResultConfidence_SelectedIndex * 10;

                runtimeSettings.FurtherModes.TextureDetectionModes[0] = (this.cmbTextureDetectionSensitivity_SelectedIndex == 0) ? EnumTextureDetectionMode.TDM_SKIP : EnumTextureDetectionMode.TDM_GENERAL_WIDTH_CONCENTRATION;

                mBarcodeReader.UpdateRuntimeSettings(runtimeSettings);

                string strErrorMessage;
                if(this.cmbTextureDetectionSensitivity_SelectedIndex != 0)
                    mBarcodeReader.SetModeArgument("TextureDetectionModes", 0, "Sensitivity", this.cmbTextureDetectionSensitivity_SelectedIndex.ToString(), out strErrorMessage);
                if (!this.tbBinarizationBlockSize.Text.Equals(""))
                    mBarcodeReader.SetModeArgument("BinarizationModes", 0, "BlockSizeX", this.tbBinarizationBlockSize.Text, out strErrorMessage);
            }
            else
            {
                // 0 Best Speed. 1 Balance. 2 Best Coverage.
                switch (miRecognitionMode)
                {
                    case 0:
                        PublicRuntimeSettings tempBestSpeed = mBarcodeReader.GetRuntimeSettings();
                            tempBestSpeed.BarcodeFormatIds = (int)this.mEmBarcodeFormat;
                            tempBestSpeed.LocalizationModes[0] = EnumLocalizationMode.LM_SCAN_DIRECTLY;
                            for (int i = 1; i < tempBestSpeed.LocalizationModes.Length; i++)
                                tempBestSpeed.LocalizationModes[i] = EnumLocalizationMode.LM_SKIP;
                            tempBestSpeed.DeblurLevel = 3;
                            tempBestSpeed.ExpectedBarcodesCount = 512;
                            tempBestSpeed.ScaleDownThreshold = 2300;
                            for (int i = 0; i < tempBestSpeed.FurtherModes.TextFilterModes.Length;i++ )
                                tempBestSpeed.FurtherModes.TextFilterModes[i] = EnumTextFilterMode.TFM_SKIP;
                            mBarcodeReader.UpdateRuntimeSettings(tempBestSpeed);
                            break;
                    case 1:
                        PublicRuntimeSettings tempBalance = mBarcodeReader.GetRuntimeSettings();
                        tempBalance.BarcodeFormatIds = (int)this.mEmBarcodeFormat;
                        tempBalance.LocalizationModes[0] = EnumLocalizationMode.LM_CONNECTED_BLOCKS;
                        tempBalance.LocalizationModes[1] = EnumLocalizationMode.LM_STATISTICS;
                        for (int i = 2; i < tempBalance.LocalizationModes.Length; i++)
                            tempBalance.LocalizationModes[i] = EnumLocalizationMode.LM_SKIP;
                        tempBalance.DeblurLevel = 5;
                        tempBalance.ExpectedBarcodesCount = 512;
                        tempBalance.ScaleDownThreshold = 2300;
                        tempBalance.FurtherModes.TextFilterModes[0] = EnumTextFilterMode.TFM_GENERAL_CONTOUR;
                        for (int i = 1; i < tempBalance.FurtherModes.TextFilterModes.Length; i++)
                            tempBalance.FurtherModes.TextFilterModes[i] = EnumTextFilterMode.TFM_SKIP;
                        mBarcodeReader.UpdateRuntimeSettings(tempBalance);
                        break;
                    case 2:
                        PublicRuntimeSettings tempCoverage = mBarcodeReader.GetRuntimeSettings();
                        tempCoverage.BarcodeFormatIds = (int)this.mEmBarcodeFormat;
                        // use default value of LocalizationModes
                        tempCoverage.DeblurLevel = 9;
                        tempCoverage.ExpectedBarcodesCount = 512;
                        tempCoverage.ScaleDownThreshold = 214748347;
                        tempCoverage.FurtherModes.TextFilterModes[0] = EnumTextFilterMode.TFM_GENERAL_CONTOUR;
                        for (int i = 1; i < tempCoverage.FurtherModes.TextFilterModes.Length; i++)
                            tempCoverage.FurtherModes.TextFilterModes[i] = EnumTextFilterMode.TFM_SKIP;
                        mBarcodeReader.UpdateRuntimeSettings(tempCoverage);
                        break;
                }
            }
        }
        private void ReadFromImage()
        {
            
            ShowSelectedImageArea();

            if (mImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdateRuntimeSettingsWithUISetting();            

                Bitmap bmp = (Bitmap)(mImageCore.ImageBuffer.GetBitmap(mImageCore.ImageBuffer.CurrentImageIndexInBuffer));
                DateTime beforeRead = DateTime.Now;
   
                TextResult[] textResults = mBarcodeReader.DecodeBitmap(bmp, "");
               
                DateTime afterRead = DateTime.Now;
                int timeElapsed = (int)(afterRead - beforeRead).TotalMilliseconds;
                this.ShowResultOnImage(bmp, textResults);
                this.ShowResult(textResults, timeElapsed);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowResultOnImage(Bitmap bitmap,TextResult[] textResults)
        {
            mImageCore.ImageBuffer.SetMetaData(mImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, null, true);
            if (textResults != null)
            {
                List<AnnotationData> tempListAnnotation = new List<AnnotationData>();
                int nTextResultIndex = 0;
                for (var i = 0; i < textResults.Length; i++)
                {
                    var penColor = Color.Red;
                    TextResult result = textResults[i];

                    var rectAnnotation = new AnnotationData();
                    rectAnnotation.AnnotationType = AnnotationType.enumRectangle;
                    Rectangle boundingrect = ConvertLocationPointToRect(result.LocalizationResult.ResultPoints);
                    rectAnnotation.StartPoint = new Point(boundingrect.Left, boundingrect.Top);
                    rectAnnotation.EndPoint = new Point((boundingrect.Left + boundingrect.Size.Width), (boundingrect.Top + boundingrect.Size.Height));
                    rectAnnotation.FillColor = Color.Transparent.ToArgb();
                    rectAnnotation.PenColor = penColor.ToArgb();
                    rectAnnotation.PenWidth = 3;
                    rectAnnotation.GUID = Guid.NewGuid();

                    float fsize = bitmap.Width / 48.0f;
                    if (fsize < 25)
                        fsize = 25;

                    Font textFont = new Font("Times New Roman", fsize, FontStyle.Bold);

                    string strNo = (result!=null)?"[" + (nTextResultIndex++ + 1) + "]":"";
                    SizeF textSize = Graphics.FromHwnd(IntPtr.Zero).MeasureString(strNo, textFont);

                    var textAnnotation = new AnnotationData();
                    textAnnotation.AnnotationType = AnnotationType.enumText;
                    textAnnotation.StartPoint = new Point(boundingrect.Left, (int)(boundingrect.Top - textSize.Height * 1.25f));
                    textAnnotation.EndPoint = new Point((textAnnotation.StartPoint.X + (int)textSize.Width * 2), (int)(textAnnotation.StartPoint.Y + textSize.Height * 1.25f));
                    if (textAnnotation.StartPoint.X < 0)
                    {
                        textAnnotation.EndPoint = new Point((textAnnotation.EndPoint.X + textAnnotation.StartPoint.X), textAnnotation.EndPoint.Y);
                        textAnnotation.StartPoint = new Point(0, textAnnotation.StartPoint.Y);
                    }
                    if (textAnnotation.StartPoint.Y < 0)
                    {
                        textAnnotation.EndPoint = new Point(textAnnotation.EndPoint.X, (textAnnotation.EndPoint.Y - textAnnotation.StartPoint.Y));
                        textAnnotation.StartPoint = new Point(textAnnotation.StartPoint.X, 0);
                    }

                    textAnnotation.TextContent = strNo;
                    AnnoTextFont tempFont = new AnnoTextFont();
                    tempFont.TextColor = Color.Red.ToArgb();
                    tempFont.Size = (int)fsize;
                    tempFont.Name = "Times New Roman";
                    textAnnotation.FontType = tempFont;
                    textAnnotation.GUID = Guid.NewGuid();

                    tempListAnnotation.Add(rectAnnotation);
                    tempListAnnotation.Add(textAnnotation);
                }
                mImageCore.ImageBuffer.SetMetaData(mImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempListAnnotation, true);
            }
        }
        private bool IsEqualPointsArray(Point []ptArrayA,Point []ptArrayB)
        {
            if (ptArrayA == ptArrayB)
                return true;
           
            if (ptArrayA!=null && ptArrayB!=null && (ptArrayA.Length == ptArrayB.Length))
            {
                for(int i=0;i<ptArrayA.Length;i++)
                {
                    if(ptArrayA[i].X != ptArrayB[i].X || ptArrayA[i].Y != ptArrayB[i].Y)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private void ShowResult(TextResult[] textResult, int timeElapsed)
        {
            string strResult;

            if (textResult == null)
            {
                strResult = "No barcode found. Total time spent: " + timeElapsed + " ms\r\n";
            }
            else
            {
                strResult = "Total barcode(s) found: " + textResult.Length + ". Total time spent: " + timeElapsed + " ms\r\n";


                for (var i = 0; i < textResult.Length; i++)
                {
                    Rectangle tempRectangle = ConvertLocationPointToRect(textResult[i].LocalizationResult.ResultPoints);
                    strResult += string.Format("  Barcode: {0}\r\n", (i + 1));
                    strResult += string.Format("    Type: {0}\r\n", textResult[i].BarcodeFormat.ToString());
                    strResult = AddBarcodeText(strResult, textResult[i].BarcodeText);
                    strResult += string.Format("    Hex Data: {0}\r\n", ToHexString(textResult[i].BarcodeBytes));
                    strResult += string.Format("    Region: {{Left: {0}, Top: {1}, Width: {2}, Height: {3}}}\r\n", tempRectangle.Left.ToString(),
                                                   tempRectangle.Top.ToString(), tempRectangle.Width.ToString(), tempRectangle.Height.ToString());
                    strResult += string.Format("    Module Size: {0}\r\n", textResult[i].LocalizationResult.ModuleSize);
                    strResult += string.Format("    Angle: {0}\r\n", textResult[i].LocalizationResult.Angle);
                    strResult += "\r\n";
                }
            }
            this.ShowBarcodeResultPanel(true);
            this.tbxResult.Text = strResult;
        }

        private string AddBarcodeText(string result, string barcodetext)
        {
            string temp = "";
            string temp1 = barcodetext;
            for (int j = 0; j < temp1.Length; j++)
            {
                if (temp1[j] == '\0')
                {
                    temp += "\\";
                    temp += "0";
                }
                else
                {
                    temp += temp1[j].ToString();
                }
            }
            result += string.Format("    Value: {0}\r\n", temp);
            return result;  
        }

        private void ShowSelectedImageArea()
        {
            if (mImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                var recSelArea = dsViewer.GetSelectionRect(mImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                var imgCurrent =  mImageCore.ImageBuffer.GetBitmap(mImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            }
        }

        private void tbxBarcodeLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            var array = Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b') e.Handled = false;
        }

        #endregion Read Barcode
        
        #region webCam relevant

        private void TurnOnReading(bool isOn)
        {
           mIsTurnOnReading = isOn;

            if (mIsTurnOnReading)
            {
                Camera tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                if (!mIfHasAddedOnFrameCaptureEvent)
                {
                    tempCamera.Open();
                    tempCamera.SetVideoContainer(picBoxWebCam.Handle);
                    tempCamera.CurrentResolution = GetCamResolution();
                    ResizeVideoWindow(0);
                    tempCamera.OnFrameCaptrue +=tempCamera_OnFrameCaptrue;
                    mIfHasAddedOnFrameCaptureEvent = true;
                }
                this.SwitchButtonState(true);
            }
            else
            {
                if (mIfHasAddedOnFrameCaptureEvent)
                {
                    Camera tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                    tempCamera.OnFrameCaptrue -= tempCamera_OnFrameCaptrue;
                }
                mIfHasAddedOnFrameCaptureEvent = false;
                this.SwitchButtonState(false);
            }
        }

        void tempCamera_OnFrameCaptrue(Bitmap bitmap)
        {
            if (mIsTurnOnReading)
            {
                ReadFromFrame(bitmap);
            }
        }

        private CamResolution GetCamResolution()
        {
            var resAry = cbxWebCamRes.Text.Split('x');
            int width, height;
            return resAry.Length > 1 && int.TryParse(resAry[0],out width) && int.TryParse(resAry[1],out 
                height)?new CamResolution(width,height):mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex).CurrentResolution; 
        }

        private void InitWebCamControls()
        {
            try
            {
                InitCbxWebCamSrc();
                //InitCbxWebCamRes();
                picBoxWebCam.Image = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResizeVideoWindow(int iRotate)
        {
            Camera tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
            var camResolution = tempCamera.CurrentResolution;
            if (camResolution == null || camResolution.Width <= 0 || camResolution.Height <= 0) return;

            if (iRotate%2 == 0)
            {
                var iVideoWidth = picBoxWebCam.Width;
                var iVideoHeight = picBoxWebCam.Width*camResolution.Height/camResolution.Width;
                var iContentHeight = picBoxWebCam.Height - picBoxWebCam.Margin.Top - picBoxWebCam.Margin.Bottom - picBoxWebCam.Padding.Top - picBoxWebCam.Padding.Bottom;
                if (iVideoHeight < iContentHeight)
                {
                    tempCamera.ResizeVideoWindow(0, (iContentHeight - iVideoHeight)/2, iVideoWidth, iVideoHeight);
                }
                else
                    tempCamera.ResizeVideoWindow(0, 0, picBoxWebCam.Width, picBoxWebCam.Height);
            }
            else
            {
                var iVideoHeight = picBoxWebCam.Height;
                var iVideoWidth = picBoxWebCam.Height*camResolution.Height/camResolution.Width;
                var iContentWidth = picBoxWebCam.Width - picBoxWebCam.Margin.Right - picBoxWebCam.Margin.Left - picBoxWebCam.Padding.Right - picBoxWebCam.Padding.Left;

                if (iVideoWidth < iContentWidth)
                    tempCamera.ResizeVideoWindow((iContentWidth - iVideoWidth) / 2, 0, iVideoWidth, iVideoHeight);
                else
                    tempCamera.ResizeVideoWindow(0, 0, picBoxWebCam.Width, picBoxWebCam.Height);
            }
        }

        private void cbxWebCamSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bIfCameraSourceUpdated)
            {
                CameraManager tempCameraManager = new CameraManager(dntLicenseKeys);
                if(mCameraManager.GetCameraNames()!=null)
                {
                    foreach (string temp in mCameraManager.GetCameraNames())
                    {
                        mCameraManager.SelectCamera(temp).Dispose();
                    }
                }

                mCameraManager = null;
                mCameraManager = tempCameraManager;
            }
            else
            {
                TurnOnReading(false);
            }

            Camera tempCamera = mCameraManager.SelectCamera(mCameraManager.CurrentSourceName);
            tempCamera.Close();
            tempCamera.Dispose();
            tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
            picBoxWebCam.Image = null;
            InitCbxWebCamRes();
            if (mIsWebCamErrorOccur) return;

            tempCamera.SetVideoContainer(picBoxWebCam.Handle);
            tempCamera.Open();
            tempCamera.CurrentResolution = GetCamResolution();
            ResizeVideoWindow(0);
            picBoxWebCam.Visible = true;
            picBoxWebCam.BringToFront();
            EnableControls(picboxReadBarcode);
            EnableControls(pictureBoxCustomize);
        }

        private string m_CurrentCameraName = null;
        private bool m_bIfCameraSourceUpdated = false;
        private void cbxWebCamSrc_DropDown(object sender, EventArgs e)
        {
            TurnOnReading(false);
            m_bIfCameraSourceUpdated = false;
            m_CurrentCameraName = mCameraManager.CurrentSourceName;

            CameraManager tempCameraManager = new CameraManager(dntLicenseKeys);

            if (mCameraManager.GetCameraNames() == null && tempCameraManager.GetCameraNames()!=null)
            {
                m_bIfCameraSourceUpdated = true;
                picBoxWebCam.Visible = true;
                picBoxWebCam.BringToFront();
            }

            if (mCameraManager.GetCameraNames() != null && tempCameraManager.GetCameraNames() == null)
            {
                m_bIfCameraSourceUpdated = true;
            }


            if(tempCameraManager.GetCameraNames()!=null && mCameraManager.GetCameraNames()!=null)
            {
                if (tempCameraManager.GetCameraNames().Count != mCameraManager.GetCameraNames().Count)
                {
                    m_bIfCameraSourceUpdated = true;
                }
                else
                {
                    List<string> temp1 = tempCameraManager.GetCameraNames();
                    List<string> temp2 = mCameraManager.GetCameraNames();
                    for (short i = 0; i < mCameraManager.GetCameraNames().Count; i++)
                    {
                        if(temp1[i]!=temp2[i])
                        {
                            m_bIfCameraSourceUpdated = true;
                        }
                    }
                }
            }
            if (m_bIfCameraSourceUpdated)
            {
                if (tempCameraManager.GetCameraNames() != null)
                {
                    cbxWebCamSrc.Items.Clear();
                    foreach (string temp in tempCameraManager.GetCameraNames())
                    {
                        cbxWebCamSrc.Items.Add(temp);
                    }
                    cbxWebCamSrc.SelectedIndex = 0;
                }
            }
            if (tempCameraManager.GetCameraNames() != null)
            {
                tempCameraManager.Dispose();
            }

        }
        private void cbxWebCamRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnOnReading(false);

            picBoxWebCam.Image = null;
            Camera tempCamera = mCameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
            tempCamera.CurrentResolution = GetCamResolution();
            ResizeVideoWindow(0);
        }
        #endregion

        #region barcode result


        private void picboxResultTitle_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseOffset2 = new Point(-e.X, -e.Y);
        }

        private bool IsInForm(Point point)
        {
            return (point.X > (picBoxWebCam.Visible ? 12 : 86)) && point.X < 363 && point.Y > 50 && point.Y < 471;
        }

        private void lblCloseResult_MouseLeave(object sender, EventArgs e)
        {
            lblCloseResult.ForeColor = Color.Black;
        }

        private void lblCloseResult_Click(object sender, EventArgs e)
        {
            ShowBarcodeResultPanel(false);
        }

        private void lblCloseResult_MouseHover(object sender, EventArgs e)
        {
            lblCloseResult.ForeColor = Color.Red;
        }

        private void ShowBarcodeResultPanel(bool bVisible)
        {
            if (bVisible)
            {
                mPanelResult.Visible = true;
                mPanelResult.Focus();
                this.mRoundedRectanglePanelAcquireLoad.Visible = false;
                this.mRoundedRectanglePanelBarcode.Visible = false;
                this.panelReadBarcode.Visible = false;
            }
            else
            {
                mPanelResult.Visible = false;
                this.mRoundedRectanglePanelAcquireLoad.Visible = true;
                this.mRoundedRectanglePanelBarcode.Visible = true;
                this.panelReadBarcode.Visible = true;
            }
        }
        #endregion

        #region AcquireImage Callback

        public void OnPostAllTransfers()
        {
            CrossThreadOperationControl crossDelegate = delegate()
            {
                dsViewer.Visible = true;
                CheckImageCount();
                EnableControls(picboxScan);
            };
            Invoke(crossDelegate);
        }

        public bool OnPostTransfer(Bitmap bit)
        {
            mImageCore.IO.LoadImage(bit);
            return true;
        }

        public void OnPreAllTransfers()
        {
        }

        public bool OnPreTransfer()
        {
            return true;
        }

        public void OnSourceUIClose()
        {
        }

        public void OnTransferCancelled()
        {

        }

        public void OnTransferError()
        {
        }
        #endregion

        #region
        public void LoadConvertResult(ConvertResult result)
        {
            mImageCore.IO.LoadImage(result.Image);
            mImageCore.ImageBuffer.SetMetaData(mImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, true);

        }
        #endregion

        #region PDF Rasterizer Callback
        public object GetAnnotations(int iPageNumber)
        {
            return null;
        }

        public Bitmap GetImage(int iPageNumber)
        {
            return null;
        }

        public int GetPageCount()
        {
            return 0;
        }
        #endregion

        private void BarcodeReaderDemo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(mTwainManager!=null)
            {
                mTwainManager.Dispose();
            }
        }
        private void BarcodeReaderDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
        }
        private Rectangle ConvertLocationPointToRect(Point[] points)
        {
            int left = points[0].X, top = points[0].Y, right = points[1].X, bottom = points[1].Y;
            for (int i = 0; i < points.Length;i++)
            {
               
                if(points[i].X<left)
                {
                    left = points[i].X;
                }

                if (points[i].X>right)
                {
                    right = points[i].X;
                }

                if(points[i].Y<top)
                {
                    top = points[i].Y;
                }

                if(points[i].Y>bottom)
                {
                    bottom = points[i].Y;
                }
            }
            Rectangle temp =new Rectangle(left, top, (right - left), (bottom - top));
            return temp;
        }

        private void btnShowAllOneD_Click(object sender, EventArgs e)
        {
            if (this.panelOneDetail.Visible)
            {
                this.panelOneDetail.Visible = false;
                btnShowAllOneD.Text = "show all";
                this.btnShowAllOneD.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_down;
            }
            else
            {
                this.panelOneDetail.Visible = true;
                btnShowAllOneD.Text = "hide all";
                this.btnShowAllOneD.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_up;
                panelOneDetail.BringToFront();
            }


        }

        private void btnEditSettings_Click(object sender, EventArgs e)
        {
            SwitchCustomControls(true);
        }

        private void SwitchCustomControls(bool bCustomizeSettings)
        {
            this.panelOneDetail.Visible = false;
            btnShowAllOneD.Text = "show all";
            this.btnShowAllOneD.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_down;
            if (bCustomizeSettings)
            {
                btnExportSettings.Visible = true;
                mbCustom = true;
                SetCustomizePanelValuseFromPublicRuntimeSettings();
                mRoundedRectanglePanelBarcode.Controls.Remove(panelNormalSettings);


                this.panelReadBarcode.Location = new System.Drawing.Point(0, 0);
                panelReadBarcode.Dock = DockStyle.Fill;
                this.panelBarcodeReaderParent.Controls.Add(panelReadBarcode);


                this.panelFormat.Location = new System.Drawing.Point(0, 0);
                this.panelFormatParent.Controls.Add(this.panelFormat);
                this.panelOneDetail.Location = new System.Drawing.Point(0, 65);
               
                panelCustomSettings.Controls.Add(this.panelOneDetail);
                mRoundedRectanglePanelBarcode.AutoSize = false;
                mRoundedRectanglePanelBarcode.Size = new Size(311, 376);
                mRoundedRectanglePanelBarcode.Controls.Add(this.panelCustom);
            }
            else
            {
                btnExportSettings.Visible = false;
                mbCustom = false;
                mRoundedRectanglePanelBarcode.Controls.Remove(this.panelCustom);             

                this.panelOneDetail.Location = new System.Drawing.Point(0, 109);
                this.panelNormalSettings.Controls.Add(this.panelOneDetail);

                this.panelFormat.Location = new System.Drawing.Point(0, 44);
                this.panelNormalSettings.Controls.Add(this.panelFormat);
                //this.panelNormalSettings.Visible = true;
                this.panelReadBarcode.Location = new System.Drawing.Point(20, 111);
                panelReadBarcode.Dock = DockStyle.None;
                this.panelRecognitionMode.Controls.Add(this.panelReadBarcode);

                mRoundedRectanglePanelBarcode.Location = new Point(12, 294);
                mRoundedRectanglePanelBarcode.Size = new Size(310, 376);
                mRoundedRectanglePanelBarcode.AutoSize = false;

                mRoundedRectanglePanelBarcode.Controls.Add(this.panelNormalSettings);
               
            }
           
        }

        private void pbCloseCustomPanel_Click(object sender, EventArgs e)
        {
            SwitchCustomControls(false);
        }

        private void rbMode_CheckedChanged(object sender, EventArgs e)
        {
            // 0 Best Speed. 1 Balance. 2 Best Coverage.
            if (!(sender is RadioButton)) return;
            if((sender as RadioButton).Name.CompareTo(this.rbBalance.Name)==0 && this.rbBalance.Checked)
            {
                miRecognitionMode = 1;
               
            }
            else if((sender as RadioButton).Name.CompareTo(this.rbBestCoverage.Name) == 0 && this.rbBestCoverage.Checked)
            {
                miRecognitionMode = 2;
            }
            else if((sender as RadioButton).Name.CompareTo(this.rbBestSpeed.Name) == 0 && this.rbBestSpeed.Checked)
            {
                miRecognitionMode = 0;
            }
        }

        private void cbOneD_CheckStateChanged(object sender, EventArgs e)
        {
            if(cbOneD.CheckState == CheckState.Unchecked)
            {
                cbUPCE.Checked = cbEAN8.Checked = cbEAN13.Checked = cbCODABAR.Checked = cbITF.Checked =
                cbCODE93.Checked = cbCODE128.Checked = cbCOD39.Checked = cbUPCA.Checked = cbINDUSTRIAL25.Checked =false;
            }
            else if (cbOneD.CheckState == CheckState.Checked)
            {
                cbUPCE.Checked = cbEAN8.Checked = cbEAN13.Checked = cbCODABAR.Checked = cbITF.Checked =
                cbCODE93.Checked = cbCODE128.Checked = cbCOD39.Checked = cbUPCA.Checked = cbINDUSTRIAL25.Checked = true;
            }
        }
        private void rbOneMode_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUPCE.Checked   && cbEAN8.Checked    && cbEAN13.Checked && cbCODABAR.Checked      && cbITF.Checked &&
               cbCODE93.Checked && cbCODE128.Checked && cbCOD39.Checked && cbINDUSTRIAL25.Checked && cbUPCA.Checked)
            {
                cbOneD.CheckState = CheckState.Checked;
            }else if(!cbUPCE.Checked &&   !cbEAN8.Checked &&    !cbEAN13.Checked && !cbCODABAR.Checked &&      !cbITF.Checked &&
                     !cbCODE93.Checked && !cbCODE128.Checked && !cbCOD39.Checked && !cbINDUSTRIAL25.Checked && !cbUPCA.Checked)
            {
                cbOneD.CheckState = CheckState.Unchecked;
            }
            else
            {
                cbOneD.CheckState = CheckState.Indeterminate;
            }
            UpdateBarcodeFormat();
        }
        
        private void cbBarcodeFormat_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBarcodeFormat();
        }
        private void UpdateBarcodeFormat()
        {
            mEmBarcodeFormat = 0;
            mEmBarcodeFormat = this.cbAZTEC.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_AZTEC) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbDataMatrix.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_DATAMATRIX) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbQRcode.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_QR_CODE) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbPDF417.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_PDF417) : mEmBarcodeFormat;

            mEmBarcodeFormat = this.cbINDUSTRIAL25.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_INDUSTRIAL_25) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbUPCE.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_UPC_E) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbUPCA.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_UPC_A) : mEmBarcodeFormat;

            mEmBarcodeFormat = this.cbEAN8.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_EAN_8) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbEAN13.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_EAN_13) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbCODABAR.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_CODABAR) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbITF.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_ITF) : mEmBarcodeFormat;

            mEmBarcodeFormat = this.cbCODE93.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_CODE_93) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbCODE128.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_CODE_128) : mEmBarcodeFormat;
            mEmBarcodeFormat = this.cbCOD39.Checked ? (mEmBarcodeFormat | EnumBarcodeFormat.BF_CODE_39) : mEmBarcodeFormat;
        }

        private void SetCustomizePanelValuseFromPublicRuntimeSettings()
        {
            PublicRuntimeSettings runtimeSettings = mBarcodeReader.GetRuntimeSettings();
            switch (miRecognitionMode)
            {
                case 0:
                    this.cmbLocalizationModes.SelectedIndex = 4;
                    this.cmbDeblurLevel.SelectedIndex = 3;
                    this.tbExpectedBarcodesCount.Text = "512";
                    this.tbScaleDownThreshold.Text = "2300";
                    this.cbTextFilterMode.CheckState = CheckState.Unchecked;
                    break;
                case 1:
                    this.cmbLocalizationModes.SelectedIndex = 5;
                    this.cmbDeblurLevel.SelectedIndex = 5;
                    this.tbExpectedBarcodesCount.Text = "512";
                    this.tbScaleDownThreshold.Text = "2300";
                    this.cbTextFilterMode.CheckState = CheckState.Checked;
                    break;
                case 2:
                    this.cmbLocalizationModes.SelectedIndex = 0;
                    this.cmbDeblurLevel.SelectedIndex = 9;
                    this.tbExpectedBarcodesCount.Text = "512";
                    this.tbScaleDownThreshold.Text = "214748347";
                    this.cbTextFilterMode.CheckState = CheckState.Checked;
                    break;
            }
            this.cbRegionPredetectionMode.CheckState = (runtimeSettings.FurtherModes.RegionPredetectionModes[0] == EnumRegionPredetectionMode.RPM_GENERAL_RGB_CONTRAST) ? CheckState.Checked : CheckState.Unchecked;
            if (runtimeSettings.FurtherModes.GrayscaleTransformationModes[1] != EnumGrayscaleTransformationMode.GTM_SKIP)
                this.cmbGrayscaleTransformationModes.SelectedIndex = 0;
            else
                this.cmbGrayscaleTransformationModes.SelectedIndex = (int)runtimeSettings.FurtherModes.GrayscaleTransformationModes[0];
            switch (runtimeSettings.FurtherModes.ImagePreprocessingModes[0])
            {
                case EnumImagePreprocessingMode.IPM_GENERAL:
                    this.cmbImagePreprocessingModes.SelectedIndex = 0;
                    break;
                case EnumImagePreprocessingMode.IPM_GRAY_EQUALIZE:
                    this.cmbImagePreprocessingModes.SelectedIndex = 1;
                    break;
                case EnumImagePreprocessingMode.IPM_GRAY_SMOOTH:
                    this.cmbImagePreprocessingModes.SelectedIndex = 2;
                    break;
                case EnumImagePreprocessingMode.IPM_SHARPEN_SMOOTH:
                    this.cmbImagePreprocessingModes.SelectedIndex = 3;
                    break;
                default:
                    this.cmbImagePreprocessingModes.SelectedIndex = 0;
                    break;
            }
            this.cmbMinResultConfidence.SelectedIndex = runtimeSettings.MinResultConfidence / 10;
            this.cmbTextureDetectionSensitivity.SelectedIndex = (runtimeSettings.FurtherModes.TextureDetectionModes[0] == EnumTextureDetectionMode.TDM_GENERAL_WIDTH_CONCENTRATION) ? 5 : 0;
            this.tbBinarizationBlockSize.Text = "0";

        }
        
        private void tbBinarizationBlockSize_OnLeave(object sender, EventArgs e)
        {
            int i = 0;
        }
        private void textBoxNumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(Char.IsNumber(e.KeyChar)) &&e.KeyChar !=(char)8)
            {
                e.Handled = true;
                return;
            }
            TextBox tbCurrent = (TextBox)sender;
            string strNewText = tbCurrent.Text;
            if (e.KeyChar == (char)8)
            {
                if ((tbCurrent.SelectionLength == tbCurrent.TextLength) || (tbCurrent.TextLength == 1 && tbCurrent.SelectionStart == 1))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    if (tbCurrent.SelectedText != "")
                        strNewText = tbCurrent.Text.Replace(tbCurrent.SelectedText, "");
                    else
                    {
                        if (tbCurrent.SelectionStart != 0)
                            strNewText = tbCurrent.Text.Remove(tbCurrent.SelectionStart - 1,1);
                    }
                }
            }
            else
            {
                if (tbCurrent.SelectedText != "")
                    strNewText = tbCurrent.Text.Replace(tbCurrent.SelectedText, e.KeyChar.ToString());
                else
                {
                    if (tbCurrent.TextLength < tbCurrent.MaxLength)
                        strNewText = tbCurrent.Text.Insert(tbCurrent.SelectionStart, e.KeyChar.ToString());
                }
            }
            try
            {
                int iValue = int.Parse(strNewText);
                if ((tbCurrent.Name == "tbBinarizationBlockSize") && (iValue > 1000))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch
            {
                e.Handled = true;
                return;
            }
        }
        private void tbScaleDownThreshold_OnLeave(object sender, EventArgs e)
        {
            int iValue = int.Parse(tbScaleDownThreshold.Text);
            if (iValue < 512)
            {
                tbScaleDownThreshold.Text = "512";
            }
        }
        
        private void labelWebcamNote_Click(object sender, EventArgs e)
        {

        }

        private void btnExportSettings_Click(object sender, EventArgs e)
        {
           
            this.saveRuntimeSettingsFileDialog.ShowDialog();            
            saveRuntimeSettingsFileDialog.Filter = "|*.json";     
        }

        private void saveRuntimeSettingsFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string path = saveRuntimeSettingsFileDialog.FileName;
            if (path == "")
            {
                return;
            }
            UpdateRuntimeSettingsWithUISetting();
            mBarcodeReader.OutputSettingsToFile(path, "customsettings");
            

        }

        private void lbCustomPanelClose_MouseHover(object sender, EventArgs e)
        {
            this.lbCustomPanelClose.Image = global::Barcode_Reader_Demo.Properties.Resources.icon_closed_hover;
        }

        private void lbCustomPanelClose_MouseLeave(object sender, EventArgs e)
        {
            this.lbCustomPanelClose.Image = global::Barcode_Reader_Demo.Properties.Resources.icon_closed;
        }

        private void btnExportSettings_DragLeave(object sender, EventArgs e)
        {
            this.btnExportSettings.Image = global::Barcode_Reader_Demo.Properties.Resources.icon_output;
        }

        private void btnExportSettings_DragEnter(object sender, DragEventArgs e)
        {
            this.btnExportSettings.Image = global::Barcode_Reader_Demo.Properties.Resources.icon_output_hover;
        }

        private void pictureBoxCustomize_MouseDown(object sender, MouseEventArgs e)
        {            

            pictureBoxCustomize.Image = (Image)Resources.ResourceManager.GetObject("pictureBoxCustomize_Leave");
        }

        private void pictureBoxCustomize_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxCustomize.Image = (Image)Resources.ResourceManager.GetObject("pictureBoxCustomize_hover");
        }

        private void pictureBoxCustomize_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxCustomize.Image = (Image)Resources.ResourceManager.GetObject("pictureBoxCustomize_Leave");
        }

        private void pictureBoxCustomize_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxCustomize.Image = (Image)Resources.ResourceManager.GetObject("pictureBoxCustomize_Leave");
        }
    }
}
