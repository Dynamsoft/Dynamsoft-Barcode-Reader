// php_dbr.cpp : Defines the exported functions for the DLL application.
#include "php_dbr.h"

#include "If_DBR.h"
#include "BarcodeFormat.h"
#include "BarcodeStructs.h"
#include "ErrorCode.h"

#ifdef _WIN64
#pragma comment(lib, "DBRx64.lib")
#else
#pragma comment(lib, "DBRx86.lib")
#endif

// Barcode format
const char * GetFormatStr(__int64 format)
{
	if (format == CODE_39)
		return "CODE_39";
	if (format == CODE_128)
		return "CODE_128";
	if (format == CODE_93)
		return "CODE_93";
	if (format == CODABAR)
		return "CODABAR";
	if (format == ITF)
		return "ITF";
	if (format == UPC_A)
		return "UPC_A";
	if (format == UPC_E)
		return "UPC_E";
	if (format == EAN_13)
		return "EAN_13";
	if (format == EAN_8)
		return "EAN_8";
	if (format == INDUSTRIAL_25)
		return "INDUSTRIAL_25";
	if (format == QR_CODE)
		return "QR_CODE";
	if (format == PDF417)
		return "PDF417";
	if (format == DATAMATRIX)
		return "DATAMATRIX";

	return "UNKNOWN";
}

ZEND_FUNCTION(DecodeBarcodeFile);

zend_function_entry CustomExtModule_functions[] = {
    ZEND_FE(DecodeBarcodeFile, NULL)
    {NULL, NULL, NULL}
};

zend_module_entry CustomExtModule_module_entry = {
    STANDARD_MODULE_HEADER,
    "Dynamsoft Barcode Reader",
    CustomExtModule_functions,
    NULL, NULL, NULL, NULL, NULL,
    NO_VERSION_YET, STANDARD_MODULE_PROPERTIES
};

ZEND_GET_MODULE(CustomExtModule)

ZEND_FUNCTION(DecodeBarcodeFile){
	array_init(return_value);

	// Get Barcode image path
	char* pFileName = NULL;
	bool isNativeOuput = false;
	bool isLogOn = false;
	int iLen = 0;

	if (zend_parse_parameters(ZEND_NUM_ARGS() TSRMLS_CC, "sb|b", &pFileName, &iLen, &isNativeOuput, &isLogOn) == FAILURE) {
        RETURN_STRING("Invalid parameters", true);
    }

	if (isLogOn)
	{
		printf("params: %s, %d, %d\n", pFileName, iLen, isNativeOuput);
	}

	// Dynamsoft Barcode Reader: init
	__int64 llFormat = (OneD | QR_CODE | PDF417 | DATAMATRIX);
	int iMaxCount = 0x7FFFFFFF;
	int iIndex = 0;
	ReaderOptions ro = {0};
	pBarcodeResultArray pResults = NULL;
	int iRet = -1;
	char * pszTemp = NULL;

	// Initialize license
	DBR_InitLicense("38B9B94D8B0E2B41DB1CC80A58946567");
	ro.llBarcodeFormat = llFormat;
	ro.iMaxBarcodesNumPerPage = iMaxCount;

	// Decode barcode image
	int ret = DBR_DecodeFile(pFileName, &ro, &pResults);

	if (ret == DBR_OK)
	{
		int count = pResults->iBarcodeCount;
		pBarcodeResult* ppBarcodes = pResults->ppBarcodes;
		pBarcodeResult tmp = NULL;
		char result[2048] = {0};

		if (count == 0)
		{
			add_next_index_string(return_value, "No Barcode detected", true);
		}

		// loop all results
		for (int i = 0; i < count; i++)
		{
			char barcodeResult[1024];

			// A barcode result.
			tmp = ppBarcodes[i];

			if (isNativeOuput)
			{
				sprintf(barcodeResult, "format: %s, value: %s\n", GetFormatStr(tmp->llFormat), tmp->pBarcodeData);
				strcat_s(result, barcodeResult);
			}
			else
			{
				// Working with PHP array: http://php.net/manual/en/internals2.variables.arrays.php
				zval *tmp_array;
				// Initialize zval
				MAKE_STD_ZVAL(tmp_array);
				array_init(tmp_array);
				// Add format & value to an array
				add_next_index_string(tmp_array, GetFormatStr(tmp->llFormat), true);
				add_next_index_string(tmp_array, tmp->pBarcodeData, true);
				// Add result to returned array
				add_next_index_zval(return_value, tmp_array);
			}
		}

		// Dynamsoft Barcode Reader: release memory
		DBR_FreeBarcodeResults(&pResults);

		if (isLogOn && isNativeOuput)
		{
			printf("Native result: %s\n", result);
		}

		if (isNativeOuput)
		{
			add_next_index_string(return_value, result, true);
		}
	}
	else
	{
		add_next_index_string(return_value, "No Barcode detected", true);
	}

}
