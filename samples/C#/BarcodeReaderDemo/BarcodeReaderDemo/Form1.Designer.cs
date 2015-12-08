namespace BarcodeReaderDemo_CSharp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.chkFitWindow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaximumNum = new System.Windows.Forms.TextBox();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.tbxTotalImageNum = new System.Windows.Forms.TextBox();
            this.tbxCurrentImageIndex = new System.Windows.Forms.TextBox();
            this.lbDiv = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageViewer = new System.Windows.Forms.PictureBox();
            this.picboxPrevious = new System.Windows.Forms.PictureBox();
            this.picboxNext = new System.Windows.Forms.PictureBox();
            this.picboxLast = new System.Windows.Forms.PictureBox();
            this.picboxFirst = new System.Windows.Forms.PictureBox();
            this.gbBarcodeType = new System.Windows.Forms.GroupBox();
            this.chkDatamatrix = new System.Windows.Forms.CheckBox();
            this.chkPDF417 = new System.Windows.Forms.CheckBox();
            this.chkQRCode = new System.Windows.Forms.CheckBox();
            this.chkIndustrial25 = new System.Windows.Forms.CheckBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.chkEAN8 = new System.Windows.Forms.CheckBox();
            this.chkEAN13 = new System.Windows.Forms.CheckBox();
            this.chkUPCE = new System.Windows.Forms.CheckBox();
            this.chkUPCA = new System.Windows.Forms.CheckBox();
            this.chkITF = new System.Windows.Forms.CheckBox();
            this.chkCodabar = new System.Windows.Forms.CheckBox();
            this.chkCode93 = new System.Windows.Forms.CheckBox();
            this.chkCode128 = new System.Windows.Forms.CheckBox();
            this.chkCode39 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFirst)).BeginInit();
            this.gbBarcodeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.AutoSize = true;
            this.btnOpenImage.Location = new System.Drawing.Point(468, 20);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(84, 23);
            this.btnOpenImage.TabIndex = 0;
            this.btnOpenImage.Text = "Open Image...";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // chkFitWindow
            // 
            this.chkFitWindow.AutoSize = true;
            this.chkFitWindow.Location = new System.Drawing.Point(701, 24);
            this.chkFitWindow.Name = "chkFitWindow";
            this.chkFitWindow.Size = new System.Drawing.Size(79, 17);
            this.chkFitWindow.TabIndex = 1;
            this.chkFitWindow.Text = "Fit Window";
            this.chkFitWindow.UseVisualStyleBackColor = true;
            this.chkFitWindow.CheckedChanged += new System.EventHandler(this.chkFitWindow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Maximum Number:";
            // 
            // tbMaximumNum
            // 
            this.tbMaximumNum.Location = new System.Drawing.Point(568, 223);
            this.tbMaximumNum.Name = "tbMaximumNum";
            this.tbMaximumNum.Size = new System.Drawing.Size(212, 20);
            this.tbMaximumNum.TabIndex = 4;
            this.tbMaximumNum.Text = "100";
            this.tbMaximumNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMaximumNum_KeyPress);
            // 
            // tbResults
            // 
            this.tbResults.Location = new System.Drawing.Point(468, 287);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.Size = new System.Drawing.Size(312, 313);
            this.tbResults.TabIndex = 7;
            this.tbResults.TabStop = false;
            // 
            // btnRead
            // 
            this.btnRead.AutoSize = true;
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(468, 253);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(94, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read Barcodes";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbxTotalImageNum
            // 
            this.tbxTotalImageNum.Enabled = false;
            this.tbxTotalImageNum.Location = new System.Drawing.Point(243, 577);
            this.tbxTotalImageNum.Name = "tbxTotalImageNum";
            this.tbxTotalImageNum.ReadOnly = true;
            this.tbxTotalImageNum.Size = new System.Drawing.Size(61, 20);
            this.tbxTotalImageNum.TabIndex = 84;
            this.tbxTotalImageNum.Text = "0";
            // 
            // tbxCurrentImageIndex
            // 
            this.tbxCurrentImageIndex.Enabled = false;
            this.tbxCurrentImageIndex.Location = new System.Drawing.Point(159, 577);
            this.tbxCurrentImageIndex.Name = "tbxCurrentImageIndex";
            this.tbxCurrentImageIndex.ReadOnly = true;
            this.tbxCurrentImageIndex.Size = new System.Drawing.Size(61, 20);
            this.tbxCurrentImageIndex.TabIndex = 83;
            this.tbxCurrentImageIndex.Text = "0";
            this.tbxCurrentImageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbDiv
            // 
            this.lbDiv.AutoSize = true;
            this.lbDiv.BackColor = System.Drawing.Color.Transparent;
            this.lbDiv.Location = new System.Drawing.Point(227, 580);
            this.lbDiv.Name = "lbDiv";
            this.lbDiv.Size = new System.Drawing.Size(12, 13);
            this.lbDiv.TabIndex = 82;
            this.lbDiv.Text = "/";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.imageViewer);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 559);
            this.panel1.TabIndex = 85;
            // 
            // imageViewer
            // 
            this.imageViewer.Location = new System.Drawing.Point(0, 1);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(0, 0);
            this.imageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageViewer.TabIndex = 86;
            this.imageViewer.TabStop = false;
            // 
            // picboxPrevious
            // 
            this.picboxPrevious.Enabled = false;
            this.picboxPrevious.Image = ((System.Drawing.Image)(resources.GetObject("picboxPrevious.Image")));
            this.picboxPrevious.Location = new System.Drawing.Point(103, 575);
            this.picboxPrevious.Name = "picboxPrevious";
            this.picboxPrevious.Size = new System.Drawing.Size(50, 25);
            this.picboxPrevious.TabIndex = 81;
            this.picboxPrevious.TabStop = false;
            this.picboxPrevious.Tag = "Previous Image";
            this.picboxPrevious.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxPrevious.Click += new System.EventHandler(this.picboxPrevious_Click);
            this.picboxPrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxPrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxPrevious.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // picboxNext
            // 
            this.picboxNext.Enabled = false;
            this.picboxNext.Image = ((System.Drawing.Image)(resources.GetObject("picboxNext.Image")));
            this.picboxNext.Location = new System.Drawing.Point(310, 575);
            this.picboxNext.Name = "picboxNext";
            this.picboxNext.Size = new System.Drawing.Size(50, 25);
            this.picboxNext.TabIndex = 80;
            this.picboxNext.TabStop = false;
            this.picboxNext.Tag = "Next Image";
            this.picboxNext.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxNext.Click += new System.EventHandler(this.picboxNext_Click);
            this.picboxNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxNext.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // picboxLast
            // 
            this.picboxLast.Enabled = false;
            this.picboxLast.Image = ((System.Drawing.Image)(resources.GetObject("picboxLast.Image")));
            this.picboxLast.Location = new System.Drawing.Point(366, 575);
            this.picboxLast.Name = "picboxLast";
            this.picboxLast.Size = new System.Drawing.Size(50, 25);
            this.picboxLast.TabIndex = 79;
            this.picboxLast.TabStop = false;
            this.picboxLast.Tag = "Last Image";
            this.picboxLast.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxLast.Click += new System.EventHandler(this.picboxLast_Click);
            this.picboxLast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxLast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxLast.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // picboxFirst
            // 
            this.picboxFirst.Enabled = false;
            this.picboxFirst.Image = ((System.Drawing.Image)(resources.GetObject("picboxFirst.Image")));
            this.picboxFirst.Location = new System.Drawing.Point(47, 575);
            this.picboxFirst.Name = "picboxFirst";
            this.picboxFirst.Size = new System.Drawing.Size(50, 25);
            this.picboxFirst.TabIndex = 78;
            this.picboxFirst.TabStop = false;
            this.picboxFirst.Tag = "First Image";
            this.picboxFirst.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxFirst.Click += new System.EventHandler(this.picboxFirst_Click);
            this.picboxFirst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            this.picboxFirst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxFirst.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            // 
            // gbBarcodeType
            // 
            this.gbBarcodeType.Controls.Add(this.chkDatamatrix);
            this.gbBarcodeType.Controls.Add(this.chkPDF417);
            this.gbBarcodeType.Controls.Add(this.chkQRCode);
            this.gbBarcodeType.Controls.Add(this.chkIndustrial25);
            this.gbBarcodeType.Controls.Add(this.btnSelectAll);
            this.gbBarcodeType.Controls.Add(this.chkEAN8);
            this.gbBarcodeType.Controls.Add(this.chkEAN13);
            this.gbBarcodeType.Controls.Add(this.chkUPCE);
            this.gbBarcodeType.Controls.Add(this.chkUPCA);
            this.gbBarcodeType.Controls.Add(this.chkITF);
            this.gbBarcodeType.Controls.Add(this.chkCodabar);
            this.gbBarcodeType.Controls.Add(this.chkCode93);
            this.gbBarcodeType.Controls.Add(this.chkCode128);
            this.gbBarcodeType.Controls.Add(this.chkCode39);
            this.gbBarcodeType.Location = new System.Drawing.Point(468, 54);
            this.gbBarcodeType.Name = "gbBarcodeType";
            this.gbBarcodeType.Size = new System.Drawing.Size(312, 160);
            this.gbBarcodeType.TabIndex = 2;
            this.gbBarcodeType.TabStop = false;
            this.gbBarcodeType.Text = "Barcode Type";
            // 
            // chkDatamatrix
            // 
            this.chkDatamatrix.AutoSize = true;
            this.chkDatamatrix.Checked = true;
            this.chkDatamatrix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDatamatrix.Location = new System.Drawing.Point(228, 76);
            this.chkDatamatrix.Name = "chkDatamatrix";
            this.chkDatamatrix.Size = new System.Drawing.Size(76, 17);
            this.chkDatamatrix.TabIndex = 12;
            this.chkDatamatrix.Text = "Datamatrix";
            this.chkDatamatrix.UseVisualStyleBackColor = true;
            this.chkDatamatrix.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkPDF417
            // 
            this.chkPDF417.AutoSize = true;
            this.chkPDF417.Checked = true;
            this.chkPDF417.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPDF417.Location = new System.Drawing.Point(228, 50);
            this.chkPDF417.Name = "chkPDF417";
            this.chkPDF417.Size = new System.Drawing.Size(65, 17);
            this.chkPDF417.TabIndex = 11;
            this.chkPDF417.Text = "PDF417";
            this.chkPDF417.UseVisualStyleBackColor = true;
            this.chkPDF417.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkQRCode
            // 
            this.chkQRCode.AutoSize = true;
            this.chkQRCode.Checked = true;
            this.chkQRCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQRCode.Location = new System.Drawing.Point(228, 24);
            this.chkQRCode.Name = "chkQRCode";
            this.chkQRCode.Size = new System.Drawing.Size(67, 17);
            this.chkQRCode.TabIndex = 10;
            this.chkQRCode.Text = "QRCode";
            this.chkQRCode.UseVisualStyleBackColor = true;
            this.chkQRCode.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkIndustrial25
            // 
            this.chkIndustrial25.AutoSize = true;
            this.chkIndustrial25.Checked = true;
            this.chkIndustrial25.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndustrial25.Location = new System.Drawing.Point(9, 129);
            this.chkIndustrial25.Name = "chkIndustrial25";
            this.chkIndustrial25.Size = new System.Drawing.Size(98, 17);
            this.chkIndustrial25.TabIndex = 4;
            this.chkIndustrial25.Text = "Industrial 2 of 5";
            this.chkIndustrial25.UseVisualStyleBackColor = true;
            this.chkIndustrial25.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AutoSize = true;
            this.btnSelectAll.Location = new System.Drawing.Point(228, 102);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 15;
            this.btnSelectAll.Text = "Unselect All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // chkEAN8
            // 
            this.chkEAN8.AutoSize = true;
            this.chkEAN8.Checked = true;
            this.chkEAN8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAN8.Location = new System.Drawing.Point(122, 76);
            this.chkEAN8.Name = "chkEAN8";
            this.chkEAN8.Size = new System.Drawing.Size(57, 17);
            this.chkEAN8.TabIndex = 7;
            this.chkEAN8.Text = "EAN-8";
            this.chkEAN8.UseVisualStyleBackColor = true;
            this.chkEAN8.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkEAN13
            // 
            this.chkEAN13.AutoSize = true;
            this.chkEAN13.Checked = true;
            this.chkEAN13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAN13.Location = new System.Drawing.Point(122, 102);
            this.chkEAN13.Name = "chkEAN13";
            this.chkEAN13.Size = new System.Drawing.Size(63, 17);
            this.chkEAN13.TabIndex = 8;
            this.chkEAN13.Text = "EAN-13";
            this.chkEAN13.UseVisualStyleBackColor = true;
            this.chkEAN13.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkUPCE
            // 
            this.chkUPCE.AutoSize = true;
            this.chkUPCE.Checked = true;
            this.chkUPCE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUPCE.Location = new System.Drawing.Point(122, 50);
            this.chkUPCE.Name = "chkUPCE";
            this.chkUPCE.Size = new System.Drawing.Size(58, 17);
            this.chkUPCE.TabIndex = 6;
            this.chkUPCE.Text = "UPC-E";
            this.chkUPCE.UseVisualStyleBackColor = true;
            this.chkUPCE.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkUPCA
            // 
            this.chkUPCA.AutoSize = true;
            this.chkUPCA.Checked = true;
            this.chkUPCA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUPCA.Location = new System.Drawing.Point(121, 24);
            this.chkUPCA.Name = "chkUPCA";
            this.chkUPCA.Size = new System.Drawing.Size(58, 17);
            this.chkUPCA.TabIndex = 5;
            this.chkUPCA.Text = "UPC-A";
            this.chkUPCA.UseVisualStyleBackColor = true;
            this.chkUPCA.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkITF
            // 
            this.chkITF.AutoSize = true;
            this.chkITF.Checked = true;
            this.chkITF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkITF.Location = new System.Drawing.Point(122, 129);
            this.chkITF.Name = "chkITF";
            this.chkITF.Size = new System.Drawing.Size(109, 17);
            this.chkITF.TabIndex = 9;
            this.chkITF.Text = "Interleaved 2 of 5";
            this.chkITF.UseVisualStyleBackColor = true;
            this.chkITF.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCodabar
            // 
            this.chkCodabar.AutoSize = true;
            this.chkCodabar.Checked = true;
            this.chkCodabar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCodabar.Location = new System.Drawing.Point(9, 102);
            this.chkCodabar.Name = "chkCodabar";
            this.chkCodabar.Size = new System.Drawing.Size(66, 17);
            this.chkCodabar.TabIndex = 3;
            this.chkCodabar.Text = "Codabar";
            this.chkCodabar.UseVisualStyleBackColor = true;
            this.chkCodabar.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCode93
            // 
            this.chkCode93.AutoSize = true;
            this.chkCode93.Checked = true;
            this.chkCode93.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode93.Location = new System.Drawing.Point(9, 76);
            this.chkCode93.Name = "chkCode93";
            this.chkCode93.Size = new System.Drawing.Size(66, 17);
            this.chkCode93.TabIndex = 2;
            this.chkCode93.Text = "Code 93";
            this.chkCode93.UseVisualStyleBackColor = true;
            this.chkCode93.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCode128
            // 
            this.chkCode128.AutoSize = true;
            this.chkCode128.Checked = true;
            this.chkCode128.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode128.Location = new System.Drawing.Point(9, 50);
            this.chkCode128.Name = "chkCode128";
            this.chkCode128.Size = new System.Drawing.Size(72, 17);
            this.chkCode128.TabIndex = 1;
            this.chkCode128.Text = "Code 128";
            this.chkCode128.UseVisualStyleBackColor = true;
            this.chkCode128.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCode39
            // 
            this.chkCode39.AutoSize = true;
            this.chkCode39.Checked = true;
            this.chkCode39.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode39.Location = new System.Drawing.Point(9, 24);
            this.chkCode39.Name = "chkCode39";
            this.chkCode39.Size = new System.Drawing.Size(66, 17);
            this.chkCode39.TabIndex = 0;
            this.chkCode39.Text = "Code 39";
            this.chkCode39.UseVisualStyleBackColor = true;
            this.chkCode39.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbxTotalImageNum);
            this.Controls.Add(this.tbxCurrentImageIndex);
            this.Controls.Add(this.lbDiv);
            this.Controls.Add(this.picboxPrevious);
            this.Controls.Add(this.picboxNext);
            this.Controls.Add(this.picboxLast);
            this.Controls.Add(this.picboxFirst);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.tbMaximumNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbBarcodeType);
            this.Controls.Add(this.chkFitWindow);
            this.Controls.Add(this.btnOpenImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BarcodeReaderDemo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFirst)).EndInit();
            this.gbBarcodeType.ResumeLayout(false);
            this.gbBarcodeType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.CheckBox chkFitWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaximumNum;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbxTotalImageNum;
        private System.Windows.Forms.TextBox tbxCurrentImageIndex;
        private System.Windows.Forms.Label lbDiv;
        private System.Windows.Forms.PictureBox picboxPrevious;
        private System.Windows.Forms.PictureBox picboxNext;
        private System.Windows.Forms.PictureBox picboxLast;
        private System.Windows.Forms.PictureBox picboxFirst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imageViewer;
        private System.Windows.Forms.GroupBox gbBarcodeType;
        private System.Windows.Forms.CheckBox chkQRCode;
        private System.Windows.Forms.CheckBox chkIndustrial25;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.CheckBox chkEAN8;
        private System.Windows.Forms.CheckBox chkEAN13;
        private System.Windows.Forms.CheckBox chkUPCE;
        private System.Windows.Forms.CheckBox chkUPCA;
        private System.Windows.Forms.CheckBox chkITF;
        private System.Windows.Forms.CheckBox chkCodabar;
        private System.Windows.Forms.CheckBox chkCode93;
        private System.Windows.Forms.CheckBox chkCode128;
        private System.Windows.Forms.CheckBox chkCode39;
        private System.Windows.Forms.CheckBox chkDatamatrix;
        private System.Windows.Forms.CheckBox chkPDF417;
    }
}

