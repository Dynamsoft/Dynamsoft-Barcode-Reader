// BarcodeReaderDemo.cpp : Defines the entry point for the console application.

#include <windows.h>
#include <stdio.h>
#include <conio.h>
#include <io.h>
#include "../../../../Components/C_C++/Include/DynamsoftBarcodeReader.h"

#ifdef _WIN64
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx64.lib")
#else
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx86.lib")
#endif


#define MAX_THREAD_COUNT 64
#define MAX_FILE_COUNT 1024

typedef struct  tagMultiThreadDecodeFileInfo
{
	int iTotalImageCount;
	int iCurrentImageCount;
	char** arrFiles;
	//HANDLE hBarcode;
	HANDLE hMutex;
}MultiThreadDecodeFileInfo;

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

void OutputResult(void* hBarcode,int errorcode/*,float time*/)
{
	char * pszTemp = NULL;
	char * pszTemp1 = NULL;
	int iRet = errorcode;
	TextResultArray *paryResult = NULL;
	int iIndex = 0;
	pszTemp = (char*)malloc(4096);
	if (iRet != DBR_OK && iRet != DBRERR_LICENSE_EXPIRED && iRet != DBRERR_MAXICODE_LICENSE_INVALID && iRet != DBRERR_AZTEC_LICENSE_INVALID && iRet != DBRERR_QR_LICENSE_INVALID && iRet != DBRERR_GS1_COMPOSITE_LICENSE_INVALID &&
		iRet != DBRERR_1D_LICENSE_INVALID && iRet != DBRERR_PDF417_LICENSE_INVALID && iRet != DBRERR_DATAMATRIX_LICENSE_INVALID && iRet != DBRERR_GS1_DATABAR_LICENSE_INVALID && iRet != DBRERR_PATCHCODE_LICENSE_INVALID && 
		iRet != DBRERR_POSTALCODE_LICENSE_INVALID && iRet != DBRERR_DOTCODE_LICENSE_INVALID && iRet != DBRERR_DOTCODE_LICENSE_INVALID && iRet != DBRERR_DPM_LICENSE_INVALID && iRet != DBRERR_IRT_LICENSE_INVALID)
	{
		sprintf_s(pszTemp, 4096, "Failed to read barcode: %s\r\n",  DBR_GetErrorString(iRet));
		printf(pszTemp);
		free(pszTemp);
		return;
	}


	DBR_GetAllTextResults(hBarcode, &paryResult);
	if (paryResult->resultsCount == 0)
	{
		sprintf_s(pszTemp, 4096, "No barcode found.\r\n");
		printf(pszTemp);
		free(pszTemp);
		DBR_FreeTextResults(&paryResult);
		return;
	}
		
	sprintf_s(pszTemp, 4096, "Total barcode(s) found: %d.\r\n\r\n", paryResult->resultsCount);
	printf(pszTemp);
	//for (iIndex = 0; iIndex < paryResult->resultsCount; iIndex++)
	//{
	//	sprintf_s(pszTemp, 4096, "Barcode %d:\r\n", iIndex + 1);
	//	printf(pszTemp);
	//if (paryResult->results[iIndex]->barcodeFormat != 0)
	//{
	//	sprintf_s(pszTemp, 4096, "    Type: %s\r\n", paryResult->results[iIndex]->barcodeFormatString);
	//}
	//else
	//{
	//	sprintf_s(pszTemp, 4096, "    Type: %s\r\n", paryResult->results[iIndex]->barcodeFormatString_2);
	//}
	//	sprintf_s(pszTemp, 4096, "    Value: %s\r\n", paryResult->results[iIndex]->barcodeText);
	//	printf(pszTemp);
	//	pszTemp1 = (char*)malloc(paryResult->results[iIndex]->barcodeBytesLength*3 + 1);
	//	ToHexString(paryResult->results[iIndex]->barcodeBytes, paryResult->results[iIndex]->barcodeBytesLength, pszTemp1);
	//	sprintf_s(pszTemp, 4096, "    Hex Data: %s\r\n", pszTemp1);
	//	printf(pszTemp);
	//	free(pszTemp1);
	//}	

	free(pszTemp);
	DBR_FreeTextResults(&paryResult);
}

