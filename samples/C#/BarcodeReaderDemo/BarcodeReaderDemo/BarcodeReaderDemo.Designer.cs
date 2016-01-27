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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeReaderDemo));
            this.panelResult = new System.Windows.Forms.Panel();
            this.picboxResultTitle = new System.Windows.Forms.PictureBox();
            this.lblCloseResult = new System.Windows.Forms.Label();
            this.timerWebCam = new System.Windows.Forms.Timer(this.components);
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
            this.dynamicDotNetTwain = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLoad = new System.Windows.Forms.Panel();
            this.panelWebCam = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.picboxLoadImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panelReadBarcode = new System.Windows.Forms.Panel();
            this.picboxReadBarcode = new System.Windows.Forms.PictureBox();
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
            this.picboxFit = new System.Windows.Forms.PictureBox();
            this.picboxOriginalSize = new System.Windows.Forms.PictureBox();
            this.rtbBarcodeResult = new System.Windows.Forms.RichTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWebCam)).BeginInit();
            this.panelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxResultTitle)).BeginInit();
            this.panelWebCam.SuspendLayout();
            this.panelLoad.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoadImage)).BeginInit();
            this.panelAcquire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScan)).BeginInit();
            this.panelReadBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxReadBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginalSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAnnotations
            // 
            this.panelResult.BackColor = System.Drawing.Color.White;
            this.panelResult.Controls.Add(this.picboxResultTitle);
            this.panelResult.Controls.Add(this.lblCloseResult);
            this.panelResult.Controls.Add(this.rtbBarcodeResult);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(199, 166);
            this.panelResult.TabIndex = 81;
            this.panelResult.Visible = false;
            //this.panelResult.BorderStyle = BorderStyle.FixedSingle;
            // 
            // picboxResultTitle
            // 
            this.picboxResultTitle.BackgroundImage = global::Barcode_Reader_Demo.Properties.Resources.barcode_Result;
            this.picboxResultTitle.Location = new System.Drawing.Point(0, 0);
            this.picboxResultTitle.Name = "picboxResultTitle";
            this.picboxResultTitle.Size = new System.Drawing.Size(199, 20);
            this.picboxResultTitle.TabStop = false;
            this.picboxResultTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picboxResultTitle_MouseMove);
            this.picboxResultTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picboxResultTitle_MouseDown);
            // 
            // lbCloseAnnotations
            // 
            this.lblCloseResult.AutoSize = true;
            this.lblCloseResult.BackColor = System.Drawing.Color.Snow;
            this.lblCloseResult.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseResult.ForeColor = System.Drawing.Color.Black;
            this.lblCloseResult.Location = new System.Drawing.Point(155, 3);
            this.lblCloseResult.Margin = new System.Windows.Forms.Padding(0);
            this.lblCloseResult.Name = "lblCloseResult";
            this.lblCloseResult.Size = new System.Drawing.Size(40, 13);
            this.lblCloseResult.TabIndex = 89;
            this.lblCloseResult.Text = "CLOSE";
            this.lblCloseResult.MouseLeave += new System.EventHandler(this.lblCloseResult_MouseLeave);
            this.lblCloseResult.Click += new System.EventHandler(this.lblCloseResult_Click);
            this.lblCloseResult.MouseHover += new System.EventHandler(this.lblCloseResult_MouseHover);
            this.lblCloseResult.BringToFront();
            // 
            // rtbBarcodeResult
            // 
            this.rtbBarcodeResult.Location = new System.Drawing.Point(0, 20);
            this.rtbBarcodeResult.Name = "rtbBarcodeResult";
            this.rtbBarcodeResult.Size = new System.Drawing.Size(199, 146);
            this.rtbBarcodeResult.TabStop = false;
            this.rtbBarcodeResult.ReadOnly = true;
            this.rtbBarcodeResult.BorderStyle = BorderStyle.None;
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
            this.picboxHand.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxHand.Click += new System.EventHandler(this.picboxHand_Click);
            this.picboxHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxHand.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxHand.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxHand.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxPoint.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxPoint.Click += new System.EventHandler(this.picboxPoint_Click);
            this.picboxPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxPoint.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxPoint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxPoint.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // lbMoveBar
            // 
            this.lbMoveBar.BackColor = System.Drawing.Color.Transparent;
            this.lbMoveBar.Location = new System.Drawing.Point(0, 1);
            this.lbMoveBar.Name = "lbMoveBar";
            this.lbMoveBar.Size = new System.Drawing.Size(897, 32);
            this.lbMoveBar.TabIndex = 18;
            this.lbMoveBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbMoveBar_MouseMove);
            this.lbMoveBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbMoveBar_MouseDown);
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
            this.picboxZoomOut.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxZoomOut.Click += new System.EventHandler(this.picboxZoomOut_Click);
            this.picboxZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxZoomOut.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxZoomOut.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxZoomIn.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxZoomIn.Click += new System.EventHandler(this.picboxZoomIn_Click);
            this.picboxZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxZoomIn.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxZoomIn.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxDeleteAll.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxDeleteAll.Click += new System.EventHandler(this.picboxDeleteAll_Click);
            this.picboxDeleteAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxDeleteAll.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxDeleteAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxDeleteAll.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxDelete.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxDelete.Click += new System.EventHandler(this.picboxDelete_Click);
            this.picboxDelete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxDelete.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxDelete.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxFirst.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxFirst.Click += new System.EventHandler(this.picboxFirst_Click);
            this.picboxFirst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxFirst.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxFirst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxFirst.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxLast.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxLast.Click += new System.EventHandler(this.picboxLast_Click);
            this.picboxLast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxLast.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxLast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxLast.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxNext.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxNext.Click += new System.EventHandler(this.picboxNext_Click);
            this.picboxNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxNext.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxNext.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxPrevious.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxPrevious.Click += new System.EventHandler(this.picboxPrevious_Click);
            this.picboxPrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxPrevious.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxPrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxPrevious.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.cbxViewMode.Size = new System.Drawing.Size(75, 25);
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
            this.picboxMin.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxMin.Click += new System.EventHandler(this.picboxMin_Click);
            this.picboxMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxMin.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // picboxClose
            // 
            this.picboxClose.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxClose_Leave;
            this.picboxClose.Location = new System.Drawing.Point(864, 10);
            this.picboxClose.Name = "picboxClose";
            this.picboxClose.Size = new System.Drawing.Size(20, 20);
            this.picboxClose.TabIndex = 74;
            this.picboxClose.TabStop = false;
            this.picboxClose.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picboxClose_MouseClick);
            this.picboxClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxClose.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            // dynamicDotNetTwain
            // 
            this.dynamicDotNetTwain.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain.AnnotationPen = null;
            this.dynamicDotNetTwain.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain.AnnotationTextFont = null;
            this.dynamicDotNetTwain.IfShowCancelDialogWhenImageTransfer = false;
            this.dynamicDotNetTwain.IfShowPrintUI = false;
            this.dynamicDotNetTwain.IfThrowException = false;
            this.dynamicDotNetTwain.Location = new System.Drawing.Point(86, 50);
            this.dynamicDotNetTwain.LogLevel = ((short)(0));
            this.dynamicDotNetTwain.Name = "dynamicDotNetTwain";
            this.dynamicDotNetTwain.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain.PDFXConformance = ((uint)(0u));
            this.dynamicDotNetTwain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dynamicDotNetTwain.Size = new System.Drawing.Size(477, 586);
            this.dynamicDotNetTwain.TabIndex = 80;
            this.dynamicDotNetTwain.Visible = false;
            this.dynamicDotNetTwain.OnImageAreaSelected += new Dynamsoft.DotNet.TWAIN.Delegate.OnImageAreaSelectedHandler(this.dynamicDotNetTwain_OnImageAreaSelected);
            this.dynamicDotNetTwain.OnPostAllTransfers += new Dynamsoft.DotNet.TWAIN.Delegate.OnPostAllTransfersHandler(this.dynamicDotNetTwain_OnPostAllTransfers);
            this.dynamicDotNetTwain.OnMouseDoubleClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseDoubleClickHandler(this.dynamicDotNetTwain_OnMouseDoubleClick);
            this.dynamicDotNetTwain.OnMouseClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseClickHandler(this.dynamicDotNetTwain_OnMouseClick);
            this.dynamicDotNetTwain.OnSourceUIClose += new Dynamsoft.DotNet.TWAIN.Delegate.OnSourceUICloseHandler(this.dynamicDotNetTwain_OnSourceUIClose);
            this.dynamicDotNetTwain.OnImageAreaDeselected += new Dynamsoft.DotNet.TWAIN.Delegate.OnImageAreaDeselectedHandler(this.dynamicDotNetTwain_OnImageAreaDeselected);
            this.dynamicDotNetTwain.OnMouseRightClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseRightClickHandler(this.dynamicDotNetTwain_OnMouseRightClick);
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
            this.panelLoad.Size = new System.Drawing.Size(300, 204);
            this.panelLoad.TabIndex = 3;
            this.panelLoad.Visible = false;
            // 
            // panelWebCam
            // 
            this.panelWebCam.BackColor = System.Drawing.Color.Transparent;
            this.panelWebCam.Controls.Add(this.lblWebCamSrc);
            this.panelWebCam.Controls.Add(this.cbxWebCamSrc);
            this.panelWebCam.Controls.Add(this.lblWebCamRes);
            this.panelWebCam.Controls.Add(this.cbxWebCamRes);
            this.panelWebCam.Location = new System.Drawing.Point(1, 41);
            this.panelWebCam.Margin = new System.Windows.Forms.Padding(0);
            this.panelWebCam.Name = "panelWebCam";
            this.panelWebCam.Size = new System.Drawing.Size(300, 150);
            this.panelWebCam.TabIndex = 3;
            this.panelWebCam.Visible = false;
            // 
            // picBoxWebCam
            // 
            this.picBoxWebCam.BackColor = System.Drawing.Color.White;
            this.picBoxWebCam.Location = new System.Drawing.Point(12, 48);
            this.picBoxWebCam.Name = "picBoxWebCam";
            this.picBoxWebCam.Size = new System.Drawing.Size(551, 628);
            this.picBoxWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxWebCam.TabIndex = 2;
            this.picBoxWebCam.TabStop = false;
            this.picBoxWebCam.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label24);
            this.panel1.Location = new System.Drawing.Point(43, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 30);
            this.panel1.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Location = new System.Drawing.Point(0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(228, 30);
            this.label24.TabIndex = 0;
            this.label24.Text = "     Note: PDF Rasterizer add-on is used when loading PDF files.";
            this.label24.Image = ((System.Drawing.Image)(Resources.ResourceManager.GetObject("icn_star")));
            this.label24.ImageAlign = ContentAlignment.TopLeft;
            // 
            // picboxLoadImage
            // 
            this.picboxLoadImage.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxLoadImage_Leave;
            this.picboxLoadImage.InitialImage = null;
            this.picboxLoadImage.Location = new System.Drawing.Point(60, 77);
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
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Load local images or PDF files";
            // 
            // lblWebCamSrc
            // 
            this.lblWebCamSrc.AutoSize = true;
            this.lblWebCamSrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCamSrc.Location = new System.Drawing.Point(38, 10);
            this.lblWebCamSrc.Name = "lblWebCamSrc";
            this.lblWebCamSrc.Size = new System.Drawing.Size(83, 15);
            this.lblWebCamSrc.TabIndex = 0;
            this.lblWebCamSrc.Text = "Webcam Source:";
            // 
            // cbxWebCamSrc
            // 
            this.cbxWebCamSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWebCamSrc.FormattingEnabled = true;
            this.cbxWebCamSrc.Location = new System.Drawing.Point(38, 34);
            this.cbxWebCamSrc.Name = "cbxWebCamSrc";
            this.cbxWebCamSrc.Size = new System.Drawing.Size(216, 22);
            this.cbxWebCamSrc.TabIndex = 13;
            // 
            // lblWebCamRes
            // 
            this.lblWebCamRes.AutoSize = true;
            this.lblWebCamRes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCamRes.Location = new System.Drawing.Point(38, 72);
            this.lblWebCamRes.Name = "lblWebCamRes";
            this.lblWebCamRes.Size = new System.Drawing.Size(83, 15);
            this.lblWebCamRes.TabIndex = 12;
            this.lblWebCamRes.Text = "Webcam Resolution:";
            // 
            // cbxWebCamRes
            // 
            this.cbxWebCamRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWebCamRes.FormattingEnabled = true;
            this.cbxWebCamRes.Location = new System.Drawing.Point(38, 96);
            this.cbxWebCamRes.Name = "cbxWebCamRes";
            this.cbxWebCamRes.Size = new System.Drawing.Size(216, 22);
            this.cbxWebCamRes.TabIndex = 13;
            //this.cbxWebCamRes.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.panelAcquire.Size = new System.Drawing.Size(300, 204);
            this.panelAcquire.TabIndex = 2;
            // 
            // rdbtnGray
            // 
            this.rdbtnGray.AutoSize = true;
            this.rdbtnGray.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnGray.Location = new System.Drawing.Point(125, 93);
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
            //this.cbxResolution.Enabled = false;
            this.cbxResolution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Location = new System.Drawing.Point(123, 119);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(130, 23);
            this.cbxResolution.TabIndex = 643;
            // 
            // picboxScan
            // 
            this.picboxScan.Enabled = false;
            this.picboxScan.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxScan_Disabled;
            this.picboxScan.Location = new System.Drawing.Point(61, 151);
            this.picboxScan.Name = "picboxScan";
            this.picboxScan.Size = new System.Drawing.Size(180, 38);
            this.picboxScan.TabIndex = 85;
            this.picboxScan.TabStop = false;
            this.picboxScan.Tag = "Scan Image";
            this.picboxScan.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxScan.Click += new System.EventHandler(this.picboxScan_Click);
            this.picboxScan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxScan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxScan.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // rdbtnBW
            // 
            this.rdbtnBW.AutoSize = true;
            this.rdbtnBW.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnBW.Location = new System.Drawing.Point(44, 93);
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
            this.lbResolution.Location = new System.Drawing.Point(38, 122);
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
            this.rdbtnColor.Location = new System.Drawing.Point(194, 93);
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
            this.lbPixelType.Location = new System.Drawing.Point(40, 68);
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
            this.lbSelectSource.Location = new System.Drawing.Point(38, 10);
            this.lbSelectSource.Name = "lbSelectSource";
            this.lbSelectSource.Size = new System.Drawing.Size(83, 15);
            this.lbSelectSource.TabIndex = 84;
            this.lbSelectSource.Text = "Scanner Source :";
            // 
            // cbxSource
            // 
            this.cbxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSource.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(40, 34);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(216, 22);
            this.cbxSource.TabIndex = 639;
            // 
            // panelReadBarcode
            // 
            this.panelReadBarcode.BackColor = System.Drawing.Color.Transparent;
            this.panelReadBarcode.Controls.Add(this.picboxReadBarcode);
            this.panelReadBarcode.Controls.Add(this.label6);
            this.panelReadBarcode.Controls.Add(this.label7);
            this.panelReadBarcode.Controls.Add(this.tbxBottom);
            this.panelReadBarcode.Controls.Add(this.tbxMaxBarcodeReads);
            this.panelReadBarcode.Controls.Add(this.cbxBarcodeFormat);
            this.panelReadBarcode.Controls.Add(this.tbxTop);
            this.panelReadBarcode.Controls.Add(this.label8);
            this.panelReadBarcode.Controls.Add(this.label9);
            this.panelReadBarcode.Controls.Add(this.tbxRight);
            this.panelReadBarcode.Controls.Add(this.label10);
            this.panelReadBarcode.Controls.Add(this.label11);
            this.panelReadBarcode.Controls.Add(this.tbxLeft);
            this.panelReadBarcode.Controls.Add(this.label12);
            this.panelReadBarcode.Location = new System.Drawing.Point(1, 41);
            this.panelReadBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.panelReadBarcode.Name = "panelReadBarcode";
            this.panelReadBarcode.Size = new System.Drawing.Size(300, 225);
            this.panelReadBarcode.TabIndex = 2;
            this.panelReadBarcode.Visible = false;
            // 
            // picboxReadBarcode
            // 
            this.picboxReadBarcode.Image = global::Barcode_Reader_Demo.Properties.Resources.picboxReadBarcode_Disabled;
            this.picboxReadBarcode.Location = new System.Drawing.Point(58, 176);
            this.picboxReadBarcode.Name = "picboxReadBarcode";
            this.picboxReadBarcode.Size = new System.Drawing.Size(180, 38);
            this.picboxReadBarcode.TabIndex = 15;
            this.picboxReadBarcode.TabStop = false;
            this.picboxReadBarcode.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxReadBarcode.Click += new System.EventHandler(this.picboxReadBarcode_Click);
            this.picboxReadBarcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxReadBarcode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxReadBarcode.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Barcode Format :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Maximum Barcode Reads :";
            // 
            // tbxBottom
            // 
            this.tbxBottom.Location = new System.Drawing.Point(202, 141);
            this.tbxBottom.Name = "tbxBottom";
            this.tbxBottom.ReadOnly = true;
            this.tbxBottom.Size = new System.Drawing.Size(60, 20);
            this.tbxBottom.TabIndex = 649;
            // 
            // tbxMaxBarcodeReads
            // 
            this.tbxMaxBarcodeReads.Location = new System.Drawing.Point(202, 47);
            this.tbxMaxBarcodeReads.Name = "tbxMaxBarcodeReads";
            this.tbxMaxBarcodeReads.Size = new System.Drawing.Size(50, 20);
            this.tbxMaxBarcodeReads.TabIndex = 645;
            this.tbxMaxBarcodeReads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBarcodeLocation_KeyPress);
            this.tbxMaxBarcodeReads.KeyUp += TbxMaxBarcodeReadsOnKeyUp;
            // 
            // cbxBarcodeFormat
            // 
            this.cbxBarcodeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBarcodeFormat.FormattingEnabled = true;
            this.cbxBarcodeFormat.ItemHeight = 15;
            this.cbxBarcodeFormat.Location = new System.Drawing.Point(140, 11);
            this.cbxBarcodeFormat.Name = "cbxBarcodeFormat";
            this.cbxBarcodeFormat.Size = new System.Drawing.Size(106, 21);
            this.cbxBarcodeFormat.TabIndex = 644;
            this.cbxBarcodeFormat.SelectedIndexChanged += new System.EventHandler(this.cbxBarcodeFormat_SelectedIndexChanged);
            // 
            // tbxTop
            // 
            this.tbxTop.Location = new System.Drawing.Point(75, 141);
            this.tbxTop.Name = "tbxTop";
            this.tbxTop.ReadOnly = true;
            this.tbxTop.Size = new System.Drawing.Size(60, 20);
            this.tbxTop.TabIndex = 648;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Selected Rectangle Area Of the Image :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Left :";
            // 
            // tbxRight
            // 
            this.tbxRight.Location = new System.Drawing.Point(202, 106);
            this.tbxRight.Name = "tbxRight";
            this.tbxRight.ReadOnly = true;
            this.tbxRight.Size = new System.Drawing.Size(60, 20);
            this.tbxRight.TabIndex = 647;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(146, 109);
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
            this.label11.Location = new System.Drawing.Point(38, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Top :";
            // 
            // tbxLeft
            // 
            this.tbxLeft.Location = new System.Drawing.Point(74, 107);
            this.tbxLeft.Name = "tbxLeft";
            this.tbxLeft.ReadOnly = true;
            this.tbxLeft.Size = new System.Drawing.Size(60, 20);
            this.tbxLeft.TabIndex = 646;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(146, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 10;
            this.label12.Text = "Bottom :";
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
            this.picboxFit.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxFit.Click += new System.EventHandler(this.picboxFit_Click);
            this.picboxFit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxFit.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxFit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxFit.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
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
            this.picboxOriginalSize.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxOriginalSize.Click += new System.EventHandler(this.picboxOriginalSize_Click);
            this.picboxOriginalSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxOriginalSize.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxOriginalSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxOriginalSize.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // webCamTimer
            // 
            this.timerWebCam.Interval = 40;
            this.timerWebCam.Tick += new System.EventHandler(this.timerWebCam_Tick);
            // 
            // DotNetTWAINDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Barcode_Reader_Demo.Properties.Resources.main_bg;
            this.ClientSize = new System.Drawing.Size(898, 698);
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
            this.Controls.Add(this.dynamicDotNetTwain);
            this.Controls.Add(this.picBoxWebCam);
            this.Controls.Add(this.panelResult);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarcodeReaderDemo";
            this.Text = "Dynamsoft Barcode Reader Demo";
            this.Load += new System.EventHandler(this.DotNetTWAINDemo_Load);
           
            this.StartPosition = FormStartPosition.CenterScreen;
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
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWebCam)).EndInit();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxResultTitle)).EndInit();
            this.panelWebCam.ResumeLayout(false);
            this.panelWebCam.PerformLayout();
            this.panelLoad.ResumeLayout(false);
            this.panelLoad.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoadImage)).EndInit();
            this.panelAcquire.ResumeLayout(false);
            this.panelAcquire.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScan)).EndInit();
            this.panelReadBarcode.ResumeLayout(false);
            this.panelReadBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxReadBarcode)).EndInit();
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
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain;
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
        private System.Windows.Forms.Panel panelReadBarcode;
        private System.Windows.Forms.PictureBox picboxFit;
        private System.Windows.Forms.PictureBox picboxOriginalSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Timer timerWebCam;
        private System.Windows.Forms.PictureBox picBoxWebCam;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.PictureBox picboxResultTitle;
        private System.Windows.Forms.Label lblCloseResult;
        private System.Windows.Forms.RichTextBox rtbBarcodeResult;
    }
}

