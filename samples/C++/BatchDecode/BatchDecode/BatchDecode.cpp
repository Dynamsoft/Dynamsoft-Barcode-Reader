// BatchDecode.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#if defined(_WIN64) || defined(_WIN32)
#include <conio.h>
#else
#include <limits>
#endif

#include "DbrBarcodeFileReader.h"


void ShowConsole();
void ShowConsoleCmd();

/****
 *The command grammar: (options)  (paramters)   
   -i: set the input the barcode files directory.  -i "D:\images"
   -o: set the output result files directory.  -o "D:\output"
   -l: set the barcode reader library(dll) path
*/
char *stdin_get_str(char *str, int len)
{
     	fgets(str, len, stdin);
     	if(str[strlen(str)-1] == '\n')
         	str[strlen(str)-1] = '\0';
	return str;
}
int main(int argc, char* argv[])
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
			}
			if (str == "-t")
			{
				string strOutputType = argv[i + 1];
				if (strcasecmp(strOutputType.c_str(), "console") ==0)
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

	ShowConsole();
	char szBuffer[256] = { 0 };
	string strGettingMessage = "";
	char ichar=' ', iType=' ';
	size_t iLen;
	while (ichar!='q')
	{
#if defined(_WIN64) || defined(_WIN32)
		ichar = _getche();
#else
		ichar = getchar();
#endif
		if(ichar=='\0')
#if defined(_WIN64) || defined(_WIN32)
			ichar = _getche();
#else
			ichar = getchar();
#endif
		switch (ichar)
		{
		case 'i':
		case 'I':
			std::cout << "\n Please input the barcode files directory:";
			memset(szBuffer, 0, sizeof(szBuffer));
#if defined(_WIN64) || defined(_WIN32)
			strGettingMessage = gets_s(szBuffer, 256);
#else
			std::cin.clear();
            std::cin.ignore( numeric_limits<streamsize>::max(), '\n' );
			std::cin.get(szBuffer, 256);
			strGettingMessage = szBuffer;
#endif
			iLen = strGettingMessage.length();
			if (strGettingMessage[0] == '\"' && strGettingMessage[iLen - 1] == '\"')
				strGettingMessage = strGettingMessage.substr(1, iLen - 2);
			barcodeFileReader->LoadBarcodeFiles(strGettingMessage.c_str());
			break;

		case 'o':
		case 'O':
		{
			barcodeFileReader->SetOutputType(CBarcodeFileReader::OUTPUT_FILE);
			std::cout << "\n Please input the output directory for decoding result:";
			memset(szBuffer, 0, sizeof(szBuffer));
#if defined(_WIN64) || defined(_WIN32)
			strGettingMessage = gets_s(szBuffer, 256);
#else
			std::cin.clear();
            std::cin.ignore( numeric_limits<streamsize>::max(), '\n' );
			std::cin.get(szBuffer, 256);
			strGettingMessage = szBuffer;
#endif
			iLen = strGettingMessage.length();
			if (strGettingMessage[0] == '\"' && strGettingMessage[iLen - 1] == '\"')
				strGettingMessage = strGettingMessage.substr(1, iLen - 2);
			barcodeFileReader->SetOutputFileDir(strGettingMessage.c_str());			
		}
			break;			
			
		case 'r':
		case 'R':
		{
			std::cout << "\n";
			barcodeFileReader->Run();
			std::cout << "Complete!" << std::endl;
#if defined(_WIN64) || defined(_WIN32)
			_getche();
#else
			getchar();
#endif
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
#if defined(_WIN64) || defined(_WIN32)
#else
		std::cin.clear();
        std::cin.ignore( numeric_limits<streamsize>::max(), '\n' );
#endif
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
