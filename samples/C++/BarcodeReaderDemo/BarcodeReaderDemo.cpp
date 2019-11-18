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

const int GetBarcodeFormatId(int iIndex)
{
	switch(iIndex)
	{
	case 1:
		return BF_ALL;
	case 2:
		return BF_ONED;
	case 3:
		return BF_QR_CODE;
	case 4:
		return BF_CODE_39;
	case 5:
		return BF_CODE_128;
	case 6:
		return BF_CODE_93;
	case 7:
		return BF_CODABAR;
	case 8:
		return BF_ITF;
	case 9:
		return BF_INDUSTRIAL_25;
	case 10:
		return BF_EAN_13;
	case 11:
		return BF_EAN_8;
	case 12:
		return BF_UPC_A;
	case 13:
		return BF_UPC_E;
	case 14:
		return BF_PDF417;
	case 15:
		return BF_DATAMATRIX;
	case 16:
		return BF_AZTEC;
	case 17:
		return BF_CODE_39_EXTENDED;
	case 18:
		return BF_MAXICODE;
	case 19:
		return BF_GS1_DATABAR;
	case 20:
		return BF_PATCHCODE;
	case 21:
		return BF_GS1_COMPOSITE;
	default:
		return -1;
	}
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

bool GetImagePath(char* pImagePath)
{
	char pszBuffer[512] = {0};
	bool bExit = false;
	size_t iLen = 0;
	FILE* fp = NULL;
	while(1)
	{
		printf("\r\n>> Step 1: Input your image file's full path:\r\n");
		gets_s(pszBuffer, 512);
		iLen = strlen(pszBuffer);
		if(iLen > 0)
		{
			if(strlen(pszBuffer) == 1 && (pszBuffer[0] == 'q' || pszBuffer[0] == 'Q'))
			{
				bExit = true;
				break;
			}

			memset(pImagePath, 0, 512);
			if(pszBuffer[0]=='\"' && pszBuffer[iLen-1] == '\"')
				memcpy(pImagePath, &pszBuffer[1], iLen-2);
			else
				memcpy(pImagePath, pszBuffer, iLen);

			errno_t err = fopen_s(&fp, pImagePath, "rb");
			if(err == 0)
			{
				fclose(fp);
				break;
			}
		}
		printf("Please input a valid path.\r\n");
	}
	return bExit;
}

bool SetBarcodeFormat(int* iBarcodeFormatId)
{
	char pszBuffer[512] = {0};
	bool bExit = false;
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
		gets_s(pszBuffer, 512);
		iLen = strlen(pszBuffer);
		if(iLen > 0)
		{

			if(strlen(pszBuffer) == 1 && (pszBuffer[0] == 'q' || pszBuffer[0] == 'Q'))
			{
				bExit = true;
				break;
			}

			iIndex = atoi(pszBuffer);
			*iBarcodeFormatId =  GetBarcodeFormatId(iIndex);
			if(*iBarcodeFormatId != -1)
				break;
		}

		if(bExit)
			break;

		printf("Please choose a valid number. \r\n");

	}
	return bExit;
}

