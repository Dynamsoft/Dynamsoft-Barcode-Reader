using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
using System.Configuration;

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
        private delegate void PostShowFrameResultsHandler(Bitmap _bitmap, BarcodeResult[] _bars, int timeElapsed,Exception ex);

        private PostShowFrameResultsHandler _postShowFrameResults; 
        private bool _isToCrop;
        private string _lastOpenedDirectory;
        private Label _infoLabel;

        private RoundedRectanglePanel _roundedRectanglePanelAcquireLoad;
        private RoundedRectanglePanel _roundedRectanglePanelBarcode;
        private TabHead _thReadSetting;
        private TabHead _thReadMoreSetting;
        private TabHead _thLoadImage;
        private TabHead _thAcquireImage;
        private TabHead _thWebCamImage;

        private TabHead _thResult;
        private RoundedRectanglePanel _panelResult;

        private readonly BarcodeReader _br;

        private string _strPreMaxBarcodeReads;

        private bool _webCamErrorOccur = false;
        private bool _bTurnOnReading = false;
        private bool _webCamMode = false;

        private TwainManager m_TwainManager = null;
        private CameraManager m_CameraManager = null;
        private ImageCore m_ImageCore = null;
        private PDFRasterizer m_PDFRasterizer = null;
        string dbrLicenseKeys = "t0068MgAAADwWnQrQnmYBrE+QnxSdTdMgwZy/UDlCMzl8YYvDGh3Wrc/cqDLpXBscXtnCozac3tY7QG+zf6iMVndW1vsfxWI=";
	    string dntLicenseKeys = "t0068MgAAAInTAbByaFZ4c+QcO4dSdEAa23SVz765qGQc8MPZbem6H32bhjIfVnmV1fzOZSZoGpwUD1VduenxHaVdLb10bBE=";
        private bool m_IfHasAddedOnFrameCaptureEvent = false;

        #endregion

        #region property

        public bool ExistWebCam
        {
            get
            {
                var exist = false;
                if(m_CameraManager.GetCameraNames()!=null)
                {
                    exist = true;
                }

                return exist;
            }
        }

        public bool ExistScanner
        {
            get
            {
                var exist = false;
                if(m_TwainManager.SourceCount >0)
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

            _br = new BarcodeReader(dbrLicenseKeys);
            _postShowFrameResults = new PostShowFrameResultsHandler(this.postShowFrameResults);

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
            _roundedRectanglePanelAcquireLoad = new RoundedRectanglePanel();
            _roundedRectanglePanelBarcode = new RoundedRectanglePanel();
            _thReadSetting = new TabHead();
            _thReadMoreSetting = new TabHead();
            _thLoadImage = new TabHead();
            _thAcquireImage = new TabHead();
            _thWebCamImage = new TabHead();
            _thResult = new TabHead();
            _panelResult = new RoundedRectanglePanel();

            _roundedRectanglePanelAcquireLoad.SuspendLayout();
            _roundedRectanglePanelBarcode.SuspendLayout();
            _panelResult.SuspendLayout();
            
            //
            // _panelResult
            //
            _panelResult.AutoSize = true;
            _panelResult.BackColor = SystemColors.Control;
            _panelResult.Controls.Add(lblCloseResult);
            _panelResult.Controls.Add(_thResult);
            _panelResult.Controls.Add(this.tbxResult);
            _panelResult.Location = new Point(12, 12);
            _panelResult.Margin = new Padding(10, 12, 12, 0);
            _panelResult.Name = "_panelResult";
            _panelResult.Padding = new Padding(1);
            _panelResult.Size = new Size(311, 500);
            _panelResult.TabIndex = 2;

            // 
            // _thResult
            // 
            _thResult.BackColor = Color.Transparent;
            _thResult.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _thResult.ImageAlign = ContentAlignment.MiddleRight;
            _thResult.Index = 4;
            _thResult.Location = new Point(1, 1);
            _thResult.Margin = new Padding(0);
            _thResult.MultiTabHead = false;
            _thResult.Name = "_thResult";
            _thResult.Size = new Size(309, 25);
            _thResult.State = TabHead.TabHeadState.SELECTED;
            _thResult.TabIndex = 0;
            _thResult.Text = "Barcode Results";
            _thResult.TextAlign = ContentAlignment.MiddleLeft;


            // 
            // roundedRectanglePanelAcquireLoad
            // 
            _roundedRectanglePanelAcquireLoad.AutoSize = true;
            _roundedRectanglePanelAcquireLoad.BackColor = SystemColors.Control;
            _roundedRectanglePanelAcquireLoad.Controls.Add(panelLoad);
            _roundedRectanglePanelAcquireLoad.Controls.Add(panelAcquire);
            _roundedRectanglePanelAcquireLoad.Controls.Add(panelWebCam);
            _roundedRectanglePanelAcquireLoad.Controls.Add(_thLoadImage);
            _roundedRectanglePanelAcquireLoad.Controls.Add(_thAcquireImage);
            _roundedRectanglePanelAcquireLoad.Controls.Add(_thWebCamImage);
            _roundedRectanglePanelAcquireLoad.Location = new Point(12, 12);
            _roundedRectanglePanelAcquireLoad.Margin = new Padding(10, 12, 12, 0);
            _roundedRectanglePanelAcquireLoad.Name = "roundedRectanglePanelAcquireLoad";
            _roundedRectanglePanelAcquireLoad.Padding = new Padding(1);
            _roundedRectanglePanelAcquireLoad.Size = new Size(311, 270);
            _roundedRectanglePanelAcquireLoad.TabIndex = 0;
            // 
            // roundedRectanglePanelBarcode
            // 
            _roundedRectanglePanelBarcode.AutoSize = true;
            _roundedRectanglePanelBarcode.Controls.Add(panelReadSetting);
            _roundedRectanglePanelBarcode.Controls.Add(panelReadMoreSetting);
            _roundedRectanglePanelBarcode.Controls.Add(_thReadSetting);
            _roundedRectanglePanelBarcode.Controls.Add(_thReadMoreSetting);
            _roundedRectanglePanelBarcode.Location = new Point(12, 294);
            _roundedRectanglePanelBarcode.Margin = new Padding(10, 12, 12, 0);
            _roundedRectanglePanelBarcode.Name = "roundedRectanglePanelBarcode";
            _roundedRectanglePanelBarcode.Padding = new Padding(1);
            _roundedRectanglePanelBarcode.Size = new Size(311, 362);
            _roundedRectanglePanelBarcode.TabIndex = 1;
            // 
            // _thReadSetting
            // 
            _thReadSetting.BackColor = Color.Transparent;
            _thReadSetting.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _thReadSetting.ImageAlign = ContentAlignment.MiddleRight;
            _thReadSetting.Index = 3;
            _thReadSetting.Location = new Point(1, 1);
            _thReadSetting.Margin = new Padding(0);
            _thReadSetting.MultiTabHead = true;
            _thReadSetting.Name = "_thReadSetting";
            _thReadSetting.Size = new Size(154, 40);
            _thReadSetting.State = TabHead.TabHeadState.SELECTED;
            _thReadSetting.TabIndex = 0;
            _thReadSetting.Text = "Settings";
            _thReadSetting.TextAlign = ContentAlignment.MiddleCenter;
            _thReadSetting.Click += TabHead_Click;

            // 
            // _thReadMoreSetting
            // 
            _thReadMoreSetting.BackColor = Color.Transparent;
            _thReadMoreSetting.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _thReadMoreSetting.ImageAlign = ContentAlignment.MiddleRight;
            _thReadMoreSetting.Index = 4;
            _thReadMoreSetting.Location = new Point(155, 1);
            _thReadMoreSetting.Margin = new Padding(0);
            _thReadMoreSetting.MultiTabHead = true;
            _thReadMoreSetting.Name = "_thReadMoreSetting";
            _thReadMoreSetting.Size = new Size(155, 40);
            _thReadMoreSetting.State = TabHead.TabHeadState.FOLDED;
            _thReadMoreSetting.TabIndex = 0;
            _thReadMoreSetting.Text = "More Settings";
            _thReadMoreSetting.TextAlign = ContentAlignment.MiddleCenter;
            _thReadMoreSetting.Click += TabHead_Click;

            // 
            // thLoadImage
            // 
            _thLoadImage.BackColor = Color.Transparent;
            _thLoadImage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _thLoadImage.Image = ((Image)(Resources.ResourceManager.GetObject("tab_file")));
            _thLoadImage.ImageAlign = ContentAlignment.MiddleLeft;
            _thLoadImage.Index = 0;
            _thLoadImage.Location = new Point(1, 1);
            _thLoadImage.Margin = new Padding(0);
            _thLoadImage.Padding = new Padding(25,0,0,0);
            _thLoadImage.MultiTabHead = true;
            _thLoadImage.Name = "_thLoadImage";
            _thLoadImage.Size = new Size(103, 40);
            _thLoadImage.State = TabHead.TabHeadState.SELECTED;
            _thLoadImage.TabIndex = 1;
            _thLoadImage.Text = "Files";
            _thLoadImage.TextAlign = ContentAlignment.MiddleCenter;
            _thLoadImage.Click += TabHead_Click;
            // 
            // thAcquireImage
            // 
            _thAcquireImage.BackColor = Color.Transparent;
            _thAcquireImage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _thAcquireImage.Image = ((Image)(Resources.ResourceManager.GetObject("tab_scanner")));
            _thAcquireImage.ImageAlign = ContentAlignment.MiddleLeft;
            _thAcquireImage.Index = 1;
            _thAcquireImage.Location = new Point(104, 1);
            _thAcquireImage.Margin = new Padding(0);
            _thAcquireImage.Padding = new Padding(10, 0, 0, 0);
            _thAcquireImage.MultiTabHead = true;
            _thAcquireImage.Name = "_thAcquireImage";
            _thAcquireImage.Size = new Size(103, 40);
            _thAcquireImage.State = TabHead.TabHeadState.FOLDED;
            _thAcquireImage.TabIndex = 2;
            _thAcquireImage.Text = "   Scanner";
            _thAcquireImage.TextAlign = ContentAlignment.MiddleCenter;
            _thAcquireImage.Click += TabHead_Click;
            // 
            // thWebCamImage
            // 
            _thWebCamImage.BackColor = Color.Transparent;
            _thWebCamImage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _thWebCamImage.Image = ((Image)(Resources.ResourceManager.GetObject("tab_webcam")));
            _thWebCamImage.ImageAlign = ContentAlignment.MiddleLeft;
            _thWebCamImage.Index = 2;
            _thWebCamImage.Location = new Point(207, 1);
            _thWebCamImage.Margin = new Padding(0);
            _thWebCamImage.Padding = new Padding(8, 0, 0, 0);
            _thWebCamImage.MultiTabHead = true;
            _thWebCamImage.Name = "_thWebCamImage";
            _thWebCamImage.Size = new Size(103, 40);
            _thWebCamImage.State = TabHead.TabHeadState.FOLDED;
            _thWebCamImage.TabIndex = 3;
            _thWebCamImage.Text = "   WebCam";
            _thWebCamImage.TextAlign = ContentAlignment.MiddleCenter;
            _thWebCamImage.Click += TabHead_Click;

            _panelResult.ResumeLayout(false);
            _roundedRectanglePanelAcquireLoad.ResumeLayout(false);
            _roundedRectanglePanelBarcode.ResumeLayout(false);

            flowLayoutPanel2.Controls.Add(_panelResult);
            flowLayoutPanel2.Controls.Add(_roundedRectanglePanelAcquireLoad);
            flowLayoutPanel2.Controls.Add(_roundedRectanglePanelBarcode);
            flowLayoutPanel2.Controls.Add(this.panelReadBarcode);
            
            _panelResult.Visible = false;
            //_roundedRectanglePanelAcquireLoad.Visible = false;
            //_roundedRectanglePanelBarcode.Visible = false;
            //panelReadBarcode.Visible = false;
        }

        protected void Initialization()
        {
            var appPath = Application.StartupPath;
            m_TwainManager = new TwainManager(dntLicenseKeys);
            m_CameraManager = new CameraManager(dntLicenseKeys);
            m_PDFRasterizer = new PDFRasterizer(dntLicenseKeys);
            m_ImageCore = new ImageCore();
            dsViewer.Bind(m_ImageCore);
            dsViewer.OnImageAreaSelected += dsViewer_OnImageAreaSelected;
            m_ImageCore.ImageBuffer.MaxImagesInBuffer = 64;
        }

        void dsViewer_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
            //if (tbxLeft.Visible == true && tbxRight.Visible == true && tbxTop.Visible == true && tbxBottom.Visible == true)
            {
                tbxLeft.Text = left.ToString();
                tbxTop.Text = top.ToString();
                tbxRight.Text = right.ToString();
                tbxBottom.Text = left.ToString();
            }
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
            if (m_CameraManager.GetCameraNames() != null)
            {
                try
                {
                    if (cbxWebCamSrc.SelectedIndex != -1)
                    {
                        Camera tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                        foreach (var resolution in tempCamera.SupportedResolutions)
                        {
                            var strResolution = resolution.Width + " x " + resolution.Height;
                            cbxWebCamRes.Items.Add(strResolution);
                        }
                        cbxWebCamRes.SelectedIndex = 0;
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Webcam error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(m_CameraManager.GetCameraNames()!=null)
            {
                for (short i = 0; i < m_CameraManager.GetCameraNames().Count;i++)
                {
                    var strSourceName = m_CameraManager.SelectCamera(i).GetCameraName();
                    cbxWebCamSrc.Items.Add(strSourceName);
                }
                m_CameraManager.SelectCamera(0);
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
            _thReadSetting.State = TabHead.TabHeadState.SELECTED;

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
            _infoLabel = new Label
            {
                Text = "",
                Visible = false,
                AutoSize = true,
                Name = "Info",
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            _infoLabel.BringToFront();          
            Controls.Add(_infoLabel);

            // For the load image button
            picboxLoadImage.MouseLeave += picbox_MouseLeave;
            picboxLoadImage.Click += picboxLoadImage_Click;
            picboxLoadImage.MouseDown += picbox_MouseDown;
            picboxLoadImage.MouseUp += picbox_MouseUp;
            picboxLoadImage.MouseEnter += picbox_MouseEnter;

            //Tab Heads
            _mTabHeads[0] = _thLoadImage;
            _mTabHeads[1] = _thAcquireImage;
            _mTabHeads[2] = _thWebCamImage;
            _mTabHeads[3] = _thReadSetting;
            _mTabHeads[4] = _thReadMoreSetting;
            _mPanels[0] = panelLoad;
            _mPanels[1] = panelAcquire;
            _mPanels[2] = panelWebCam;
            _mPanels[3] = panelReadSetting;
            _mPanels[4] = panelReadMoreSetting;
            _thLoadImage.State = TabHead.TabHeadState.SELECTED;
            
            //Read Barcode
            cbxBarcodeFormat.Items.Add("All");
            cbxBarcodeFormat.Items.Add("OneD");
            cbxBarcodeFormat.Items.Add("QRCode");
            cbxBarcodeFormat.Items.Add("PDF417");
            cbxBarcodeFormat.Items.Add("Datamatrix");
            cbxBarcodeFormat.Items.Add("Code 39");
            cbxBarcodeFormat.Items.Add("Code 128");
            cbxBarcodeFormat.Items.Add("Code 93");
            cbxBarcodeFormat.Items.Add("Codabar");
            cbxBarcodeFormat.Items.Add("Interleaved 2 of 5");
            cbxBarcodeFormat.Items.Add("Industrial 2 of 5");
            cbxBarcodeFormat.Items.Add("EAN-13");
            cbxBarcodeFormat.Items.Add("EAN-8");
            cbxBarcodeFormat.Items.Add("UPC-A");
            cbxBarcodeFormat.Items.Add("UPC-E");

            cbxBarcodeFormat.SelectedIndex = 0;
            tbxMaxBarcodeReads.Text = "100";
            _strPreMaxBarcodeReads = "100";
            tbxLeft.Text = "0";
            tbxRight.Text = "0";
            tbxTop.Text = "0";
            tbxBottom.Text = "0";

            DisableControls(picboxReadBarcode);

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
                dsViewer.MouseShape = false;
                dsViewer.SetViewMode(-1,-1);
                cbxViewMode.SelectedIndex = 0;

                cbxWebCamSrc.SelectedIndexChanged += cbxWebCamSrc_SelectedIndexChanged;
                cbxWebCamSrc.DropDown += cbxWebCamSrc_DropDown;

                cbxWebCamRes.SelectedIndexChanged += cbxWebCamRes_SelectedIndexChanged;

                cbxSource.DropDown += cbxSource_DropDown;
                cbxSource.SelectedIndexChanged += cbxSource_SelectedIndexChanged;

                 //Init the sources for TWAIN scanning and Webcam grab, show in the cbxSources controls
                //if (m_TwainManager.SourceCount <= 0 && m_CameraManager.GetCameraNames()!=null) return;

                //var hasTwainSource = false;
                ////var hasWebcamSource = false;
                //cbxSource.Items.Clear();
                //for (var i = 0; i < m_TwainManager.SourceCount; i++)
                //{
                //    hasTwainSource = true;
                //    cbxSource.Items.Add(m_TwainManager.SourceNameItems((short)i));
                //}

                //if (m_CameraManager.GetCameraNames() != null)
                //{
                //    hasWebcamSource = true;
                //}

                //if (hasTwainSource)
                //{
                //    SetScannerControlsEnable(true);
                //}

                //if (hasWebcamSource)
                //{
                //    InitWebCamControls();
                //}

                //if(cbxSource.Items.Count > 0)cbxSource.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SetScannerControlsEnable(bool isEnable)
        {
            //cbxSource.Enabled = isEnable;
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
            _lastOpenedDirectory = Application.ExecutablePath;
            _lastOpenedDirectory = _lastOpenedDirectory.Replace("/", "\\");
            var index = _lastOpenedDirectory.LastIndexOf("Samples");
            if (index > 0)
            {
                _lastOpenedDirectory = _lastOpenedDirectory.Substring(0, index);
                _lastOpenedDirectory += "Images\\";
            }

            if (!Directory.Exists(_lastOpenedDirectory))
                _lastOpenedDirectory = string.Empty;
        }

        #endregion

        #region enable/disable function buttons

        /// <summary>
        /// Disable all the function buttons in the left and bottom panel
        /// </summary>
        private void DisableAllFunctionButtons()
        {
            DisableControls(picboxHand);
            DisableControls(picboxPoint);
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
            EnableControls(picboxHand);
            EnableControls(picboxPoint);
            EnableControls(picboxZoomIn);
            EnableControls(picboxZoomOut);

            EnableControls(picboxDelete);
            EnableControls(picboxDeleteAll);

            EnableControls(picboxFit);
            EnableControls(picboxOriginalSize);

            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 1)
            {
                EnableControls(picboxFirst);
                EnableControls(picboxPrevious);
                EnableControls(picboxNext);
                EnableControls(picboxLast);

                if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer == 0)
                {
                    DisableControls(picboxPrevious);
                    DisableControls(picboxFirst);
                }
                if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer + 1 == m_ImageCore.ImageBuffer.HowManyImagesInBuffer)
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
            if (!(sender is PictureBox) || !(sender as PictureBox).Enabled) return;

            (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Leave");
            _infoLabel.Text = "";
            _infoLabel.Visible = false;
        }

        private void picbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!(sender is PictureBox) || !(sender as PictureBox).Enabled) return;
            (sender as PictureBox).Image = (Image)Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Enter");
        }

        private void picbox_MouseHover(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox != null) _infoLabel.Text = pictureBox.Tag.ToString();
            _infoLabel.Location = new Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 20);
            _infoLabel.Visible = true;
            _infoLabel.BringToFront();
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

        private static void DisableControls(object sender)
        {
            DisableControls(sender, string.Empty);
        }

        private static void DisableControls(object sender, string suffix)
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
            m_TwainManager.Dispose();
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
                for (short i = 0; i < m_TwainManager.SourceCount; i++)
                {
                    if (m_TwainManager.SourceNameItems(i) != cbxSource.Text) continue;
                    srcIndex = i;
                    break;
                }

                m_TwainManager.SelectSourceByIndex(srcIndex == -1 ? cbxSource.SelectedIndex : srcIndex);
                m_TwainManager.OpenSource();
                m_TwainManager.IfShowUI = false;
                m_TwainManager.IfDisableSourceAfterAcquire = true;

                if (rdbtnBW.Checked)
                {
                    m_TwainManager.PixelType = TWICapPixelType.TWPT_BW;
                    m_TwainManager.BitDepth = 1;
                }
                else if (rdbtnGray.Checked)
                {
                    m_TwainManager.PixelType = TWICapPixelType.TWPT_GRAY;
                    m_TwainManager.BitDepth = 8;
                }
                else
                {
                    m_TwainManager.PixelType = TWICapPixelType.TWPT_RGB;
                    m_TwainManager.BitDepth = 24;
                }


                m_TwainManager.Resolution = int.Parse(cbxResolution.Text);

                
                
                bRet = m_TwainManager.AcquireImage(this as Dynamsoft.TWAIN.Interface.IAcquireCallback);
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
            CheckZoom();
        }

        private void CropPicture(int imageIndex, Rectangle rc)
        {
            m_ImageCore.ImageProcesser.Crop((short)imageIndex,rc.X,rc.Y,rc.X + rc.Width,rc.Y + rc.Height);
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
            if (cbxViewMode.SelectedIndex != 0 || m_ImageCore.ImageBuffer.HowManyImagesInBuffer == 0 )
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
            m_ImageCore.ImageBuffer.RemoveImage(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            CheckImageCount();
        }

        private void picboxDeleteAll_Click(object sender, EventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
            CheckImageCount();
        }

        private void cbxSource_DropDown(object sender, EventArgs e)
        {
            //var orgSrcName = cbxSource.Text;
            //List<string> curSrcNames;
            //if (IsNeedRebindCbxSrc(out curSrcNames))
            //{
            //    cbxSource.Items.Clear();
            //    for (short i = 0; i < m_TwainManager.SourceCount; i++)
            //    {
            //        var strSourceName = m_TwainManager.SourceNameItems(i);
            //        if (strSourceName != null)
            //            cbxSource.Items.Add(strSourceName);
            //    }
            //}

            //if (curSrcNames.Contains(orgSrcName)) cbxSource.Text = orgSrcName;

            //SetScannerControlsEnable(cbxSource.Items.Count > 0);

            //cbxSource.DroppedDown = false;
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetScannerControlsEnable(true);
            //m_TwainManager.SelectSourceByIndex(cbxSource.SelectedIndex);
        }

        /// <summary>
        /// If the image count changed, some features should changed.
        /// </summary>
        private void CheckImageCount()
        {
            _currentImageIndex = m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            var currentIndex = _currentImageIndex + 1;
            int imageCount = m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            if (imageCount == 0)
                currentIndex = 0;

            tbxCurrentImageIndex.Text = currentIndex.ToString();
            tbxTotalImageNum.Text = imageCount.ToString();

            if (imageCount > 0)
            {
                EnableAllFunctionButtons();
                EnableControls(picboxReadBarcode); 
            }
            else
            {
                DisableAllFunctionButtons();
                dsViewer.Visible = false;
                DisableControls(picboxReadBarcode);
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
            if(m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = 0;
            CheckImageCount();
        }

        private void picboxLast_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = (short)(m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1);
            CheckImageCount();
        }

        private void picboxPrevious_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 && m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer > 0)
                --m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            CheckImageCount();
        }

        private void picboxNext_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 &&
                m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1)
                ++m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            CheckImageCount();
        }

        private void picboxLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*GIF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF|PDF|*.PDF";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = _lastOpenedDirectory;

            m_ImageCore.ImageBuffer.IfAppendImage = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _lastOpenedDirectory = System.IO.Directory.GetParent(openFileDialog.FileName).FullName;

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
                                m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                                m_PDFRasterizer.ConvertToImage(strFileName, "", 200, this as IConvertCallback);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message, "Loading image error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                            m_ImageCore.IO.LoadImage(strFileName);
                    }
                    else
                        m_ImageCore.IO.LoadImage(strFileName);
                }
                dsViewer.Visible = true;
            }
            CheckImageCount();
        }

        #endregion

        #region dynamicDotNetTwain event

        private void dynamicDotNetTwain_OnMouseClick(short sImageIndex)
        {
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer != _currentImageIndex)
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

                if (_isToCrop && !rc.IsEmpty)
                {
                    CropPicture(sImageIndex, rc);
                }
                _isToCrop = false;
            }
            catch
            {
            }
            EnableAllFunctionButtons();
        }

        private void dynamicDotNetTwain_OnMouseRightClick(short sImageIndex)
        {
            if (_isToCrop) _isToCrop = false;
            dsViewer.ClearSelectionRect(sImageIndex);
            EnableAllFunctionButtons();
        }

        private void dynamicDotNetTwain_OnImageAreaDeselected(short sImageIndex)
        {
            if (_isToCrop) _isToCrop = false;
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

        //private TabHead m_CurrentTabHead = new TabHead();
        private void TabHead_Click(object sender, EventArgs e)
        {
            var thHead = sender as TabHead;
            if(thHead == null) return;

            //m_CurrentTabHead = thHead;
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
                    IsVisiable(true);
                    tbxTimeout.Enabled = true;
                    if(m_CameraManager.GetCameraNames()!=null)
                    {
                        m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName).Close();
                    }
                    _webCamMode = false;
                   
                    CheckImageCount();
                    cbxImageCaptureDevice.SelectedIndex = thHead.Name == "_thLoadImage" ? 0  : 1;
                    _bTurnOnReading = false;
                    picBoxWebCam.Visible = false;
                    this.SwitchButtonState(false);
                    break;
                case "_thAcquireImage":
                    var hasTwainSource = false;
                    cbxSource.Focus();
                    tbxTimeout.Enabled = true;
                    if(cbxSource.Items.Count>0)
                    {
                        cbxSource.Items.Clear();
                    }

                    for (var i = 0; i < m_TwainManager.SourceCount; i++)
                    {
                        hasTwainSource = true;
                        cbxSource.Items.Add(m_TwainManager.SourceNameItems((short)i));
                    }
                    if (cbxSource.Items.Count > 0)
                    {
                        cbxSource.SelectedIndex = 0;
                    }
                    if (hasTwainSource)
                    {
                        SetScannerControlsEnable(true);
                    }
                    

                    IsVisiable(true);
                    if(m_CameraManager.GetCameraNames()!=null)
                    {
                        m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName).Close();
                    }
                    _webCamMode = false;
                   
                    CheckImageCount();
                    m_TwainManager.CloseSource();
                    cbxImageCaptureDevice.SelectedIndex = thHead.Name == "_thLoadImage" ? 0  : 1;
                    
                    _bTurnOnReading = false;
                    picBoxWebCam.Visible = false;
                    this.SwitchButtonState(false);

                    break;

                case "_thWebCamImage":
                    IsVisiable(false);
                    _webCamMode = true;
                    cbxWebCamSrc.Focus();
                    tbxTimeout.Enabled = false;
                    if (_webCamErrorOccur)
                    {
                        DisableControls(picboxReadBarcode);
                        break;
                    }


                    cbxImageCaptureDevice.SelectedIndex = 2;
                    InitWebCamControls();

                    Camera tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                    if(tempCamera == null)
                    {
                        return;
                    }
                    tempCamera.SetVideoContainer(picBoxWebCam.Handle);
                    tempCamera.Open();
                    tempCamera.CurrentResolution = GetCamResolution();
                    ResizeVideoWindow(0);
                    picBoxWebCam.Visible = true;
                    picBoxWebCam.BringToFront();

                    if (ExistWebCam && !string.IsNullOrEmpty(cbxWebCamSrc.Text) && !string.IsNullOrEmpty(cbxWebCamRes.Text)) EnableControls(picboxReadBarcode);
                    else DisableControls(picboxReadBarcode);
                    break;
                    default:
                    break;
            }

            RestorePreMaxBarcodeReads(!picBoxWebCam.Visible);
        }


        private void IsVisiable(bool bResult)
        {
            label8.Visible = bResult;
            label9.Visible = bResult;
            label10.Visible = bResult;
            label11.Visible = bResult;
            label12.Visible = bResult;

            tbxLeft.Visible = bResult;
            tbxRight.Visible = bResult;
            tbxTop.Visible = bResult;
            tbxBottom.Visible = bResult;
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

                if (!CheckAndSetReaderOptions())
                    return;

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
		
        private void postShowFrameResults(Bitmap _bitmap, BarcodeResult[] _bars, int timeElapsed,Exception ex)
        {
            this.TurnOnReading(false);

            if (_bars != null)
            {
                picBoxWebCam.Image = null;

                var tempBitmap = new Bitmap(_bitmap.Width, _bitmap.Height);
                using (var g = Graphics.FromImage(tempBitmap))
                {
                    g.DrawImage(_bitmap, 0, 0);
                    g.DrawRectangle(new Pen(Color.FromArgb(255, 0, 0), 2), _bars[0].BoundingRect);
                }

                Camera tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                tempCamera.Close();
                tempCamera.Dispose();
                picBoxWebCam.Image = tempBitmap;
                this.ShowResult(_bars, timeElapsed);
            }
            if(ex !=null)
            {
                MessageBox.Show(ex.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadFromFrame(Bitmap bitmap)
        {
            BarcodeResult[] bars = null;
            Bitmap tempBitmap = ((Bitmap)(bitmap)).Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
            int timeElapsed = 0;
            
            try
            {
                DateTime beforeRead = DateTime.Now;

                bars = _br.DecodeBitmap(bitmap);

                DateTime afterRead = DateTime.Now;
                timeElapsed = (int)(afterRead - beforeRead).TotalMilliseconds;

                if (bars == null || bars.Length <= 0)
                {
                    return;
                }

                this.BeginInvoke(_postShowFrameResults, tempBitmap,bars, timeElapsed,null);
            }
            catch (Exception ex)
            {
                this.Invoke(_postShowFrameResults, new object[] { bitmap, bars, timeElapsed,ex});
                //MessageBox.Show(ex.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool CheckAndSetReaderOptions()
        {
            //Max barcodes to read.
            var iMaxBarcodesToRead = 0;
            try
            {
                iMaxBarcodesToRead = int.Parse(tbxMaxBarcodeReads.Text);
                _br.ReaderOptions.MaxBarcodesToReadPerPage = iMaxBarcodesToRead;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Invalid input of MaxBarcodeReads", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxMaxBarcodeReads.Focus();
                return false;
            }

            //Image capture device
            if (this.cbxImageCaptureDevice.Text == "Unknown")
            {
                _br.ReaderOptions.ImageCaptureDevice = ImageCaptureDevice.ICD_Unknown;
            }
            else if (this.cbxImageCaptureDevice.Text == "Scanner")
            {
                _br.ReaderOptions.ImageCaptureDevice = ImageCaptureDevice.ICD_Scanner;
            }
            else if (this.cbxImageCaptureDevice.Text == "Camera")
            {
                _br.ReaderOptions.ImageCaptureDevice = ImageCaptureDevice.ICD_Camera;
            }
            else if (this.cbxImageCaptureDevice.Text == "Fax")
            {
                _br.ReaderOptions.ImageCaptureDevice = ImageCaptureDevice.ICD_Fax;
            }

            //BarcodeOrientation
            _br.ClearAllAngleRanges();
            if (this.cbxBarcodeOrientation.Text == "All")
            {
                _br.AddAngle(BarcodeOrientationType.BOT_Horizontal);
                _br.AddAngle(BarcodeOrientationType.BOT_Vertical);
            }
            else if (this.cbxBarcodeOrientation.Text == "Horizontal")
            {
                _br.AddAngle(BarcodeOrientationType.BOT_Horizontal);
            }
            else if (this.cbxBarcodeOrientation.Text == "Vertical")
            {
                _br.AddAngle(BarcodeOrientationType.BOT_Vertical);
            }

            //Region
            _br.ClearAllRegions();

            if (!_webCamMode)
            {
                var rect = dsViewer.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                if (rect != Rectangle.Empty)
                {
                    _br.AddRegion(rect.Left, rect.Top, rect.Right, rect.Bottom, false);
                }
            }

            //timeout
            var iTimeout = 0;
            try
            {
                iTimeout = int.Parse(tbxTimeout.Text);
                if (_mPanels[0].Visible == true || _mPanels[1].Visible == true)
                {
                    _br.ReaderOptions.TimeoutPerPage = iTimeout;
                }
                else if(_mPanels[2].Visible == true)
                {
                    _br.ReaderOptions.TimeoutPerPage = 0x7fffffff;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Timeout per page value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxTimeout.Focus();
                return false;
            }

            //barcode width
            _br.ClearAllWidthRanges();

            var iMin = 0;
            var iMax = 0;
            try
            {
                iMin = int.Parse(tbxMinWidth.Text);
                iMax = int.Parse(tbxMaxWidth.Text);
                _br.AddWidthRange(iMin, iMax);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Barcode Width Range Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //barcode height
            _br.ClearAllHeightRanges();

            try
            {
                iMin = int.Parse(tbxMinHeight.Text);
                iMax = int.Parse(tbxMaxHeight.Text);
                _br.AddHeightRange(iMin, iMax);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Barcode Height Range Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //barcode modulesize
            _br.ClearAllModuleSizeRanges();

            try
            {
                iMin = int.Parse(tbxMinModuleSize.Text);
                iMax = int.Parse(tbxMaxModuleSize.Text);
                _br.AddModuleSizeRange(iMin, iMax);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Barcode Module Size Range Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Barcode text encoding
            if (this.cbxBarcodeTextEncoding.Text == "Default")
            {
                _br.ReaderOptions.BarcodeTextEncoding = BarcodeTextEncoding.BTE_Default;
            }
            else if (this.cbxBarcodeTextEncoding.Text == "UTF8")
            {
                _br.ReaderOptions.BarcodeTextEncoding = BarcodeTextEncoding.BTE_UTF8;
            }
            else if (this.cbxBarcodeTextEncoding.Text == "UTF16")
            {
                _br.ReaderOptions.BarcodeTextEncoding = BarcodeTextEncoding.BTE_UTF16;
            }
            else if (this.cbxBarcodeTextEncoding.Text == "GB2312_936")
            {
                _br.ReaderOptions.BarcodeTextEncoding = BarcodeTextEncoding.BTE_GB2312_936;
            }
            else if (this.cbxBarcodeTextEncoding.Text == "SHIFT_JIS_932")
            {
                _br.ReaderOptions.BarcodeTextEncoding = BarcodeTextEncoding.BTE_SHIFT_JIS_932;
            }
            else if (this.cbxBarcodeTextEncoding.Text == "KOREAN_949")
            {
                _br.ReaderOptions.BarcodeTextEncoding = BarcodeTextEncoding.BTE_KOREAN_949;
            }
            else if (this.cbxBarcodeTextEncoding.Text == "BIG5_950")
            {
                _br.ReaderOptions.BarcodeTextEncoding = BarcodeTextEncoding.BTE_BIG5_950;
            }

            //barcode color mode
            if (cbxBarcodeDark.Checked && cbxBarcodeLight.Checked)
            {
                _br.ReaderOptions.BarcodeColorMode = BarcodeColorMode.BCM_DarkAndLight;
            }
            else if (cbxBarcodeDark.Checked && !cbxBarcodeLight.Checked)
            {
                _br.ReaderOptions.BarcodeColorMode = BarcodeColorMode.BCM_DarkOnLight;
            }
            else if (!cbxBarcodeDark.Checked && cbxBarcodeLight.Checked)
            {
                _br.ReaderOptions.BarcodeColorMode = BarcodeColorMode.BCM_LightOnDark;
            }
            else
            {
                _br.ReaderOptions.BarcodeColorMode = BarcodeColorMode.BCM_DarkOnLight;
            }

            //deblur oned
            _br.ReaderOptions.UseOneDDeblur = cbxDeblurOneD.Checked;

            //find unrecognized
            _br.ReaderOptions.ReturnUnrecognizedBarcode = cbxReturnUnrecognized.Checked;

            return true;
        }

        private void ReadFromImage()
        {
            ShowSelectedImageArea();

            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if(!CheckAndSetReaderOptions())
                    return;

                Bitmap bmp = (Bitmap)(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer));
                
                DateTime beforeRead = DateTime.Now;
                
                BarcodeResult[] aryResult=_br.DecodeBitmap(bmp);
                
                DateTime afterRead = DateTime.Now;
                int timeElapsed = (int)(afterRead - beforeRead).TotalMilliseconds;
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, null, true);
                if(aryResult != null)
                {
                    List<AnnotationData> tempListAnnotation = new List<AnnotationData>();
                    for (var i = 0; i < aryResult.Length; i++)
                    {
                        //add rect annotation
                        var penColor = Color.Red;
                        if (aryResult[i].IsUnrecognized)
                            penColor = Color.Blue;

                        var rectAnnotation = new AnnotationData();
                        rectAnnotation.AnnotationType = AnnotationType.enumRectangle;
                        rectAnnotation.StartPoint = aryResult[i].BoundingRect.Location;
                        rectAnnotation.EndPoint = new Point((aryResult[i].BoundingRect.Location.X + aryResult[i].BoundingRect.Size.Width),(aryResult[i].BoundingRect.Location.Y + aryResult[i].BoundingRect.Size.Height));
                        rectAnnotation.FillColor = Color.Transparent.ToArgb();
                        rectAnnotation.PenColor = penColor.ToArgb();
                        rectAnnotation.PenWidth = 3;
                        rectAnnotation.GUID = Guid.NewGuid();

                        float fsize = bmp.Width / 48.0f;
                        if (fsize < 25)
                            fsize = 25;

                        Font textFont = new Font("Times New Roman", fsize, FontStyle.Bold);

                        string strNo = "[" + (i + 1) + "]";
                        SizeF textSize = Graphics.FromHwnd(IntPtr.Zero).MeasureString(strNo, textFont);

                        var textAnnotation = new AnnotationData();
                        textAnnotation.AnnotationType = AnnotationType.enumText;
                        textAnnotation.StartPoint = new Point(aryResult[i].BoundingRect.Location.X, (int)(aryResult[i].BoundingRect.Location.Y - textSize.Height * 1.25f));
                        textAnnotation.EndPoint = new Point((textAnnotation.StartPoint.X + (int)textSize.Width * 2), (int)(textAnnotation.StartPoint.Y + textSize.Height * 1.25f));
                        if(textAnnotation.StartPoint.X<0)
                        {
                            textAnnotation.EndPoint = new Point((textAnnotation.EndPoint.X + textAnnotation.StartPoint.X),textAnnotation.EndPoint.Y);
                            textAnnotation.StartPoint = new Point(0,textAnnotation.StartPoint.Y);
                        }
                        if(textAnnotation.StartPoint.Y<0)
                        {
                            textAnnotation.EndPoint = new Point(textAnnotation.EndPoint.X,(textAnnotation.EndPoint.Y - textAnnotation.StartPoint.Y));
                            textAnnotation.StartPoint = new Point(textAnnotation.StartPoint.X,0);
                        }

                        textAnnotation.TextContent = strNo;
                        AnnoTextFont tempFont = new AnnoTextFont();
                        tempFont.TextColor = Color.Blue.ToArgb();
                        tempFont.Size = (int)fsize;
                        tempFont.Name = "Times New Roman";
                        textAnnotation.FontType = tempFont;
                        textAnnotation.GUID = Guid.NewGuid();
                        
                        tempListAnnotation.Add(rectAnnotation);
                        tempListAnnotation.Add(textAnnotation);
                    }
                    m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempListAnnotation, true);
                }

                this.ShowResult(aryResult, timeElapsed);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowResult(BarcodeResult[] aryResult, int timeElapsed)
        {
            string strResult;

            if (aryResult == null)
            {
                strResult = "No barcode found. Total time spent: " + timeElapsed + " ms\r\n";
            }
            else
            {
                strResult = "Total barcode(s) found: " + aryResult.Length + ". Total time spent: " + timeElapsed + " ms\r\n";

                for (var i = 0; i < aryResult.Length; i++)
                {
                    strResult += string.Format("  Barcode: {0}\r\n", (i + 1));
                    strResult += string.Format("    Type: {0}\r\n", aryResult[i].BarcodeFormat.ToString());
                    strResult += string.Format("    Value: {0}\r\n", aryResult[i].BarcodeText);
                    string[] res = aryResult[i].BarcodeText.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    strResult += string.Format("    Hex Data: {0}\r\n", ToHexString(aryResult[i].BarcodeData));
                    strResult += string.Format("    Region: {{Left: {0}, Top: {1}, Width: {2}, Height: {3}}}\r\n", aryResult[i].BoundingRect.Left.ToString(),
                                                   aryResult[i].BoundingRect.Top.ToString(), aryResult[i].BoundingRect.Width.ToString(), aryResult[i].BoundingRect.Height.ToString());
                    strResult += string.Format("    Module Size: {0}\r\n", aryResult[i].ModuleSize);
                    strResult += string.Format("    Angle: {0}\r\n", aryResult[i].Angle);
                    strResult += string.Format("    Is Recognized: {0}\r\n", !aryResult[i].IsUnrecognized);
                    strResult += "\r\n";

                }
            }

            this.ShowBarcodeResultPanel(true);
            this.tbxResult.Text = strResult;
        }

        private void ShowSelectedImageArea()
        {
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                var recSelArea = dsViewer.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                var imgCurrent =  m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                if (recSelArea.IsEmpty)
                {
                    tbxLeft.Text = "0";
                    tbxRight.Text = imgCurrent.Width.ToString();
                    tbxTop.Text = "0";
                    tbxBottom.Text = imgCurrent.Height.ToString();
                }
                else
                {
                    tbxLeft.Text = recSelArea.Left < 0 ? "0" : (recSelArea.Left > imgCurrent.Width ? imgCurrent.Width.ToString() : recSelArea.Left.ToString());
                    tbxRight.Text = recSelArea.Right < 0 ? "0" : (recSelArea.Right > imgCurrent.Width ? imgCurrent.Width.ToString() : recSelArea.Right.ToString());
                    tbxTop.Text = recSelArea.Top < 0 ? "0" : (recSelArea.Top > imgCurrent.Height ? imgCurrent.Height.ToString() : recSelArea.Top.ToString());
                    tbxBottom.Text = recSelArea.Bottom < 0 ? "0" : (recSelArea.Bottom > imgCurrent.Height ? imgCurrent.Height.ToString() : recSelArea.Bottom.ToString());
                }
            }
            else
            {
                tbxLeft.Text = "0";
                tbxRight.Text = "0";
                tbxTop.Text = "0";
                tbxBottom.Text = "0";
            }
        }

        private void cbxBarcodeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox) == null) return;


            switch (cbxBarcodeFormat.SelectedIndex)
            {
                case 0:
                    Int64 format = 0;
                    foreach (var value in Enum.GetValues(typeof(BarcodeFormat)))
                    {
                        format = format | (Int64)value;
                    }
                    _br.ReaderOptions.BarcodeFormats = (BarcodeFormat) format;
                    break;
                case 1:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.OneD;
                    break;
                case 2:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.QR_CODE;
                    break;
                case 3:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.PDF417;
                    break;
                case 4:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.DATAMATRIX;
                    break;
                case 5:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.CODE_39;
                    break;
                case 6:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.CODE_128;
                    break;
                case 7:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.CODE_93;
                    break;
                case 8:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.CODABAR;
                    break;
                case 9:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.ITF;
                    break;
                case 10:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.INDUSTRIAL_25;
                    break;
                case 11:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.EAN_13;
                    break;
                case 12:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.EAN_8;
                    break;
                case 13:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.UPC_A;
                    break;
                case 14:
                    _br.ReaderOptions.BarcodeFormats = BarcodeFormat.UPC_E;
                    break;
            }
        }

        private void tbxBarcodeLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            var array = Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b') e.Handled = false;
        }

        private void TbxMaxBarcodeReadsOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (!tbxMaxBarcodeReads.ReadOnly) _strPreMaxBarcodeReads = tbxMaxBarcodeReads.Text;
        }

        #endregion Read Barcode
        
        #region webCam relevant

        private void TurnOnReading(bool isOn)
        {
           _bTurnOnReading = isOn;

            if (_bTurnOnReading)
            {
                Camera tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                if (!m_IfHasAddedOnFrameCaptureEvent)
                {
                    tempCamera.Open();
                    tempCamera.SetVideoContainer(picBoxWebCam.Handle);
                    tempCamera.CurrentResolution = GetCamResolution();
                    ResizeVideoWindow(0);
                    tempCamera.OnFrameCaptrue +=tempCamera_OnFrameCaptrue;
                    m_IfHasAddedOnFrameCaptureEvent = true;
                }
                _br.ReaderOptions.MaxBarcodesToReadPerPage = 1;
                this.SwitchButtonState(true);
            }
            else
            {
                if (m_IfHasAddedOnFrameCaptureEvent)
                {
                    Camera tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
                    tempCamera.OnFrameCaptrue -= tempCamera_OnFrameCaptrue;
                }
                m_IfHasAddedOnFrameCaptureEvent = false;
                this.SwitchButtonState(false);
            }
        }

        void tempCamera_OnFrameCaptrue(Bitmap bitmap)
        {
            if (_bTurnOnReading)
            {
                ReadFromFrame(bitmap);
            }
        }

        private CamResolution GetCamResolution()
        {
            var resAry = cbxWebCamRes.Text.Split('x');
            int width, height;
            return resAry.Length > 1 && int.TryParse(resAry[0],out width) && int.TryParse(resAry[1],out 
                height)?new CamResolution(width,height):m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex).CurrentResolution; 
        }

        private void InitWebCamControls()
        {
            try
            {
                InitCbxWebCamSrc();
                InitCbxWebCamRes();
                picBoxWebCam.Image = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResizeVideoWindow(int iRotate)
        {
            Camera tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
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
                if(m_CameraManager.GetCameraNames()!=null)
                {
                    foreach (string temp in m_CameraManager.GetCameraNames())
                    {
                        m_CameraManager.SelectCamera(temp).Dispose();
                    }
                }

                m_CameraManager = null;
                m_CameraManager = tempCameraManager;
                //this.SwitchButtonState(true);
            }
            else
            {
                TurnOnReading(false);
            }

            Camera tempCamera = m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName);
            tempCamera.Close();
            tempCamera.Dispose();
            tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
            picBoxWebCam.Image = null;
            InitCbxWebCamRes();
            if (_webCamErrorOccur) return;

            tempCamera.SetVideoContainer(picBoxWebCam.Handle);
            tempCamera.Open();
            tempCamera.CurrentResolution = GetCamResolution();
            ResizeVideoWindow(0);
        }

        private bool IsNeedRebindCbxSrc(out List<string> curSrcNames)
        {
            var orgSrcNames = new List<string>();
            for (short i = 0; i < m_TwainManager.SourceCount; i++)
            {
                orgSrcNames.Add(m_TwainManager.SourceNameItems(i));
            }

            m_TwainManager.CloseSourceManager();
            m_TwainManager.OpenSourceManager();

            curSrcNames = new List<string>();
            for (short i = 0; i < m_TwainManager.SourceCount; i++)
            {
                curSrcNames.Add(m_TwainManager.SourceNameItems(i));
            }

            //1. check count
            var isNeedRebind = orgSrcNames.Count != curSrcNames.Count;

            //2. check names
            if (isNeedRebind) return isNeedRebind;

            foreach (var orgName in orgSrcNames)
            {
                if (curSrcNames.Contains(orgName)) continue;

                isNeedRebind = true;
                break;
            }

            return isNeedRebind;
        }

        private string m_CurrentCameraName = null;
        private bool m_bIfCameraSourceUpdated = false;
        private void cbxWebCamSrc_DropDown(object sender, EventArgs e)
        {
            //if (_webCamErrorOccur) return;
            TurnOnReading(false);
            m_bIfCameraSourceUpdated = false;
            m_CurrentCameraName = m_CameraManager.CurrentSourceName;

            CameraManager tempCameraManager = new CameraManager(dntLicenseKeys);

            if (m_CameraManager.GetCameraNames() == null && tempCameraManager.GetCameraNames()!=null)
            {
                m_bIfCameraSourceUpdated = true;
                picBoxWebCam.Visible = true;
                picBoxWebCam.BringToFront();
            }

            if (m_CameraManager.GetCameraNames() != null && tempCameraManager.GetCameraNames() == null)
            {
                m_bIfCameraSourceUpdated = true;
            }


            if(tempCameraManager.GetCameraNames()!=null && m_CameraManager.GetCameraNames()!=null)
            {
                if (tempCameraManager.GetCameraNames().Count != m_CameraManager.GetCameraNames().Count)
                {
                    m_bIfCameraSourceUpdated = true;
                }
                else
                {
                    List<string> temp1 = tempCameraManager.GetCameraNames();
                    List<string> temp2 = m_CameraManager.GetCameraNames();
                    for (short i = 0; i < m_CameraManager.GetCameraNames().Count; i++)
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

                    //}
                    //if (_webCamErrorOccur) return;

                    //TurnOnReading(false);

                    //var orgSrcName = cbxWebCamSrc.Text;
                    //List<string> curSrcNames;
                    //if (IsNeedRebindCbxSrc(out curSrcNames)) BindCbxWebCamSrc();

                    //if (cbxWebCamSrc.Items.Count == 0) cbxWebCamRes.Items.Clear();

                    //if (curSrcNames.Contains(orgSrcName))
                    //{
                    //    cbxWebCamSrc.Text = orgSrcName;
                    //    picBoxWebCam.Image = null;
                    //    SetWebCamAsDntSrc(orgSrcName);
                    //    InitCbxWebCamRes();
                    //    Camera tempCamera = m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName);
                    //    tempCamera.SetVideoContainer(picBoxWebCam.Handle);
                    //    tempCamera.Open();
                    //    tempCamera.CurrentResolution = GetCamResolution();
                    //    ResizeVideoWindow(0);
                }
            }
            if (tempCameraManager.GetCameraNames() != null)
            {
                tempCameraManager.Dispose();
            }

        }

        //    cbxWebCamSrc.DroppedDown = false;
        //    if (string.IsNullOrEmpty(cbxWebCamSrc.Text))
        //        DisableControls(picboxReadBarcode);
        //}

        private void cbxWebCamRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnOnReading(false);

            picBoxWebCam.Image = null;
            Camera tempCamera = m_CameraManager.SelectCamera((short)cbxWebCamSrc.SelectedIndex);
            tempCamera.CurrentResolution = GetCamResolution();
            ResizeVideoWindow(0);
        }

        //private void SetWebCamAsDntSrc(string srcName)
        //{
        //    var srcIndex = -1;
        //    if(m_CameraManager.GetCameraNames()!=null)
        //    {
        //        for (short i = 0; i < m_CameraManager.GetCameraNames().Count;i++)
        //        {
        //            if (m_CameraManager.SelectCamera(i).GetCameraName() != srcName) continue;
        //            srcIndex = i;
        //            break;
        //        }
        //        m_CameraManager.SelectCamera((short)srcIndex);
        //    }
        //}

        private void RestorePreMaxBarcodeReads(bool isRestore)
        {
            tbxMaxBarcodeReads.ReadOnly = !isRestore;
            tbxMaxBarcodeReads.Text = isRestore ? _strPreMaxBarcodeReads : "1";
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
                _panelResult.Visible = true;
                _panelResult.Focus();
                this._roundedRectanglePanelAcquireLoad.Visible = false;
                this._roundedRectanglePanelBarcode.Visible = false;
                this.panelReadBarcode.Visible = false;
            }
            else
            {
                _panelResult.Visible = false;
                this._roundedRectanglePanelAcquireLoad.Visible = true;
                this._roundedRectanglePanelBarcode.Visible = true;
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
            m_ImageCore.IO.LoadImage(bit);
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
            m_ImageCore.IO.LoadImage(result.Image);
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, true);

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
            if(m_TwainManager!=null)
            {
                m_TwainManager.Dispose();
            }
        }

        private void BarcodeReaderDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
        }

    }
}
