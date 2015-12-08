package com.dynamsoft.barcode;

import java.util.Date;
import java.io.*;

public final class CommandLineRunner {

	private CommandLineRunner() {
	}

	private static long GetFormat(int iIndex) {
		long lFormat = 0;

		switch (iIndex) {
		case 1:
			lFormat = EnumBarCode.OneD | EnumBarCode.QR_CODE
					| EnumBarCode.PDF417 | EnumBarCode.DATAMATRIX;
			break;
		case 2:
			lFormat = EnumBarCode.OneD;
			break;
		case 3:
			lFormat = EnumBarCode.QR_CODE;
			break;
		case 4:
			lFormat = EnumBarCode.CODE_39;
			break;
		case 5:
			lFormat = EnumBarCode.CODE_128;
			break;
		case 6:
			lFormat = EnumBarCode.CODE_93;
			break;
		case 7:
			lFormat = EnumBarCode.CODABAR;
			break;
		case 8:
			lFormat = EnumBarCode.ITF;
			break;
		case 9:
			lFormat = EnumBarCode.INDUSTRIAL_25;
			break;
		case 10:
			lFormat = EnumBarCode.EAN_13;
			break;
		case 11:
			lFormat = EnumBarCode.EAN_8;
			break;
		case 12:
			lFormat = EnumBarCode.UPC_A;
			break;
		case 13:
			lFormat = EnumBarCode.UPC_E;
			break;
		case 14:
			lFormat = EnumBarCode.PDF417;
			break;
		case 15:
			lFormat = EnumBarCode.DATAMATRIX;
			break;
		default:
			break;
		}

		return lFormat;
	}

