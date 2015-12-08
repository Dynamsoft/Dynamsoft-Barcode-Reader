using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeDLL;
using System.Drawing;
using System.IO;

namespace BarcodeWeb
{
    public partial class BarcodePage : System.Web.UI.Page
    {
        public string SessionID = "";
        public int iWidth = 0;
        public int iHeight = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionID = Session["SessionID"].ToString();

            if (!IsPostBack)
            {
                hide_showInputURLImage.Value = "0";
                Initial();
                Image1.Style.Add("border-width","1px");
                hide_ShowType.Value = "0";

            }

        }
        private void Initial()
        {
            string strFilesPath = "";
            string strSelectPath = "";
            string strFilePath = Server.MapPath(".") + "\\Images\\DemoImages\\";
            if (!Directory.Exists(strFilePath))
            {
                int indexSample = Server.MapPath(".").LastIndexOf("Samples");
                if (indexSample > 0)
                    strFilePath = Server.MapPath(".").Substring(0, indexSample-1) + "\\Images\\";
            }
            if (Directory.Exists(strFilePath))
            {
                string[] files = Directory.GetFiles(strFilePath);
                if (files != null && files.Length > 0)
                {
                    bool isFirst = true;
                    for (int i = 0; i < files.Length; i++)
                    {
                        string strFileExt = files[i].Substring(files[i].LastIndexOf('.') + 1).ToLower();
                        if (!BarcodeMode.IfFileExt(strFileExt))
                            continue;
                        if (isFirst)
                        {
                            SetFilesPath(files[i], true, ref strFilesPath);
                            strSelectPath = strFilesPath;
                            isFirst = false;
                        }
                        else
                            SetFilesPath(files[i], false, ref strFilesPath);
                    }
                }
            }

            hide_allImgURL.Value = strFilesPath;
            hide_ImgFileName.Value = strSelectPath;
            hide_index.Value = "0";
        }

        public bool SetFilesPath(string strFilePath, bool bFirst, ref string strFilesPath)
        {
            string strReturnPath = BarcodeMode.LoadImage(strFilePath, SessionID);
            if (strReturnPath != "")
            {
                string strPath = BarcodeAccess.GetUploadFolder() + System.IO.Path.DirectorySeparatorChar + SessionID + System.IO.Path.DirectorySeparatorChar + strReturnPath;
                strPath = strPath.Replace("\\", "/");
                if (bFirst)
                {
                    //return Temp images
                    strFilesPath = BarcodeAccess.GetTempImagePath("Images/Upload/" + SessionID + "/" + strReturnPath);
                }
                else
                {
                    //return Temp images
                    strFilesPath = strFilesPath + BarcodeAccess.GetTempImagePath(":Images/Upload/" + SessionID + "/" + strReturnPath);
                }
                return true;
            }
            return false;
        }

    }
}
