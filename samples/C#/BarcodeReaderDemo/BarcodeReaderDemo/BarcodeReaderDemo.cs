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
using Dynamsoft.DotNet.TWAIN.Annotation;
using Dynamsoft.DotNet.TWAIN.Enums;
using Dynamsoft.DotNet.TWAIN.WebCamera;
using ContentAlignment = System.Drawing.ContentAlignment;
using ErrorCode = Dynamsoft.DotNet.TWAIN.Enums.ErrorCode;

namespace Barcode_Reader_Demo
{
    public partial class BarcodeReaderDemo : Form
    {
        #region field

        // For move the window
        private Point _mouseOffset;
        // For move the result panel/
        private Point _mouseOffset2;
        private int _currentImageIndex = -1;
        private delegate void CrossThreadOperationControl();
        private delegate void PostShowFrameResultsHandler(Bitmap _bitmap, BarcodeResult[] _bars, int timeElapsed);

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

        #endregion

        #region property

        public bool ExistWebCam
        {
            get
            {
                var exist = false;
                for (var i = 0; i < dynamicDotNetTwain.SourceCount; ++i)
                {
                    if (dynamicDotNetTwain.GetSourceType((short) i) != EnumDeviceType.SDT_WEBCAM) continue;
                    exist = true;
                    break;
                }

                return exist;
            }
        }

