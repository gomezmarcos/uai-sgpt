using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.idioma;
using GUI.utiliadad;
using BE.servicio.idioma;
using BE;

namespace GUI
{
    public partial class SiteMaster : MasterPage
    {
        IdiomaBll idiomaBll = new IdiomaBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string cultura = Session["cultura"] == null ? "ES-AR" : (string) Session["cultura"];
            Usuario u = new Usuario();
            u.Id = 1;
            Idioma idioma = idiomaBll.ObtenerPorUsuario(u);
            GuiHelper.TraducirPagina(this.Page, idioma);
        }
    }
}