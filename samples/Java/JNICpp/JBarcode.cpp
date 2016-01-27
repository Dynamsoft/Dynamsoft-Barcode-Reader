#include "com_dynamsoft_barcode_JBarcode.h"


// BarcodeReaderDemo.cpp : Defines the entry point for the console application.

#include <windows.h>
#include "../../../../Components/C_C++/Include/If_DBR.h"



#ifdef _WIN64
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx64.lib")
#else
#pragma comment(lib, "../../../../Components/C_C++/Lib/DBRx86.lib")
#endif


bool isGetClassBarcodeResult = false;
jclass    br_m_cls   = NULL;
jmethodID br_m_mid   = NULL;
jfieldID  br_m_Format = NULL;
jfieldID  br_m_BarcodeData = NULL;
jfieldID  br_m_BarcodeDataLength = NULL;
jfieldID  br_m_Left = NULL;
jfieldID  br_m_Top = NULL;
jfieldID  br_m_Width = NULL;
jfieldID  br_m_Height = NULL;
jfieldID  br_m_X1 = NULL;
jfieldID  br_m_Y1 = NULL;
jfieldID  br_m_X2 = NULL;
jfieldID  br_m_Y2 = NULL;
jfieldID  br_m_X3 = NULL;
jfieldID  br_m_Y3 = NULL;
jfieldID  br_m_X4 = NULL;
jfieldID  br_m_Y4 = NULL;
jfieldID  br_m_PageNum = NULL;

bool isGetClassBarcodeArrayResult = false;
jclass    brAry_cls   = NULL;
jmethodID brAry_mid   = NULL;
jfieldID  brAry_field_count = NULL;
jfieldID  brAry_field_brResult = NULL;


void loadJavaClassInfo(JNIEnv *env){
	//if(!isGetClassBarcodeResult){
		br_m_cls   = env->FindClass("com/dynamsoft/barcode/tagBarcodeResult");
		br_m_mid   = env->GetMethodID(br_m_cls,"<init>","()V");

		br_m_Format = env->GetFieldID(br_m_cls,"lFormat","J");
		br_m_BarcodeData = env->GetFieldID(br_m_cls,"pBarcodeData","[B");
		br_m_BarcodeDataLength = env->GetFieldID(br_m_cls,"iBarcodeDataLength","I");
		br_m_Left = env->GetFieldID(br_m_cls,"iLeft","I");
		br_m_Top = env->GetFieldID(br_m_cls,"iTop","I");
		br_m_Width = env->GetFieldID(br_m_cls,"iWidth","I");
		br_m_Height = env->GetFieldID(br_m_cls,"iHeight","I");
		br_m_X1 = env->GetFieldID(br_m_cls,"iX1","I");
		br_m_Y1 = env->GetFieldID(br_m_cls,"iY1","I");
		br_m_X2 = env->GetFieldID(br_m_cls,"iX2","I");
		br_m_Y2 = env->GetFieldID(br_m_cls,"iY2","I");
		br_m_X3 = env->GetFieldID(br_m_cls,"iX3","I");
		br_m_Y3 = env->GetFieldID(br_m_cls,"iY3","I");
		br_m_X4 = env->GetFieldID(br_m_cls,"iX4","I");
		br_m_Y4 = env->GetFieldID(br_m_cls,"iY4","I");
		br_m_PageNum = env->GetFieldID(br_m_cls,"iPageNum","I");
		isGetClassBarcodeResult = true;
	//}

	//if(!isGetClassBarcodeArrayResult){
	    brAry_cls   = env->FindClass("com/dynamsoft/barcode/tagBarcodeResultArray");
		brAry_mid   = env->GetMethodID(brAry_cls,"<init>","()V");
		brAry_field_count = env->GetFieldID(brAry_cls,"iBarcodeCount","I");
		brAry_field_brResult = env->GetFieldID(brAry_cls,"ppBarcodes","[Lcom/dynamsoft/barcode/tagBarcodeResult;");
		isGetClassBarcodeArrayResult = true;
	//}
}

