unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DBRCtrlLib_TLB;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    tbFileName: TEdit;
    btnBrowse: TButton;
    GroupBox1: TGroupBox;
    cbCode39: TCheckBox;
    cbCode128: TCheckBox;
    cbCode93: TCheckBox;
    Label2: TLabel;
    tbMaxNum: TEdit;
    memoResults: TMemo;
    cbCodabar: TCheckBox;
    cbITF: TCheckBox;
    cbIND: TCheckBox;
    cbEAN8: TCheckBox;
    cbEAN13: TCheckBox;
    cbUPCE: TCheckBox;
    cbUPCA: TCheckBox;
    cbQRCode: TCheckBox;
    btnSelect: TButton;
    btnReadBarcodes: TButton;
    cbPDF417: TCheckBox;
    cbDataMatrix: TCheckBox;
    procedure FormCreate(Sender: TObject);
    procedure btnReadBarcodesClick(Sender: TObject);
    procedure btnBrowseClick(Sender: TObject);
    procedure btnSelectClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  oBR: BarcodeReader;
  oBF: BarcodeFormat;
  oRO: ReaderOptions;
  oList: BarcodeResultArray;
  oBarcode: BarcodeResult;
  strResults : String;
  iCount: Integer;
  openDialog1: TOpenDialog;
  bSelectAll: Boolean;
  Saved8087CW: Word;
  implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  Saved8087CW := Default8087CW;
  Set8087CW($133f); { Disable all fpu exceptions }

  oBR := CoBarcodeReader.Create;
  oBF := CoBarcodeFormat.Create;
  oRO := CoReaderOptions.Create;
  bSelectAll := true;
  oBR.InitLicense('38B9B94D8B0E2B41FDE1FB60861C28C0');
end;

procedure TForm1.btnReadBarcodesClick(Sender: TObject);
  var
    i : Integer;
    format : OleVariant;
    iBeg: Integer;
    iEnd: Integer;
  begin

  format := 0;
  if cbCode39.Checked then
  begin
    format := format or oBF.CODE_39;
  end;
  if cbCode128.Checked then
  begin
    format := format or oBF.CODE_128;
  end;
  if cbCode93.Checked then
  begin
    format := format or oBF.CODE_93;
  end;
  if cbCodabar.Checked then
  begin
    format := format or oBF.CODABAR;
  end;
  if cbITF.Checked then
  begin
    format := format or oBF.ITF;
  end;
  if cbIND.Checked then
  begin
    format := format or oBF.INDUSTRIAL_25;
  end;
  if cbEAN8.Checked then
  begin
    format := format or oBF.EAN_8;
  end;
  if cbEAN13.Checked then
  begin
    format := format or oBF.EAN_13;
  end;
  if cbUPCA.Checked then
  begin
    format := format or oBF.UPC_A;
  end;
  if cbUPCE.Checked then
  begin
    format := format or oBF.UPC_E;
  end;
  if cbQRCode.Checked then
  begin
    format := format or oBF.QR_CODE;
  end;
  if cbPDF417.Checked then
  begin
    format := format or oBF.PDF417;
  end;
  if cbDataMatrix.Checked then
  begin
    format := format or oBF.DATAMATRIX;
  end;

  oRO.BarcodeFormats := format;
  oRO.MaxBarcodesNumPerPage := strtoint(tbMaxNum.Text);
  oBR.ReaderOptions := oRO;

  iBeg := GetTickCount();

  try
    oBR.DecodeFile(tbFileName.Text);
  except
  on ex : Exception do
    begin
      //Application.MessageBox(PChar(ex.Message), 'Error', 16);
      memoResults.Text := ex.Message;
      exit;
    end;
  end;

  iEnd := GetTickCount();

  oList := oBR.Barcodes;
  if oList.Count = 0 Then
  begin
      strResults := 'No barcode found.';
  end
  else
  begin
      strResults := 'Total barcode(s) found: ' + inttostr(oList.Count) + '.' ;
  end;

  strResults := strResults + ' Total time spent: ' + SysUtils.FloatToStr((iEnd-iBeg)/1000.0) + '  seconds.' + sLineBreak;

  For i := 0 to oList.Count-1 do
  begin
     oBarcode := oList.item(i);

     strResults := strResults + '    Barcode ' + inttostr(i+1) + ':' + sLineBreak;
     strResults := strResults + '    Page: ' + inttostr(oBarcode.PageNum) + sLineBreak;
     strResults := strResults + '    Type: ' + oBarcode.BarcodeFormat.TypeString + sLineBreak;
     strResults := strResults + '    Value: ' + oBarcode.BarcodeText + sLineBreak;
     strResults := strResults + '    Region: {Left: ' + inttostr(oBarcode.Left) +
                                ', Top: ' + inttostr(oBarcode.Top) +
                                ', Width: ' + inttostr(oBarcode.Width) +
                                ', Height: ' + inttostr(oBarcode.Height) + '}' + sLineBreak;
                                
     strResults := strResults + sLineBreak;
  end;

  memoResults.Text := strResults;
end;

procedure TForm1.btnBrowseClick(Sender: TObject);
begin
    openDialog1 := TOpenDialog.Create(self);

    OpenDialog1.Filter := 'BMP(*.bmp)|*.bmp|JPEG(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png|TIFF(*.tif;*.tiff)|*.tif;*.tiff|GIF(*.gif)|*.gif|PDF(*.pdf)|*.pdf|All Files|*.*';
    OpenDialog1.FilterIndex := 7;
    if OpenDialog1.Execute
    then
    begin
          tbFileName.Text := OpenDialog1.FileName;
    end;
    openDialog1.Free;
end;

procedure TForm1.btnSelectClick(Sender: TObject);
begin
  if bSelectAll
  then
  begin
    cbCode39.Checked := False;
    cbCode128.Checked := False;
    cbCode93.Checked := False;
    cbCodabar.Checked := False;
    cbITF.Checked := False;
    cbIND.Checked := False;
    cbEAN8.Checked := False;
    cbEAN13.Checked := False;
    cbUPCE.Checked := False;
    cbUPCA.Checked := False;
    cbQRCode.Checked := False;
    cbPDF417.Checked := False;
    cbDataMatrix.Checked := False;
    btnSelect.Caption := 'Select All';
    bSelectAll := False;
  end
  else
  begin
    cbCode39.Checked := True;
    cbCode128.Checked := True;
    cbCode93.Checked := True;
    cbCodabar.Checked := True;
    cbITF.Checked := True;
    cbIND.Checked := True;
    cbEAN8.Checked := True;
    cbEAN13.Checked := True;
    cbUPCE.Checked := True;
    cbUPCA.Checked := True;
    cbQRCode.Checked := True;
    cbPDF417.Checked := True;
    cbDataMatrix.Checked := True;
    btnSelect.Caption := 'Unselect All';
    bSelectAll := True;
  end;
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Set8087CW(Saved8087CW);
end;

end.
