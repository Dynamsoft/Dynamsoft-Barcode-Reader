VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmMain 
   Caption         =   "Barcode Reader Demo"
   ClientHeight    =   8910
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8205
   LinkTopic       =   "Form1"
   ScaleHeight     =   8910
   ScaleWidth      =   8205
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox lbResults 
      Height          =   3615
      Left            =   360
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   21
      Top             =   4680
      Width           =   7575
   End
   Begin MSComDlg.CommonDialog cdOpenFileDlg 
      Left            =   0
      Top             =   8400
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton btnReadBarcode 
      Caption         =   "Read Barcodes"
      Height          =   495
      Left            =   360
      TabIndex        =   20
      Top             =   3960
      Width           =   1455
   End
   Begin VB.TextBox tbMaxNum 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   1033
         SubFormatType   =   1
      EndProperty
      Height          =   375
      Left            =   1920
      TabIndex        =   19
      Text            =   "100"
      Top             =   3360
      Width           =   6015
   End
   Begin VB.CommandButton btnBrowse 
      Caption         =   "Browse..."
      Height          =   375
      Left            =   6960
      TabIndex        =   2
      Top             =   240
      Width           =   975
   End
   Begin VB.TextBox tbFileName 
      Height          =   375
      Left            =   1440
      TabIndex        =   1
      Top             =   240
      Width           =   5415
   End
   Begin VB.Frame frmTypes 
      Caption         =   "Barcode Types"
      Height          =   2055
      Left            =   240
      TabIndex        =   17
      Top             =   960
      Width           =   7695
      Begin VB.CheckBox cbDataMatrix 
         Caption         =   "DataMatrix"
         Height          =   255
         Left            =   3240
         TabIndex        =   15
         Top             =   1440
         Value           =   1  'Checked
         Width           =   1095
      End
      Begin VB.CheckBox cbPDF417 
         Caption         =   "PDF417"
         Height          =   255
         Left            =   1800
         TabIndex        =   14
         Top             =   1440
         Value           =   1  'Checked
         Width           =   975
      End
      Begin VB.CheckBox cbQRCode 
         Caption         =   "QRCode"
         Height          =   255
         Left            =   480
         TabIndex        =   13
         Top             =   1440
         Value           =   1  'Checked
         Width           =   1215
      End
      Begin VB.CheckBox cbIND 
         Caption         =   "Industrial 2 of 5"
         Height          =   375
         Left            =   3240
         TabIndex        =   10
         Top             =   840
         Value           =   1  'Checked
         Width           =   1455
      End
      Begin VB.CheckBox cbCodabar 
         Caption         =   "Codabar"
         Height          =   375
         Left            =   1800
         TabIndex        =   9
         Top             =   840
         Value           =   1  'Checked
         Width           =   975
      End
      Begin VB.CheckBox cbEAN13 
         Caption         =   "EAN13"
         Height          =   375
         Left            =   5040
         TabIndex        =   11
         Top             =   840
         Value           =   1  'Checked
         Width           =   855
      End
      Begin VB.CommandButton btnSelect 
         Caption         =   "Unselect All"
         Height          =   375
         Left            =   5880
         TabIndex        =   16
         Top             =   1440
         Width           =   1335
      End
      Begin VB.CheckBox cbCode93 
         Caption         =   "Code 93"
         Height          =   375
         Left            =   1800
         TabIndex        =   4
         Top             =   360
         Value           =   1  'Checked
         Width           =   975
      End
      Begin VB.CheckBox cbCode39 
         Caption         =   "Code 39"
         Height          =   375
         Left            =   480
         TabIndex        =   3
         Top             =   360
         Value           =   1  'Checked
         Width           =   975
      End
      Begin VB.CheckBox cbITF 
         Caption         =   "Interleaved 2 of 5"
         Height          =   375
         Left            =   3240
         TabIndex        =   5
         Top             =   360
         Value           =   1  'Checked
         Width           =   1695
      End
      Begin VB.CheckBox cbEAN8 
         Caption         =   "EAN8"
         Height          =   375
         Left            =   5040
         TabIndex        =   6
         Top             =   360
         Value           =   1  'Checked
         Width           =   855
      End
      Begin VB.CheckBox cbUPCA 
         Caption         =   "UPCA"
         Height          =   375
         Left            =   6360
         TabIndex        =   12
         Top             =   840
         Value           =   1  'Checked
         Width           =   855
      End
      Begin VB.CheckBox cbUPCE 
         Caption         =   "UPCE"
         Height          =   375
         Left            =   6360
         TabIndex        =   7
         Top             =   360
         Value           =   1  'Checked
         Width           =   855
      End
      Begin VB.CheckBox cbCode128 
         Caption         =   "Code 128"
         Height          =   375
         Left            =   480
         TabIndex        =   8
         Top             =   840
         Value           =   1  'Checked
         Width           =   1095
      End
   End
   Begin VB.Label Label2 
      Caption         =   "Maximum Number:"
      Height          =   375
      Left            =   360
      TabIndex        =   18
      Top             =   3360
      Width           =   1455
   End
   Begin VB.Label Label1 
      Caption         =   "Image File:"
      Height          =   375
      Left            =   360
      TabIndex        =   0
      Top             =   240
      Width           =   1215
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim bUnselectFlag As Boolean

