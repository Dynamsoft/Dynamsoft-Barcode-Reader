<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chkEAN8 = New System.Windows.Forms.CheckBox
        Me.btnOpenImage = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.imageViewer = New System.Windows.Forms.PictureBox
        Me.panel1 = New System.Windows.Forms.Panel
        Me.chkEAN13 = New System.Windows.Forms.CheckBox
        Me.lbDiv = New System.Windows.Forms.Label
        Me.chkUPCE = New System.Windows.Forms.CheckBox
        Me.chkUPCA = New System.Windows.Forms.CheckBox
        Me.picboxPrevious = New System.Windows.Forms.PictureBox
        Me.picboxNext = New System.Windows.Forms.PictureBox
        Me.picboxLast = New System.Windows.Forms.PictureBox
        Me.chkITF = New System.Windows.Forms.CheckBox
        Me.tbxCurrentImageIndex = New System.Windows.Forms.TextBox
        Me.chkCodabar = New System.Windows.Forms.CheckBox
        Me.chkCode93 = New System.Windows.Forms.CheckBox
        Me.chkCode128 = New System.Windows.Forms.CheckBox
        Me.tbxTotalImageNum = New System.Windows.Forms.TextBox
        Me.picboxFirst = New System.Windows.Forms.PictureBox
        Me.chkCode39 = New System.Windows.Forms.CheckBox
        Me.btnRead = New System.Windows.Forms.Button
        Me.tbResults = New System.Windows.Forms.TextBox
        Me.tbMaximumNum = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.gbBarcodeType = New System.Windows.Forms.GroupBox
        Me.chkDatamatrix = New System.Windows.Forms.CheckBox
        Me.chkPDF417 = New System.Windows.Forms.CheckBox
        Me.chkQRCode = New System.Windows.Forms.CheckBox
        Me.chkIndustrial25 = New System.Windows.Forms.CheckBox
        Me.chkFitWindow = New System.Windows.Forms.CheckBox
        CType(Me.imageViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.picboxPrevious, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxLast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxFirst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBarcodeType.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkEAN8
        '
        Me.chkEAN8.AutoSize = True
        Me.chkEAN8.Checked = True
        Me.chkEAN8.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEAN8.Location = New System.Drawing.Point(130, 104)
        Me.chkEAN8.Name = "chkEAN8"
        Me.chkEAN8.Size = New System.Drawing.Size(57, 17)
        Me.chkEAN8.TabIndex = 8
        Me.chkEAN8.Text = "EAN-8"
        Me.chkEAN8.UseVisualStyleBackColor = True
        '
        'btnOpenImage
        '
        Me.btnOpenImage.AutoSize = True
        Me.btnOpenImage.Location = New System.Drawing.Point(469, 20)
        Me.btnOpenImage.Name = "btnOpenImage"
        Me.btnOpenImage.Size = New System.Drawing.Size(84, 23)
        Me.btnOpenImage.TabIndex = 86
        Me.btnOpenImage.Text = "Open Image..."
        Me.btnOpenImage.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.AutoSize = True
        Me.btnSelectAll.Location = New System.Drawing.Point(231, 104)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectAll.TabIndex = 15
        Me.btnSelectAll.Text = "Unselect All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'imageViewer
        '
        Me.imageViewer.Location = New System.Drawing.Point(0, 1)
        Me.imageViewer.Name = "imageViewer"
        Me.imageViewer.Size = New System.Drawing.Size(0, 0)
        Me.imageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imageViewer.TabIndex = 86
        Me.imageViewer.TabStop = False
        '
        'panel1
        '
        Me.panel1.AutoScroll = True
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.Controls.Add(Me.imageViewer)
        Me.panel1.Location = New System.Drawing.Point(13, 12)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(450, 559)
        Me.panel1.TabIndex = 100
        '
        'chkEAN13
        '
        Me.chkEAN13.AutoSize = True
        Me.chkEAN13.Checked = True
        Me.chkEAN13.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEAN13.Location = New System.Drawing.Point(130, 77)
        Me.chkEAN13.Name = "chkEAN13"
        Me.chkEAN13.Size = New System.Drawing.Size(63, 17)
        Me.chkEAN13.TabIndex = 7
        Me.chkEAN13.Text = "EAN-13"
        Me.chkEAN13.UseVisualStyleBackColor = True
        '
        'lbDiv
        '
        Me.lbDiv.AutoSize = True
        Me.lbDiv.BackColor = System.Drawing.Color.Transparent
        Me.lbDiv.Location = New System.Drawing.Point(228, 580)
        Me.lbDiv.Name = "lbDiv"
        Me.lbDiv.Size = New System.Drawing.Size(12, 13)
        Me.lbDiv.TabIndex = 97
        Me.lbDiv.Text = "/"
        '
        'chkUPCE
        '
        Me.chkUPCE.AutoSize = True
        Me.chkUPCE.Checked = True
        Me.chkUPCE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUPCE.Location = New System.Drawing.Point(130, 50)
        Me.chkUPCE.Name = "chkUPCE"
        Me.chkUPCE.Size = New System.Drawing.Size(58, 17)
        Me.chkUPCE.TabIndex = 6
        Me.chkUPCE.Text = "UPC-E"
        Me.chkUPCE.UseVisualStyleBackColor = True
        '
        'chkUPCA
        '
        Me.chkUPCA.AutoSize = True
        Me.chkUPCA.Checked = True
        Me.chkUPCA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUPCA.Location = New System.Drawing.Point(130, 24)
        Me.chkUPCA.Name = "chkUPCA"
        Me.chkUPCA.Size = New System.Drawing.Size(58, 17)
        Me.chkUPCA.TabIndex = 5
        Me.chkUPCA.Text = "UPC-A"
        Me.chkUPCA.UseVisualStyleBackColor = True
        '
        'picboxPrevious
        '
        Me.picboxPrevious.Enabled = False
        Me.picboxPrevious.Image = Global.BarcodeReaderDemo.My.Resources.Resources.picboxPrevious_Disabled
        Me.picboxPrevious.Location = New System.Drawing.Point(104, 575)
        Me.picboxPrevious.Name = "picboxPrevious"
        Me.picboxPrevious.Size = New System.Drawing.Size(50, 25)
        Me.picboxPrevious.TabIndex = 96
        Me.picboxPrevious.TabStop = False
        Me.picboxPrevious.Tag = "Previous Image"
        '
        'picboxNext
        '
        Me.picboxNext.Enabled = False
        Me.picboxNext.Image = Global.BarcodeReaderDemo.My.Resources.Resources.picboxNext_Disabled
        Me.picboxNext.Location = New System.Drawing.Point(311, 575)
        Me.picboxNext.Name = "picboxNext"
        Me.picboxNext.Size = New System.Drawing.Size(50, 25)
        Me.picboxNext.TabIndex = 95
        Me.picboxNext.TabStop = False
        Me.picboxNext.Tag = "Next Image"
        '
        'picboxLast
        '
        Me.picboxLast.Enabled = False
        Me.picboxLast.Image = Global.BarcodeReaderDemo.My.Resources.Resources.picboxLast_Disabled
        Me.picboxLast.Location = New System.Drawing.Point(367, 575)
        Me.picboxLast.Name = "picboxLast"
        Me.picboxLast.Size = New System.Drawing.Size(50, 25)
        Me.picboxLast.TabIndex = 94
        Me.picboxLast.TabStop = False
        Me.picboxLast.Tag = "Last Image"
        '
        'chkITF
        '
        Me.chkITF.AutoSize = True
        Me.chkITF.Checked = True
        Me.chkITF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkITF.Location = New System.Drawing.Point(9, 132)
        Me.chkITF.Name = "chkITF"
        Me.chkITF.Size = New System.Drawing.Size(109, 17)
        Me.chkITF.TabIndex = 4
        Me.chkITF.Text = "Interleaved 2 of 5"
        Me.chkITF.UseVisualStyleBackColor = True
        '
        'tbxCurrentImageIndex
        '
        Me.tbxCurrentImageIndex.Enabled = False
        Me.tbxCurrentImageIndex.Location = New System.Drawing.Point(160, 577)
        Me.tbxCurrentImageIndex.Name = "tbxCurrentImageIndex"
        Me.tbxCurrentImageIndex.ReadOnly = True
        Me.tbxCurrentImageIndex.Size = New System.Drawing.Size(61, 20)
        Me.tbxCurrentImageIndex.TabIndex = 98
        Me.tbxCurrentImageIndex.Text = "0"
        Me.tbxCurrentImageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkCodabar
        '
        Me.chkCodabar.AutoSize = True
        Me.chkCodabar.Checked = True
        Me.chkCodabar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCodabar.Location = New System.Drawing.Point(9, 104)
        Me.chkCodabar.Name = "chkCodabar"
        Me.chkCodabar.Size = New System.Drawing.Size(66, 17)
        Me.chkCodabar.TabIndex = 3
        Me.chkCodabar.Text = "Codabar"
        Me.chkCodabar.UseVisualStyleBackColor = True
        '
        'chkCode93
        '
        Me.chkCode93.AutoSize = True
        Me.chkCode93.Checked = True
        Me.chkCode93.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCode93.Location = New System.Drawing.Point(9, 77)
        Me.chkCode93.Name = "chkCode93"
        Me.chkCode93.Size = New System.Drawing.Size(66, 17)
        Me.chkCode93.TabIndex = 2
        Me.chkCode93.Text = "Code 93"
        Me.chkCode93.UseVisualStyleBackColor = True
        '
        'chkCode128
        '
        Me.chkCode128.AutoSize = True
        Me.chkCode128.Checked = True
        Me.chkCode128.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCode128.Location = New System.Drawing.Point(9, 50)
        Me.chkCode128.Name = "chkCode128"
        Me.chkCode128.Size = New System.Drawing.Size(72, 17)
        Me.chkCode128.TabIndex = 1
        Me.chkCode128.Text = "Code 128"
        Me.chkCode128.UseVisualStyleBackColor = True
        '
        'tbxTotalImageNum
        '
        Me.tbxTotalImageNum.Enabled = False
        Me.tbxTotalImageNum.Location = New System.Drawing.Point(244, 577)
        Me.tbxTotalImageNum.Name = "tbxTotalImageNum"
        Me.tbxTotalImageNum.ReadOnly = True
        Me.tbxTotalImageNum.Size = New System.Drawing.Size(61, 20)
        Me.tbxTotalImageNum.TabIndex = 99
        Me.tbxTotalImageNum.Text = "0"
        '
        'picboxFirst
        '
        Me.picboxFirst.Enabled = False
        Me.picboxFirst.Image = Global.BarcodeReaderDemo.My.Resources.Resources.picboxFirst_Disabled
        Me.picboxFirst.Location = New System.Drawing.Point(48, 575)
        Me.picboxFirst.Name = "picboxFirst"
        Me.picboxFirst.Size = New System.Drawing.Size(50, 25)
        Me.picboxFirst.TabIndex = 93
        Me.picboxFirst.TabStop = False
        Me.picboxFirst.Tag = "First Image"
        '
        'chkCode39
        '
        Me.chkCode39.AutoSize = True
        Me.chkCode39.Checked = True
        Me.chkCode39.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCode39.Location = New System.Drawing.Point(9, 24)
        Me.chkCode39.Name = "chkCode39"
        Me.chkCode39.Size = New System.Drawing.Size(66, 17)
        Me.chkCode39.TabIndex = 0
        Me.chkCode39.Text = "Code 39"
        Me.chkCode39.UseVisualStyleBackColor = True
        '
        'btnRead
        '
        Me.btnRead.AutoSize = True
        Me.btnRead.Enabled = False
        Me.btnRead.Location = New System.Drawing.Point(469, 253)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(94, 23)
        Me.btnRead.TabIndex = 91
        Me.btnRead.Text = "Read Barcodes"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'tbResults
        '
        Me.tbResults.Location = New System.Drawing.Point(469, 287)
        Me.tbResults.Multiline = True
        Me.tbResults.Name = "tbResults"
        Me.tbResults.ReadOnly = True
        Me.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbResults.Size = New System.Drawing.Size(312, 313)
        Me.tbResults.TabIndex = 92
        Me.tbResults.TabStop = False
        '
        'tbMaximumNum
        '
        Me.tbMaximumNum.Location = New System.Drawing.Point(569, 223)
        Me.tbMaximumNum.Name = "tbMaximumNum"
        Me.tbMaximumNum.Size = New System.Drawing.Size(212, 20)
        Me.tbMaximumNum.TabIndex = 90
        Me.tbMaximumNum.Text = "100"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(469, 226)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(94, 13)
        Me.label1.TabIndex = 89
        Me.label1.Text = "Maximum Number:"
        '
        'gbBarcodeType
        '
        Me.gbBarcodeType.Controls.Add(Me.chkDatamatrix)
        Me.gbBarcodeType.Controls.Add(Me.chkPDF417)
        Me.gbBarcodeType.Controls.Add(Me.chkQRCode)
        Me.gbBarcodeType.Controls.Add(Me.chkIndustrial25)
        Me.gbBarcodeType.Controls.Add(Me.btnSelectAll)
        Me.gbBarcodeType.Controls.Add(Me.chkEAN8)
        Me.gbBarcodeType.Controls.Add(Me.chkEAN13)
        Me.gbBarcodeType.Controls.Add(Me.chkUPCE)
        Me.gbBarcodeType.Controls.Add(Me.chkUPCA)
        Me.gbBarcodeType.Controls.Add(Me.chkITF)
        Me.gbBarcodeType.Controls.Add(Me.chkCodabar)
        Me.gbBarcodeType.Controls.Add(Me.chkCode93)
        Me.gbBarcodeType.Controls.Add(Me.chkCode128)
        Me.gbBarcodeType.Controls.Add(Me.chkCode39)
        Me.gbBarcodeType.Location = New System.Drawing.Point(469, 54)
        Me.gbBarcodeType.Name = "gbBarcodeType"
        Me.gbBarcodeType.Size = New System.Drawing.Size(312, 160)
        Me.gbBarcodeType.TabIndex = 88
        Me.gbBarcodeType.TabStop = False
        Me.gbBarcodeType.Text = "Barcode Type"
        '
        'chkDatamatrix
        '
        Me.chkDatamatrix.AutoSize = True
        Me.chkDatamatrix.Checked = True
        Me.chkDatamatrix.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDatamatrix.Location = New System.Drawing.Point(231, 77)
        Me.chkDatamatrix.Name = "chkDatamatrix"
        Me.chkDatamatrix.Size = New System.Drawing.Size(76, 17)
        Me.chkDatamatrix.TabIndex = 12
        Me.chkDatamatrix.Text = "Datamatrix"
        Me.chkDatamatrix.UseVisualStyleBackColor = True
        '
        'chkPDF417
        '
        Me.chkPDF417.AutoSize = True
        Me.chkPDF417.Checked = True
        Me.chkPDF417.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPDF417.Location = New System.Drawing.Point(231, 50)
        Me.chkPDF417.Name = "chkPDF417"
        Me.chkPDF417.Size = New System.Drawing.Size(65, 17)
        Me.chkPDF417.TabIndex = 11
        Me.chkPDF417.Text = "PDF417"
        Me.chkPDF417.UseVisualStyleBackColor = True
        '
        'chkQRCode
        '
        Me.chkQRCode.AutoSize = True
        Me.chkQRCode.Checked = True
        Me.chkQRCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkQRCode.Location = New System.Drawing.Point(231, 24)
        Me.chkQRCode.Name = "chkQRCode"
        Me.chkQRCode.Size = New System.Drawing.Size(67, 17)
        Me.chkQRCode.TabIndex = 10
        Me.chkQRCode.Text = "QRCode"
        Me.chkQRCode.UseVisualStyleBackColor = True
        '
        'chkIndustrial25
        '
        Me.chkIndustrial25.AutoSize = True
        Me.chkIndustrial25.Checked = True
        Me.chkIndustrial25.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIndustrial25.Location = New System.Drawing.Point(130, 132)
        Me.chkIndustrial25.Name = "chkIndustrial25"
        Me.chkIndustrial25.Size = New System.Drawing.Size(98, 17)
        Me.chkIndustrial25.TabIndex = 9
        Me.chkIndustrial25.Text = "Industrial 2 of 5"
        Me.chkIndustrial25.UseVisualStyleBackColor = True
        '
        'chkFitWindow
        '
        Me.chkFitWindow.AutoSize = True
        Me.chkFitWindow.Location = New System.Drawing.Point(702, 24)
        Me.chkFitWindow.Name = "chkFitWindow"
        Me.chkFitWindow.Size = New System.Drawing.Size(79, 17)
        Me.chkFitWindow.TabIndex = 87
        Me.chkFitWindow.Text = "Fit Window"
        Me.chkFitWindow.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 612)
        Me.Controls.Add(Me.btnOpenImage)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.lbDiv)
        Me.Controls.Add(Me.picboxPrevious)
        Me.Controls.Add(Me.picboxNext)
        Me.Controls.Add(Me.picboxLast)
        Me.Controls.Add(Me.tbxCurrentImageIndex)
        Me.Controls.Add(Me.tbxTotalImageNum)
        Me.Controls.Add(Me.picboxFirst)
        Me.Controls.Add(Me.btnRead)
        Me.Controls.Add(Me.tbResults)
        Me.Controls.Add(Me.tbMaximumNum)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.gbBarcodeType)
        Me.Controls.Add(Me.chkFitWindow)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "BarcodeReaderDemo"
        CType(Me.imageViewer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.picboxPrevious, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxLast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxFirst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBarcodeType.ResumeLayout(False)
        Me.gbBarcodeType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkEAN8 As System.Windows.Forms.CheckBox
    Private WithEvents btnOpenImage As System.Windows.Forms.Button
    Private WithEvents btnSelectAll As System.Windows.Forms.Button
    Private WithEvents imageViewer As System.Windows.Forms.PictureBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents chkEAN13 As System.Windows.Forms.CheckBox
    Private WithEvents lbDiv As System.Windows.Forms.Label
    Private WithEvents chkUPCE As System.Windows.Forms.CheckBox
    Private WithEvents chkUPCA As System.Windows.Forms.CheckBox
    Private WithEvents picboxPrevious As System.Windows.Forms.PictureBox
    Private WithEvents picboxNext As System.Windows.Forms.PictureBox
    Private WithEvents picboxLast As System.Windows.Forms.PictureBox
    Private WithEvents chkITF As System.Windows.Forms.CheckBox
    Private WithEvents tbxCurrentImageIndex As System.Windows.Forms.TextBox
    Private WithEvents chkCodabar As System.Windows.Forms.CheckBox
    Private WithEvents chkCode93 As System.Windows.Forms.CheckBox
    Private WithEvents chkCode128 As System.Windows.Forms.CheckBox
    Private WithEvents tbxTotalImageNum As System.Windows.Forms.TextBox
    Private WithEvents picboxFirst As System.Windows.Forms.PictureBox
    Private WithEvents chkCode39 As System.Windows.Forms.CheckBox
    Private WithEvents btnRead As System.Windows.Forms.Button
    Private WithEvents tbResults As System.Windows.Forms.TextBox
    Private WithEvents tbMaximumNum As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents gbBarcodeType As System.Windows.Forms.GroupBox
    Private WithEvents chkFitWindow As System.Windows.Forms.CheckBox
    Friend WithEvents chkQRCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkIndustrial25 As System.Windows.Forms.CheckBox
    Private WithEvents chkDatamatrix As System.Windows.Forms.CheckBox
    Private WithEvents chkPDF417 As System.Windows.Forms.CheckBox

End Class
