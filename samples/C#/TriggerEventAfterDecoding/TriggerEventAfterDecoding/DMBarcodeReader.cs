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