Private Sub btnBrowse_Click()
    
    On Error GoTo ErrLabel
    
    cdOpenFileDlg.CancelError = True
    cdOpenFileDlg.Filter = "BMP(*.bmp)|*.bmp|JPEG(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png|TIFF(*.tif;*.tiff)|*.tif;*.tiff|GIF(*.gif)|*.gif|PDF(*.pdf)|*.pdf|All Files|*.*"
    cdOpenFileDlg.FilterIndex = 7
    cdOpenFileDlg.ShowOpen
    
    tbFileName.Text = cdOpenFileDlg.FileName
    
    Exit Sub
ErrLabel:
    Exit Sub
    
End Sub

Private Function GetSelectedBarcodeTypes() As Variant
    Dim lFormat As Long
    lFormat = 0
    
    
    If cbCode39.Value = Checked Then
        lFormat = lFormat Or EBF_CODE_39
    End If
        
    If cbCode128.Value = Checked Then
        lFormat = lFormat Or EBF_CODE_128
    End If
     
    If cbCode93.Value = Checked Then
        lFormat = lFormat Or EBF_CODE_93
    End If
    
    If cbCodabar.Value = Checked Then
        lFormat = lFormat Or EBF_CODABAR
    End If
    
    If cbITF.Value = Checked Then
        lFormat = lFormat Or EBF_ITF
    End If
    
    If cbEAN13.Value = Checked Then
        lFormat = lFormat Or EBF_EAN_13
    End If
    
    If cbEAN8.Value = Checked Then
        lFormat = lFormat Or EBF_EAN_8
    End If
    
    If cbUPCA.Value = Checked Then
        lFormat = lFormat Or EBF_UPC_A
    End If
   
    If cbUPCE.Value = Checked Then
        lFormat = lFormat Or EBF_UPC_E
    End If
    
    If cbIND.Value = Checked Then
        lFormat = lFormat Or EBF_INDUSTRIAL_25
    End If
    
    If cbQRCode.Value = Checked Then
        lFormat = lFormat Or EBF_QR_CODE
    End If
    
    If cbPDF417.Value = Checked Then
        lFormat = lFormat Or EBF_PDF417
    End If
    
    If cbDataMatrix.Value = Checked Then
        lFormat = lFormat Or EBF_DATAMATRIX
    End If
    
    If lFormat = 0 Then
        lFormat = -1
    End If
    
    GetSelectedBarcodeTypes = lFormat
    
