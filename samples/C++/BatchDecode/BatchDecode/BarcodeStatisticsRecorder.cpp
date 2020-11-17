#include "stdafx.h"
#include <fstream>
#include <sstream>
#include <algorithm> 
#include <functional> 
#include <cctype>
#include<iomanip>
#include "BarcodeStatisticsRecorder.h"

static std::string  replace_all_distinct(string str, const   string old_value, const   string  new_value)
{
	for (string::size_type pos(0); pos != string::npos; pos += new_value.length()) {
		if ((pos = str.find(old_value, pos)) != string::npos)
			str.replace(pos, old_value.length(), new_value);
		else   break;
	}
	return   str;
}
#if defined(_WIN64) || defined(_WIN32)
static inline std::string& rtrim(std::string& s) {
#else
static inline std::string rtrim(std::string s) {
#endif
	s.erase(std::find_if(s.rbegin(), s.rend(), std::not1(std::ptr_fun<int, int>(std::isspace))).base(), s.end());
	return s;
}

CBarcodeStatisticsRecorder::CBarcodeStatisticsRecorder()
{
	m_bTraceThePoint = false;
}


CBarcodeStatisticsRecorder::~CBarcodeStatisticsRecorder()
{
	m_vctDecodeResults.clear();
}


void CBarcodeStatisticsRecorder::AddDecodeResult(DecodeResultInfo resultInfo)
{
	m_vctDecodeResults.push_back(resultInfo);
}

bool CBarcodeStatisticsRecorder::FindDecodeResultByFilePath(string strFileName, CBarcodeStatisticsRecorder::DecodeResultInfo &decodeResultInfo)
{
	for (int i = 0; i < m_vctDecodeResults.size(); i++)
	{
		DecodeResultInfo info = m_vctDecodeResults.at(i);
		if (0 == strcasecmp(info.strFileName.c_str(), strFileName.c_str()))
		{			
			decodeResultInfo = info;
			return true;
		}
	}
	return false;
}

bool CBarcodeStatisticsRecorder::FindDecodeResultByIndex(const int index,CBarcodeStatisticsRecorder::DecodeResultInfo &decodeResultInfo)
{
	if(index < m_vctDecodeResults.size())
	{
		decodeResultInfo =  m_vctDecodeResults.at(index);
		return true;
	}
	return false;
}

size_t CBarcodeStatisticsRecorder::GetDecodeResultSize()
{
	return m_vctDecodeResults.size();
}
void CBarcodeStatisticsRecorder::ClearDecodeResult()
{
	m_vctDecodeResults.clear();
}

vector<CBarcodeStatisticsRecorder::DecodeResultInfo> CBarcodeStatisticsRecorder::getDecodeResultList()
{
	return m_vctDecodeResults;
}

CBarcodeStatisticsRecorder::DecodeStatisticsResult CBarcodeStatisticsRecorder::DoDataStatistics()
{
	DecodeStatisticsResult statisticsResult;

	size_t nTotalCodes = 0;
	size_t nSuccessFileNumber = 0;
	size_t nTotalFileNumber = m_vctDecodeResults.size();
	double dSpendTotaltime = 0.0;
	for (size_t i = 0; i < nTotalFileNumber; i++)
	{
		if (m_vctDecodeResults.at(i).state == RESULT_STATE::STATE_OK)
		{
			nSuccessFileNumber++;
			dSpendTotaltime += m_vctDecodeResults.at(i).dDecodeTime;
			nTotalCodes += m_vctDecodeResults.at(i).listCodes.size();
		}
	}
	statisticsResult.nTotalFiles = nTotalFileNumber;
	statisticsResult.nSuccessDecodeFiles = nSuccessFileNumber;
	statisticsResult.nTotalCodes = nTotalCodes;
	statisticsResult.dSuccessRate = ((double)nSuccessFileNumber*100.0 / (nTotalFileNumber*1.0));
	statisticsResult.dAvgDecodeTimes = dSpendTotaltime / nTotalCodes;
	statisticsResult.dTotalDecodeTimes = dSpendTotaltime;
	return statisticsResult;

}
void CBarcodeStatisticsRecorder::RecordStatisticsData(DecodeResultInfo decodeResult) {	

	size_t posSize = m_pOStream->tellp();
	if (decodeResult.state == STATE_INVALID) 
	{
		m_runningTraceInfo.LAST_FILE_PATH = m_runningTraceInfo.CURRENT_FILE_PATH;
		m_runningTraceInfo.LAST_POS_SIZE = m_runningTraceInfo.CURRENT_POS_SIZE;		
		m_runningTraceInfo.CURRENT_FILE_PATH = decodeResult.strFileName;
		m_runningTraceInfo.CURRENT_FILE_STATUE = "STATE_INVALID";
	}
	else 
	{
		m_runningTraceInfo.CURRENT_POS_SIZE = posSize;
		if (decodeResult.state == STATE_OK) {
			if (decodeResult.listCodes.size() > 0) {
				m_runningTraceInfo.TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED += decodeResult.dDecodeTime;
				m_runningTraceInfo.IMAGES_WITH_BARCODES_RECOGNIZED += 1;
			}
				
			m_runningTraceInfo.CURRENT_FILE_STATUE = "STATE_OK";
		}
		else
		{
			m_runningTraceInfo.CURRENT_FILE_STATUE = "STATE_FAILED";
		}

		m_runningTraceInfo.TOTAL_IMAGE_COUNT += 1;
		m_runningTraceInfo.TIME_COST_OF_ALL_IMAGES += decodeResult.dDecodeTime;
		m_runningTraceInfo.TOTAL_BARCODE_COUNT += decodeResult.listCodes.size();
		OutputDecodResult(&decodeResult);
	}	
	m_runningTraceInfo.OUTPUT_FILE_PATH = m_outputFilePath;
	m_runningTraceInfo.SCAN_DIRECTORY = m_scanDirectory;
	RecordReaderRunningTrace(m_runningTraceInfo);

	
}

void CBarcodeStatisticsRecorder::Initialization(string &lastScanFileDir, string &lastDecodeBarcodeOutputFilepath) {
	m_runningTraceInfo = LoadReaderRunningTrace();
	if (m_runningTraceInfo.OUTPUT_FILE_PATH.empty())
	{
		m_bTraceThePoint = false;
	}
	else {
		lastDecodeBarcodeOutputFilepath = m_runningTraceInfo.OUTPUT_FILE_PATH;
		lastScanFileDir = m_runningTraceInfo.SCAN_DIRECTORY;
		if (strcasecmp(m_runningTraceInfo.CURRENT_FILE_STATUE.c_str(), "STATE_INVALID")==0)
		{
			m_runningTraceInfo.TOTAL_IMAGE_COUNT += 1;
		}
		m_bTraceThePoint = true;		
	}
	

}
void CBarcodeStatisticsRecorder::StartRecord(ostream *pOstream, ostream *pContentOstream, string scanFileDir, string outputFilepath)
{
	string barcodeFilesDir;
	this->m_pOStream = pOstream;
	this->m_pContentOStream = pContentOstream;
	(*m_pOStream) << setprecision(2) << fixed;
	if (!m_bTraceThePoint)
	{	

		*m_pOStream << "NO.,Image Source,Time Cost(ms),Barcode Count,Barcode Type,Barcode Hex,Barcode Text,Original" << "\n";
		*m_pContentOStream<<setw(5)<<"NO."<<setw(32)<<"Image Source"<<"   Barcode Text" << "\n";

	}
	else {	
		//*pOstream << "resumed...\n";
	}
	(*m_pOStream).flush();
	(*m_pContentOStream).flush();
	m_outputFilePath = outputFilepath;
	m_scanDirectory = scanFileDir;
	
}

bool CBarcodeStatisticsRecorder::FindLastScanPoint(string currentFilePath)
{
	if (m_bTraceThePoint && !m_runningTraceInfo.CURRENT_FILE_PATH.empty())
	{
		if (strcasecmp(currentFilePath.c_str(), m_runningTraceInfo.CURRENT_FILE_PATH.c_str()) == 0)
		{
			m_bTraceThePoint = false;
			//record the to the decorde result file,because the app existed before record it last time.
			if (strcasecmp(m_runningTraceInfo.CURRENT_FILE_STATUE.c_str(), "STATE_INVALID")==0)
			{
				DecodeResultInfo decodeResult;
				decodeResult.strFileName = m_runningTraceInfo.CURRENT_FILE_PATH;
				decodeResult.state = STATE_INVALID;
				OutputDecodResult(&decodeResult);
			}
			return false;
		}
		else {
			return false;
		}
	}
	return true;
}

void CBarcodeStatisticsRecorder::StopRecord()
{
	OutputStatisticsResult();
	if (this->m_pOStream != NULL)
	{
		this->m_pOStream->flush();	
		if(this->m_pContentOStream!=NULL)
		this->m_pContentOStream->flush();
	}
	RemoveReaderRunningTrace();
}

void CBarcodeStatisticsRecorder::OutputDecodResult(CBarcodeStatisticsRecorder::DecodeResultInfo *resultMode)
{
	if (resultMode->state == CBarcodeStatisticsRecorder::STATE_OK)
	{
		(*m_pOStream) << m_runningTraceInfo.TOTAL_IMAGE_COUNT<<","<< resultMode->strFileName << "," << resultMode->dDecodeTime << "," << resultMode->listCodes.size() << ",";

		list<CBarcodeStatisticsRecorder::BCODE_VALUE>::iterator iter = resultMode->listCodes.begin();
		string strAllBarcodeText = "";
		string strAllBarcodeTextWithType = "";
		string strAllBarcodeHex = "";
		int index = 1;
		string strFirstFormatString = (iter!= resultMode->listCodes.end())?iter->strCodeFormat:"";
		while (iter != resultMode->listCodes.end())
		{
			char strIndex[8] = { 0 };
			sprintf(strIndex,"%d",index);
			
			strAllBarcodeHex += iter->strHexMessage;
			strAllBarcodeText += iter->strTextMessage;
			strAllBarcodeTextWithType += "("+ string(strIndex)+")["+iter->strCodeFormat+"] ";
			strAllBarcodeTextWithType += iter->strTextMessage;
			iter++;
			index++;
		}
		string strBarcodeContentFile = m_runningTraceInfo.OUTPUT_FILE_PATH;
		strBarcodeContentFile = strBarcodeContentFile.substr(0,strBarcodeContentFile.find_last_of("."))+ "_original.txt";
	
		int npos = string::npos;
		npos = strAllBarcodeText.find("\r");
		npos = strAllBarcodeText.find("\n");
		npos = strAllBarcodeText.find(",");		
		if ((npos = strAllBarcodeText.find("\r")!=string::npos)|| (npos = strAllBarcodeText.find("\n")) != string::npos || (npos = strAllBarcodeText.find(",")) != string::npos || (npos = strAllBarcodeText.find("\"")) != string::npos || strAllBarcodeText.length()>128 /*|| resultMode->listCodes.size() > 1*/)
		{
			(*m_pContentOStream) << setw(5) << m_runningTraceInfo.TOTAL_IMAGE_COUNT << "  " <<resultMode->strFileName << "   " << strAllBarcodeTextWithType << endl;
			(*m_pContentOStream).flush();

			string strSubBarcodeText = strAllBarcodeText;
			strSubBarcodeText = strSubBarcodeText.substr(0, min((int)strSubBarcodeText.length(), 128));	
			strSubBarcodeText = replace_all_distinct(strSubBarcodeText, "\r", " ");
			strSubBarcodeText = replace_all_distinct(strSubBarcodeText, "\n", " ");
			strSubBarcodeText = replace_all_distinct(strSubBarcodeText, "\"", "\"\"");
					
			
			(*m_pOStream) << strFirstFormatString<<","<< strAllBarcodeHex << "," << "\"" << strSubBarcodeText << "\"" << ",no";
		
		}
		else
		{
			(*m_pOStream) << strFirstFormatString << "," << strAllBarcodeHex << "," << strAllBarcodeText << ",yes";
		}

		(*m_pOStream) << endl;
		(*m_pOStream).flush();		
	}
	else if(resultMode->state == CBarcodeStatisticsRecorder::STATE_FAILED)
	{
		(*m_pOStream) << m_runningTraceInfo.TOTAL_IMAGE_COUNT << ","<< resultMode->strFileName << "," << resultMode->dDecodeTime << endl;
		(*m_pOStream).flush();	
	}
	else
	{
		m_runningTraceInfo.RESUMED_TIMES++;
		(*m_pOStream) << m_runningTraceInfo.TOTAL_IMAGE_COUNT << "," << resultMode->strFileName << ",resumed," << endl;
		(*m_pOStream).flush();
	}
}

void CBarcodeStatisticsRecorder::OutputStatisticsResult()
{
	float fRecognitionRate = m_runningTraceInfo.TOTAL_IMAGE_COUNT>0? ((float)m_runningTraceInfo.IMAGES_WITH_BARCODES_RECOGNIZED *100.0 / (m_runningTraceInfo.TOTAL_IMAGE_COUNT  *1.0)):0;
	float dAvgScanPerImageTime = m_runningTraceInfo.TOTAL_IMAGE_COUNT>0?m_runningTraceInfo.TIME_COST_OF_ALL_IMAGES / m_runningTraceInfo.TOTAL_IMAGE_COUNT:0;
	float dAvgSuccessScanTime = m_runningTraceInfo.IMAGES_WITH_BARCODES_RECOGNIZED>0 ? m_runningTraceInfo.TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED / m_runningTraceInfo.IMAGES_WITH_BARCODES_RECOGNIZED : 0;
	float dAvgSanPerBarcodeTime = m_runningTraceInfo.TOTAL_BARCODE_COUNT>0 ? m_runningTraceInfo.TIME_COST_OF_ALL_IMAGES / m_runningTraceInfo.TOTAL_BARCODE_COUNT : 0;

	if (m_pOStream != NULL)
	{
		*(m_pOStream) << "\nTotal Image Count:," << m_runningTraceInfo.TOTAL_IMAGE_COUNT << "\n";
		*(m_pOStream) << "Images with Barcodes Recognized:," << m_runningTraceInfo.IMAGES_WITH_BARCODES_RECOGNIZED << "\n";
		*(m_pOStream) << "Total Barcode Count:," << m_runningTraceInfo.TOTAL_BARCODE_COUNT << "\n";
		*(m_pOStream) << "Time Cost of All Images(ms):," << m_runningTraceInfo.TIME_COST_OF_ALL_IMAGES << "\n";
		*(m_pOStream) << "Recognition Rate:," << fRecognitionRate << "% ,   ," << "Images with Barcodes Recognized/ Total Image Count\n";
		*(m_pOStream) << "Avg Time of Total Scan Per Image (ms):," << dAvgScanPerImageTime << ", ," << "Total Time Cost of All Images/ Total Image Count\n";
		*(m_pOStream) << "Avg Time of Total Scan Per Barcode (ms):," << dAvgSanPerBarcodeTime << ", ," << "Total Time Cost of All Images/ Total Barcode Count\n";
		*(m_pOStream) << endl;
		*(m_pOStream) << "Time Cost of Images with Barcodes Recognized(ms):," << m_runningTraceInfo.TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED << "\n";	
		*(m_pOStream) << "Avg Time of Successful Scan Per Image (ms):," << dAvgSuccessScanTime << ", ," << "Time Cost of Images with Barcodes Recognized/ Images with Barcodes Recognized\n";
		*(m_pOStream) << endl;
		*(m_pOStream) << "Resume times:," << m_runningTraceInfo.RESUMED_TIMES << "\n";



		string strBarcodeContentFile = m_runningTraceInfo.OUTPUT_FILE_PATH;
		strBarcodeContentFile = strBarcodeContentFile.substr(0, strBarcodeContentFile.find_last_of(".")) + "_original.txt";
		string strOriginalFileName = strBarcodeContentFile.rfind('/') != string::npos ? strBarcodeContentFile.substr(strBarcodeContentFile.rfind("\\") + strlen("\\")) : strBarcodeContentFile;
		
		string strNote = "Please refer to the file \"" + strOriginalFileName + "\" if the \"Original\" column value of any row is \"no\".It means the barcode text of this row has been modified to follow regular format in this file, and the corresponding original text was saved in the file whose name was with the suffix of \"original\".";
		strNote = replace_all_distinct(strNote, "\"", "\"\"");
		*(m_pOStream) << "Note:,\"" << strNote << "\"" << endl;
		m_pOStream->flush();
	}
}

void CBarcodeStatisticsRecorder::RecordReaderRunningTrace(RUNNING_TRACE_INFO runningTraceInfo)
{
	ofstream osfile("__br.txt");
	osfile << "LAST_FILE_PATH" << " = " << Base64encodestring(runningTraceInfo.LAST_FILE_PATH) << "\n";
	osfile << "LAST_POS_SIZE" << " = " << runningTraceInfo.LAST_POS_SIZE << "\n";

	osfile << "CURRENT_FILE_PATH" << " = " << Base64encodestring(runningTraceInfo.CURRENT_FILE_PATH) << "\n";
	osfile << "CURRENT_POS_SIZE" << " = " << runningTraceInfo.CURRENT_POS_SIZE << "\n";

	osfile << "OUTPUT_FILE_PATH" << " = " << Base64encodestring(runningTraceInfo.OUTPUT_FILE_PATH) << "\n";
	osfile << "SCAN_DIRECTORY" << " = " << Base64encodestring(runningTraceInfo.SCAN_DIRECTORY) << "\n";

	osfile << "TOTAL_IMAGE_COUNT" << " = " << runningTraceInfo.TOTAL_IMAGE_COUNT << "\n";
	osfile << "IMAGES_WITH_BARCODES_RECOGNIZED" << " = " << runningTraceInfo.IMAGES_WITH_BARCODES_RECOGNIZED << "\n";
	osfile << "TIME_COST_OF_ALL_IMAGES" << " = " << runningTraceInfo.TIME_COST_OF_ALL_IMAGES << "\n";
	osfile << "TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED" << " = " << runningTraceInfo.TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED << "\n";
	osfile << "TOTAL_BARCODE_COUNT" << " = " << runningTraceInfo.TOTAL_BARCODE_COUNT << "\n";
	osfile << "RESUMED_TIMES" << " = " << runningTraceInfo.RESUMED_TIMES << "\n";
	osfile << "DECODE_SETTING_FILE" << " = " << Base64encodestring(runningTraceInfo.DECODE_SETTING_FILE) << "\n";
	osfile << "CURRENT_FILE_STATUE" << " = " << runningTraceInfo.CURRENT_FILE_STATUE<< "\n";
	osfile.flush();
	osfile.close();

}

CBarcodeStatisticsRecorder::RUNNING_TRACE_INFO  CBarcodeStatisticsRecorder::LoadReaderRunningTrace()
{
	string strLastReaderFile;
	ifstream isfile;
	stringstream sstream;
	isfile.open("__br.txt");
	string strline, strKey, strEQTag, strValue;

	RUNNING_TRACE_INFO traceInfo;
	bool bGood = isfile.good();
	while (bGood && !isfile.eof()) {
		getline(isfile, strline);
		sstream.clear();
		sstream.str(strline);
		sstream >> strKey >> strEQTag >> strValue;
		if (sstream.fail())
			continue;
		if (strKey.compare("CURRENT_FILE_PATH") == 0)
		{
			traceInfo.CURRENT_FILE_PATH = rtrim(Base64decodestring(strValue));
		}
		else if (strKey.compare("OUTPUT_FILE_PATH") == 0)
		{
			traceInfo.OUTPUT_FILE_PATH = rtrim(Base64decodestring(strValue));
		}
		else if (strKey.compare("BCODE_READER ") == 0)
		{
			traceInfo.BCODE_READER = strValue;
		}
		else if (strKey.compare("LAST_FILE_PATH") == 0) {
			traceInfo.LAST_FILE_PATH = rtrim(Base64decodestring(strValue));
		}
		else if (strKey.compare("LAST_POS_SIZE") == 0) {
			traceInfo.LAST_POS_SIZE = atoi(strValue.c_str());
		}
		else if (strKey.compare("CURRENT_POS_SIZE") == 0) {
			traceInfo.CURRENT_POS_SIZE = atoi(strValue.c_str());
		}
		else if (strKey.compare("SCAN_DIRECTORY") == 0) {
			traceInfo.SCAN_DIRECTORY = rtrim(Base64decodestring(strValue));
		}
		else if (strKey.compare("TOTAL_IMAGE_COUNT") == 0) {
			traceInfo.TOTAL_IMAGE_COUNT = atoi(strValue.c_str());
		}
		else if (strKey.compare("IMAGES_WITH_BARCODES_RECOGNIZED") == 0) {
			traceInfo.IMAGES_WITH_BARCODES_RECOGNIZED = atoi(strValue.c_str());
		}
		else if (strKey.compare("TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED") == 0) {
			traceInfo.TIME_COST_OF_IMAGES_WITH_BARCODES_RECOGNIZED = atoi(strValue.c_str());
		}
		else if (strKey.compare("TIME_COST_OF_ALL_IMAGES") == 0) {
			traceInfo.TIME_COST_OF_ALL_IMAGES = atoi(strValue.c_str());
		}
		else if (strKey.compare("TOTAL_BARCODE_COUNT") == 0) {
			traceInfo.TOTAL_BARCODE_COUNT = atoi(strValue.c_str());
		}

		else if (strKey.compare("DECODE_SETTING_FILE") == 0) {
			traceInfo.DECODE_SETTING_FILE = rtrim(Base64decodestring(strValue));
		}
		else if (strKey.compare("CURRENT_FILE_STATUE") == 0) {
			traceInfo.CURRENT_FILE_STATUE = rtrim(strValue);
		}
		else if (strKey.compare("RESUMED_TIMES") == 0) {
			traceInfo.RESUMED_TIMES = atoi(strValue.c_str());
		}

	}

	isfile.close();

	return traceInfo;
}

void CBarcodeStatisticsRecorder::RemoveReaderRunningTrace()
{
	remove("__br.txt");
}


string CBarcodeStatisticsRecorder::Base64encodestring(const string &strString)
{
	int nByteSrc = strString.length();
	string pszSource = strString;

	int i = 0;
	for (i; i < nByteSrc; i++)
		if (pszSource[i] < 0 || pszSource[i] > 127)
			throw "can not encode Non-ASCII characters";

	const char *enkey = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
	std::string pszEncode(nByteSrc * 4 / 3 + 4, '\0');
	int nLoop = nByteSrc % 3 == 0 ? nByteSrc : nByteSrc - 3;
	int n = 0;
	for (i = 0; i < nLoop; i += 3)
	{
		pszEncode[n] = enkey[pszSource[i] >> 2];
		pszEncode[n + 1] = enkey[((pszSource[i] & 3) << 4) | ((pszSource[i + 1] & 0xF0) >> 4)];
		pszEncode[n + 2] = enkey[((pszSource[i + 1] & 0x0f) << 2) | ((pszSource[i + 2] & 0xc0) >> 6)];
		pszEncode[n + 3] = enkey[pszSource[i + 2] & 0x3F];
		n += 4;
	}

	switch (nByteSrc % 3)
	{
	case 0:
		pszEncode[n] = '\0';
		break;

	case 1:
		pszEncode[n] = enkey[pszSource[i] >> 2];
		pszEncode[n + 1] = enkey[((pszSource[i] & 3) << 4) | ((0 & 0xf0) >> 4)];
		pszEncode[n + 2] = '=';
		pszEncode[n + 3] = '=';
		pszEncode[n + 4] = '\0';
		break;

	case 2:
		pszEncode[n] = enkey[pszSource[i] >> 2];
		pszEncode[n + 1] = enkey[((pszSource[i] & 3) << 4) | ((pszSource[i + 1] & 0xf0) >> 4)];
		pszEncode[n + 2] = enkey[((pszSource[i + 1] & 0xf) << 2) | ((0 & 0xc0) >> 6)];
		pszEncode[n + 3] = '=';
		pszEncode[n + 4] = '\0';
		break;
	}

	return pszEncode.c_str();
}


string CBarcodeStatisticsRecorder::Base64decodestring(const string &strString)
{
	int nByteSrc = strString.length();
	string pszSource = strString;

	const int dekey[] = {
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		62, // '+'
		-1, -1, -1,
		63, // '/'
		52, 53, 54, 55, 56, 57, 58, 59, 60, 61, // '0'-'9'
		-1, -1, -1, -1, -1, -1, -1,
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
		13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, // 'A'-'Z'
		-1, -1, -1, -1, -1, -1,
		26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38,
		39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, // 'a'-'z'
	};

	if (nByteSrc % 4 != 0)
		throw "bad base64 string";

	string pszDecode(nByteSrc * 3 / 4 + 4, '\0');
	int nLoop = pszSource[nByteSrc - 1] == '=' ? nByteSrc - 4 : nByteSrc;
	int b[4];
	int i = 0, n = 0;
	for (i = 0; i < nLoop; i += 4)
	{
		b[0] = dekey[pszSource[i]];        b[1] = dekey[pszSource[i + 1]];
		b[2] = dekey[pszSource[i + 2]];    b[3] = dekey[pszSource[i + 3]];
		if (b[0] == -1 || b[1] == -1 || b[2] == -1 || b[3] == -1)
			throw "bad base64 string";

		pszDecode[n] = (b[0] << 2) | ((b[1] & 0x30) >> 4);
		pszDecode[n + 1] = ((b[1] & 0xf) << 4) | ((b[2] & 0x3c) >> 2);
		pszDecode[n + 2] = ((b[2] & 0x3) << 6) | b[3];

		n += 3;
	}

	if (pszSource[nByteSrc - 1] == '=' && pszSource[nByteSrc - 2] == '=')
	{
		b[0] = dekey[pszSource[i]];        b[1] = dekey[pszSource[i + 1]];
		if (b[0] == -1 || b[1] == -1)
			throw "bad base64 string";

		pszDecode[n] = (b[0] << 2) | ((b[1] & 0x30) >> 4);
		pszDecode[n + 1] = '\0';
	}

	if (pszSource[nByteSrc - 1] == '=' && pszSource[nByteSrc - 2] != '=')
	{
		b[0] = dekey[pszSource[i]];        b[1] = dekey[pszSource[i + 1]];
		b[2] = dekey[pszSource[i + 2]];
		if (b[0] == -1 || b[1] == -1 || b[2] == -1)
			throw "bad base64 string";

		pszDecode[n] = (b[0] << 2) | ((b[1] & 0x30) >> 4);
		pszDecode[n + 1] = ((b[1] & 0xf) << 4) | ((b[2] & 0x3c) >> 2);
		pszDecode[n + 2] = '\0';
	}

	if (pszSource[nByteSrc - 1] != '=' && pszSource[nByteSrc - 2] != '=')
		pszDecode[n] = '\0';

	return pszDecode.c_str();
}
