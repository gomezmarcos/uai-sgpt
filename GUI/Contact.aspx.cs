using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BE;

namespace GUI
{
    public partial class Contact : Page
    {
        UsuarioBll usuarioBll = new UsuarioBll();
        HotelBll hotelBll = new HotelBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Hotel> hoteles = hotelBll.BuscarTodos();
            Hotel h = hotelBll.BuscarPorId(2);
            hoteles.Count();
            Label1.Text = h.Nombre;

            
            foreach (var hh in hoteles)
            {
                TableRow t = new TableRow();
                TableCell tCell1 = new TableCell();
                tCell1.Text = hh.Id.ToString();
                t.Cells.Add(tCell1);

                TableCell tCell2 = new TableCell();
                tCell2.Text = hh.Nombre;
                t.Cells.Add(tCell2);

                TableCell tCell3 = new TableCell();
                tCell3.Text = hh.Descripcion;
                t.Cells.Add(tCell3);

                Table1.Rows.Add(t);
            }
            

            string[] answers = new string[10] { "Y", "Y", "N", "Y", "N", "Y", "N", "Y", "N", "Y" };
            rptResults1.DataSource = answers;
            rptResults1.DataBind();

        }
    }
}