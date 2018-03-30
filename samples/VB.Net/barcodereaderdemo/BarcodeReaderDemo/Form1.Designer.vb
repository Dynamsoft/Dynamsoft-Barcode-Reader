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
        Me.btnOpenImage = New System.Windows.Forms.Button()
        Me.imageViewer = New System.Windows.Forms.PictureBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.lbDiv = New System.Windows.Forms.Label()
        Me.picboxPrevious = New System.Windows.Forms.PictureBox()
        Me.picboxNext = New System.Windows.Forms.PictureBox()
        Me.picboxLast = New System.Windows.Forms.PictureBox()
        Me.tbxCurrentImageIndex = New System.Windows.Forms.TextBox()
        Me.tbxTotalImageNum = New System.Windows.Forms.TextBox()
        Me.picboxFirst = New System.Windows.Forms.PictureBox()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.tbResults = New System.Windows.Forms.TextBox()
        Me.gbBarcodeType = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.chkFitWindow = New System.Windows.Forms.CheckBox()
        CType(Me.imageViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.picboxPrevious, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxLast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxFirst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBarcodeType.SuspendLayout()
        Me.SuspendLayout()
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
        'btnRead
        '
        Me.btnRead.AutoSize = True
        Me.btnRead.Enabled = False
        Me.btnRead.Location = New System.Drawing.Point(469, 170)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(94, 23)
        Me.btnRead.TabIndex = 91
        Me.btnRead.Text = "Read Barcodes"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'tbResults
        '
        Me.tbResults.Location = New System.Drawing.Point(469, 207)
        Me.tbResults.Multiline = True
        Me.tbResults.Name = "tbResults"
        Me.tbResults.ReadOnly = True
        Me.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbResults.Size = New System.Drawing.Size(312, 393)
        Me.tbResults.TabIndex = 92
        Me.tbResults.TabStop = False
        '
        'gbBarcodeType
        '
        Me.gbBarcodeType.Controls.Add(Me.Label2)
        Me.gbBarcodeType.Controls.Add(Me.ComboBox1)
        Me.gbBarcodeType.Location = New System.Drawing.Point(469, 54)
        Me.gbBarcodeType.Name = "gbBarcodeType"
        Me.gbBarcodeType.Size = New System.Drawing.Size(312, 100)
        Me.gbBarcodeType.TabIndex = 88
        Me.gbBarcodeType.TabStop = False
        Me.gbBarcodeType.Text = "Settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Barcode Format:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(97, 39)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(206, 21)
        Me.ComboBox1.TabIndex = 0
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
    Private WithEvents btnOpenImage As System.Windows.Forms.Button
    Private WithEvents imageViewer As System.Windows.Forms.PictureBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents lbDiv As System.Windows.Forms.Label
    Private WithEvents picboxPrevious As System.Windows.Forms.PictureBox
    Private WithEvents picboxNext As System.Windows.Forms.PictureBox
    Private WithEvents picboxLast As System.Windows.Forms.PictureBox
    Private WithEvents tbxCurrentImageIndex As System.Windows.Forms.TextBox
    Private WithEvents tbxTotalImageNum As System.Windows.Forms.TextBox
    Private WithEvents picboxFirst As System.Windows.Forms.PictureBox
    Private WithEvents btnRead As System.Windows.Forms.Button
    Private WithEvents tbResults As System.Windows.Forms.TextBox
    Private WithEvents gbBarcodeType As System.Windows.Forms.GroupBox
    Private WithEvents chkFitWindow As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

End Class
