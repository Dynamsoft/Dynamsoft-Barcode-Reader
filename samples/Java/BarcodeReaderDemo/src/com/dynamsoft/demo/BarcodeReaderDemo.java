package com.dynamsoft.demo;

import com.dynamsoft.barcode.*;

import java.io.BufferedReader;
import java.util.Date;

public final class BarcodeReaderDemo {
    private static int barcodeFormatIds;
    private static int barcodeFormatIds_2;
    private BarcodeReaderDemo() {
        barcodeFormatIds = 0;
        barcodeFormatIds_2 = 0;
    }

    private static int GetFormatID(int iIndex) {
        int ret = 0;

        switch (iIndex) {
            case 1:
                barcodeFormatIds = EnumBarcodeFormat.BF_ALL;
                barcodeFormatIds_2 = EnumBarcodeFormat_2.BF2_POSTALCODE;
                break;
            case 2:
                barcodeFormatIds = EnumBarcodeFormat.BF_ONED;
                barcodeFormatIds_2 = 0;
                break;
            case 3:
                barcodeFormatIds = EnumBarcodeFormat.BF_QR_CODE;
                barcodeFormatIds_2 = 0;
                break;
            case 4:
                barcodeFormatIds = EnumBarcodeFormat.BF_CODE_39;
                barcodeFormatIds_2 = 0;
                break;
            case 5:
                barcodeFormatIds = EnumBarcodeFormat.BF_CODE_128;
                barcodeFormatIds_2 = 0;
                break;
            case 6:
                barcodeFormatIds = EnumBarcodeFormat.BF_CODE_93;
                barcodeFormatIds_2 = 0;
                break;
            case 7:
                barcodeFormatIds = EnumBarcodeFormat.BF_CODABAR;
                barcodeFormatIds_2 = 0;
                break;
            case 8:
                barcodeFormatIds = EnumBarcodeFormat.BF_ITF;
                barcodeFormatIds_2 = 0;
                break;
            case 9:
                barcodeFormatIds = EnumBarcodeFormat.BF_INDUSTRIAL_25;
                barcodeFormatIds_2 = 0;
                break;
            case 10:
                barcodeFormatIds = EnumBarcodeFormat.BF_EAN_13;
                barcodeFormatIds_2 = 0;
                break;
            case 11:
                barcodeFormatIds = EnumBarcodeFormat.BF_EAN_8;
                barcodeFormatIds_2 = 0;
                break;
            case 12:
                barcodeFormatIds = EnumBarcodeFormat.BF_UPC_A;
                barcodeFormatIds_2 = 0;
                break;
            case 13:
                barcodeFormatIds = EnumBarcodeFormat.BF_UPC_E;
                barcodeFormatIds_2 = 0;
                break;
            case 14:
                barcodeFormatIds = EnumBarcodeFormat.BF_PDF417;
                barcodeFormatIds_2 = 0;
                break;
            case 15:
                barcodeFormatIds = EnumBarcodeFormat.BF_DATAMATRIX;
                barcodeFormatIds_2 = 0;
                break;
            case 16:
                barcodeFormatIds = EnumBarcodeFormat.BF_AZTEC;
                barcodeFormatIds_2 = 0;
                break;
			case 17:
                barcodeFormatIds = EnumBarcodeFormat.BF_CODE_39_EXTENDED;
                barcodeFormatIds_2 = 0;
                break;
 			case 18:
                barcodeFormatIds = EnumBarcodeFormat.BF_MAXICODE;
                barcodeFormatIds_2 = 0;
                break;
            case 19:
                barcodeFormatIds = EnumBarcodeFormat.BF_GS1_DATABAR;
                barcodeFormatIds_2 = 0;
                break;
			case 20:
                barcodeFormatIds = EnumBarcodeFormat.BF_PATCHCODE;
                barcodeFormatIds_2 = 0;
                break;
			case 21:
                barcodeFormatIds = EnumBarcodeFormat.BF_GS1_COMPOSITE;
                barcodeFormatIds_2 = 0;
                break;
            case 22:
                barcodeFormatIds = 0;
                barcodeFormatIds_2 = EnumBarcodeFormat_2.BF2_POSTALCODE;
                break;
            default:
                ret = -1;
                break;
        }
        return ret;
    }

