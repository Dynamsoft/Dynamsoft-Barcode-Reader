using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TriggerEventAfterDecoding
{
    class Program
    {
        static void tempDMBarcode_OnBarcodeRecognized(Dynamsoft.Barcode.TextResult[] result)
        {
            Console.WriteLine("\r\nOnBarcodeRecognized is triggered.");
            Console.WriteLine(GeneratorOutputTextResult(result));
        }

        private static string GeneratorOutputTextResult(Dynamsoft.Barcode.TextResult[] result)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("\r\nBarcode Results:\r\n----------------------------------------------------------\r\n");
            if (result == null)
            {
                string outputInfo = "Total barcode(s) found: 0.\r\n\r\n";
                builder.AppendFormat(outputInfo);
            }
            else
            {
                string outputInfo = "Total barcode(s) found: " + result.Length + ".\r\n\r\n";
                builder.AppendFormat(outputInfo);
                for (int iIndex = 0; iIndex < result.Length; iIndex++)
                {
                    builder.AppendFormat(String.Format("Barcode {0}:\r\n", iIndex + 1));
                    builder.AppendFormat(String.Format("    Type: {0}\r\n", result[iIndex].BarcodeFormat.ToString()));
                    builder.AppendFormat(String.Format("    Value: {0}\r\n", result[iIndex].BarcodeText));
                    builder.AppendFormat(String.Format("    Hex Data: {0}\r\n", ToHexString(result[iIndex].BarcodeBytes)));
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
                strImagePath = strImagePath.Replace("\"","");
                bool bIfFileExist = File.Exists(strImagePath);
                if (!bIfFileExist)
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

            string strLicenseKeys = "t0068MgAAAG8tqGMc8U9RyTI1vI/5xuzcYNWKDOdxczgOzaB0WtctPt2yo+7T6HD+jVdT2itiLYtpA1pFpPD4C16BWBDTsMI=";
            DMBarcodeReader tempDMBarcode = new DMBarcodeReader(strLicenseKeys);
            tempDMBarcode.OnBarcodeRecognized += tempDMBarcode_OnBarcodeRecognized;
            while (true)
            {

                string strImagePath = null;
                bExitFlag = GetImagePath(ref strImagePath);
                if (bExitFlag)
                    break;
                tempDMBarcode.DecodeFile(strImagePath);
            }
        }

    }
}
