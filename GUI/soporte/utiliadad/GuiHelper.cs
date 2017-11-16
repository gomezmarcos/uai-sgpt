using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BE.servicio.idioma;
using System.Web.UI.WebControls;

namespace GUI.utiliadad
{
    public class GuiHelper
    {
        public static void TraducirPagina(Page pagina, Idioma idioma)
        {
            List<Label> labels = new List<Label>();
            ObtenerTodosLosGuiControles<Label>(pagina.Controls, labels);
            foreach (var cc in labels)
            {
                ((Label)cc).Text = idioma.Traducir(cc.ID);
            }

            /*
            List<DropDownList> drops = new List<DropDownList>();
            ObtenerTodosLosGuiControles<DropDownList>(pagina.Controls, drops);
            foreach (DropDownList cc in drops)
            {
                foreach (ListItem i in cc.Items)
                    i.Text = idioma.Traducir(i.Text);
            }
            */
        }

        private static void ObtenerTodosLosGuiControles<T>(ControlCollection controles, List<T> resultado) where T : System.Web.UI.Control
        {
            foreach (System.Web.UI.Control control in controles)
            {
                if (control is T)
                    resultado.Add((T)control);

                if (control.HasControls())
                    ObtenerTodosLosGuiControles(control.Controls, resultado);
            }
        }

    }
}