DWORD WINAPI DecodeFile(void* pInfo)
{
	MultiThreadDecodeFileInfo *pMultiThreadDecodeFileInfo = (MultiThreadDecodeFileInfo*)pInfo;
	while (1)
	{
		unsigned __int64 ullTimeBegin = 0;
		unsigned __int64 ullTimeEnd = 0;
		int iRet = 0;
		int iImageIndex = -1;
		char* tempFileName;
		void* temphBarcode = NULL;
		char szErrorMsg[256];
		WaitForSingleObject(pMultiThreadDecodeFileInfo->hMutex,INFINITE);
		iImageIndex = pMultiThreadDecodeFileInfo->iCurrentImageCount;
		tempFileName = pMultiThreadDecodeFileInfo->arrFiles[iImageIndex];
		if (pMultiThreadDecodeFileInfo->iCurrentImageCount >= pMultiThreadDecodeFileInfo->iTotalImageCount)
		{
			ReleaseMutex(pMultiThreadDecodeFileInfo->hMutex);
			return 0;
		}
		pMultiThreadDecodeFileInfo->iCurrentImageCount++;
		ReleaseMutex(pMultiThreadDecodeFileInfo->hMutex);
		temphBarcode = DBR_CreateInstance();
		DBR_InitLicense(temphBarcode,"t0068MgAAAE7qT3leEpZ3FHHeK0o/M6+e9qFvbD2K1AgVg+BCZnMsEdwhXeBuEvr0bB0vi1YnRCd4GpvPqQQfr8K44O2iSXk=");

		//Best coverage settings
		DBR_InitRuntimeSettingsWithString(temphBarcode,"{\"ImageParameter\":{\"Name\":\"BestCoverage\",\"DeblurLevel\":9,\"ExpectedBarcodesCount\":512,\"ScaleDownThreshold\":100000,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_SCAN_DIRECTLY\"},{\"Mode\":\"LM_STATISTICS\"},{\"Mode\":\"LM_LINES\"},{\"Mode\":\"LM_STATISTICS_MARKS\"}],\"GrayscaleTransformationModes\":[{\"Mode\":\"GTM_ORIGINAL\"},{\"Mode\":\"GTM_INVERTED\"}]}}",CM_OVERWRITE,szErrorMsg,256);
		//Best speed settings
		//DBR_InitRuntimeSettingsWithString(temphBarcode,"{\"ImageParameter\":{\"Name\":\"BestSpeed\",\"DeblurLevel\":3,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_SCAN_DIRECTLY\"}],\"TextFilterModes\":[{\"MinImageDimension\":262144,\"Mode\":\"TFM_GENERAL_CONTOUR\"}]}}",CM_OVERWRITE,szErrorMsg,256);
		//Balance settings
		//DBR_InitRuntimeSettingsWithString(temphBarcode,"{\"ImageParameter\":{\"Name\":\"Balance\",\"DeblurLevel\":5,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_STATISTICS\"}]}}",CM_OVERWRITE,szErrorMsg,256);

		iRet = DBR_DecodeFile(temphBarcode,tempFileName,"");

		WaitForSingleObject(pMultiThreadDecodeFileInfo->hMutex,INFINITE);
		printf("File Name: %s\r\n",tempFileName);
		OutputResult(temphBarcode, iRet);
		ReleaseMutex(pMultiThreadDecodeFileInfo->hMutex);
		DBR_DestroyInstance(temphBarcode);
	}
}

