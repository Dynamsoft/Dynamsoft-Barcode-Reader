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
// File generated on 2017/2/13 10:23:29 from Type Library described below.

// ************************************************************************  //
// Type Lib: E:\DBR\DBRSamples\Components\ActiveX\DynamsoftBarcodeReaderCtrlx86.dll (1)
// LIBID: {19AA5F16-9FA9-4B11-8F90-C269B8E668D9}
// LCID: 0
// Helpfile: 
// HelpString: Dynamsoft Barcode Reader 5.0 Type Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\Windows\SysWOW64\stdole2.tlb)
// Errors:
//   Error creating palette bitmap of (TBarcodeReader) : Server E:\DBR\DBRSamples\Components\ActiveX\DynamsoftBarcodeReaderCtrlx86.dll contains no icons
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

  LIBID_DBRCtrlLib: TGUID = '{19AA5F16-9FA9-4B11-8F90-C269B8E668D9}';

  DIID__IBarcodeReaderEvents: TGUID = '{96D15AE6-535C-417F-A4B2-9567460A1311}';
  IID_IBarcodeReader: TGUID = '{5847949D-7195-4613-AE5E-E03F84C7D641}';
  CLASS_BarcodeReader: TGUID = '{34251D1F-7229-4CED-B32A-CBBDA8DDBC31}';
  IID_IBarcodeResultArray: TGUID = '{C37FE03C-854E-4057-A9C4-7FA47992A434}';
  IID_IBarcodeResult: TGUID = '{5D746054-19C1-494F-8703-A92BA29B4AB8}';
  CLASS_BarcodeResult: TGUID = '{0229F7CD-CD5C-4773-A575-E90122C59BB5}';
  CLASS_BarcodeResultArray: TGUID = '{BC3689F9-4051-445A-8B71-C067F72634A0}';

// *********************************************************************//
// Declaration of Enumerations defined in Type Library                    
// *********************************************************************//
// Constants for enum __MIDL___MIDL_itf_DBR_ATL_0000_0000_0001
type
  __MIDL___MIDL_itf_DBR_ATL_0000_0000_0001 = TOleEnum;
const
  EBF_All = $00000000;
  EBF_OneD = $000003FF;
  EBF_CODE_39 = $00000001;
  EBF_CODE_128 = $00000002;
  EBF_CODE_93 = $00000004;
  EBF_CODABAR = $00000008;
  EBF_ITF = $00000010;
  EBF_EAN_13 = $00000020;
  EBF_EAN_8 = $00000040;
  EBF_UPC_A = $00000080;
  EBF_UPC_E = $00000100;
  EBF_INDUSTRIAL_25 = $00000200;
  EBF_PDF417 = $02000000;
  EBF_QR_CODE = $04000000;
  EBF_DATAMATRIX = $08000000;

// Constants for enum __MIDL___MIDL_itf_DBR_ATL_0000_0000_0002
type
  __MIDL___MIDL_itf_DBR_ATL_0000_0000_0002 = TOleEnum;
const
  EICD_Unknown = $00000000;
  EICD_Scanner = $00000001;
  EICD_Camera = $00000002;
  EICD_Fax = $00000003;

// Constants for enum __MIDL___MIDL_itf_DBR_ATL_0000_0000_0003
type
  __MIDL___MIDL_itf_DBR_ATL_0000_0000_0003 = TOleEnum;
const
  EBCM_DarkOnLight = $00000000;
  EBCM_LightOnDark = $00000001;
  EBCM_DarkAndLight = $00000002;

// Constants for enum __MIDL___MIDL_itf_DBR_ATL_0000_0000_0006
type
  __MIDL___MIDL_itf_DBR_ATL_0000_0000_0006 = TOleEnum;
const
  EBTE_Default = $00000000;
  EBTE_SHIFT_JIS_932 = $000003A4;
  EBTE_GB2312_936 = $000003A8;
  EBTE_KOREAN_949 = $000003B5;
  EBTE_BIG5_950 = $000003B6;
  EBTE_UTF16 = $000004B0;
  EBTE_UTF16BE = $000004B1;
  EBTE_UTF8 = $0000FDE9;

// Constants for enum __MIDL___MIDL_itf_DBR_ATL_0000_0000_0007
type
  __MIDL___MIDL_itf_DBR_ATL_0000_0000_0007 = TOleEnum;
const
  EIPT_Binary = $00000000;
  EIPT_BinaryInverted = $00000001;
  EIPT_GrayScaled = $00000002;
  EIPT_NV21 = $00000003;
  EIPT_RGB_565 = $00000004;
  EIPT_RGB_555 = $00000005;
  EIPT_RGB_888 = $00000006;
  EIPT_ARGB_8888 = $00000007;

// Constants for enum __MIDL___MIDL_itf_DBR_ATL_0000_0000_0004
type
  __MIDL___MIDL_itf_DBR_ATL_0000_0000_0004 = TOleEnum;
