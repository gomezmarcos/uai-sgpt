using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.idioma;
using GUI.utiliadad;
using BE.servicio.idioma;
using BE;

namespace GUI
{
    public partial class SiteMaster : MasterPage
    {
        IdiomaBll idiomaBll = new IdiomaBll();
        EntradaBll entradaBll = new EntradaBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            string cultura = Session["cultura"] == null ? "1" : Session["cultura"].ToString();
            Idioma idioma = idiomaBll.BuscarPorId(Int32.Parse(cultura));

            //buscar los idiomas
            Dictionary<String, object> m = new Dictionary<String, object>();
            m.Add("fk_idioma", cultura);
            IList<Entrada> entradas = entradaBll.BuscarTodos(m);
            idioma.Entradas = entradas;

            GuiHelper.TraducirPagina(this.Page, idioma);

            IList<Idioma> idiomas = idiomaBll.BuscarTodos();
            foreach (Idioma item in idiomas)
            {
                ListItem i = new ListItem(item.Nombre + " " + item.Cultura, item.Id.ToString());
                lstIdiomas.Items.Add(i);
            }
            }
        }

        protected void lstIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedValue = ((DropDownList)sender).SelectedValue;
            Session["cultura"] = selectedValue;
            Idioma idioma = idiomaBll.BuscarPorId(Int32.Parse(selectedValue));
            Dictionary<String, object> m = new Dictionary<String, object>();
            m.Add("fk_idioma", selectedValue);
            IList<Entrada> entradas = entradaBll.BuscarTodos(m);
            idioma.Entradas = entradas;
            GuiHelper.TraducirPagina(this.Page, idioma);
        }
    }
}