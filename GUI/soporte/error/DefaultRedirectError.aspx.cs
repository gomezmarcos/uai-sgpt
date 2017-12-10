using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class DefaultRedirectError : System.Web.UI.Page
    {
        public string Message = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            String exeptionMessage = Request.Params["ex"];
            this.Message = exeptionMessage == null ? "" : exeptionMessage ;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            ViewState.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/soporte/autenticar/Autenticar");
        }
    }
}