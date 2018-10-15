#include "stdafx.h"
#include <iostream>
#include <io.h>
#include <direct.h>
#include<iomanip>
#include <ctime>
#include "BarcodeFileReader.h"


CBarcodeFileReader::CBarcodeFileReader()
{

	m_barcodeFilesDir		= ".";
	m_decodeResultOutputDir = ".";
	m_outputType	 = OUTPUT_FILE;
	m_readerState = READER_STOPPED;
	m_pBarcodeStatisticsRecorder = new CBarcodeStatisticsRecorder();
}

CBarcodeFileReader::~CBarcodeFileReader()
{
	SAFE_DELETE(m_pBarcodeStatisticsRecorder);
	
}

void CBarcodeFileReader::LoadBarcodeFiles(const char *strBarcodeFilesDir)
{
	m_barcodeFilesDir = strBarcodeFilesDir == NULL ? ".\\" : strBarcodeFilesDir;
}

void CBarcodeFileReader::SetOutputType(OUTPUT_TYPE outputType)
{
	m_outputType = outputType;
}

void CBarcodeFileReader::SetOutputFileDir(const char *strOutputDir)
{
	m_decodeResultOutputDir = strOutputDir == NULL ? ".\\" : strOutputDir;
	
}


void CBarcodeFileReader::Run()
{
	ProcessBarcodeFileRead();	
}
void CBarcodeFileReader::Pause()
{
	m_readerState = READER_PAUSE;
}

void CBarcodeFileReader::Stop()
{
	m_readerState = READER_STOPPED;
}

void CBarcodeFileReader::ProcessBarcodeFileRead()
{
	ostream *pResultofStream = NULL,*pResultContentStream = NULL;
	string lastBarcodeFilesDir, lastDecodeBarcodeOutputFilePath;
	m_pBarcodeStatisticsRecorder->Initialization(lastBarcodeFilesDir, lastDecodeBarcodeOutputFilePath);
	if (m_outputType == OUTPUT_FILE)
	{
		string strSubffix = ".csv" ;
		string strOutputFilePath = m_decodeResultOutputDir + "\\"+m_currentOutputFileName + strSubffix;
		if (!lastBarcodeFilesDir.empty())
		{
			m_barcodeFilesDir = lastBarcodeFilesDir;
			strOutputFilePath = lastDecodeBarcodeOutputFilePath;
		}
		string strOutputContentFilePath = strOutputFilePath;
		strOutputContentFilePath = strOutputContentFilePath.substr(0, strOutputContentFilePath.find_last_of(".")) + "_original.txt";// strOutputContentFilePath.replace(strOutputFilePath.find_last_of(".csv")- strlen(".csv"), strlen(".csv"), "_content.txt");
		CreateOutputFileDir(strOutputContentFilePath);
		CreateOutputFileDir(strOutputFilePath);

		cout <<"The output file:"<< strOutputFilePath <<"\n"<< endl;
		pResultofStream = new ofstream(strOutputFilePath.c_str(), ios::app);	
		pResultContentStream = new ofstream(strOutputContentFilePath.c_str(), ios::app);
		m_pBarcodeStatisticsRecorder->StartRecord(pResultofStream, pResultContentStream, m_barcodeFilesDir, strOutputFilePath);
		

	}
	else
	{
		pResultofStream = &cout;
		m_pBarcodeStatisticsRecorder->StartRecord(&cout, &cout,"","");
		//pErrorOfstream = &cout;
	}

	/////////////////////////////////////////////////
	m_readerState = READER_RUNNING;
	
	ScanBarcodeFilesDir(m_barcodeFilesDir);

	m_readerState = READER_STOPPED;

	m_pBarcodeStatisticsRecorder->StopRecord();

	if (m_outputType == OUTPUT_FILE)
	{
		pResultofStream->flush();
		((ofstream*)pResultofStream)->close();
		SAFE_DELETE(pResultofStream);
	}
	
}


