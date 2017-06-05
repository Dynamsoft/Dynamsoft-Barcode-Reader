package com.dynamsoft.demo;

import java.util.Date;
import java.io.*;

import com.dynamsoft.barcode.Barcode;
import com.dynamsoft.barcode.BarcodeReader;
import com.dynamsoft.barcode.ReadResult;

public final class BarcodeReaderDemo {
	private BarcodeReaderDemo() {
	}
	
	private static long GetFormat(int iIndex) {
		long lFormat = 0;

		switch (iIndex) {
		case 1:
			lFormat = Barcode.OneD | Barcode.QR_CODE
					| Barcode.PDF417 | Barcode.DATAMATRIX;
			break;
		case 2:
			lFormat = Barcode.OneD;
			break;
		case 3:
			lFormat = Barcode.QR_CODE;
			break;
		case 4:
			lFormat = Barcode.CODE_39;
			break;
		case 5:
			lFormat = Barcode.CODE_128;
			break;
		case 6:
			lFormat = Barcode.CODE_93;
			break;
		case 7:
			lFormat = Barcode.CODABAR;
			break;
		case 8:
			lFormat = Barcode.ITF;
			break;
		case 9:
			lFormat = Barcode.INDUSTRIAL_25;
			break;
		case 10:
			lFormat = Barcode.EAN_13;
			break;
		case 11:
			lFormat = Barcode.EAN_8;
			break;
		case 12:
			lFormat = Barcode.UPC_A;
			break;
		case 13:
			lFormat = Barcode.UPC_E;
			break;
		case 14:
			lFormat = Barcode.PDF417;
			break;
		case 15:
			lFormat = Barcode.DATAMATRIX;
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
			lFormat = (Barcode.OneD | Barcode.QR_CODE
					| Barcode.PDF417 | Barcode.DATAMATRIX);

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
			BarcodeReader br = new BarcodeReader("t0068MgAAABs0soPfOcktn1WIaQwU5tPkLklx8PbtKusKGedkkCTDIQldAxDlOkitjsoOoUHYq9Zxro5YEVTQ7/oqoIcoGzQ=");
			
			// Read barcode
			long ullTimeBegin = new Date().getTime();			
			ReadResult result = br.readFile(pszImageFile, lFormat, iMaxCount);			
			long ullTimeEnd = new Date().getTime();
			
			if (result.errorCode != BarcodeReader.DBR_OK && result.errorCode != BarcodeReader.DBRERR_LICENSE_EXPIRED && result.errorCode != BarcodeReader.DBRERR_LICENSE_INVALID) {
				System.out.println(result.errorString);
				continue;
			}

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

			if (result.barcodes == null || result.barcodes.length == 0) {
				pszTemp = String.format(
						"No barcode found. Total time spent: %.3f seconds.", ((float) (ullTimeEnd - ullTimeBegin) / 1000));
				System.out.println(pszTemp);
			} else {
				pszTemp = String.format("Total barcode(s) found: %d. Total time spent: %.3f seconds.", result.barcodes.length, ((float) (ullTimeEnd - ullTimeBegin) / 1000));
				System.out.println(pszTemp);			

				for (iIndex = 0; iIndex < result.barcodes.length; iIndex++) {
					Barcode barcode = result.barcodes[iIndex];
					
					pszTemp = String.format("  Barcode %d:", iIndex + 1);
					System.out.println(pszTemp);
					pszTemp = String.format("    Page: %d", barcode.pageNumber);
					System.out.println(pszTemp);
					pszTemp = String.format("    Type: %s", barcode.formatString);						
					System.out.println(pszTemp);				
					pszTemp = "    Value: " + barcode.displayValue;
					System.out.println(pszTemp);		
					
					
					pszTemp = String.format("    Region: {Left: %d, Top: %d, Width: %d, Height: %d}",
									barcode.boundingBox.x, barcode.boundingBox.y, barcode.boundingBox.width, barcode.boundingBox.height);
	
					System.out.println(pszTemp);
					System.out.println();
				}
			}
		}
	}
}
