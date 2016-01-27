unit DBRCtrlLib_TLB;

// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// PASTLWTR : 1.2
// File generated on 1/5/2016 10:21:39 PM from Type Library described below.

// ************************************************************************  //
// Type Lib: C:\DBR\0106\Windows\Components\ActiveX\DynamsoftBarcodeReaderCtrlx86.dll (1)
// LIBID: {FFE1D517-154B-4026-998B-66FFC1A3ACCA}
// LCID: 0
// Helpfile: 
// HelpString: Dynamsoft Barcode Reader 4.1 Type Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\Windows\SysWOW64\stdole2.tlb)
// Errors:
//   Hint: Symbol 'Type' renamed to 'type_'
//   Error creating palette bitmap of (TBarcodeReader) : Server C:\DBR\0106\Windows\Components\ActiveX\DynamsoftBarcodeReaderCtrlx86.dll contains no icons
//   Error creating palette bitmap of (TBarcodeFormat) : Server C:\DBR\0106\Windows\Components\ActiveX\DynamsoftBarcodeReaderCtrlx86.dll contains no icons
//   Error creating palette bitmap of (TReaderOptions) : Server C:\DBR\0106\Windows\Components\ActiveX\DynamsoftBarcodeReaderCtrlx86.dll contains no icons
// ************************************************************************ //
// *************************************************************************//
// NOTE:                                                                      
// Items guarded by $IFDEF_LIVE_SERVER_AT_DESIGN_TIME are used by properties  
// which return objects that may need to be explicitly created via a function 
// call prior to any access via the property. These items have been disabled  
// in order to prevent accidental use from within the object inspector. You   
// may enable them by defining LIVE_SERVER_AT_DESIGN_TIME or by selectively   
// removing them from the $IFDEF blocks. However, such items must still be    
// programmatically created via a method of the appropriate CoClass before    
// they can be used.                                                          
{$TYPEDADDRESS OFF} // Unit must be compiled without type-checked pointers. 
{$WARN SYMBOL_PLATFORM OFF}
{$WRITEABLECONST ON}
{$VARPROPSETTER ON}
interface

uses Windows, ActiveX, Classes, Graphics, OleServer, StdVCL, Variants;
  

// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLASS_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
const
  // TypeLibrary Major and minor versions
  DBRCtrlLibMajorVersion = 1;
  DBRCtrlLibMinorVersion = 0;

  LIBID_DBRCtrlLib: TGUID = '{FFE1D517-154B-4026-998B-66FFC1A3ACCA}';

  DIID__IBarcodeReaderEvents: TGUID = '{07B5D2D9-B4F2-432C-ACF1-685C69485825}';
  IID_IBarcodeReader: TGUID = '{70000CBB-F908-4E2C-9E53-070237A6BD1C}';
  CLASS_BarcodeReader: TGUID = '{08D536C2-F4C9-44F6-A540-65957760C1B2}';
  IID_IReaderOptions: TGUID = '{68ECF6D9-5BB7-42B5-8BDC-D1D6AFB0ED15}';
  IID_IBarcodeResultArray: TGUID = '{B15268A1-E8B0-42AC-A1C9-42E9C8329DE3}';
  IID_IBarcodeResult: TGUID = '{ABDFE739-97AD-4715-B2D6-BC023763E9B2}';
  IID_IBarcodeFormat: TGUID = '{F03B5DC1-4C10-4D76-B73F-4222C1B783CF}';
  CLASS_BarcodeFormat: TGUID = '{2FBB2D11-F616-4ABB-A0C7-AE709017385B}';
  CLASS_ReaderOptions: TGUID = '{E483386B-CB2F-4B4E-B014-E8D2DA41AE7F}';
  CLASS_BarcodeResult: TGUID = '{52826E02-2F94-4E1B-A08C-B9C3C6AADC2C}';
  CLASS_BarcodeResultArray: TGUID = '{4B7DE7CB-B94F-46AD-AB91-D25F3461D603}';
type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  _IBarcodeReaderEvents = dispinterface;
  IBarcodeReader = interface;
  IBarcodeReaderDisp = dispinterface;
  IReaderOptions = interface;
  IReaderOptionsDisp = dispinterface;
  IBarcodeResultArray = interface;
  IBarcodeResultArrayDisp = dispinterface;
  IBarcodeResult = interface;
  IBarcodeResultDisp = dispinterface;
  IBarcodeFormat = interface;
  IBarcodeFormatDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  BarcodeReader = IBarcodeReader;
  BarcodeFormat = IBarcodeFormat;
  ReaderOptions = IReaderOptions;
  BarcodeResult = IBarcodeResult;
  BarcodeResultArray = IBarcodeResultArray;


// *********************************************************************//
// DispIntf:  _IBarcodeReaderEvents
// Flags:     (4096) Dispatchable
// GUID:      {07B5D2D9-B4F2-432C-ACF1-685C69485825}
// *********************************************************************//
  _IBarcodeReaderEvents = dispinterface
    ['{07B5D2D9-B4F2-432C-ACF1-685C69485825}']
  end;

