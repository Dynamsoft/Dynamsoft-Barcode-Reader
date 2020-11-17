#pragma once

#include <string>
#include <list>
#include<vector>
using namespace std;

#if defined(_WIN64) || defined(_WIN32)
#define strcasecmp stricmp
#define separator "\\"
#else
#define separator "/"
#endif

class CBarcodeStatisticsRecorder
{
public:
	CBarcodeStatisticsRecorder();
	~CBarcodeStatisticsRecorder();


	typedef enum _emResultState {
		STATE_INVALID,
		STATE_OK,
		STATE_FAILED,
	}RESULT_STATE;

	typedef struct _tagCodeValue {
		string strTextMessage;
		string strCodeFormat;
		string strHexMessage;
	}BCODE_VALUE;
	typedef struct _tagDecodeResult {
		string strFileName;
		string strErrorMessage;
		list<BCODE_VALUE> listCodes;
		double dDecodeTime; //ms
		RESULT_STATE state;
	}DecodeResultInfo, *PDecodeResultInfo;


	typedef struct _tagStatisticsResult
	{
		int nTotalFiles;
		int nSuccessDecodeFiles;
		double dSuccessRate;
		double dTotalDecodeTimes;
		double dAvgDecodeTimes;//for each code or file?
		int nTotalCodes;
	}DecodeStatisticsResult, *PDecodeStatisticsResult;

	typedef struct _tagRunningTaceInfo
	{
		string SCAN_DIRECTORY;// DOCUMENT_PATH;
		string CURRENT_FILE_PATH;
		string CURRENT_FILE_STATUE;
		string BCODE_READER;
		string OUTPUT_FILE_PATH;
		size_t CURRENT_POS_SIZE;
		string LAST_FILE_PATH;
		size_t LAST_POS_SIZE;

		size_t TOTAL_IMAGE_COUNT;
		size_t IMAGES_WITH_BARCODES_RECOGNIZED;
		size_t TIME_COST_OF_ALL_IMAGES;
		size_t TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED;
		size_t TOTAL_BARCODE_COUNT;
		size_t RESUMED_TIMES;
		string DECODE_SETTING_FILE;
		_tagRunningTaceInfo() {
			CURRENT_POS_SIZE = 0;
			LAST_POS_SIZE = 0;
			TOTAL_IMAGE_COUNT = 0;
			IMAGES_WITH_BARCODES_RECOGNIZED = 0;
			TIME_COST_OF_ALL_IMAGES = 0;
			TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED = 0;
			TOTAL_BARCODE_COUNT = 0;
			RESUMED_TIMES = 0;
			DECODE_SETTING_FILE = "";
			OUTPUT_FILE_PATH = "";
			CURRENT_FILE_PATH = "";
			BCODE_READER = "";
			LAST_FILE_PATH = "";
			CURRENT_FILE_STATUE = "STATE_INVALID";
		}
	}RUNNING_TRACE_INFO;
private:
	vector<DecodeResultInfo>  m_vctDecodeResults;

	ostream		*m_pOStream,*m_pContentOStream;
	RUNNING_TRACE_INFO m_runningTraceInfo;
	bool		m_bTraceThePoint;
	string m_outputFilePath;
	string m_scanDirectory;

private:
	void RemoveReaderRunningTrace();

	void OutputDecodResult(DecodeResultInfo *resultMode);
	void OutputStatisticsResult();

	string Base64encodestring(const string &strString);
	string Base64decodestring(const string &strString);


public:
	void Initialization(string &lastScanFileDir, string &lastDecodeBarcodeOutputFilepath);
	void StartRecord(ostream *pOstream, ostream *pContentOstream, string scanFileDir, string outputFilepath);
	void RecordStatisticsData(DecodeResultInfo decodeResult);
	bool FindLastScanPoint(string currentFilePath);
	void StopRecord();

	RUNNING_TRACE_INFO  LoadReaderRunningTrace();
	void RecordReaderRunningTrace(RUNNING_TRACE_INFO runningTraceInfo);
	void AddDecodeResult(DecodeResultInfo decodeResult);
	size_t GetDecodeResultSize();

	bool FindDecodeResultByFilePath(const string strFileName, CBarcodeStatisticsRecorder::DecodeResultInfo &decodeResultInfo);
	bool FindDecodeResultByIndex(const int index,CBarcodeStatisticsRecorder::DecodeResultInfo &decodeResultInfo);	
	void ClearDecodeResult();
	vector<DecodeResultInfo> getDecodeResultList();
	DecodeStatisticsResult DoDataStatistics();
};

