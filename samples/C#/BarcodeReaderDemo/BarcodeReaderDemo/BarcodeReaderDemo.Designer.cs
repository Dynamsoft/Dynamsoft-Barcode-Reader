using System;
using System.Drawing;
using System.Windows.Forms;
using Barcode_Reader_Demo;
using Barcode_Reader_Demo.Properties;

namespace Barcode_Reader_Demo
{
    partial class BarcodeReaderDemo
    {
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
            this.picBoxWebCam = new System.Windows.Forms.PictureBox();
            this.picboxHand = new System.Windows.Forms.PictureBox();
            this.picboxPoint = new System.Windows.Forms.PictureBox();
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
            this.panelLoad = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.picboxLoadImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWebCam = new System.Windows.Forms.Panel();
            this.lblWebCamSrc = new System.Windows.Forms.Label();
            this.cbxWebCamSrc = new System.Windows.Forms.ComboBox();
            this.lblWebCamRes = new System.Windows.Forms.Label();
            this.cbxWebCamRes = new System.Windows.Forms.ComboBox();
            this.panelWebcamNote = new System.Windows.Forms.Panel();
            this.labelWebcamNote = new System.Windows.Forms.Label();
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
            this.panelReadSetting = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxBottom = new System.Windows.Forms.TextBox();
            this.tbxMaxBarcodeReads = new System.Windows.Forms.TextBox();
            this.cbxBarcodeFormat = new System.Windows.Forms.ComboBox();
            this.tbxTop = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxRight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxLeft = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelImageCaptureDevice = new System.Windows.Forms.Label();
            this.labelBarcodeOrientation = new System.Windows.Forms.Label();
            this.cbxImageCaptureDevice = new System.Windows.Forms.ComboBox();
            this.cbxBarcodeOrientation = new System.Windows.Forms.ComboBox();
            this.panelReadMoreSetting = new System.Windows.Forms.Panel();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.labelBarcodeWidth = new System.Windows.Forms.Label();
            this.labelBarcodeHeight = new System.Windows.Forms.Label();
            this.labelBarcodeModuleSize = new System.Windows.Forms.Label();
            this.labelBarcodeWidthMeasure = new System.Windows.Forms.Label();
            this.labelBarcodeHeightMeasure = new System.Windows.Forms.Label();
            this.labelBarcodeModuleSizeMeasure = new System.Windows.Forms.Label();
            this.labelBarcodeTextEncoding = new System.Windows.Forms.Label();
            this.labelBarcodeColorMode = new System.Windows.Forms.Label();
            this.tbxTimeout = new System.Windows.Forms.TextBox();
            this.tbxMinWidth = new System.Windows.Forms.TextBox();
            this.tbxMaxWidth = new System.Windows.Forms.TextBox();
            this.tbxMinHeight = new System.Windows.Forms.TextBox();
            this.tbxMaxHeight = new System.Windows.Forms.TextBox();
            this.tbxMinModuleSize = new System.Windows.Forms.TextBox();
            this.tbxMaxModuleSize = new System.Windows.Forms.TextBox();
            this.cbxBarcodeTextEncoding = new System.Windows.Forms.ComboBox();
            this.cbxBarcodeDark = new System.Windows.Forms.CheckBox();
            this.cbxBarcodeLight = new System.Windows.Forms.CheckBox();
            this.cbxDeblurOneD = new System.Windows.Forms.CheckBox();
            this.cbxReturnUnrecognized = new System.Windows.Forms.CheckBox();
            this.panelReadBarcode = new System.Windows.Forms.Panel();
            this.picboxReadBarcode = new System.Windows.Forms.PictureBox();
            this.picboxStopBarcode = new System.Windows.Forms.PictureBox();
            this.picboxFit = new System.Windows.Forms.PictureBox();
            this.picboxOriginalSize = new System.Windows.Forms.PictureBox();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.lblCloseResult = new System.Windows.Forms.Label();
            this.dsViewer = new Dynamsoft.Forms.DSViewer();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWebCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPoint)).BeginInit();
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
            this.panelLoad.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoadImage)).BeginInit();
            this.panelWebCam.SuspendLayout();
            this.panelWebcamNote.SuspendLayout();
            this.panelAcquire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScan)).BeginInit();
            this.panelReadSetting.SuspendLayout();
            this.panelReadMoreSetting.SuspendLayout();
            this.panelReadBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxReadBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxStopBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginalSize)).BeginInit();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodeReaderDemo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BarcodeReaderDemo_FormClosed);
            this.SuspendLayout();
            // 
            // picBoxWebCam
            // 
            this.picBoxWebCam.BackColor = System.Drawing.Color.White;
            this.picBoxWebCam.Location = new System.Drawing.Point(6, 48);
            this.picBoxWebCam.Name = "picBoxWebCam";
            this.picBoxWebCam.Size = new System.Drawing.Size(563, 628);
            this.picBoxWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxWebCam.TabIndex = 2;
            this.picBoxWebCam.TabStop = false;
            this.picBoxWebCam.Visible = false;
            // 
            // picboxHand
            // 
            this.picboxHand.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxHand_Leave;
            this.picboxHand.Location = new System.Drawing.Point(12, 108);
            this.picboxHand.Name = "picboxHand";
            this.picboxHand.Size = new System.Drawing.Size(61, 36);
            this.picboxHand.TabIndex = 2;
            this.picboxHand.TabStop = false;
            this.picboxHand.Tag = "Move";
            this.picboxHand.Click += new System.EventHandler(this.picboxHand_Click);
            this.picboxHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxHand.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxHand.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxHand.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxHand.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxPoint
            // 
            this.picboxPoint.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxPoint_Leave;
            this.picboxPoint.Location = new System.Drawing.Point(12, 60);
            this.picboxPoint.Name = "picboxPoint";
            this.picboxPoint.Size = new System.Drawing.Size(60, 36);
            this.picboxPoint.TabIndex = 4;
            this.picboxPoint.TabStop = false;
            this.picboxPoint.Tag = "Select";
            this.picboxPoint.Click += new System.EventHandler(this.picboxPoint_Click);
            this.picboxPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxPoint.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxPoint.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxPoint.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxPoint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
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
            this.picboxZoomOut.Location = new System.Drawing.Point(12, 300);
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
            this.picboxZoomIn.Location = new System.Drawing.Point(12, 252);
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
            this.picboxDeleteAll.Location = new System.Drawing.Point(12, 396);
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
            this.picboxDelete.Location = new System.Drawing.Point(12, 348);
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
            this.picboxFirst.Location = new System.Drawing.Point(99, 645);
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
            this.picboxLast.Location = new System.Drawing.Point(418, 645);
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
            this.picboxNext.Location = new System.Drawing.Point(362, 645);
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
            this.picboxPrevious.Location = new System.Drawing.Point(155, 645);
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
            this.cbxViewMode.Location = new System.Drawing.Point(474, 645);
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
            this.lbDiv.Location = new System.Drawing.Point(279, 650);
            this.lbDiv.Name = "lbDiv";
            this.lbDiv.Size = new System.Drawing.Size(12, 15);
            this.lbDiv.TabIndex = 75;
            this.lbDiv.Text = "/";
            // 
            // tbxCurrentImageIndex
            // 
            this.tbxCurrentImageIndex.Enabled = false;
            this.tbxCurrentImageIndex.Location = new System.Drawing.Point(211, 647);
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
            this.tbxTotalImageNum.Location = new System.Drawing.Point(295, 647);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(566, 48);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(331, 624);
            this.flowLayoutPanel2.TabIndex = 84;
            // 
            // panelLoad
            // 
            this.panelLoad.BackColor = System.Drawing.Color.Transparent;
            this.panelLoad.Controls.Add(this.panel1);
            this.panelLoad.Controls.Add(this.picboxLoadImage);
            this.panelLoad.Controls.Add(this.label1);
            this.panelLoad.Location = new System.Drawing.Point(1, 41);
            this.panelLoad.Margin = new System.Windows.Forms.Padding(0);
            this.panelLoad.Name = "panelLoad";
            this.panelLoad.Size = new System.Drawing.Size(300, 175);
            this.panelLoad.TabIndex = 3;
            this.panelLoad.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label24);
            this.panel1.Location = new System.Drawing.Point(43, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 30);
            this.panel1.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label24.Location = new System.Drawing.Point(0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(228, 30);
            this.label24.TabIndex = 0;
            this.label24.Text = "     Note: PDF Rasterizer add-on is used when loading PDF files.";
            // 
            // picboxLoadImage
            // 
            this.picboxLoadImage.InitialImage = null;
            this.picboxLoadImage.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxLoadImage_Leave;
            this.picboxLoadImage.Location = new System.Drawing.Point(60, 60);
            this.picboxLoadImage.Name = "picboxLoadImage";
            this.picboxLoadImage.Size = new System.Drawing.Size(180, 38);
            this.picboxLoadImage.TabIndex = 1;
            this.picboxLoadImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Load local images or PDF files";
            // 
            // panelWebCam
            // 
            this.panelWebCam.BackColor = System.Drawing.Color.Transparent;
            this.panelWebCam.Controls.Add(this.lblWebCamSrc);
            this.panelWebCam.Controls.Add(this.cbxWebCamSrc);
            this.panelWebCam.Controls.Add(this.lblWebCamRes);
            this.panelWebCam.Controls.Add(this.cbxWebCamRes);
            this.panelWebCam.Controls.Add(this.panelWebcamNote);
            this.panelWebCam.Location = new System.Drawing.Point(1, 41);
            this.panelWebCam.Margin = new System.Windows.Forms.Padding(0);
            this.panelWebCam.Name = "panelWebCam";
            this.panelWebCam.Size = new System.Drawing.Size(300, 175);
            this.panelWebCam.TabIndex = 3;
            this.panelWebCam.Visible = false;
            // 
            // lblWebCamSrc
            // 
            this.lblWebCamSrc.AutoSize = true;
            this.lblWebCamSrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCamSrc.Location = new System.Drawing.Point(38, 10);
            this.lblWebCamSrc.Name = "lblWebCamSrc";
            this.lblWebCamSrc.Size = new System.Drawing.Size(96, 15);
            this.lblWebCamSrc.TabIndex = 0;
            this.lblWebCamSrc.Text = "Webcam Source:";
            // 
            // cbxWebCamSrc
            // 
            this.cbxWebCamSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWebCamSrc.FormattingEnabled = true;
            this.cbxWebCamSrc.Location = new System.Drawing.Point(38, 30);
            this.cbxWebCamSrc.Name = "cbxWebCamSrc";
            this.cbxWebCamSrc.Size = new System.Drawing.Size(216, 21);
            this.cbxWebCamSrc.TabIndex = 13;
            // 
            // lblWebCamRes
            // 
            this.lblWebCamRes.AutoSize = true;
            this.lblWebCamRes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCamRes.Location = new System.Drawing.Point(38, 60);
            this.lblWebCamRes.Name = "lblWebCamRes";
            this.lblWebCamRes.Size = new System.Drawing.Size(116, 15);
            this.lblWebCamRes.TabIndex = 12;
            this.lblWebCamRes.Text = "Webcam Resolution:";
            // 
            // cbxWebCamRes
            // 
            this.cbxWebCamRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWebCamRes.FormattingEnabled = true;
            this.cbxWebCamRes.Location = new System.Drawing.Point(38, 80);
            this.cbxWebCamRes.Name = "cbxWebCamRes";
            this.cbxWebCamRes.Size = new System.Drawing.Size(216, 21);
            this.cbxWebCamRes.TabIndex = 13;
            // 
            // panelWebcamNote
            // 
            this.panelWebcamNote.Controls.Add(this.labelWebcamNote);
            this.panelWebcamNote.Location = new System.Drawing.Point(35, 110);
            this.panelWebcamNote.Name = "panelWebcamNote";
            this.panelWebcamNote.Size = new System.Drawing.Size(228, 60);
            this.panelWebcamNote.TabIndex = 3;
            // 
            // labelWebcamNote
            // 
            this.labelWebcamNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWebcamNote.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelWebcamNote.Location = new System.Drawing.Point(0, 0);
            this.labelWebcamNote.Name = "labelWebcamNote";
            this.labelWebcamNote.Size = new System.Drawing.Size(228, 60);
            this.labelWebcamNote.TabIndex = 0;
            this.labelWebcamNote.Text = "     Note: Please place a barcode in front of your webcam and then click \"Read Ba" +
    "rcode\" button. It will decode barcodes from camera stream directly.";
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
            this.panelAcquire.Location = new System.Drawing.Point(1, 41);
            this.panelAcquire.Margin = new System.Windows.Forms.Padding(0);
            this.panelAcquire.Name = "panelAcquire";
            this.panelAcquire.Size = new System.Drawing.Size(300, 175);
            this.panelAcquire.TabIndex = 2;
            // 
            // rdbtnGray
            // 
            this.rdbtnGray.AutoSize = true;
            this.rdbtnGray.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnGray.Location = new System.Drawing.Point(165, 50);
            this.rdbtnGray.Name = "rdbtnGray";
            this.rdbtnGray.Size = new System.Drawing.Size(49, 19);
            this.rdbtnGray.TabIndex = 641;
            this.rdbtnGray.TabStop = true;
            this.rdbtnGray.Text = "Gray";
            this.rdbtnGray.UseVisualStyleBackColor = true;
            // 
            // cbxResolution
            // 
            this.cbxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Location = new System.Drawing.Point(90, 82);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(190, 23);
            this.cbxResolution.TabIndex = 643;
            // 
            // picboxScan
            // 
            this.picboxScan.Enabled = false;
            this.picboxScan.Location = new System.Drawing.Point(61, 120);
            this.picboxScan.Name = "picboxScan";
            this.picboxScan.Size = new System.Drawing.Size(180, 38);
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
            this.rdbtnBW.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnBW.Location = new System.Drawing.Point(88, 50);
            this.rdbtnBW.Name = "rdbtnBW";
            this.rdbtnBW.Size = new System.Drawing.Size(59, 19);
            this.rdbtnBW.TabIndex = 640;
            this.rdbtnBW.TabStop = true;
            this.rdbtnBW.Text = "B && W";
            this.rdbtnBW.UseVisualStyleBackColor = true;
            // 
            // lbResolution
            // 
            this.lbResolution.AutoSize = true;
            this.lbResolution.BackColor = System.Drawing.Color.Transparent;
            this.lbResolution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResolution.Location = new System.Drawing.Point(15, 85);
            this.lbResolution.Name = "lbResolution";
            this.lbResolution.Size = new System.Drawing.Size(69, 15);
            this.lbResolution.TabIndex = 83;
            this.lbResolution.Text = "Resolution :";
            // 
            // rdbtnColor
            // 
            this.rdbtnColor.AutoSize = true;
            this.rdbtnColor.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnColor.Location = new System.Drawing.Point(232, 50);
            this.rdbtnColor.Name = "rdbtnColor";
            this.rdbtnColor.Size = new System.Drawing.Size(54, 19);
            this.rdbtnColor.TabIndex = 642;
            this.rdbtnColor.TabStop = true;
            this.rdbtnColor.Text = "Color";
            this.rdbtnColor.UseVisualStyleBackColor = false;
            // 
            // lbPixelType
            // 
            this.lbPixelType.AutoSize = true;
            this.lbPixelType.BackColor = System.Drawing.Color.Transparent;
            this.lbPixelType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPixelType.Location = new System.Drawing.Point(15, 50);
            this.lbPixelType.Name = "lbPixelType";
            this.lbPixelType.Size = new System.Drawing.Size(66, 15);
            this.lbPixelType.TabIndex = 87;
            this.lbPixelType.Text = "Pixel Type :";
            // 
            // lbSelectSource
            // 
            this.lbSelectSource.AutoSize = true;
            this.lbSelectSource.BackColor = System.Drawing.Color.Transparent;
            this.lbSelectSource.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectSource.Location = new System.Drawing.Point(15, 15);
            this.lbSelectSource.Name = "lbSelectSource";
            this.lbSelectSource.Size = new System.Drawing.Size(94, 15);
            this.lbSelectSource.TabIndex = 84;
            this.lbSelectSource.Text = "Scanner Source :";
            // 
            // cbxSource
            // 
            this.cbxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSource.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(120, 12);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(160, 22);
            this.cbxSource.TabIndex = 639;
            // 
            // panelReadSetting
            // 
            this.panelReadSetting.BackColor = System.Drawing.Color.Transparent;
            this.panelReadSetting.Controls.Add(this.label6);
            this.panelReadSetting.Controls.Add(this.label7);
            this.panelReadSetting.Controls.Add(this.tbxBottom);
            this.panelReadSetting.Controls.Add(this.tbxMaxBarcodeReads);
            this.panelReadSetting.Controls.Add(this.cbxBarcodeFormat);
            this.panelReadSetting.Controls.Add(this.tbxTop);
            this.panelReadSetting.Controls.Add(this.label8);
            this.panelReadSetting.Controls.Add(this.label9);
            this.panelReadSetting.Controls.Add(this.tbxRight);
            this.panelReadSetting.Controls.Add(this.label10);
            this.panelReadSetting.Controls.Add(this.label11);
            this.panelReadSetting.Controls.Add(this.tbxLeft);
            this.panelReadSetting.Controls.Add(this.label12);
            this.panelReadSetting.Controls.Add(this.labelImageCaptureDevice);
            this.panelReadSetting.Controls.Add(this.labelBarcodeOrientation);
            this.panelReadSetting.Controls.Add(this.cbxImageCaptureDevice);
            this.panelReadSetting.Controls.Add(this.cbxBarcodeOrientation);
            this.panelReadSetting.Location = new System.Drawing.Point(1, 41);
            this.panelReadSetting.Margin = new System.Windows.Forms.Padding(0);
            this.panelReadSetting.Name = "panelReadSetting";
            this.panelReadSetting.Size = new System.Drawing.Size(300, 290);
            this.panelReadSetting.TabIndex = 2;
            this.panelReadSetting.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Barcode format :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Maximum barcode reads :";
            // 
            // tbxBottom
            // 
            this.tbxBottom.Location = new System.Drawing.Point(207, 211);
            this.tbxBottom.Name = "tbxBottom";
            this.tbxBottom.ReadOnly = true;
            this.tbxBottom.Size = new System.Drawing.Size(80, 20);
            this.tbxBottom.TabIndex = 649;
            // 
            // tbxMaxBarcodeReads
            // 
            this.tbxMaxBarcodeReads.Location = new System.Drawing.Point(170, 47);
            this.tbxMaxBarcodeReads.Name = "tbxMaxBarcodeReads";
            this.tbxMaxBarcodeReads.Size = new System.Drawing.Size(120, 20);
            this.tbxMaxBarcodeReads.TabIndex = 645;
            this.tbxMaxBarcodeReads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBarcodeLocation_KeyPress);
            // 
            // cbxBarcodeFormat
            // 
            this.cbxBarcodeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBarcodeFormat.FormattingEnabled = true;
            this.cbxBarcodeFormat.ItemHeight = 13;
            this.cbxBarcodeFormat.Location = new System.Drawing.Point(120, 11);
            this.cbxBarcodeFormat.Name = "cbxBarcodeFormat";
            this.cbxBarcodeFormat.Size = new System.Drawing.Size(170, 21);
            this.cbxBarcodeFormat.TabIndex = 644;
            this.cbxBarcodeFormat.SelectedIndexChanged += new System.EventHandler(this.cbxBarcodeFormat_SelectedIndexChanged);
            // 
            // tbxTop
            // 
            this.tbxTop.Location = new System.Drawing.Point(60, 211);
            this.tbxTop.Name = "tbxTop";
            this.tbxTop.ReadOnly = true;
            this.tbxTop.Size = new System.Drawing.Size(80, 20);
            this.tbxTop.TabIndex = 648;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Selected rectangle area of the image :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Left :";
            // 
            // tbxRight
            // 
            this.tbxRight.Location = new System.Drawing.Point(207, 176);
            this.tbxRight.Name = "tbxRight";
            this.tbxRight.ReadOnly = true;
            this.tbxRight.Size = new System.Drawing.Size(80, 20);
            this.tbxRight.TabIndex = 647;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(151, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Right :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Top :";
            // 
            // tbxLeft
            // 
            this.tbxLeft.Location = new System.Drawing.Point(60, 177);
            this.tbxLeft.Name = "tbxLeft";
            this.tbxLeft.ReadOnly = true;
            this.tbxLeft.Size = new System.Drawing.Size(80, 20);
            this.tbxLeft.TabIndex = 646;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(151, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 10;
            this.label12.Text = "Bottom :";
            // 
            // labelImageCaptureDevice
            // 
            this.labelImageCaptureDevice.AutoSize = true;
            this.labelImageCaptureDevice.BackColor = System.Drawing.Color.Transparent;
            this.labelImageCaptureDevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageCaptureDevice.Location = new System.Drawing.Point(15, 83);
            this.labelImageCaptureDevice.Name = "labelImageCaptureDevice";
            this.labelImageCaptureDevice.Size = new System.Drawing.Size(126, 15);
            this.labelImageCaptureDevice.TabIndex = 84;
            this.labelImageCaptureDevice.Text = "Image capture device :";
            // 
            // labelBarcodeOrientation
            // 
            this.labelBarcodeOrientation.AutoSize = true;
            this.labelBarcodeOrientation.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeOrientation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeOrientation.Location = new System.Drawing.Point(15, 117);
            this.labelBarcodeOrientation.Name = "labelBarcodeOrientation";
            this.labelBarcodeOrientation.Size = new System.Drawing.Size(117, 15);
            this.labelBarcodeOrientation.TabIndex = 84;
            this.labelBarcodeOrientation.Text = "Barcode orientation :";
            // 
            // cbxImageCaptureDevice
            // 
            this.cbxImageCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxImageCaptureDevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxImageCaptureDevice.FormattingEnabled = true;
            this.cbxImageCaptureDevice.Items.AddRange(new object[] {
            "Unknown",
            "Scanner",
            "Camera",
            "Fax"});
            this.cbxImageCaptureDevice.Location = new System.Drawing.Point(150, 79);
            this.cbxImageCaptureDevice.Name = "cbxImageCaptureDevice";
            this.cbxImageCaptureDevice.Size = new System.Drawing.Size(140, 23);
            this.cbxImageCaptureDevice.TabIndex = 643;
            this.cbxImageCaptureDevice.SelectedIndex = 0;
            // 
            // cbxBarcodeOrientation
            // 
            this.cbxBarcodeOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBarcodeOrientation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBarcodeOrientation.FormattingEnabled = true;
            this.cbxBarcodeOrientation.Items.AddRange(new object[] {
            "All",
            "Horizontal",
            "Vertical"});
            this.cbxBarcodeOrientation.Location = new System.Drawing.Point(150, 113);
            this.cbxBarcodeOrientation.Name = "cbxBarcodeOrientation";
            this.cbxBarcodeOrientation.Size = new System.Drawing.Size(140, 23);
            this.cbxBarcodeOrientation.TabIndex = 643;
            this.cbxBarcodeOrientation.SelectedIndex = 0;
            // 
            // panelReadMoreSetting
            // 
            this.panelReadMoreSetting.BackColor = System.Drawing.Color.Transparent;
            this.panelReadMoreSetting.Controls.Add(this.labelTimeout);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeWidth);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeHeight);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeModuleSize);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeWidthMeasure);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeHeightMeasure);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeModuleSizeMeasure);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeTextEncoding);
            this.panelReadMoreSetting.Controls.Add(this.labelBarcodeColorMode);
            this.panelReadMoreSetting.Controls.Add(this.tbxTimeout);
            this.panelReadMoreSetting.Controls.Add(this.tbxMinWidth);
            this.panelReadMoreSetting.Controls.Add(this.tbxMaxWidth);
            this.panelReadMoreSetting.Controls.Add(this.tbxMinHeight);
            this.panelReadMoreSetting.Controls.Add(this.tbxMaxHeight);
            this.panelReadMoreSetting.Controls.Add(this.tbxMinModuleSize);
            this.panelReadMoreSetting.Controls.Add(this.tbxMaxModuleSize);
            this.panelReadMoreSetting.Controls.Add(this.cbxBarcodeTextEncoding);
            this.panelReadMoreSetting.Controls.Add(this.cbxBarcodeDark);
            this.panelReadMoreSetting.Controls.Add(this.cbxBarcodeLight);
            this.panelReadMoreSetting.Controls.Add(this.cbxDeblurOneD);
            this.panelReadMoreSetting.Controls.Add(this.cbxReturnUnrecognized);
            this.panelReadMoreSetting.Location = new System.Drawing.Point(1, 41);
            this.panelReadMoreSetting.Margin = new System.Windows.Forms.Padding(0);
            this.panelReadMoreSetting.Name = "panelReadMoreSetting";
            this.panelReadMoreSetting.Size = new System.Drawing.Size(300, 290);
            this.panelReadMoreSetting.TabIndex = 3;
            this.panelReadMoreSetting.Visible = false;
            // 
            // labelTimeout
            // 
            this.labelTimeout.AutoSize = true;
            this.labelTimeout.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeout.Location = new System.Drawing.Point(15, 15);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(135, 15);
            this.labelTimeout.TabIndex = 2;
            this.labelTimeout.Text = "Timeout (milliseconds) :";
            // 
            // labelBarcodeWidth
            // 
            this.labelBarcodeWidth.AutoSize = true;
            this.labelBarcodeWidth.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeWidth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeWidth.Location = new System.Drawing.Point(15, 49);
            this.labelBarcodeWidth.Name = "labelBarcodeWidth";
            this.labelBarcodeWidth.Size = new System.Drawing.Size(129, 15);
            this.labelBarcodeWidth.TabIndex = 3;
            this.labelBarcodeWidth.Text = "Barcode width (pixels) :";
            // 
            // labelBarcodeHeight
            // 
            this.labelBarcodeHeight.AutoSize = true;
            this.labelBarcodeHeight.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeHeight.Location = new System.Drawing.Point(15, 83);
            this.labelBarcodeHeight.Name = "labelBarcodeHeight";
            this.labelBarcodeHeight.Size = new System.Drawing.Size(133, 15);
            this.labelBarcodeHeight.TabIndex = 84;
            this.labelBarcodeHeight.Text = "Barcode height (pixels) :";
            // 
            // labelBarcodeModuleSize
            // 
            this.labelBarcodeModuleSize.AutoSize = true;
            this.labelBarcodeModuleSize.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeModuleSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeModuleSize.Location = new System.Drawing.Point(15, 117);
            this.labelBarcodeModuleSize.Name = "labelBarcodeModuleSize";
            this.labelBarcodeModuleSize.Size = new System.Drawing.Size(162, 15);
            this.labelBarcodeModuleSize.TabIndex = 84;
            this.labelBarcodeModuleSize.Text = "Barcode module size (pixels) :";
            // 
            // labelBarcodeWidthMeasure
            // 
            this.labelBarcodeWidthMeasure.AutoSize = true;
            this.labelBarcodeWidthMeasure.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeWidthMeasure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeWidthMeasure.Location = new System.Drawing.Point(212, 49);
            this.labelBarcodeWidthMeasure.Name = "labelBarcodeWidthMeasure";
            this.labelBarcodeWidthMeasure.Size = new System.Drawing.Size(12, 15);
            this.labelBarcodeWidthMeasure.TabIndex = 84;
            this.labelBarcodeWidthMeasure.Text = "-";
            // 
            // labelBarcodeHeightMeasure
            // 
            this.labelBarcodeHeightMeasure.AutoSize = true;
            this.labelBarcodeHeightMeasure.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeHeightMeasure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeHeightMeasure.Location = new System.Drawing.Point(212, 83);
            this.labelBarcodeHeightMeasure.Name = "labelBarcodeHeightMeasure";
            this.labelBarcodeHeightMeasure.Size = new System.Drawing.Size(12, 15);
            this.labelBarcodeHeightMeasure.TabIndex = 84;
            this.labelBarcodeHeightMeasure.Text = "-";
            // 
            // labelBarcodeModuleSizeMeasure
            // 
            this.labelBarcodeModuleSizeMeasure.AutoSize = true;
            this.labelBarcodeModuleSizeMeasure.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeModuleSizeMeasure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeModuleSizeMeasure.Location = new System.Drawing.Point(230, 117);
            this.labelBarcodeModuleSizeMeasure.Name = "labelBarcodeModuleSizeMeasure";
            this.labelBarcodeModuleSizeMeasure.Size = new System.Drawing.Size(12, 15);
            this.labelBarcodeModuleSizeMeasure.TabIndex = 84;
            this.labelBarcodeModuleSizeMeasure.Text = "-";
            // 
            // labelBarcodeTextEncoding
            // 
            this.labelBarcodeTextEncoding.AutoSize = true;
            this.labelBarcodeTextEncoding.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeTextEncoding.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeTextEncoding.Location = new System.Drawing.Point(15, 151);
            this.labelBarcodeTextEncoding.Name = "labelBarcodeTextEncoding";
            this.labelBarcodeTextEncoding.Size = new System.Drawing.Size(131, 15);
            this.labelBarcodeTextEncoding.TabIndex = 84;
            this.labelBarcodeTextEncoding.Text = "Barcode text encoding :";
            // 
            // labelBarcodeColorMode
            // 
            this.labelBarcodeColorMode.AutoSize = true;
            this.labelBarcodeColorMode.BackColor = System.Drawing.Color.Transparent;
            this.labelBarcodeColorMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodeColorMode.Location = new System.Drawing.Point(15, 185);
            this.labelBarcodeColorMode.Name = "labelBarcodeColorMode";
            this.labelBarcodeColorMode.Size = new System.Drawing.Size(120, 15);
            this.labelBarcodeColorMode.TabIndex = 84;
            this.labelBarcodeColorMode.Text = "Barcode color mode :";
            // 
            // tbxTimeout
            // 
            this.tbxTimeout.Location = new System.Drawing.Point(150, 11);
            this.tbxTimeout.Name = "tbxTimeout";
            this.tbxTimeout.Size = new System.Drawing.Size(140, 20);
            this.tbxTimeout.TabIndex = 645;
            this.tbxTimeout.Text = "15000";
            // 
            // tbxMinWidth
            // 
            this.tbxMinWidth.Location = new System.Drawing.Point(150, 49);
            this.tbxMinWidth.Name = "tbxMinWidth";
            this.tbxMinWidth.Size = new System.Drawing.Size(60, 20);
            this.tbxMinWidth.TabIndex = 645;
            this.tbxMinWidth.Text = "8";
            // 
            // tbxMaxWidth
            // 
            this.tbxMaxWidth.Location = new System.Drawing.Point(230, 49);
            this.tbxMaxWidth.Name = "tbxMaxWidth";
            this.tbxMaxWidth.Size = new System.Drawing.Size(60, 20);
            this.tbxMaxWidth.TabIndex = 645;
            this.tbxMaxWidth.Text = "2048";
            // 
            // tbxMinHeight
            // 
            this.tbxMinHeight.Location = new System.Drawing.Point(150, 83);
            this.tbxMinHeight.Name = "tbxMinHeight";
            this.tbxMinHeight.Size = new System.Drawing.Size(60, 20);
            this.tbxMinHeight.TabIndex = 650;
            this.tbxMinHeight.Text = "8";
            // 
            // tbxMaxHeight
            // 
            this.tbxMaxHeight.Location = new System.Drawing.Point(230, 83);
            this.tbxMaxHeight.Name = "tbxMaxHeight";
            this.tbxMaxHeight.Size = new System.Drawing.Size(60, 20);
            this.tbxMaxHeight.TabIndex = 651;
            this.tbxMaxHeight.Text = "2048";
            // 
            // tbxMinModuleSize
            // 
            this.tbxMinModuleSize.Location = new System.Drawing.Point(180, 117);
            this.tbxMinModuleSize.Name = "tbxMinModuleSize";
            this.tbxMinModuleSize.Size = new System.Drawing.Size(45, 20);
            this.tbxMinModuleSize.TabIndex = 650;
            this.tbxMinModuleSize.Text = "1";
            // 
            // tbxMaxModuleSize
            // 
            this.tbxMaxModuleSize.Location = new System.Drawing.Point(245, 117);
            this.tbxMaxModuleSize.Name = "tbxMaxModuleSize";
            this.tbxMaxModuleSize.Size = new System.Drawing.Size(45, 20);
            this.tbxMaxModuleSize.TabIndex = 651;
            this.tbxMaxModuleSize.Text = "32";
            // 
            // cbxBarcodeTextEncoding
            // 
            this.cbxBarcodeTextEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBarcodeTextEncoding.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBarcodeTextEncoding.FormattingEnabled = true;
            this.cbxBarcodeTextEncoding.Items.AddRange(new object[] {
            "Default",
            "UTF8",
            "UTF16",
            "SHIFT_JIS_932",
            "GB2312_936",
            "KOREAN_949",
            "BIG5_950"});
            this.cbxBarcodeTextEncoding.Location = new System.Drawing.Point(150, 151);
            this.cbxBarcodeTextEncoding.Name = "cbxBarcodeTextEncoding";
            this.cbxBarcodeTextEncoding.Size = new System.Drawing.Size(140, 23);
            this.cbxBarcodeTextEncoding.TabIndex = 655;
            this.cbxBarcodeTextEncoding.SelectedIndex = 0;
            // 
            // cbxBarcodeDark
            // 
            this.cbxBarcodeDark.AutoSize = true;
            this.cbxBarcodeDark.BackColor = System.Drawing.Color.Transparent;
            this.cbxBarcodeDark.Checked = true;
            this.cbxBarcodeDark.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxBarcodeDark.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBarcodeDark.Location = new System.Drawing.Point(140, 185);
            this.cbxBarcodeDark.Name = "cbxBarcodeDark";
            this.cbxBarcodeDark.Size = new System.Drawing.Size(94, 19);
            this.cbxBarcodeDark.TabIndex = 85;
            this.cbxBarcodeDark.Text = "Dark on light";
            this.cbxBarcodeDark.UseVisualStyleBackColor = false;
            // 
            // cbxBarcodeLight
            // 
            this.cbxBarcodeLight.AutoSize = true;
            this.cbxBarcodeLight.BackColor = System.Drawing.Color.Transparent;
            this.cbxBarcodeLight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBarcodeLight.Location = new System.Drawing.Point(140, 210);
            this.cbxBarcodeLight.Name = "cbxBarcodeLight";
            this.cbxBarcodeLight.Size = new System.Drawing.Size(99, 19);
            this.cbxBarcodeLight.TabIndex = 86;
            this.cbxBarcodeLight.Text = "Light on dark ";
            this.cbxBarcodeLight.UseVisualStyleBackColor = false;
            // 
            // cbxDeblurOneD
            // 
            this.cbxDeblurOneD.AutoSize = true;
            this.cbxDeblurOneD.BackColor = System.Drawing.Color.Transparent;
            this.cbxDeblurOneD.Checked = true;
            this.cbxDeblurOneD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDeblurOneD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDeblurOneD.Location = new System.Drawing.Point(18, 230);
            this.cbxDeblurOneD.Name = "cbxDeblurOneD";
            this.cbxDeblurOneD.Size = new System.Drawing.Size(124, 19);
            this.cbxDeblurOneD.TabIndex = 86;
            this.cbxDeblurOneD.Text = "Deblur 1D barcode";
            this.cbxDeblurOneD.UseVisualStyleBackColor = false;
            // 
            // cbxReturnUnrecognized
            // 
            this.cbxReturnUnrecognized.AutoSize = true;
            this.cbxReturnUnrecognized.BackColor = System.Drawing.Color.Transparent;
            this.cbxReturnUnrecognized.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReturnUnrecognized.Location = new System.Drawing.Point(18, 258);
            this.cbxReturnUnrecognized.Name = "cbxReturnUnrecognized";
            this.cbxReturnUnrecognized.Size = new System.Drawing.Size(170, 19);
            this.cbxReturnUnrecognized.TabIndex = 86;
            this.cbxReturnUnrecognized.Text = "Find unrecognized barcode";
            this.cbxReturnUnrecognized.UseVisualStyleBackColor = false;
            // 
            // panelReadBarcode
            // 
            this.panelReadBarcode.BackColor = System.Drawing.Color.Transparent;
            this.panelReadBarcode.Controls.Add(this.picboxReadBarcode);
            this.panelReadBarcode.Controls.Add(this.picboxStopBarcode);
            this.panelReadBarcode.Location = new System.Drawing.Point(1, 41);
            this.panelReadBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.panelReadBarcode.Name = "panelReadBarcode";
            this.panelReadBarcode.Size = new System.Drawing.Size(300, 50);
            this.panelReadBarcode.TabIndex = 3;
            // 
            // picboxReadBarcode
            // 
            this.picboxReadBarcode.Location = new System.Drawing.Point(68, 6);
            this.picboxReadBarcode.Name = "picboxReadBarcode";
            this.picboxReadBarcode.Size = new System.Drawing.Size(180, 38);
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
            this.picboxStopBarcode.Location = new System.Drawing.Point(68, 6);
            this.picboxStopBarcode.Name = "picboxStopBarcode";
            this.picboxStopBarcode.Size = new System.Drawing.Size(180, 38);
            this.picboxStopBarcode.TabIndex = 15;
            this.picboxStopBarcode.TabStop = false;
            this.picboxStopBarcode.Visible = false;
            this.picboxStopBarcode.Click += new System.EventHandler(this.picboxStopBarcode_Click);
            this.picboxStopBarcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxStopBarcode.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            this.picboxStopBarcode.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxStopBarcode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            // 
            // picboxFit
            // 
            this.picboxFit.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxFit_Leave;
            this.picboxFit.Location = new System.Drawing.Point(12, 156);
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
            this.picboxOriginalSize.Location = new System.Drawing.Point(12, 204);
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
            this.tbxResult.Size = new System.Drawing.Size(309, 570);
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
            this.dsViewer.Size = new System.Drawing.Size(477, 586);
            this.dsViewer.TabIndex = 651;
            // 
            // BarcodeReaderDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Barcode_Reader_Demo.Properties.Resources.main_bg;
            this.ClientSize = new System.Drawing.Size(898, 698);
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
            this.Controls.Add(this.picboxPoint);
            this.Controls.Add(this.picboxHand);
            this.Controls.Add(this.picBoxWebCam);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarcodeReaderDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamsoft Barcode Reader Demo";
            this.Load += new System.EventHandler(this.DotNetTWAINDemo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWebCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPoint)).EndInit();
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
            this.panelLoad.ResumeLayout(false);
            this.panelLoad.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoadImage)).EndInit();
            this.panelWebCam.ResumeLayout(false);
            this.panelWebCam.PerformLayout();
            this.panelWebcamNote.ResumeLayout(false);
            this.panelAcquire.ResumeLayout(false);
            this.panelAcquire.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScan)).EndInit();
            this.panelReadSetting.ResumeLayout(false);
            this.panelReadSetting.PerformLayout();
            this.panelReadMoreSetting.ResumeLayout(false);
            this.panelReadMoreSetting.PerformLayout();
            this.panelReadBarcode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxReadBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxStopBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginalSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.PictureBox picboxHand;
        private System.Windows.Forms.PictureBox picboxPoint;
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
        private System.Windows.Forms.ComboBox cbxResolution;
        private System.Windows.Forms.PictureBox picboxScan;
        private System.Windows.Forms.Label lbSelectSource;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxMaxBarcodeReads;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxBarcodeFormat;
        private System.Windows.Forms.TextBox tbxBottom;
        private System.Windows.Forms.TextBox tbxTop;
        private System.Windows.Forms.TextBox tbxRight;
        private System.Windows.Forms.TextBox tbxLeft;
        private System.Windows.Forms.PictureBox picboxReadBarcode;
        private System.Windows.Forms.PictureBox picboxStopBarcode;
        private System.Windows.Forms.Panel panelReadSetting;
        private System.Windows.Forms.Panel panelReadMoreSetting;
        private System.Windows.Forms.Panel panelReadBarcode;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Label lblCloseResult;
        private System.Windows.Forms.PictureBox picboxFit;
        private System.Windows.Forms.PictureBox picboxOriginalSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panelWebcamNote;
        private System.Windows.Forms.Label labelWebcamNote;
        //private System.Windows.Forms.Timer timerWebCam;
        private System.Windows.Forms.PictureBox picBoxWebCam;
        private System.Windows.Forms.Label labelImageCaptureDevice;
        private System.Windows.Forms.Label labelBarcodeOrientation;
        private System.Windows.Forms.ComboBox cbxImageCaptureDevice;
        private System.Windows.Forms.ComboBox cbxBarcodeOrientation;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.Label labelBarcodeWidth;
        private System.Windows.Forms.Label labelBarcodeHeight;
        private System.Windows.Forms.Label labelBarcodeModuleSize;
        private System.Windows.Forms.Label labelBarcodeWidthMeasure;
        private System.Windows.Forms.Label labelBarcodeHeightMeasure;
        private System.Windows.Forms.Label labelBarcodeModuleSizeMeasure;
        private System.Windows.Forms.Label labelBarcodeTextEncoding;
        private System.Windows.Forms.Label labelBarcodeColorMode;
        private System.Windows.Forms.TextBox tbxTimeout;
        private System.Windows.Forms.TextBox tbxMinWidth;
        private System.Windows.Forms.TextBox tbxMaxWidth;
        private System.Windows.Forms.TextBox tbxMinHeight;
        private System.Windows.Forms.TextBox tbxMaxHeight;
        private System.Windows.Forms.TextBox tbxMinModuleSize;
        private System.Windows.Forms.TextBox tbxMaxModuleSize;
        private System.Windows.Forms.ComboBox cbxBarcodeTextEncoding;
        private System.Windows.Forms.CheckBox cbxBarcodeDark;
        private System.Windows.Forms.CheckBox cbxBarcodeLight;
        private System.Windows.Forms.CheckBox cbxDeblurOneD;
        private System.Windows.Forms.CheckBox cbxReturnUnrecognized;
        private Dynamsoft.Forms.DSViewer dsViewer;
    }
}