// *********************************************************************//
// Interface: IBarcodeReader
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {70000CBB-F908-4E2C-9E53-070237A6BD1C}
// *********************************************************************//
  IBarcodeReader = interface(IDispatch)
    ['{70000CBB-F908-4E2C-9E53-070237A6BD1C}']
    procedure InitLicense(const sLicenseKey: WideString); safecall;
    procedure DecodeFile(const sFileName: WideString); safecall;
    procedure DecodeFileRect(const sFileName: WideString; iRectLeft: Integer; iRectTop: Integer; 
                             iRectWidth: Integer; iRectHeight: Integer); safecall;
    procedure DecodeDIB(hDIB: Integer); safecall;
    procedure DecodeDIBRect(hDIB: Integer; iRectLeft: Integer; iRectTop: Integer; 
                            iRectWidth: Integer; iRectHeight: Integer); safecall;
    function Get_ReaderOptions: IReaderOptions; safecall;
    procedure Set_ReaderOptions(const pVal: IReaderOptions); safecall;
    function Get_Barcodes: IBarcodeResultArray; safecall;
    function Get_BarcodesCount: Integer; safecall;
    function Get_ErrorCode: Integer; safecall;
    function Get_ErrorString: WideString; safecall;
    procedure DecodeBuffer(DIBBuffer: OleVariant); safecall;
    procedure DecodeBufferRect(DIBBuffer: OleVariant; iRectLeft: Integer; iRectTop: Integer; 
                               iRectWidth: Integer; iRectHeight: Integer); safecall;
    procedure DecodeStream(FileStream: OleVariant); safecall;
    procedure DecodeStreamRect(FileStream: OleVariant; iRectLeft: Integer; iRectTop: Integer; 
                               iRectWidth: Integer; iRectHeight: Integer); safecall;
    procedure DecodeBase64String(const sFileStream: WideString); safecall;
    procedure DecodeBase64StringRect(const sFileStream: WideString; iRectLeft: Integer; 
                                     iRectTop: Integer; iRectWidth: Integer; iRectHeight: Integer); safecall;
    property ReaderOptions: IReaderOptions read Get_ReaderOptions write Set_ReaderOptions;
    property Barcodes: IBarcodeResultArray read Get_Barcodes;
    property BarcodesCount: Integer read Get_BarcodesCount;
    property ErrorCode: Integer read Get_ErrorCode;
    property ErrorString: WideString read Get_ErrorString;
  end;

// *********************************************************************//
// DispIntf:  IBarcodeReaderDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {70000CBB-F908-4E2C-9E53-070237A6BD1C}
// *********************************************************************//
  IBarcodeReaderDisp = dispinterface
    ['{70000CBB-F908-4E2C-9E53-070237A6BD1C}']
    procedure InitLicense(const sLicenseKey: WideString); dispid 1;
    procedure DecodeFile(const sFileName: WideString); dispid 2;
    procedure DecodeFileRect(const sFileName: WideString; iRectLeft: Integer; iRectTop: Integer; 
                             iRectWidth: Integer; iRectHeight: Integer); dispid 3;
    procedure DecodeDIB(hDIB: Integer); dispid 4;
    procedure DecodeDIBRect(hDIB: Integer; iRectLeft: Integer; iRectTop: Integer; 
                            iRectWidth: Integer; iRectHeight: Integer); dispid 5;
    property ReaderOptions: IReaderOptions dispid 6;
    property Barcodes: IBarcodeResultArray readonly dispid 7;
    property BarcodesCount: Integer readonly dispid 8;
    property ErrorCode: Integer readonly dispid 9;
    property ErrorString: WideString readonly dispid 10;
    procedure DecodeBuffer(DIBBuffer: OleVariant); dispid 11;
    procedure DecodeBufferRect(DIBBuffer: OleVariant; iRectLeft: Integer; iRectTop: Integer; 
                               iRectWidth: Integer; iRectHeight: Integer); dispid 12;
    procedure DecodeStream(FileStream: OleVariant); dispid 13;
    procedure DecodeStreamRect(FileStream: OleVariant; iRectLeft: Integer; iRectTop: Integer; 
                               iRectWidth: Integer; iRectHeight: Integer); dispid 14;
    procedure DecodeBase64String(const sFileStream: WideString); dispid 15;
    procedure DecodeBase64StringRect(const sFileStream: WideString; iRectLeft: Integer; 
                                     iRectTop: Integer; iRectWidth: Integer; iRectHeight: Integer); dispid 16;
  end;

// *********************************************************************//
// Interface: IReaderOptions
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {68ECF6D9-5BB7-42B5-8BDC-D1D6AFB0ED15}
// *********************************************************************//
  IReaderOptions = interface(IDispatch)
    ['{68ECF6D9-5BB7-42B5-8BDC-D1D6AFB0ED15}']
    function Get_BarcodeFormats: OleVariant; safecall;
    procedure Set_BarcodeFormats(pVal: OleVariant); safecall;
    function Get_MaxBarcodesNumPerPage: Integer; safecall;
    procedure Set_MaxBarcodesNumPerPage(pVal: Integer); safecall;
    property BarcodeFormats: OleVariant read Get_BarcodeFormats write Set_BarcodeFormats;
    property MaxBarcodesNumPerPage: Integer read Get_MaxBarcodesNumPerPage write Set_MaxBarcodesNumPerPage;
  end;

// *********************************************************************//
// DispIntf:  IReaderOptionsDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {68ECF6D9-5BB7-42B5-8BDC-D1D6AFB0ED15}
// *********************************************************************//
  IReaderOptionsDisp = dispinterface
    ['{68ECF6D9-5BB7-42B5-8BDC-D1D6AFB0ED15}']
    property BarcodeFormats: OleVariant dispid 1;
    property MaxBarcodesNumPerPage: Integer dispid 2;
  end;