const
  ESRS_Left = $00000000;
  ESRS_Top = $00000001;
  ESRS_Right = $00000002;
  ESRS_Bottom = $00000003;

// Constants for enum __MIDL___MIDL_itf_DBR_ATL_0000_0000_0005
type
  __MIDL___MIDL_itf_DBR_ATL_0000_0000_0005 = TOleEnum;
const
  EBOT_Horizontal = $00000000;
  EBOT_Vertical = $00000001;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  _IBarcodeReaderEvents = dispinterface;
  IBarcodeReader = interface;
  IBarcodeReaderDisp = dispinterface;
  IBarcodeResultArray = interface;
  IBarcodeResultArrayDisp = dispinterface;
  IBarcodeResult = interface;
  IBarcodeResultDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  BarcodeReader = IBarcodeReader;
  BarcodeResult = IBarcodeResult;
  BarcodeResultArray = IBarcodeResultArray;


// *********************************************************************//
// Declaration of structures, unions and aliases.                         
// *********************************************************************//

  enumBarcodeFormat = __MIDL___MIDL_itf_DBR_ATL_0000_0000_0001; 
  enumImageCaptureDevice = __MIDL___MIDL_itf_DBR_ATL_0000_0000_0002; 
  enumBarcodeColorMode = __MIDL___MIDL_itf_DBR_ATL_0000_0000_0003; 
  enumBarcodeTextEncoding = __MIDL___MIDL_itf_DBR_ATL_0000_0000_0006; 
  enumImagePixelFormat = __MIDL___MIDL_itf_DBR_ATL_0000_0000_0007; 
  enumScanRegionSide = __MIDL___MIDL_itf_DBR_ATL_0000_0000_0004; 
  enumBarcodeOrientationType = __MIDL___MIDL_itf_DBR_ATL_0000_0000_0005; 

// *********************************************************************//
// DispIntf:  _IBarcodeReaderEvents
// Flags:     (4096) Dispatchable
// GUID:      {96D15AE6-535C-417F-A4B2-9567460A1311}
// *********************************************************************//
  _IBarcodeReaderEvents = dispinterface
    ['{96D15AE6-535C-417F-A4B2-9567460A1311}']
  end;

