using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using BLL.dominio;

namespace GUI.dominio.cliente
{
    public partial class Landing : System.Web.UI.Page
    {

        PaqueteBll paqueteBll = new PaqueteBll();
        HotelBll hotelBll = new HotelBll();

        public Paquete p = new Paquete();

        protected void Page_Load(object sender, EventArgs e)
        {
            var paqueteId = Int64.Parse(Request.QueryString["paqueteId"]);
            p = paqueteBll.BuscarPorId(paqueteId);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}