// *********************************************************************//
// Interface: IBarcodeResultArray
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {B15268A1-E8B0-42AC-A1C9-42E9C8329DE3}
// *********************************************************************//
  IBarcodeResultArray = interface(IDispatch)
    ['{B15268A1-E8B0-42AC-A1C9-42E9C8329DE3}']
    function Get_Count: Integer; safecall;
    function Item(iIndex: Integer): IBarcodeResult; safecall;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IBarcodeResultArrayDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {B15268A1-E8B0-42AC-A1C9-42E9C8329DE3}
// *********************************************************************//
  IBarcodeResultArrayDisp = dispinterface
    ['{B15268A1-E8B0-42AC-A1C9-42E9C8329DE3}']
    property Count: Integer readonly dispid 1;
    function Item(iIndex: Integer): IBarcodeResult; dispid 2;
  end;

// *********************************************************************//
// Interface: IBarcodeResult
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {ABDFE739-97AD-4715-B2D6-BC023763E9B2}
// *********************************************************************//
  IBarcodeResult = interface(IDispatch)
    ['{ABDFE739-97AD-4715-B2D6-BC023763E9B2}']
    function Get_BarcodeFormat: IBarcodeFormat; safecall;
    function Get_BarcodeText: WideString; safecall;
    function Get_BarcodeData: OleVariant; safecall;
    function Get_Left: Integer; safecall;
    function Get_Top: Integer; safecall;
    function Get_Width: Integer; safecall;
    function Get_Height: Integer; safecall;
    function Get_X1: Integer; safecall;
    function Get_Y1: Integer; safecall;
    function Get_X2: Integer; safecall;
    function Get_Y2: Integer; safecall;
    function Get_X3: Integer; safecall;
    function Get_Y3: Integer; safecall;
    function Get_X4: Integer; safecall;
    function Get_Y4: Integer; safecall;
    function Get_PageNum: Integer; safecall;
    property BarcodeFormat: IBarcodeFormat read Get_BarcodeFormat;
    property BarcodeText: WideString read Get_BarcodeText;
    property BarcodeData: OleVariant read Get_BarcodeData;
    property Left: Integer read Get_Left;
    property Top: Integer read Get_Top;
    property Width: Integer read Get_Width;
    property Height: Integer read Get_Height;
    property X1: Integer read Get_X1;
    property Y1: Integer read Get_Y1;
    property X2: Integer read Get_X2;
    property Y2: Integer read Get_Y2;
    property X3: Integer read Get_X3;
    property Y3: Integer read Get_Y3;
    property X4: Integer read Get_X4;
    property Y4: Integer read Get_Y4;
    property PageNum: Integer read Get_PageNum;
  end;

// *********************************************************************//
// DispIntf:  IBarcodeResultDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {ABDFE739-97AD-4715-B2D6-BC023763E9B2}
// *********************************************************************//
  IBarcodeResultDisp = dispinterface
    ['{ABDFE739-97AD-4715-B2D6-BC023763E9B2}']
    property BarcodeFormat: IBarcodeFormat readonly dispid 1;
    property BarcodeText: WideString readonly dispid 2;
    property BarcodeData: OleVariant readonly dispid 3;
    property Left: Integer readonly dispid 4;
    property Top: Integer readonly dispid 5;
    property Width: Integer readonly dispid 6;
    property Height: Integer readonly dispid 7;
    property X1: Integer readonly dispid 8;
    property Y1: Integer readonly dispid 9;
    property X2: Integer readonly dispid 10;
    property Y2: Integer readonly dispid 11;
    property X3: Integer readonly dispid 12;
    property Y3: Integer readonly dispid 13;
    property X4: Integer readonly dispid 14;
    property Y4: Integer readonly dispid 15;
    property PageNum: Integer readonly dispid 16;
  end;

// *********************************************************************//
// Interface: IBarcodeFormat
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {F03B5DC1-4C10-4D76-B73F-4222C1B783CF}
// *********************************************************************//
  IBarcodeFormat = interface(IDispatch)
    ['{F03B5DC1-4C10-4D76-B73F-4222C1B783CF}']
    function Get_CODE_39: OleVariant; safecall;
    function Get_CODE_128: OleVariant; safecall;
    function Get_CODE_93: OleVariant; safecall;
    function Get_CODABAR: OleVariant; safecall;
    function Get_ITF: OleVariant; safecall;
    function Get_EAN_13: OleVariant; safecall;
    function Get_EAN_8: OleVariant; safecall;
    function Get_UPC_A: OleVariant; safecall;
    function Get_UPC_E: OleVariant; safecall;
    function Get_OneD: OleVariant; safecall;
    function Get_type_: OleVariant; safecall;
    function Get_TypeString: WideString; safecall;
    function Get_INDUSTRIAL_25: OleVariant; safecall;
    function Get_QR_CODE: OleVariant; safecall;
    function Get_PDF417: OleVariant; safecall;
    function Get_DATAMATRIX: OleVariant; safecall;
    property CODE_39: OleVariant read Get_CODE_39;
    property CODE_128: OleVariant read Get_CODE_128;
    property CODE_93: OleVariant read Get_CODE_93;
    property CODABAR: OleVariant read Get_CODABAR;
    property ITF: OleVariant read Get_ITF;
    property EAN_13: OleVariant read Get_EAN_13;
    property EAN_8: OleVariant read Get_EAN_8;
    property UPC_A: OleVariant read Get_UPC_A;
    property UPC_E: OleVariant read Get_UPC_E;
    property OneD: OleVariant read Get_OneD;
    property type_: OleVariant read Get_type_;
    property TypeString: WideString read Get_TypeString;
    property INDUSTRIAL_25: OleVariant read Get_INDUSTRIAL_25;
    property QR_CODE: OleVariant read Get_QR_CODE;
    property PDF417: OleVariant read Get_PDF417;
    property DATAMATRIX: OleVariant read Get_DATAMATRIX;
  end;

