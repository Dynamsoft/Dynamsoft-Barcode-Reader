using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using Dynamsoft.Barcode;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;


namespace BarcodeDLL
{
    public class BarcodeMode
    {
        public static string LoadImage(string strFilePath, string strSessionID)
        {
            string strFileName = "";
            int index = strFilePath.LastIndexOf("\\");
            if(index > 0)
                strFileName = strFilePath.Substring(index, strFilePath.Length - index); ;
            if (strFileName.IndexOf(".") < 0)
                throw new BarcodeException("File not supported.");
            string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
            if (!IfFileExt(strFileExt))
            {
                throw new BarcodeException("Only 'bmp','dib','jpg','jpeg','jpe','jfif','tif','tiff','gif','png', 'pdf' supported.");
            }
            Bitmap objmap = new Bitmap(strFilePath);
            BarcodeAccess barcodeAccess = new BarcodeAccess(strSessionID);
            string strFile = barcodeAccess.SaveLoadeFile(strFileExt, objmap);
            if (objmap != null)
            {
                objmap.Dispose();
            }  
            return strFile;
        }

        public static string UpLoadImage(System.Web.UI.WebControls.FileUpload uploadfileControl, string strSessionID)
        {
            if (!uploadfileControl.HasFile)
            {
                throw new BarcodeException("No file exist.");
            }
            string strFileName = uploadfileControl.FileName;
            if (strFileName.IndexOf(".") < 0)
                throw new BarcodeException("File not supported.");
            string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
            if (!IfFileExt(strFileExt))
            {
                throw new BarcodeException("Only 'bmp','dib','jpg','jpeg','jpe','jfif','tif','tiff','gif','png', 'pdf' supported.");
            }

            BarcodeAccess barcodeAccess = new BarcodeAccess(strSessionID);
            return barcodeAccess.SaveUploadFile(strFileExt, uploadfileControl.FileBytes);
        }

        
        public static bool IfFileExt(string strFileExt)
        {
            foreach (string strFile in BarcodeAccess.FileExt)
            {
                if (strFile == strFileExt)
                    return true;
            }

            return false;
        }
        public static string FetchImageFromURL(string strImgURL,string strSessionID)
        {
            BarcodeAccess barcodeAccess = new BarcodeAccess(strSessionID);
            return barcodeAccess.FetchImageFromURL(strImgURL);
        }

        public static string Barcode(string strImgID, Int64 iformat, int iMaxNumbers, string strSessionID, ref string strResult)
        {
            if (strImgID == null || strImgID.Trim() == "")
                throw new Exception("No barcode exist.");
            return BarcodeMode.DoBarcode(strImgID, iformat, iMaxNumbers, strSessionID, ref strResult);
        }

        public static System.Drawing.Imaging.ImageFormat GetImageFormat(string strImgID)
        {
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Bmp;
            if (strImgID != null)
            {
                string strExtern = strImgID.Substring(strImgID.LastIndexOf('.') + 1).ToLower();
                switch (strExtern)
                {
                    case "bmp": break;
                    case "jpg":
                    case "jpeg":
                    case "jpe": format = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                    case "png": format = System.Drawing.Imaging.ImageFormat.Png; break;
                    case "gif": format = System.Drawing.Imaging.ImageFormat.Gif; break;
                    case "tif":
                    case "tiff": format = System.Drawing.Imaging.ImageFormat.Tiff; break;
                    case "icon":
                    case "ico": format = System.Drawing.Imaging.ImageFormat.Icon; break;
                    default: break;
                }
            }
            return format;
        }

        public static void DeleteFolder(string strSessionID)
        {
            try
            {
                BarcodeAccess.DeleteFolder(strSessionID);
            }
            catch { }
        }

        public static void CreateFolder(string strSessionID)
        {
            try
            {
                BarcodeAccess.CreateFolder(strSessionID);
            }
            catch { }
        }

        #region Private DoBarcode

