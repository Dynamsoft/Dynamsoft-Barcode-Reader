using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeDLL;
using System.Drawing;

namespace BarcodeWeb
{
    public partial class UploadMode : System.Web.UI.Page
    {
        public string SessionID = "";
        public string strReturnPath = "";
        public int iWidth = 0;
        public int iHeight = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SessionID = Session["SessionID"].ToString();

                if (hide_State.Value == "1")
                {
                    strReturnPath = BarcodeMode.UpLoadImage(upLoadFile, SessionID);
                }
                else if (hide_State.Value == "2")
                    strReturnPath = BarcodeMode.FetchImageFromURL(txtImgURL.Text.Trim(), SessionID);

                if (strReturnPath != "")
                {
                    Bitmap objImage = null;
                    string strRestult = "";
                    try
                    {
                        string[] strAryPath = strReturnPath.Split(':');
                        string strPath = BarcodeAccess.GetUploadFolder() + System.IO.Path.DirectorySeparatorChar + SessionID + System.IO.Path.DirectorySeparatorChar + strAryPath[0];
                        strPath = strPath.Replace("\\", "/");
                        objImage = new Bitmap(strPath);
                        iWidth = objImage.Width;
                        iHeight = objImage.Height;

                        foreach (string strTemp in strAryPath)
                        {
                            if (strRestult.Length == 0)
                                strRestult = strRestult + BarcodeAccess.GetTempImagePath("Images/Upload/" + SessionID + "/" + strTemp);
                            else
                                strRestult = strRestult + BarcodeAccess.GetTempImagePath(":Images/Upload/" + SessionID + "/" + strTemp);
                        }
                    }
                    catch { }
                    finally
                    {
                        if (objImage != null)
                        {
                            objImage.Dispose();
                        }  
                    }

                    strReturnPath = strRestult;
                }
            }
            catch (BarcodeException exp)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), null, "DoNotShowWaitDDialog(); alert('" + exp.Message + "');", true);
            }
            catch (Exception exp)
            {
                if (hide_State.Value == "1")
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), null, "DoNotShowWaitDDialog(); alert('Error uploading image:" + exp.Message + "');", true);
                else if (hide_State.Value == "2")
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), null, "DoNotShowWaitDDialog(); alert('Error loading image from remote URL.');", true);

            }
            finally
            {
            }
        }
    }
}