// *********************************************************************//
// DispIntf:  IBarcodeFormatDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {F03B5DC1-4C10-4D76-B73F-4222C1B783CF}
// *********************************************************************//
  IBarcodeFormatDisp = dispinterface
    ['{F03B5DC1-4C10-4D76-B73F-4222C1B783CF}']
    property CODE_39: OleVariant readonly dispid 1;
    property CODE_128: OleVariant readonly dispid 2;
    property CODE_93: OleVariant readonly dispid 3;
    property CODABAR: OleVariant readonly dispid 4;
    property ITF: OleVariant readonly dispid 5;
    property EAN_13: OleVariant readonly dispid 6;
    property EAN_8: OleVariant readonly dispid 7;
    property UPC_A: OleVariant readonly dispid 8;
    property UPC_E: OleVariant readonly dispid 9;
    property OneD: OleVariant readonly dispid 10;
    property type_: OleVariant readonly dispid 11;
    property TypeString: WideString readonly dispid 12;
    property INDUSTRIAL_25: OleVariant readonly dispid 13;
    property QR_CODE: OleVariant readonly dispid 14;
    property PDF417: OleVariant readonly dispid 15;
    property DATAMATRIX: OleVariant readonly dispid 16;
  end;

// *********************************************************************//
// The Class CoBarcodeReader provides a Create and CreateRemote method to          
// create instances of the default interface IBarcodeReader exposed by              
// the CoClass BarcodeReader. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoBarcodeReader = class
    class function Create: IBarcodeReader;
    class function CreateRemote(const MachineName: string): IBarcodeReader;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TBarcodeReader
// Help String      : BarcodeReader Class
// Default Interface: IBarcodeReader
// Def. Intf. DISP? : No
// Event   Interface: _IBarcodeReaderEvents
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TBarcodeReaderProperties= class;
{$ENDIF}
  TBarcodeReader = class(TOleServer)
  private
    FIntf:        IBarcodeReader;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps:       TBarcodeReaderProperties;
    function      GetServerProperties: TBarcodeReaderProperties;
{$ENDIF}
    function      GetDefaultInterface: IBarcodeReader;
  protected
    procedure InitServerData; override;
    procedure InvokeEvent(DispID: TDispID; var Params: TVariantArray); override;
    function Get_ReaderOptions: IReaderOptions;
    procedure Set_ReaderOptions(const pVal: IReaderOptions);
    function Get_Barcodes: IBarcodeResultArray;
    function Get_BarcodesCount: Integer;
    function Get_ErrorCode: Integer;
    function Get_ErrorString: WideString;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IBarcodeReader);
    procedure Disconnect; override;
    procedure InitLicense(const sLicenseKey: WideString);
    procedure DecodeFile(const sFileName: WideString);
    procedure DecodeFileRect(const sFileName: WideString; iRectLeft: Integer; iRectTop: Integer; 
                             iRectWidth: Integer; iRectHeight: Integer);
    procedure DecodeDIB(hDIB: Integer);
    procedure DecodeDIBRect(hDIB: Integer; iRectLeft: Integer; iRectTop: Integer; 
                            iRectWidth: Integer; iRectHeight: Integer);
    procedure DecodeBuffer(DIBBuffer: OleVariant);
    procedure DecodeBufferRect(DIBBuffer: OleVariant; iRectLeft: Integer; iRectTop: Integer; 
                               iRectWidth: Integer; iRectHeight: Integer);
    procedure DecodeStream(FileStream: OleVariant);
    procedure DecodeStreamRect(FileStream: OleVariant; iRectLeft: Integer; iRectTop: Integer; 
                               iRectWidth: Integer; iRectHeight: Integer);
    procedure DecodeBase64String(const sFileStream: WideString);
    procedure DecodeBase64StringRect(const sFileStream: WideString; iRectLeft: Integer; 
                                     iRectTop: Integer; iRectWidth: Integer; iRectHeight: Integer);
    property DefaultInterface: IBarcodeReader read GetDefaultInterface;
    property Barcodes: IBarcodeResultArray read Get_Barcodes;
    property BarcodesCount: Integer read Get_BarcodesCount;
    property ErrorCode: Integer read Get_ErrorCode;
    property ErrorString: WideString read Get_ErrorString;
    property ReaderOptions: IReaderOptions read Get_ReaderOptions write Set_ReaderOptions;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TBarcodeReaderProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TBarcodeReader
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TBarcodeReaderProperties = class(TPersistent)
  private
    FServer:    TBarcodeReader;
    function    GetDefaultInterface: IBarcodeReader;
    constructor Create(AServer: TBarcodeReader);
  protected
    function Get_ReaderOptions: IReaderOptions;
    procedure Set_ReaderOptions(const pVal: IReaderOptions);
    function Get_Barcodes: IBarcodeResultArray;
    function Get_BarcodesCount: Integer;
    function Get_ErrorCode: Integer;
    function Get_ErrorString: WideString;
  public
    property DefaultInterface: IBarcodeReader read GetDefaultInterface;
  published
    property ReaderOptions: IReaderOptions read Get_ReaderOptions write Set_ReaderOptions;
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoBarcodeFormat provides a Create and CreateRemote method to          
// create instances of the default interface IBarcodeFormat exposed by              
// the CoClass BarcodeFormat. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoBarcodeFormat = class
    class function Create: IBarcodeFormat;
    class function CreateRemote(const MachineName: string): IBarcodeFormat;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TBarcodeFormat