// *********************************************************************//
// Interface: IBarcodeReader
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {5847949D-7195-4613-AE5E-E03F84C7D641}
// *********************************************************************//
  IBarcodeReader = interface(IDispatch)
    ['{5847949D-7195-4613-AE5E-E03F84C7D641}']
    procedure InitLicense(const sLicenseKey: WideString); safecall;
    procedure DecodeFile(const sFileName: WideString); safecall;
    procedure DecodeDIB(hDIB: Integer); safecall;
    function Get_Barcodes: IBarcodeResultArray; safecall;
    function Get_BarcodesCount: Integer; safecall;
    function Get_ErrorCode: Integer; safecall;
    function Get_ErrorString: WideString; safecall;
    procedure DecodeStream(FileStream: OleVariant); safecall;
    procedure DecodeBase64String(const sBase64: WideString); safecall;
    function Get_BarcodeFormats: Integer; safecall;
    procedure Set_BarcodeFormats(pVal: Integer); safecall;
    function Get_MaxBarcodesNumPerPage: Integer; safecall;
    procedure Set_MaxBarcodesNumPerPage(pVal: Integer); safecall;
    function Get_ImageCaptureDevice: enumImageCaptureDevice; safecall;
    procedure Set_ImageCaptureDevice(pVal: enumImageCaptureDevice); safecall;
    function Get_BarcodeColorMode: enumBarcodeColorMode; safecall;
    procedure Set_BarcodeColorMode(pVal: enumBarcodeColorMode); safecall;
    function Get_TimeoutPerPage: Integer; safecall;
    procedure Set_TimeoutPerPage(pVal: Integer); safecall;
    function Get_UseOneDDeblur: WordBool; safecall;
    procedure Set_UseOneDDeblur(pVal: WordBool); safecall;
    function Get_ReturnUnrecognizedBarcode: WordBool; safecall;
    procedure Set_ReturnUnrecognizedBarcode(pVal: WordBool); safecall;
    function Get_BarcodeTextEncoding: enumBarcodeTextEncoding; safecall;
    procedure Set_BarcodeTextEncoding(pVal: enumBarcodeTextEncoding); safecall;
    procedure DecodeBufferEx(Buffer: OleVariant; iWidth: Integer; iHeight: Integer; 
                             iStride: Integer; format: enumImagePixelFormat); safecall;
    procedure AddPage(iPage: Integer); safecall;
    function GetPageCount: Integer; safecall;
    procedure GetPage(iIndex: Integer; out piPage: Integer); safecall;
    procedure ClearAllPages; safecall;
    procedure AddRegion(iLeft: Integer; iTop: Integer; iRight: Integer; iBottom: Integer; 
                        bByPercentage: WordBool); safecall;
    procedure AddRegion2(emSide: enumScanRegionSide; iPercentage: Integer); safecall;
    function GetRegionCount: Integer; safecall;
    procedure GetRegion(iIndex: Integer; out piLeft: Integer; out piTop: Integer; 
                        out piRight: Integer; out piBottom: Integer; out pbByPercentage: WordBool); safecall;
    procedure ClearAllRegions; safecall;
    procedure AddWidthRange(iMinWidth: Integer; iMaxWidth: Integer); safecall;
    function GetWidthRangeCount: Integer; safecall;
    procedure GetWidthRange(iIndex: Integer; out piMinWidth: Integer; out piMaxWidth: Integer); safecall;
    procedure ClearAllWidthRanges; safecall;
    procedure AddHeightRange(iMinHeight: Integer; iMaxHeight: Integer); safecall;
    function GetHeightRangeCount: Integer; safecall;
    procedure GetHeightRange(iIndex: Integer; out piMinHeight: Integer; out piMaxHeight: Integer); safecall;
    procedure ClearAllHeightRanges; safecall;
    procedure AddModuleSizeRange(iMinModuleSize: Integer; iMaxModuleSize: Integer); safecall;
    function GetModuleSizeRangeCount: Integer; safecall;
    procedure GetModuleSizeRange(iIndex: Integer; out piMinModuleSize: Integer; 
                                 out piMaxModuleSize: Integer); safecall;
    procedure ClearAllModuleSizeRanges; safecall;
    procedure AddAngleRange(iFromAngle: Integer; iToAngle: Integer); safecall;
    procedure AddAngle(emType: enumBarcodeOrientationType); safecall;
    function GetAngleRangeCount: Integer; safecall;
    procedure GetAngleRange(iIndex: Integer; out piFromAngle: Integer; out piToAngle: Integer); safecall;
    procedure ClearAllAngleRanges; safecall;
    function LoadSetting(const sJsonSetting: WideString): WordBool; safecall;
    property Barcodes: IBarcodeResultArray read Get_Barcodes;
    property BarcodesCount: Integer read Get_BarcodesCount;
    property ErrorCode: Integer read Get_ErrorCode;
    property ErrorString: WideString read Get_ErrorString;
    property BarcodeFormats: Integer read Get_BarcodeFormats write Set_BarcodeFormats;
    property MaxBarcodesNumPerPage: Integer read Get_MaxBarcodesNumPerPage write Set_MaxBarcodesNumPerPage;
    property ImageCaptureDevice: enumImageCaptureDevice read Get_ImageCaptureDevice write Set_ImageCaptureDevice;
    property BarcodeColorMode: enumBarcodeColorMode read Get_BarcodeColorMode write Set_BarcodeColorMode;
    property TimeoutPerPage: Integer read Get_TimeoutPerPage write Set_TimeoutPerPage;
    property UseOneDDeblur: WordBool read Get_UseOneDDeblur write Set_UseOneDDeblur;
    property ReturnUnrecognizedBarcode: WordBool read Get_ReturnUnrecognizedBarcode write Set_ReturnUnrecognizedBarcode;
    property BarcodeTextEncoding: enumBarcodeTextEncoding read Get_BarcodeTextEncoding write Set_BarcodeTextEncoding;
  end;

