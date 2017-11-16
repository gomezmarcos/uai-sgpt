using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.idioma;
using BE.servicio.idioma;

namespace GUI.idioma
{
    public partial class IdiomaAbm : System.Web.UI.Page
    {
        IdiomaBll bll = new IdiomaBll();
        protected void Page_Load(object sender, EventArgs e)
        {
                tbl.Rows.Clear();
                TableHeaderRow hrow = new TableHeaderRow();
                hrow.Cells.Add( new TableHeaderCell {Text = "Nombre"});
                hrow.Cells.Add( new TableHeaderCell {Text = "Cultura"});
                hrow.Cells.Add( new TableHeaderCell {Text = ""});
                hrow.Cells.Add( new TableHeaderCell {Text = ""});
                tbl.Rows.Add(hrow);

                IList<Idioma> patentesTabla = bll.BuscarTodos();
                foreach (Idioma p in patentesTabla)
                    tbl.Rows.Add(CrearFila(p));

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Idioma idioma = new Idioma();
            idioma.Cultura = txtCultura.Text;
            idioma.Nombre = txtNombre.Text;
            bll.Registrar(idioma);
            TableRow row = CrearFila(idioma);

            tbl.Rows.Add(row);
        }

        private static TableRow CrearFila(Idioma idioma)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell { Text = idioma.Nombre });
            row.Cells.Add(new TableCell { Text = idioma.Cultura });

            HyperLink linkEditar = new HyperLink
            {
                Text = "Editar",
                NavigateUrl = "idiomaEditar?id=" + idioma.Id
            };
            TableCell tc = new TableCell();
            tc.Controls.Add(linkEditar);
            row.Cells.Add(tc);

            HyperLink linkAdministrar = new HyperLink
            {
                Text = "Administrar",
                NavigateUrl = "entradaEditar?id=" + idioma.Id
            };
            TableCell tc2 = new TableCell();
            tc.Controls.Add(linkAdministrar);
            row.Cells.Add(tc2);
            return row;
        }
    }
}