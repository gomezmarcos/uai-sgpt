using BE;
using BLL.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;

namespace GUI.dominio.cliente
{
    public partial class ConfirmarCompra : System.Web.UI.Page
    {
        PaqueteBll paqueteBll = new PaqueteBll();
        HotelBll hotelBll = new HotelBll();

        public Paquete p = new Paquete();

        protected void Page_Load(object sender, EventArgs e)
        {
            var paqueteId = Int64.Parse(Request.QueryString["paqueteId"]);
            p = paqueteBll.BuscarPorId(paqueteId);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario) Session["usuario"];
            paqueteBll.Comprar(usuario, p);
            Response.Redirect("Gracias.aspx", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buscar.aspx", true);
        }
    }
}