    public static void main(String[] args) throws Exception {

        int iMaxCount = 0;
        int ret = 0;
        int iIndex = 0;
        String pszImageFile = null;
        String strLine;
        boolean bExitFlag = false;
        System.out.println("*************************************************");
        System.out.println("Welcome to Dynamsoft Barcode Reader Demo");
        System.out.println("*************************************************");
        System.out.println("Hints: Please input 'Q'or 'q' to quit the application.");

        BufferedReader cin = new BufferedReader(new java.io.InputStreamReader(System.in));

        while (true) {
            iMaxCount = 0x7FFFFFFF;

            while (true) {
                System.out.println();
                System.out.println(">> Step 1: Input your image file's full path:");
                strLine = cin.readLine();
                if (strLine != null && strLine.trim().length() > 0) {
                    strLine = strLine.trim();
                    if (strLine.equalsIgnoreCase("q")) {
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
                    if (file.exists() && file.isFile())
                        break;
                }

                System.out.println("Please input a valid path.");
            }

            if (bExitFlag)
                break;

            while (true) {
                System.out.println();
                System.out.println(">> Step 2: Choose a number for the format(s) of your barcode image:");
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
                System.out.println("   16: AZTEC");
                System.out.println("   17: Code 39 Extended");
				System.out.println("   18: Maxicode");
				System.out.println("   19: GS1 Databar");
				System.out.println("   20: PatchCode");
				System.out.println("   21: GS1 Composite");
				System.out.println("   22: Postal Code");
                strLine = cin.readLine();
                if (strLine.length() > 0) {
                    try {
                        iIndex = Integer.parseInt(strLine);
                        ret = GetFormatID(iIndex);
                        if (ret != -1)
                            break;
                    } catch (Exception exp) {
                    }
                }

                System.out.println("Please choose a valid number. ");

            }

            while (true) {
                System.out.println();
                System.out.println(">> Step 3: Input the maximum number of barcodes to read per page: ");

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
            BarcodeReader br = new BarcodeReader("t0068MgAAAFffu0u4uz+J3IjyMm2we78pFnM/vICd/fkUgbP9ZenKUTRTfwjj8xpZ2vZ93iJtqRd75JXqKbiBLPsyfkvY1jE=");
            // Read barcode           
            try {
                long ullTimeBegin = new Date().getTime();

                //Best coverage settings
                br.initRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestCoverage\",\"DeblurLevel\":9,\"ExpectedBarcodesCount\":512,\"ScaleDownThreshold\":100000,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_SCAN_DIRECTLY\"},{\"Mode\":\"LM_STATISTICS\"},{\"Mode\":\"LM_LINES\"},{\"Mode\":\"LM_STATISTICS_MARKS\"}],\"GrayscaleTransformationModes\":[{\"Mode\":\"GTM_ORIGINAL\"},{\"Mode\":\"GTM_INVERTED\"}]}}", EnumConflictMode.CM_OVERWRITE);
                //Best speed settings
                //br.initRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestSpeed\",\"DeblurLevel\":3,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_SCAN_DIRECTLY\"}],\"TextFilterModes\":[{\"MinImageDimension\":262144,\"Mode\":\"TFM_GENERAL_CONTOUR\"}]}}",EnumConflictMode.CM_OVERWRITE);
                //Balance settings
                //br.initRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"Balance\",\"DeblurLevel\":5,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_STATISTICS\"}]}}",EnumConflictMode.CM_OVERWRITE);

                PublicRuntimeSettings runtimeSettings = br.getRuntimeSettings();
                runtimeSettings.expectedBarcodesCount = iMaxCount;
                runtimeSettings.barcodeFormatIds = barcodeFormatIds;
                runtimeSettings.barcodeFormatIds_2 = barcodeFormatIds_2;
                br.updateRuntimeSettings(runtimeSettings);

                TextResult[] results = br.decodeFile(pszImageFile, "");
                long ullTimeEnd = new Date().getTime();
                if (results == null || results.length == 0) {
                    String pszTemp = String.format("No barcode found. Total time spent: %.3f seconds.", ((float) (ullTimeEnd - ullTimeBegin) / 1000));
                    System.out.println(pszTemp);
                } else {
                    String pszTemp = String.format("Total barcode(s) found: %d. Total time spent: %.3f seconds.", results.length, ((float) (ullTimeEnd - ullTimeBegin) / 1000));
                    System.out.println(pszTemp);
                    iIndex = 0;
                    for (TextResult result : results) {
                    	iIndex++;
                        pszTemp = String.format("  Barcode %d:", iIndex);
                        System.out.println(pszTemp);
                        pszTemp = String.format("    Page: %d", result.localizationResult.pageNumber + 1);
                        System.out.println(pszTemp);
                        if(result.barcodeFormat != 0){
                            pszTemp = "    Type: " + result.barcodeFormatString;
                        } else {
                            pszTemp = "    Type: " + result.barcodeFormatString_2;
                        }
                        System.out.println(pszTemp);
                        pszTemp = "    Value: " + result.barcodeText;
                        System.out.println(pszTemp);

                        pszTemp = String.format("    Region points: {(%d,%d),(%d,%d),(%d,%d),(%d,%d)}",
                                result.localizationResult.resultPoints[0].x, result.localizationResult.resultPoints[0].y,
                                result.localizationResult.resultPoints[1].x,result.localizationResult.resultPoints[1].y,
                                result.localizationResult.resultPoints[2].x,result.localizationResult.resultPoints[2].y,
                                result.localizationResult.resultPoints[3].x,result.localizationResult.resultPoints[3].y);

                        System.out.println(pszTemp);
                        System.out.println();
                    }
                }
            } catch (BarcodeReaderException e) {
                e.printStackTrace();
            }

        }
    }
}