// *********************************************************************//
// DispIntf:  IBarcodeReaderDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {5847949D-7195-4613-AE5E-E03F84C7D641}
// *********************************************************************//
  IBarcodeReaderDisp = dispinterface
    ['{5847949D-7195-4613-AE5E-E03F84C7D641}']
    procedure InitLicense(const sLicenseKey: WideString); dispid 1;
    procedure DecodeFile(const sFileName: WideString); dispid 2;
    procedure DecodeDIB(hDIB: Integer); dispid 4;
    property Barcodes: IBarcodeResultArray readonly dispid 7;
    property BarcodesCount: Integer readonly dispid 8;
    property ErrorCode: Integer readonly dispid 9;
    property ErrorString: WideString readonly dispid 10;
    procedure DecodeStream(FileStream: OleVariant); dispid 13;
    procedure DecodeBase64String(const sBase64: WideString); dispid 15;
    property BarcodeFormats: Integer dispid 17;
    property MaxBarcodesNumPerPage: Integer dispid 18;
    property ImageCaptureDevice: enumImageCaptureDevice dispid 19;
    property BarcodeColorMode: enumBarcodeColorMode dispid 20;
    property TimeoutPerPage: Integer dispid 21;
    property UseOneDDeblur: WordBool dispid 22;
    property ReturnUnrecognizedBarcode: WordBool dispid 23;
    property BarcodeTextEncoding: enumBarcodeTextEncoding dispid 24;
    procedure DecodeBufferEx(Buffer: OleVariant; iWidth: Integer; iHeight: Integer; 
                             iStride: Integer; format: enumImagePixelFormat); dispid 25;
    procedure AddPage(iPage: Integer); dispid 26;
    function GetPageCount: Integer; dispid 27;
    procedure GetPage(iIndex: Integer; out piPage: Integer); dispid 28;
    procedure ClearAllPages; dispid 29;
    procedure AddRegion(iLeft: Integer; iTop: Integer; iRight: Integer; iBottom: Integer; 
                        bByPercentage: WordBool); dispid 30;
    procedure AddRegion2(emSide: enumScanRegionSide; iPercentage: Integer); dispid 31;
    function GetRegionCount: Integer; dispid 32;
    procedure GetRegion(iIndex: Integer; out piLeft: Integer; out piTop: Integer; 
                        out piRight: Integer; out piBottom: Integer; out pbByPercentage: WordBool); dispid 33;
    procedure ClearAllRegions; dispid 34;
    procedure AddWidthRange(iMinWidth: Integer; iMaxWidth: Integer); dispid 35;
    function GetWidthRangeCount: Integer; dispid 36;
    procedure GetWidthRange(iIndex: Integer; out piMinWidth: Integer; out piMaxWidth: Integer); dispid 37;
    procedure ClearAllWidthRanges; dispid 38;
    procedure AddHeightRange(iMinHeight: Integer; iMaxHeight: Integer); dispid 39;
    function GetHeightRangeCount: Integer; dispid 40;
    procedure GetHeightRange(iIndex: Integer; out piMinHeight: Integer; out piMaxHeight: Integer); dispid 41;
    procedure ClearAllHeightRanges; dispid 42;
    procedure AddModuleSizeRange(iMinModuleSize: Integer; iMaxModuleSize: Integer); dispid 43;
    function GetModuleSizeRangeCount: Integer; dispid 44;
    procedure GetModuleSizeRange(iIndex: Integer; out piMinModuleSize: Integer; 
                                 out piMaxModuleSize: Integer); dispid 45;
    procedure ClearAllModuleSizeRanges; dispid 46;
    procedure AddAngleRange(iFromAngle: Integer; iToAngle: Integer); dispid 47;
    procedure AddAngle(emType: enumBarcodeOrientationType); dispid 48;
    function GetAngleRangeCount: Integer; dispid 49;
    procedure GetAngleRange(iIndex: Integer; out piFromAngle: Integer; out piToAngle: Integer); dispid 50;
    procedure ClearAllAngleRanges; dispid 51;
    function LoadSetting(const sJsonSetting: WideString): WordBool; dispid 52;
  end;

// *********************************************************************//
// Interface: IBarcodeResultArray
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {C37FE03C-854E-4057-A9C4-7FA47992A434}
// *********************************************************************//
  IBarcodeResultArray = interface(IDispatch)
    ['{C37FE03C-854E-4057-A9C4-7FA47992A434}']
    function Get_Count: Integer; safecall;
    function Item(iIndex: Integer): IBarcodeResult; safecall;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IBarcodeResultArrayDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {C37FE03C-854E-4057-A9C4-7FA47992A434}
// *********************************************************************//
  IBarcodeResultArrayDisp = dispinterface
    ['{C37FE03C-854E-4057-A9C4-7FA47992A434}']
    property Count: Integer readonly dispid 1;
    function Item(iIndex: Integer): IBarcodeResult; dispid 2;
  end;

// *********************************************************************//
// Interface: IBarcodeResult
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {5D746054-19C1-494F-8703-A92BA29B4AB8}
// *********************************************************************//
  IBarcodeResult = interface(IDispatch)
    ['{5D746054-19C1-494F-8703-A92BA29B4AB8}']
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
    function Get_BarcodeFormat: enumBarcodeFormat; safecall;
    function Get_BarcodeFormatString: WideString; safecall;
    function Get_Angle: Integer; safecall;
    function Get_ModuleSize: Integer; safecall;
    function Get_IsUnrecognized: WordBool; safecall;
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
    property BarcodeFormat: enumBarcodeFormat read Get_BarcodeFormat;
    property BarcodeFormatString: WideString read Get_BarcodeFormatString;
    property Angle: Integer read Get_Angle;
    property ModuleSize: Integer read Get_ModuleSize;
    property IsUnrecognized: WordBool read Get_IsUnrecognized;
  end;