        public bool ExistScanner
        {
            get
            {
                var exist = false;
                for (var i = 0; i < dynamicDotNetTwain.SourceCount; ++i)
                {
                    if (dynamicDotNetTwain.GetSourceType((short)i) != EnumDeviceType.SDT_TWAIN) continue;
                    exist = true;
                    break;
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

            _br = new BarcodeReader { LicenseKeys = "t0068MgAAABs0soPfOcktn1WIaQwU5tPkLklx8PbtKusKGedkkCTDIQldAxDlOkitjsoOoUHYq9Zxro5YEVTQ7/oqoIcoGzQ=" };
            dynamicDotNetTwain.LicenseKeys = "ECD6D80BF542A2B0E24DA26383DF85D9;ECD6D80BF542A2B06F09F8514EFDB3FD;ECD6D80BF542A2B0EE8ED6DF3885C436;ECD6D80BF542A2B07C2CCE813856BCB5;ECD6D80BF542A2B0AD4D85B1DD690D94";

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

            dynamicDotNetTwain.PDFRasterizerDllPath = appPath + "\\PDFResources\\";
            dynamicDotNetTwain.IfShowCancelDialogWhenBarcodeOrOCR = true;
            dynamicDotNetTwain.MaxImagesInBuffer = 64;
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
            foreach (var resolution in dynamicDotNetTwain.ResolutionForCamList)
            {
                var strResolution = resolution.Width + " x " + resolution.Height;
                cbxWebCamRes.Items.Add(strResolution);
            }
            if (dynamicDotNetTwain.ResolutionForCamList.Count > 0)
            {
                cbxWebCamRes.SelectedIndex = 0;
            }

            if (dynamicDotNetTwain.ErrorCode != Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed && !_webCamErrorOccur)
            {
                _webCamErrorOccur = true;
                MessageBox.Show(dynamicDotNetTwain.ErrorString, "Webcam error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitCbxWebCamSrc()
        {
            BindCbxWebCamSrc();
            if (cbxWebCamSrc.Items.Count > 0) cbxWebCamSrc.SelectedIndex = 0;
        }

        private void BindCbxWebCamSrc()
        {
            cbxWebCamSrc.Items.Clear();
            for (short i = 0; i < dynamicDotNetTwain.SourceCount; i++)
            {
                var strSourceName = dynamicDotNetTwain.SourceNameItems(i);
                if (strSourceName != null && dynamicDotNetTwain.GetSourceType(i) == EnumDeviceType.SDT_WEBCAM)
                    cbxWebCamSrc.Items.Add(strSourceName);
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

            dynamicDotNetTwain.Visible = false;

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
                dynamicDotNetTwain.SupportedDeviceType = EnumSupportedDeviceType.SDT_ALL;
                dynamicDotNetTwain.ScanInNewProcess = true;
                dynamicDotNetTwain.IfFitWindow = true;
                dynamicDotNetTwain.MouseShape = false;
                dynamicDotNetTwain.SetViewMode(-1, -1);
                cbxViewMode.SelectedIndex = 0;

                cbxWebCamSrc.SelectedIndexChanged += cbxWebCamSrc_SelectedIndexChanged;
                cbxWebCamSrc.DropDown += cbxWebCamSrc_DropDown;

                cbxWebCamRes.SelectedIndexChanged += cbxWebCamRes_SelectedIndexChanged;

                cbxSource.DropDown += cbxSource_DropDown;
                cbxSource.SelectedIndexChanged += cbxSource_SelectedIndexChanged;

                // Init the sources for TWAIN scanning and Webcam grab, show in the cbxSources controls
                if (dynamicDotNetTwain.SourceCount <= 0) return;

                var hasTwainSource = false;
                var hasWebcamSource = false;
                cbxSource.Items.Clear();
                for (var i = 0; i < dynamicDotNetTwain.SourceCount; ++i)
                {
                    var enumDeviceType = dynamicDotNetTwain.GetSourceType((short)i);
                    switch (enumDeviceType)
                    {
                        case EnumDeviceType.SDT_TWAIN:
                            hasTwainSource = true;
                            cbxSource.Items.Add(dynamicDotNetTwain.SourceNameItems((short)i));
                            break;
                        case EnumDeviceType.SDT_WEBCAM:
                            hasWebcamSource = true;
                            break;
                    }
                }

                if (hasTwainSource)
                {
                    SetScannerControlsEnable(true);
                }

                if (hasWebcamSource)
                {
                    InitWebCamControls();
                }

                if(cbxSource.Items.Count > 0)cbxSource.SelectedIndex = 0;
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

            if (dynamicDotNetTwain.HowManyImagesInBuffer > 1)
            {
                EnableControls(picboxFirst);
                EnableControls(picboxPrevious);
                EnableControls(picboxNext);
                EnableControls(picboxLast);

                if (dynamicDotNetTwain.CurrentImageIndexInBuffer == 0)
                {
                    DisableControls(picboxPrevious);
                    DisableControls(picboxFirst);
                }
                if (dynamicDotNetTwain.CurrentImageIndexInBuffer + 1 == dynamicDotNetTwain.HowManyImagesInBuffer)
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
            try
            {
                // Select the source for TWAIN
                var srcIndex = -1;
                for (short i = 0; i < dynamicDotNetTwain.SourceCount; i++)
                {
                    if (dynamicDotNetTwain.SourceNameItems(i) != cbxSource.Text) continue;
                    srcIndex = i;
                    break;
                }

                dynamicDotNetTwain.SelectSourceByIndex(srcIndex == -1 ? cbxSource.SelectedIndex : srcIndex);
                dynamicDotNetTwain.OpenSource();
                dynamicDotNetTwain.IfShowUI = false;
                dynamicDotNetTwain.IfDisableSourceAfterAcquire = true;

                if (rdbtnBW.Checked)
                {
                    dynamicDotNetTwain.PixelType = TWICapPixelType.TWPT_BW;
                    dynamicDotNetTwain.BitDepth = 1;
                }
                else if (rdbtnGray.Checked)
                {
                    dynamicDotNetTwain.PixelType = TWICapPixelType.TWPT_GRAY;
                    dynamicDotNetTwain.BitDepth = 8;
                }
                else
                {
                    dynamicDotNetTwain.PixelType = TWICapPixelType.TWPT_RGB;
                    dynamicDotNetTwain.BitDepth = 24;
                }


                dynamicDotNetTwain.Resolution = int.Parse(cbxResolution.Text);
                // Acquire image from the source
                if (!dynamicDotNetTwain.AcquireImage())
                    MessageBox.Show(dynamicDotNetTwain.ErrorString, "Scan error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occurs: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dynamicDotNetTwain.ErrorCode != ErrorCode.Succeed)
                    EnableControls(picboxScan);
            }
        }

        private void picboxPoint_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = false;
            dynamicDotNetTwain.AnnotationType = DWTAnnotationType.enumNone;
        }

        // Change mouse shape to hand, for move image
        private void picboxHand_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = true;
            dynamicDotNetTwain.AnnotationType = DWTAnnotationType.enumNone;
        }

        private void picboxFit_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.IfFitWindow = true;
            CheckZoom();
        }

        private void picboxOriginalSize_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.IfFitWindow = false;
            CheckZoom();
        }

        private void CropPicture(int imageIndex, Rectangle rc)
        {
            dynamicDotNetTwain.Crop((short)imageIndex, rc.X, rc.Y, rc.X + rc.Width, rc.Y + rc.Height);
        }

        private void picboxZoomIn_Click(object sender, EventArgs e)
        {
            var zoom = dynamicDotNetTwain.Zoom + 0.1F;
            dynamicDotNetTwain.IfFitWindow = false;
            dynamicDotNetTwain.Zoom = zoom;
            CheckZoom();
        }

        private void picboxZoomOut_Click(object sender, EventArgs e)
        {
            var zoom = dynamicDotNetTwain.Zoom - 0.1F;
            dynamicDotNetTwain.IfFitWindow = false;
            dynamicDotNetTwain.Zoom = zoom;
            CheckZoom();
        }

        private void CheckZoom()
        {
            if (cbxViewMode.SelectedIndex != 0 || dynamicDotNetTwain.HowManyImagesInBuffer == 0 )
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
           
            if (dynamicDotNetTwain.Zoom <= 0.02F)
            {
                DisableControls(picboxZoomOut);
            }
            else
            {
                EnableControls(picboxZoomOut);
            }

            if (dynamicDotNetTwain.Zoom >= 65F)         
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
            dynamicDotNetTwain.RemoveImage(dynamicDotNetTwain.CurrentImageIndexInBuffer);
            CheckImageCount();
        }

        private void picboxDeleteAll_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.RemoveAllImages();
            CheckImageCount();
        }

        private void cbxSource_DropDown(object sender, EventArgs e)
        {
            var orgSrcName = cbxSource.Text;
            List<string> curSrcNames;
            if (IsNeedRebindCbxSrc(out curSrcNames))
            {
                cbxSource.Items.Clear();
                for (short i = 0; i < dynamicDotNetTwain.SourceCount; i++)
                {
                    var strSourceName = dynamicDotNetTwain.SourceNameItems(i);
                    if (strSourceName != null && dynamicDotNetTwain.GetSourceType(i) == EnumDeviceType.SDT_TWAIN)
                        cbxSource.Items.Add(strSourceName);
                }
            }

            if (curSrcNames.Contains(orgSrcName)) cbxSource.Text = orgSrcName;

            SetScannerControlsEnable(cbxSource.Items.Count > 0);

            cbxSource.DroppedDown = false;
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
            _currentImageIndex = dynamicDotNetTwain.CurrentImageIndexInBuffer;
            var currentIndex = _currentImageIndex + 1;
            int imageCount = dynamicDotNetTwain.HowManyImagesInBuffer;
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
                dynamicDotNetTwain.Visible = false;
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
                    dynamicDotNetTwain.SetViewMode(-1,-1);
                    break;
                case 1:
                    dynamicDotNetTwain.SetViewMode(2, 2);
                    break;
                case 2: 
                    dynamicDotNetTwain.SetViewMode(3, 3);
                    break;
                case 3:
                    dynamicDotNetTwain.SetViewMode(4, 4);
                    break;
                case 4:
                    dynamicDotNetTwain.SetViewMode(5, 5);
                    break;
                default:
                    dynamicDotNetTwain.SetViewMode(-1, -1);
                    break;
            }
            CheckZoom();
        }     

        private void picboxFirst_Click(object sender, EventArgs e)
        {
            if(dynamicDotNetTwain.HowManyImagesInBuffer > 0)
                dynamicDotNetTwain.CurrentImageIndexInBuffer = 0;
            CheckImageCount();
        }

        private void picboxLast_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain.HowManyImagesInBuffer > 0)
                dynamicDotNetTwain.CurrentImageIndexInBuffer = (short)(dynamicDotNetTwain.HowManyImagesInBuffer - 1);
            CheckImageCount();
        }

