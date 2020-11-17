#pragma once

#include <vector>
#include <string>
#include <list>
#include <map>
#include <fstream>
#include <sstream>
#if defined(_WIN64) || defined(_WIN32)
#include <io.h>
#include <direct.h>
#define sleep _sleep
#else
#include <sys/io.h>
#include <dirent.h>
#include <unistd.h> 
#include <sys/stat.h>
#include <sys/types.h>
#endif

#include "BarcodeStatisticsRecorder.h"

#ifndef SAFE_DELETE
#define SAFE_DELETE(obj) if(obj!=NULL){ delete obj;obj=NULL;}
#endif

using namespace std;

struct PathInfo
{
	char* name;
	bool isDir;
	const string strDir;
#if defined(_WIN64) || defined(_WIN32)
	_finddata_t findData;
	intptr_t handle;
#else
	struct dirent* pDirent;
	struct stat s_buf;
	DIR* pDir;
#endif
	PathInfo(const string& sDir) :strDir(sDir)
	{}
};

static bool ReadNext(PathInfo& pathInfo)
{
#if defined(_WIN64) || defined(_WIN32)
	if (_findnext(pathInfo.handle, &pathInfo.findData) == 0)
	{
		pathInfo.name = pathInfo.findData.name;
		pathInfo.isDir = ((pathInfo.findData.attrib & _A_SUBDIR) != 0);
		return true;
	}
#else
	pathInfo.pDirent = readdir(pathInfo.pDir);
	if (pathInfo.pDirent != NULL)
	{
		pathInfo.name = pathInfo.pDirent->d_name;
		string strTmpDir = pathInfo.strDir + "/" + pathInfo.name;
		stat(strTmpDir.c_str(), &pathInfo.s_buf);
		pathInfo.isDir = S_ISDIR(pathInfo.s_buf.st_mode);
		return true;
	}
#endif
	return false;
}
static bool OpenDirectory(PathInfo& pathInfo)
{
#if defined(_WIN64) || defined(_WIN32)
	string strTmpDir = pathInfo.strDir + "\\*.*";
	pathInfo.handle = _findfirst(strTmpDir.c_str(), &pathInfo.findData);
	if (pathInfo.handle == -1)
		return false;
	pathInfo.name = pathInfo.findData.name;
	pathInfo.isDir = ((pathInfo.findData.attrib & _A_SUBDIR) != 0);
#else
	stat(pathInfo.strDir.c_str(), &pathInfo.s_buf);
	pathInfo.pDir = opendir(pathInfo.strDir.c_str());
	if (!pathInfo.pDir)
		return false;
	if (!ReadNext(pathInfo))
		return false;
#endif
	return true;
}
static int CloseDirectory(PathInfo& pathInfo)
{
#if defined(_WIN64) || defined(_WIN32)
	return _findclose(pathInfo.handle);
#else
	return closedir(pathInfo.pDir);
#endif
}

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