// Help String      : BarcodeFormat Class
// Default Interface: IBarcodeFormat
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TBarcodeFormatProperties= class;
{$ENDIF}
  TBarcodeFormat = class(TOleServer)
  private
    FIntf:        IBarcodeFormat;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps:       TBarcodeFormatProperties;
    function      GetServerProperties: TBarcodeFormatProperties;
{$ENDIF}
    function      GetDefaultInterface: IBarcodeFormat;
  protected
    procedure InitServerData; override;
    function Get_CODE_39: OleVariant;
    function Get_CODE_128: OleVariant;
    function Get_CODE_93: OleVariant;
    function Get_CODABAR: OleVariant;
    function Get_ITF: OleVariant;
    function Get_EAN_13: OleVariant;
    function Get_EAN_8: OleVariant;
    function Get_UPC_A: OleVariant;
    function Get_UPC_E: OleVariant;
    function Get_OneD: OleVariant;
    function Get_type_: OleVariant;
    function Get_TypeString: WideString;
    function Get_INDUSTRIAL_25: OleVariant;
    function Get_QR_CODE: OleVariant;
    function Get_PDF417: OleVariant;
    function Get_DATAMATRIX: OleVariant;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IBarcodeFormat);
    procedure Disconnect; override;
    property DefaultInterface: IBarcodeFormat read GetDefaultInterface;
    property CODE_39: OleVariant read Get_CODE_39;
    property CODE_128: OleVariant read Get_CODE_128;
    property CODE_93: OleVariant read Get_CODE_93;
    property CODABAR: OleVariant read Get_CODABAR;
    property ITF: OleVariant read Get_ITF;
    property EAN_13: OleVariant read Get_EAN_13;
    property EAN_8: OleVariant read Get_EAN_8;
    property UPC_A: OleVariant read Get_UPC_A;
    property UPC_E: OleVariant read Get_UPC_E;
    property OneD: OleVariant read Get_OneD;
    property type_: OleVariant read Get_type_;
    property TypeString: WideString read Get_TypeString;
    property INDUSTRIAL_25: OleVariant read Get_INDUSTRIAL_25;
    property QR_CODE: OleVariant read Get_QR_CODE;
    property PDF417: OleVariant read Get_PDF417;
    property DATAMATRIX: OleVariant read Get_DATAMATRIX;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TBarcodeFormatProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TBarcodeFormat
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TBarcodeFormatProperties = class(TPersistent)
  private
    FServer:    TBarcodeFormat;
    function    GetDefaultInterface: IBarcodeFormat;
    constructor Create(AServer: TBarcodeFormat);
  protected
    function Get_CODE_39: OleVariant;
    function Get_CODE_128: OleVariant;
    function Get_CODE_93: OleVariant;
    function Get_CODABAR: OleVariant;
    function Get_ITF: OleVariant;
    function Get_EAN_13: OleVariant;
    function Get_EAN_8: OleVariant;
    function Get_UPC_A: OleVariant;
    function Get_UPC_E: OleVariant;
    function Get_OneD: OleVariant;
    function Get_type_: OleVariant;
    function Get_TypeString: WideString;
    function Get_INDUSTRIAL_25: OleVariant;
    function Get_QR_CODE: OleVariant;
    function Get_PDF417: OleVariant;
    function Get_DATAMATRIX: OleVariant;
  public
    property DefaultInterface: IBarcodeFormat read GetDefaultInterface;
  published
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoReaderOptions provides a Create and CreateRemote method to          
// create instances of the default interface IReaderOptions exposed by              
// the CoClass ReaderOptions. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoReaderOptions = class
    class function Create: IReaderOptions;
    class function CreateRemote(const MachineName: string): IReaderOptions;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TReaderOptions