// *********************************************************************//
// DispIntf:  IBarcodeResultDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {5D746054-19C1-494F-8703-A92BA29B4AB8}
// *********************************************************************//
  IBarcodeResultDisp = dispinterface
    ['{5D746054-19C1-494F-8703-A92BA29B4AB8}']
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
    property BarcodeFormat: enumBarcodeFormat readonly dispid 17;
    property BarcodeFormatString: WideString readonly dispid 18;
    property Angle: Integer readonly dispid 19;
    property ModuleSize: Integer readonly dispid 20;
    property IsUnrecognized: WordBool readonly dispid 21;
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
    function Get_Barcodes: IBarcodeResultArray;
    function Get_BarcodesCount: Integer;
    function Get_ErrorCode: Integer;
    function Get_ErrorString: WideString;
    function Get_BarcodeFormats: Integer;
    procedure Set_BarcodeFormats(pVal: Integer);
    function Get_MaxBarcodesNumPerPage: Integer;
    procedure Set_MaxBarcodesNumPerPage(pVal: Integer);
    function Get_ImageCaptureDevice: enumImageCaptureDevice;
    procedure Set_ImageCaptureDevice(pVal: enumImageCaptureDevice);
    function Get_BarcodeColorMode: enumBarcodeColorMode;
    procedure Set_BarcodeColorMode(pVal: enumBarcodeColorMode);
    function Get_TimeoutPerPage: Integer;
    procedure Set_TimeoutPerPage(pVal: Integer);
    function Get_UseOneDDeblur: WordBool;
    procedure Set_UseOneDDeblur(pVal: WordBool);
    function Get_ReturnUnrecognizedBarcode: WordBool;
    procedure Set_ReturnUnrecognizedBarcode(pVal: WordBool);
    function Get_BarcodeTextEncoding: enumBarcodeTextEncoding;
    procedure Set_BarcodeTextEncoding(pVal: enumBarcodeTextEncoding);
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IBarcodeReader);
    procedure Disconnect; override;
    procedure InitLicense(const sLicenseKey: WideString);
    procedure DecodeFile(const sFileName: WideString);
    procedure DecodeDIB(hDIB: Integer);
    procedure DecodeStream(FileStream: OleVariant);
    procedure DecodeBase64String(const sBase64: WideString);
    procedure DecodeBufferEx(Buffer: OleVariant; iWidth: Integer; iHeight: Integer; 
                             iStride: Integer; format: enumImagePixelFormat);
    procedure AddPage(iPage: Integer);
    function GetPageCount: Integer;
    procedure GetPage(iIndex: Integer; out piPage: Integer);
    procedure ClearAllPages;
    procedure AddRegion(iLeft: Integer; iTop: Integer; iRight: Integer; iBottom: Integer; 
                        bByPercentage: WordBool);
    procedure AddRegion2(emSide: enumScanRegionSide; iPercentage: Integer);
    function GetRegionCount: Integer;
    procedure GetRegion(iIndex: Integer; out piLeft: Integer; out piTop: Integer; 
                        out piRight: Integer; out piBottom: Integer; out pbByPercentage: WordBool);
    procedure ClearAllRegions;
    procedure AddWidthRange(iMinWidth: Integer; iMaxWidth: Integer);
    function GetWidthRangeCount: Integer;
    procedure GetWidthRange(iIndex: Integer; out piMinWidth: Integer; out piMaxWidth: Integer);
    procedure ClearAllWidthRanges;
    procedure AddHeightRange(iMinHeight: Integer; iMaxHeight: Integer);
    function GetHeightRangeCount: Integer;
    procedure GetHeightRange(iIndex: Integer; out piMinHeight: Integer; out piMaxHeight: Integer);
    procedure ClearAllHeightRanges;
    procedure AddModuleSizeRange(iMinModuleSize: Integer; iMaxModuleSize: Integer);
    function GetModuleSizeRangeCount: Integer;
    procedure GetModuleSizeRange(iIndex: Integer; out piMinModuleSize: Integer; 
                                 out piMaxModuleSize: Integer);
    procedure ClearAllModuleSizeRanges;
    procedure AddAngleRange(iFromAngle: Integer; iToAngle: Integer);
    procedure AddAngle(emType: enumBarcodeOrientationType);
    function GetAngleRangeCount: Integer;
    procedure GetAngleRange(iIndex: Integer; out piFromAngle: Integer; out piToAngle: Integer);
    procedure ClearAllAngleRanges;
    function LoadSetting(const sJsonSetting: WideString): WordBool;
    property DefaultInterface: IBarcodeReader read GetDefaultInterface;
    property Barcodes: IBarcodeResultArray read Get_Barcodes;
    property BarcodesCount: Integer read Get_BarcodesCount;
    property ErrorCode: Integer read Get_ErrorCode;
    property ErrorString: WideString read Get_ErrorString;
    property BarcodeFormats: Integer read Get_BarcodeFormats write Set_BarcodeFormats;
    property MaxBarcodesNumPerPage: Integer read Get_MaxBarcodesNumPerPage write Set_MaxBarcodesNumPerPage;
    property ImageCaptureDevice: enumImageCaptureDevice read Get_ImageCaptureDevice write Set_ImageCaptureDevice;
    property BarcodeColorMode: enumBarcodeColorMode read Get_BarcodeColorMode write Set_BarcodeColorMode;
    property TimeoutPerPage: Integer read Get_TimeoutPerPage write Set_TimeoutPerPage;
    property UseOneDDeblur: WordBool read Get_UseOneDDeblur write Set_UseOneDDeblur;
    property ReturnUnrecognizedBarcode: WordBool read Get_ReturnUnrecognizedBarcode write Set_ReturnUnrecognizedBarcode;
    property BarcodeTextEncoding: enumBarcodeTextEncoding read Get_BarcodeTextEncoding write Set_BarcodeTextEncoding;
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
    function Get_Barcodes: IBarcodeResultArray;
    function Get_BarcodesCount: Integer;
    function Get_ErrorCode: Integer;
    function Get_ErrorString: WideString;
    function Get_BarcodeFormats: Integer;
    procedure Set_BarcodeFormats(pVal: Integer);
    function Get_MaxBarcodesNumPerPage: Integer;
    procedure Set_MaxBarcodesNumPerPage(pVal: Integer);
    function Get_ImageCaptureDevice: enumImageCaptureDevice;
    procedure Set_ImageCaptureDevice(pVal: enumImageCaptureDevice);
    function Get_BarcodeColorMode: enumBarcodeColorMode;
    procedure Set_BarcodeColorMode(pVal: enumBarcodeColorMode);
    function Get_TimeoutPerPage: Integer;
    procedure Set_TimeoutPerPage(pVal: Integer);
    function Get_UseOneDDeblur: WordBool;
    procedure Set_UseOneDDeblur(pVal: WordBool);
    function Get_ReturnUnrecognizedBarcode: WordBool;
    procedure Set_ReturnUnrecognizedBarcode(pVal: WordBool);
    function Get_BarcodeTextEncoding: enumBarcodeTextEncoding;
    procedure Set_BarcodeTextEncoding(pVal: enumBarcodeTextEncoding);
  public
    property DefaultInterface: IBarcodeReader read GetDefaultInterface;
  published
    property BarcodeFormats: Integer read Get_BarcodeFormats write Set_BarcodeFormats;
    property MaxBarcodesNumPerPage: Integer read Get_MaxBarcodesNumPerPage write Set_MaxBarcodesNumPerPage;
    property ImageCaptureDevice: enumImageCaptureDevice read Get_ImageCaptureDevice write Set_ImageCaptureDevice;
    property BarcodeColorMode: enumBarcodeColorMode read Get_BarcodeColorMode write Set_BarcodeColorMode;
    property TimeoutPerPage: Integer read Get_TimeoutPerPage write Set_TimeoutPerPage;
    property UseOneDDeblur: WordBool read Get_UseOneDDeblur write Set_UseOneDDeblur;
    property ReturnUnrecognizedBarcode: WordBool read Get_ReturnUnrecognizedBarcode write Set_ReturnUnrecognizedBarcode;
    property BarcodeTextEncoding: enumBarcodeTextEncoding read Get_BarcodeTextEncoding write Set_BarcodeTextEncoding;
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
    ClassID:   '{34251D1F-7229-4CED-B32A-CBBDA8DDBC31}';
    IntfIID:   '{5847949D-7195-4613-AE5E-E03F84C7D641}';
    EventIID:  '{96D15AE6-535C-417F-A4B2-9567460A1311}';
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

