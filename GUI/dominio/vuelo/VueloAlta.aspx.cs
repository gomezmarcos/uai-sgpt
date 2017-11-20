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
    public partial class VueloAlta : System.Web.UI.Page
    {
        private VueloBll vueloBll = new VueloBll();
        private DestinoBll destinoBll = new DestinoBll();
        protected void Page_Load(object sender, EventArgs e)
        {

            foreach (Destino d in destinoBll.BuscarTodos())
            {
                ListItem item = new ListItem();
                item.Value = d.Id.ToString();
                item.Text = d.Descripcion;
                lstDestinoOrigen.Items.Add(item);
                lstDestinoDestino.Items.Add(item);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Vuelo v = new Vuelo();
            v.UID = txtUid.Text;
            v.Precio = decimal.Parse(txtPrecio.Text);
            v.Empresa = txtEmpresa.Text;
            v.objOrigen = destinoBll.BuscarPorId(long.Parse(lstDestinoOrigen.SelectedValue));
            v.objDestino = destinoBll.BuscarPorId(long.Parse(lstDestinoDestino.SelectedValue));
            vueloBll.Registrar(v);
            Response.Redirect("VueloAbm.aspx", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VueloAbm.aspx", true);
        }
    }
}