// Help String      : ReaderOptions Class
// Default Interface: IReaderOptions
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TReaderOptionsProperties= class;
{$ENDIF}
  TReaderOptions = class(TOleServer)
  private
    FIntf:        IReaderOptions;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps:       TReaderOptionsProperties;
    function      GetServerProperties: TReaderOptionsProperties;
{$ENDIF}
    function      GetDefaultInterface: IReaderOptions;
  protected
    procedure InitServerData; override;
    function Get_BarcodeFormats: OleVariant;
    procedure Set_BarcodeFormats(pVal: OleVariant);
    function Get_MaxBarcodesNumPerPage: Integer;
    procedure Set_MaxBarcodesNumPerPage(pVal: Integer);
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IReaderOptions);
    procedure Disconnect; override;
    property DefaultInterface: IReaderOptions read GetDefaultInterface;
    property BarcodeFormats: OleVariant read Get_BarcodeFormats write Set_BarcodeFormats;
    property MaxBarcodesNumPerPage: Integer read Get_MaxBarcodesNumPerPage write Set_MaxBarcodesNumPerPage;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TReaderOptionsProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TReaderOptions
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TReaderOptionsProperties = class(TPersistent)
  private
    FServer:    TReaderOptions;
    function    GetDefaultInterface: IReaderOptions;
    constructor Create(AServer: TReaderOptions);
  protected
    function Get_BarcodeFormats: OleVariant;
    procedure Set_BarcodeFormats(pVal: OleVariant);
    function Get_MaxBarcodesNumPerPage: Integer;
    procedure Set_MaxBarcodesNumPerPage(pVal: Integer);
  public
    property DefaultInterface: IReaderOptions read GetDefaultInterface;
  published
    property MaxBarcodesNumPerPage: Integer read Get_MaxBarcodesNumPerPage write Set_MaxBarcodesNumPerPage;
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoBarcodeResult provides a Create and CreateRemote method to          
// create instances of the default interface IBarcodeResult exposed by              
// the CoClass BarcodeResult. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoBarcodeResult = class
    class function Create: IBarcodeResult;
    class function CreateRemote(const MachineName: string): IBarcodeResult;
  end;

// *********************************************************************//
// The Class CoBarcodeResultArray provides a Create and CreateRemote method to          
// create instances of the default interface IBarcodeResultArray exposed by              
// the CoClass BarcodeResultArray. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoBarcodeResultArray = class
    class function Create: IBarcodeResultArray;
    class function CreateRemote(const MachineName: string): IBarcodeResultArray;
  end;

procedure Register;

resourcestring
  dtlServerPage = 'ActiveX';

  dtlOcxPage = 'ActiveX';

implementation

uses ComObj;

class function CoBarcodeReader.Create: IBarcodeReader;
begin
  Result := CreateComObject(CLASS_BarcodeReader) as IBarcodeReader;
end;

class function CoBarcodeReader.CreateRemote(const MachineName: string): IBarcodeReader;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_BarcodeReader) as IBarcodeReader;
end;

procedure TBarcodeReader.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{08D536C2-F4C9-44F6-A540-65957760C1B2}';
    IntfIID:   '{70000CBB-F908-4E2C-9E53-070237A6BD1C}';
    EventIID:  '{07B5D2D9-B4F2-432C-ACF1-685C69485825}';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TBarcodeReader.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    ConnectEvents(punk);
    Fintf:= punk as IBarcodeReader;
  end;
end;

procedure TBarcodeReader.ConnectTo(svrIntf: IBarcodeReader);
begin
  Disconnect;
  FIntf := svrIntf;
  ConnectEvents(FIntf);
end;

procedure TBarcodeReader.DisConnect;
begin
  if Fintf <> nil then
  begin
    DisconnectEvents(FIntf);
    FIntf := nil;
  end;
end;

function TBarcodeReader.GetDefaultInterface: IBarcodeReader;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call ''Connect'' or ''ConnectTo'' before this operation');
  Result := FIntf;
end;

constructor TBarcodeReader.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TBarcodeReaderProperties.Create(Self);
{$ENDIF}
end;

destructor TBarcodeReader.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TBarcodeReader.GetServerProperties: TBarcodeReaderProperties;
begin
  Result := FProps;
end;
{$ENDIF}

procedure TBarcodeReader.InvokeEvent(DispID: TDispID; var Params: TVariantArray);
begin
  case DispID of
    -1: Exit;  // DISPID_UNKNOWN
  end; {case DispID}
end;

function TBarcodeReader.Get_ReaderOptions: IReaderOptions;
begin
    Result := DefaultInterface.ReaderOptions;
end;

procedure TBarcodeReader.Set_ReaderOptions(const pVal: IReaderOptions);
begin
  DefaultInterface.Set_ReaderOptions(pVal);
end;

function TBarcodeReader.Get_Barcodes: IBarcodeResultArray;
begin
    Result := DefaultInterface.Barcodes;
end;

function TBarcodeReader.Get_BarcodesCount: Integer;
begin
    Result := DefaultInterface.BarcodesCount;
end;

function TBarcodeReader.Get_ErrorCode: Integer;
begin
    Result := DefaultInterface.ErrorCode;
end;

function TBarcodeReader.Get_ErrorString: WideString;
begin
    Result := DefaultInterface.ErrorString;
end;

procedure TBarcodeReader.InitLicense(const sLicenseKey: WideString);
begin
  DefaultInterface.InitLicense(sLicenseKey);
end;

procedure TBarcodeReader.DecodeFile(const sFileName: WideString);
begin
  DefaultInterface.DecodeFile(sFileName);
end;

procedure TBarcodeReader.DecodeFileRect(const sFileName: WideString; iRectLeft: Integer; 
                                        iRectTop: Integer; iRectWidth: Integer; iRectHeight: Integer);
begin
  DefaultInterface.DecodeFileRect(sFileName, iRectLeft, iRectTop, iRectWidth, iRectHeight);
end;

procedure TBarcodeReader.DecodeDIB(hDIB: Integer);
begin
  DefaultInterface.DecodeDIB(hDIB);
end;

procedure TBarcodeReader.DecodeDIBRect(hDIB: Integer; iRectLeft: Integer; iRectTop: Integer; 
                                       iRectWidth: Integer; iRectHeight: Integer);