void CBarcodeFileReader::ScanBarcodeFilesDir(const string strDir)
{
	string		   strTmpDir = strDir+ "\\*.*";
	vector<string> listDir;
	_finddata_t    findData;
	intptr_t	   handle;
	handle = _findfirst(strTmpDir.c_str(), &findData);
	if (handle == -1)
	{
		cout << "The directory " << strDir << " does not exist.\n";
		return;
	}
	do
	{
		switch (m_readerState)
		{
		case READER_STOPPED:
			return;
		case READER_PAUSE:
		{
			_sleep(2000);
			continue;
		}
			break;
		default:
			break;
		}
	
		if (findData.attrib & _A_SUBDIR)
		{
			if (strcmp(findData.name, ".") == 0 || strcmp(findData.name, "..") == 0)
				continue;
			strTmpDir = strDir + "\\" + findData.name;
			listDir.push_back(strTmpDir);
		}
		else
		{
			string fileName = findData.name;
			size_t pos = fileName.find_last_of('.'); // find index of the last '.'
			if (pos != string::npos) // if pos exits
			{
				fileName = fileName.substr(pos);
			}
			if (stricmp(fileName.c_str(), ".bmp") != 0
				&& stricmp(fileName.c_str(), ".jpg") != 0
				&& stricmp(fileName.c_str(), ".jpeg") != 0
				&& stricmp(fileName.c_str(), ".pdf") != 0
				&& stricmp(fileName.c_str(), ".tif") != 0
				&& stricmp(fileName.c_str(), ".png") != 0
				&& stricmp(fileName.c_str(), ".tiff") != 0
				&& stricmp(fileName.c_str(), ".gif") != 0)
				continue;
			string strCurrentFilePath = strDir + "\\" + findData.name;
			if (!m_pBarcodeStatisticsRecorder->FindLastScanPoint(strCurrentFilePath))
				continue;

			
			
			CBarcodeStatisticsRecorder::DecodeResultInfo decodeResult;
			decodeResult.strFileName = strCurrentFilePath;
			decodeResult.state = CBarcodeStatisticsRecorder::STATE_INVALID;
			m_pBarcodeStatisticsRecorder->RecordStatisticsData(decodeResult);

			bool bRet = ReadFileBarcodes(strCurrentFilePath, decodeResult);
			decodeResult.state = bRet ? CBarcodeStatisticsRecorder::STATE_OK : CBarcodeStatisticsRecorder::STATE_FAILED;	
			m_pBarcodeStatisticsRecorder->RecordStatisticsData(decodeResult);
		}
			
	} while (_findnext(handle, &findData) == 0);

	for (size_t i = 0; i < listDir.size(); i++)
	{		
		ScanBarcodeFilesDir(listDir.at(i));
	}
	_findclose(handle);  	
}


string CBarcodeFileReader::GetCurrentTimeString()
{
	time_t timer;
	struct tm *pTm;
	timer = time(NULL);
	pTm = localtime(&timer);
	char szFileName[256] = { 0 };
	pTm->tm_mon;
	pTm->tm_mday;
	pTm->tm_hour;
	pTm->tm_min;
	pTm->tm_sec;
	sprintf(szFileName, "%d%02d%02d%02d%02d%02d", pTm->tm_year + 1900, pTm->tm_mon + 1, pTm->tm_mday, pTm->tm_hour, pTm->tm_min, pTm->tm_sec);
	string strTime = szFileName;
	return strTime;
}
string CBarcodeFileReader::ToHexString(unsigned char* bytes, const int byteLength)
{
	string strHexResult;
	string HEX_PARAM("0123456789ABCDEF");

	for (int i = 0; i < byteLength; i++)
	{
		int nValue = 0x0f & (bytes[i] >> 4);
		strHexResult.append(1, HEX_PARAM.at(nValue));
		nValue = 0x0f & bytes[i];
		strHexResult.append(1, HEX_PARAM.at(nValue));
	}
	return strHexResult;
}


void CBarcodeFileReader::CreateOutputFileDir(string strOutputFilePath) {
	char *fileName = (char*)strOutputFilePath.c_str(), *pDir;
	int pos = 0;
	while ((pos = strOutputFilePath.find('\\', pos))!=string::npos)
	{
		string subStr = strOutputFilePath.substr(0, pos);		
		if (access(subStr.c_str(), 6) == -1)
		{
			mkdir(subStr.c_str());
		}
		pos++;
	}
	
}