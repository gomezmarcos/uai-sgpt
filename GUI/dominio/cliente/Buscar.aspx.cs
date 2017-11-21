using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL.dominio;

namespace GUI.dominio
{
    public partial class Cliente : System.Web.UI.Page
    {
        private PaqueteBll paqueteBll = new PaqueteBll();
        public IList<Paquete> paquetes = new List<Paquete>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                paquetes = paqueteBll.BuscarTodos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            paquetes = paqueteBll.BuscarTodosConLike(new Dictionary<String, object>
                {
                    { "titulo", txtBuscar.Text.Trim() }
                }
            );
        }
    }
}