void OutputResult(CBarcodeReader& reader,int errorcode,float time)
{
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	char * pszTemp2 = NULL;
	int iRet = errorcode;
	pszTemp = (char*)malloc(4096);
	if (iRet != DBR_OK && iRet != DBRERR_MAXICODE_LICENSE_INVALID && iRet != DBRERR_AZTEC_LICENSE_INVALID && iRet != DBRERR_LICENSE_EXPIRED && iRet != DBRERR_QR_LICENSE_INVALID && iRet != DBRERR_GS1_COMPOSITE_LICENSE_INVALID &&
		iRet != DBRERR_1D_LICENSE_INVALID && iRet != DBRERR_PDF417_LICENSE_INVALID && iRet != DBRERR_DATAMATRIX_LICENSE_INVALID && iRet != DBRERR_GS1_DATABAR_LICENSE_INVALID && iRet != DBRERR_PATCHCODE_LICENSE_INVALID)
	{
		sprintf_s(pszTemp, 4096, "Failed to read barcode: %s\r\n", CBarcodeReader::GetErrorString(iRet));
		printf(pszTemp);
		free(pszTemp);
		return;
	}

	TextResultArray *paryResult = NULL;
	reader.GetAllTextResults(&paryResult);
		
	if (paryResult->resultsCount == 0)
	{
		sprintf_s(pszTemp, 4096, "No barcode found. Total time spent: %.3f seconds.\r\n", time);
		printf(pszTemp);
		free(pszTemp);
		CBarcodeReader::FreeTextResults(&paryResult);
		return;
	}
		
	sprintf_s(pszTemp, 4096, "Total barcode(s) found: %d. Total time spent: %.3f seconds\r\n\r\n", paryResult->resultsCount, time);
	printf(pszTemp);
	for (int iIndex = 0; iIndex < paryResult->resultsCount; iIndex++)
	{
		sprintf_s(pszTemp, 4096, "Barcode %d:\r\n", iIndex + 1);
		printf(pszTemp);
		sprintf_s(pszTemp, 4096, "    Type: %s\r\n", paryResult->results[iIndex]->barcodeFormatString);
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
	CBarcodeReader::FreeTextResults(&paryResult);
}

int main(int argc, const char* argv[])
{
	const char* pszTemplateName = NULL;
	int iBarcodeFormatId = -1;
	char pszBuffer[512] = {0};
	char pszImageFile[512] = {0};
	int iIndex = 0;
	int iRet = -1;
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	unsigned __int64 ullTimeBegin = 0;
	unsigned __int64 ullTimeEnd = 0;
	size_t iLen = 0;
	FILE* fp = NULL;
	bool bExit = false;
	char szErrorMsg[256];
	PublicRuntimeSettings runtimeSettings;

	printf("*************************************************\r\n");
	printf("Welcome to Dynamsoft Barcode Reader Demo\r\n");
	printf("*************************************************\r\n");
	printf("Hints: Please input 'Q'or 'q' to quit the application.\r\n");
	
	CBarcodeReader reader;
	reader.InitLicense("t0068MgAAAAIEWomweHrd8TH8cqcd+RtLQ/U16rG5fQxcrtjpwNqnwlEoGaDn7m/wO5Wc0WvA5YcKMJKDA4JiVh0yAtTKghs=");
	

	while(1)
	{
		bExit = GetImagePath(pszImageFile);
		if(bExit)
			break;

		bExit = SetBarcodeFormat(&iBarcodeFormatId);
		if(bExit)
			break;

		//Best coverage settings
		reader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestCoverage\",\"DeblurLevel\":9,\"ExpectedBarcodesCount\":512,\"ScaleDownThreshold\":100000,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_SCAN_DIRECTLY\"},{\"Mode\":\"LM_STATISTICS\"},{\"Mode\":\"LM_LINES\"},{\"Mode\":\"LM_STATISTICS_MARKS\"}],\"GrayscaleTransformationModes\":[{\"Mode\":\"GTM_ORIGINAL\"},{\"Mode\":\"GTM_INVERTED\"}]}}", CM_OVERWRITE, szErrorMsg, 256);
		//Best speed settings
		//reader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestSpeed\",\"DeblurLevel\":3,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_SCAN_DIRECTLY\"}],\"TextFilterModes\":[{\"MinImageDimension\":262144,\"Mode\":\"TFM_GENERAL_CONTOUR\"}]}}",CM_OVERWRITE,szErrorMsg,256);
		//Balance settings
		//reader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"Balance\",\"DeblurLevel\":5,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_STATISTICS\"}]}}",CM_OVERWRITE,szErrorMsg,256);

		reader.GetRuntimeSettings(&runtimeSettings);
		runtimeSettings.barcodeFormatIds = iBarcodeFormatId;
		iRet = reader.UpdateRuntimeSettings(&runtimeSettings,szErrorMsg,256);
		if(iRet != DBR_OK)
		{
			printf("Error code: %d. Error message: %s\n", iRet, szErrorMsg);
			return -1;
		}

		// Read barcode
		ullTimeBegin = GetTickCount();
		iRet = reader.DecodeFile(pszImageFile, pszTemplateName);
		ullTimeEnd = GetTickCount();
			
		// Output barcode result
		OutputResult(reader,iRet,(((float)(ullTimeEnd - ullTimeBegin))/1000));
	}

	return 0;
}
