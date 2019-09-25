#include "stdafx.h"
#include <io.h>
#include <time.h>
#include <iostream>
#include "DbrBarcodeFileReader.h"

CDbrBarcodeFileReader::CDbrBarcodeFileReader()
{
	m_pBarcodeReader = new CBarcodeReader();
	m_pBarcodeReader->InitLicense("t0068MgAAADaH8yokXmKf3axcV99lMBDDRYEZIsBZ5PPiekmW820HqSR2tQ/VOjuXPvq1FCvla7eS6KmEMUFgHZR9X7GuR2s=");
}

CDbrBarcodeFileReader::~CDbrBarcodeFileReader()
{

	SAFE_DELETE(m_pBarcodeReader);
}

void CDbrBarcodeFileReader::Run()
{
	if (m_listSettingsFile.size() > 0)
	{
		RunWithRuntimeSettings();
	}
	else
	{
		m_currentOutputFileName = CreateOutputFileName("DEFAULT"); 
		CBarcodeFileReader::Run();
	}
	
}


void CDbrBarcodeFileReader::LoadRuntimeSettings(string strSettingFilePath)
{
	string		   strTmpDir = strSettingFilePath + "\\*.*";
	vector<string> listDir;
	_finddata_t    findData;
	intptr_t	   handle;
	handle = _findfirst(strTmpDir.c_str(), &findData);
	if (handle == -1)
	{		
		return;
	}
	do
	{
		if (findData.attrib & _A_SUBDIR)
		{
			if (strcmp(findData.name, ".") == 0 || strcmp(findData.name, "..") == 0)
				continue;
			strTmpDir = strSettingFilePath + "\\" + findData.name;
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
			if (stricmp(fileName.c_str(), ".json") != 0)
				continue;			
			string strCurrentFilePath = strSettingFilePath + "\\" + findData.name;
			m_listSettingsFile.push_back(strCurrentFilePath);
		}

	} while (_findnext(handle, &findData) == 0);

	for (size_t i = 0; i < listDir.size(); i++)
	{
		LoadRuntimeSettings(listDir.at(i));
	}
	_findclose(handle);
	
}

void CDbrBarcodeFileReader::RunWithRuntimeSettings()
{
	CBarcodeStatisticsRecorder::RUNNING_TRACE_INFO traceInfo = m_pBarcodeStatisticsRecorder->LoadReaderRunningTrace();	
	bool bFindLastSetting = false;
	for (int i = 0; i < m_listSettingsFile.size(); i++)
	{
		traceInfo = m_pBarcodeStatisticsRecorder->LoadReaderRunningTrace();
		if (bFindLastSetting || traceInfo.DECODE_SETTING_FILE.empty()) {
			traceInfo.DECODE_SETTING_FILE = m_listSettingsFile.at(i);
			m_pBarcodeStatisticsRecorder->RecordReaderRunningTrace(traceInfo);
			if (!bFindLastSetting)
				bFindLastSetting = true;
		}
		else 
		{
			if (stricmp(traceInfo.DECODE_SETTING_FILE.c_str(), m_listSettingsFile.at(i).c_str()) != 0)
				continue;
			else
				bFindLastSetting = true;
		}

		string filePath = m_listSettingsFile.at(i);
		char szErrorMsgBuffer[1024] = { 0 };
		int nErrorCode = -1;
		nErrorCode = m_pBarcodeReader->InitRuntimeSettingsWithFile(filePath.c_str(), ConflictMode::CM_OVERWRITE, szErrorMsgBuffer, sizeof(szErrorMsgBuffer));
		if (nErrorCode != 0)
		{
			cout <<"Init runtime settings file("+ filePath+") failed:"<<string(szErrorMsgBuffer) << endl;
		}
		else {
			int pos1 = filePath.rfind('\\');
			int pos2 = filePath.rfind('.');
			string strFileName = filePath.substr(pos1+1, pos2 - pos1-1);
			m_currentOutputFileName = CreateOutputFileName(strFileName);
			CBarcodeFileReader::Run();
		}
	}	
}

bool CDbrBarcodeFileReader::ReadFileBarcodes( const string strFilePath, CBarcodeStatisticsRecorder::DecodeResultInfo &decodeResultInfo)
{
	bool bret = true;
	clock_t start, end;

	///////////////////////////////////////////////////
	start = clock();
	int nErrorCode = -1;
	nErrorCode = m_pBarcodeReader->DecodeFile(strFilePath.c_str());
	end = clock();
	decodeResultInfo.dDecodeTime = ((double)(end - start) / CLOCKS_PER_SEC * 1000);
	if ((nErrorCode == 0) || (nErrorCode == -10017))
	{
		TextResultArray *pTextResultArray = NULL;

		nErrorCode = m_pBarcodeReader->GetAllTextResults(&pTextResultArray);
		if (nErrorCode != 0)
		{
			decodeResultInfo.strErrorMessage = m_pBarcodeReader->GetErrorString(nErrorCode);
			bret = false;
		}

		
		for (int i = 0; pTextResultArray != NULL && i < (pTextResultArray)->resultsCount; i++)
		{
			CBarcodeStatisticsRecorder::BCODE_VALUE bcodeValue;
			bcodeValue.strTextMessage = (pTextResultArray)->results[i]->barcodeText;
			bcodeValue.strCodeFormat = (pTextResultArray)->results[i]->barcodeFormatString;
			unsigned char* tempByte = (pTextResultArray)->results[i]->barcodeBytes;
			int byteLength = (pTextResultArray)->results[i]->barcodeBytesLength;
			bcodeValue.strHexMessage = ToHexString(tempByte, byteLength);
			decodeResultInfo.listCodes.push_back(bcodeValue);
		}
		if (pTextResultArray != NULL)
		{
			m_pBarcodeReader->FreeTextResults(&pTextResultArray);
		}
	}
	else
	{
		decodeResultInfo.strErrorMessage = m_pBarcodeReader->GetErrorString(nErrorCode);
		bret = false;
	}
	return bret;
} 

string CDbrBarcodeFileReader::CreateOutputFileName(string defultName)
{
	string strFileName = defultName;
	string currentOutputFileName = "DBR";
	currentOutputFileName += "_T_" + strFileName + "_" + GetCurrentTimeString();
	return currentOutputFileName;
}

	
