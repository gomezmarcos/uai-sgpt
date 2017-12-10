using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace GUI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            string sms = ex.InnerException.Message.Replace("\"", "\'");
            sms = sms.Replace("\r\n", " ");

            if(Session["usuario"] == null)
            {
                Response.Redirect("~/soporte/error/FatalRedirectError?ex=" + sms );
            } else
            {
                Response.Redirect("~/soporte/error/DefaultRedirectError?ex=" + sms);
            }
        }
    }
}