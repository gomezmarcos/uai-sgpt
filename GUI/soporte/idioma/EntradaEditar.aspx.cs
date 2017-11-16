using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE.servicio.idioma;
using BLL.servicio.idioma;
using GUI.utiliadad;

namespace GUI.idioma
{
    public partial class EntradaEditar : System.Web.UI.Page
    {
        EntradaBll entradaBll = new EntradaBll();

        protected void Page_Load(object sender, EventArgs e)
        {

                tbl.Rows.Clear();
                TableHeaderRow hrow = new TableHeaderRow();
                hrow.Cells.Add( new TableHeaderCell {Text = "Label"});
                hrow.Cells.Add( new TableHeaderCell {Text = "Texto"});
                tbl.Rows.Add(hrow);

                var idiomaId = Int64.Parse(Request.QueryString["id"]);
                IList<Entrada> entradas = entradaBll.BuscarTodos(new Dictionary<String, object>
                {
                    { "fk_idioma", idiomaId }
                }
            );

            foreach (Entrada p in entradas)
                tbl.Rows.Add(CrearFila(p));

        }

        private static TableRow CrearFila(Entrada entrada)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell { Text = entrada.Clave });
            TableCell tc = new TableCell();
            TextBox tb = new TextBox
            {
                ID = entrada.Clave,
                Text = entrada.Valor
            };
            tc.Controls.Add(tb);
            row.Cells.Add(tc);
            return row;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IdiomaAbm.aspx", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            var idiomaId = Int64.Parse(Request.QueryString["id"]);
            List<TextBox> texts = new List<TextBox>();
            ObtenerTodosLosGuiControles<TextBox>(this.Controls, texts);
            foreach (TextBox text in texts)
            {
                Dictionary<string, object> map = new Dictionary<String, object>();
                map.Add("fk_idioma", idiomaId);
                map.Add("clave", text.ID);

                Entrada entrada = entradaBll.BuscarTodos(map)[0];
                entrada.Valor = text.Text;

                entradaBll.Modificar(entrada);
            }
            Response.Redirect("IdiomaAbm.aspx", true);
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