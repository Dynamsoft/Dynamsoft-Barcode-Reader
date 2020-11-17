#pragma once
#include "BarcodeFileReader.h"
#include "DynamsoftBarcodeReader.h"
#include "DynamsoftCommon.h"

#ifdef _WIN64
#pragma comment(lib, "../../../Lib/Windows/x64/DBRx64.lib")
#else
#pragma comment(lib, "../../../Lib/Windows/x86/DBRx86.lib")
#endif

class CBarcodeReader;
class CDbrBarcodeFileReader :
	public CBarcodeFileReader
{
public:
	CDbrBarcodeFileReader();
	~CDbrBarcodeFileReader();
public:	
	void Run();
	void LoadRuntimeSettings(std::string strSettingFilePath);
protected:
	virtual bool ReadFileBarcodes(const std::string strFilePath, CBarcodeStatisticsRecorder::DecodeResultInfo &decodeResultInfo);
private:
	string CreateOutputFileName(string defultName);
	void RunWithRuntimeSettings();
private:
	
	vector<string>  m_listSettingsFile;
	dynamsoft::dbr::CBarcodeReader * m_pBarcodeReader;
};

