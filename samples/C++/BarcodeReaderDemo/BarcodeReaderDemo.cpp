// BarcodeReaderDemo.cpp : Defines the entry point for the console application.

#include <windows.h>
#include <stdio.h>
#include <conio.h>
#include "../../../../Components/C_C++/Include/If_DBRP.h"
#ifdef _WIN64
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx64.lib")
#else
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx86.lib")
#endif

struct barcode_format
{
	const char * pszFormat;
	__int64 llFormat;
};

static struct barcode_format Barcode_Formats[] = 
{
	{"CODE_39", CODE_39},
	{"CODE_128", CODE_128},
	{"CODE_93", CODE_93},
	{"CODABAR", CODABAR},
	{"ITF", ITF},
	{"UPC_A", UPC_A},
	{"UPC_E", UPC_E},
	{"EAN_13", EAN_13},
	{"EAN_8", EAN_8},
	{"INDUSTRIAL_25",INDUSTRIAL_25},
	{"OneD", OneD},
	{"QR_CODE", QR_CODE},
	{"PDF417",PDF417},
	{"DATAMATRIX", DATAMATRIX}		
};

__int64 GetFormat(int iIndex)
{
	__int64 llFormat = 0;

	switch(iIndex)
	{
	case 1:
		llFormat = OneD | QR_CODE |PDF417 | DATAMATRIX;
		break;
	case 2:
		llFormat = OneD;
		break;
	case 3:
		llFormat = QR_CODE;
		break;
	case 4:
		llFormat = CODE_39;
		break;	
	case 5:
		llFormat = CODE_128;
		break;	
	case 6:
		llFormat = CODE_93;
		break;	
	case 7:
		llFormat = CODABAR;
		break;	
	case 8:
		llFormat = ITF;
		break;
	case 9:
		llFormat = INDUSTRIAL_25;
		break;
	case 10:
		llFormat = EAN_13;
		break;
	case 11:
		llFormat = EAN_8;
		break;
	case 12:
		llFormat = UPC_A;
		break;
	case 13:
		llFormat = UPC_E;
		break;
	case 14:
		llFormat = PDF417;
		break;
	case 15:
		llFormat = DATAMATRIX;
		break;
	default:
		break;
	}

	return llFormat;
}

const char * GetFormatStr(__int64 format)
{
	int iCount = sizeof(Barcode_Formats)/sizeof(Barcode_Formats[0]);
	
	for (int index = 0; index < iCount; index ++)
	{
		if (Barcode_Formats[index].llFormat == format)
			return Barcode_Formats[index].pszFormat;
	}
	
	return "UNKNOWN";
}

