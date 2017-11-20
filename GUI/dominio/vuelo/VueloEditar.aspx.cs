using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL.dominio;

namespace GUI.dominio.vuelo
{
    public partial class VueloEditar : System.Web.UI.Page
    {
        private VueloBll vueloBll = new VueloBll();
        private DestinoBll destinoBll = new DestinoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            var hotelId = Int64.Parse(Request.QueryString["id"]);
            Vuelo v = vueloBll.BuscarPorId(hotelId);
            if (!IsPostBack)
            {
                txtEmpresa.Text = v.Empresa;
                txtPrecio.Text = v.Precio.ToString();
                txtUid.Text = v.UID;
            }

            IList<Destino> destinos = destinoBll.BuscarTodos();
            foreach (Destino d in destinos)
            {
                ListItem item = new ListItem();
                item.Value = d.Id.ToString();
                item.Text = d.Descripcion;
                if (!IsPostBack && item.Value == v.objOrigen.Id.ToString())
                    item.Selected = true;
                lstDestinoOrigen.Items.Add(item);
            }

            foreach (Destino d in destinos)
            {
                ListItem item = new ListItem();
                item.Value = d.Id.ToString();
                item.Text = d.Descripcion;
                if (!IsPostBack && item.Value == v.objDestino.Id.ToString())
                    item.Selected = true;
                lstDestinoDestino.Items.Add(item);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VueloAbm.aspx", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var hotelId = Int64.Parse(Request.QueryString["id"]);
            Vuelo v = vueloBll.BuscarPorId(hotelId);

            vueloBll.EliminarDestinos(v);

            v.UID = txtUid.Text;
            v.Precio = decimal.Parse(txtPrecio.Text);
            v.Empresa = txtEmpresa.Text;
            v.objOrigen = destinoBll.BuscarPorId(long.Parse(lstDestinoOrigen.SelectedValue));
            v.objDestino = destinoBll.BuscarPorId(long.Parse(lstDestinoDestino.SelectedValue));
            vueloBll.Modificar(v);
            Response.Redirect("VueloAbm.aspx", true);
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            var hotelId = Int64.Parse(Request.QueryString["id"]);
            Vuelo v = vueloBll.BuscarPorId(hotelId);
            vueloBll.EliminarDestinos(v);
            vueloBll.Eliminar(v);
            Response.Redirect("VueloAbm.aspx", true);
        }
    }
}