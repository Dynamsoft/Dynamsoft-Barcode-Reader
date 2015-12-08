using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BarcodeDLL
{
    public class BarcodeAccess
    {
        private static readonly int MaxSize=1024*1024*5;
        internal static readonly string[] FileExt = { 
                               "bmp","dib",
                               "jpg","jpeg","jpe","jfif",
                               "tif","tiff",
                               "gif",
                               "png",
                               //"pdf",
                               
                                                    };
        public static readonly string[] FileExtMimeType = { 
                               "bmp","image/bmp",
                               "bmp","application/x-MS-bmp",
                               "dib","application/x-dib",
                               "jpg","image/jpeg",
                               "jpg","application/x-jpg",
                               "jpg","image/pjpeg",
                               "jpg","image/jpg",
                               "jpeg","image/jpeg",
                               "jpeg","image/pjpeg",
                               "jpe","image/jpeg",
                               "jpe","application/x-jpe",
                               "jfif","image/jpeg",
                               "jfif","image/pipeg",
                               "tif","image/tiff",
                               "tif","application/x-tif",
                               "tiff","image/tiff",
                               "gif","image/gif",
                               "png","image/png",
                               "png","application/x-png",
                               "pdf","application/pdf",
                               };
        private static char cSep=System.IO.Path.DirectorySeparatorChar;
        private static string StrPath = AppDomain.CurrentDomain.BaseDirectory+"Images";

        public static string UploadFolder = StrPath + cSep + "Upload";
        private static string DemoFolder = StrPath + cSep + "Demo";
        private static string CollectFolder = StrPath + cSep + "Collect";
        private string m_strSessionID;
        private string m_strFileNameTemp;
        private string m_strFileName;
        private string m_strAryFileName;

        public static string GetUploadFolder()
        {
            return UploadFolder;
        }

        public BarcodeAccess(string strSessionID)
        {
            m_strSessionID = strSessionID;
        }

        /// <summary>
        /// only return the name of normal image
        /// </summary>
        /// <param name="imagePath">(....)/xxxx/name</param>
        /// <returns></returns>
        public static string GetNormalImageName(string imagePath)
        {
            string strNormal = imagePath;
            if (imagePath != null)
            {
                int start = imagePath.LastIndexOf("/");
                if (start >= 0)
                    strNormal = imagePath.Substring(start + 1);
            }
            return strNormal;
        }

        /// <summary>
        /// return whole path of temp image
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string GetTempImagePath(string imagePath)
        {
            string strTemp = imagePath;
            if (imagePath != null)
            {
                int start = imagePath.LastIndexOf("/");
                    string strFileName = imagePath.Substring(start + 1);
                    int dotPos = strFileName.LastIndexOf('.');
                    if (dotPos != -1)
                    {
                        string strName = strFileName.Substring(0, dotPos);
                        string strExt = strFileName.Substring(dotPos + 1);
                        strTemp = imagePath.Substring(0, start) + "/" + strName + "_" + strExt + ".jpeg";
                    }
            }
            return strTemp;
        }

        public static string GetNextFileIndex(string strFileExt, string strSessionID)
        {
            if (strFileExt.ToLower() == "tif" || strFileExt.ToLower() == "tiff" || strFileExt.ToLower() == "pdf")
            {
                strFileExt = "jpg";
            }
            DateTime now = DateTime.Now;
            string strFile = now.ToString("yyyyMMdd_HHmmss_")+now.Millisecond+"_"+(new Random().Next()%1000).ToString();
            string strFileName = strFile + "." + strFileExt.ToLower();
            while (File.Exists(UploadFolder + System.IO.Path.DirectorySeparatorChar + strSessionID + System.IO.Path.DirectorySeparatorChar + strFileName))
            {
                strFile = now.ToString("yyyyMMdd_HHmmss_") + now.Millisecond +"_"+ (new Random().Next() % 1000).ToString();
                strFileName = strFile + "." + strFileExt.ToLower();
            }
            return strFileName;
        }

        internal string SaveUploadFile(string strFileExt, byte[] data)
        {
            //bool isPdf = strFileExt.ToLower() == "pdf";
            //if (isPdf)
            //{
            //    return SaveUploadPDFFile(strFileExt, data);
            //}

            string strFileName = GetNextFileIndex(strFileExt, m_strSessionID);
            bool isTif = strFileExt.ToLower() == "tif" || strFileExt.ToLower() == "tiff";
            bool isGif = strFileExt.ToLower() == "gif";

            string strOriginalFileName = strFileName;
            if (isTif)
                strOriginalFileName = strOriginalFileName.Substring(0, strOriginalFileName.LastIndexOf('.')) + ".tiff";

            using (MemoryStream memdata = new MemoryStream(data))
            {
                using (Bitmap map = new Bitmap(memdata))
                {
                    if (isTif || isGif)
                    {
                        string strAryFileName = "";
                        string strFileNameTemp = strFileName;
                        int pages = 0;
                        if (isTif)
                            pages = map.GetFrameCount(FrameDimension.Page);
                        else
                            pages = 1;
                        for (int i = 0; i < pages; i++)
                        {
                            map.SelectActiveFrame(FrameDimension.Page, i);
                            int dotPos = strFileNameTemp.LastIndexOf(".");
                            if (dotPos > 0)
                                strFileNameTemp = strFileNameTemp.Substring(0, dotPos) + "_" + map.Width + "_" + map.Height + strFileNameTemp.Substring(dotPos);
                            if (strAryFileName.Length == 0)
                                strAryFileName = strAryFileName + strFileNameTemp;
                            else
                                strAryFileName = strAryFileName + ":" + strFileNameTemp;
                            Bitmap bitmap = new Bitmap(map);
                            bitmap.Save(UploadFolder + System.IO.Path.DirectorySeparatorChar + m_strSessionID + System.IO.Path.DirectorySeparatorChar + strFileNameTemp, System.Drawing.Imaging.ImageFormat.Png);
                            if (bitmap != null)
                                bitmap.Dispose();
                            strFileNameTemp = (i + 1).ToString() + strFileName;
                        }
                        strFileName = strAryFileName;
                    }
                    else
                    {
                        int dotPos = strFileName.LastIndexOf(".");
                        if (dotPos > 0)
                            strFileName = strFileName.Substring(0, dotPos) + "_" + map.Width + "_" + map.Height + strFileName.Substring(dotPos);
                        map.Save(UploadFolder + System.IO.Path.DirectorySeparatorChar + m_strSessionID + System.IO.Path.DirectorySeparatorChar + strFileName);
                    }
                }
            }
            
            return strFileName;
        }

        internal string SaveLoadeFile(string strFileExt, Bitmap map)
        {
            string strFileName = GetNextFileIndex(strFileExt, m_strSessionID);
            int dotPos = strFileName.LastIndexOf(".");
            if (dotPos > 0)
                strFileName = strFileName.Substring(0, dotPos) + "_" + map.Width + "_" + map.Height + strFileName.Substring(dotPos);

            map.Save(UploadFolder + System.IO.Path.DirectorySeparatorChar + m_strSessionID + System.IO.Path.DirectorySeparatorChar + strFileName, System.Drawing.Imaging.ImageFormat.Png);

            return strFileName;
        }

        internal string FetchImageFromURL(string strImgURL)
        {
           HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(strImgURL);
           string strFileName = "";
           using (WebResponse response = req.GetResponse())
           {
               if(response.ContentLength> BarcodeAccess.MaxSize)
               {
                   throw new BarcodeException(" Picture size is too big. Max size: 5MB.");
               }
               using (BufferedStream reader=new BufferedStream( response.GetResponseStream()))
               {
                   byte[] data = new byte[response.ContentLength];
                   int index = 0;
                   while (index < response.ContentLength)
                   {
                       index += reader.Read(data, index, (int)response.ContentLength - index);
                   }
                   int nLen= FileExtMimeType.Length;
                   string strContentType=response.ContentType;
                   string strExt = "";
                   for (int i = 1; i <nLen; i+=2)
                   {
                       if (FileExtMimeType[i] == strContentType)
                       {
                           strExt = FileExtMimeType[i - 1];
                           break;
                       }
                   }
                   if (strExt == "")
                       throw new BarcodeException("URL is invalid image.");

                   return SaveUploadFile(strExt, data);
               }
           }
           return strFileName;
        }

        internal static string GetImgPathByName(string strImgID, string strSessionID)
        {
             return UploadFolder + System.IO.Path.DirectorySeparatorChar + strSessionID + System.IO.Path.DirectorySeparatorChar + strImgID;
        }


        internal static void DeleteTempFiles(string strPath)
        {
            try
            {
                string[] aryFiles = System.IO.Directory.GetFiles(strPath);
                foreach (string strFileName in aryFiles)
                {
                    try
                    {
                        int index = strFileName.LastIndexOf("\\");
                        if (index > 0)
                        {
                            string strFileNameTemp = strFileName.Substring(index + 1, strFileName.Length - index - 1);
                            if (strFileNameTemp.StartsWith("Demo_") == false)
                            {
                                File.Delete(strFileName);
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }

        internal static void DeleteFolder(string strSessionID)
        {
            try
            {
                string strFullPath = BarcodeAccess.GetUploadFolder() + System.IO.Path.DirectorySeparatorChar + strSessionID;

                if (Directory.Exists(strFullPath))
                {
                    try
                    {
                        DeleteTempFiles(strFullPath);
                    }
                    catch { }
                    Directory.Delete(strFullPath);
                }
            }
            catch { }
        }

        internal static void CreateFolder(string strSessionID)
        {
            string strDir = BarcodeAccess.GetUploadFolder() + System.IO.Path.DirectorySeparatorChar + strSessionID;
            if (!Directory.Exists(strDir))
            {
                Directory.CreateDirectory(strDir);
            }
        }
    }
}