	public static void main(String[] args) throws Exception {

		int iMaxCount = 0;
		long lFormat = -1;
		int iIndex = 0;
		String pszImageFile = null;
		String strLine;
		boolean bExitFlag = false;

		System.out.println("*************************************************");
		System.out.println("Welcome to Dynamsoft Barcode Reader Demo");
		System.out.println("*************************************************");
		System.out
				.println("Hints: Please input 'Q'or 'q' to quit the application.");

		BufferedReader cin = new BufferedReader(new java.io.InputStreamReader(
				System.in));

		while (true) {
			iMaxCount = 0x7FFFFFFF;
			lFormat = (EnumBarCode.OneD | EnumBarCode.QR_CODE
					| EnumBarCode.PDF417 | EnumBarCode.DATAMATRIX);

			while (true) {
				System.out.println();
				System.out
						.println(">> Step 1: Input your image file's full path:");
				strLine = cin.readLine();
				if (strLine != null && strLine.trim().length() > 0) {
					strLine = strLine.trim();
					if (strLine.equalsIgnoreCase("q")){
						bExitFlag = true;
						break;
					}
						
					if (strLine.length() >= 2 && strLine.charAt(0) == '\"'
							&& strLine.charAt(strLine.length() - 1) == '\"') {
						pszImageFile = strLine.substring(1, strLine.length() - 1);
					} else {
						pszImageFile = strLine;
					}
					
					java.io.File file = new java.io.File(pszImageFile);
					if(file.exists() && file.isFile())
						break;
				}
				
				System.out.println("Please input a valid path.");
			}
			
			if(bExitFlag)
				break;

			while (true) {
				System.out.println();
				System.out
						.println(">> Step 2: Choose a number for the format(s) of your barcode image:");
				System.out.println("   1: All");
				System.out.println("   2: OneD");
				System.out.println("   3: QR Code");
				System.out.println("   4: Code 39");
				System.out.println("   5: Code 128");
				System.out.println("   6: Code 93");
				System.out.println("   7: Codabar");
				System.out.println("   8: Interleaved 2 of 5");
				System.out.println("   9: Industrial 2 of 5");
				System.out.println("   10: EAN-13");
				System.out.println("   11: EAN-8");
				System.out.println("   12: UPC-A");
				System.out.println("   13: UPC-E");
				System.out.println("   14: PDF417");
				System.out.println("   15: DATAMATRIX");

				strLine = cin.readLine();
				if (strLine.length() > 0) {
					try {
						iIndex = Integer.parseInt(strLine);
						lFormat = GetFormat(iIndex);
						if (lFormat != 0)
							break;
					} catch (Exception exp) {
					}
				}

				System.out.println("Please choose a valid number. ");

			}

			while (true) {
				System.out.println();
				System.out
						.println(">> Step 3: Input the maximum number of barcodes to read per page: ");

				strLine = cin.readLine();
				if (strLine.length() > 0) {
					try {
						iMaxCount = Integer.parseInt(strLine);
						if (iMaxCount > 0)
							break;
					} catch (Exception exp) {
					}
				}

				System.out.println("Please re-input the correct number again.");
			}

			System.out.println();
			System.out.println("Barcode Results:");
			System.out.println("----------------------------------------------------------");

			// Set license
			JBarcode.DBR_InitLicense("38B9B94D8B0E2B41DB1CC80A58946567");
			
			// Read barcode
			long ullTimeBegin = new Date().getTime();

			tagBarcodeResultArray paryResults = new tagBarcodeResultArray();

			int iret = JBarcode.DBR_DecodeFile(pszImageFile, iMaxCount,
					lFormat, paryResults);
			if (iret != 0) {
				System.out.println(JBarcode.DBR_GetErrorString(iret));
				continue;
			}

			long ullTimeEnd = new Date().getTime();

			// Output barcode result
			/*
			 * Total barcode(s) found: 2. Total time spent: 0.218 seconds.
			 * 
			 * Barcode 1: Page: 1 Type: CODE_128 Value: Zt=-mL-94 Region: {Left:
			 * 100, Top: 20, Width: 100, Height: 40}
			 * 
			 * Barcode 2: Page: 1 Type: CODE_39 Value: Dynamsoft Region: {Left:
			 * 100, Top: 200, Width: 180, Height: 30}
			 */

			String pszTemp;

			if (paryResults.iBarcodeCount <= 0) {
				pszTemp = String.format(
						"No barcode found. Total time spent: %.3f seconds.",
						((float) (ullTimeEnd - ullTimeBegin) / 1000));
			} else {
				pszTemp = String
						.format("Total barcode(s) found: %d. Total time spent: %.3f seconds.",
								paryResults.iBarcodeCount,
								((float) (ullTimeEnd - ullTimeBegin) / 1000));
			}
			System.out.println(pszTemp);

			for (iIndex = 0; iIndex < paryResults.iBarcodeCount; iIndex++) {
				tagBarcodeResult result = paryResults.ppBarcodes[iIndex];
				pszTemp = String.format("  Barcode %d:", iIndex + 1);
				System.out.println(pszTemp);
				pszTemp = String.format("    Page: %d", result.iPageNum);
				System.out.println(pszTemp);
				pszTemp = String.format("    Type: %s",
						GetFormatStr(result.lFormat));
				System.out.println(pszTemp);

				int barcodeDataLen = result.iBarcodeDataLength;

				byte[] pszTemp1 = new byte[barcodeDataLen];
				for (int x = 0; x < barcodeDataLen; x++) {
					pszTemp1[x] = result.pBarcodeData[x];
				}

				pszTemp = "    Value: " + new String(pszTemp1);
				System.out.println(pszTemp);

				pszTemp = String
						.format("    Region: {Left: %d, Top: %d, Width: %d, Height: %d}",
								result.iLeft, result.iTop, result.iWidth,
								result.iHeight);

				System.out.println(pszTemp);
				System.out.println();
			}

		}
	}

	private static String GetFormatStr(long format) {
		if (format == EnumBarCode.OneD)
			return "OneD";
		if (format == EnumBarCode.CODE_39)
			return "CODE_39";
		if (format == EnumBarCode.CODE_128)
			return "CODE_128";
		if (format == EnumBarCode.CODE_93)
			return "CODE_93";
		if (format == EnumBarCode.CODABAR)
			return "CODABAR";
		if (format == EnumBarCode.ITF)
			return "ITF";
		if (format == EnumBarCode.UPC_A)
			return "UPC_A";
		if (format == EnumBarCode.UPC_E)
			return "UPC_E";
		if (format == EnumBarCode.EAN_13)
			return "EAN_13";
		if (format == EnumBarCode.EAN_8)
			return "EAN_8";
		if (format == EnumBarCode.INDUSTRIAL_25)
			return "INDUSTRIAL_25";
		if (format == EnumBarCode.QR_CODE)
			return "QR_CODE";
		if (format == EnumBarCode.PDF417)
			return "PDF417";
		if (format == EnumBarCode.DATAMATRIX)
			return "DATAMATRIX";

		return "Unknown";
	}
}
