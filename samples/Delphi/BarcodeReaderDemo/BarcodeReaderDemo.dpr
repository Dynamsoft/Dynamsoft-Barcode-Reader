program BarcodeReaderDemo;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1},
  DBRCtrlLib_TLB in 'DBRCtrlLib_TLB.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
