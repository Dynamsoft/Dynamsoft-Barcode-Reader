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

typedef struct BarcodeFormatSet
{
	int barcodeFormatIds;
	int barcodeFormatIds_2;
}BarcodeFormatSet;

const int GetBarcodeFormatId(int iIndex, BarcodeFormatSet* barcodeFormatSet)
{
	int ret = 0;
	switch(iIndex)
	{
	case 1:
		barcodeFormatSet->barcodeFormatIds = BF_ALL;
		barcodeFormatSet->barcodeFormatIds_2 = BF2_POSTALCODE | BF2_DOTCODE;
		break;
	case 2:
		barcodeFormatSet->barcodeFormatIds = BF_ONED;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 3:
		barcodeFormatSet->barcodeFormatIds = BF_QR_CODE;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 4:
		barcodeFormatSet->barcodeFormatIds = BF_CODE_39;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 5:
		barcodeFormatSet->barcodeFormatIds = BF_CODE_128;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 6:
		barcodeFormatSet->barcodeFormatIds = BF_CODE_93;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 7:
		barcodeFormatSet->barcodeFormatIds = BF_CODABAR;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 8:
		barcodeFormatSet->barcodeFormatIds = BF_ITF;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 9:
		barcodeFormatSet->barcodeFormatIds = BF_INDUSTRIAL_25;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 10:
		barcodeFormatSet->barcodeFormatIds = BF_EAN_13;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 11:
		barcodeFormatSet->barcodeFormatIds = BF_EAN_8;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 12:
		barcodeFormatSet->barcodeFormatIds = BF_UPC_A;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 13:
		barcodeFormatSet->barcodeFormatIds = BF_UPC_E;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 14:
		barcodeFormatSet->barcodeFormatIds = BF_PDF417;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 15:
		barcodeFormatSet->barcodeFormatIds = BF_DATAMATRIX;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 16:
		barcodeFormatSet->barcodeFormatIds = BF_AZTEC;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 17:
		barcodeFormatSet->barcodeFormatIds = BF_CODE_39_EXTENDED;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 18:
		barcodeFormatSet->barcodeFormatIds = BF_MAXICODE;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 19:
		barcodeFormatSet->barcodeFormatIds = BF_GS1_DATABAR;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 20:
		barcodeFormatSet->barcodeFormatIds = BF_PATCHCODE;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 21:
		barcodeFormatSet->barcodeFormatIds = BF_GS1_COMPOSITE;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
		break;
	case 22:
		barcodeFormatSet->barcodeFormatIds = 0;
		barcodeFormatSet->barcodeFormatIds_2 = BF2_POSTALCODE;
		break;
	case 23:
		barcodeFormatSet->barcodeFormatIds = 0;
		barcodeFormatSet->barcodeFormatIds_2 = BF2_DOTCODE;
		break;
	default:
		ret = -1;
		break;
	}
	return ret;
}

void ToHexString(unsigned char* pSrc, int iLen, char* pDest)
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

int GetImagePath(char* pImagePath)
{
	char pszBuffer[512] = {0};
	int iExitFlag = 0;
	size_t iLen = 0;
	FILE* fp = NULL;
	errno_t err;
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

			memset(pImagePath, 0, 512);
			if(pszBuffer[0]=='\"' && pszBuffer[iLen-1] == '\"')
				memcpy(pImagePath, &pszBuffer[1], iLen-2);
			else
				memcpy(pImagePath, pszBuffer, iLen);

			err = fopen_s(&fp, pImagePath, "rb");
			if(err == 0)
			{
				fclose(fp);
				break;
			}
		}
		printf("Please input a valid path.\r\n");
	}
	return iExitFlag;
}

