// BatchDecode.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <conio.h>

#include "../../../../../Components/C_C++/Include/DynamsoftBarcodeReader.h"
#include "DbrBarcodeFileReader.h"


void ShowConsole();
void ShowConsoleCmd();

/****
 *The command grammar: (options)  (paramters)   
   -i: set the input the barcode files directory.  -i "D:\images"
   -o: set the output result files directory.  -o "D:\output"
   -l: set the barcode reader library(dll) path
*/
int _tmain(int argc, _TCHAR* argv[])
{

	CDbrBarcodeFileReader *barcodeFileReader = new CDbrBarcodeFileReader();

	if (argc >= 3 && argc%2==1)
	{
		for (int i = 1; i < argc-1; i++)
		{
			string str = argv[i];
			if (str == "-i")
			{
				string strBarcodeDir = argv[i + 1];
				barcodeFileReader->LoadBarcodeFiles(strBarcodeDir.c_str());
			}
			if (str == "-o")
			{
				string strOutputBarcodeDir = argv[i + 1];
				barcodeFileReader->SetOutputFileDir(strOutputBarcodeDir.c_str());
			}
			if (str == "-l")
			{
				string strOutputBarcodeDir = argv[i + 1];
#ifdef USE_LOAD_LIBARAY 
				barcodeFileReader->SetDBRLibaryPath(strOutputBarcodeDir.c_str());
#endif
			}
			if (str == "-t")
			{
				string strOutputType = argv[i + 1];
				if (stricmp(strOutputType.c_str(), "console") ==0)
				{
					barcodeFileReader->SetOutputType(CBarcodeFileReader::OUTPUT_CONSOLE);
				}
				else
				{
					barcodeFileReader->SetOutputType(CBarcodeFileReader::OUTPUT_FILE);
				}
			}
		}
		barcodeFileReader->Run();
		std::cout << "Complete!" << std::endl;
		if (barcodeFileReader != NULL)
		{
			delete barcodeFileReader;
		}
		return 0;
	}

#ifdef USE_LOAD_LIBARAY
	barcodeFileReader->SetDBRLibaryPath("DynamsoftBarcodeReaderx86.dll");
#endif
	ShowConsole();
	char szBuffer[256] = { 0 };
	string strGettingMessage = "";
	char ichar=' ', iType=' ';
	while (ichar!='q')
	{
		ichar = _getche();//need press the enter. getchar():need press the enter
		if(ichar=='\0')
			ichar= _getche();
		switch (ichar) 
		{
		case 'i':
		case 'I':
			std::cout << "\n Please input the barcode files directory:";
			memset(szBuffer, 0, sizeof(szBuffer));
			strGettingMessage = gets_s(szBuffer, 256);
			barcodeFileReader->LoadBarcodeFiles(strGettingMessage.c_str());
			break;

		case 'o':
		case 'O':
		{
			barcodeFileReader->SetOutputType(CBarcodeFileReader::OUTPUT_FILE);
			std::cout << "\n Please input the output directory for decoding result:";
			memset(szBuffer, 0, sizeof(szBuffer));
			strGettingMessage = gets_s(szBuffer, 256);
			barcodeFileReader->SetOutputFileDir(strGettingMessage.c_str());			
		}
			break;			
			
		case 'r':
		case 'R':
		{
			std::cout << "\n";
			barcodeFileReader->Run();
			std::cout << "Complete!" << std::endl;
			_getche();
			memset(szBuffer, 0, sizeof(szBuffer));
		}
			break;
		case 'q':
		case 'Q':
			ichar = 'q';
			break;
		case ' ':
			break;
		default:
		{
			std::cout << "\n The input commands invalid!" << std::endl;			
		}

		}
		ShowConsoleCmd();
	}
	if (barcodeFileReader != NULL)
	{
		delete barcodeFileReader;
	}
	return 0;
}

void ShowConsole()
{
	
	std::cout << "***************************************************************************" << std::endl;
	std::cout << "*****         Dynamsoft Barcode Reader SDK Test Console            ********" << std::endl;
	std::cout << "***************************************************************************" << std::endl;
	std::cout << "*****   I-Input barcode files directory (Default is './')          ********" << std::endl;
	std::cout << "*****   O-Output directory for decoding result (Default is './')   ********" << std::endl;
	std::cout << "*****   R-Run the barcode Reader                                   ********" << std::endl;
	std::cout << "*****   Q-Quit!                                                    ********" << std::endl;
	std::cout << "***************************************************************************" << std::endl;
	
}
void ShowConsoleCmd()
{	
	std::cout << "*   I-Input barcode files directory (Default is './') " << std::endl;
	std::cout << "*   O-Output directory for decoding result (Default is './')  " << std::endl;
	std::cout << "*   R-Run the barcode reader                         " << std::endl;
	std::cout << "*   Q-Quit!                          " << std::endl;

}
