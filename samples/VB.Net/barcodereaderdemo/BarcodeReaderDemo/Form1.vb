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
    Private m_barcodes As TextResult() = Nothing
    Private m_index As Integer = -1
    Private filePath As String = Nothing
    Private lastOpenedDirectory As String = Application.ExecutablePath
    Private templateFilePath As String = Application.ExecutablePath
    Private Const iFormatCount As Integer = 13
    Private reader As BarcodeReader = New Dynamsoft.Barcode.BarcodeReader()
    'Private mBarcodeType As String() = {"All_DEFAULT", "OneD_DEFAULT", "QR_CODE_DEFAULT", "PDF417_DEFAULT", "DATAMATRIX_DEFAULT", "CODE_39_DEFAULT", "CODE_128_DEFAULT", "CODE_93_DEFAULT", "CODABAR_DEFAULT", "ITF_DEFAULT", "INDUSTRIAL_25_DEFAULT", "EAN_13_DEFAULT", "EAN_8_DEFAULT", "UPC_A_DEFAULT", "UPC_E_DEFAULT"}
    Private mBarcodeFormat As Integer = EnumBarcodeFormat.All
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
        'Try
        '    Dim mSettingsPath As String = "Put the full path of settings file here"
        '    reader.LoadSettingsFromFile(mSettingsPath)
        'Catch ex As Exception
        '    MessageBox.Show("Failed to load the settings file, please check the file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        If (index > 0) Then
            lastOpenedDirectory += "Images\"
        End If
        If (Not System.IO.Directory.Exists(lastOpenedDirectory)) Then
            lastOpenedDirectory = ""
        End If
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("OneD")
        ComboBox1.Items.Add("QRCode")
        ComboBox1.Items.Add("PDF417")
        ComboBox1.Items.Add("Datamatrix")
        ComboBox1.Items.Add("Code 39")
        ComboBox1.Items.Add("Code 128")
        ComboBox1.Items.Add("Code 93")
        ComboBox1.Items.Add("Codabar")
        ComboBox1.Items.Add("Interleaved 2 of 5")
        ComboBox1.Items.Add("Industrial 2 of 5")
        ComboBox1.Items.Add("EAN-13")
        ComboBox1.Items.Add("EAN-8")
        ComboBox1.Items.Add("UPC-A")
        ComboBox1.Items.Add("UPC-E")
        ComboBox1.Items.Add("AZTEC")
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub chkFitWindow_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkFitWindow.CheckedChanged
        FitWindow = chkFitWindow.Checked
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
                If dlg.FileName.Length > 4 And dlg.FileName.Contains(".") Then
                    If dlg.FileName.Substring(dlg.FileName.LastIndexOf(".")).ToLower().EndsWith(".pdf") Then
                        MessageBox.Show("This sample doesn't support decoding PDF files.", "Barcode Reader Demo", MessageBoxButtons.OK)
                        Return
                    End If
                End If
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

                'If iPageCount > 0 And iCheckedFormatCount > 0 Then
                If iPageCount > 0 Then
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
                                    Dim barcodeResult As TextResult = m_barcodes(barcodeResults(i))
                                    If Not barcodeResult Is Nothing Then
                                        Dim rect As Rectangle = ConvertLocationPointToRect(barcodeResult.LocalizationResult.ResultPoints)
                                        g.DrawRectangle(pen, rect)
                                        Dim strText As String = "[" + (barcodeResults(i) + 1).ToString() + "]"
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


    Private Sub btnRead_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRead.Click
        If (Not imageViewer.Image Is Nothing) Then

            Try
                reader.LicenseKeys = "t0068MgAAAJbpvFwUvsodF81FjWojDo91ZYmDf3+aNdOGPOBOygS6Yte0JFqPMt/DnNMdfGS4gInUd+5RYOCX6IramuO+m4A="
                Dim beforeRead As DateTime = DateTime.Now
                Dim tempPublicParameterSettings As PublicRuntimeSettings = reader.GetRuntimeSettings()
                tempPublicParameterSettings.mBarcodeFormatIds = mBarcodeFormat
                reader.UpdateRuntimeSettings(tempPublicParameterSettings)
                Dim barcodes As TextResult() = reader.DecodeFile(filePath, "")
                Dim afterRead As DateTime = DateTime.Now
                Dim timeElapsed As Double = (afterRead - beforeRead).TotalMilliseconds
                ShowBarcodeResults(barcodes, timeElapsed)

            Catch exp As Exception
                MessageBox.Show(exp.Message, "Barcode Reader Demo", MessageBoxButtons.OK)
            Finally
            End Try
        End If
    End Sub

    Private Function ToHexString(ByVal bytData As Byte())
        Dim strHex As String
        Dim i As Integer

        strHex = ""
        For i = 0 To UBound(bytData)
            strHex = strHex & Hex(bytData(i)) & " "
        Next

        ToHexString = strHex
    End Function

    Private Sub ShowBarcodeResults(ByVal barcodeResults As TextResult(), ByVal timeElapsed As Double)
        tbResults.Clear()
        m_results.Clear()
        m_barcodes = barcodeResults

        If (Not barcodeResults Is Nothing) Then
            If barcodeResults.Length > 0 Then
                tbResults.AppendText(String.Format("Total barcode(s) found: {0}. Total cost time: {1} seconds{2}{3}", barcodeResults.Length, CType(Math.Floor(timeElapsed), Integer) / 1000.0F, vbCrLf, vbCrLf))
                Dim i As Integer
                For i = 0 To barcodeResults.Length - 1
                    Dim tempRectangle As Rectangle = ConvertLocationPointToRect(barcodeResults(i).LocalizationResult.ResultPoints)
                    tbResults.AppendText(String.Format("  Barcode: {0}{1}", (i + 1).ToString(), vbCrLf))
                    tbResults.AppendText(String.Format("    Page: {0}{1}", (barcodeResults(i).LocalizationResult.PageNumber).ToString(), vbCrLf))
                    tbResults.AppendText(String.Format("    Type: {0}{1}", barcodeResults(i).BarcodeFormat.ToString(), vbCrLf))
                    'tbResults.AppendText(String.Format("    Value: {0}{1}", barcodeResults(i).BarcodeText, vbCrLf))
                    tbResults.AppendText(AddBarcodeText(barcodeResults(i).BarcodeText))
                    tbResults.AppendText(String.Format("    Hex Data: {0}{1}", ToHexString(barcodeResults(i).BarcodeBytes), vbCrLf))
                    tbResults.AppendText(String.Format("    Region: {{Left: {0}, Top: {1}, Width: {2}, Height: {3}}}{4}", tempRectangle.Left.ToString(), _
                                                       tempRectangle.Top.ToString(), tempRectangle.Width.ToString(), tempRectangle.Height.ToString(), vbCrLf))
                    tbResults.AppendText(String.Format("    Module Size: {0}{1}", barcodeResults(i).LocalizationResult.ModuleSize, vbCrLf))
                    tbResults.AppendText(String.Format("    Angle: {0}{1}", barcodeResults(i).LocalizationResult.Angle, vbCrLf))
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
                        If Not barcodeResults(i).LocalizationResult.PageNumber = iLastPageNumber Then
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
                                m_results(iLastPageNumber) = resultsOnePage
                            End If
                            iStartIndex = i
                            iLastPageNumber = barcodeResults(i).LocalizationResult.PageNumber
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
                            m_results(iLastPageNumber) = resultsOnePage
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

    Private Function AddBarcodeText(ByVal barcodetext As String) As String
        Dim temp As String = ""
        Dim temp1 As String = barcodetext
        For j As Integer = 0 To temp1.Length - 1
            If temp1(j) = vbNullChar Then
                temp += "\"
                temp += "0"
            Else
                temp += temp1(j).ToString()
            End If
        Next

        Return String.Format("    Value: {0}" & vbCrLf, temp)
    End Function

    Private Sub tbMaximumNum_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If (Not e.KeyChar = "\b") Then
            Dim array As Byte() = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString())
            If ((Not Char.IsDigit(e.KeyChar)) Or array.LongLength = 2) Then
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



    Private Function ConvertLocationPointToRect(ByVal points As Point()) As Rectangle
        Dim left As Integer = points(0).X, top As Integer = points(0).Y, right As Integer = points(1).X, bottom As Integer = points(1).Y
        For i As Integer = 0 To points.Length - 1
            If points(i).X < left Then
                left = points(i).X
            End If

            If points(i).X > right Then
                right = points(i).X
            End If

            If points(i).Y < top Then
                top = points(i).Y
            End If

            If points(i).Y > bottom Then
                bottom = points(i).Y
            End If
        Next

        Dim temp As Rectangle = New Rectangle(left, top, (right - left), (bottom - top))
        Return temp
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        'Private mBarcodeType As String() = {"All_DEFAULT", "OneD_DEFAULT", "QR_CODE_DEFAULT", "PDF417_DEFAULT", "DATAMATRIX_DEFAULT", "CODE_39_DEFAULT", "CODE_128_DEFAULT", "CODE_93_DEFAULT", "CODABAR_DEFAULT", "ITF_DEFAULT", "INDUSTRIAL_25_DEFAULT", "EAN_13_DEFAULT", "EAN_8_DEFAULT", "UPC_A_DEFAULT", "UPC_E_DEFAULT"}
        If ComboBox1.SelectedIndex = 0 Then
            mBarcodeFormat = EnumBarcodeFormat.All
        ElseIf ComboBox1.SelectedIndex = 1 Then
            mBarcodeFormat = EnumBarcodeFormat.OneD
        ElseIf ComboBox1.SelectedIndex = 2 Then
            mBarcodeFormat = EnumBarcodeFormat.QR_CODE
        ElseIf ComboBox1.SelectedIndex = 3 Then
            mBarcodeFormat = EnumBarcodeFormat.PDF417
        ElseIf ComboBox1.SelectedIndex = 4 Then
            mBarcodeFormat = EnumBarcodeFormat.DATAMATRIX
        ElseIf ComboBox1.SelectedIndex = 5 Then
            mBarcodeFormat = EnumBarcodeFormat.CODE_39
        ElseIf ComboBox1.SelectedIndex = 6 Then
            mBarcodeFormat = EnumBarcodeFormat.CODE_128
        ElseIf ComboBox1.SelectedIndex = 7 Then
            mBarcodeFormat = EnumBarcodeFormat.CODE_93
        ElseIf ComboBox1.SelectedIndex = 8 Then
            mBarcodeFormat = EnumBarcodeFormat.CODABAR
        ElseIf ComboBox1.SelectedIndex = 9 Then
            mBarcodeFormat = EnumBarcodeFormat.ITF
        ElseIf ComboBox1.SelectedIndex = 10 Then
            mBarcodeFormat = EnumBarcodeFormat.INDUSTRIAL_25
        ElseIf ComboBox1.SelectedIndex = 11 Then
            mBarcodeFormat = EnumBarcodeFormat.EAN_13
        ElseIf ComboBox1.SelectedIndex = 12 Then
            mBarcodeFormat = EnumBarcodeFormat.EAN_8
        ElseIf ComboBox1.SelectedIndex = 13 Then
            mBarcodeFormat = EnumBarcodeFormat.UPC_A
        ElseIf ComboBox1.SelectedIndex = 14 Then
            mBarcodeFormat = EnumBarcodeFormat.UPC_E
        ElseIf ComboBox1.SelectedIndex = 15 Then
            mBarcodeFormat = EnumBarcodeFormat.AZTEC
        End If

    End Sub
End Class