int SetBarcodeFormat(BarcodeFormatSet* iBarcodeFormatId)
{
	char pszBuffer[512] = {0};
	int iExitFlag = 0;
	size_t iLen = 0;
	int iIndex = 0;
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
		printf("   16: AZTEC\r\n");
		printf("   17: Code 39 Extended\r\n");
		printf("   18: Maxicode\r\n");
		printf("   19: GS1 Databar\r\n");
		printf("   20: PatchCode\r\n");
		printf("   21: GS1 Composite\r\n");
		printf("   22: Postal  Code\r\n");
		printf("   23: DotCode\r\n");
		gets_s(pszBuffer, 512);
		iLen = strlen(pszBuffer);
		if(iLen > 0)
		{

			if(strlen(pszBuffer) == 1 && (pszBuffer[0] == 'q' || pszBuffer[0] == 'Q'))
			{
				iExitFlag = 1;
				break;
			}

			iIndex = atoi(pszBuffer);
			int ret =  GetBarcodeFormatId(iIndex, iBarcodeFormatId);
			if(ret != -1)
				break;
		}

		if(iExitFlag)
			break;

		printf("Please choose a valid number. \r\n");

	}
	return iExitFlag;
}

void OutputResult(void* hBarcode,int errorcode,float time)
{
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	char * pszTemp2 = NULL;
	int iRet = errorcode;
	TextResultArray *paryResult = NULL;
	int iIndex = 0;
	pszTemp = (char*)malloc(4096);
	if (iRet != DBR_OK && iRet!=DBRERR_MAXICODE_LICENSE_INVALID && iRet!= DBRERR_GS1_COMPOSITE_LICENSE_INVALID && iRet!= DBRERR_AZTEC_LICENSE_INVALID && iRet != DBRERR_LICENSE_EXPIRED && iRet != DBRERR_QR_LICENSE_INVALID &&
		iRet != DBRERR_1D_LICENSE_INVALID && iRet != DBRERR_PDF417_LICENSE_INVALID && iRet != DBRERR_DATAMATRIX_LICENSE_INVALID && iRet != DBRERR_GS1_DATABAR_LICENSE_INVALID && iRet != DBRERR_PATCHCODE_LICENSE_INVALID && 
		iRet != DBRERR_POSTALCODE_LICENSE_INVALID && iRet != DBRERR_DOTCODE_LICENSE_INVALID && iRet != DBRERR_DPM_LICENSE_INVALID && iRet != DBRERR_IRT_LICENSE_INVALID)
	{
		sprintf_s(pszTemp, 4096, "Failed to read barcode: %s\r\n",  DBR_GetErrorString(iRet));
		printf(pszTemp);
		free(pszTemp);
		return;
	}


	DBR_GetAllTextResults(hBarcode, &paryResult);
	if (paryResult->resultsCount == 0)
	{
		sprintf_s(pszTemp, 4096, "No barcode found. Total time spent: %.3f seconds.\r\n", time);
		printf(pszTemp);
		free(pszTemp);
		DBR_FreeTextResults(&paryResult);
		return;
	}
		
	sprintf_s(pszTemp, 4096, "Total barcode(s) found: %d. Total time spent: %.3f seconds\r\n\r\n", paryResult->resultsCount, time);
	printf(pszTemp);
	for (iIndex = 0; iIndex < paryResult->resultsCount; iIndex++)
	{
		sprintf_s(pszTemp, 4096, "Barcode %d:\r\n", iIndex + 1);
		printf(pszTemp);
		if (paryResult->results[iIndex]->barcodeFormat != 0)
		{
			sprintf_s(pszTemp, 4096, "    Type: %s\r\n", paryResult->results[iIndex]->barcodeFormatString);
		}
		else
		{
			sprintf_s(pszTemp, 4096, "    Type: %s\r\n", paryResult->results[iIndex]->barcodeFormatString_2);
		}
		printf(pszTemp);
		sprintf_s(pszTemp, 4096, "    Value: %s\r\n", paryResult->results[iIndex]->barcodeText);
		printf(pszTemp);
		pszTemp1 = (char*)malloc(paryResult->results[iIndex]->barcodeBytesLength*3 + 1);
		pszTemp2 = (char*)malloc(paryResult->results[iIndex]->barcodeBytesLength*3 + 100);
		ToHexString(paryResult->results[iIndex]->barcodeBytes, paryResult->results[iIndex]->barcodeBytesLength, pszTemp1);
		sprintf_s(pszTemp2, paryResult->results[iIndex]->barcodeBytesLength*3 + 100, "    Hex Data: %s\r\n", pszTemp1);
		printf(pszTemp2);
		free(pszTemp1);
		free(pszTemp2);
	}	

	free(pszTemp);
	DBR_FreeTextResults(&paryResult);
}


