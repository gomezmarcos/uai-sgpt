using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.dominio;
using BE;

namespace GUI.dominio.cliente
{
    public partial class ResenaAbm : System.Web.UI.Page
    {
        HotelBll hotelBll = new HotelBll();
        ResenaBll resenaBll = new ResenaBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (Hotel h in hotelBll.BuscarTodos())
                {
                    lstHotel.Items.Add(new ListItem()
                    {
                        Value = h.Id.ToString(),
                        Text = h.Nombre + " - " + h.Direccion
                    });
                }
                for (int i = 1; i < 6; i++)
                {
                    ListItem item = new ListItem()
                    {
                        Text = i + " Estrella",
                        Value = i.ToString()
                    };
                    lstLimpieza.Items.Add(item);
                    lstUbicacion.Items.Add(item);
                    lstPrecio.Items.Add(item);
                    lstAtencion.Items.Add(item);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", true);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Resena resena = new Resena();
            resena.objUsuario = (Usuario) Session["usuario"];
            resena.objHotel = hotelBll.BuscarPorId(Int32.Parse(lstHotel.SelectedValue));
            resena.Atencion = Int32.Parse(lstAtencion.SelectedValue);
            resena.Limpieza = Int32.Parse(lstLimpieza.SelectedValue);
            resena.Ubicacion = Int32.Parse(lstUbicacion.SelectedValue);
            resena.Precio = Int32.Parse(lstPrecio.SelectedValue);
            resena.descripcion = Descripcion.Text;
            resenaBll.Registrar(resena);
            Response.Redirect("~/Default.aspx", true);
        }
    }
}