void MultiThreadDecodeFileFolder(int* iThreadCount, char** arrFiles, int* iTotalImageCount)
{
	int iIndex = 0;
	MultiThreadDecodeFileInfo tempThreadDecodeFileInfo;
	HANDLE hMutex = NULL;

	DWORD *dThreadId = (DWORD*)malloc(sizeof(DWORD)*(*iThreadCount));
	HANDLE *hArrBarcode = (HANDLE *)malloc(sizeof(HANDLE)*(*iThreadCount));
	HANDLE *hArrThreadHandle = (HANDLE *)malloc(sizeof(HANDLE)*(*iThreadCount));
	hMutex = CreateMutex(NULL, FALSE, NULL);


	tempThreadDecodeFileInfo.iTotalImageCount = (*iTotalImageCount);
	tempThreadDecodeFileInfo.iCurrentImageCount = 0;
	tempThreadDecodeFileInfo.arrFiles = arrFiles;
	tempThreadDecodeFileInfo.hMutex = hMutex;



	for (iIndex = 0; iIndex < (*iThreadCount); iIndex++)
	{
		hArrThreadHandle[iIndex] = CreateThread(NULL, 0, DecodeFile, &tempThreadDecodeFileInfo, 0, &(dThreadId[iIndex]));
	}
	WaitForMultipleObjects((*iThreadCount), hArrThreadHandle, TRUE, INFINITE);
	for(iIndex = 0; iIndex < (*iThreadCount); iIndex++)
	{
		CloseHandle(hArrThreadHandle[iIndex]);
	}

	free(dThreadId);
	free(hArrBarcode);
	free(hArrThreadHandle);
}

void GetFiles(const char* path, char* files[], int* filecount)
{
	intptr_t hFile = 0;
	struct _finddata_t fileinfo;
	size_t len = strlen(path);

	char newpath[512] = {0};
	strcpy(newpath, path);
	strcat(newpath, "\\*");

	if((hFile = _findfirst(newpath, &fileinfo))!=-1)
	{
		do
		{
			if((fileinfo.attrib & _A_SUBDIR))
			{
			}
			else
			{
				files[*filecount] = (char*)malloc(len+1+strlen(fileinfo.name)+1);
				strcpy(files[*filecount], path);
				strcat(files[*filecount], "\\");
				strcat(files[*filecount], fileinfo.name);

				(*filecount)++;
			}
		}while(_findnext(hFile,&fileinfo)==0);

		_findclose(hFile);
	}

}

int GetImageFolderPath(char* pImagePath)
{
	char pszBuffer[512] = { 0 };
	int iExitFlag = 0;
	size_t iLen = 0;
	FILE* fp = NULL;
	errno_t err;
	while (1)
	{
		printf("\r\n>> Step 1: Input your image folder's full path:\r\n");
		gets_s(pszBuffer, 512);
		iLen = strlen(pszBuffer);
		if (iLen > 0)
		{
			if (strlen(pszBuffer) == 1 && (pszBuffer[0] == 'q' || pszBuffer[0] == 'Q'))
			{
				iExitFlag = 1;
				break;
			}

			memset(pImagePath, 0, 512);
			if (pszBuffer[0] == '\"' && pszBuffer[iLen - 1] == '\"')
				memcpy(pImagePath, &pszBuffer[1], iLen - 2);
			else
				memcpy(pImagePath, pszBuffer, iLen);
			break;
			//err = fopen_s(&fp, pImagePath, "rb");
			//if (err == 0)
			//{
			//	fclose(fp);
			//	break;
			//}
		}
		printf("Please input a valid path.\r\n");
	}
	return iExitFlag;
}

int main(int argc, const char* argv[])
{
	int iExitFlag = 0;
	char pszImageFile[512] = {0};
	int iThreadCount = 4;
	char** arrFiles = NULL;
	int iTotalImageCount = 0;

	printf("*************************************************\r\n");
	printf("Welcome to Dynamsoft Barcode Reader Demo\r\n");
	printf("*************************************************\r\n");
	printf("Hints: Please input 'Q'or 'q' to quit the application.\r\n");


	GetImageFolderPath(pszImageFile);
	arrFiles = (char**)malloc(MAX_FILE_COUNT);
	GetFiles(pszImageFile, arrFiles, &iTotalImageCount);
	MultiThreadDecodeFileFolder(&iThreadCount, arrFiles, &iTotalImageCount);

	printf("Finish. \r\n");

	return 0;
}

