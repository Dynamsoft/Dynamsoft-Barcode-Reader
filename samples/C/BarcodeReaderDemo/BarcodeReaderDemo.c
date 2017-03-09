// BarcodeReaderDemo.cpp : Defines the entry point for the console application.

#include <windows.h>
#include <stdio.h>
#include <conio.h>
#include "../../../../Components/C_C++/Include/DynamsoftBarcodeReader.h"

#ifdef _WIN64
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx64.lib")
#else
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx86.lib")
#endif

int GetFormat(int iIndex)
{
	int iFormat = -1;

	switch(iIndex)
	{
	case 1:
		iFormat = BF_All;
		break;
	case 2:
		iFormat = BF_OneD;
		break;
	case 3:
		iFormat = BF_QR_CODE;
		break;
	case 4:
		iFormat = BF_CODE_39;
		break;	
	case 5:
		iFormat = BF_CODE_128;
		break;	
	case 6:
		iFormat = BF_CODE_93;
		break;	
	case 7:
		iFormat = BF_CODABAR;
		break;	
	case 8:
		iFormat = BF_ITF;
		break;
	case 9:
		iFormat = BF_INDUSTRIAL_25;
		break;
	case 10:
		iFormat = BF_EAN_13;
		break;
	case 11:
		iFormat = BF_EAN_8;
		break;
	case 12:
		iFormat = BF_UPC_A;
		break;
	case 13:
		iFormat = BF_UPC_E;
		break;
	case 14:
		iFormat = BF_PDF417;
		break;
	case 15:
		iFormat = BF_DATAMATRIX;
		break;
	default:
		break;
	}

	return iFormat;
}

void ToHexString(char* pSrc, int iLen, char* pDest)
{
	const char HEXCHARS[16] = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

	int i;
	char* ptr = pDest;

	for(i = 0; i < iLen; ++i)
	{
		sprintf_s(ptr, 4, "%c%c ", HEXCHARS[ ( pSrc[i] & 0xF0 ) >> 4 ], HEXCHARS[ ( pSrc[i] & 0x0F ) >> 0 ]);
		ptr += 3;
	}
}

