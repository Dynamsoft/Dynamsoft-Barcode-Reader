object Form1: TForm1
  Left = 629
  Top = 271
  BorderStyle = bsDialog
  Caption = 'Barcode Reader Demo'
  ClientHeight = 574
  ClientWidth = 544
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Scaled = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 24
    Top = 24
    Width = 54
    Height = 13
    Caption = 'Image File: '
  end
  object Label2: TLabel
    Left = 24
    Top = 200
    Width = 87
    Height = 13
    Caption = 'Maximum Number:'
  end
  object tbFileName: TEdit
    Left = 88
    Top = 24
    Width = 361
    Height = 21
    TabOrder = 0
  end
  object btnBrowse: TButton
    Left = 464
    Top = 24
    Width = 57
    Height = 25
    Caption = 'Browse...'
    TabOrder = 1
    OnClick = btnBrowseClick
  end
  object GroupBox1: TGroupBox
    Left = 24
    Top = 64
    Width = 497
    Height = 121
    Caption = 'Barcode Types'
    TabOrder = 2
    object cbCode39: TCheckBox
      Left = 24
      Top = 32
      Width = 65
      Height = 17
      Caption = 'Code 39'
      Checked = True
      State = cbChecked
      TabOrder = 0
    end
    object cbCode128: TCheckBox
      Left = 24
      Top = 56
      Width = 65
      Height = 17
      Caption = 'Code 128'
      Checked = True
      State = cbChecked
      TabOrder = 5
    end
    object cbCode93: TCheckBox
      Left = 112
      Top = 32
      Width = 65
      Height = 17
      Caption = 'Code 93'
      Checked = True
      State = cbChecked
      TabOrder = 1
    end
    object cbCodabar: TCheckBox
      Left = 112
      Top = 56
      Width = 65
      Height = 17
      Caption = 'Codabar'
      Checked = True
      State = cbChecked
      TabOrder = 6
    end
    object cbITF: TCheckBox
      Left = 192
      Top = 32
      Width = 113
      Height = 17
      Caption = 'Interleaved 2 of 5'
      Checked = True
      State = cbChecked
      TabOrder = 2
    end
    object cbIND: TCheckBox
      Left = 192
      Top = 56
      Width = 113
      Height = 17
      Caption = 'Industrial 2 of 5'
      Checked = True
      State = cbChecked
      TabOrder = 7
    end
    object cbEAN8: TCheckBox
      Left = 320
      Top = 32
      Width = 113
      Height = 17
      Caption = 'EAN-8'
      Checked = True
      State = cbChecked
      TabOrder = 3
    end
    object cbEAN13: TCheckBox
      Left = 320
      Top = 56
      Width = 65
      Height = 17
      Caption = 'EAN-13'
      Checked = True
      State = cbChecked
      TabOrder = 8
    end
    object cbUPCE: TCheckBox
      Left = 400
      Top = 32
      Width = 89
      Height = 17
      Caption = 'UPC-E'
      Checked = True
      State = cbChecked
      TabOrder = 4
    end
    object cbUPCA: TCheckBox
      Left = 400
      Top = 56
      Width = 81
      Height = 17
      Caption = 'UPC-A'
      Checked = True
      State = cbChecked
      TabOrder = 9
    end
    object cbQRCode: TCheckBox
      Left = 24
      Top = 88
      Width = 81
      Height = 17
      Caption = 'QRCode'
      Checked = True
      State = cbChecked
      TabOrder = 10
    end
    object btnSelect: TButton
      Left = 384
      Top = 80
      Width = 73
      Height = 25
      Caption = 'Unselect All'
      TabOrder = 13
      OnClick = btnSelectClick
    end
    object cbPDF417: TCheckBox
      Left = 112
      Top = 88
      Width = 81
      Height = 17
      Caption = 'PDF417'
      Checked = True
      State = cbChecked
      TabOrder = 11
    end
    object cbDataMatrix: TCheckBox
      Left = 192
      Top = 88
      Width = 81
      Height = 17
      Caption = 'DataMatrix'
      Checked = True
      State = cbChecked
      TabOrder = 12
    end
  end
  object tbMaxNum: TEdit
    Left = 120
    Top = 200
    Width = 401
    Height = 21
    TabOrder = 3
    Text = '100'
  end
  object memoResults: TMemo
    Left = 24
    Top = 280
    Width = 497
    Height = 273
    Lines.Strings = (
      '')
    ScrollBars = ssVertical
    TabOrder = 5
  end
  object btnReadBarcodes: TButton
    Left = 24
    Top = 240
    Width = 97
    Height = 25
    Caption = 'Read Barcodes'
    TabOrder = 4
    OnClick = btnReadBarcodesClick
  end
end
