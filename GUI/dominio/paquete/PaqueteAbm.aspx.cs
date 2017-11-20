using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.dominio;
using BE;

namespace GUI.dominio.paquete
{
    public partial class PaqueteAbm : System.Web.UI.Page
    {
        private PaqueteBll paqueteBll = new PaqueteBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbl.Rows.Clear();
            TableHeaderRow hrow = new TableHeaderRow();
            hrow.Cells.Add( new TableHeaderCell {Text = "Titulo"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Descripcion"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Precio"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Destinos"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha Creacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha Actualizacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            tbl.Rows.Add(hrow);

            IList<Paquete> vuelos = paqueteBll.BuscarTodos();
            foreach (Paquete p in vuelos)
            {
                TableRow row = new TableRow();
                row.Cells.Add( new TableCell {Text = p.Titulo});
                row.Cells.Add( new TableCell {Text = p.Descripcion});
                row.Cells.Add( new TableCell {Text = p.Precio.ToString()});
                String DestinosFormateados = "";
                foreach (Destino d in paqueteBll.BuscarDestinosPorId(p.Id))
                    DestinosFormateados += d.Codigo + "-";
                row.Cells.Add( new TableCell {Text = DestinosFormateados});
                row.Cells.Add( new TableCell {Text = p.FechaCreacion.ToString()});
                row.Cells.Add( new TableCell {Text = p.FechaActualizacion.ToString()});

                HyperLink l = new HyperLink { 
                    Text = "Editar",
                    NavigateUrl = "paqueteEditar?id=" + p.Id
                };
                TableCell tc = new TableCell();
                tc.Controls.Add(l);
                row.Cells.Add( tc);

                tbl.Rows.Add(row);
            }
        }

        protected void btnNuevoPaquete_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaqueteAlta.aspx", true);
        }
    }
}