int main(int argc, const char* argv[])
{
	BarcodeFormatSet iBarcodeFormatId = {0,0};
	char pszBuffer[512] = {0};
	char pszImageFile[512] = {0};
	int iIndex = 0;
	TextResultArray *paryResult = NULL;
	int iRet = -1;
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	unsigned __int64 ullTimeBegin = 0;
	unsigned __int64 ullTimeEnd = 0;
	FILE* fp = NULL;
	int iExitFlag = 0;
	errno_t err = 0;
	void* hBarcode = NULL;
	char szErrorMsg[256];
	PublicRuntimeSettings runtimeSettings;

	printf("*************************************************\r\n");
	printf("Welcome to Dynamsoft Barcode Reader Demo\r\n");
	printf("*************************************************\r\n");
	printf("Hints: Please input 'Q'or 'q' to quit the application.\r\n");
	
	hBarcode = DBR_CreateInstance();
	DBR_InitLicense(hBarcode, "t0068MgAAAE7qT3leEpZ3FHHeK0o/M6+e9qFvbD2K1AgVg+BCZnMsEdwhXeBuEvr0bB0vi1YnRCd4GpvPqQQfr8K44O2iSXk=");


	while(1)
	{
		iExitFlag = GetImagePath(pszImageFile);
		if(iExitFlag)
			break;

		iExitFlag = SetBarcodeFormat(&iBarcodeFormatId);
		if(iExitFlag)
			break;
		//Best coverage settings
		DBR_InitRuntimeSettingsWithString(hBarcode,"{\"ImageParameter\":{\"Name\":\"BestCoverage\",\"DeblurLevel\":9,\"ExpectedBarcodesCount\":512,\"ScaleDownThreshold\":100000,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_SCAN_DIRECTLY\"},{\"Mode\":\"LM_STATISTICS\"},{\"Mode\":\"LM_LINES\"},{\"Mode\":\"LM_STATISTICS_MARKS\"}],\"GrayscaleTransformationModes\":[{\"Mode\":\"GTM_ORIGINAL\"},{\"Mode\":\"GTM_INVERTED\"}]}}",CM_OVERWRITE,szErrorMsg,256);
		//Best speed settings
		//DBR_InitRuntimeSettingsWithString(hBarcode,"{\"ImageParameter\":{\"Name\":\"BestSpeed\",\"DeblurLevel\":3,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_SCAN_DIRECTLY\"}],\"TextFilterModes\":[{\"MinImageDimension\":262144,\"Mode\":\"TFM_GENERAL_CONTOUR\"}]}}",CM_OVERWRITE,szErrorMsg,256);
		//Balance settings
		//DBR_InitRuntimeSettingsWithString(hBarcode,"{\"ImageParameter\":{\"Name\":\"Balance\",\"DeblurLevel\":5,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_STATISTICS\"}]}}",CM_OVERWRITE,szErrorMsg,256);
		DBR_GetRuntimeSettings(hBarcode,&runtimeSettings);
		runtimeSettings.barcodeFormatIds = iBarcodeFormatId.barcodeFormatIds;
		runtimeSettings.barcodeFormatIds_2 = iBarcodeFormatId.barcodeFormatIds_2;
		iRet = DBR_UpdateRuntimeSettings(hBarcode,&runtimeSettings,szErrorMsg,256);
		if(iRet != DBR_OK)
		{
			printf("Error code: %d. Error message: %s\n", iRet, szErrorMsg);
			return -1;
		}

		ullTimeBegin = GetTickCount();
		iRet = DBR_DecodeFile(hBarcode, pszImageFile,"");
		ullTimeEnd = GetTickCount();
		
		OutputResult(hBarcode,iRet,(((float)(ullTimeEnd - ullTimeBegin))/1000));
	}
		
	DBR_DestroyInstance(hBarcode);

	return 0;
}