int main(int argc, const char* argv[])
{

	__int64 llFormat = (OneD|QR_CODE|PDF417|DATAMATRIX);

	char pszBuffer[512] = {0};

	char pszImageFile[512] = {0};
	int iMaxCount = 0x7FFFFFFF;
	int iIndex = 0;
	ReaderOptions ro = {0};
	int iRet = -1;
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	unsigned __int64 ullTimeBegin = 0;
	unsigned __int64 ullTimeEnd = 0;
	size_t iLen = 0;
	FILE* fp = NULL;
	int iExitFlag = 0;

	printf("*************************************************\r\n");
	printf("Welcome to Dynamsoft Barcode Reader Demo\r\n");
	printf("*************************************************\r\n");
	printf("Hints: Please input 'Q'or 'q' to quit the application.\r\n");
	

	while(1)
	{
		iMaxCount = 0x7FFFFFFF;
		llFormat = (OneD|QR_CODE|PDF417|DATAMATRIX);

		while(1)
		{
			printf("\r\n>> Step 1: Input your image file's full path:\r\n");
			gets(pszBuffer);
			iLen = strlen(pszBuffer);
			if(iLen > 0)
			{
				if(strlen(pszBuffer) == 1 && (pszBuffer[0] == 'q' || pszBuffer[0] == 'Q'))
				{
					iExitFlag = 1;
					break;
				}

				memset(pszImageFile, 0, 512);
				if(pszBuffer[0]=='\"' && pszBuffer[iLen-1] == '\"')
					memcpy(pszImageFile, &pszBuffer[1], iLen-2);
				else
					memcpy(pszImageFile, pszBuffer, iLen);

				fp = fopen(pszImageFile, "rb");
				if(fp != NULL)
				{
					fclose(fp);
					break;
				}
			}
			
			printf("Please input a valid path.\r\n");
		}

		if(iExitFlag)
			break;

		while(1)
		{
			printf("\r\n>> Step 2: Choose a number for the format(s) of your barcode image:\r\n");
			printf("   1: All\r\n");
			printf("   2: OneD\r\n");
			printf("   3: QR Code\r\n");
			printf("   4: Code 39\r\n");
			printf("   5: Code 128\r\n");
			printf("   6: Code 93\r\n");
			printf("   7: Codabar\r\n");
			printf("   8: Interleaved 2 of 5\r\n");
			printf("   9: Industrial 2 of 5\r\n");
			printf("   10: EAN-13\r\n");
			printf("   11: EAN-8\r\n");
			printf("   12: UPC-A\r\n");
			printf("   13: UPC-E\r\n");
			printf("   14: PDF417\r\n");
			printf("   15: DATAMATRIX\r\n");

			gets(pszBuffer);	
			iLen = strlen(pszBuffer);
			if(iLen > 0)
			{
				iIndex = atoi(pszBuffer);
				llFormat = GetFormat(iIndex);
				if(llFormat != 0)
					break;
			}

			printf("Please choose a valid number. \r\n");

		}

		while(1)
		{
			printf("\r\n>> Step 3: Input the maximum number of barcodes to read per page: \r\n");
			gets(pszBuffer);
			iLen = strlen(pszBuffer);

			if(iLen > 0)
			{
				iMaxCount = atoi(pszBuffer);
				if(iMaxCount > 0)
					break;
			}

			printf("Please re-input the correct number again. \r\n");
		}

		printf("\r\nBarcode Results:\r\n----------------------------------------------------------\r\n");

		// Set license
		CBarcodeReader reader;
		reader.InitLicense("38B9B94D8B0E2B41641A47AFC3809889");

		// Read barcode
		ullTimeBegin = GetTickCount();
		ro.llBarcodeFormat = llFormat;
		ro.iMaxBarcodesNumPerPage = iMaxCount;
		reader.SetReaderOptions(ro);
		iRet = reader.DecodeFile(pszImageFile);
		ullTimeEnd = GetTickCount();
			
		// Output barcode result
		pszTemp = (char*)malloc(4096);
		if (iRet != DBR_OK && iRet != DBRERR_LICENSE_EXPIRED)
		{
			sprintf(pszTemp, "Failed to read barcode: %s\r\n", DBR_GetErrorString(iRet));
			printf(pszTemp);
			free(pszTemp);
			continue;
		}

		pBarcodeResultArray paryResult = NULL;
		reader.GetBarcodes(&paryResult);
		
		if (paryResult->iBarcodeCount == 0)
		{
			sprintf(pszTemp, "No barcode found. Total time spent: %.3f seconds.\r\n", ((float)(ullTimeEnd - ullTimeBegin)/1000));
			printf(pszTemp);
			free(pszTemp);
			reader.FreeBarcodeResults(&paryResult);
			//return 0;
			continue;
		}
		
		sprintf(pszTemp, "Total barcode(s) found: %d. Total time spent: %.3f seconds\r\n\r\n", paryResult->iBarcodeCount, ((float)(ullTimeEnd - ullTimeBegin)/1000));
		printf(pszTemp);
		for (iIndex = 0; iIndex < paryResult->iBarcodeCount; iIndex++)
		{
			sprintf(pszTemp, "Barcode %d:\r\n", iIndex + 1);
			printf(pszTemp);
			sprintf(pszTemp, "    Page: %d\r\n", paryResult->ppBarcodes[iIndex]->iPageNum);
			printf(pszTemp);
			sprintf(pszTemp, "    Type: %s\r\n", GetFormatStr(paryResult->ppBarcodes[iIndex]->llFormat));
			printf(pszTemp);
			pszTemp1 = (char*)malloc(paryResult->ppBarcodes[iIndex]->iBarcodeDataLength + 1);
			memset(pszTemp1, 0, paryResult->ppBarcodes[iIndex]->iBarcodeDataLength + 1);
			memcpy(pszTemp1, paryResult->ppBarcodes[iIndex]->pBarcodeData, paryResult->ppBarcodes[iIndex]->iBarcodeDataLength);
			sprintf(pszTemp, "    Value: %s\r\n", pszTemp1);
			printf(pszTemp);
			free(pszTemp1);
			sprintf(pszTemp, "    Region: {Left: %d, Top: %d, Width: %d, Height: %d}\r\n\r\n", 
				paryResult->ppBarcodes[iIndex]->iLeft, paryResult->ppBarcodes[iIndex]->iTop, 
				paryResult->ppBarcodes[iIndex]->iWidth, paryResult->ppBarcodes[iIndex]->iHeight);
			printf(pszTemp);
		}	

		free(pszTemp);
		reader.FreeBarcodeResults(&paryResult);
	}

	return 0;
}
