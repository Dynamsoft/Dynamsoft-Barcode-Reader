using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using BarcodeDLL;

namespace BarcodeWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            System.Reflection.PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            object o = p.GetValue(null, null);
            System.Reflection.FieldInfo f = o.GetType().GetField("_dirMonSubdirs", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.IgnoreCase);
            object monitor = f.GetValue(o);
            System.Reflection.MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            m.Invoke(monitor, new object[] { }); 
        }

        public const int TIME_OUT = 20;

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["SessionID"] = System.Web.HttpContext.Current.Session.SessionID.ToString();
            try
            {
                //BarcodeMode.DeleteFolder(Session["SessionID"].ToString());
                Session.Timeout = TIME_OUT;
            }
            catch { }
            BarcodeMode.CreateFolder(Session["SessionID"].ToString());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
            BarcodeMode.DeleteFolder(Session["SessionID"].ToString());
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}