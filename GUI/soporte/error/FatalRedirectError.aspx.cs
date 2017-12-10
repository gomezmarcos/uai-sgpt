using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.soporte.error
{
    public partial class FatalRedirectError : System.Web.UI.Page
    {
        public string errorMessage = "error !";
        protected void Page_Load(object sender, EventArgs e)
        {
            String exeptionMessage = Request.Params["ex"];
            this.errorMessage = exeptionMessage == null ? "" : exeptionMessage ;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}