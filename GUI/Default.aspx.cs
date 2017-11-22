using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.dominio;
using BE;

namespace GUI
{
    public partial class _Default : Page
    {
        private HotelBll bll = new HotelBll();

        public IList<Hotel> hoteles = null;
        public IList<Hotel> tag1 = new List<Hotel>();
        public IList<Hotel> tag2 = new List<Hotel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hoteles = bll.BuscarTodos();
                tag1 = new List<Hotel>();
                tag2 = new List<Hotel>();

                foreach(Hotel h in hoteles)
                    foreach (Tag t in h.tags)
                        if(t.Id == 1)
                        {
                            tag1.Add(h);
                            break;
                        }
                foreach(Hotel h in hoteles)
                    foreach (Tag t in h.tags)
                        if(t.Id == 3)
                        {
                            tag2.Add(h);
                            break;
                        }
            }
            hoteles = hoteles.OrderByDescending(o => o.Puntos).ToList();
            tag1 = tag1.OrderByDescending(o => o.Puntos).ToList();
            tag2 = tag2.OrderByDescending(o => o.Puntos).ToList();
        }

        protected void VerPaquetes_Click(object sender, EventArgs e)
        {
            Response.Redirect("/dominio/cliente/Buscar.aspx", true);
        }
    }
}