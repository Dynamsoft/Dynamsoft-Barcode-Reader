#pragma once
#include "BarcodeFileReader.h"
#include "../../../../../Components/C_C++/Include/DynamsoftBarcodeReader.h"

#ifdef _WIN64
#pragma comment(lib, "../../../../../Components/C_C++/Lib/DBRx64.lib")
#else
#pragma comment(lib, "../../../../../Components/C_C++/Lib/DBRx86.lib")
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
	CBarcodeReader * m_pBarcodeReader;
};