        private static string DoBarcode(string strImgID, Int64 format, int iMaxNumbers, string strSessionID, ref string strResult)
        {
            strResult = "";
            string strResturn = "[";
            using (Bitmap bitmap = new Bitmap(BarcodeAccess.GetImgPathByName(strImgID, strSessionID)))
            {
                DateTime beginTime = DateTime.Now;

                BarcodeResult[] listResult = BarcodeMode.GetBarcode(bitmap, format, iMaxNumbers, strSessionID);
                DateTime afterTime = DateTime.Now;
                TimeSpan midTime = afterTime - beginTime;
                if (listResult == null || listResult.Length == 0)
                {
                    strResult = "No barcode found. Total time spent: " + midTime.TotalSeconds.ToString("F3") + " seconds.<br/>";
                    return "[]";
                }
                strResult = "Total barcode(s) found: " + listResult.Length + ". <br/>Total time spent: " + midTime.TotalSeconds.ToString("F3") + " seconds.<br/><br/>";
                Bitmap _bitmap = new Bitmap(1,1);
                using (Graphics g = Graphics.FromImage(_bitmap))
                {           
                    float fsize = bitmap.Width / 80f;
                    if (fsize < 12)
                        fsize = 12;
                    using (Font font = new Font("Times New Roman", fsize, FontStyle.Bold))
                    {
                        int i = 1;
                        foreach (BarcodeResult Item in listResult)
                        {
                            strResult = strResult + "&nbsp&nbspBarcode " + i + ":<br/>";
                            strResult = strResult + "&nbsp&nbsp&nbsp&nbspPage: 1" + "<br/>";
                            strResult = strResult + "&nbsp&nbsp&nbsp&nbspType: " + Item.BarcodeFormat + "<br/>";
                            strResult = strResult + "&nbsp&nbsp&nbsp&nbspValue: " + Item.BarcodeText + "<br/>";
                            strResult = strResult + "&nbsp&nbsp&nbsp&nbspRegion: {left: " + Item.ResultPoints[0].X
                                         + ", Top: " + Item.ResultPoints[0].Y
                                         + ", Width: " + Item.BoundingRect.Width
                                         + ", Height: " + Item.BoundingRect.Height + "}<br/><br/>";
                            

                            string text = Item.BarcodeText;
                            if (text != null && text.Length > 0)
                            {
                                string[] texts = text.Split('"');
                                text = "[" + i + "] ";
                                for (int k = 0; k < texts.Length - 1; k++)
                                    text += texts[k] + "&quot;";
                                text += texts[texts.Length - 1];

                                PointF tmp = new PointF(00, 40);
                                if (Item.ResultPoints.Length > 0)
                                {
                                    tmp.X = (float)Item.ResultPoints[0].X;
                                    tmp.Y = (float)Item.ResultPoints[0].Y;
                                }
                                SizeF sizeFT = g.MeasureString(text, font);
                                if (tmp.Y + sizeFT.Height > bitmap.Height)
                                {
                                    tmp.Y = tmp.Y - 30 > 0 ? tmp.Y - 30 : 0;
                                }
                                if (sizeFT.Width + tmp.X > bitmap.Width)
                                {
                                    tmp.X = 0;
                                }

                                strResturn += string.Format("{{\"text\":\"{0}\",\"x\":{1},\"y\":{2},\"width\":{3},\"height\":{4},\"fontsize\":\"{5}\"}},", text, tmp.X, tmp.Y, sizeFT.Width, sizeFT.Height, font.Size);
                            }

                            i++;
                        }
                    }
                }
                strResturn = strResturn.Substring(0, strResturn.Length - 1);
                strResturn += "]";
                return strResturn;
            }
        }

        public static BarcodeResult[] GetBarcode(Bitmap bitmap, Int64 format, int iMaxNumbers, string strSessionID)
        {
            BarcodeReader reader = new BarcodeReader();
            ReaderOptions options = new ReaderOptions();
            options.MaxBarcodesToReadPerPage = iMaxNumbers;// 100;
            options.BarcodeFormats = (BarcodeFormat)format;

            reader.ReaderOptions = options;
            reader.LicenseKeys = "38B9B94D8B0E2B41DB1CC80A58946567";
            return reader.DecodeBitmap(bitmap);

        }

        private static string CreateError(string strImgID, string strErrorMessage, string strSessionID)
        {
            try
            {
                return BarcodeMode.CreateErrorInner(strImgID, strErrorMessage,strSessionID);
            }
            catch (Exception)
            {
                return BarcodeMode.CreateErrorInner(null, strErrorMessage,strSessionID);
            }
        }

        private static string CreateErrorInner(string strImgID, string strErrorMessage,string strSessionID)
        {
            Bitmap _bitmap = BarcodeMode.CreateErrorImg(strImgID, "No barcode found.", strSessionID);
            string strFileName = BarcodeAccess.GetNextFileIndex(strImgID, strSessionID);
            string strFullPath = BarcodeAccess.GetUploadFolder() + System.IO.Path.DirectorySeparatorChar + strSessionID + System.IO.Path.DirectorySeparatorChar + strFileName;

            _bitmap.Save(strFullPath, GetImageFormat(strImgID));
            if (_bitmap != null)
            {
                _bitmap.Dispose();
            }
            return "Images/Upload/" + strSessionID + "/" + strFileName;
        }

        private static Bitmap CreateErrorImg(string strFileName, string strErrorMessagae, string strSessionID)
        {
            Bitmap retValue = null;
            Bitmap temp = null;
            if (strFileName == null || strFileName.Trim() == "")
            {
                retValue = new Bitmap(600, 200);
            }
            else
            {
                temp = new Bitmap(BarcodeAccess.GetImgPathByName(strFileName, strSessionID));
                retValue = new Bitmap(temp.Width, temp.Height);
            }
            using (Graphics g = Graphics.FromImage(retValue))
            {
                if (strFileName == null || strFileName.Trim() == "")
                    g.Clear(Color.Tan);
                if (temp != null)
                {
                    g.DrawImage(temp, new Rectangle(0, 0, temp.Width, temp.Height), 0, 0, temp.Width, temp.Height, GraphicsUnit.Pixel);
                    temp.Dispose();
                }
                using (Font font = new Font("Times New Roman", 12, FontStyle.Bold))
                {
                    g.DrawString(strErrorMessagae, font, Brushes.Red, 2, 2);
                }
            }
            return retValue;
        }

        #endregion
    }
}
