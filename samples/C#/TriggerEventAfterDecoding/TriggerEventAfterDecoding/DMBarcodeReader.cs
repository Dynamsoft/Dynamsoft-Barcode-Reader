using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dynamsoft.Barcode;

namespace TriggerEventAfterDecoding
{
    public delegate void OnBarcdeRecognizedHandler(TextResult[] result);

    class DMBarcodeReader
    {
        private BarcodeReader mBarcodeRader;
        public event OnBarcdeRecognizedHandler OnBarcodeRecognized;

        public DMBarcodeReader(string license)
        {
            mBarcodeRader = new BarcodeReader();
            mBarcodeRader.ProductKeys = license;
        }

        public void DecodeFile(string file)
        {
            string strErrorMSG = "";
            //Best coverage settings
            mBarcodeRader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestCoverage\",\"DeblurLevel\":9,\"ExpectedBarcodesCount\":512,\"ScaleDownThreshold\":100000,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_SCAN_DIRECTLY\"},{\"Mode\":\"LM_STATISTICS\"},{\"Mode\":\"LM_LINES\"},{\"Mode\":\"LM_STATISTICS_MARKS\"}],\"GrayscaleTransformationModes\":[{\"Mode\":\"GTM_ORIGINAL\"},{\"Mode\":\"GTM_INVERTED\"}]}}", EnumConflictMode.CM_OVERWRITE, out strErrorMSG);
            //Best speed settings
            //mBarcodeRader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"BestSpeed\",\"DeblurLevel\":3,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_SCAN_DIRECTLY\"}],\"TextFilterModes\":[{\"MinImageDimension\":262144,\"Mode\":\"TFM_GENERAL_CONTOUR\"}]}}", EnumConflictMode.CM_OVERWRITE, out strErrorMSG);
            //Balance settings
            //mBarcodeRader.InitRuntimeSettingsWithString("{\"ImageParameter\":{\"Name\":\"Balance\",\"DeblurLevel\":5,\"ExpectedBarcodesCount\":512,\"LocalizationModes\":[{\"Mode\":\"LM_CONNECTED_BLOCKS\"},{\"Mode\":\"LM_STATISTICS\"}]}}", EnumConflictMode.CM_OVERWRITE, out strErrorMSG);


            TextResult[] tempResult = mBarcodeRader.DecodeFile(file, "");
            if (tempResult != null && tempResult.Length > 0)
            {
                if (OnBarcodeRecognized != null)
                {
                    OnBarcodeRecognized(tempResult);
                }
            }
        }
    }
}
