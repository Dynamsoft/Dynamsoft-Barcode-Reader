namespace ReadBarcodeFromPDFFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
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
            this.btnRead = new System.Windows.Forms.Button();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.tbMaximumNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.gbBarcodeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image File:";
            // 
            // tbFileName
            // 
            this.tbFileName.BackColor = System.Drawing.Color.White;
            this.tbFileName.Location = new System.Drawing.Point(81, 19);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(356, 20);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.TextChanged += new System.EventHandler(this.tbFileName_TextChanged);
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
            this.gbBarcodeType.Location = new System.Drawing.Point(20, 54);
            this.gbBarcodeType.Name = "gbBarcodeType";
            this.gbBarcodeType.Size = new System.Drawing.Size(486, 132);
            this.gbBarcodeType.TabIndex = 4;
            this.gbBarcodeType.TabStop = false;
            this.gbBarcodeType.Text = "Barcode Type";
            // 
            // chkDatamatrix
            // 
            this.chkDatamatrix.AutoSize = true;
            this.chkDatamatrix.Checked = true;
            this.chkDatamatrix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDatamatrix.Location = new System.Drawing.Point(206, 97);
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
            this.chkPDF417.Location = new System.Drawing.Point(118, 97);
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
            this.chkQRCode.Location = new System.Drawing.Point(24, 97);
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
            this.chkIndustrial25.Location = new System.Drawing.Point(206, 63);
            this.chkIndustrial25.Name = "chkIndustrial25";
            this.chkIndustrial25.Size = new System.Drawing.Size(98, 17);
            this.chkIndustrial25.TabIndex = 7;
            this.chkIndustrial25.Text = "Industrial 2 of 5";
            this.chkIndustrial25.UseVisualStyleBackColor = true;
            this.chkIndustrial25.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(392, 97);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 13;
            this.btnSelectAll.Text = "Unselect All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // chkEAN8
            // 
            this.chkEAN8.AutoSize = true;
            this.chkEAN8.Checked = true;
            this.chkEAN8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAN8.Location = new System.Drawing.Point(410, 28);
            this.chkEAN8.Name = "chkEAN8";
            this.chkEAN8.Size = new System.Drawing.Size(57, 17);
            this.chkEAN8.TabIndex = 4;
            this.chkEAN8.Text = "EAN-8";
            this.chkEAN8.UseVisualStyleBackColor = true;
            this.chkEAN8.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkEAN13
            // 
            this.chkEAN13.AutoSize = true;
            this.chkEAN13.Checked = true;
            this.chkEAN13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAN13.Location = new System.Drawing.Point(410, 63);
            this.chkEAN13.Name = "chkEAN13";
            this.chkEAN13.Size = new System.Drawing.Size(63, 17);
            this.chkEAN13.TabIndex = 9;
            this.chkEAN13.Text = "EAN-13";
            this.chkEAN13.UseVisualStyleBackColor = true;
            this.chkEAN13.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkUPCE
            // 
            this.chkUPCE.AutoSize = true;
            this.chkUPCE.Checked = true;
            this.chkUPCE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUPCE.Location = new System.Drawing.Point(335, 63);
            this.chkUPCE.Name = "chkUPCE";
            this.chkUPCE.Size = new System.Drawing.Size(58, 17);
            this.chkUPCE.TabIndex = 8;
            this.chkUPCE.Text = "UPC-E";
            this.chkUPCE.UseVisualStyleBackColor = true;
            this.chkUPCE.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkUPCA
            // 
            this.chkUPCA.AutoSize = true;
            this.chkUPCA.Checked = true;
            this.chkUPCA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUPCA.Location = new System.Drawing.Point(335, 28);
            this.chkUPCA.Name = "chkUPCA";
            this.chkUPCA.Size = new System.Drawing.Size(58, 17);
            this.chkUPCA.TabIndex = 3;
            this.chkUPCA.Text = "UPC-A";
            this.chkUPCA.UseVisualStyleBackColor = true;
            this.chkUPCA.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkITF
            // 
            this.chkITF.AutoSize = true;
            this.chkITF.Checked = true;
            this.chkITF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkITF.Location = new System.Drawing.Point(206, 28);
            this.chkITF.Name = "chkITF";
            this.chkITF.Size = new System.Drawing.Size(109, 17);
            this.chkITF.TabIndex = 2;
            this.chkITF.Text = "Interleaved 2 of 5";
            this.chkITF.UseVisualStyleBackColor = true;
            this.chkITF.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCodabar
            // 
            this.chkCodabar.AutoSize = true;
            this.chkCodabar.Checked = true;
            this.chkCodabar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCodabar.Location = new System.Drawing.Point(118, 63);
            this.chkCodabar.Name = "chkCodabar";
            this.chkCodabar.Size = new System.Drawing.Size(66, 17);
            this.chkCodabar.TabIndex = 6;
            this.chkCodabar.Text = "Codabar";
            this.chkCodabar.UseVisualStyleBackColor = true;
            this.chkCodabar.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCode93
            // 
            this.chkCode93.AutoSize = true;
            this.chkCode93.Checked = true;
            this.chkCode93.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode93.Location = new System.Drawing.Point(118, 28);
            this.chkCode93.Name = "chkCode93";
            this.chkCode93.Size = new System.Drawing.Size(66, 17);
            this.chkCode93.TabIndex = 1;
            this.chkCode93.Text = "Code 93";
            this.chkCode93.UseVisualStyleBackColor = true;
            this.chkCode93.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCode128
            // 
            this.chkCode128.AutoSize = true;
            this.chkCode128.Checked = true;
            this.chkCode128.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode128.Location = new System.Drawing.Point(22, 63);
            this.chkCode128.Name = "chkCode128";
            this.chkCode128.Size = new System.Drawing.Size(72, 17);
            this.chkCode128.TabIndex = 5;
            this.chkCode128.Text = "Code 128";
            this.chkCode128.UseVisualStyleBackColor = true;
            this.chkCode128.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // chkCode39
            // 
            this.chkCode39.AutoSize = true;
            this.chkCode39.Checked = true;
            this.chkCode39.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode39.Location = new System.Drawing.Point(22, 28);
            this.chkCode39.Name = "chkCode39";
            this.chkCode39.Size = new System.Drawing.Size(66, 17);
            this.chkCode39.TabIndex = 0;
            this.chkCode39.Text = "Code 39";
            this.chkCode39.UseVisualStyleBackColor = true;
            this.chkCode39.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(20, 243);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(94, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read Barcodes";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbResults
            // 
            this.tbResults.BackColor = System.Drawing.Color.White;
            this.tbResults.Location = new System.Drawing.Point(20, 281);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.Size = new System.Drawing.Size(486, 264);
            this.tbResults.TabIndex = 7;
            this.tbResults.TabStop = false;
            // 
            // tbMaximumNum
            // 
            this.tbMaximumNum.Location = new System.Drawing.Point(111, 207);
            this.tbMaximumNum.Name = "tbMaximumNum";
            this.tbMaximumNum.Size = new System.Drawing.Size(395, 20);
            this.tbMaximumNum.TabIndex = 5;
            this.tbMaximumNum.Text = "100";
            this.tbMaximumNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMaximumNum_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Maximum Number:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(443, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(63, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 562);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.tbMaximumNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbBarcodeType);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Read Barcode From PDF File";
            this.gbBarcodeType.ResumeLayout(false);
            this.gbBarcodeType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.GroupBox gbBarcodeType;
        private System.Windows.Forms.CheckBox chkDatamatrix;
        private System.Windows.Forms.CheckBox chkPDF417;
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
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.TextBox tbMaximumNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
    }
}