function TBarcodeReader.Get_BarcodeFormats: Integer;
begin
    Result := DefaultInterface.BarcodeFormats;
end;

procedure TBarcodeReader.Set_BarcodeFormats(pVal: Integer);
begin
  DefaultInterface.Set_BarcodeFormats(pVal);
end;

function TBarcodeReader.Get_MaxBarcodesNumPerPage: Integer;
begin
    Result := DefaultInterface.MaxBarcodesNumPerPage;
end;

procedure TBarcodeReader.Set_MaxBarcodesNumPerPage(pVal: Integer);
begin
  DefaultInterface.Set_MaxBarcodesNumPerPage(pVal);
end;

function TBarcodeReader.Get_ImageCaptureDevice: enumImageCaptureDevice;
begin
    Result := DefaultInterface.ImageCaptureDevice;
end;

procedure TBarcodeReader.Set_ImageCaptureDevice(pVal: enumImageCaptureDevice);
begin
  DefaultInterface.Set_ImageCaptureDevice(pVal);
end;

function TBarcodeReader.Get_BarcodeColorMode: enumBarcodeColorMode;
begin
    Result := DefaultInterface.BarcodeColorMode;
end;

procedure TBarcodeReader.Set_BarcodeColorMode(pVal: enumBarcodeColorMode);
begin
  DefaultInterface.Set_BarcodeColorMode(pVal);
end;

function TBarcodeReader.Get_TimeoutPerPage: Integer;
begin
    Result := DefaultInterface.TimeoutPerPage;
end;

procedure TBarcodeReader.Set_TimeoutPerPage(pVal: Integer);
begin
  DefaultInterface.Set_TimeoutPerPage(pVal);
end;

function TBarcodeReader.Get_UseOneDDeblur: WordBool;
begin
    Result := DefaultInterface.UseOneDDeblur;
end;

procedure TBarcodeReader.Set_UseOneDDeblur(pVal: WordBool);
begin
  DefaultInterface.Set_UseOneDDeblur(pVal);