        private void picboxPrevious_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain.HowManyImagesInBuffer > 0 && dynamicDotNetTwain.CurrentImageIndexInBuffer > 0)
                --dynamicDotNetTwain.CurrentImageIndexInBuffer;
            CheckImageCount();
        }

        private void picboxNext_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain.HowManyImagesInBuffer > 0 &&
                dynamicDotNetTwain.CurrentImageIndexInBuffer < dynamicDotNetTwain.HowManyImagesInBuffer - 1)
                ++dynamicDotNetTwain.CurrentImageIndexInBuffer;
            CheckImageCount();
        }

        private void picboxLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*GIF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF|PDF|*.PDF";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = _lastOpenedDirectory;

            dynamicDotNetTwain.IfAppendImage = true;

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
                            dynamicDotNetTwain.PDFConvertMode = EnumPDFConvertMode.enumCM_RENDERALL;
                            dynamicDotNetTwain.SetPDFResolution(300);
                            dynamicDotNetTwain.LoadImage(strFileName);

                            if (dynamicDotNetTwain.ErrorCode != ErrorCode.Succeed)
                            {
                                MessageBox.Show(dynamicDotNetTwain.ErrorString, "Loading image error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            dynamicDotNetTwain.LoadImage(strFileName);
                    }
                    else
                        dynamicDotNetTwain.LoadImage(strFileName);
                }
                dynamicDotNetTwain.Visible = true;
            }
            CheckImageCount();
        }

        #endregion

        #region dynamicDotNetTwain event

        private void dynamicDotNetTwain_OnMouseClick(short sImageIndex)
        {
            if (dynamicDotNetTwain.CurrentImageIndexInBuffer != _currentImageIndex)
                CheckImageCount();
        }

        /// <summary>
        /// 
        /// </summary>
        private void dynamicDotNetTwain_OnPostAllTransfers()
        {
            CrossThreadOperationControl crossDelegate = delegate()
                {
                    dynamicDotNetTwain.Visible = true;
                    CheckImageCount();
                    EnableControls(picboxScan);
                };
            Invoke(crossDelegate);
        }

        private void dynamicDotNetTwain_OnMouseDoubleClick(short sImageIndex)
        {
            try
            {
                var rc = dynamicDotNetTwain.GetSelectionRect(sImageIndex);

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
            dynamicDotNetTwain.ClearSelectionRect(sImageIndex);
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

        private void dynamicDotNetTwain_OnFrameCapture(Dynamsoft.DotNet.TWAIN.Interface.OnFrameCaptureEventArgs arg)
        {
            if (_bTurnOnReading)
            {
                ReadFromFrame(arg.Frame);
            }
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
                case "_thAcquireImage":
                    _webCamMode = false;
                   
                    CheckImageCount();
                    dynamicDotNetTwain.CloseSource();

                    dynamicDotNetTwain.SupportedDeviceType = thHead.Name == "_thLoadImage" ?EnumSupportedDeviceType.SDT_ALL : EnumSupportedDeviceType.SDT_TWAIN;
                    cbxImageCaptureDevice.SelectedIndex = thHead.Name == "_thLoadImage" ? 0 : 1;
                    
                    _bTurnOnReading = false;
                    picBoxWebCam.Visible = false;
                    this.SwitchButtonState(false);
                    break;

                case "_thWebCamImage":
                    _webCamMode = true;

                    if (_webCamErrorOccur)
                    {
                        DisableControls(picboxReadBarcode);
                        break;
                    }

                    cbxImageCaptureDevice.SelectedIndex = 2;
                    dynamicDotNetTwain.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;
                    SetWebCamAsDntSrc(cbxWebCamSrc.Text);
                    dynamicDotNetTwain.SetVideoContainer(picBoxWebCam);
                    dynamicDotNetTwain.OpenSource();
                    dynamicDotNetTwain.ResolutionForCam = GetCamResolution();
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
		
        private void postShowFrameResults(Bitmap _bitmap, BarcodeResult[] _bars, int timeElapsed)
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

                picBoxWebCam.Image = tempBitmap;
                dynamicDotNetTwain.IfShowUI = false;

                this.ShowResult(_bars, timeElapsed);
            }
        }

        private void ReadFromFrame(Bitmap bitmap)
        {
            BarcodeResult[] bars = null;
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

                this.BeginInvoke(_postShowFrameResults, new object[] { bitmap, bars, timeElapsed });
            }
            catch (Exception ex)
            {
                this.BeginInvoke(_postShowFrameResults, new object[] { bitmap, bars, timeElapsed });
                MessageBox.Show(ex.Message);
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
                var rect = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer);
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
                _br.ReaderOptions.TimeoutPerPage = iTimeout;
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

            if (dynamicDotNetTwain.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if(!CheckAndSetReaderOptions())
                    return;

                Bitmap bmp = (Bitmap)(dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer));
                
                DateTime beforeRead = DateTime.Now;
                
                BarcodeResult[] aryResult=_br.DecodeBitmap(bmp);
                
                DateTime afterRead = DateTime.Now;
                int timeElapsed = (int)(afterRead - beforeRead).TotalMilliseconds;

                List<AnnotationData> aryAnnotations;
                if (dynamicDotNetTwain.GetAllAnnotationDataList(dynamicDotNetTwain.CurrentImageIndexInBuffer, out aryAnnotations))
                    dynamicDotNetTwain.DeleteAnnotations(dynamicDotNetTwain.CurrentImageIndexInBuffer, aryAnnotations);

                if(aryResult != null)
                { 
                    for (var i = 0; i < aryResult.Length; i++)
                    {
                        //add rect annotation
                        var penColor = Color.Red;
                        if (aryResult[i].IsUnrecognized)
                            penColor = Color.Blue;

                        var rectAnnotation = new RectangleAnnotationData
                        {
                            AnnotationLocation = aryResult[i].BoundingRect.Location,
                            AnnotationSize = aryResult[i].BoundingRect.Size,
                            FillColor = Color.Transparent,
                            PenColor = penColor,
                            PenWidth = 3
                        };

                        float fsize = bmp.Width / 48.0f;
                        if (fsize < 25)
                            fsize = 25;

                        Font textFont = new Font("Times New Roman", fsize, FontStyle.Bold);

                        string strNo = "[" + (i + 1) + "]";
                        SizeF textSize = Graphics.FromHwnd(IntPtr.Zero).MeasureString(strNo, textFont);

                        var textAnnotation = new TextAnnotationData()
                        {
                            AnnotationLocation = new Point(aryResult[i].BoundingRect.Location.X, (int)(aryResult[i].BoundingRect.Location.Y - textSize.Height * 1.25f)),
                            AnnotationSize = new System.Drawing.Size((int)textSize.Width * 2, (int)(textSize.Height * 1.25f)),
                            TextContent = strNo,
                            TextFont = textFont,
                            TextColor = Color.Blue
                        };

                        dynamicDotNetTwain.CreateAnnotation(dynamicDotNetTwain.CurrentImageIndexInBuffer, rectAnnotation);
                        dynamicDotNetTwain.CreateAnnotation(dynamicDotNetTwain.CurrentImageIndexInBuffer, textAnnotation);
                    }
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
            if (dynamicDotNetTwain.CurrentImageIndexInBuffer >= 0)
            {
                var recSelArea = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer);
                var imgCurrent = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer);
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
                _br.ReaderOptions.MaxBarcodesToReadPerPage = 1;
                dynamicDotNetTwain.IfDisableSourceAfterAcquire = false;
                dynamicDotNetTwain.IfShowUI = true;
                this.SwitchButtonState(true);
            }
            else
            {
                this.SwitchButtonState(false);
            }
        }

        private CamResolution GetCamResolution()
        {
            var resAry = cbxWebCamRes.Text.Split('x');
            int width, height;

            return resAry.Length > 1 && int.TryParse(resAry[0], out width) && int.TryParse(resAry[1], out height)
                ? new CamResolution(width, height)
                : dynamicDotNetTwain.ResolutionForCam;
        }

        private void InitWebCamControls()
        {
            try
            {
                dynamicDotNetTwain.CloseSource();
                dynamicDotNetTwain.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;
                InitCbxWebCamSrc();
                SetWebCamAsDntSrc(cbxWebCamSrc.Text);
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
            var camResolution = dynamicDotNetTwain.ResolutionForCam;
            if (camResolution == null || camResolution.Width <= 0 || camResolution.Height <= 0) return;

            if (iRotate%2 == 0)
            {
                var iVideoWidth = picBoxWebCam.Width;
                var iVideoHeight = picBoxWebCam.Width*camResolution.Height/camResolution.Width;
                var iContentHeight = picBoxWebCam.Height - picBoxWebCam.Margin.Top - picBoxWebCam.Margin.Bottom - picBoxWebCam.Padding.Top - picBoxWebCam.Padding.Bottom;

                if (iVideoHeight < iContentHeight)
                    dynamicDotNetTwain.ResizeVideoWindow(0, (iContentHeight - iVideoHeight)/2, iVideoWidth, iVideoHeight);
                else
                    dynamicDotNetTwain.ResizeVideoWindow(0, 0, picBoxWebCam.Width, picBoxWebCam.Height);
            }
            else
            {
                var iVideoHeight = picBoxWebCam.Height;
                var iVideoWidth = picBoxWebCam.Height*camResolution.Height/camResolution.Width;
                var iContentWidth = picBoxWebCam.Width - picBoxWebCam.Margin.Right - picBoxWebCam.Margin.Left - picBoxWebCam.Padding.Right - picBoxWebCam.Padding.Left;

                if (iVideoWidth < iContentWidth)
                    dynamicDotNetTwain.ResizeVideoWindow((iContentWidth - iVideoWidth)/2, 0, iVideoWidth, iVideoHeight);
                else
                    dynamicDotNetTwain.ResizeVideoWindow(0, 0, picBoxWebCam.Width, picBoxWebCam.Height);
            }
        }

        private void cbxWebCamSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnOnReading(false);

            dynamicDotNetTwain.CloseSource();
            dynamicDotNetTwain.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;
            picBoxWebCam.Image = null;
            SetWebCamAsDntSrc(cbxWebCamSrc.Text);
            InitCbxWebCamRes();
            if (_webCamErrorOccur) return;
            dynamicDotNetTwain.SetVideoContainer(picBoxWebCam);
            dynamicDotNetTwain.OpenSource();
            dynamicDotNetTwain.ResolutionForCam = GetCamResolution();
            ResizeVideoWindow(0);
            dynamicDotNetTwain.IfShowUI = true;
        }

        private bool IsNeedRebindCbxSrc(out List<string> curSrcNames)
        {
            var orgSrcNames = new List<string>();
            for (short i = 0; i < dynamicDotNetTwain.SourceCount; i++)
            {
                orgSrcNames.Add(dynamicDotNetTwain.SourceNameItems(i));
            }

            dynamicDotNetTwain.CloseSourceManager();
            dynamicDotNetTwain.OpenSourceManager();

            curSrcNames = new List<string>();
            for (short i = 0; i < dynamicDotNetTwain.SourceCount; i++)
            {
                curSrcNames.Add(dynamicDotNetTwain.SourceNameItems(i));
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

        private void cbxWebCamSrc_DropDown(object sender, EventArgs e)
        {
            if (_webCamErrorOccur) return;

            TurnOnReading(false);

            var orgSrcName = cbxWebCamSrc.Text;
            List<string> curSrcNames;
            if (IsNeedRebindCbxSrc(out curSrcNames)) BindCbxWebCamSrc();

            if(cbxWebCamSrc.Items.Count == 0) cbxWebCamRes.Items.Clear();

            if (curSrcNames.Contains(orgSrcName))
            {
                cbxWebCamSrc.Text = orgSrcName;
                picBoxWebCam.Image = null;
                SetWebCamAsDntSrc(orgSrcName);
                InitCbxWebCamRes();
                dynamicDotNetTwain.SetVideoContainer(picBoxWebCam);
                dynamicDotNetTwain.OpenSource();
                dynamicDotNetTwain.ResolutionForCam = GetCamResolution();
                ResizeVideoWindow(0);
                dynamicDotNetTwain.IfShowUI = true;
            }
            
            cbxWebCamSrc.DroppedDown = false;
            if(string.IsNullOrEmpty(cbxWebCamSrc.Text)) 
                DisableControls(picboxReadBarcode);
        }

        private void cbxWebCamRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnOnReading(false);

            picBoxWebCam.Image = null;
            dynamicDotNetTwain.ResolutionForCam = GetCamResolution();
            ResizeVideoWindow(0);
            dynamicDotNetTwain.IfShowUI = true;
        }

        private void SetWebCamAsDntSrc(string srcName)
        {
            dynamicDotNetTwain.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;

            var srcIndex = -1;
            for (short i = 0; i < dynamicDotNetTwain.SourceCount; i++)
            {
                if (dynamicDotNetTwain.SourceNameItems(i) != srcName) continue;
                srcIndex = i;
                break;
            }

            dynamicDotNetTwain.SelectSourceByIndex(srcIndex == -1 ? cbxWebCamSrc.SelectedIndex : srcIndex);
        }

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
    }
}