jobject convertResultToJNIObject(JNIEnv *env, pBarcodeResult pBarcode){

	loadJavaClassInfo(env);


    jobject obj = env->NewObject(br_m_cls, br_m_mid);

	jbyteArray rtnbytes = env->NewByteArray((jsize)(pBarcode->iBarcodeDataLength)); 
	env->SetByteArrayRegion(rtnbytes, 0, (jsize)(pBarcode->iBarcodeDataLength), (jbyte*)pBarcode->pBarcodeData); 

	env->SetLongField(obj, br_m_Format, pBarcode->llFormat);
	env->SetObjectField(obj, br_m_BarcodeData, rtnbytes);
	env->SetIntField(obj, br_m_BarcodeDataLength, pBarcode->iBarcodeDataLength);
	env->SetIntField(obj, br_m_Left, pBarcode->iLeft);
	env->SetIntField(obj, br_m_Top, pBarcode->iTop);
	env->SetIntField(obj, br_m_Width, pBarcode->iWidth);
	env->SetIntField(obj, br_m_Height, pBarcode->iHeight);
	env->SetIntField(obj, br_m_X1, pBarcode->iX1);
	env->SetIntField(obj, br_m_Y1, pBarcode->iY1);
	env->SetIntField(obj, br_m_X2, pBarcode->iX2);
	env->SetIntField(obj, br_m_Y2, pBarcode->iY2);
	env->SetIntField(obj, br_m_X3, pBarcode->iX3);
	env->SetIntField(obj, br_m_Y3, pBarcode->iY3);
	env->SetIntField(obj, br_m_X4, pBarcode->iX4);
	env->SetIntField(obj, br_m_Y4, pBarcode->iY4);
	env->SetIntField(obj, br_m_PageNum, pBarcode->iPageNum);

	return obj;
}

void fillBarcodeResultArray(JNIEnv *env, jobject obj, pBarcodeResultArray pArrayResults){

	loadJavaClassInfo(env);

	int count = pArrayResults->iBarcodeCount;
	pBarcodeResult* ppBarcodes = pArrayResults->ppBarcodes;


	jobjectArray swArray = env->NewObjectArray(count, br_m_cls, 0); 

	for(int i=0; i<count; i++){
		env->SetObjectArrayElement(swArray, i, convertResultToJNIObject(env, ppBarcodes[i]));
	}

	env->SetIntField(obj, brAry_field_count, count);
	env->SetObjectField(obj, brAry_field_brResult, swArray);

}

void SetOptions(pReaderOptions pOption, jint option_iMaxBarcodesNumPerPage, jlong option_llBarcodeFormat){

	if(option_llBarcodeFormat > 0)
		pOption->llBarcodeFormat = option_llBarcodeFormat;
	else
		pOption->llBarcodeFormat = OneD | QR_CODE;

	pOption->iMaxBarcodesNumPerPage = option_iMaxBarcodesNumPerPage;
}


JNIEXPORT jint JNICALL Java_com_dynamsoft_barcode_JBarcode_DBR_1InitLicense
(JNIEnv *env, jclass, jstring pString){

	const char *nativeString = env->GetStringUTFChars(pString, 0);  

	//printf("%s", nativeString);
	int ret = DBR_InitLicense(nativeString);

	//DON'T FORGET THIS LINE!!!  
	env->ReleaseStringUTFChars(pString, nativeString);  

	return ret;
}

JNIEXPORT jint JNICALL Java_com_dynamsoft_barcode_JBarcode_DBR_1DecodeFile
  (JNIEnv *env, jclass, jstring strFileName, jint option_iMaxBarcodesNumPerPage, jlong option_llBarcodeFormat, jobject pArrayResults)
{
	const char *pFileName = env->GetStringUTFChars(strFileName, 0);
	pBarcodeResultArray pResults = NULL;
	ReaderOptions option;
	SetOptions(&option, option_iMaxBarcodesNumPerPage, option_llBarcodeFormat);

	int ret = DBR_DecodeFile(
		pFileName,
		&option,
		&pResults
	);

	if(ret == DBR_OK){
		fillBarcodeResultArray(env, pArrayResults, pResults);
		DBR_FreeBarcodeResults(&pResults);
	}


	//DON'T FORGET THIS LINE!!!  
	env->ReleaseStringUTFChars(strFileName, pFileName);  
	return ret;
}

