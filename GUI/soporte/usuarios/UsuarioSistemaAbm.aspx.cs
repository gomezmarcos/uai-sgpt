using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace GUI.soporte.usuarios
{
    public partial class UsuarioSistemaAbm : System.Web.UI.Page
    {
        UsuarioBll usuarioBll = new UsuarioBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbl.Rows.Clear();
            TableHeaderRow hrow = new TableHeaderRow();
            hrow.Cells.Add( new TableHeaderCell {Text = "Alias"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Area"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha de creacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Email"});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            tbl.Rows.Add(hrow);

            IList<Usuario> patentesTabla = usuarioBll.BuscarTodos();
            foreach (Usuario p in patentesTabla)
            {
                TableRow row = new TableRow();
                row.Cells.Add( new TableCell {Text = p.Alias});
                row.Cells.Add( new TableCell {Text = p.Area});
                row.Cells.Add( new TableCell {Text = p.FechaCreacion.ToString()});
                row.Cells.Add( new TableCell {Text = p.Email});

                HyperLink l = new HyperLink { 
                    Text = "Editar",
                    NavigateUrl = "usuarioSistemaEditar?id=" + p.Id
                };
                TableCell tc = new TableCell();
                tc.Controls.Add(l);
                row.Cells.Add( tc);

                tbl.Rows.Add(row);
            }

        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioSistemaAlta.aspx", true);

        }
    }
}