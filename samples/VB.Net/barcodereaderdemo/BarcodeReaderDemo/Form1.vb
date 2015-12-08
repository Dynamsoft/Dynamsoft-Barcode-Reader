Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports Dynamsoft.Barcode
Imports System

Public Class Form1

    Private m_bFitWindow As Boolean = False
    Private m_data As Image = Nothing
    Private iPageCount As Integer = 0
    Private m_results As List(Of Integer()) = New List(Of Integer())()
    Private m_barcodes As BarcodeResult() = Nothing
    Private m_index As Integer = -1
    Private filePath As String = Nothing
    Private lastOpenedDirectory As String = Application.ExecutablePath
    Private Const iFormatCount As Integer = 13
    Private iCheckedFormatCount As Integer = 0

    Public Property FitWindow() As Boolean
        Get
            Return m_bFitWindow
        End Get
        Set(ByVal value As Boolean)
            If (Not m_bFitWindow = value) Then
                m_bFitWindow = value
                If (m_bFitWindow) Then
                    panel1.AutoScroll = False
                    imageViewer.SizeMode = PictureBoxSizeMode.Zoom
                    imageViewer.Dock = DockStyle.Fill
                Else
                    panel1.AutoScroll = True
                    imageViewer.SizeMode = PictureBoxSizeMode.AutoSize
                    imageViewer.Dock = DockStyle.None
                End If
                panel1.Refresh()
            End If
        End Set
    End Property

    Public Property CurrentIndex() As Integer
        Get
            Return m_index
        End Get
        Set(ByVal value As Integer)
            If (value >= 0 And value < iPageCount And (Not m_index = value)) Then
                m_index = value
                tbxCurrentImageIndex.Text = (value + 1).ToString()
            End If
            SetImageViewerImage() 'update Image property of imageviewer when Open an file(under the case, m_index may equal to value)
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        chkFitWindow.Checked = True
        lastOpenedDirectory.Replace("/", "\")
        Dim index As Integer = lastOpenedDirectory.LastIndexOf("Samples")
        If (index > 0) Then
            lastOpenedDirectory = lastOpenedDirectory.Substring(0, index)
            lastOpenedDirectory += "Images\"
        End If
        If (Not System.IO.Directory.Exists(lastOpenedDirectory)) Then
            lastOpenedDirectory = ""
        End If
    End Sub

    Private Sub chkFitWindow_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkFitWindow.CheckedChanged
        FitWindow = chkFitWindow.Checked
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
        Dim selectall As Boolean = False
        Dim count As Integer = gbBarcodeType.Controls.Count
        Dim i As Integer
        For i = 0 To count - 1 Step 1
            If (TypeOf gbBarcodeType.Controls(i) Is CheckBox) Then
                If (Not DirectCast(gbBarcodeType.Controls(i), CheckBox).Checked) Then
                    selectall = True
                    Exit For
                End If
            End If
        Next

        For i = 0 To count - 1 Step 1
            If (TypeOf gbBarcodeType.Controls(i) Is CheckBox) Then
                DirectCast(gbBarcodeType.Controls(i), CheckBox).Checked = selectall
            End If
        Next

        If selectall Then
            btnSelectAll.Text = "Unselect All"
        Else
            btnSelectAll.Text = "Select All"
        End If
    End Sub

    Declare Auto Sub CopyMemory Lib "kernel32.dll" Alias "CopyMemory" (ByVal dest As IntPtr, ByVal src As IntPtr, ByVal count As Integer)

    Function Clone(ByVal img As Bitmap, ByVal format As PixelFormat) As Bitmap
        Dim bmp As Bitmap = Nothing
        Dim data As BitmapData = Nothing
        Dim data2 As BitmapData = Nothing
        Try
            data = img.LockBits(New Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, format)
            Dim len As Integer = data.Stride * img.Height
            bmp = New Bitmap(img.Width, img.Height, format)
            data2 = bmp.LockBits(New Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, format)
            CopyMemory(data2.Scan0, data.Scan0, len)
            img.UnlockBits(data)
            bmp.UnlockBits(data2)
            data = Nothing
            data2 = Nothing
        Catch
        Finally
            If (Not data Is Nothing) Then
                img.UnlockBits(data)
            End If
            If (Not data2 Is Nothing) Then
                bmp.UnlockBits(data2)
            End If
        End Try

        Return bmp
    End Function

    Private Sub btnOpenImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpenImage.Click
        Try
            Dim dlg As OpenFileDialog = New OpenFileDialog()
            dlg.Filter = "All Supported Images(*.BMP,*.PNG,*.JPEG,*.JPG,*.JPE,*.JFIF,*.TIF,*.TIFF,*.GIF)|*.BMP;*.PNG;*.JPEG;*.JPG;*.JPE;*.JFIF;*.TIF;*.TIFF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF"
            dlg.InitialDirectory = lastOpenedDirectory
            If (dlg.ShowDialog() = DialogResult.OK) Then
                lastOpenedDirectory = System.IO.Directory.GetParent(dlg.FileName).FullName
                If Not m_data Is Nothing Then
                    m_data.Dispose()
                    m_data = Nothing
                    iPageCount = 0
                End If
                m_results.Clear()
                tbResults.Clear()

                Me.Text = dlg.FileName

                filePath = dlg.FileName
                m_data = Image.FromFile(filePath)
                Dim isGif As Boolean = m_data.RawFormat.Equals(ImageFormat.Gif)
                If isGif Then
                    iPageCount = 1
                Else
                    Dim frameGuid As Guid = m_data.FrameDimensionsList(0)
                    Dim demension As FrameDimension = New FrameDimension(frameGuid)
                    iPageCount = m_data.GetFrameCount(demension)
                End If

                If iPageCount > 0 And iCheckedFormatCount > 0 Then
                    btnRead.Enabled = True
                End If
                CurrentIndex = iPageCount - 1
                tbxTotalImageNum.Text = iPageCount.ToString()
                If (iPageCount > 1) Then
                    EnableControls(picboxFirst)
                    EnableControls(picboxPrevious)
                    'EnableControls(picboxNext);
                    'EnableControls(picboxLast);
                Else
                    DisableControls(picboxFirst)
                    DisableControls(picboxPrevious)
                    DisableControls(picboxNext)
                    DisableControls(picboxLast)
                End If
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Barcode Reader Demo", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub SetImageViewerImage()
        If Not imageViewer.Image Is Nothing Then
            Dim img As Image = imageViewer.Image
            imageViewer.Image = Nothing
            img.Dispose()
        End If

        If m_index >= 0 And m_index < iPageCount Then
            Dim bmp As Bitmap = Nothing
            If iPageCount > 1 Then
                Dim tempBmp As Bitmap = DirectCast(m_data.Clone(), Bitmap)
                tempBmp.SelectActiveFrame(FrameDimension.Page, m_index)
                Dim format As PixelFormat = tempBmp.PixelFormat
                If ((((DirectCast(tempBmp.PixelFormat, Integer)) >> 8) And 255) < 24) Then
                    format = PixelFormat.Format24bppRgb
                End If
                bmp = Clone(tempBmp, format)
                tempBmp.Dispose()
            Else
                Dim format As PixelFormat = m_data.PixelFormat
                If ((((DirectCast(m_data.PixelFormat, Integer)) >> 8) And 255) < 24) Then
                    format = PixelFormat.Format24bppRgb
                End If
                bmp = Clone(DirectCast(m_data, Bitmap), Format)
            End If

            If Not bmp Is Nothing Then
                Using g As Graphics = Graphics.FromImage(bmp)
                    If m_index < m_results.Count Then
                        Dim barcodeResults As Integer() = m_results(m_index)
                        If Not barcodeResults Is Nothing Then
                            If barcodeResults.Length > 0 Then
                                Dim fsize As Single = bmp.Width / 64.0F
                                If (fsize < 12) Then
                                    fsize = 12
                                End If
                                Dim lineWidth As Single = fsize / 6
                                If lineWidth < 1 Then
                                    lineWidth = 1
                                End If
                                Dim pen As Pen = New Pen(Color.Red, lineWidth)
                                Dim textBrush As Brush = New SolidBrush(Color.Blue)
                                Dim textFont As Font = New Font("Times New Roman", fsize, FontStyle.Bold)
                                Dim i As Integer
                                For i = barcodeResults.Length - 1 To 0 Step -1
                                    Dim barcodeResult As BarcodeResult = m_barcodes(barcodeResults(i))
                                    If Not barcodeResult Is Nothing Then
                                        Dim rect As Rectangle = barcodeResult.BoundingRect
                                        g.DrawRectangle(pen, rect)
                                        Dim strText As String = "[" + (barcodeResults(i) + 1).ToString() + "] {" + barcodeResult.BarcodeText + "}"
                                        Dim size As SizeF = g.MeasureString(strText, textFont)
                                        'int iWidth = rect.Width + (((int)textFont.Size) >> 1);
                                        Dim iHeight As Integer = (CInt(size.Height) + 1) ' *((int)(size.Width / rect.Width + 1));//textFont.Height * 3 / 2;
                                        Dim iTop As Integer = rect.Top - iHeight
                                        If iTop < 0 Then
                                            iTop = 0
                                        End If
                                        g.DrawString(strText, textFont, textBrush, New Rectangle(rect.Left, iTop, 0, iHeight), New StringFormat(StringFormatFlags.NoClip Or StringFormatFlags.NoWrap))
                                    End If
                                Next
                                pen.Dispose()
                                textBrush.Dispose()
                                textFont.Dispose()
                            End If
                        End If
                    End If

                    imageViewer.Image = bmp
                End Using
            End If
        End If
    End Sub

    Private Function GetFormats() As BarcodeFormat
        Dim formats As BarcodeFormat? = Nothing
        If (chkCode39.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.CODE_39
            Else
                formats = formats Or BarcodeFormat.CODE_39
            End If
        End If
        If (chkCode128.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.CODE_128
            Else
                formats = formats Or BarcodeFormat.CODE_128
            End If
        End If
        If (chkCode93.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.CODE_93
            Else
                formats = formats Or BarcodeFormat.CODE_93
            End If
        End If
        If (chkCodabar.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.CODABAR
            Else
                formats = formats Or BarcodeFormat.CODABAR
            End If
        End If
        If (chkITF.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.ITF
            Else
                formats = formats Or BarcodeFormat.ITF
            End If
        End If
        If (chkUPCA.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.UPC_A
            Else
                formats = formats Or BarcodeFormat.UPC_A
            End If
        End If
        If (chkUPCE.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.UPC_E
            Else
                formats = formats Or BarcodeFormat.UPC_E
            End If
        End If
        If (chkEAN8.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.EAN_8
            Else
                formats = formats Or BarcodeFormat.EAN_8
            End If
        End If
        If (chkEAN13.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.EAN_13
            Else
                formats = formats Or BarcodeFormat.EAN_13
            End If
        End If
        If (chkIndustrial25.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.INDUSTRIAL_25
            Else
                formats = formats Or BarcodeFormat.INDUSTRIAL_25
            End If
        End If
        If (chkQRCode.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.QR_CODE
            Else
                formats = formats Or BarcodeFormat.QR_CODE
            End If
        End If
        If (chkPDF417.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.PDF417
            Else
                formats = formats Or BarcodeFormat.PDF417
            End If
        End If
        If (chkDatamatrix.Checked) Then
            If (Not formats.HasValue) Then
                formats = BarcodeFormat.DATAMATRIX
            Else
                formats = formats Or BarcodeFormat.DATAMATRIX
            End If
        End If

        If Not formats.HasValue Then
            Return BarcodeFormat.OneD Or BarcodeFormat.QR_CODE Or BarcodeFormat.PDF417 Or BarcodeFormat.DATAMATRIX
        Else
            Return formats.Value
        End If
    End Function

    Private Sub btnRead_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRead.Click
        If (Not imageViewer.Image Is Nothing) Then
            'Rectangle rect = new Rectangle();
            Dim reader As BarcodeReader = New Dynamsoft.Barcode.BarcodeReader()
            Try
                reader.LicenseKeys = "38B9B94D8B0E2B41DB1CC80A58946567"
                Dim ro As ReaderOptions = New ReaderOptions()
                ro.BarcodeFormats = GetFormats()
                ro.MaxBarcodesToReadPerPage = Integer.Parse(tbMaximumNum.Text)
                reader.ReaderOptions = ro
                Dim beforeRead As DateTime = DateTime.Now
                Dim barcodes As BarcodeResult() = reader.DecodeFile(filePath)
                Dim afterRead As DateTime = DateTime.Now
                Dim timeElapsed As Double = (afterRead - beforeRead).TotalMilliseconds
                ShowBarcodeResults(barcodes, timeElapsed)
            Catch exp As Exception
                MessageBox.Show(exp.Message, "Barcode Reader Demo", MessageBoxButtons.OK)
            Finally
                'reader.Dispose()
            End Try
        End If
    End Sub

    Private Sub ShowBarcodeResults(ByVal barcodeResults As BarcodeResult(), ByVal timeElapsed As Double)
        tbResults.Clear()
        m_results.Clear()
        m_barcodes = barcodeResults

        If (Not barcodeResults Is Nothing) Then
            If barcodeResults.Length > 0 Then
                tbResults.AppendText(String.Format("Total barcode(s) found: {0}. Total cost time: {1} seconds{2}{3}", barcodeResults.Length, CType(Math.Floor(timeElapsed), Integer) / 1000.0F, vbCrLf, vbCrLf))
                Dim i As Integer
                For i = 0 To barcodeResults.Length - 1
                    tbResults.AppendText(String.Format("  Barcode: {0}{1}", (i + 1).ToString(), vbCrLf))
                    tbResults.AppendText(String.Format("    Page: {0}{1}", (barcodeResults(i).PageNumber).ToString(), vbCrLf))
                    tbResults.AppendText(String.Format("    Type: {0}{1}", barcodeResults(i).BarcodeFormat.ToString(), vbCrLf))
                    tbResults.AppendText(String.Format("    Value: {0}{1}", barcodeResults(i).BarcodeText, vbCrLf))
                    tbResults.AppendText(String.Format("    Region: {{Left: {0}, Top: {1}, Width: {2}, Height: {3}}}{4}", barcodeResults(i).BoundingRect.Left.ToString(), _
                                                       barcodeResults(i).BoundingRect.Top.ToString(), barcodeResults(i).BoundingRect.Width.ToString(), barcodeResults(i).BoundingRect.Height.ToString(), vbCrLf))
                    tbResults.AppendText(vbCrLf)
                Next
                tbResults.SelectionStart = 0
                tbResults.ScrollToCaret()

                Dim iLastPageNumber As Integer = Integer.MinValue + 10
                Dim iStartIndex As Integer = barcodeResults.Length - 1
                For i = 0 To iPageCount - 1 Step 1
                    m_results.Add(Nothing)
                Next
                For i = iStartIndex To 0 Step -1
                    If Not barcodeResults(i) Is Nothing Then
                        If Not barcodeResults(i).PageNumber = iLastPageNumber Then
                            If Not i = iStartIndex Then
                                Dim iEnd As Integer = i
                                Dim iStart As Integer = iStartIndex
                                If i > iStartIndex Then
                                    iEnd = i - 1
                                Else
                                    iEnd = i + 1
                                End If
                                If iEnd < iStart Then
                                    Dim temp As Integer = iStart
                                    iStart = iEnd
                                    iEnd = temp
                                End If

                                Dim resultsOnePage As Integer() = New Integer(iEnd - iStart) {}
                                Dim k As Integer
                                For k = iStart To iEnd Step 1
                                    resultsOnePage(k - iStart) = k
                                Next
                                m_results(iLastPageNumber - 1) = resultsOnePage
                            End If
                            iStartIndex = i
                            iLastPageNumber = barcodeResults(i).PageNumber
                        End If

                        If i = 0 Then
                            Dim iEnd As Integer = i
                            Dim iStart As Integer = iStartIndex
                            If iEnd < iStart Then
                                Dim temp As Integer = iStart
                                iStart = iEnd
                                iEnd = temp
                            End If
                            Dim resultsOnePage As Integer() = New Integer(iEnd - iStart) {}
                            Dim k As Integer
                            For k = iStart To iEnd Step 1
                                resultsOnePage(k - iStart) = k
                            Next
                            m_results(iLastPageNumber - 1) = resultsOnePage
                        End If
                    End If
                Next

            Else
                tbResults.AppendText("No barcode found. Total time spent: " + (timeElapsed / 1000).ToString() + " seconds" + vbCrLf)
            End If
        Else
            tbResults.AppendText("No barcode found. Total time spent: " + (timeElapsed / 1000).ToString() + " seconds" + vbCrLf)
        End If

        SetImageViewerImage()
    End Sub

    Private Sub tbMaximumNum_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If (Not e.KeyChar = "\b") Then
            Dim array As Byte() = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString())
            If ((Not Char.IsDigit(e.KeyChar)) Or array.LongLength = 2) Then
                e.Handled = True
            End If
            If ((tbMaximumNum.Text.Length = 0 Or tbMaximumNum.SelectionLength = tbMaximumNum.Text.Length) And e.KeyChar = "0") Then
                e.Handled = True
            End If
        End If
    End Sub

#Region "regist Event For All PictureBox Buttons"
    Private Sub picbox_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles picboxFirst.MouseEnter, picboxLast.MouseEnter, picboxNext.MouseEnter, picboxPrevious.MouseEnter
        If (TypeOf sender Is PictureBox) Then
            Dim picBox As PictureBox = DirectCast(sender, PictureBox)
            If (picBox.Enabled) Then
                picBox.Image = DirectCast(My.Resources.ResourceManager.GetObject(picBox.Name + "_Enter"), Image)
            End If
        End If
    End Sub

    Private Sub picbox_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles picboxFirst.MouseLeave, picboxLast.MouseLeave, picboxNext.MouseLeave, picboxPrevious.MouseLeave
        If (TypeOf sender Is PictureBox) Then
            Dim picBox As PictureBox = DirectCast(sender, PictureBox)
            If (picBox.Enabled) Then
                picBox.Image = DirectCast(My.Resources.ResourceManager.GetObject(picBox.Name + "_Leave"), Image)
            End If
        End If
    End Sub

    Private Sub picbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picboxFirst.MouseDown, picboxLast.MouseDown, picboxNext.MouseDown, picboxPrevious.MouseDown
        If (TypeOf sender Is PictureBox) Then
            Dim picBox As PictureBox = DirectCast(sender, PictureBox)
            If (picBox.Enabled) Then
                picBox.Image = DirectCast(My.Resources.ResourceManager.GetObject(picBox.Name + "_Down"), Image)
            End If
        End If
    End Sub

    Private Sub picbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picboxFirst.MouseUp, picboxLast.MouseUp, picboxNext.MouseUp, picboxPrevious.MouseUp
        If (TypeOf sender Is PictureBox) Then
            Dim picBox As PictureBox = DirectCast(sender, PictureBox)
            If (picBox.Enabled) Then
                picBox.Image = DirectCast(My.Resources.ResourceManager.GetObject(picBox.Name + "_Enter"), Image)
            End If
        End If
    End Sub

    Private Sub DisableControls(ByVal sender As Object)
        If (TypeOf sender Is PictureBox) Then
            Dim picBox As PictureBox = DirectCast(sender, PictureBox)
            picBox.Image = DirectCast(My.Resources.ResourceManager.GetObject(picBox.Name + "_Disabled"), Image)
            picBox.Enabled = False
        Else
            DirectCast(sender, Control).Enabled = False
        End If
    End Sub

    Private Sub EnableControls(ByVal sender As Object)
        If (TypeOf sender Is PictureBox) Then
            Dim picBox As PictureBox = DirectCast(sender, PictureBox)
            picBox.Image = DirectCast(My.Resources.ResourceManager.GetObject(picBox.Name + "_Leave"), Image)
            picBox.Enabled = True
        Else
            DirectCast(sender, Control).Enabled = True
        End If
    End Sub

    Private Sub picboxFirst_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxFirst.Click
        If (picboxFirst.Enabled) Then
            CurrentIndex = 0
            DisableControls(picboxFirst)
            DisableControls(picboxPrevious)
            EnableControls(picboxNext)
            EnableControls(picboxLast)
        End If
    End Sub

    Private Sub picboxLast_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxLast.Click
        If (picboxLast.Enabled) Then
            CurrentIndex = iPageCount - 1
            DisableControls(picboxLast)
            DisableControls(picboxNext)
            EnableControls(picboxPrevious)
            EnableControls(picboxFirst)
        End If
    End Sub

    Private Sub picboxPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxPrevious.Click
        If (picboxPrevious.Enabled) Then
            CurrentIndex = CurrentIndex - 1
            If (CurrentIndex = 0) Then
                DisableControls(picboxFirst)
                DisableControls(picboxPrevious)
            End If
            EnableControls(picboxNext)
            EnableControls(picboxLast)
        End If
    End Sub

    Private Sub picboxNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxNext.Click
        CurrentIndex = CurrentIndex + 1
        If (picboxNext.Enabled) Then
            If (CurrentIndex = iPageCount - 1) Then
                DisableControls(picboxLast)
                DisableControls(picboxNext)
            End If
            EnableControls(picboxPrevious)
            EnableControls(picboxFirst)
        End If
    End Sub

#End Region

    Private Sub chkFormat_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkCodabar.CheckedChanged, chkCode128.CheckedChanged, chkCode39.CheckedChanged, chkCode93.CheckedChanged, chkEAN13.CheckedChanged, chkEAN8.CheckedChanged, chkITF.CheckedChanged, chkUPCA.CheckedChanged, chkUPCE.CheckedChanged, chkQRCode.CheckedChanged, chkIndustrial25.CheckedChanged, chkPDF417.CheckedChanged, chkDatamatrix.CheckedChanged
        Dim chkbox As CheckBox = DirectCast(sender, CheckBox)
        If (chkbox.Checked) Then
            iCheckedFormatCount = iCheckedFormatCount + 1
        Else
            iCheckedFormatCount = iCheckedFormatCount - 1
        End If

        If (iPageCount > 0 And iCheckedFormatCount > 0) Then
            btnRead.Enabled = True
        Else
            btnRead.Enabled = False
        End If

        If (iCheckedFormatCount < iFormatCount) Then
            btnSelectAll.Text = "Select All"
        Else
            btnSelectAll.Text = "Unselect All"
        End If
    End Sub
End Class
