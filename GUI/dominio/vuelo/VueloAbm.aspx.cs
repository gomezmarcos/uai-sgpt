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
    public partial class VueloAbm : System.Web.UI.Page
    {
        private VueloBll vueloBll= new VueloBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            tbl.Rows.Clear();
            TableHeaderRow hrow = new TableHeaderRow();
            hrow.Cells.Add( new TableHeaderCell {Text = "UID"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Empresa"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Origen"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Destino"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Precio"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha Creacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha Actualizacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            tbl.Rows.Add(hrow);

            IList<Vuelo> vuelos = vueloBll.BuscarTodos();
            foreach (Vuelo v in vuelos)
            {
                TableRow row = new TableRow();
                row.Cells.Add( new TableCell {Text = v.UID});
                row.Cells.Add( new TableCell {Text = v.Empresa});
                row.Cells.Add( new TableCell {Text = v.objOrigen.Descripcion});
                row.Cells.Add( new TableCell {Text = v.objDestino.Descripcion});
                row.Cells.Add( new TableCell {Text = v.Precio.ToString()});
                row.Cells.Add( new TableCell {Text = v.FechaCreacion.ToString()});
                row.Cells.Add( new TableCell {Text = v.FechaActualizacion.ToString()});

                HyperLink l = new HyperLink { 
                    Text = "Editar",
                    NavigateUrl = "vueloEditar?id=" + v.Id
                };
                TableCell tc = new TableCell();
                tc.Controls.Add(l);
                row.Cells.Add( tc);

                tbl.Rows.Add(row);
            }

        }

        protected void btnNuevoVuelo_Click(object sender, EventArgs e)
        {
            Response.Redirect("VueloAlta.aspx", true);
        }
    }
}