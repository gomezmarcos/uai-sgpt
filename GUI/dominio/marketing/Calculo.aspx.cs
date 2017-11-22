using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL.dominio;

namespace GUI.dominio.marketing
{
    public partial class Calculo : System.Web.UI.Page
    {
        private ResenaPonderacionBll bll = new ResenaPonderacionBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResenaPonderacion p = bll.BuscarPorId(1);
                for (int i = 1; i < 11; i++)
                {
                    ListItem item = new ListItem()
                    {
                        Text = i + " Puntos de Ponderacion",
                        Value = i.ToString(),
                        Selected = i == p.Limpieza
                    };
                    lstLimpieza.Items.Add(item);
                }
                for (int i = 1; i < 11; i++)
                {
                    ListItem item = new ListItem()
                    {
                        Text = i + " Puntos de Ponderacion",
                        Value = i.ToString(),
                        Selected = i == p.Ubicacion
                    };
                    lstUbicacion.Items.Add(item);
                }
                for (int i = 1; i < 11; i++)
                {
                    ListItem item = new ListItem()
                    {
                        Text = i + " Puntos de Ponderacion",
                        Value = i.ToString(),
                        Selected = i == p.Precio
                    };
                    lstPrecio.Items.Add(item);
                }
                for (int i = 1; i < 11; i++)
                {
                    ListItem item = new ListItem()
                    {
                        Text = i + " Puntos de Ponderacion",
                        Value = i.ToString(),
                        Selected = i == p.Atencion
                    };
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
            ResenaPonderacion ponderacion = new ResenaPonderacion();
            ponderacion.Id = 1;
            ponderacion.Atencion = Int32.Parse(lstAtencion.SelectedValue);
            ponderacion.Limpieza = Int32.Parse(lstLimpieza.SelectedValue);
            ponderacion.Ubicacion = Int32.Parse(lstUbicacion.SelectedValue);
            ponderacion.Precio = Int32.Parse(lstPrecio.SelectedValue);
            bll.Modificar(ponderacion);

            bll.CalcularRanking(ponderacion);

            Response.Redirect("~/Default.aspx", true);
        }
    }
}