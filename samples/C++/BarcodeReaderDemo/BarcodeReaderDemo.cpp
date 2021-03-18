#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#if defined(_WIN64) || defined(_WIN32)
#include <windows.h>
#include <conio.h>
#define snprintf sprintf_s 
#else
#include <sys/time.h>
#endif

#include "DynamsoftBarcodeReader.h"
#include "DynamsoftCommon.h"
using namespace dynamsoft::dbr;
typedef struct BarcodeFormatSet
{
	int barcodeFormatIds;
	int barcodeFormatIds_2;
}BarcodeFormatSet;

unsigned long GetTiming()
{
#if defined(_WIN64) || defined(_WIN32)
	return GetTickCount();
#else
	struct timeval timing;
	gettimeofday(&timing, NULL);
	return timing.tv_sec * 1000  + timing.tv_usec / 1000;
#endif
}

const int GetBarcodeFormatId(int iIndex, BarcodeFormatSet* barcodeFormatSet)
{
	int ret = 0;
	switch (iIndex)
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
	case 24:
		barcodeFormatSet->barcodeFormatIds = BF_MSI_CODE;
		barcodeFormatSet->barcodeFormatIds_2 = 0;
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

	for (i = 0; i < iLen; ++i)
	{
		snprintf(ptr, 4, "%c%c ", HEXCHARS[(pSrc[i] & 0xF0) >> 4], HEXCHARS[(pSrc[i] & 0x0F) >> 0]);
		ptr += 3;
	}
}

bool GetImagePath(char* pImagePath)
{
	char pszBuffer[512] = { 0 };
	bool bExit = false;
	size_t iLen = 0;
	FILE* fp = NULL;
	while (1)
	{
		printf("\r\n>> Step 1: Input your image file's full path:\r\n");
		fgets(pszBuffer, 512, stdin);
		strtok(pszBuffer, "\n");

		iLen = strlen(pszBuffer);
		if (iLen > 0)
		{
			if (strlen(pszBuffer) == 1 && (pszBuffer[0] == 'q' || pszBuffer[0] == 'Q'))
			{
				bExit = true;
				break;
			}

			memset(pImagePath, 0, 512);
			if (pszBuffer[0] == '\'' || pszBuffer[0] == '\"' )
			{
				if (pszBuffer[iLen - 3] == '\'')
					memcpy(pImagePath, pszBuffer + 1, iLen - 4);
				else if (pszBuffer[iLen - 2] == '\'')
					memcpy(pImagePath, pszBuffer + 1, iLen - 3);
				else if(pszBuffer[iLen - 1] == '\"')
					memcpy(pImagePath, pszBuffer + 1, iLen - 2);
			}
			else
				memcpy(pImagePath, pszBuffer, iLen);

			fp = fopen(pImagePath, "rb");
			if (fp != NULL)
			{
				break;
			}
		}
		printf("Please input a valid path.\r\n");
	}
	return bExit;
}

bool SetBarcodeFormat(BarcodeFormatSet* iBarcodeFormatId)
{
	char pszBuffer[512] = { 0 };
	bool bExit = false;
	size_t iLen = 0;
	int iIndex = 0;
	while (1)
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
		printf("   24: MSI Code\r\n");

		fgets(pszBuffer, 512, stdin);
		strtok(pszBuffer, "\n");

		iLen = strlen(pszBuffer);
		if (iLen > 0)
		{

			if (strlen(pszBuffer) == 1 && (pszBuffer[0] == 'q' || pszBuffer[0] == 'Q'))
			{
				bExit = true;
				break;
			}

			iIndex = atoi(pszBuffer);
			int ret = GetBarcodeFormatId(iIndex, iBarcodeFormatId);
			if (ret != -1)
				break;
		}

		if (bExit)
			break;

		printf("Please choose a valid number. \r\n");

	}
	return bExit;
}