end;

function TBarcodeReader.Get_ReturnUnrecognizedBarcode: WordBool;
begin
    Result := DefaultInterface.ReturnUnrecognizedBarcode;
end;

procedure TBarcodeReader.Set_ReturnUnrecognizedBarcode(pVal: WordBool);
begin
  DefaultInterface.Set_ReturnUnrecognizedBarcode(pVal);
end;

function TBarcodeReader.Get_BarcodeTextEncoding: enumBarcodeTextEncoding;
begin
    Result := DefaultInterface.BarcodeTextEncoding;
end;

procedure TBarcodeReader.Set_BarcodeTextEncoding(pVal: enumBarcodeTextEncoding);
begin
  DefaultInterface.Set_BarcodeTextEncoding(pVal);
end;

procedure TBarcodeReader.InitLicense(const sLicenseKey: WideString);
begin
  DefaultInterface.InitLicense(sLicenseKey);
end;

procedure TBarcodeReader.DecodeFile(const sFileName: WideString);
begin
  DefaultInterface.DecodeFile(sFileName);
end;

procedure TBarcodeReader.DecodeDIB(hDIB: Integer);
begin
  DefaultInterface.DecodeDIB(hDIB);
end;

procedure TBarcodeReader.DecodeStream(FileStream: OleVariant);
begin
  DefaultInterface.DecodeStream(FileStream);
end;

procedure TBarcodeReader.DecodeBase64String(const sBase64: WideString);
begin
  DefaultInterface.DecodeBase64String(sBase64);
end;

procedure TBarcodeReader.DecodeBufferEx(Buffer: OleVariant; iWidth: Integer; iHeight: Integer; 
                                        iStride: Integer; format: enumImagePixelFormat);
begin
  DefaultInterface.DecodeBufferEx(Buffer, iWidth, iHeight, iStride, format);
end;

procedure TBarcodeReader.AddPage(iPage: Integer);
begin
  DefaultInterface.AddPage(iPage);
end;

function TBarcodeReader.GetPageCount: Integer;
begin
  Result := DefaultInterface.GetPageCount;
end;

procedure TBarcodeReader.GetPage(iIndex: Integer; out piPage: Integer);
begin
  DefaultInterface.GetPage(iIndex, piPage);
end;

procedure TBarcodeReader.ClearAllPages;
begin
  DefaultInterface.ClearAllPages;
end;

procedure TBarcodeReader.AddRegion(iLeft: Integer; iTop: Integer; iRight: Integer; 
                                   iBottom: Integer; bByPercentage: WordBool);
begin
  DefaultInterface.AddRegion(iLeft, iTop, iRight, iBottom, bByPercentage);
end;

procedure TBarcodeReader.AddRegion2(emSide: enumScanRegionSide; iPercentage: Integer);
begin
  DefaultInterface.AddRegion2(emSide, iPercentage);
end;

function TBarcodeReader.GetRegionCount: Integer;
begin
  Result := DefaultInterface.GetRegionCount;
end;

procedure TBarcodeReader.GetRegion(iIndex: Integer; out piLeft: Integer; out piTop: Integer; 
                                   out piRight: Integer; out piBottom: Integer; 
                                   out pbByPercentage: WordBool);
begin
  DefaultInterface.GetRegion(iIndex, piLeft, piTop, piRight, piBottom, pbByPercentage);
end;

procedure TBarcodeReader.ClearAllRegions;
begin
  DefaultInterface.ClearAllRegions;
end;

procedure TBarcodeReader.AddWidthRange(iMinWidth: Integer; iMaxWidth: Integer);
begin
  DefaultInterface.AddWidthRange(iMinWidth, iMaxWidth);
end;

function TBarcodeReader.GetWidthRangeCount: Integer;
begin
  Result := DefaultInterface.GetWidthRangeCount;
end;

procedure TBarcodeReader.GetWidthRange(iIndex: Integer; out piMinWidth: Integer; 
                                       out piMaxWidth: Integer);
begin
  DefaultInterface.GetWidthRange(iIndex, piMinWidth, piMaxWidth);
end;

procedure TBarcodeReader.ClearAllWidthRanges;
begin
  DefaultInterface.ClearAllWidthRanges;
end;

procedure TBarcodeReader.AddHeightRange(iMinHeight: Integer; iMaxHeight: Integer);
begin
  DefaultInterface.AddHeightRange(iMinHeight, iMaxHeight);
end;

function TBarcodeReader.GetHeightRangeCount: Integer;
begin
  Result := DefaultInterface.GetHeightRangeCount;
end;

procedure TBarcodeReader.GetHeightRange(iIndex: Integer; out piMinHeight: Integer; 
                                        out piMaxHeight: Integer);
begin
  DefaultInterface.GetHeightRange(iIndex, piMinHeight, piMaxHeight);
end;

procedure TBarcodeReader.ClearAllHeightRanges;
begin
  DefaultInterface.ClearAllHeightRanges;
