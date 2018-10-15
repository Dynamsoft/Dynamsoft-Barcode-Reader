#pragma once

#include <vector>
#include <string>
#include <list>
#include <map>
#include <fstream>
#include <sstream>

#include "BarcodeStatisticsRecorder.h"

#ifndef SAFE_DELETE
#define SAFE_DELETE(obj) if(obj!=NULL){ delete obj;obj=NULL;}
#endif

using namespace std;


class CBarcodeStatisticsRecorder;

class CBarcodeFileReader
{
public:
	CBarcodeFileReader();
	~CBarcodeFileReader();

	typedef enum _emOutputType 
	{
		OUTPUT_CONSOLE,
		OUTPUT_FILE,
	}OUTPUT_TYPE;

	typedef enum _enBarcodeFormat {
		ALL_BARCODE,
		ONED_BARCODE,
		CODE39_BARCODE,
		CODE128_BARCODE,
		CODE93_BARCODE,
		CODABAR_BARCODE,
		ITF_BARCODE,
		EAN13_BARCODE,
		EAN8_BARCODE,
		UPC_A_BARCODE,
		UPC_E_BARCODE,
		INDUSTRIAL_25_BARCODE,
		PDF417_BARCODE,
		DATAMATRIX_BARCODE,
		AZTEC_BARCODE,
	}BARCODE_FORMAT;

private:
	typedef enum _enReaderState 
	{
		READER_STOPPED,
		READER_RUNNING,
		READER_PAUSE,
	}READER_STATE;
	
private:
	string	    m_barcodeFilesDir;
	string		m_decodeResultOutputDir;
	OUTPUT_TYPE	m_outputType;
	READER_STATE m_readerState; //0:stopped 1:running 2:pause
protected:
	string	    m_currentOutputFileName;
	CBarcodeStatisticsRecorder* m_pBarcodeStatisticsRecorder;
public:
	void LoadBarcodeFiles(const char *strBarcodeFilesDir);

	void SetOutputType(OUTPUT_TYPE outputType);
	void SetOutputFileDir(const char *strOutputDir);

	virtual void Run();
	void Pause();
	void Stop();
protected:

	virtual bool ReadFileBarcodes(const  string strBarcodeFilePath, CBarcodeStatisticsRecorder::DecodeResultInfo &decodeResultInfo)= 0;

	string GetCurrentTimeString();
	string ToHexString(unsigned char* bytes, const int byteLength);
private:	
	void ProcessBarcodeFileRead();
	void ScanBarcodeFilesDir(string dir);
	void CreateOutputFileDir(string strOutputFilePath);
};