End Function
Private Sub btnReadBarcode_Click()
    On Error GoTo ErrLabel
    
    lbResults = ""
        
    Dim oBarcodeReader As New BarcodeReader
    oBarcodeReader.InitLicense "t0260NQAAAFUZbbNi3xJ4oViu+0+5Eim8wPzn6GeJZrIvrb/HLjzJ8Mn+GRjbfdoa/f+iRLzKTudXVEkKqj9tKlzzDP+xKzZ2IdknzMXimKDmKBivdKTXM3T5ACPK25omqoQkqNw00zExtCrR532mHig0QU6dsF5EmvkgDLxsbWw/M54wj1F1pGagM7YfKzpLN0/qvCeejimX2nvTMfOzv+M37m+0RPsnyp20pITycnvBGyWkZ3OWQ97U8UNYl+OyyfuHymz8EcjqQm9nxvYTm4nYHERHkiXMmI6jWLgK+4+jIlcS9WLgWd8pMKkI0bZCcwmVzk5z+vuGYKjZVK/iuYIx7McOP9k="
    
    oBarcodeReader.BarcodeFormats = GetSelectedBarcodeTypes
    oBarcodeReader.MaxBarcodesNumPerPage = tbMaxNum.Text
    
    Dim dtBeg, dtEnd As Double
    dtBeg = Timer
    oBarcodeReader.DecodeFile tbFileName.Text
    dtEnd = Timer
    
    
    Dim oBarcodeArray As IBarcodeResultArray
    Set oBarcodeArray = oBarcodeReader.Barcodes
    
    Dim oTempStr As String
    If oBarcodeArray.Count = 0 Then
        oTempStr = "No barcode found."
    Else
        oTempStr = "Total barcode(s) found: " & oBarcodeArray.Count & "."
    End If
    
    oTempStr = oTempStr & " Total time spent: " & Format(dtEnd - dtBeg, "0.000") & " seconds."
    oTempStr = oTempStr & vbCrLf & vbCrLf
        
    Dim iIndex As Long
    Dim oBarcode As IBarcodeResult
    For iIndex = 0 To oBarcodeArray.Count - 1
        Set oBarcode = oBarcodeArray.Item(iIndex)
        
        oTempStr = oTempStr & "    Barcode " & iIndex + 1 & ":" & vbCrLf
        oTempStr = oTempStr & "        Page: " & oBarcode.PageNum & vbCrLf
        oTempStr = oTempStr & "        Type: " & oBarcode.BarcodeFormatString & vbCrLf
        oTempStr = oTempStr & "        Value: " & oBarcode.BarcodeText & vbCrLf
               
        oTempStr = oTempStr & "        Hex Data: " & ToHexString(oBarcode.BarcodeData) & vbCrLf
        
        oTempStr = oTempStr & "        Region: {Left: " & oBarcode.Left & _
                                ", Top: " & oBarcode.Top & _
                                ", Width: " & oBarcode.Width & _
                                ", Height: " & oBarcode.Height & "}" & vbCrLf
                                
        oTempStr = oTempStr & "        Module size: " & oBarcode.ModuleSize & vbCrLf
        oTempStr = oTempStr & "        Angle: " & oBarcode.Angle & vbCrLf & vbCrLf
    Next
    
    lbResults = oTempStr
    
    Set oBarcodeArray = Nothing
    Set oOption = Nothing
    Set oBarcodeReader = Nothing
    
    Exit Sub
ErrLabel:
    'MsgBox Err.Description, vbCritical
    lbResults.Text = Err.Description
End Sub

Private Function ToHexString(bytBuffer() As Byte)
    Dim strHex As String
    strHex = ""
    
    Dim iIndex As Long
    For iIndex = 0 To UBound(bytBuffer)
        If Len(Hex(bytBuffer(iIndex))) = 1 Then
            strHex = strHex & "0" & Hex(bytBuffer(iIndex)) & " "
        Else
            strHex = strHex & Hex(bytBuffer(iIndex)) & " "
        End If
    Next iIndex
    
    ToHexString = strHex
End Function

Private Sub btnSelect_Click()
    If Not bUnselectFlag Then
        btnSelect.Caption = "Unselect All"
        bUnselectFlag = True
        cbCode39.Value = Checked
        cbCode128.Value = Checked
        cbCode93.Value = Checked
        cbCodabar.Value = Checked
        cbITF.Value = Checked
        cbEAN13.Value = Checked
        cbEAN8.Value = Checked
        cbUPCA.Value = Checked
        cbUPCE.Value = Checked
        cbIND.Value = Checked
        cbQRCode.Value = Checked
        cbPDF417.Value = Checked
        cbDataMatrix.Value = Checked
    Else
        btnSelect.Caption = "Select All"
        bUnselectFlag = False
        cbCode39.Value = Unchecked
        cbCode128.Value = Unchecked
        cbCode93.Value = Unchecked
        cbCodabar.Value = Unchecked
        cbITF.Value = Unchecked
        cbEAN13.Value = Unchecked
        cbEAN8.Value = Unchecked
        cbUPCA.Value = Unchecked
        cbUPCE.Value = Unchecked
        cbIND.Value = Unchecked
        cbQRCode.Value = Unchecked
        cbPDF417.Value = Unchecked
        cbDataMatrix.Value = Unchecked
    End If
    
    DisableOrEnableReadButton
End Sub

Private Sub DisableOrEnableReadButton()
    If GetSelectedBarcodeTypes = -1 Then
        btnReadBarcode.Enabled = False
    Else
        btnReadBarcode.Enabled = True
    End If
End Sub

Private Sub cbCodabar_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbCode128_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbCode39_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbCode93_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbDataMatrix_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbEAN13_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbEAN8_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbIND_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbITF_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbPDF417_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbQRCode_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbUPCA_Click()
    DisableOrEnableReadButton
End Sub

Private Sub cbUPCE_Click()
    DisableOrEnableReadButton
End Sub

Private Sub Form_Load()
    bUnselectFlag = True
End Sub