begin
  DefaultInterface.DecodeDIBRect(hDIB, iRectLeft, iRectTop, iRectWidth, iRectHeight);
end;

procedure TBarcodeReader.DecodeBuffer(DIBBuffer: OleVariant);
begin
  DefaultInterface.DecodeBuffer(DIBBuffer);
end;

procedure TBarcodeReader.DecodeBufferRect(DIBBuffer: OleVariant; iRectLeft: Integer; 
                                          iRectTop: Integer; iRectWidth: Integer; 
                                          iRectHeight: Integer);
begin
  DefaultInterface.DecodeBufferRect(DIBBuffer, iRectLeft, iRectTop, iRectWidth, iRectHeight);
end;

procedure TBarcodeReader.DecodeStream(FileStream: OleVariant);
begin
  DefaultInterface.DecodeStream(FileStream);
end;

procedure TBarcodeReader.DecodeStreamRect(FileStream: OleVariant; iRectLeft: Integer; 
                                          iRectTop: Integer; iRectWidth: Integer; 
                                          iRectHeight: Integer);
begin
  DefaultInterface.DecodeStreamRect(FileStream, iRectLeft, iRectTop, iRectWidth, iRectHeight);
end;

procedure TBarcodeReader.DecodeBase64String(const sFileStream: WideString);
begin
  DefaultInterface.DecodeBase64String(sFileStream);
end;

procedure TBarcodeReader.DecodeBase64StringRect(const sFileStream: WideString; iRectLeft: Integer; 
                                                iRectTop: Integer; iRectWidth: Integer; 
                                                iRectHeight: Integer);
begin
  DefaultInterface.DecodeBase64StringRect(sFileStream, iRectLeft, iRectTop, iRectWidth, iRectHeight);
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TBarcodeReaderProperties.Create(AServer: TBarcodeReader);
begin
  inherited Create;
  FServer := AServer;
end;

function TBarcodeReaderProperties.GetDefaultInterface: IBarcodeReader;
begin
  Result := FServer.DefaultInterface;
end;

function TBarcodeReaderProperties.Get_ReaderOptions: IReaderOptions;
begin
    Result := DefaultInterface.ReaderOptions;
end;

procedure TBarcodeReaderProperties.Set_ReaderOptions(const pVal: IReaderOptions);
begin
  DefaultInterface.Set_ReaderOptions(pVal);
end;

function TBarcodeReaderProperties.Get_Barcodes: IBarcodeResultArray;
begin
    Result := DefaultInterface.Barcodes;
end;

function TBarcodeReaderProperties.Get_BarcodesCount: Integer;
begin
    Result := DefaultInterface.BarcodesCount;
end;

function TBarcodeReaderProperties.Get_ErrorCode: Integer;
begin
    Result := DefaultInterface.ErrorCode;
end;

function TBarcodeReaderProperties.Get_ErrorString: WideString;
begin
    Result := DefaultInterface.ErrorString;
end;

{$ENDIF}

class function CoBarcodeFormat.Create: IBarcodeFormat;
begin
  Result := CreateComObject(CLASS_BarcodeFormat) as IBarcodeFormat;
end;

class function CoBarcodeFormat.CreateRemote(const MachineName: string): IBarcodeFormat;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_BarcodeFormat) as IBarcodeFormat;
end;

procedure TBarcodeFormat.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{2FBB2D11-F616-4ABB-A0C7-AE709017385B}';
    IntfIID:   '{F03B5DC1-4C10-4D76-B73F-4222C1B783CF}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TBarcodeFormat.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IBarcodeFormat;
  end;
end;

procedure TBarcodeFormat.ConnectTo(svrIntf: IBarcodeFormat);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TBarcodeFormat.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TBarcodeFormat.GetDefaultInterface: IBarcodeFormat;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call ''Connect'' or ''ConnectTo'' before this operation');
  Result := FIntf;
end;

constructor TBarcodeFormat.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TBarcodeFormatProperties.Create(Self);
{$ENDIF}
end;

destructor TBarcodeFormat.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TBarcodeFormat.GetServerProperties: TBarcodeFormatProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TBarcodeFormat.Get_CODE_39: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODE_39;
end;

function TBarcodeFormat.Get_CODE_128: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODE_128;
end;

function TBarcodeFormat.Get_CODE_93: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODE_93;
end;

function TBarcodeFormat.Get_CODABAR: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODABAR;
end;

function TBarcodeFormat.Get_ITF: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.ITF;
end;

function TBarcodeFormat.Get_EAN_13: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.EAN_13;
end;

function TBarcodeFormat.Get_EAN_8: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.EAN_8;
end;

function TBarcodeFormat.Get_UPC_A: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.UPC_A;
end;

function TBarcodeFormat.Get_UPC_E: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.UPC_E;
end;

function TBarcodeFormat.Get_OneD: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.OneD;
end;

function TBarcodeFormat.Get_type_: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.type_;
end;

function TBarcodeFormat.Get_TypeString: WideString;
begin
    Result := DefaultInterface.TypeString;
end;

function TBarcodeFormat.Get_INDUSTRIAL_25: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.INDUSTRIAL_25;
end;

function TBarcodeFormat.Get_QR_CODE: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.QR_CODE;
end;

function TBarcodeFormat.Get_PDF417: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.PDF417;
end;

