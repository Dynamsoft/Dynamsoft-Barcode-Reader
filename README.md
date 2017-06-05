Dynamsoft Barcode Reader
=========
version 5.1

Introduction
-----------

Dynamsoft’s [Barcode Reader SDK][1] enables you to efficiently embed barcode reading functionality in your application using just a few lines of code. This can save you from months of added development time and extra costs. With the Barcode Reader SDK, you can decode barcodes from various image file formats (bmp, jpg, png and tiff). This includes from device-independent bitmap (DIB) formats which can be obtained from cameras, scanners, etc.

Two editions, for Windows and Mac, are available. The Windows Edition provides C, C++, ActiveX / COM and .NET APIs. The Mac Edition provides C and C++ APIs. You can use the SDK in various development environments, such as Visual Studio .NET (C# / VB.NET), Visual C++, VB6, Delphi, Eclipse, Xcode, etc.

![image](http://www.codepool.biz/wp-content/uploads/2015/08/dbr_3_0_screenshot.png)

Download
-----------
http://www.dynamsoft.com/Downloads/Dynamic-Barcode-Reader-Download.aspx

Documentation
--------------

* Windows: http://www.dynamsoft.com/help/Barcode-Reader/index.html
* Mac: http://www.dynamsoft.com/help/Barcode-Reader-Mac/index.html

Specifications
-----------

### Features
* Reads barcodes within a specified area of a selected image
* Reads multiple barcodes in one image
* Can read poor quality and damaged barcodes
* Detects barcode at any orientation and rotation angle

### Edit
* ActiveX, Plug-in and HTML5 editions provide an Image Editor for image editing and viewing.
* ActiveX, Plug-in and HTML5 Editions support adding colored rectangles to images.
* Supports multiple images selection.
* Supports image swapping.
* Supports clearing specified areas of an image, and filling cleared areas with color.
* Supports zooming.

### Supported Barcode Types
* 1D barcodes: Code39, Code93, Code128, Codabar, ITF, EAN13, EAN8, UPCA, UPCE
* 2D barcodes: QR Code, DataMatrix, PDF417

### Barcode Reading Results
* Barcode type
* Barcode count
* Barcode value as string
* Barcode raw data as bytes
* Barcode bounding rectangle
* Coordinate of four corners
* Page number

### Supported Image Source Types
* Bmp, jpg, png, and tiff image files; multi-page tiff also supported
* Windows DIB and .NET bitmap
* Black/white, grayscale or color

### Runtime Environment
* Windows Workstation: XP, Vista, 7, 8
* Windows Server: 2003, 2008, 2008 R2, 2012
* Mac OS X: Mac OSX 10.6 and above

### Languages and Environment
* APIs: C, C++, ActiveX/COM, .NET
* Projects: 32-bit or 64-bit
* Languages: C#, VB.net, Java, C++, VB6, Delphi, PHP, VBScript, JavaScript, Python, Perl, Ruby etc.

[More][2]

Package
-------
```
Barcode Reader 2.0 Trial
/Documents
/Images
/Include
/Lib
/Redist
/Samples
/LicenseManager.exe

```

A Simple Barcode Reader Application in C++
---------------------------------
  ```C++
#include <stdio.h>
#include "<relative path>/If_DBRP.h"
#ifdef _WIN64
#pragma comment(lib, "<relative path>/DBRx64.lib")
#else
#pragma comment(lib, "<relative path>/DBRx86.lib")
#endif

int main(int argc, const char* argv[])
{
    //Define variables
	const char * pszImageFile = "<your image file full path>";
	int iIndex = 0;
	int iRet = -1;
        
    //Initialize license prior to any decoding
    CBarcodeReader reader;
	reader.InitLicense("<your license key here>");

    //Start decoding
    iRet = reader.DecodeFile(pszImageFile);

    //If not DBR_OK
	if (iRet != DBR_OK)
	{
		printf("Failed to read barcode: %d\r\n%s\r\n",iRet, DBR_GetErrorString(iRet));
		return iRet;
	}

    //If DBR_OK
	pBarcodeResultArray paryResult = NULL;
    reader.GetBarcodes(&paryResult);
	printf("%d total barcodes found. \r\n", paryResult->iBarcodeCount);
	for (iIndex = 0; iIndex < paryResult->iBarcodeCount; iIndex++)
	{
		printf("Result %d\r\n", iIndex + 1);
		printf("PageNum: %d\r\n", paryResult->ppBarcodes[iIndex]->iPageNum);
		printf("BarcodeFormat: %lld\r\n", paryResult->ppBarcodes[iIndex]->llFormat);
		printf("Text read: %s\r\n", paryResult->ppBarcodes[iIndex]->pBarcodeData);
	}

    //Finally release BarcodeResultArray
    CBarcodeReader::FreeBarcodeResults(&paryResult);
        
	return 0;
}

  ```

[1]:http://www.dynamsoft.com/Products/Dynamic-Barcode-Reader.aspx
[2]:http://www.dynamsoft.com/Products/Dynamic-Barcode-Reader-Feature.aspx
