using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.dominio;
using BE;

namespace GUI.dominio.hotel
{
    public partial class HotelAbm : System.Web.UI.Page
    {
        HotelBll hotelBll = new HotelBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbl.Rows.Clear();
            TableHeaderRow hrow = new TableHeaderRow();
            hrow.Cells.Add( new TableHeaderCell {Text = "Nombre"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Direccion"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha de creacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            tbl.Rows.Add(hrow);

            IList<Hotel> hoteles = hotelBll.BuscarTodos();
            foreach (Hotel h in hoteles)
            {
                TableRow row = new TableRow();
                row.Cells.Add( new TableCell {Text = h.Nombre});
                row.Cells.Add( new TableCell {Text = h.Direccion});
                row.Cells.Add( new TableCell {Text = h.FechaCreacion.ToString()});

                HyperLink l = new HyperLink { 
                    Text = "Editar",
                    NavigateUrl = "hotelEditar?id=" + h.Id
                };
                TableCell tc = new TableCell();
                tc.Controls.Add(l);
                row.Cells.Add( tc);

                tbl.Rows.Add(row);
            }
        }

        protected void btnNuevoHotel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HotelAlta.aspx", true);
        }
    }
}