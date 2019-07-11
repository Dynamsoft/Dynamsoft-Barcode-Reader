using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Dynamsoft.Barcode;

namespace DecodeMultiBarcodes
{
    class Program
    {

        private static TextResult[] DecodeFile(BarcodeReader _br, string strImagePath)
        {
            //modifiy the default template and decode file.
            PublicRuntimeSettings settings = _br.GetRuntimeSettings();
            //set excepted barcode count.
            settings.ExpectedBarcodesCount = 0x7ffffff;
            _br.UpdateRuntimeSettings(settings);
            TextResult[] result = _br.DecodeFile(strImagePath, "");
            return result;
        }

        private static string GeneratorOutputTextResult(TextResult[] result)
        {
            string builder = null;
            builder += "\r\nBarcode Results:\r\n----------------------------------------------------------\r\n";
            if (result == null)
            {
                string outputInfo = "Total barcode(s) found: 0.\r\n\r\n";
                builder += outputInfo;
            }
            else
            {
                string outputInfo = "Total barcode(s) found: " + result.Length + ".\r\n\r\n";
                builder += outputInfo;
                for (int iIndex = 0; iIndex < result.Length; iIndex++)
                {

                    int iBarcodeIndex = iIndex + 1;
                    builder += "Barcode " + iBarcodeIndex.ToString() + ":\r\n";
                    builder += "    Type: " + result[iIndex].BarcodeFormat.ToString() + "\r\n";
                    builder += "    Value: " + result[iIndex].BarcodeText + "\r\n";
                    builder += "    Hex Data: " + ToHexString(result[iIndex].BarcodeBytes) + "\r\n";
                }
            }
            return builder.ToString();
        }

        private static bool GetImagePath(ref string strImagePath)
        {
            while (true)
            {
                Console.WriteLine("\r\n>> Step 1: Input your image file's full path:\r\n");
                string tempInput = Console.ReadLine();
                if (tempInput.Length > 0)
                {
                    if (tempInput == "q" || tempInput == "Q")
                    {
                        strImagePath = null;
                        return true;
                    }
                }
                strImagePath = tempInput.Replace("\\", "\\\\");
                bool bIfFileExists = File.Exists(strImagePath);
                if (!bIfFileExists)
                {
                    Console.WriteLine("Please input a valid path.\r\n");
                }
                return false;
            }
        }

        private static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;

            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2") + " ");
                }

                hexString = strB.ToString();

            }

            return hexString;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("*************************************************\r\n");
            Console.WriteLine("Welcome to Dynamsoft Barcode Reader Demo\r\n");
            Console.WriteLine("*************************************************\r\n");
            Console.WriteLine("Hints: Please input 'Q'or 'q' to quit the application.\r\n");
            bool bExitFlag = false;
            BarcodeReader _br = new BarcodeReader();
            _br.ProductKeys = "t0068MgAAAGULjuE8kaXvjroaEl2wrJH8t74pon1WyqsBoFiChDCds9YW4U2y3bNdGu/n04/lbzbhkXIH635/POaNi2SG5aE=";
            while (true)
            {
                string strImagePath = null;
                bExitFlag = GetImagePath(ref strImagePath);
                if (bExitFlag)
                    break;
                TextResult[] result = DecodeFile(_br, strImagePath);
                string textResult = GeneratorOutputTextResult(result);
                Console.WriteLine(textResult);
            }
        }
    }
}
