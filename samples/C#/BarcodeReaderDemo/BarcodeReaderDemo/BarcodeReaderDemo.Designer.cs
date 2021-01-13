using System;
using System.Drawing;
using System.Windows.Forms;
using Barcode_Reader_Demo;
using Barcode_Reader_Demo.Properties;

namespace Barcode_Reader_Demo
{
    partial class BarcodeReaderDemo
    {
        private int cmbDeblurLevel_SelectedIndex = 0;
        private int cmbLocalizationModes_SelectedIndex = 0;
        private int cmbGrayscaleTransformationModes_SelectedIndex = 0;
        private int cmbImagePreprocessingModes_SelectedIndex = 0;
        private int cmbMinResultConfidence_SelectedIndex = 0;
        private int cmbTextureDetectionSensitivity_SelectedIndex = 0;       
            
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picBoxWebCam = new System.Windows.Forms.PictureBox();
            this.lbMoveBar = new System.Windows.Forms.Label();
            this.picboxZoomOut = new System.Windows.Forms.PictureBox();
            this.picboxZoomIn = new System.Windows.Forms.PictureBox();
            this.picboxDeleteAll = new System.Windows.Forms.PictureBox();
            this.picboxDelete = new System.Windows.Forms.PictureBox();
            this.picboxFirst = new System.Windows.Forms.PictureBox();
            this.picboxLast = new System.Windows.Forms.PictureBox();
            this.picboxNext = new System.Windows.Forms.PictureBox();
            this.picboxPrevious = new System.Windows.Forms.PictureBox();
            this.cbxViewMode = new System.Windows.Forms.ComboBox();
            this.picboxMin = new System.Windows.Forms.PictureBox();
            this.picboxClose = new System.Windows.Forms.PictureBox();
            this.lbDiv = new System.Windows.Forms.Label();
            this.tbxCurrentImageIndex = new System.Windows.Forms.TextBox();
            this.tbxTotalImageNum = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelNormalSettings = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelRecognitionMode = new System.Windows.Forms.Panel();
            this.pictureBoxCustomize = new System.Windows.Forms.PictureBox();
            this.comment = new System.Windows.Forms.Label();
            this.lbRecMode = new System.Windows.Forms.Label();
            this.panelReadBarcode = new System.Windows.Forms.Panel();
            this.picboxReadBarcode = new System.Windows.Forms.PictureBox();
            this.picboxStopBarcode = new System.Windows.Forms.PictureBox();
            this.rbBalance = new System.Windows.Forms.RadioButton();
            this.rbBestSpeed = new System.Windows.Forms.RadioButton();
            this.rbBestCoverage = new System.Windows.Forms.RadioButton();
            this.panelPostalCodeDetail = new System.Windows.Forms.Panel();
            this.cbPlanet = new System.Windows.Forms.CheckBox();
            this.cbPostnet = new System.Windows.Forms.CheckBox();
            this.cbRM4SCC = new System.Windows.Forms.CheckBox();
            this.cbAustralianPost = new System.Windows.Forms.CheckBox();
            this.cbUSPSIntelligentMail = new System.Windows.Forms.CheckBox();
            this.panelPDFDetail = new System.Windows.Forms.Panel();
            this.cbMicroPDF = new System.Windows.Forms.CheckBox();
            this.cbPDF417 = new System.Windows.Forms.CheckBox();
            this.panelQRDetail = new System.Windows.Forms.Panel();
            this.cbMicroQR = new System.Windows.Forms.CheckBox();
            this.cbQRcode = new System.Windows.Forms.CheckBox();
            this.panelFormat = new System.Windows.Forms.Panel();
            this.cbPostalCode = new System.Windows.Forms.CheckBox();
            this.btnExportSettings = new System.Windows.Forms.Button();
            this.btnShowAllOneD = new System.Windows.Forms.Button();
            this.btnShowAllDatabar = new System.Windows.Forms.Button();
            this.btnShowAllPDF = new System.Windows.Forms.Button();
            this.btnShowAllQR = new System.Windows.Forms.Button();
            this.btnShowAllPostalCode = new System.Windows.Forms.Button();
            this.lableFormat = new System.Windows.Forms.Label();
            this.cbOneD = new System.Windows.Forms.CheckBox();
            this.cbAllPDF417 = new System.Windows.Forms.CheckBox();
            this.cbAllQRCode = new System.Windows.Forms.CheckBox();
            this.cbDATABAR = new System.Windows.Forms.CheckBox();
            this.cbDataMatrix = new System.Windows.Forms.CheckBox();
            this.cbMaxicode = new System.Windows.Forms.CheckBox();
            this.cbAZTEC = new System.Windows.Forms.CheckBox();
            this.cbPATCHCODE = new System.Windows.Forms.CheckBox();
            this.cbGS1Composite = new System.Windows.Forms.CheckBox();
            this.cbDOTCODE = new System.Windows.Forms.CheckBox();
            this.panelOneDetail = new System.Windows.Forms.Panel();
            this.cbINDUSTRIAL25 = new System.Windows.Forms.CheckBox();
            this.cbUPCE = new System.Windows.Forms.CheckBox();
            this.cbUPCA = new System.Windows.Forms.CheckBox();
            this.cbEAN8 = new System.Windows.Forms.CheckBox();
            this.cbCODABAR = new System.Windows.Forms.CheckBox();
            this.cbITF = new System.Windows.Forms.CheckBox();
            this.cbEAN13 = new System.Windows.Forms.CheckBox();
            this.cbCODE93 = new System.Windows.Forms.CheckBox();
            this.cbCODE128 = new System.Windows.Forms.CheckBox();
            this.cbCOD39 = new System.Windows.Forms.CheckBox();
            this.cbMSICODE = new System.Windows.Forms.CheckBox();
            this.panelDatabarDetail = new System.Windows.Forms.Panel();
            this.cbDatabarOmnidirectional = new System.Windows.Forms.CheckBox();
            this.cbDatabarExpanded = new System.Windows.Forms.CheckBox();
            this.cbDatabarExpanedStacked = new System.Windows.Forms.CheckBox();
            this.cbDatabarLimited = new System.Windows.Forms.CheckBox();
            this.cbDatabarStacked = new System.Windows.Forms.CheckBox();
            this.cbDatabarStackedOmnidirectional = new System.Windows.Forms.CheckBox();
            this.cbDatabarTruncated = new System.Windows.Forms.CheckBox();
            this.panelCustom = new System.Windows.Forms.Panel();
            this.panelCustomTop = new System.Windows.Forms.Panel();
            this.panelBarcodeReaderParent = new System.Windows.Forms.Panel();
            this.lbCustomPanelClose = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panelCustomSettings = new System.Windows.Forms.Panel();
            this.panelFormatParent = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTextureDetectionSensitivity = new System.Windows.Forms.ComboBox();
            this.cmbMinResultConfidence = new System.Windows.Forms.ComboBox();
            this.cmbImagePreprocessingModes = new System.Windows.Forms.ComboBox();
            this.cmbGrayscaleTransformationModes = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbBinarizationBlockSize = new System.Windows.Forms.TextBox();
            this.tbScaleDownThreshold = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRegionPredetectionMode = new System.Windows.Forms.CheckBox();
            this.cbTextFilterMode = new System.Windows.Forms.CheckBox();
            this.cmbLocalizationModes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDeblurLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbExpectedBarcodesCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelLoad = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.picboxLoadImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWebCam = new System.Windows.Forms.Panel();
            this.labelWebcamNote = new System.Windows.Forms.Label();
            this.lblWebCamSrc = new System.Windows.Forms.Label();
            this.cbxWebCamSrc = new System.Windows.Forms.ComboBox();
            this.lblWebCamRes = new System.Windows.Forms.Label();
            this.cbxWebCamRes = new System.Windows.Forms.ComboBox();
            this.panelAcquire = new System.Windows.Forms.Panel();
            this.rdbtnGray = new System.Windows.Forms.RadioButton();
            this.cbxResolution = new System.Windows.Forms.ComboBox();
            this.picboxScan = new System.Windows.Forms.PictureBox();
            this.rdbtnBW = new System.Windows.Forms.RadioButton();
            this.lbResolution = new System.Windows.Forms.Label();
            this.rdbtnColor = new System.Windows.Forms.RadioButton();
            this.lbPixelType = new System.Windows.Forms.Label();
            this.lbSelectSource = new System.Windows.Forms.Label();
            this.cbxSource = new System.Windows.Forms.ComboBox();
            this.lbSelectRecognitionMode = new System.Windows.Forms.Label();
            this.panelReadSetting = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panelReadMoreSetting = new System.Windows.Forms.Panel();
            this.picboxFit = new System.Windows.Forms.PictureBox();
            this.picboxOriginalSize = new System.Windows.Forms.PictureBox();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.lblCloseResult = new System.Windows.Forms.Label();
            this.dsViewer = new Dynamsoft.Forms.DSViewer();
            this.saveRuntimeSettingsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTipExport = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWebCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDeleteAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxClose)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelNormalSettings.SuspendLayout();
            this.panelRecognitionMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomize)).BeginInit();
            this.panelReadBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxReadBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxStopBarcode)).BeginInit();
            this.panelPostalCodeDetail.SuspendLayout();
            this.panelPDFDetail.SuspendLayout();
            this.panelQRDetail.SuspendLayout();
            this.panelFormat.SuspendLayout();
            this.panelOneDetail.SuspendLayout();
            this.panelDatabarDetail.SuspendLayout();
            this.panelCustom.SuspendLayout();
            this.panelCustomTop.SuspendLayout();
            this.panelCustomSettings.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoadImage)).BeginInit();
            this.panelWebCam.SuspendLayout();
            this.panelAcquire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScan)).BeginInit();
            this.panelReadSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginalSize)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxWebCam
            // 
            this.picBoxWebCam.BackColor = System.Drawing.Color.White;
            this.picBoxWebCam.Location = new System.Drawing.Point(6, 48);
            this.picBoxWebCam.Name = "picBoxWebCam";
            this.picBoxWebCam.Size = new System.Drawing.Size(563, 692);
            this.picBoxWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxWebCam.TabIndex = 2;
            this.picBoxWebCam.TabStop = false;
            this.picBoxWebCam.Visible = false;
            // 
            // lbMoveBar
            // 
            this.lbMoveBar.BackColor = System.Drawing.Color.Transparent;
            this.lbMoveBar.Location = new System.Drawing.Point(0, 1);
            this.lbMoveBar.Name = "lbMoveBar";
            this.lbMoveBar.Size = new System.Drawing.Size(897, 32);
            this.lbMoveBar.TabIndex = 18;
            this.lbMoveBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbMoveBar_MouseDown);
            this.lbMoveBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbMoveBar_MouseMove);
            // 
            // picboxZoomOut
            // 
            this.picboxZoomOut.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxZoomOut_Leave;
            this.picboxZoomOut.Location = new System.Drawing.Point(12, 204);
            this.picboxZoomOut.Name = "picboxZoomOut";
            this.picboxZoomOut.Size = new System.Drawing.Size(60, 36);
            this.picboxZoomOut.TabIndex = 34;
            this.picboxZoomOut.TabStop = false;
            this.picboxZoomOut.Tag = "Zoom Out";
            this.picboxZoomOut.Click += new System.EventHandler(this.picboxZoomOut_Click);
            this.picboxZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxZoomOut.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxZoomOut.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxZoomOut.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxZoomIn
            // 
            this.picboxZoomIn.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxZoomIn_Leave;
            this.picboxZoomIn.Location = new System.Drawing.Point(12, 156);
            this.picboxZoomIn.Name = "picboxZoomIn";
            this.picboxZoomIn.Size = new System.Drawing.Size(61, 36);
            this.picboxZoomIn.TabIndex = 32;
            this.picboxZoomIn.TabStop = false;
            this.picboxZoomIn.Tag = "Zoom In";
            this.picboxZoomIn.Click += new System.EventHandler(this.picboxZoomIn_Click);
            this.picboxZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxZoomIn.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxZoomIn.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxZoomIn.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxDeleteAll
            // 
            this.picboxDeleteAll.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxDeleteAll_Leave;
            this.picboxDeleteAll.Location = new System.Drawing.Point(12, 252);
            this.picboxDeleteAll.Name = "picboxDeleteAll";
            this.picboxDeleteAll.Size = new System.Drawing.Size(60, 36);
            this.picboxDeleteAll.TabIndex = 38;
            this.picboxDeleteAll.TabStop = false;
            this.picboxDeleteAll.Tag = "Delete All";
            this.picboxDeleteAll.Click += new System.EventHandler(this.picboxDeleteAll_Click);
            this.picboxDeleteAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxDeleteAll.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxDeleteAll.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxDeleteAll.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxDeleteAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxDelete
            // 
            this.picboxDelete.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxDelete_Leave;
            this.picboxDelete.Location = new System.Drawing.Point(12, 300);
            this.picboxDelete.Name = "picboxDelete";
            this.picboxDelete.Size = new System.Drawing.Size(61, 36);
            this.picboxDelete.TabIndex = 36;
            this.picboxDelete.TabStop = false;
            this.picboxDelete.Tag = "Delete Current Image";
            this.picboxDelete.Click += new System.EventHandler(this.picboxDelete_Click);
            this.picboxDelete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxDelete.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxDelete.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxDelete.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxFirst
            // 
            this.picboxFirst.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxFirst_Leave;
            this.picboxFirst.Location = new System.Drawing.Point(99, 709);
            this.picboxFirst.Name = "picboxFirst";
            this.picboxFirst.Size = new System.Drawing.Size(50, 25);
            this.picboxFirst.TabIndex = 42;
            this.picboxFirst.TabStop = false;
            this.picboxFirst.Tag = "First Image";
            this.picboxFirst.Click += new System.EventHandler(this.picboxFirst_Click);
            this.picboxFirst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxFirst.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxFirst.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxFirst.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxFirst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxLast
            // 
            this.picboxLast.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxLast_Leave;
            this.picboxLast.Location = new System.Drawing.Point(418, 709);
            this.picboxLast.Name = "picboxLast";
            this.picboxLast.Size = new System.Drawing.Size(50, 25);
            this.picboxLast.TabIndex = 43;
            this.picboxLast.TabStop = false;
            this.picboxLast.Tag = "Last Image";
            this.picboxLast.Click += new System.EventHandler(this.picboxLast_Click);
            this.picboxLast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxLast.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxLast.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxLast.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxLast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxNext
            // 
            this.picboxNext.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxNext_Leave;
            this.picboxNext.Location = new System.Drawing.Point(362, 709);
            this.picboxNext.Name = "picboxNext";
            this.picboxNext.Size = new System.Drawing.Size(50, 25);
            this.picboxNext.TabIndex = 44;
            this.picboxNext.TabStop = false;
            this.picboxNext.Tag = "Next Image";
            this.picboxNext.Click += new System.EventHandler(this.picboxNext_Click);
            this.picboxNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxNext.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxNext.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxNext.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxPrevious
            // 
            this.picboxPrevious.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxPrevious_Leave;
            this.picboxPrevious.Location = new System.Drawing.Point(155, 709);
            this.picboxPrevious.Name = "picboxPrevious";
            this.picboxPrevious.Size = new System.Drawing.Size(50, 25);
            this.picboxPrevious.TabIndex = 47;
            this.picboxPrevious.TabStop = false;
            this.picboxPrevious.Tag = "Previous Image";
            this.picboxPrevious.Click += new System.EventHandler(this.picboxPrevious_Click);
            this.picboxPrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxPrevious.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxPrevious.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxPrevious.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxPrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // cbxViewMode
            // 
            this.cbxViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxViewMode.FormattingEnabled = true;
            this.cbxViewMode.Items.AddRange(new object[] {
            "1 x 1",
            "2 x 2",
            "3 x 3",
            "4 x 4",
            "5 x 5"});
            this.cbxViewMode.Location = new System.Drawing.Point(474, 709);
            this.cbxViewMode.Name = "cbxViewMode";
            this.cbxViewMode.Size = new System.Drawing.Size(75, 23);
            this.cbxViewMode.TabIndex = 650;
            this.cbxViewMode.SelectedIndexChanged += new System.EventHandler(this.cbxLayout_SelectedIndexChanged);
            // 
            // picboxMin
            // 
            this.picboxMin.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxMin_Leave;
            this.picboxMin.Location = new System.Drawing.Point(840, 10);
            this.picboxMin.Name = "picboxMin";
            this.picboxMin.Size = new System.Drawing.Size(20, 20);
            this.picboxMin.TabIndex = 73;
            this.picboxMin.TabStop = false;
            this.picboxMin.Click += new System.EventHandler(this.picboxMin_Click);
            this.picboxMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxMin.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxMin.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxClose
            // 
            this.picboxClose.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxClose_Leave;
            this.picboxClose.Location = new System.Drawing.Point(864, 10);
            this.picboxClose.Name = "picboxClose";
            this.picboxClose.Size = new System.Drawing.Size(20, 20);
            this.picboxClose.TabIndex = 74;
            this.picboxClose.TabStop = false;
            this.picboxClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picboxClose_MouseClick);
            this.picboxClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxClose.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxClose.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // lbDiv
            // 
            this.lbDiv.AutoSize = true;
            this.lbDiv.BackColor = System.Drawing.Color.Transparent;
            this.lbDiv.Location = new System.Drawing.Point(279, 714);
            this.lbDiv.Name = "lbDiv";
            this.lbDiv.Size = new System.Drawing.Size(12, 15);
            this.lbDiv.TabIndex = 75;
            this.lbDiv.Text = "/";
            // 
            // tbxCurrentImageIndex
            // 
            this.tbxCurrentImageIndex.Enabled = false;
            this.tbxCurrentImageIndex.Location = new System.Drawing.Point(211, 709);
            this.tbxCurrentImageIndex.Name = "tbxCurrentImageIndex";
            this.tbxCurrentImageIndex.ReadOnly = true;
            this.tbxCurrentImageIndex.Size = new System.Drawing.Size(61, 23);
            this.tbxCurrentImageIndex.TabIndex = 76;
            this.tbxCurrentImageIndex.Text = "0";
            this.tbxCurrentImageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxTotalImageNum
            // 
            this.tbxTotalImageNum.Enabled = false;
            this.tbxTotalImageNum.Location = new System.Drawing.Point(295, 709);
            this.tbxTotalImageNum.Name = "tbxTotalImageNum";
            this.tbxTotalImageNum.ReadOnly = true;
            this.tbxTotalImageNum.Size = new System.Drawing.Size(61, 23);
            this.tbxTotalImageNum.TabIndex = 77;
            this.tbxTotalImageNum.Text = "0";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Controls.Add(this.panelNormalSettings);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(566, 48);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(331, 688);
            this.flowLayoutPanel2.TabIndex = 84;
            // 
            // panelNormalSettings
            // 
            this.panelNormalSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelNormalSettings.Controls.Add(this.panelOneDetail);
            this.panelNormalSettings.Controls.Add(this.label14);
            this.panelNormalSettings.Controls.Add(this.label2);
            this.panelNormalSettings.Controls.Add(this.label13);
            this.panelNormalSettings.Controls.Add(this.panelRecognitionMode);
            this.panelNormalSettings.Controls.Add(this.panelDatabarDetail);
            this.panelNormalSettings.Controls.Add(this.panelPostalCodeDetail);
            this.panelNormalSettings.Controls.Add(this.panelQRDetail);
            this.panelNormalSettings.Controls.Add(this.panelPDFDetail);
            this.panelNormalSettings.Controls.Add(this.panelFormat);
            this.panelNormalSettings.Location = new System.Drawing.Point(3, 3);
            this.panelNormalSettings.Name = "panelNormalSettings";
            this.panelNormalSettings.Size = new System.Drawing.Size(310, 446);
            this.panelNormalSettings.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.DarkGray;
            this.label14.Location = new System.Drawing.Point(0, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(305, 1);
            this.label14.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 1);
            this.label2.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Open Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label13.Location = new System.Drawing.Point(11, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Settings";
            // 
            // panelRecognitionMode
            // 
            this.panelRecognitionMode.Controls.Add(this.pictureBoxCustomize);
            this.panelRecognitionMode.Controls.Add(this.comment);
            this.panelRecognitionMode.Controls.Add(this.lbRecMode);
            this.panelRecognitionMode.Controls.Add(this.panelReadBarcode);
            this.panelRecognitionMode.Controls.Add(this.rbBalance);
            this.panelRecognitionMode.Controls.Add(this.rbBestSpeed);
            this.panelRecognitionMode.Controls.Add(this.rbBestCoverage);
            this.panelRecognitionMode.Location = new System.Drawing.Point(0, 288);
            this.panelRecognitionMode.Name = "panelRecognitionMode";
            this.panelRecognitionMode.Size = new System.Drawing.Size(310, 155);
            this.panelRecognitionMode.TabIndex = 7;
            // 
            // pictureBoxCustomize
            // 
            this.pictureBoxCustomize.InitialImage = global::Barcode_Reader_Demo.Properties.Resources.pictureBoxCustomize_hover;
            this.pictureBoxCustomize.Location = new System.Drawing.Point(190, 77);
            this.pictureBoxCustomize.Name = "pictureBoxCustomize";
            this.pictureBoxCustomize.Size = new System.Drawing.Size(100, 34);
            this.pictureBoxCustomize.TabIndex = 8;
            this.pictureBoxCustomize.TabStop = false;
            this.pictureBoxCustomize.Click += new System.EventHandler(this.btnEditSettings_Click);
            this.pictureBoxCustomize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCustomize_MouseDown);
            this.pictureBoxCustomize.MouseEnter += new System.EventHandler(this.pictureBoxCustomize_MouseEnter);
            this.pictureBoxCustomize.MouseLeave += new System.EventHandler(this.pictureBoxCustomize_MouseLeave);
            this.pictureBoxCustomize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCustomize_MouseUp);
            // 
            // comment
            // 
            this.comment.AutoSize = true;
            this.comment.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comment.Location = new System.Drawing.Point(22, 126);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(230, 15);
            this.comment.TabIndex = 7;
            this.comment.Text = "* \"Customize\" is only for advanced users. ";
            // 
            // lbRecMode
            // 
            this.lbRecMode.AutoSize = true;
            this.lbRecMode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbRecMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lbRecMode.Location = new System.Drawing.Point(19, 11);
            this.lbRecMode.Name = "lbRecMode";
            this.lbRecMode.Size = new System.Drawing.Size(122, 17);
            this.lbRecMode.TabIndex = 4;
            this.lbRecMode.Text = "Recognition Mode";
            // 
            // panelReadBarcode
            // 
            this.panelReadBarcode.AutoSize = true;
            this.panelReadBarcode.BackColor = System.Drawing.Color.Transparent;
            this.panelReadBarcode.Controls.Add(this.picboxReadBarcode);
            this.panelReadBarcode.Controls.Add(this.picboxStopBarcode);
            this.panelReadBarcode.Location = new System.Drawing.Point(20, 77);
            this.panelReadBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.panelReadBarcode.Name = "panelReadBarcode";
            this.panelReadBarcode.Size = new System.Drawing.Size(160, 37);
            this.panelReadBarcode.TabIndex = 3;
            // 
            // picboxReadBarcode
            // 
            this.picboxReadBarcode.Location = new System.Drawing.Point(0, 0);
            this.picboxReadBarcode.Name = "picboxReadBarcode";
            this.picboxReadBarcode.Size = new System.Drawing.Size(153, 34);
            this.picboxReadBarcode.TabIndex = 15;
            this.picboxReadBarcode.TabStop = false;
            this.picboxReadBarcode.Click += new System.EventHandler(this.picboxReadBarcode_Click);
            this.picboxReadBarcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxReadBarcode.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxReadBarcode.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxReadBarcode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxStopBarcode
            // 
            this.picboxStopBarcode.Location = new System.Drawing.Point(0, 0);
            this.picboxStopBarcode.Name = "picboxStopBarcode";
            this.picboxStopBarcode.Size = new System.Drawing.Size(153, 34);
            this.picboxStopBarcode.TabIndex = 15;
            this.picboxStopBarcode.TabStop = false;
            this.picboxStopBarcode.Visible = false;
            this.picboxStopBarcode.Click += new System.EventHandler(this.picboxStopBarcode_Click);
            this.picboxStopBarcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxStopBarcode.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxStopBarcode.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxStopBarcode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // rbBalance
            // 
            this.rbBalance.AutoSize = true;
            this.rbBalance.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rbBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.rbBalance.Location = new System.Drawing.Point(100, 40);
            this.rbBalance.Name = "rbBalance";
            this.rbBalance.Size = new System.Drawing.Size(80, 21);
            this.rbBalance.TabIndex = 5;
            this.rbBalance.Text = "Balance";
            this.rbBalance.UseVisualStyleBackColor = true;
            this.rbBalance.CheckedChanged += new System.EventHandler(this.rbMode_CheckedChanged);
            // 
            // rbBestSpeed
            // 
            this.rbBestSpeed.AutoSize = true;
            this.rbBestSpeed.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rbBestSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.rbBestSpeed.Location = new System.Drawing.Point(19, 40);
            this.rbBestSpeed.Name = "rbBestSpeed";
            this.rbBestSpeed.Size = new System.Drawing.Size(80, 21);
            this.rbBestSpeed.TabIndex = 5;
            this.rbBestSpeed.TabStop = true;
            this.rbBestSpeed.Text = "Speed";
            this.rbBestSpeed.UseVisualStyleBackColor = true;
            this.rbBestSpeed.CheckedChanged += new System.EventHandler(this.rbMode_CheckedChanged);
            // 
            // rbBestCoverage
            // 
            this.rbBestCoverage.AutoSize = true;
            this.rbBestCoverage.Checked = true;
            this.rbBestCoverage.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rbBestCoverage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.rbBestCoverage.Location = new System.Drawing.Point(180, 40);
            this.rbBestCoverage.Name = "rbBestCoverage";
            this.rbBestCoverage.Size = new System.Drawing.Size(80, 21);
            this.rbBestCoverage.TabIndex = 5;
            this.rbBestCoverage.TabStop = true;
            this.rbBestCoverage.Text = "Coverage";
            this.rbBestCoverage.UseVisualStyleBackColor = true;
            this.rbBestCoverage.CheckedChanged += new System.EventHandler(this.rbMode_CheckedChanged);
            // 
            // panelPostalCodeDetail
            // 
            this.panelPostalCodeDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panelPostalCodeDetail.Controls.Add(this.cbPlanet);
            this.panelPostalCodeDetail.Controls.Add(this.cbPostnet);
            this.panelPostalCodeDetail.Controls.Add(this.cbRM4SCC);
            this.panelPostalCodeDetail.Controls.Add(this.cbAustralianPost);
            this.panelPostalCodeDetail.Controls.Add(this.cbUSPSIntelligentMail);
            this.panelPostalCodeDetail.Location = new System.Drawing.Point(0, 141);
            this.panelPostalCodeDetail.Name = "panelPostalCodeDetail";
            this.panelPostalCodeDetail.Size = new System.Drawing.Size(305, 159);
            this.panelPostalCodeDetail.TabIndex = 9;
            this.panelPostalCodeDetail.Visible = false;
            // 
            // cbPlanet
            // 
            this.cbPlanet.AutoSize = true;
            this.cbPlanet.Checked = true;
            this.cbPlanet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlanet.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbPlanet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbPlanet.Location = new System.Drawing.Point(10, 122);
            this.cbPlanet.Margin = new System.Windows.Forms.Padding(0);
            this.cbPlanet.Name = "cbPlanet";
            this.cbPlanet.Size = new System.Drawing.Size(67, 21);
            this.cbPlanet.TabIndex = 5;
            this.cbPlanet.Text = "Planet";
            this.cbPlanet.UseVisualStyleBackColor = true;
            this.cbPlanet.CheckedChanged += new System.EventHandler(this.rbPostalCodeMode_CheckedChanged);
            // 
            // cbPostnet
            // 
            this.cbPostnet.AutoSize = true;
            this.cbPostnet.Checked = true;
            this.cbPostnet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPostnet.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbPostnet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbPostnet.Location = new System.Drawing.Point(10, 94);
            this.cbPostnet.Margin = new System.Windows.Forms.Padding(0);
            this.cbPostnet.Name = "cbPostnet";
            this.cbPostnet.Size = new System.Drawing.Size(75, 21);
            this.cbPostnet.TabIndex = 3;
            this.cbPostnet.Text = "Postnet";
            this.cbPostnet.UseVisualStyleBackColor = true;
            this.cbPostnet.CheckedChanged += new System.EventHandler(this.rbPostalCodeMode_CheckedChanged);
            // 
            // cbRM4SCC
            // 
            this.cbRM4SCC.AutoSize = true;
            this.cbRM4SCC.Checked = true;
            this.cbRM4SCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRM4SCC.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbRM4SCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbRM4SCC.Location = new System.Drawing.Point(10, 66);
            this.cbRM4SCC.Margin = new System.Windows.Forms.Padding(0);
            this.cbRM4SCC.Name = "cbRM4SCC";
            this.cbRM4SCC.Size = new System.Drawing.Size(263, 21);
            this.cbRM4SCC.TabIndex = 4;
            this.cbRM4SCC.Text = "Royal Mail 4-State Customer Barcode";
            this.cbRM4SCC.UseVisualStyleBackColor = true;
            this.cbRM4SCC.CheckedChanged += new System.EventHandler(this.rbPostalCodeMode_CheckedChanged);
            // 
            // cbAustralianPost
            // 
            this.cbAustralianPost.AutoSize = true;
            this.cbAustralianPost.Checked = true;
            this.cbAustralianPost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAustralianPost.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbAustralianPost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbAustralianPost.Location = new System.Drawing.Point(10, 38);
            this.cbAustralianPost.Margin = new System.Windows.Forms.Padding(0);
            this.cbAustralianPost.Name = "cbAustralianPost";
            this.cbAustralianPost.Size = new System.Drawing.Size(122, 21);
            this.cbAustralianPost.TabIndex = 2;
            this.cbAustralianPost.Text = "Australian Post";
            this.cbAustralianPost.UseVisualStyleBackColor = true;
            this.cbAustralianPost.CheckedChanged += new System.EventHandler(this.rbPostalCodeMode_CheckedChanged);
            // 
            // cbUSPSIntelligentMail
            // 
            this.cbUSPSIntelligentMail.AutoSize = true;
            this.cbUSPSIntelligentMail.Checked = true;
            this.cbUSPSIntelligentMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUSPSIntelligentMail.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbUSPSIntelligentMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbUSPSIntelligentMail.Location = new System.Drawing.Point(10, 10);
            this.cbUSPSIntelligentMail.Margin = new System.Windows.Forms.Padding(0);
            this.cbUSPSIntelligentMail.Name = "cbUSPSIntelligentMail";
            this.cbUSPSIntelligentMail.Size = new System.Drawing.Size(157, 21);
            this.cbUSPSIntelligentMail.TabIndex = 2;
            this.cbUSPSIntelligentMail.Text = "USPS Intelligent Mail";
            this.cbUSPSIntelligentMail.UseVisualStyleBackColor = true;
            this.cbUSPSIntelligentMail.CheckedChanged += new System.EventHandler(this.rbPostalCodeMode_CheckedChanged);
            // 
            // panelPDFDetail
            // 
            this.panelPDFDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panelPDFDetail.Controls.Add(this.cbMicroPDF);
            this.panelPDFDetail.Controls.Add(this.cbPDF417);
            this.panelPDFDetail.Location = new System.Drawing.Point(0, 173);
            this.panelPDFDetail.Name = "panelPDFDetail";
            this.panelPDFDetail.Size = new System.Drawing.Size(305, 76);
            this.panelPDFDetail.TabIndex = 8;
            this.panelPDFDetail.Visible = false;
            // 
            // cbMicroPDF
            // 
            this.cbMicroPDF.AutoSize = true;
            this.cbMicroPDF.Checked = true;
            this.cbMicroPDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMicroPDF.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbMicroPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbMicroPDF.Location = new System.Drawing.Point(10, 38);
            this.cbMicroPDF.Margin = new System.Windows.Forms.Padding(0);
            this.cbMicroPDF.Name = "cbMicroPDF";
            this.cbMicroPDF.Size = new System.Drawing.Size(116, 21);
            this.cbMicroPDF.TabIndex = 2;
            this.cbMicroPDF.Text = "Micro PDF417";
            this.cbMicroPDF.UseVisualStyleBackColor = true;
            this.cbMicroPDF.CheckedChanged += new System.EventHandler(this.rbAllPDFMode_CheckedChanged);
            // 
            // cbPDF417
            // 
            this.cbPDF417.AutoSize = true;
            this.cbPDF417.Checked = true;
            this.cbPDF417.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPDF417.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbPDF417.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbPDF417.Location = new System.Drawing.Point(10, 10);
            this.cbPDF417.Margin = new System.Windows.Forms.Padding(0);
            this.cbPDF417.Name = "cbPDF417";
            this.cbPDF417.Size = new System.Drawing.Size(78, 21);
            this.cbPDF417.TabIndex = 2;
            this.cbPDF417.Text = "PDF417";
            this.cbPDF417.UseVisualStyleBackColor = true;
            this.cbPDF417.CheckedChanged += new System.EventHandler(this.rbAllPDFMode_CheckedChanged);
            // 
            // panelQRDetail
            // 
            this.panelQRDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panelQRDetail.Controls.Add(this.cbMicroQR);
            this.panelQRDetail.Controls.Add(this.cbQRcode);
            this.panelQRDetail.Location = new System.Drawing.Point(0, 141);
            this.panelQRDetail.Name = "panelQRDetail";
            this.panelQRDetail.Size = new System.Drawing.Size(305, 76);
            this.panelQRDetail.TabIndex = 8;
            this.panelQRDetail.Visible = false;
            // 
            // cbMicroQR
            // 
            this.cbMicroQR.AutoSize = true;
            this.cbMicroQR.Checked = true;
            this.cbMicroQR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMicroQR.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbMicroQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbMicroQR.Location = new System.Drawing.Point(10, 38);
            this.cbMicroQR.Margin = new System.Windows.Forms.Padding(0);
            this.cbMicroQR.Name = "cbMicroQR";
            this.cbMicroQR.Size = new System.Drawing.Size(86, 21);
            this.cbMicroQR.TabIndex = 2;
            this.cbMicroQR.Text = "Micro QR";
            this.cbMicroQR.UseVisualStyleBackColor = true;
            this.cbMicroQR.CheckedChanged += new System.EventHandler(this.rbAllQRMode_CheckedChanged);
            // 
            // cbQRcode
            // 
            this.cbQRcode.AutoSize = true;
            this.cbQRcode.Checked = true;
            this.cbQRcode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbQRcode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbQRcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbQRcode.Location = new System.Drawing.Point(10, 10);
            this.cbQRcode.Name = "cbQRcode";
            this.cbQRcode.Size = new System.Drawing.Size(85, 21);
            this.cbQRcode.TabIndex = 2;
            this.cbQRcode.Text = "QR Code";
            this.cbQRcode.UseVisualStyleBackColor = true;
            this.cbQRcode.CheckedChanged += new System.EventHandler(this.rbAllQRMode_CheckedChanged);
            // 
            // panelFormat
            // 
            this.panelFormat.Controls.Add(this.cbPostalCode);
            this.panelFormat.Controls.Add(this.btnExportSettings);
            this.panelFormat.Controls.Add(this.btnShowAllOneD);
            this.panelFormat.Controls.Add(this.btnShowAllDatabar);
            this.panelFormat.Controls.Add(this.btnShowAllPDF);
            this.panelFormat.Controls.Add(this.btnShowAllQR);
            this.panelFormat.Controls.Add(this.btnShowAllPostalCode);
            this.panelFormat.Controls.Add(this.lableFormat);
            this.panelFormat.Controls.Add(this.cbOneD);
            this.panelFormat.Controls.Add(this.cbAllPDF417);
            this.panelFormat.Controls.Add(this.cbAllQRCode);
            this.panelFormat.Controls.Add(this.cbDATABAR);
            this.panelFormat.Controls.Add(this.cbDataMatrix);
            this.panelFormat.Controls.Add(this.cbMaxicode);
            this.panelFormat.Controls.Add(this.cbAZTEC);
            this.panelFormat.Controls.Add(this.cbPATCHCODE);
            this.panelFormat.Controls.Add(this.cbGS1Composite);
            this.panelFormat.Controls.Add(this.cbDOTCODE);
            this.panelFormat.Location = new System.Drawing.Point(0, 44);
            this.panelFormat.Name = "panelFormat";
            this.panelFormat.Size = new System.Drawing.Size(310, 243);
            this.panelFormat.TabIndex = 1;
            // 
            // cbPostalCode
            // 
            this.cbPostalCode.AutoSize = true;
            this.cbPostalCode.Checked = true;
            this.cbPostalCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPostalCode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbPostalCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbPostalCode.Location = new System.Drawing.Point(140, 72);
            this.cbPostalCode.Name = "cbPostalCode";
            this.cbPostalCode.Size = new System.Drawing.Size(103, 21);
            this.cbPostalCode.TabIndex = 9;
            this.cbPostalCode.Text = "Postal Code";
            this.cbPostalCode.UseVisualStyleBackColor = true;
            this.cbPostalCode.CheckStateChanged += new System.EventHandler(this.cbPostalCode_CheckStateChanged);
            // 
            // btnExportSettings
            // 
            this.btnExportSettings.FlatAppearance.BorderSize = 0;
            this.btnExportSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSettings.Image = global::Barcode_Reader_Demo.Properties.Resources.icon_output;
            this.btnExportSettings.Location = new System.Drawing.Point(250, 9);
            this.btnExportSettings.Name = "btnExportSettings";
            this.btnExportSettings.Size = new System.Drawing.Size(30, 23);
            this.btnExportSettings.TabIndex = 8;
            this.btnExportSettings.UseVisualStyleBackColor = true;
            this.btnExportSettings.Visible = false;
            this.btnExportSettings.Click += new System.EventHandler(this.btnExportSettings_Click);
            this.btnExportSettings.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnExportSettings_DragEnter);
            this.btnExportSettings.DragLeave += new System.EventHandler(this.btnExportSettings_DragLeave);
            // 
            // btnShowAllOneD
            // 
            this.btnShowAllOneD.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAllOneD.FlatAppearance.BorderSize = 0;
            this.btnShowAllOneD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllOneD.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnShowAllOneD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(168)))), ((int)(((byte)(225)))));
            this.btnShowAllOneD.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_down;
            this.btnShowAllOneD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAllOneD.Location = new System.Drawing.Point(58, 40);
            this.btnShowAllOneD.Name = "btnShowAllOneD";
            this.btnShowAllOneD.Size = new System.Drawing.Size(20, 24);
            this.btnShowAllOneD.TabIndex = 7;
            this.btnShowAllOneD.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnShowAllOneD.UseVisualStyleBackColor = false;
            this.btnShowAllOneD.Click += new System.EventHandler(this.btnShowAllOneD_Click);
            // 
            // btnShowAllDatabar
            // 
            this.btnShowAllDatabar.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAllDatabar.FlatAppearance.BorderSize = 0;
            this.btnShowAllDatabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllDatabar.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnShowAllDatabar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(168)))), ((int)(((byte)(225)))));
            this.btnShowAllDatabar.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_down;
            this.btnShowAllDatabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAllDatabar.Location = new System.Drawing.Point(260, 40);
            this.btnShowAllDatabar.Name = "btnShowAllDatabar";
            this.btnShowAllDatabar.Size = new System.Drawing.Size(20, 24);
            this.btnShowAllDatabar.TabIndex = 7;
            this.btnShowAllDatabar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnShowAllDatabar.UseVisualStyleBackColor = false;
            this.btnShowAllDatabar.Click += new System.EventHandler(this.btnShowAllDatabar_Click);
            // 
            // btnShowAllPDF
            // 
            this.btnShowAllPDF.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAllPDF.FlatAppearance.BorderSize = 0;
            this.btnShowAllPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllPDF.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnShowAllPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(168)))), ((int)(((byte)(225)))));
            this.btnShowAllPDF.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_down;
            this.btnShowAllPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAllPDF.Location = new System.Drawing.Point(100, 104);
            this.btnShowAllPDF.Name = "btnShowAllPDF";
            this.btnShowAllPDF.Size = new System.Drawing.Size(20, 24);
            this.btnShowAllPDF.TabIndex = 7;
            this.btnShowAllPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnShowAllPDF.UseVisualStyleBackColor = false;
            this.btnShowAllPDF.Click += new System.EventHandler(this.btnShowAllPDF_Click);
            // 
            // btnShowAllQR
            // 
            this.btnShowAllQR.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAllQR.FlatAppearance.BorderSize = 0;
            this.btnShowAllQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllQR.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnShowAllQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(168)))), ((int)(((byte)(225)))));
            this.btnShowAllQR.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_down;
            this.btnShowAllQR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAllQR.Location = new System.Drawing.Point(100, 72);
            this.btnShowAllQR.Name = "btnShowAllQR";
            this.btnShowAllQR.Size = new System.Drawing.Size(20, 24);
            this.btnShowAllQR.TabIndex = 7;
            this.btnShowAllQR.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnShowAllQR.UseVisualStyleBackColor = false;
            this.btnShowAllQR.Click += new System.EventHandler(this.btnShowAllQR_Click);
            // 
            // btnShowAllPostalCode
            // 
            this.btnShowAllPostalCode.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAllPostalCode.FlatAppearance.BorderSize = 0;
            this.btnShowAllPostalCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllPostalCode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnShowAllPostalCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(168)))), ((int)(((byte)(225)))));
            this.btnShowAllPostalCode.Image = global::Barcode_Reader_Demo.Properties.Resources.arrow_down;
            this.btnShowAllPostalCode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAllPostalCode.Location = new System.Drawing.Point(260, 72);
            this.btnShowAllPostalCode.Name = "btnShowAllPostalCode";
            this.btnShowAllPostalCode.Size = new System.Drawing.Size(20, 24);
            this.btnShowAllPostalCode.TabIndex = 7;
            this.btnShowAllPostalCode.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnShowAllPostalCode.UseVisualStyleBackColor = false;
            this.btnShowAllPostalCode.Click += new System.EventHandler(this.btnShowAllPostalCode_Click);
            // 
            // lableFormat
            // 
            this.lableFormat.AutoSize = true;
            this.lableFormat.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lableFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lableFormat.Location = new System.Drawing.Point(18, 11);
            this.lableFormat.Margin = new System.Windows.Forms.Padding(0);
            this.lableFormat.Name = "lableFormat";
            this.lableFormat.Size = new System.Drawing.Size(109, 17);
            this.lableFormat.TabIndex = 0;
            this.lableFormat.Text = "Barcode Format";
            // 
            // cbOneD
            // 
            this.cbOneD.AutoSize = true;
            this.cbOneD.Checked = true;
            this.cbOneD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOneD.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbOneD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbOneD.Location = new System.Drawing.Point(17, 40);
            this.cbOneD.Name = "cbOneD";
            this.cbOneD.Size = new System.Drawing.Size(45, 21);
            this.cbOneD.TabIndex = 1;
            this.cbOneD.Text = "1D";
            this.cbOneD.UseVisualStyleBackColor = true;
            this.cbOneD.CheckStateChanged += new System.EventHandler(this.cbOneD_CheckStateChanged);
            // 
            // cbAllPDF417
            // 
            this.cbAllPDF417.AutoSize = true;
            this.cbAllPDF417.Checked = true;
            this.cbAllPDF417.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllPDF417.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbAllPDF417.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbAllPDF417.Location = new System.Drawing.Point(17, 104);
            this.cbAllPDF417.Name = "cbAllPDF417";
            this.cbAllPDF417.Size = new System.Drawing.Size(78, 21);
            this.cbAllPDF417.TabIndex = 2;
            this.cbAllPDF417.Text = "PDF417";
            this.cbAllPDF417.UseVisualStyleBackColor = true;
            this.cbAllPDF417.CheckedChanged += new System.EventHandler(this.cbAllPDF417_CheckStateChanged);
            // 
            // cbAllQRCode
            // 
            this.cbAllQRCode.AutoSize = true;
            this.cbAllQRCode.Checked = true;
            this.cbAllQRCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllQRCode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbAllQRCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbAllQRCode.Location = new System.Drawing.Point(17, 72);
            this.cbAllQRCode.Name = "cbAllQRCode";
            this.cbAllQRCode.Size = new System.Drawing.Size(85, 21);
            this.cbAllQRCode.TabIndex = 2;
            this.cbAllQRCode.Text = "QR Code";
            this.cbAllQRCode.UseVisualStyleBackColor = true;
            this.cbAllQRCode.CheckedChanged += new System.EventHandler(this.cbAllQRCode_CheckStateChanged);
            // 
            // cbDATABAR
            // 
            this.cbDATABAR.AutoSize = true;
            this.cbDATABAR.Checked = true;
            this.cbDATABAR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDATABAR.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDATABAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDATABAR.Location = new System.Drawing.Point(140, 40);
            this.cbDATABAR.Name = "cbDATABAR";
            this.cbDATABAR.Size = new System.Drawing.Size(124, 21);
            this.cbDATABAR.TabIndex = 0;
            this.cbDATABAR.Text = "GS1 Databar";
            this.cbDATABAR.UseVisualStyleBackColor = true;
            this.cbDATABAR.CheckedChanged += new System.EventHandler(this.cbDatabar_CheckStateChanged);
            // 
            // cbDataMatrix
            // 
            this.cbDataMatrix.AutoSize = true;
            this.cbDataMatrix.Checked = true;
            this.cbDataMatrix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDataMatrix.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDataMatrix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDataMatrix.Location = new System.Drawing.Point(140, 104);
            this.cbDataMatrix.Name = "cbDataMatrix";
            this.cbDataMatrix.Size = new System.Drawing.Size(94, 21);
            this.cbDataMatrix.TabIndex = 2;
            this.cbDataMatrix.Text = "DataMatrix";
            this.cbDataMatrix.UseVisualStyleBackColor = true;
            this.cbDataMatrix.CheckedChanged += new System.EventHandler(this.cbBarcodeFormat_CheckedChanged);
            // 
            // cbMaxicode
            // 
            this.cbMaxicode.AutoSize = true;
            this.cbMaxicode.Checked = true;
            this.cbMaxicode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMaxicode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbMaxicode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbMaxicode.Location = new System.Drawing.Point(140, 136);
            this.cbMaxicode.Margin = new System.Windows.Forms.Padding(0);
            this.cbMaxicode.Name = "cbMaxicode";
            this.cbMaxicode.Size = new System.Drawing.Size(88, 21);
            this.cbMaxicode.TabIndex = 2;
            this.cbMaxicode.Text = "MaxiCode";
            this.cbMaxicode.UseVisualStyleBackColor = true;
            this.cbMaxicode.CheckedChanged += new System.EventHandler(this.cbBarcodeFormat_CheckedChanged);
            // 
            // cbAZTEC
            // 
            this.cbAZTEC.AutoSize = true;
            this.cbAZTEC.Checked = true;
            this.cbAZTEC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAZTEC.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbAZTEC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbAZTEC.Location = new System.Drawing.Point(17, 136);
            this.cbAZTEC.Name = "cbAZTEC";
            this.cbAZTEC.Size = new System.Drawing.Size(72, 21);
            this.cbAZTEC.TabIndex = 2;
            this.cbAZTEC.Text = "AZTEC";
            this.cbAZTEC.UseVisualStyleBackColor = true;
            this.cbAZTEC.CheckedChanged += new System.EventHandler(this.cbBarcodeFormat_CheckedChanged);
            // 
            // cbPATCHCODE
            // 
            this.cbPATCHCODE.AutoSize = true;
            this.cbPATCHCODE.Checked = true;
            this.cbPATCHCODE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPATCHCODE.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbPATCHCODE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbPATCHCODE.Location = new System.Drawing.Point(17, 168);
            this.cbPATCHCODE.Name = "cbPATCHCODE";
            this.cbPATCHCODE.Size = new System.Drawing.Size(94, 21);
            this.cbPATCHCODE.TabIndex = 0;
            this.cbPATCHCODE.Text = "Patchcode";
            this.cbPATCHCODE.UseVisualStyleBackColor = true;
            this.cbPATCHCODE.CheckedChanged += new System.EventHandler(this.cbBarcodeFormat_CheckedChanged);
            // 
            // cbGS1Composite
            // 
            this.cbGS1Composite.AutoSize = true;
            this.cbGS1Composite.Checked = true;
            this.cbGS1Composite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGS1Composite.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbGS1Composite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbGS1Composite.Location = new System.Drawing.Point(139, 168);
            this.cbGS1Composite.Margin = new System.Windows.Forms.Padding(0);
            this.cbGS1Composite.Name = "cbGS1Composite";
            this.cbGS1Composite.Size = new System.Drawing.Size(125, 21);
            this.cbGS1Composite.TabIndex = 2;
            this.cbGS1Composite.Text = "GS1 Composite";
            this.cbGS1Composite.UseVisualStyleBackColor = true;
            this.cbGS1Composite.CheckedChanged += new System.EventHandler(this.cbBarcodeFormat_CheckedChanged);
            // 
            // cbDOTCODE
            // 
            this.cbDOTCODE.AutoSize = true;
            this.cbDOTCODE.Checked = true;
            this.cbDOTCODE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDOTCODE.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDOTCODE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDOTCODE.Location = new System.Drawing.Point(17, 200);
            this.cbDOTCODE.Name = "cbDOTCODE";
            this.cbDOTCODE.Size = new System.Drawing.Size(94, 21);
            this.cbDOTCODE.TabIndex = 0;
            this.cbDOTCODE.Text = "DotCode";
            this.cbDOTCODE.UseVisualStyleBackColor = true;
            this.cbDOTCODE.CheckedChanged += new System.EventHandler(this.cbBarcodeFormat_CheckedChanged);
            // 
            // panelOneDetail
            // 
            this.panelOneDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panelOneDetail.Controls.Add(this.cbINDUSTRIAL25);
            this.panelOneDetail.Controls.Add(this.cbUPCE);
            this.panelOneDetail.Controls.Add(this.cbUPCA);
            this.panelOneDetail.Controls.Add(this.cbEAN8);
            this.panelOneDetail.Controls.Add(this.cbCODABAR);
            this.panelOneDetail.Controls.Add(this.cbITF);
            this.panelOneDetail.Controls.Add(this.cbEAN13);
            this.panelOneDetail.Controls.Add(this.cbCODE93);
            this.panelOneDetail.Controls.Add(this.cbCODE128);
            this.panelOneDetail.Controls.Add(this.cbCOD39);
            this.panelOneDetail.Controls.Add(this.cbMSICODE);
            this.panelOneDetail.Location = new System.Drawing.Point(0, 109);
            this.panelOneDetail.Name = "panelOneDetail";
            this.panelOneDetail.Size = new System.Drawing.Size(305, 188);
            this.panelOneDetail.TabIndex = 8;
            this.panelOneDetail.Visible = false;
            // 
            // cbINDUSTRIAL25
            // 
            this.cbINDUSTRIAL25.AutoSize = true;
            this.cbINDUSTRIAL25.Checked = true;
            this.cbINDUSTRIAL25.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbINDUSTRIAL25.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbINDUSTRIAL25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbINDUSTRIAL25.Location = new System.Drawing.Point(140, 122);
            this.cbINDUSTRIAL25.Name = "cbINDUSTRIAL25";
            this.cbINDUSTRIAL25.Size = new System.Drawing.Size(132, 21);
            this.cbINDUSTRIAL25.TabIndex = 0;
            this.cbINDUSTRIAL25.Text = "INDUSTRIAL_25";
            this.cbINDUSTRIAL25.UseVisualStyleBackColor = true;
            this.cbINDUSTRIAL25.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbUPCE
            // 
            this.cbUPCE.AutoSize = true;
            this.cbUPCE.Checked = true;
            this.cbUPCE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUPCE.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbUPCE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbUPCE.Location = new System.Drawing.Point(10, 122);
            this.cbUPCE.Name = "cbUPCE";
            this.cbUPCE.Size = new System.Drawing.Size(72, 21);
            this.cbUPCE.TabIndex = 0;
            this.cbUPCE.Text = "UPC_E";
            this.cbUPCE.UseVisualStyleBackColor = true;
            this.cbUPCE.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbUPCA
            // 
            this.cbUPCA.AutoSize = true;
            this.cbUPCA.Checked = true;
            this.cbUPCA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUPCA.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbUPCA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbUPCA.Location = new System.Drawing.Point(140, 94);
            this.cbUPCA.Name = "cbUPCA";
            this.cbUPCA.Size = new System.Drawing.Size(72, 21);
            this.cbUPCA.TabIndex = 0;
            this.cbUPCA.Text = "UPC_A";
            this.cbUPCA.UseVisualStyleBackColor = true;
            this.cbUPCA.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbEAN8
            // 
            this.cbEAN8.AutoSize = true;
            this.cbEAN8.Checked = true;
            this.cbEAN8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEAN8.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbEAN8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbEAN8.Location = new System.Drawing.Point(10, 94);
            this.cbEAN8.Name = "cbEAN8";
            this.cbEAN8.Size = new System.Drawing.Size(71, 21);
            this.cbEAN8.TabIndex = 0;
            this.cbEAN8.Text = "EAN_8";
            this.cbEAN8.UseVisualStyleBackColor = true;
            this.cbEAN8.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbCODABAR
            // 
            this.cbCODABAR.AutoSize = true;
            this.cbCODABAR.Checked = true;
            this.cbCODABAR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCODABAR.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbCODABAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbCODABAR.Location = new System.Drawing.Point(140, 38);
            this.cbCODABAR.Name = "cbCODABAR";
            this.cbCODABAR.Size = new System.Drawing.Size(94, 21);
            this.cbCODABAR.TabIndex = 0;
            this.cbCODABAR.Text = "CODABAR";
            this.cbCODABAR.UseVisualStyleBackColor = true;
            this.cbCODABAR.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbITF
            // 
            this.cbITF.AutoSize = true;
            this.cbITF.Checked = true;
            this.cbITF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbITF.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbITF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbITF.Location = new System.Drawing.Point(10, 66);
            this.cbITF.Name = "cbITF";
            this.cbITF.Size = new System.Drawing.Size(47, 21);
            this.cbITF.TabIndex = 0;
            this.cbITF.Text = "ITF";
            this.cbITF.UseVisualStyleBackColor = true;
            this.cbITF.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbEAN13
            // 
            this.cbEAN13.AutoSize = true;
            this.cbEAN13.Checked = true;
            this.cbEAN13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEAN13.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbEAN13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbEAN13.Location = new System.Drawing.Point(140, 66);
            this.cbEAN13.Name = "cbEAN13";
            this.cbEAN13.Size = new System.Drawing.Size(79, 21);
            this.cbEAN13.TabIndex = 0;
            this.cbEAN13.Text = "EAN_13";
            this.cbEAN13.UseVisualStyleBackColor = true;
            this.cbEAN13.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbCODE93
            // 
            this.cbCODE93.AutoSize = true;
            this.cbCODE93.Checked = true;
            this.cbCODE93.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCODE93.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbCODE93.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbCODE93.Location = new System.Drawing.Point(140, 10);
            this.cbCODE93.Name = "cbCODE93";
            this.cbCODE93.Size = new System.Drawing.Size(90, 21);
            this.cbCODE93.TabIndex = 0;
            this.cbCODE93.Text = "CODE_93";
            this.cbCODE93.UseVisualStyleBackColor = true;
            this.cbCODE93.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbCODE128
            // 
            this.cbCODE128.AutoSize = true;
            this.cbCODE128.Checked = true;
            this.cbCODE128.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCODE128.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbCODE128.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbCODE128.Location = new System.Drawing.Point(10, 38);
            this.cbCODE128.Name = "cbCODE128";
            this.cbCODE128.Size = new System.Drawing.Size(98, 21);
            this.cbCODE128.TabIndex = 0;
            this.cbCODE128.Text = "CODE_128";
            this.cbCODE128.UseVisualStyleBackColor = true;
            this.cbCODE128.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbCOD39
            // 
            this.cbCOD39.AutoSize = true;
            this.cbCOD39.Checked = true;
            this.cbCOD39.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCOD39.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbCOD39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbCOD39.Location = new System.Drawing.Point(10, 10);
            this.cbCOD39.Name = "cbCOD39";
            this.cbCOD39.Size = new System.Drawing.Size(90, 21);
            this.cbCOD39.TabIndex = 0;
            this.cbCOD39.Text = "CODE_39";
            this.cbCOD39.UseVisualStyleBackColor = true;
            this.cbCOD39.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // cbMSICODE
            // 
            this.cbMSICODE.AutoSize = true;
            this.cbMSICODE.Checked = true;
            this.cbMSICODE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMSICODE.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbMSICODE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbMSICODE.Location = new System.Drawing.Point(10, 150);
            this.cbMSICODE.Name = "cbMSICODE";
            this.cbMSICODE.Size = new System.Drawing.Size(90, 21);
            this.cbMSICODE.TabIndex = 0;
            this.cbMSICODE.Text = "MSI CODE";
            this.cbMSICODE.UseVisualStyleBackColor = true;
            this.cbMSICODE.CheckedChanged += new System.EventHandler(this.rbOneMode_CheckedChanged);
            // 
            // panelDatabarDetail
            // 
            this.panelDatabarDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panelDatabarDetail.Controls.Add(this.cbDatabarOmnidirectional);
            this.panelDatabarDetail.Controls.Add(this.cbDatabarExpanded);
            this.panelDatabarDetail.Controls.Add(this.cbDatabarExpanedStacked);
            this.panelDatabarDetail.Controls.Add(this.cbDatabarLimited);
            this.panelDatabarDetail.Controls.Add(this.cbDatabarStacked);
            this.panelDatabarDetail.Controls.Add(this.cbDatabarStackedOmnidirectional);
            this.panelDatabarDetail.Controls.Add(this.cbDatabarTruncated);
            this.panelDatabarDetail.Location = new System.Drawing.Point(0, 109);
            this.panelDatabarDetail.Name = "panelDatabarDetail";
            this.panelDatabarDetail.Size = new System.Drawing.Size(305, 224);
            this.panelDatabarDetail.TabIndex = 8;
            this.panelDatabarDetail.Visible = false;
            // 
            // cbDatabarOmnidirectional
            // 
            this.cbDatabarOmnidirectional.AutoSize = true;
            this.cbDatabarOmnidirectional.Checked = true;
            this.cbDatabarOmnidirectional.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatabarOmnidirectional.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDatabarOmnidirectional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDatabarOmnidirectional.Location = new System.Drawing.Point(10, 10);
            this.cbDatabarOmnidirectional.Name = "cbDatabarOmnidirectional";
            this.cbDatabarOmnidirectional.Size = new System.Drawing.Size(212, 21);
            this.cbDatabarOmnidirectional.TabIndex = 0;
            this.cbDatabarOmnidirectional.Text = "GS1 Databar Omnidirectional";
            this.cbDatabarOmnidirectional.UseVisualStyleBackColor = true;
            this.cbDatabarOmnidirectional.CheckedChanged += new System.EventHandler(this.rbDatabarMode_CheckedChanged);
            // 
            // cbDatabarExpanded
            // 
            this.cbDatabarExpanded.AutoSize = true;
            this.cbDatabarExpanded.Checked = true;
            this.cbDatabarExpanded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatabarExpanded.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDatabarExpanded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDatabarExpanded.Location = new System.Drawing.Point(10, 38);
            this.cbDatabarExpanded.Name = "cbDatabarExpanded";
            this.cbDatabarExpanded.Size = new System.Drawing.Size(177, 21);
            this.cbDatabarExpanded.TabIndex = 0;
            this.cbDatabarExpanded.Text = "GS1 Databar Expanded";
            this.cbDatabarExpanded.UseVisualStyleBackColor = true;
            this.cbDatabarExpanded.CheckedChanged += new System.EventHandler(this.rbDatabarMode_CheckedChanged);
            // 
            // cbDatabarExpanedStacked
            // 
            this.cbDatabarExpanedStacked.AutoSize = true;
            this.cbDatabarExpanedStacked.Checked = true;
            this.cbDatabarExpanedStacked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatabarExpanedStacked.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDatabarExpanedStacked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDatabarExpanedStacked.Location = new System.Drawing.Point(10, 66);
            this.cbDatabarExpanedStacked.Name = "cbDatabarExpanedStacked";
            this.cbDatabarExpanedStacked.Size = new System.Drawing.Size(224, 21);
            this.cbDatabarExpanedStacked.TabIndex = 0;
            this.cbDatabarExpanedStacked.Text = "GS1 Databar Expaned Stacked";
            this.cbDatabarExpanedStacked.UseVisualStyleBackColor = true;
            this.cbDatabarExpanedStacked.CheckedChanged += new System.EventHandler(this.rbDatabarMode_CheckedChanged);
            // 
            // cbDatabarLimited
            // 
            this.cbDatabarLimited.AutoSize = true;
            this.cbDatabarLimited.Checked = true;
            this.cbDatabarLimited.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatabarLimited.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDatabarLimited.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDatabarLimited.Location = new System.Drawing.Point(10, 94);
            this.cbDatabarLimited.Name = "cbDatabarLimited";
            this.cbDatabarLimited.Size = new System.Drawing.Size(159, 21);
            this.cbDatabarLimited.TabIndex = 0;
            this.cbDatabarLimited.Text = "GS1 Databar Limited";
            this.cbDatabarLimited.UseVisualStyleBackColor = true;
            this.cbDatabarLimited.CheckedChanged += new System.EventHandler(this.rbDatabarMode_CheckedChanged);
            // 
            // cbDatabarStacked
            // 
            this.cbDatabarStacked.AutoSize = true;
            this.cbDatabarStacked.Checked = true;
            this.cbDatabarStacked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatabarStacked.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDatabarStacked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDatabarStacked.Location = new System.Drawing.Point(10, 122);
            this.cbDatabarStacked.Name = "cbDatabarStacked";
            this.cbDatabarStacked.Size = new System.Drawing.Size(165, 21);
            this.cbDatabarStacked.TabIndex = 0;
            this.cbDatabarStacked.Text = "GS1 Databar Stacked";
            this.cbDatabarStacked.UseVisualStyleBackColor = true;
            this.cbDatabarStacked.CheckedChanged += new System.EventHandler(this.rbDatabarMode_CheckedChanged);
            // 
            // cbDatabarStackedOmnidirectional
            // 
            this.cbDatabarStackedOmnidirectional.AutoSize = true;
            this.cbDatabarStackedOmnidirectional.Checked = true;
            this.cbDatabarStackedOmnidirectional.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatabarStackedOmnidirectional.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDatabarStackedOmnidirectional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDatabarStackedOmnidirectional.Location = new System.Drawing.Point(10, 150);
            this.cbDatabarStackedOmnidirectional.Name = "cbDatabarStackedOmnidirectional";
            this.cbDatabarStackedOmnidirectional.Size = new System.Drawing.Size(267, 21);
            this.cbDatabarStackedOmnidirectional.TabIndex = 0;
            this.cbDatabarStackedOmnidirectional.Text = "GS1 Databar Stacked Omnidirectional";
            this.cbDatabarStackedOmnidirectional.UseVisualStyleBackColor = true;
            this.cbDatabarStackedOmnidirectional.CheckedChanged += new System.EventHandler(this.rbDatabarMode_CheckedChanged);
            // 
            // cbDatabarTruncated
            // 
            this.cbDatabarTruncated.AutoSize = true;
            this.cbDatabarTruncated.Checked = true;
            this.cbDatabarTruncated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatabarTruncated.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbDatabarTruncated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbDatabarTruncated.Location = new System.Drawing.Point(10, 178);
            this.cbDatabarTruncated.Name = "cbDatabarTruncated";
            this.cbDatabarTruncated.Size = new System.Drawing.Size(179, 21);
            this.cbDatabarTruncated.TabIndex = 0;
            this.cbDatabarTruncated.Text = "GS1 Databar Truncated";
            this.cbDatabarTruncated.UseVisualStyleBackColor = true;
            this.cbDatabarTruncated.CheckedChanged += new System.EventHandler(this.rbDatabarMode_CheckedChanged);
            // 
            // panelCustom
            // 
            this.panelCustom.BackColor = System.Drawing.Color.Transparent;
            this.panelCustom.Controls.Add(this.panelCustomTop);
            this.panelCustom.Controls.Add(this.label18);
            this.panelCustom.Controls.Add(this.panelCustomSettings);
            this.panelCustom.Location = new System.Drawing.Point(3, 3);
            this.panelCustom.Name = "panelCustom";
            this.panelCustom.Size = new System.Drawing.Size(310, 564);
            this.panelCustom.TabIndex = 652;
            // 
            // panelCustomTop
            // 
            this.panelCustomTop.Controls.Add(this.panelBarcodeReaderParent);
            this.panelCustomTop.Controls.Add(this.lbCustomPanelClose);
            this.panelCustomTop.Location = new System.Drawing.Point(0, 0);
            this.panelCustomTop.Name = "panelCustomTop";
            this.panelCustomTop.Size = new System.Drawing.Size(310, 55);
            this.panelCustomTop.TabIndex = 6;
            // 
            // panelBarcodeReaderParent
            // 
            this.panelBarcodeReaderParent.Location = new System.Drawing.Point(19, 11);
            this.panelBarcodeReaderParent.Name = "panelBarcodeReaderParent";
            this.panelBarcodeReaderParent.Size = new System.Drawing.Size(153, 34);
            this.panelBarcodeReaderParent.TabIndex = 6;
            // 
            // lbCustomPanelClose
            // 
            this.lbCustomPanelClose.Image = global::Barcode_Reader_Demo.Properties.Resources.icon_closed;
            this.lbCustomPanelClose.Location = new System.Drawing.Point(277, 22);
            this.lbCustomPanelClose.Name = "lbCustomPanelClose";
            this.lbCustomPanelClose.Size = new System.Drawing.Size(14, 15);
            this.lbCustomPanelClose.TabIndex = 5;
            this.lbCustomPanelClose.Click += new System.EventHandler(this.pbCloseCustomPanel_Click);
            this.lbCustomPanelClose.MouseLeave += new System.EventHandler(this.lbCustomPanelClose_MouseLeave);
            this.lbCustomPanelClose.MouseHover += new System.EventHandler(this.lbCustomPanelClose_MouseHover);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(1, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(280, 1);
            this.label18.TabIndex = 4;
            // 
            // panelCustomSettings
            // 
            this.panelCustomSettings.AutoScroll = true;
            this.panelCustomSettings.Controls.Add(this.panelFormatParent);
            this.panelCustomSettings.Controls.Add(this.label17);
            this.panelCustomSettings.Controls.Add(this.panelSettings);
            this.panelCustomSettings.Location = new System.Drawing.Point(0, 56);
            this.panelCustomSettings.Name = "panelCustomSettings";
            this.panelCustomSettings.Size = new System.Drawing.Size(305, 374);
            this.panelCustomSettings.TabIndex = 0;
            // 
            // panelFormatParent
            // 
            this.panelFormatParent.Location = new System.Drawing.Point(0, 0);
            this.panelFormatParent.Name = "panelFormatParent";
            this.panelFormatParent.Size = new System.Drawing.Size(285, 244);
            this.panelFormatParent.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label17.Location = new System.Drawing.Point(0, 245);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(280, 1);
            this.label17.TabIndex = 2;
            // 
            // panelSettings
            // 
            this.panelSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSettings.Controls.Add(this.label12);
            this.panelSettings.Controls.Add(this.label11);
            this.panelSettings.Controls.Add(this.label10);
            this.panelSettings.Controls.Add(this.cmbTextureDetectionSensitivity);
            this.panelSettings.Controls.Add(this.cmbMinResultConfidence);
            this.panelSettings.Controls.Add(this.cmbImagePreprocessingModes);
            this.panelSettings.Controls.Add(this.cmbGrayscaleTransformationModes);
            this.panelSettings.Controls.Add(this.label9);
            this.panelSettings.Controls.Add(this.label8);
            this.panelSettings.Controls.Add(this.tbBinarizationBlockSize);
            this.panelSettings.Controls.Add(this.tbScaleDownThreshold);
            this.panelSettings.Controls.Add(this.label7);
            this.panelSettings.Controls.Add(this.cbRegionPredetectionMode);
            this.panelSettings.Controls.Add(this.cbTextFilterMode);
            this.panelSettings.Controls.Add(this.cmbLocalizationModes);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.cmbDeblurLevel);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.tbExpectedBarcodesCount);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Location = new System.Drawing.Point(0, 248);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(285, 683);
            this.panelSettings.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label12.Location = new System.Drawing.Point(17, 619);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Binarization Block Size: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label11.Location = new System.Drawing.Point(16, 547);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "Texture Detection Sensitivity: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label10.Location = new System.Drawing.Point(19, 478);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Min Result Confidence: ";
            // 
            // cmbTextureDetectionSensitivity
            // 
            this.cmbTextureDetectionSensitivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTextureDetectionSensitivity.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbTextureDetectionSensitivity.FormattingEnabled = true;
            this.cmbTextureDetectionSensitivity.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbTextureDetectionSensitivity.Location = new System.Drawing.Point(19, 572);
            this.cmbTextureDetectionSensitivity.Name = "cmbTextureDetectionSensitivity";
            this.cmbTextureDetectionSensitivity.Size = new System.Drawing.Size(258, 25);
            this.cmbTextureDetectionSensitivity.TabIndex = 12;
            this.cmbTextureDetectionSensitivity.SelectedIndexChanged += new System.EventHandler(this.cmbTextureDetectionSensitivity_SelectedIndexChanged);
            // 
            // cmbMinResultConfidence
            // 
            this.cmbMinResultConfidence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinResultConfidence.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbMinResultConfidence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cmbMinResultConfidence.FormattingEnabled = true;
            this.cmbMinResultConfidence.Items.AddRange(new object[] {
            "0 - No limitation",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90"});
            this.cmbMinResultConfidence.Location = new System.Drawing.Point(19, 501);
            this.cmbMinResultConfidence.Name = "cmbMinResultConfidence";
            this.cmbMinResultConfidence.Size = new System.Drawing.Size(258, 25);
            this.cmbMinResultConfidence.TabIndex = 12;
            this.cmbMinResultConfidence.SelectedIndexChanged += new System.EventHandler(this.cmbMinResultConfidence_SelectedIndexChanged);
            // 
            // cmbImagePreprocessingModes
            // 
            this.cmbImagePreprocessingModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImagePreprocessingModes.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbImagePreprocessingModes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cmbImagePreprocessingModes.FormattingEnabled = true;
            this.cmbImagePreprocessingModes.Items.AddRange(new object[] {
            "General",
            "Gray Equalization",
            "Gray Smoothing",
            "Sharpening and Smoothing"});
            this.cmbImagePreprocessingModes.Location = new System.Drawing.Point(19, 432);
            this.cmbImagePreprocessingModes.Name = "cmbImagePreprocessingModes";
            this.cmbImagePreprocessingModes.Size = new System.Drawing.Size(258, 25);
            this.cmbImagePreprocessingModes.TabIndex = 12;
            this.cmbImagePreprocessingModes.SelectedIndexChanged += new System.EventHandler(this.cmbImagePreprocessingModes_SelectedIndexChanged);
            // 
            // cmbGrayscaleTransformationModes
            // 
            this.cmbGrayscaleTransformationModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrayscaleTransformationModes.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbGrayscaleTransformationModes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cmbGrayscaleTransformationModes.FormattingEnabled = true;
            this.cmbGrayscaleTransformationModes.Items.AddRange(new object[] {
            "Original + Inverted",
            "Inverted",
            "Original"});
            this.cmbGrayscaleTransformationModes.Location = new System.Drawing.Point(19, 366);
            this.cmbGrayscaleTransformationModes.Name = "cmbGrayscaleTransformationModes";
            this.cmbGrayscaleTransformationModes.Size = new System.Drawing.Size(258, 25);
            this.cmbGrayscaleTransformationModes.TabIndex = 12;
            this.cmbGrayscaleTransformationModes.SelectedIndexChanged += new System.EventHandler(this.cmbGrayscaleTransformationModes_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label9.Location = new System.Drawing.Point(19, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Image Preprocess Modes: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(19, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(238, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "Grayscale Transformation Modes: ";
            // 
            // tbBinarizationBlockSize
            // 
            this.tbBinarizationBlockSize.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tbBinarizationBlockSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.tbBinarizationBlockSize.Location = new System.Drawing.Point(21, 645);
            this.tbBinarizationBlockSize.MaxLength = 10;
            this.tbBinarizationBlockSize.Name = "tbBinarizationBlockSize";
            this.tbBinarizationBlockSize.Size = new System.Drawing.Size(258, 23);
            this.tbBinarizationBlockSize.TabIndex = 10;
            this.tbBinarizationBlockSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberOnly_KeyPress);
            // 
            // tbScaleDownThreshold
            // 
            this.tbScaleDownThreshold.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tbScaleDownThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.tbScaleDownThreshold.Location = new System.Drawing.Point(19, 300);
            this.tbScaleDownThreshold.MaxLength = 10;
            this.tbScaleDownThreshold.Name = "tbScaleDownThreshold";
            this.tbScaleDownThreshold.Size = new System.Drawing.Size(258, 23);
            this.tbScaleDownThreshold.TabIndex = 10;
            this.tbScaleDownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberOnly_KeyPress);
            this.tbScaleDownThreshold.Leave += new System.EventHandler(this.tbScaleDownThreshold_OnLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(19, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Scale Down Threshold: ";
            // 
            // cbRegionPredetectionMode
            // 
            this.cbRegionPredetectionMode.AutoSize = true;
            this.cbRegionPredetectionMode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbRegionPredetectionMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbRegionPredetectionMode.Location = new System.Drawing.Point(19, 243);
            this.cbRegionPredetectionMode.Name = "cbRegionPredetectionMode";
            this.cbRegionPredetectionMode.Size = new System.Drawing.Size(224, 21);
            this.cbRegionPredetectionMode.TabIndex = 8;
            this.cbRegionPredetectionMode.Text = "Use Region Predetection Mode";
            this.cbRegionPredetectionMode.UseVisualStyleBackColor = true;
            // 
            // cbTextFilterMode
            // 
            this.cbTextFilterMode.AutoSize = true;
            this.cbTextFilterMode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.cbTextFilterMode.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbTextFilterMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbTextFilterMode.Location = new System.Drawing.Point(19, 210);
            this.cbTextFilterMode.Name = "cbTextFilterMode";
            this.cbTextFilterMode.Size = new System.Drawing.Size(157, 21);
            this.cbTextFilterMode.TabIndex = 7;
            this.cbTextFilterMode.Text = "Use Text Filter Mode";
            this.cbTextFilterMode.UseVisualStyleBackColor = true;
            // 
            // cmbLocalizationModes
            // 
            this.cmbLocalizationModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalizationModes.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbLocalizationModes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cmbLocalizationModes.FormattingEnabled = true;
            this.cmbLocalizationModes.Items.AddRange(new object[] {
            "Default",
            "Connected blocks",
            "Statistics",
            "Lines",
            "Scan directly",
            "Connected blocks + Scan directly"});
            this.cmbLocalizationModes.Location = new System.Drawing.Point(19, 169);
            this.cmbLocalizationModes.Name = "cmbLocalizationModes";
            this.cmbLocalizationModes.Size = new System.Drawing.Size(258, 25);
            this.cmbLocalizationModes.TabIndex = 5;
            this.cmbLocalizationModes.SelectedIndexChanged += new System.EventHandler(this.cmbLocalizationModes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(18, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Localization Mode:";
            // 
            // cmbDeblurLevel
            // 
            this.cmbDeblurLevel.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDeblurLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeblurLevel.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbDeblurLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cmbDeblurLevel.FormattingEnabled = true;
            this.cmbDeblurLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbDeblurLevel.Location = new System.Drawing.Point(19, 101);
            this.cmbDeblurLevel.Name = "cmbDeblurLevel";
            this.cmbDeblurLevel.Size = new System.Drawing.Size(258, 25);
            this.cmbDeblurLevel.TabIndex = 3;
            this.cmbDeblurLevel.SelectedIndexChanged += new System.EventHandler(this.cmbDeblurLevel_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(18, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "DeblurLevel:";
            // 
            // tbExpectedBarcodesCount
            // 
            this.tbExpectedBarcodesCount.BackColor = System.Drawing.Color.White;
            this.tbExpectedBarcodesCount.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tbExpectedBarcodesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.tbExpectedBarcodesCount.Location = new System.Drawing.Point(19, 39);
            this.tbExpectedBarcodesCount.MaxLength = 10;
            this.tbExpectedBarcodesCount.Name = "tbExpectedBarcodesCount";
            this.tbExpectedBarcodesCount.Size = new System.Drawing.Size(258, 23);
            this.tbExpectedBarcodesCount.TabIndex = 1;
            this.tbExpectedBarcodesCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberOnly_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Expected Barcodes Count:";
            // 
            // panelLoad
            // 
            this.panelLoad.BackColor = System.Drawing.Color.Transparent;
            this.panelLoad.Controls.Add(this.label24);
            this.panelLoad.Controls.Add(this.picboxLoadImage);
            this.panelLoad.Controls.Add(this.label1);
            this.panelLoad.Location = new System.Drawing.Point(0, 45);
            this.panelLoad.Margin = new System.Windows.Forms.Padding(0);
            this.panelLoad.Name = "panelLoad";
            this.panelLoad.Size = new System.Drawing.Size(310, 175);
            this.panelLoad.TabIndex = 3;
            this.panelLoad.Visible = false;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label24.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label24.Location = new System.Drawing.Point(4, 118);
            this.label24.Margin = new System.Windows.Forms.Padding(0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(310, 60);
            this.label24.TabIndex = 0;
            this.label24.Text = "Note: Dynamic .NET TWAIN license is required for loading and previewing images, acquiring images from scanners and cameras.";
            // 
            // picboxLoadImage
            // 
            this.picboxLoadImage.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxLoadImage_Leave;
            this.picboxLoadImage.InitialImage = null;
            this.picboxLoadImage.Location = new System.Drawing.Point(78, 67);
            this.picboxLoadImage.Name = "picboxLoadImage";
            this.picboxLoadImage.Size = new System.Drawing.Size(154, 36);
            this.picboxLoadImage.TabIndex = 1;
            this.picboxLoadImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Load local images or PDF files";
            // 
            // panelWebCam
            // 
            this.panelWebCam.BackColor = System.Drawing.Color.Transparent;
            this.panelWebCam.Controls.Add(this.labelWebcamNote);
            this.panelWebCam.Controls.Add(this.lblWebCamSrc);
            this.panelWebCam.Controls.Add(this.cbxWebCamSrc);
            this.panelWebCam.Controls.Add(this.lblWebCamRes);
            this.panelWebCam.Controls.Add(this.cbxWebCamRes);
            this.panelWebCam.Location = new System.Drawing.Point(0, 45);
            this.panelWebCam.Margin = new System.Windows.Forms.Padding(0);
            this.panelWebCam.Name = "panelWebCam";
            this.panelWebCam.Size = new System.Drawing.Size(300, 175);
            this.panelWebCam.TabIndex = 3;
            this.panelWebCam.Visible = false;
            // 
            // labelWebcamNote
            // 
            this.labelWebcamNote.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.labelWebcamNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelWebcamNote.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelWebcamNote.Location = new System.Drawing.Point(16, 93);
            this.labelWebcamNote.Name = "labelWebcamNote";
            this.labelWebcamNote.Size = new System.Drawing.Size(275, 80);
            this.labelWebcamNote.TabIndex = 0;
            this.labelWebcamNote.Text = "Note: Please place a barcode in front of \r\nyour webcam and then click “Read Barco" +
    "de” \r\nbutton. It will decode barcodes from camera \r\nstream directly.";
            this.labelWebcamNote.Click += new System.EventHandler(this.labelWebcamNote_Click);
            // 
            // lblWebCamSrc
            // 
            this.lblWebCamSrc.AutoSize = true;
            this.lblWebCamSrc.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblWebCamSrc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblWebCamSrc.Location = new System.Drawing.Point(20, 21);
            this.lblWebCamSrc.Name = "lblWebCamSrc";
            this.lblWebCamSrc.Size = new System.Drawing.Size(116, 17);
            this.lblWebCamSrc.TabIndex = 0;
            this.lblWebCamSrc.Text = "Webcam Source:";
            // 
            // cbxWebCamSrc
            // 
            this.cbxWebCamSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWebCamSrc.DropDownWidth = 145;
            this.cbxWebCamSrc.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbxWebCamSrc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cbxWebCamSrc.FormattingEnabled = true;
            this.cbxWebCamSrc.Location = new System.Drawing.Point(148, 18);
            this.cbxWebCamSrc.Name = "cbxWebCamSrc";
            this.cbxWebCamSrc.Size = new System.Drawing.Size(145, 25);
            this.cbxWebCamSrc.TabIndex = 13;
            // 
            // lblWebCamRes
            // 
            this.lblWebCamRes.AutoSize = true;
            this.lblWebCamRes.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblWebCamRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblWebCamRes.Location = new System.Drawing.Point(20, 60);
            this.lblWebCamRes.Name = "lblWebCamRes";
            this.lblWebCamRes.Size = new System.Drawing.Size(138, 17);
            this.lblWebCamRes.TabIndex = 12;
            this.lblWebCamRes.Text = "Webcam Resolution:";
            // 
            // cbxWebCamRes
            // 
            this.cbxWebCamRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWebCamRes.DropDownWidth = 120;
            this.cbxWebCamRes.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbxWebCamRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cbxWebCamRes.FormattingEnabled = true;
            this.cbxWebCamRes.Location = new System.Drawing.Point(173, 57);
            this.cbxWebCamRes.Name = "cbxWebCamRes";
            this.cbxWebCamRes.Size = new System.Drawing.Size(120, 25);
            this.cbxWebCamRes.TabIndex = 13;
            // 
            // panelAcquire
            // 
            this.panelAcquire.BackColor = System.Drawing.Color.Transparent;
            this.panelAcquire.Controls.Add(this.rdbtnGray);
            this.panelAcquire.Controls.Add(this.cbxResolution);
            this.panelAcquire.Controls.Add(this.picboxScan);
            this.panelAcquire.Controls.Add(this.rdbtnBW);
            this.panelAcquire.Controls.Add(this.lbResolution);
            this.panelAcquire.Controls.Add(this.rdbtnColor);
            this.panelAcquire.Controls.Add(this.lbPixelType);
            this.panelAcquire.Controls.Add(this.lbSelectSource);
            this.panelAcquire.Controls.Add(this.cbxSource);
            this.panelAcquire.Location = new System.Drawing.Point(0, 45);
            this.panelAcquire.Margin = new System.Windows.Forms.Padding(0);
            this.panelAcquire.Name = "panelAcquire";
            this.panelAcquire.Size = new System.Drawing.Size(310, 175);
            this.panelAcquire.TabIndex = 2;
            // 
            // rdbtnGray
            // 
            this.rdbtnGray.AutoSize = true;
            this.rdbtnGray.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdbtnGray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.rdbtnGray.Location = new System.Drawing.Point(170, 52);
            this.rdbtnGray.Name = "rdbtnGray";
            this.rdbtnGray.Size = new System.Drawing.Size(57, 21);
            this.rdbtnGray.TabIndex = 641;
            this.rdbtnGray.TabStop = true;
            this.rdbtnGray.Text = "Gray";
            this.rdbtnGray.UseVisualStyleBackColor = true;
            // 
            // cbxResolution
            // 
            this.cbxResolution.BackColor = System.Drawing.SystemColors.Window;
            this.cbxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolution.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbxResolution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Location = new System.Drawing.Point(104, 86);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(168, 25);
            this.cbxResolution.TabIndex = 643;
            // 
            // picboxScan
            // 
            this.picboxScan.Enabled = false;
            this.picboxScan.Location = new System.Drawing.Point(78, 126);
            this.picboxScan.Name = "picboxScan";
            this.picboxScan.Size = new System.Drawing.Size(154, 36);
            this.picboxScan.TabIndex = 85;
            this.picboxScan.TabStop = false;
            this.picboxScan.Tag = "Scan Image";
            this.picboxScan.Click += new System.EventHandler(this.picboxScan_Click);
            this.picboxScan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxScan.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxScan.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxScan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // rdbtnBW
            // 
            this.rdbtnBW.AutoSize = true;
            this.rdbtnBW.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdbtnBW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.rdbtnBW.Location = new System.Drawing.Point(101, 52);
            this.rdbtnBW.Name = "rdbtnBW";
            this.rdbtnBW.Size = new System.Drawing.Size(65, 21);
            this.rdbtnBW.TabIndex = 640;
            this.rdbtnBW.TabStop = true;
            this.rdbtnBW.Text = "B && W";
            this.rdbtnBW.UseVisualStyleBackColor = true;
            // 
            // lbResolution
            // 
            this.lbResolution.AutoSize = true;
            this.lbResolution.BackColor = System.Drawing.Color.Transparent;
            this.lbResolution.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbResolution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lbResolution.Location = new System.Drawing.Point(15, 90);
            this.lbResolution.Name = "lbResolution";
            this.lbResolution.Size = new System.Drawing.Size(83, 17);
            this.lbResolution.TabIndex = 83;
            this.lbResolution.Text = "Resolution :";
            // 
            // rdbtnColor
            // 
            this.rdbtnColor.AutoSize = true;
            this.rdbtnColor.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnColor.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdbtnColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.rdbtnColor.Location = new System.Drawing.Point(232, 52);
            this.rdbtnColor.Name = "rdbtnColor";
            this.rdbtnColor.Size = new System.Drawing.Size(59, 21);
            this.rdbtnColor.TabIndex = 642;
            this.rdbtnColor.TabStop = true;
            this.rdbtnColor.Text = "Color";
            this.rdbtnColor.UseVisualStyleBackColor = false;
            // 
            // lbPixelType
            // 
            this.lbPixelType.AutoSize = true;
            this.lbPixelType.BackColor = System.Drawing.Color.Transparent;
            this.lbPixelType.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbPixelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lbPixelType.Location = new System.Drawing.Point(15, 52);
            this.lbPixelType.Name = "lbPixelType";
            this.lbPixelType.Size = new System.Drawing.Size(81, 17);
            this.lbPixelType.TabIndex = 87;
            this.lbPixelType.Text = "Pixel Type :";
            // 
            // lbSelectSource
            // 
            this.lbSelectSource.AutoSize = true;
            this.lbSelectSource.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbSelectSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lbSelectSource.Location = new System.Drawing.Point(15, 15);
            this.lbSelectSource.Name = "lbSelectSource";
            this.lbSelectSource.Size = new System.Drawing.Size(118, 17);
            this.lbSelectSource.TabIndex = 84;
            this.lbSelectSource.Text = "Scanner Source :";
            // 
            // cbxSource
            // 
            this.cbxSource.BackColor = System.Drawing.SystemColors.Window;
            this.cbxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSource.DropDownWidth = 180;
            this.cbxSource.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cbxSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(140, 13);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(158, 25);
            this.cbxSource.TabIndex = 639;
            // 
            // lbSelectRecognitionMode
            // 
            this.lbSelectRecognitionMode.AutoSize = true;
            this.lbSelectRecognitionMode.BackColor = System.Drawing.Color.Transparent;
            this.lbSelectRecognitionMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectRecognitionMode.Location = new System.Drawing.Point(10, 50);
            this.lbSelectRecognitionMode.Name = "lbSelectRecognitionMode";
            this.lbSelectRecognitionMode.Size = new System.Drawing.Size(111, 15);
            this.lbSelectRecognitionMode.TabIndex = 84;
            this.lbSelectRecognitionMode.Text = "Recognition Mode :";
            // 
            // panelReadSetting
            // 
            this.panelReadSetting.BackColor = System.Drawing.Color.Transparent;
            this.panelReadSetting.Controls.Add(this.label6);
            this.panelReadSetting.Controls.Add(this.lbSelectRecognitionMode);
            this.panelReadSetting.Location = new System.Drawing.Point(1, 41);
            this.panelReadSetting.Margin = new System.Windows.Forms.Padding(0);
            this.panelReadSetting.Name = "panelReadSetting";
            this.panelReadSetting.Size = new System.Drawing.Size(300, 80);
            this.panelReadSetting.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Barcode format :";
            // 
            // panelReadMoreSetting
            // 
            this.panelReadMoreSetting.BackColor = System.Drawing.Color.Transparent;
            this.panelReadMoreSetting.Location = new System.Drawing.Point(1, 41);
            this.panelReadMoreSetting.Margin = new System.Windows.Forms.Padding(0);
            this.panelReadMoreSetting.Name = "panelReadMoreSetting";
            this.panelReadMoreSetting.Size = new System.Drawing.Size(300, 290);
            this.panelReadMoreSetting.TabIndex = 3;
            this.panelReadMoreSetting.Visible = false;
            // 
            // picboxFit
            // 
            this.picboxFit.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxFit_Leave;
            this.picboxFit.Location = new System.Drawing.Point(12, 60);
            this.picboxFit.Name = "picboxFit";
            this.picboxFit.Size = new System.Drawing.Size(61, 36);
            this.picboxFit.TabIndex = 88;
            this.picboxFit.TabStop = false;
            this.picboxFit.Tag = "Fit Window Size";
            this.picboxFit.Click += new System.EventHandler(this.picboxFit_Click);
            this.picboxFit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxFit.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxFit.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxFit.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxFit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxOriginalSize
            // 
            this.picboxOriginalSize.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxOriginalSize_Leave;
            this.picboxOriginalSize.Location = new System.Drawing.Point(12, 108);
            this.picboxOriginalSize.Name = "picboxOriginalSize";
            this.picboxOriginalSize.Size = new System.Drawing.Size(60, 36);
            this.picboxOriginalSize.TabIndex = 87;
            this.picboxOriginalSize.TabStop = false;
            this.picboxOriginalSize.Tag = "Original Size";
            this.picboxOriginalSize.Click += new System.EventHandler(this.picboxOriginalSize_Click);
            this.picboxOriginalSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxOriginalSize.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxOriginalSize.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxOriginalSize.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxOriginalSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // tbxResult
            // 
            this.tbxResult.BackColor = System.Drawing.Color.White;
            this.tbxResult.Location = new System.Drawing.Point(1, 26);
            this.tbxResult.Margin = new System.Windows.Forms.Padding(0);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ReadOnly = true;
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxResult.Size = new System.Drawing.Size(309, 634);
            this.tbxResult.TabIndex = 184;
            // 
            // lblCloseResult
            // 
            this.lblCloseResult.BackColor = System.Drawing.SystemColors.Control;
            this.lblCloseResult.Location = new System.Drawing.Point(290, 5);
            this.lblCloseResult.Name = "lblCloseResult";
            this.lblCloseResult.Size = new System.Drawing.Size(16, 16);
            this.lblCloseResult.TabIndex = 0;
            this.lblCloseResult.Text = "X";
            this.lblCloseResult.Click += new System.EventHandler(this.lblCloseResult_Click);
            this.lblCloseResult.MouseLeave += new System.EventHandler(this.lblCloseResult_MouseLeave);
            this.lblCloseResult.MouseHover += new System.EventHandler(this.lblCloseResult_MouseHover);
            // 
            // dsViewer
            // 
            this.dsViewer.Location = new System.Drawing.Point(86, 50);
            this.dsViewer.Name = "dsViewer";
            this.dsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer.SelectionRectAspectRatio = 0D;
            this.dsViewer.Size = new System.Drawing.Size(477, 650);
            this.dsViewer.TabIndex = 651;
            this.dsViewer.OnMouseClick += new Dynamsoft.Forms.Delegate.OnMouseClickHandler(this.dsViewer_OnMouseClick);
            // 
            // saveRuntimeSettingsFileDialog
            // 
            this.saveRuntimeSettingsFileDialog.Filter = "|*.json";
            this.saveRuntimeSettingsFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveRuntimeSettingsFileDialog_FileOk);
            // 
            // BarcodeReaderDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Barcode_Reader_Demo.Properties.Resources.main_bg;
            this.ClientSize = new System.Drawing.Size(898, 762);
            this.Controls.Add(this.dsViewer);
            this.Controls.Add(this.picboxFit);
            this.Controls.Add(this.picboxOriginalSize);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.tbxTotalImageNum);
            this.Controls.Add(this.tbxCurrentImageIndex);
            this.Controls.Add(this.lbDiv);
            this.Controls.Add(this.picboxClose);
            this.Controls.Add(this.picboxMin);
            this.Controls.Add(this.cbxViewMode);
            this.Controls.Add(this.picboxPrevious);
            this.Controls.Add(this.picboxNext);
            this.Controls.Add(this.picboxLast);
            this.Controls.Add(this.picboxFirst);
            this.Controls.Add(this.lbMoveBar);
            this.Controls.Add(this.picboxDeleteAll);
            this.Controls.Add(this.picboxDelete);
            this.Controls.Add(this.picboxZoomOut);
            this.Controls.Add(this.picboxZoomIn);
            this.Controls.Add(this.picBoxWebCam);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarcodeReaderDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamsoft Barcode Reader Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodeReaderDemo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BarcodeReaderDemo_FormClosed);
            this.Load += new System.EventHandler(this.DotNetTWAINDemo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWebCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDeleteAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxClose)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panelNormalSettings.ResumeLayout(false);
            this.panelNormalSettings.PerformLayout();
            this.panelRecognitionMode.ResumeLayout(false);
            this.panelRecognitionMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomize)).EndInit();
            this.panelReadBarcode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxReadBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxStopBarcode)).EndInit();
            this.panelPostalCodeDetail.ResumeLayout(false);
            this.panelPostalCodeDetail.PerformLayout();
            this.panelPDFDetail.ResumeLayout(false);
            this.panelPDFDetail.PerformLayout();
            this.panelQRDetail.ResumeLayout(false);
            this.panelQRDetail.PerformLayout();
            this.panelFormat.ResumeLayout(false);
            this.panelFormat.PerformLayout();
            this.panelOneDetail.ResumeLayout(false);
            this.panelOneDetail.PerformLayout();
            this.panelDatabarDetail.ResumeLayout(false);
            this.panelDatabarDetail.PerformLayout();
            this.panelCustom.ResumeLayout(false);
            this.panelCustomTop.ResumeLayout(false);
            this.panelCustomSettings.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelLoad.ResumeLayout(false);
            this.panelLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoadImage)).EndInit();
            this.panelWebCam.ResumeLayout(false);
            this.panelWebCam.PerformLayout();
            this.panelAcquire.ResumeLayout(false);
            this.panelAcquire.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScan)).EndInit();
            this.panelReadSetting.ResumeLayout(false);
            this.panelReadSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginalSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void cmbDeblurLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbDeblurLevel_SelectedIndex = this.cmbDeblurLevel.SelectedIndex;
        }

        void cmbLocalizationModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbLocalizationModes_SelectedIndex = this.cmbLocalizationModes.SelectedIndex;
        }
        void cmbGrayscaleTransformationModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbGrayscaleTransformationModes_SelectedIndex = this.cmbGrayscaleTransformationModes.SelectedIndex;
        }

        void cmbImagePreprocessingModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbImagePreprocessingModes_SelectedIndex = this.cmbImagePreprocessingModes.SelectedIndex;
        }
        void cmbMinResultConfidence_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbMinResultConfidence_SelectedIndex = this.cmbMinResultConfidence.SelectedIndex;
        }

        void cmbTextureDetectionSensitivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbTextureDetectionSensitivity_SelectedIndex = this.cmbTextureDetectionSensitivity.SelectedIndex;
        }

        void dsViewer_OnMouseClick(short sImageIndex)
        {
            if(sImageIndex>=0 && sImageIndex<mImageCore.ImageBuffer.HowManyImagesInBuffer)
            {
                CheckImageCount();
            }
        }



        #endregion


        private System.Windows.Forms.Label lbMoveBar;
        private System.Windows.Forms.PictureBox picboxZoomOut;
        private System.Windows.Forms.PictureBox picboxZoomIn;
        private System.Windows.Forms.PictureBox picboxDeleteAll;
        private System.Windows.Forms.PictureBox picboxDelete;
        private System.Windows.Forms.PictureBox picboxFirst;
        private System.Windows.Forms.PictureBox picboxLast;
        private System.Windows.Forms.PictureBox picboxNext;
        private System.Windows.Forms.PictureBox picboxPrevious;
        private System.Windows.Forms.ComboBox cbxViewMode;
        private System.Windows.Forms.PictureBox picboxMin;
        private System.Windows.Forms.PictureBox picboxClose;
        private System.Windows.Forms.Label lbDiv;
        private System.Windows.Forms.TextBox tbxCurrentImageIndex;
        private System.Windows.Forms.TextBox tbxTotalImageNum;
        //private Dynamsoft.Forms.DSViewer dsViewer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rdbtnGray;
        private System.Windows.Forms.RadioButton rdbtnBW;
        private System.Windows.Forms.Label lbPixelType;
        private System.Windows.Forms.RadioButton rdbtnColor;
        private System.Windows.Forms.ComboBox cbxSource;
       // private System.Windows.Forms.ComboBox cbxRecognitionMode;
        private System.Windows.Forms.ComboBox cbxResolution;
        private System.Windows.Forms.PictureBox picboxScan;
        
        private System.Windows.Forms.Label lbSelectSource;
        private System.Windows.Forms.Label lbSelectRecognitionMode;

        private System.Windows.Forms.Label lbResolution;
        private System.Windows.Forms.Panel panelAcquire;
        private System.Windows.Forms.Panel panelLoad;
        private System.Windows.Forms.Panel panelWebCam;
        private System.Windows.Forms.Label lblWebCamSrc;
        private System.Windows.Forms.ComboBox cbxWebCamSrc;
        private System.Windows.Forms.Label lblWebCamRes;
        private System.Windows.Forms.ComboBox cbxWebCamRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picboxLoadImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelReadSetting;
        private System.Windows.Forms.Panel panelReadMoreSetting;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Label lblCloseResult;
        private System.Windows.Forms.PictureBox picboxFit;
        private System.Windows.Forms.PictureBox picboxOriginalSize;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox picBoxWebCam;

        private Dynamsoft.Forms.DSViewer dsViewer;
        private Panel panelNormalSettings;
        private Panel panelOneDetail;
        private Panel panelDatabarDetail;
        private Panel panelPDFDetail;
        private Panel panelQRDetail;
        private CheckBox cbDatabarLimited;
        private CheckBox cbDatabarOmnidirectional;
        private CheckBox cbDatabarExpanded;
        private CheckBox cbDatabarExpanedStacked;
        private CheckBox cbDatabarStacked;
        private CheckBox cbDatabarStackedOmnidirectional;
        private CheckBox cbDatabarTruncated;
        private CheckBox cbINDUSTRIAL25;
        private CheckBox cbUPCE;
        private CheckBox cbUPCA;
        private CheckBox cbEAN8;
        private CheckBox cbCODABAR;
        private CheckBox cbITF;
        private CheckBox cbEAN13;
        private CheckBox cbCODE93;
        private CheckBox cbCODE128;
        private CheckBox cbCOD39;
        private CheckBox cbMSICODE;
        private CheckBox cbPATCHCODE;
        private CheckBox cbDOTCODE;
        private CheckBox cbDATABAR;
        private CheckBox cbMaxicode;
        private CheckBox cbAllPDF417;
        private CheckBox cbAllQRCode;
        private CheckBox cbGS1Composite;
        private CheckBox cbMicroPDF;
        private CheckBox cbMicroQR;
        private Button btnShowAllOneD;
        private Button btnShowAllDatabar;
        private Button btnShowAllPDF;
        private Button btnShowAllQR;
        private Button btnShowAllPostalCode;
        private RadioButton rbBestCoverage;
        private RadioButton rbBalance;
        private RadioButton rbBestSpeed;
        private Label lbRecMode;
        private CheckBox cbAZTEC;
        private CheckBox cbDataMatrix;
        private CheckBox cbQRcode;
        private CheckBox cbPDF417;
        private CheckBox cbOneD;
        private Label lableFormat;
        private Panel panelSettings;
        private Label label12;
        private Label label11;
        private Label label10;
        private ComboBox cmbTextureDetectionSensitivity;
        private ComboBox cmbMinResultConfidence;
        private ComboBox cmbImagePreprocessingModes;
        private ComboBox cmbGrayscaleTransformationModes;
        private Label label9;
        private Label label8;
        private TextBox tbBinarizationBlockSize;
        private TextBox tbScaleDownThreshold;
        private Label label7;
        private CheckBox cbRegionPredetectionMode;
        private CheckBox cbTextFilterMode;
        private ComboBox cmbLocalizationModes;
        private Label label5;
        private ComboBox cmbDeblurLevel;
        private Label label4;
        private TextBox tbExpectedBarcodesCount;
        private Label label3;
        private Panel panelCustomSettings;
        private Panel panelFormat;
        private Panel panelCustom;
        private Label label17;
        private Label label18;
        private Label lbCustomPanelClose;
        private Panel panelRecognitionMode;
        private Label label2;
        private Label label13;
        private Label label14;
        private Panel panelReadBarcode;
        private PictureBox picboxReadBarcode;
        private PictureBox picboxStopBarcode;
        private Label labelWebcamNote;
        private Panel panelCustomTop;
        private Panel panelBarcodeReaderParent;
        private Panel panelFormatParent;
        private Button btnExportSettings;
        private SaveFileDialog saveRuntimeSettingsFileDialog;
        private Label comment;
        private ToolTip toolTipExport;
        private PictureBox pictureBoxCustomize;
        private CheckBox cbPostalCode;
        private Panel panelPostalCodeDetail;
        private CheckBox cbPlanet;
        private CheckBox cbPostnet;
        private CheckBox cbRM4SCC;
        private CheckBox cbAustralianPost;
        private CheckBox cbUSPSIntelligentMail;
    }
}

