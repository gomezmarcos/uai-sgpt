using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.autorizacion;
using BE.servicio.autorizacion;

namespace GUI
{
    public partial class PatenteAbm : System.Web.UI.Page
    {
        AutorizacionBll bll = new AutorizacionBll();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            tbl.Rows.Clear();
            TableHeaderRow hrow = new TableHeaderRow();
            hrow.Cells.Add( new TableHeaderCell {Text = "Codigo"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Descripcion"});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            tbl.Rows.Add(hrow);

            IList<Patente> patentesTabla = bll.BuscarPatentesRama();
            foreach (Patente p in patentesTabla)
            {
                TableRow row = new TableRow();
                row.Cells.Add( new TableCell {Text = p.Codigo});
                row.Cells.Add( new TableCell {Text = p.Descripcion});

                HyperLink l = new HyperLink { 
                    Text = "Editar",
                    NavigateUrl = "patenteEditar?id=" + p.Id
                };
                TableCell tc = new TableCell();
                tc.Controls.Add(l);
                row.Cells.Add( tc);

                tbl.Rows.Add(row);
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("PatenteAlta.aspx", true);
        }
    }
}