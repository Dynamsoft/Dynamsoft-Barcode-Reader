using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeDLL;
using System.Text;
using System.Drawing;

namespace BarcodeWeb
{
    public partial class  Ajaxfunctions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Request.Form["DW_AjaxMethod"] != null)
			{
                String strMethod = this.Request.Form["DW_AjaxMethod"];
                if (strMethod == "DoBarcode")
                {
                    string strReturnValue = "";

                    string strImgID = Ajaxfunctions.DecodeValueInXml(this.Request.Form["FileName"]);
                    //translate strTemp image to normal image
                    strImgID = BarcodeAccess.GetNormalImageName(strImgID);

                    string strFormat = Ajaxfunctions.DecodeValueInXml(this.Request.Form["BarcodeFormat"]);
                    string strMaxNumbers = Ajaxfunctions.DecodeValueInXml(this.Request.Form["MaxNumbers"]);

                    
                    string strSessionID = Ajaxfunctions.DecodeValueInXml(this.Request.Form["SessionID"]);
                    Int64 iFormat = Convert.ToInt64(strFormat);
                    int iMaxNumbers = Convert.ToInt32(strMaxNumbers);
                    strReturnValue = this.DoBarcodeInner(strImgID, iFormat, iMaxNumbers, strSessionID);
                    Response.Write(strReturnValue);
                }
                else if (strMethod == "Interval")
                {
                }
            }
            else
            {
                Response.Write("Error.");
            }
        }

        private string DoBarcodeInner(string strImgID, Int64 iFormat, int iMaxNumbers, string strSessionID)
        {
            string strReturnValue = "";
            string strResult = "";
            try
            {
                string strBarcodeInfo = BarcodeMode.Barcode(strImgID, iFormat, iMaxNumbers, strSessionID, ref strResult);
                strReturnValue = "OK;" + strBarcodeInfo + ";" + strResult;
            }

            catch (Exception exp)
            {
                strReturnValue = "EXP;" + exp.Message.ToString() + ";" + strResult;
            }
            finally
            {

            }
            return strReturnValue;
        }

        public static string DecodeValueInXml(string sourceString)
        {
            if (sourceString == null || sourceString == "")
            {
                return "";
            }

            string src = sourceString.Replace(" ", "+");

            return Encoding.UTF8.GetString(Convert.FromBase64String(src));
        }
    }
}