JNIEXPORT jint JNICALL Java_com_dynamsoft_barcode_JBarcode_DBR_1DecodeFileRect
  (JNIEnv *env, jclass, jstring strFileName, jint option_iMaxBarcodesNumPerPage, jlong option_llBarcodeFormat, jint iRectLeft, jint iRectTop, jint iRectWidth, jint iRectHeight, jobject pArrayResults)
{
	const char *pFileName = env->GetStringUTFChars(strFileName, 0);
	pBarcodeResultArray pResults = NULL;
	ReaderOptions option;
	SetOptions(&option, option_iMaxBarcodesNumPerPage, option_llBarcodeFormat);


	int ret = DBR_DecodeFileRect(
		pFileName,
		&option,
		iRectLeft,	
		iRectTop,	
		iRectWidth,	
		iRectHeight,
		&pResults
	);
		
	if(ret == DBR_OK){

		fillBarcodeResultArray(env, pArrayResults, pResults);
		DBR_FreeBarcodeResults(&pResults);
	}

	//DON'T FORGET THIS LINE!!!  
	env->ReleaseStringUTFChars(strFileName, pFileName);  
	return ret;
}

JNIEXPORT jint JNICALL Java_com_dynamsoft_barcode_JBarcode_DBR_1DecodeBuffer
  (JNIEnv *env, jclass, jbyteArray pDIBBuffer, jint iDIBSize, jint option_iMaxBarcodesNumPerPage, jlong option_llBarcodeFormat, jobject pArrayResults)
{
	pBarcodeResultArray pResults = NULL;
	ReaderOptions option;
	SetOptions(&option, option_iMaxBarcodesNumPerPage, option_llBarcodeFormat);

	int ret = DBR_DecodeBuffer(
		(unsigned char*) pDIBBuffer,		
		iDIBSize,
		&option,	
		&pResults
	);
	
	if(ret == DBR_OK){
		fillBarcodeResultArray(env, pArrayResults, pResults);
		DBR_FreeBarcodeResults(&pResults);
	}

	return ret;
}

JNIEXPORT jint JNICALL Java_com_dynamsoft_barcode_JBarcode_DBR_1DecodeBufferRect
  (JNIEnv *env, jclass, 
  jbyteArray pDIBBuffer, jint iDIBSize, jint option_iMaxBarcodesNumPerPage, jlong option_llBarcodeFormat, 
  jint iRectLeft, jint iRectTop, jint iRectWidth, jint iRectHeight, jobject pArrayResults)
{
	pBarcodeResultArray pResults = NULL;
	ReaderOptions option;
	SetOptions(&option, option_iMaxBarcodesNumPerPage, option_llBarcodeFormat);

	int ret = DBR_DecodeBufferRect(
		(unsigned char*) pDIBBuffer,		
		iDIBSize,
		&option,
		iRectLeft,	
		iRectTop,	
		iRectWidth,	
		iRectHeight,
		&pResults
	);

	if(ret == DBR_OK){
		fillBarcodeResultArray(env, pArrayResults, pResults);
		DBR_FreeBarcodeResults(&pResults);
	}

	return ret;
}

JNIEXPORT jstring JNICALL Java_com_dynamsoft_barcode_JBarcode_DBR_1GetErrorString
  (JNIEnv *env, jclass, jint iErrorCode)
{
	const char *pError = DBR_GetErrorString( iErrorCode);
    return env->NewStringUTF(pError);
    // (*env)->ReleaseStringUTFChars(env, jstr, utf); 

}

// for test
/*
JNIEXPORT jint JNICALL Java_com_dynamsoft_T_getScanResult (JNIEnv *env, jclass cls, jobject pArrayResults)
{
	BYTE by[2];
	by[0] = 100;
	by[1] = 101;

	pBarcodeResult aryBR[1];

	BarcodeResult barcode;
	barcode.iBarcodeDataLength = 2;
	barcode.llFormat = 2;
	barcode.iHeight = 3;
	barcode.iLeft = 4;
	barcode.iPageNum = 5;
	barcode.iTop = 6;
	barcode.iWidth = 7;
	barcode.iX1 = 11;
	barcode.iY1 = 12;
	barcode.iX2 = 21;
	barcode.iY2 = 22;
	barcode.iX3 = 31;
	barcode.iY3 = 32;
	barcode.iX4 = 41;
	barcode.iY4 = 42;
	barcode.pBarcodeData = (char *) by;

	aryBR[0] = &barcode;

	BarcodeResultArray ary;
	ary.iBarcodeCount = 1;
	ary.ppBarcodes = aryBR;

	fillBarcodeResultArray(env, pArrayResults, &ary);


	return 0;
}
*/