void OutputResult(CBarcodeReader& reader, int errorcode, float time)
{
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	char * pszTemp2 = NULL;
	int iRet = errorcode;
	pszTemp = (char*)malloc(4096);
	if (iRet != DBR_OK && iRet != DBRERR_MAXICODE_LICENSE_INVALID && iRet != DBRERR_AZTEC_LICENSE_INVALID && iRet != DBRERR_LICENSE_EXPIRED && iRet != DBRERR_QR_LICENSE_INVALID && iRet != DBRERR_GS1_COMPOSITE_LICENSE_INVALID &&
		iRet != DBRERR_1D_LICENSE_INVALID && iRet != DBRERR_PDF417_LICENSE_INVALID && iRet != DBRERR_DATAMATRIX_LICENSE_INVALID && iRet != DBRERR_GS1_DATABAR_LICENSE_INVALID && iRet != DBRERR_PATCHCODE_LICENSE_INVALID &&
		iRet != DBRERR_POSTALCODE_LICENSE_INVALID && iRet != DBRERR_DOTCODE_LICENSE_INVALID && iRet != DBRERR_DPM_LICENSE_INVALID && iRet != DBRERR_IRT_LICENSE_INVALID && iRet != DMERR_NO_LICENSE && iRet != DMERR_TRIAL_LICENSE)
	{
		snprintf(pszTemp, 4096, "Failed to read barcode: %s\r\n", CBarcodeReader::GetErrorString(iRet));
		printf("%s", pszTemp);
		free(pszTemp);
		return;
	}

	TextResultArray *paryResult = NULL;
	reader.GetAllTextResults(&paryResult);

	if (paryResult->resultsCount == 0)
	{
		snprintf(pszTemp, 4096, "No barcode found. Total time spent: %.3f seconds.\r\n", time);
		printf("%s", pszTemp);
		free(pszTemp);
		CBarcodeReader::FreeTextResults(&paryResult);
		return;
	}

	snprintf(pszTemp, 4096, "Total barcode(s) found: %d. Total time spent: %.3f seconds\r\n\r\n", paryResult->resultsCount, time);
	printf("%s", pszTemp);
	for (int iIndex = 0; iIndex < paryResult->resultsCount; iIndex++)
	{
		snprintf(pszTemp, 4096, "Barcode %d:\r\n", iIndex + 1);
		printf("%s", pszTemp);
		if (paryResult->results[iIndex]->barcodeFormat != 0)
		{
			snprintf(pszTemp, 4096, "    Type: %s\r\n", paryResult->results[iIndex]->barcodeFormatString);
		}
		else
		{
			snprintf(pszTemp, 4096, "    Type: %s\r\n", paryResult->results[iIndex]->barcodeFormatString_2);
		}

		printf("%s", pszTemp);
		snprintf(pszTemp, 4096, "    Value: %s\r\n", paryResult->results[iIndex]->barcodeText);
		printf("%s", pszTemp);

		pszTemp1 = (char*)malloc(paryResult->results[iIndex]->barcodeBytesLength * 3 + 1);
		pszTemp2 = (char*)malloc(paryResult->results[iIndex]->barcodeBytesLength * 3 + 100);
		ToHexString(paryResult->results[iIndex]->barcodeBytes, paryResult->results[iIndex]->barcodeBytesLength, pszTemp1);
		snprintf(pszTemp2, paryResult->results[iIndex]->barcodeBytesLength * 3 + 100, "    Hex Data: %s\r\n", pszTemp1);
		printf("%s", pszTemp2);
		free(pszTemp1);
		free(pszTemp2);
	}

	free(pszTemp);
	CBarcodeReader::FreeTextResults(&paryResult);
}

int main(int argc, const char* argv[])
{
	const char* pszTemplateName = NULL;
	BarcodeFormatSet iBarcodeFormatId = { 0,0 };
	char pszBuffer[512] = { 0 };
	char pszImageFile[512] = { 0 };
	int iIndex = 0;
	int iRet = -1;
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	unsigned long ullTimeBegin = 0;
	unsigned long ullTimeEnd = 0;

	size_t iLen = 0;
	FILE* fp = NULL;
	bool bExit = false;
	char szErrorMsg[256];
	PublicRuntimeSettings runtimeSettings;

	printf("*************************************************\r\n");
	printf("Welcome to Dynamsoft Barcode Reader Demo\r\n");
	printf("*************************************************\r\n");
	printf("Hints: Please input 'Q' or 'q' to quit the application.\r\n");

	CBarcodeReader reader;
	reader.InitLicense("t0068MgAAAC4m3vBqmGZTtroTtWT8STe3QFyOlwiLqwtB7ghY+8pU01rgU3JedgtcsxyRHnys1N3qjCMZ2AprRCavlIpLbAk=");


	while (1)
	{
		bExit = GetImagePath(pszImageFile);
		if (bExit)
			break;

		bExit = SetBarcodeFormat(&iBarcodeFormatId);
		if (bExit)
			break;

		//Best coverage settings
		reader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestCoverage\",\"DeblurLevel\":9,\"ExpectedBarcodesCount\":512,\"ScaleDownThreshold\":100000,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_SCAN_DIRECTLY\"},{\"Mode\":\"LM_STATISTICS\"},{\"Mode\":\"LM_LINES\"},{\"Mode\":\"LM_STATISTICS_MARKS\"}],\"GrayscaleTransformationModes\":[{\"Mode\":\"GTM_ORIGINAL\"},{\"Mode\":\"GTM_INVERTED\"}]}}", CM_OVERWRITE, szErrorMsg, 256);
		//Best speed settings
		//reader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestSpeed\",\"DeblurLevel\":3,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_SCAN_DIRECTLY\"}],\"TextFilterModes\":[{\"MinImageDimension\":262144,\"Mode\":\"TFM_GENERAL_CONTOUR\"}]}}",CM_OVERWRITE,szErrorMsg,256);
		//Balance settings
		//reader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"Balance\",\"DeblurLevel\":5,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_STATISTICS\"}]}}",CM_OVERWRITE,szErrorMsg,256);

		reader.GetRuntimeSettings(&runtimeSettings);
		runtimeSettings.barcodeFormatIds = iBarcodeFormatId.barcodeFormatIds;
		runtimeSettings.barcodeFormatIds_2 = iBarcodeFormatId.barcodeFormatIds_2;
		iRet = reader.UpdateRuntimeSettings(&runtimeSettings, szErrorMsg, 256);
		if (iRet != DBR_OK)
		{
			printf("Error code: %d. Error message: %s\n", iRet, szErrorMsg);
			return -1;
		}

		ullTimeBegin = GetTiming();
		iRet = reader.DecodeFile(pszImageFile, pszTemplateName);
		ullTimeEnd = GetTiming();
		OutputResult(reader, iRet, (((float)(ullTimeEnd - ullTimeBegin)) / 1000));

	}

	return 0;
}