end;

procedure TBarcodeReader.AddModuleSizeRange(iMinModuleSize: Integer; iMaxModuleSize: Integer);
begin
  DefaultInterface.AddModuleSizeRange(iMinModuleSize, iMaxModuleSize);
end;

function TBarcodeReader.GetModuleSizeRangeCount: Integer;
begin
  Result := DefaultInterface.GetModuleSizeRangeCount;
end;

procedure TBarcodeReader.GetModuleSizeRange(iIndex: Integer; out piMinModuleSize: Integer; 
                                            out piMaxModuleSize: Integer);
begin
  DefaultInterface.GetModuleSizeRange(iIndex, piMinModuleSize, piMaxModuleSize);
end;

procedure TBarcodeReader.ClearAllModuleSizeRanges;
begin
  DefaultInterface.ClearAllModuleSizeRanges;
end;

procedure TBarcodeReader.AddAngleRange(iFromAngle: Integer; iToAngle: Integer);
begin
  DefaultInterface.AddAngleRange(iFromAngle, iToAngle);
end;

procedure TBarcodeReader.AddAngle(emType: enumBarcodeOrientationType);
begin
  DefaultInterface.AddAngle(emType);
end;

function TBarcodeReader.GetAngleRangeCount: Integer;
begin
  Result := DefaultInterface.GetAngleRangeCount;
end;

procedure TBarcodeReader.GetAngleRange(iIndex: Integer; out piFromAngle: Integer; 
                                       out piToAngle: Integer);
begin
  DefaultInterface.GetAngleRange(iIndex, piFromAngle, piToAngle);
end;

procedure TBarcodeReader.ClearAllAngleRanges;
begin
  DefaultInterface.ClearAllAngleRanges;
end;

function TBarcodeReader.LoadSetting(const sJsonSetting: WideString): WordBool;
begin
  Result := DefaultInterface.LoadSetting(sJsonSetting);
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

function TBarcodeReaderProperties.Get_BarcodeFormats: Integer;
begin
    Result := DefaultInterface.BarcodeFormats;
end;

procedure TBarcodeReaderProperties.Set_BarcodeFormats(pVal: Integer);
begin
  DefaultInterface.Set_BarcodeFormats(pVal);
end;

function TBarcodeReaderProperties.Get_MaxBarcodesNumPerPage: Integer;
begin
    Result := DefaultInterface.MaxBarcodesNumPerPage;
end;

procedure TBarcodeReaderProperties.Set_MaxBarcodesNumPerPage(pVal: Integer);
begin
  DefaultInterface.Set_MaxBarcodesNumPerPage(pVal);
end;

function TBarcodeReaderProperties.Get_ImageCaptureDevice: enumImageCaptureDevice;
begin
    Result := DefaultInterface.ImageCaptureDevice;
end;

procedure TBarcodeReaderProperties.Set_ImageCaptureDevice(pVal: enumImageCaptureDevice);
begin
  DefaultInterface.Set_ImageCaptureDevice(pVal);
end;

function TBarcodeReaderProperties.Get_BarcodeColorMode: enumBarcodeColorMode;
begin
    Result := DefaultInterface.BarcodeColorMode;
end;

procedure TBarcodeReaderProperties.Set_BarcodeColorMode(pVal: enumBarcodeColorMode);
begin
  DefaultInterface.Set_BarcodeColorMode(pVal);
end;

function TBarcodeReaderProperties.Get_TimeoutPerPage: Integer;
begin
    Result := DefaultInterface.TimeoutPerPage;
end;

procedure TBarcodeReaderProperties.Set_TimeoutPerPage(pVal: Integer);
begin
  DefaultInterface.Set_TimeoutPerPage(pVal);
end;

function TBarcodeReaderProperties.Get_UseOneDDeblur: WordBool;
begin
    Result := DefaultInterface.UseOneDDeblur;
end;

procedure TBarcodeReaderProperties.Set_UseOneDDeblur(pVal: WordBool);
begin
  DefaultInterface.Set_UseOneDDeblur(pVal);
end;

function TBarcodeReaderProperties.Get_ReturnUnrecognizedBarcode: WordBool;
begin
    Result := DefaultInterface.ReturnUnrecognizedBarcode;
end;

procedure TBarcodeReaderProperties.Set_ReturnUnrecognizedBarcode(pVal: WordBool);
begin
  DefaultInterface.Set_ReturnUnrecognizedBarcode(pVal);
end;

function TBarcodeReaderProperties.Get_BarcodeTextEncoding: enumBarcodeTextEncoding;
begin
    Result := DefaultInterface.BarcodeTextEncoding;
end;

procedure TBarcodeReaderProperties.Set_BarcodeTextEncoding(pVal: enumBarcodeTextEncoding);
begin
  DefaultInterface.Set_BarcodeTextEncoding(pVal);
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
  RegisterComponents(dtlServerPage, [TBarcodeReader]);
end;

end.
