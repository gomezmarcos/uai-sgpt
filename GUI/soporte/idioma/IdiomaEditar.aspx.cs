using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.idioma;
using BE.servicio.idioma;

namespace GUI.idioma
{
    public partial class IdiomaEditar : System.Web.UI.Page
    {
        IdiomaBll bll = new IdiomaBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idiomaId = Int64.Parse(Request.QueryString["id"]);
                Idioma idioma = bll.BuscarPorId(idiomaId);
                txtCultura.Text = idioma.Cultura;
                txtNombre.Text = idioma.Nombre;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            var idiomaId = Int64.Parse(Request.QueryString["id"]);
            Idioma idioma = bll.BuscarPorId(idiomaId);
            idioma.Cultura = txtCultura.Text;
            idioma.Nombre = txtNombre.Text;
            bll.Modificar(idioma);
            Response.Redirect("IdiomaAbm.aspx", true);
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            var idiomaId = Int64.Parse(Request.QueryString["id"]);
            Idioma idioma = bll.BuscarPorId(idiomaId);
            bll.Eliminar(idioma);

            //buscar todas las entradas con fk_idioma = idiomaId y eliminarlas.

            Response.Redirect("IdiomaAbm.aspx", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IdiomaAbm.aspx", true);
        }
    }
}