function TBarcodeFormat.Get_DATAMATRIX: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.DATAMATRIX;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TBarcodeFormatProperties.Create(AServer: TBarcodeFormat);
begin
  inherited Create;
  FServer := AServer;
end;

function TBarcodeFormatProperties.GetDefaultInterface: IBarcodeFormat;
begin
  Result := FServer.DefaultInterface;
end;

function TBarcodeFormatProperties.Get_CODE_39: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODE_39;
end;

function TBarcodeFormatProperties.Get_CODE_128: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODE_128;
end;

function TBarcodeFormatProperties.Get_CODE_93: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODE_93;
end;

function TBarcodeFormatProperties.Get_CODABAR: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.CODABAR;
end;

function TBarcodeFormatProperties.Get_ITF: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.ITF;
end;

function TBarcodeFormatProperties.Get_EAN_13: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.EAN_13;
end;

function TBarcodeFormatProperties.Get_EAN_8: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.EAN_8;
end;

function TBarcodeFormatProperties.Get_UPC_A: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.UPC_A;
end;

function TBarcodeFormatProperties.Get_UPC_E: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.UPC_E;
end;

function TBarcodeFormatProperties.Get_OneD: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.OneD;
end;

function TBarcodeFormatProperties.Get_type_: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.type_;
end;

function TBarcodeFormatProperties.Get_TypeString: WideString;
begin
    Result := DefaultInterface.TypeString;
end;

function TBarcodeFormatProperties.Get_INDUSTRIAL_25: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.INDUSTRIAL_25;
end;

function TBarcodeFormatProperties.Get_QR_CODE: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.QR_CODE;
end;

function TBarcodeFormatProperties.Get_PDF417: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.PDF417;
end;

function TBarcodeFormatProperties.Get_DATAMATRIX: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.DATAMATRIX;
end;

{$ENDIF}

class function CoReaderOptions.Create: IReaderOptions;
begin
  Result := CreateComObject(CLASS_ReaderOptions) as IReaderOptions;
end;

class function CoReaderOptions.CreateRemote(const MachineName: string): IReaderOptions;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_ReaderOptions) as IReaderOptions;
end;

procedure TReaderOptions.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{E483386B-CB2F-4B4E-B014-E8D2DA41AE7F}';
    IntfIID:   '{68ECF6D9-5BB7-42B5-8BDC-D1D6AFB0ED15}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TReaderOptions.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IReaderOptions;
  end;
end;

procedure TReaderOptions.ConnectTo(svrIntf: IReaderOptions);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TReaderOptions.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TReaderOptions.GetDefaultInterface: IReaderOptions;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call ''Connect'' or ''ConnectTo'' before this operation');
  Result := FIntf;
end;

constructor TReaderOptions.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TReaderOptionsProperties.Create(Self);
{$ENDIF}
end;

destructor TReaderOptions.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TReaderOptions.GetServerProperties: TReaderOptionsProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TReaderOptions.Get_BarcodeFormats: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.BarcodeFormats;
end;

procedure TReaderOptions.Set_BarcodeFormats(pVal: OleVariant);
begin
  DefaultInterface.Set_BarcodeFormats(pVal);
end;

function TReaderOptions.Get_MaxBarcodesNumPerPage: Integer;
begin
    Result := DefaultInterface.MaxBarcodesNumPerPage;
end;

procedure TReaderOptions.Set_MaxBarcodesNumPerPage(pVal: Integer);
begin
  DefaultInterface.Set_MaxBarcodesNumPerPage(pVal);
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TReaderOptionsProperties.Create(AServer: TReaderOptions);
begin
  inherited Create;
  FServer := AServer;
end;

function TReaderOptionsProperties.GetDefaultInterface: IReaderOptions;
begin
  Result := FServer.DefaultInterface;
end;

function TReaderOptionsProperties.Get_BarcodeFormats: OleVariant;
var
  InterfaceVariant : OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  Result := InterfaceVariant.BarcodeFormats;
end;

procedure TReaderOptionsProperties.Set_BarcodeFormats(pVal: OleVariant);
begin
  DefaultInterface.Set_BarcodeFormats(pVal);
end;

function TReaderOptionsProperties.Get_MaxBarcodesNumPerPage: Integer;
begin
    Result := DefaultInterface.MaxBarcodesNumPerPage;
end;

procedure TReaderOptionsProperties.Set_MaxBarcodesNumPerPage(pVal: Integer);
begin
  DefaultInterface.Set_MaxBarcodesNumPerPage(pVal);
end;

{$ENDIF}

class function CoBarcodeResult.Create: IBarcodeResult;
begin
  Result := CreateComObject(CLASS_BarcodeResult) as IBarcodeResult;
end;

class function CoBarcodeResult.CreateRemote(const MachineName: string): IBarcodeResult;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_BarcodeResult) as IBarcodeResult;
end;

class function CoBarcodeResultArray.Create: IBarcodeResultArray;
begin
  Result := CreateComObject(CLASS_BarcodeResultArray) as IBarcodeResultArray;
end;

class function CoBarcodeResultArray.CreateRemote(const MachineName: string): IBarcodeResultArray;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_BarcodeResultArray) as IBarcodeResultArray;
end;

procedure Register;
begin
  RegisterComponents(dtlServerPage, [TBarcodeReader, TBarcodeFormat, TReaderOptions]);
end;

end.
