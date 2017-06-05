namespace BarcodeDocumentsProcessDemo
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbCode128 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbEAN13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCode39 = new System.Windows.Forms.Label();
            this.rdbSplit = new System.Windows.Forms.Label();
            this.rdbClassify = new System.Windows.Forms.Label();
            this.rdbRename = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.lbMinimum = new System.Windows.Forms.Label();
            this.lbSplit = new System.Windows.Forms.Label();
            this.lbClassify = new System.Windows.Forms.Label();
            this.lbRename = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picboxMode = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lbInputBrowse = new System.Windows.Forms.Label();
            this.lbOutputBrowse = new System.Windows.Forms.Label();
            this.tbInputFolder = new System.Windows.Forms.TextBox();
            this.tbOutputFolder = new System.Windows.Forms.TextBox();
            this.lbProcess = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.lbRenameContainer = new System.Windows.Forms.Label();
            this.lbSplitContainer = new System.Windows.Forms.Label();
            this.lbClassifyContainer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbUnknown = new System.Windows.Forms.Label();
            this.lbModeInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMode)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(800, 52);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbTitle_MouseDown);
            this.lbTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbTitle_MouseMove);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label14.Location = new System.Drawing.Point(28, 558);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 16);
            this.label14.TabIndex = 16;
            this.label14.Tag = "bf-qrcode";
            this.label14.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label13.Location = new System.Drawing.Point(421, 534);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 16);
            this.label13.TabIndex = 15;
            this.label13.Tag = "bf-industrial 2 of 5";
            this.label13.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label12.Location = new System.Drawing.Point(333, 534);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 16);
            this.label12.TabIndex = 14;
            this.label12.Tag = "bf-upc-e";
            this.label12.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label11.Location = new System.Drawing.Point(232, 534);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 13;
            this.label11.Tag = "bf-ean-8";
            this.label11.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label10.Location = new System.Drawing.Point(130, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 12;
            this.label10.Tag = "bf-codabar";
            this.label10.Click += new System.EventHandler(this.Format_Changed);
            // 
            // lbCode128
            // 
            this.lbCode128.BackColor = System.Drawing.Color.Transparent;
            this.lbCode128.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.lbCode128.Location = new System.Drawing.Point(28, 534);
            this.lbCode128.Name = "lbCode128";
            this.lbCode128.Size = new System.Drawing.Size(16, 16);
            this.lbCode128.TabIndex = 11;
            this.lbCode128.Tag = "bf-code 128";
            this.lbCode128.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label8.Location = new System.Drawing.Point(421, 510);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 16);
            this.label8.TabIndex = 10;
            this.label8.Tag = "bf-interleaved 2 of 5";
            this.label8.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label7.Location = new System.Drawing.Point(333, 510);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 9;
            this.label7.Tag = "bf-upc-a";
            this.label7.Click += new System.EventHandler(this.Format_Changed);
            // 
            // lbEAN13
            // 
            this.lbEAN13.BackColor = System.Drawing.Color.Transparent;
            this.lbEAN13.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.lbEAN13.Location = new System.Drawing.Point(232, 510);
            this.lbEAN13.Name = "lbEAN13";
            this.lbEAN13.Size = new System.Drawing.Size(16, 16);
            this.lbEAN13.TabIndex = 8;
            this.lbEAN13.Tag = "bf-ean-13";
            this.lbEAN13.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label5.Location = new System.Drawing.Point(130, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 7;
            this.label5.Tag = "bf-code 93";
            this.label5.Click += new System.EventHandler(this.Format_Changed);
            // 
            // lbCode39
            // 
            this.lbCode39.BackColor = System.Drawing.Color.Transparent;
            this.lbCode39.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.lbCode39.Location = new System.Drawing.Point(28, 510);
            this.lbCode39.Name = "lbCode39";
            this.lbCode39.Size = new System.Drawing.Size(16, 16);
            this.lbCode39.TabIndex = 6;
            this.lbCode39.Tag = "bf-code 39";
            this.lbCode39.Click += new System.EventHandler(this.Format_Changed);
            // 
            // rdbSplit
            // 
            this.rdbSplit.BackColor = System.Drawing.Color.Transparent;
            this.rdbSplit.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.rdbSplit.Location = new System.Drawing.Point(28, 188);
            this.rdbSplit.Name = "rdbSplit";
            this.rdbSplit.Size = new System.Drawing.Size(16, 16);
            this.rdbSplit.TabIndex = 5;
            this.rdbSplit.Tag = "split";
            this.rdbSplit.Click += new System.EventHandler(this.Mode_Changed);
            // 
            // rdbClassify
            // 
            this.rdbClassify.BackColor = System.Drawing.Color.Transparent;
            this.rdbClassify.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.rdbClassify.Location = new System.Drawing.Point(28, 269);
            this.rdbClassify.Name = "rdbClassify";
            this.rdbClassify.Size = new System.Drawing.Size(16, 16);
            this.rdbClassify.TabIndex = 4;
            this.rdbClassify.Tag = "classify";
            this.rdbClassify.Click += new System.EventHandler(this.Mode_Changed);
            // 
            // rdbRename
            // 
            this.rdbRename.BackColor = System.Drawing.Color.Transparent;
            this.rdbRename.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.rdbRename.Location = new System.Drawing.Point(28, 105);
            this.rdbRename.Name = "rdbRename";
            this.rdbRename.Size = new System.Drawing.Size(16, 16);
            this.rdbRename.TabIndex = 3;
            this.rdbRename.Tag = "rename";
            this.rdbRename.Click += new System.EventHandler(this.Mode_Changed);
            // 
            // lbClose
            // 
            this.lbClose.BackColor = System.Drawing.Color.Transparent;
            this.lbClose.Image = ((System.Drawing.Image)(resources.GetObject("lbClose.Image")));
            this.lbClose.Location = new System.Drawing.Point(758, 12);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(30, 27);
            this.lbClose.TabIndex = 2;
            this.lbClose.Tag = "close";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            this.lbClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseDown);
            this.lbClose.MouseEnter += new System.EventHandler(this.lbButton_MouseEnter);
            this.lbClose.MouseLeave += new System.EventHandler(this.lbButton_MouseLeave);
            this.lbClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseUp);
            // 
            // lbMinimum
            // 
            this.lbMinimum.BackColor = System.Drawing.Color.Transparent;
            this.lbMinimum.Image = ((System.Drawing.Image)(resources.GetObject("lbMinimum.Image")));
            this.lbMinimum.Location = new System.Drawing.Point(716, 12);
            this.lbMinimum.Name = "lbMinimum";
            this.lbMinimum.Size = new System.Drawing.Size(30, 27);
            this.lbMinimum.TabIndex = 1;
            this.lbMinimum.Tag = "minimum";
            this.lbMinimum.Click += new System.EventHandler(this.lbMinimum_Click);
            this.lbMinimum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseDown);
            this.lbMinimum.MouseEnter += new System.EventHandler(this.lbButton_MouseEnter);
            this.lbMinimum.MouseLeave += new System.EventHandler(this.lbButton_MouseLeave);
            this.lbMinimum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseUp);
            // 
            // lbSplit
            // 
            this.lbSplit.AutoSize = true;
            this.lbSplit.BackColor = System.Drawing.Color.Transparent;
            this.lbSplit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSplit.Location = new System.Drawing.Point(50, 188);
            this.lbSplit.Name = "lbSplit";
            this.lbSplit.Size = new System.Drawing.Size(37, 16);
            this.lbSplit.TabIndex = 21;
            this.lbSplit.Tag = "split";
            this.lbSplit.Text = "Split";
            this.lbSplit.Click += new System.EventHandler(this.Mode_Changed);
            this.lbSplit.MouseLeave += new System.EventHandler(this.lbMode_MouseLeave);
            this.lbSplit.MouseHover += new System.EventHandler(this.lbMode_MouseHover);
            // 
            // lbClassify
            // 
            this.lbClassify.AutoSize = true;
            this.lbClassify.BackColor = System.Drawing.Color.Transparent;
            this.lbClassify.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClassify.Location = new System.Drawing.Point(50, 269);
            this.lbClassify.Name = "lbClassify";
            this.lbClassify.Size = new System.Drawing.Size(56, 16);
            this.lbClassify.TabIndex = 20;
            this.lbClassify.Tag = "classify";
            this.lbClassify.Text = "Classify";
            this.lbClassify.Click += new System.EventHandler(this.Mode_Changed);
            this.lbClassify.MouseLeave += new System.EventHandler(this.lbMode_MouseLeave);
            this.lbClassify.MouseHover += new System.EventHandler(this.lbMode_MouseHover);
            // 
            // lbRename
            // 
            this.lbRename.AutoSize = true;
            this.lbRename.BackColor = System.Drawing.Color.Transparent;
            this.lbRename.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRename.Location = new System.Drawing.Point(50, 105);
            this.lbRename.Name = "lbRename";
            this.lbRename.Size = new System.Drawing.Size(61, 16);
            this.lbRename.TabIndex = 19;
            this.lbRename.Tag = "rename";
            this.lbRename.Text = "Rename";
            this.lbRename.Click += new System.EventHandler(this.Mode_Changed);
            this.lbRename.MouseLeave += new System.EventHandler(this.lbMode_MouseLeave);
            this.lbRename.MouseHover += new System.EventHandler(this.lbMode_MouseHover);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 54);
            this.label1.TabIndex = 22;
            this.label1.Text = "use the barcode value on the first page name";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 36);
            this.label2.TabIndex = 23;
            this.label2.Text = "as a separator to split documents";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 36);
            this.label3.TabIndex = 24;
            this.label3.Text = "classify documents";
            // 
            // picboxMode
            // 
            this.picboxMode.BackColor = System.Drawing.Color.White;
            this.picboxMode.ImageLocation = "";
            this.picboxMode.InitialImage = null;
            this.picboxMode.Location = new System.Drawing.Point(172, 96);
            this.picboxMode.Margin = new System.Windows.Forms.Padding(0);
            this.picboxMode.Name = "picboxMode";
            this.picboxMode.Size = new System.Drawing.Size(383, 225);
            this.picboxMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picboxMode.TabIndex = 25;
            this.picboxMode.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(54, 393);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 16);
            this.label17.TabIndex = 26;
            this.label17.Text = "Input Folder";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(54, 430);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 16);
            this.label18.TabIndex = 27;
            this.label18.Text = "Output Folder";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(46, 510);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 16);
            this.label21.TabIndex = 30;
            this.label21.Text = "Code 39";
            this.label21.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.DimGray;
            this.label22.Location = new System.Drawing.Point(149, 510);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 16);
            this.label22.TabIndex = 31;
            this.label22.Tag = "";
            this.label22.Text = "Code 93";
            this.label22.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.DimGray;
            this.label23.Location = new System.Drawing.Point(250, 510);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 16);
            this.label23.TabIndex = 32;
            this.label23.Text = "EAN-13";
            this.label23.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.DimGray;
            this.label24.Location = new System.Drawing.Point(352, 510);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 16);
            this.label24.TabIndex = 33;
            this.label24.Text = "UPC-A";
            this.label24.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.DimGray;
            this.label25.Location = new System.Drawing.Point(440, 510);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(118, 16);
            this.label25.TabIndex = 34;
            this.label25.Text = "Interleaved 2 of 5";
            this.label25.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.DimGray;
            this.label26.Location = new System.Drawing.Point(47, 534);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 16);
            this.label26.TabIndex = 35;
            this.label26.Text = "Code 128";
            this.label26.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.DimGray;
            this.label27.Location = new System.Drawing.Point(149, 534);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(62, 16);
            this.label27.TabIndex = 36;
            this.label27.Text = "Codabar";
            this.label27.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.DimGray;
            this.label28.Location = new System.Drawing.Point(251, 534);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(45, 16);
            this.label28.TabIndex = 37;
            this.label28.Text = "EAN-8";
            this.label28.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.Color.DimGray;
            this.label29.Location = new System.Drawing.Point(352, 534);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(47, 16);
            this.label29.TabIndex = 38;
            this.label29.Text = "UPC-E";
            this.label29.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label30.ForeColor = System.Drawing.Color.DimGray;
            this.label30.Location = new System.Drawing.Point(440, 534);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(105, 16);
            this.label30.TabIndex = 39;
            this.label30.Text = "Industrial 2 of 5";
            this.label30.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.DimGray;
            this.label31.Location = new System.Drawing.Point(47, 558);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(60, 16);
            this.label31.TabIndex = 40;
            this.label31.Text = "QRCode";
            this.label31.Click += new System.EventHandler(this.Format_Changed);
            // 
            // lbInputBrowse
            // 
            this.lbInputBrowse.BackColor = System.Drawing.Color.Transparent;
            this.lbInputBrowse.Image = ((System.Drawing.Image)(resources.GetObject("lbInputBrowse.Image")));
            this.lbInputBrowse.Location = new System.Drawing.Point(467, 387);
            this.lbInputBrowse.Name = "lbInputBrowse";
            this.lbInputBrowse.Size = new System.Drawing.Size(90, 28);
            this.lbInputBrowse.TabIndex = 41;
            this.lbInputBrowse.Tag = "browse";
            this.lbInputBrowse.Click += new System.EventHandler(this.lbInputBrowse_Click);
            this.lbInputBrowse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseDown);
            this.lbInputBrowse.MouseEnter += new System.EventHandler(this.lbButton_MouseEnter);
            this.lbInputBrowse.MouseLeave += new System.EventHandler(this.lbButton_MouseLeave);
            this.lbInputBrowse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseUp);
            // 
            // lbOutputBrowse
            // 
            this.lbOutputBrowse.BackColor = System.Drawing.Color.Transparent;
            this.lbOutputBrowse.Image = ((System.Drawing.Image)(resources.GetObject("lbOutputBrowse.Image")));
            this.lbOutputBrowse.Location = new System.Drawing.Point(467, 424);
            this.lbOutputBrowse.Name = "lbOutputBrowse";
            this.lbOutputBrowse.Size = new System.Drawing.Size(90, 28);
            this.lbOutputBrowse.TabIndex = 42;
            this.lbOutputBrowse.Tag = "browse";
            this.lbOutputBrowse.Click += new System.EventHandler(this.lbOutputBrowse_Click);
            this.lbOutputBrowse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseDown);
            this.lbOutputBrowse.MouseEnter += new System.EventHandler(this.lbButton_MouseEnter);
            this.lbOutputBrowse.MouseLeave += new System.EventHandler(this.lbButton_MouseLeave);
            this.lbOutputBrowse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseUp);
            // 
            // tbInputFolder
            // 
            this.tbInputFolder.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInputFolder.Location = new System.Drawing.Point(171, 391);
            this.tbInputFolder.Name = "tbInputFolder";
            this.tbInputFolder.Size = new System.Drawing.Size(280, 22);
            this.tbInputFolder.TabIndex = 43;
            // 
            // tbOutputFolder
            // 
            this.tbOutputFolder.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutputFolder.Location = new System.Drawing.Point(171, 428);
            this.tbOutputFolder.Name = "tbOutputFolder";
            this.tbOutputFolder.Size = new System.Drawing.Size(280, 22);
            this.tbOutputFolder.TabIndex = 44;
            // 
            // lbProcess
            // 
            this.lbProcess.BackColor = System.Drawing.Color.Transparent;
            this.lbProcess.Image = ((System.Drawing.Image)(resources.GetObject("lbProcess.Image")));
            this.lbProcess.Location = new System.Drawing.Point(207, 599);
            this.lbProcess.Name = "lbProcess";
            this.lbProcess.Size = new System.Drawing.Size(175, 27);
            this.lbProcess.TabIndex = 45;
            this.lbProcess.Tag = "start";
            this.lbProcess.Click += new System.EventHandler(this.lbProcess_Click);
            this.lbProcess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseDown);
            this.lbProcess.MouseEnter += new System.EventHandler(this.lbButton_MouseEnter);
            this.lbProcess.MouseLeave += new System.EventHandler(this.lbButton_MouseLeave);
            this.lbProcess.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbButton_MouseUp);
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLog.Location = new System.Drawing.Point(591, 81);
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(192, 499);
            this.tbLog.TabIndex = 46;
            this.tbLog.TabStop = false;
            this.tbLog.Text = "";
            // 
            // lbRenameContainer
            // 
            this.lbRenameContainer.BackColor = System.Drawing.Color.Transparent;
            this.lbRenameContainer.Location = new System.Drawing.Point(28, 105);
            this.lbRenameContainer.Name = "lbRenameContainer";
            this.lbRenameContainer.Size = new System.Drawing.Size(80, 16);
            this.lbRenameContainer.TabIndex = 47;
            this.lbRenameContainer.Tag = "rename";
            this.lbRenameContainer.Click += new System.EventHandler(this.Mode_Changed);
            // 
            // lbSplitContainer
            // 
            this.lbSplitContainer.BackColor = System.Drawing.Color.Transparent;
            this.lbSplitContainer.Location = new System.Drawing.Point(28, 188);
            this.lbSplitContainer.Name = "lbSplitContainer";
            this.lbSplitContainer.Size = new System.Drawing.Size(55, 16);
            this.lbSplitContainer.TabIndex = 48;
            this.lbSplitContainer.Tag = "split";
            this.lbSplitContainer.Click += new System.EventHandler(this.Mode_Changed);
            // 
            // lbClassifyContainer
            // 
            this.lbClassifyContainer.BackColor = System.Drawing.Color.Transparent;
            this.lbClassifyContainer.Location = new System.Drawing.Point(28, 269);
            this.lbClassifyContainer.Name = "lbClassifyContainer";
            this.lbClassifyContainer.Size = new System.Drawing.Size(75, 16);
            this.lbClassifyContainer.TabIndex = 49;
            this.lbClassifyContainer.Tag = "classify";
            this.lbClassifyContainer.Click += new System.EventHandler(this.Mode_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(149, 558);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "PDF417";
            this.label4.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label15.Location = new System.Drawing.Point(130, 558);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 16);
            this.label15.TabIndex = 50;
            this.label15.Tag = "bf-pdf417";
            this.label15.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(251, 558);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 16);
            this.label16.TabIndex = 53;
            this.label16.Text = "DataMatrix";
            this.label16.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.label19.Location = new System.Drawing.Point(232, 558);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 16);
            this.label19.TabIndex = 52;
            this.label19.Tag = "bf-datamatrix";
            this.label19.Click += new System.EventHandler(this.Format_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(353, 558);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = "Unknown";
            this.label6.Click += new System.EventHandler(this.Format_Changed);
            // 
            // lbUnknown
            // 
            this.lbUnknown.BackColor = System.Drawing.Color.Transparent;
            this.lbUnknown.Image = global::BarcodeDocumentsProcessDemo.Properties.Resources.radio_unchecked;
            this.lbUnknown.Location = new System.Drawing.Point(334, 558);
            this.lbUnknown.Name = "lbUnknown";
            this.lbUnknown.Size = new System.Drawing.Size(16, 16);
            this.lbUnknown.TabIndex = 54;
            this.lbUnknown.Tag = "bf-unknown";
            this.lbUnknown.Click += new System.EventHandler(this.Format_Changed);
            // 
            // lbModeInfo
            // 
            this.lbModeInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lbModeInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbModeInfo.Location = new System.Drawing.Point(114, 107);
            this.lbModeInfo.Name = "lbModeInfo";
            this.lbModeInfo.Size = new System.Drawing.Size(182, 56);
            this.lbModeInfo.TabIndex = 56;
            this.lbModeInfo.Text = "Classify documents into indicidual output folders by barcodes on the first pages " +
    "of the input files.";
            this.lbModeInfo.UseCompatibleTextRendering = true;
            this.lbModeInfo.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::BarcodeDocumentsProcessDemo.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(802, 640);
            this.Controls.Add(this.lbModeInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbUnknown);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lbProcess);
            this.Controls.Add(this.tbOutputFolder);
            this.Controls.Add(this.tbInputFolder);
            this.Controls.Add(this.lbOutputBrowse);
            this.Controls.Add(this.lbInputBrowse);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.picboxMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSplit);
            this.Controls.Add(this.lbClassify);
            this.Controls.Add(this.lbRename);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbCode128);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbEAN13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbCode39);
            this.Controls.Add(this.rdbSplit);
            this.Controls.Add(this.rdbClassify);
            this.Controls.Add(this.rdbRename);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.lbMinimum);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbRenameContainer);
            this.Controls.Add(this.lbClassifyContainer);
            this.Controls.Add(this.lbSplitContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Barcode Documents Process Demo";
            ((System.ComponentModel.ISupportInitialize)(this.picboxMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbMinimum;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Label rdbRename;
        private System.Windows.Forms.Label rdbClassify;
        private System.Windows.Forms.Label rdbSplit;
        private System.Windows.Forms.Label lbCode39;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbEAN13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbCode128;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbRename;
        private System.Windows.Forms.Label lbClassify;
        private System.Windows.Forms.Label lbSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picboxMode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lbInputBrowse;
        private System.Windows.Forms.Label lbOutputBrowse;
        private System.Windows.Forms.TextBox tbInputFolder;
        private System.Windows.Forms.TextBox tbOutputFolder;
        private System.Windows.Forms.Label lbProcess;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.Label lbRenameContainer;
        private System.Windows.Forms.Label lbSplitContainer;
        private System.Windows.Forms.Label lbClassifyContainer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbUnknown;
        private System.Windows.Forms.Label lbModeInfo;

    }
}