int main(int argc, const char* argv[])
{
	int iFormat = 0;
	char pszBuffer[512] = {0};

	char pszImageFile[512] = {0};
	int iMaxCount = 0x7FFFFFFF;
	int iIndex = 0;
	SBarcodeResultArray *paryResult = NULL;
	int iRet = -1;
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	unsigned __int64 ullTimeBegin = 0;
	unsigned __int64 ullTimeEnd = 0;
	size_t iLen;
	FILE* fp = NULL;
	int iExitFlag = 0;
	errno_t err = 0;
	void* hBarcode = NULL;

	printf("*************************************************\r\n");
	printf("Welcome to Dynamsoft Barcode Reader Demo\r\n");
	printf("*************************************************\r\n");
	printf("Hints: Please input 'Q'or 'q' to quit the application.\r\n");
	
	while(1)
	{
		iMaxCount = 0x7FFFFFFF;
		iFormat = BF_All;

		while(1)
		{
			printf("\r\n>> Step 1: Input your image file's full path:\r\n");
			gets_s(pszBuffer, 512);			
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

				err = fopen_s(&fp, pszImageFile, "rb");
				if (err == 0)
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

			gets_s(pszBuffer, 512);
			iLen = strlen(pszBuffer);
			if(iLen > 0)
			{
				iIndex = atoi(pszBuffer);
				iFormat = GetFormat(iIndex);
				if(iFormat != -1)
					break;
			}
			
			printf("Please choose a valid number. \r\n");

		}

		while(1)
		{
			printf("\r\n>> Step 3: Input the maximum number of barcodes to read per page: \r\n");
			gets_s(pszBuffer, 512);
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


		hBarcode = DBR_CreateInstance();

		DBR_InitLicenseEx(hBarcode, "t0260NQAAAFUZbbNi3xJ4oViu+0+5Eim8wPzn6GeJZrIvrb/HLjzJ8Mn+GRjbfdoa/f+iRLzKTudXVEkKqj9tKlzzDP+xKzZ2IdknzMXimKDmKBivdKTXM3T5ACPK25omqoQkqNw00zExtCrR532mHig0QU6dsF5EmvkgDLxsbWw/M54wj1F1pGagM7YfKzpLN0/qvCeejimX2nvTMfOzv+M37m+0RPsnyp20pITycnvBGyWkZ3OWQ97U8UNYl+OyyfuHymz8EcjqQm9nxvYTm4nYHERHkiXMmI6jWLgK+4+jIlcS9WLgWd8pMKkI0bZCcwmVzk5z+vuGYKjZVK/iuYIx7McOP9k=");
		DBR_SetBarcodeFormats(hBarcode, iFormat);
		DBR_SetMaxBarcodesNumPerPage(hBarcode, iMaxCount);

		// Read barcode
		ullTimeBegin = GetTickCount();
		iRet = DBR_DecodeFileEx(hBarcode, pszImageFile, &paryResult);
		ullTimeEnd = GetTickCount();
		
		// Output barcode result
		pszTemp = (char*)malloc(4096);
		if (iRet != DBR_OK && iRet != DBRERR_LICENSE_EXPIRED && iRet != DBRERR_QR_LICENSE_INVALID &&
			iRet != DBRERR_1D_LICENSE_INVALID && iRet != DBRERR_PDF417_LICENSE_INVALID && iRet != DBRERR_DATAMATRIX_LICENSE_INVALID)
		{
			sprintf_s(pszTemp, 4096, "Failed to read barcode: %s\r\n", DBR_GetErrorString(iRet));
			printf(pszTemp);
			free(pszTemp);
			//return 1;
			continue;
		}
		
		if (paryResult->iBarcodeCount == 0)
		{
			sprintf_s(pszTemp, 4096, "No barcode found. Total time spent: %.3f seconds.\r\n", ((float)(ullTimeEnd - ullTimeBegin)/1000));
			printf(pszTemp);
			free(pszTemp);
			DBR_FreeBarcodeResults(&paryResult);
			continue;
			//return 0;
		}
		
		sprintf_s(pszTemp, 4096, "Total barcode(s) found: %d. Total time spent: %.3f seconds\r\n\r\n", paryResult->iBarcodeCount, ((float)(ullTimeEnd - ullTimeBegin)/1000));
		printf(pszTemp);
		for (iIndex = 0; iIndex < paryResult->iBarcodeCount; iIndex++)
		{
			sprintf_s(pszTemp, 4096, "Barcode %d:\r\n", iIndex + 1);
			printf(pszTemp);
			sprintf_s(pszTemp, 4096, "    Page: %d\r\n", paryResult->ppBarcodes[iIndex]->iPageNum);
			printf(pszTemp);
			sprintf_s(pszTemp, 4096, "    Type: %s\r\n", paryResult->ppBarcodes[iIndex]->pBarcodeFormatString);
			printf(pszTemp);
			sprintf_s(pszTemp, 4096, "    Value: %s\r\n", paryResult->ppBarcodes[iIndex]->pBarcodeData);
			printf(pszTemp);

			pszTemp1 = (char*)malloc(paryResult->ppBarcodes[iIndex]->iBarcodeDataLength*3+1);
			ToHexString(paryResult->ppBarcodes[iIndex]->pBarcodeData, paryResult->ppBarcodes[iIndex]->iBarcodeDataLength, pszTemp1);
			sprintf_s(pszTemp, 4096, "    Hex Data: %s\r\n", pszTemp1);
			printf(pszTemp);
			free(pszTemp1);

			sprintf_s(pszTemp, 4096, "    Region: {Left: %d, Top: %d, Width: %d, Height: %d}\r\n",
				paryResult->ppBarcodes[iIndex]->iLeft, paryResult->ppBarcodes[iIndex]->iTop, 
				paryResult->ppBarcodes[iIndex]->iWidth, paryResult->ppBarcodes[iIndex]->iHeight);
			printf(pszTemp);

			sprintf_s(pszTemp, 4096, "    Module Size: %d\r\n", paryResult->ppBarcodes[iIndex]->iModuleSize);
			printf(pszTemp);
			sprintf_s(pszTemp, 4096, "    Angle: %d\r\n\r\n", paryResult->ppBarcodes[iIndex]->iAngle);
			printf(pszTemp);

		}

		free(pszTemp);
		DBR_FreeBarcodeResults(&paryResult);

		DBR_DestroyInstance(hBarcode);
	}

	return 0;
}

