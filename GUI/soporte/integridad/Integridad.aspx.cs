using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.verificacion;

namespace GUI.soporte.integridad
{
    public partial class Integridad : System.Web.UI.Page
    {
        private VerificacionBll verificacionBll = new VerificacionBll();
        public string Mensaje = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default"); //como si fuese mi login
        }

        protected void verificar_Click(object sender, EventArgs e)
        {
            Mensaje = verificacionBll.verificarIntegridad();
        }
    }
}