using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.backup;
using BE.servicio.backup;

namespace GUI.soporte.backup
{
    public partial class BackupAbm : System.Web.UI.Page
    {
        private BackupBll backupBll = new BackupBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarArchivos();
                BuscarBasesDeDatos();
            }
        }

        private void BuscarBasesDeDatos()
        {
            IList<BE.servicio.backup.Backup> backups = backupBll.BuscarBasesDeDatos();
            foreach (BE.servicio.backup.Backup b in backups)
            {
                ListItem i = new ListItem();
                i.Value = b.BaseDatosId.ToString();
                i.Text = b.Nombre;
                ddlDatabases.Items.Add(i);
            }
            
        }

        private void BuscarArchivos()
        {
            System.IO.Directory.CreateDirectory(Server.MapPath("~\\data\\bkup\\"));
            IList<string> backups = System.IO.Directory.GetFiles(Server.MapPath("~\\data\\bkup\\"), "*.bak");
            foreach (string b in backups)
            {
                ListItem li = new ListItem();
                li.Text = b.ToString().Split('\\')[9].ToUpper();
                li.Value = b.ToString();
                lstBackupfiles.Items.Add(li);
            }
        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {

            string dbNombre = ddlDatabases.SelectedItem.Text;
            string archivo = dbNombre + Convert.ToString("_")
                + DateTime.Now.Year.ToString() + "_"
                + DateTime.Now.Month.ToString() + "_"
                + DateTime.Now.Day.ToString() + "_"
                + DateTime.Now.Millisecond.ToString() + ".bak";

            Backup b = new Backup();
            b.Nombre = dbNombre;
            b.Archivo = Server.MapPath("~\\data\\bkup\\") + archivo;
            b.Server = "[local./SQLEXPRESS]";

            backupBll.CrearBackup(b);
            Response.Redirect("~/soporte/backup/backupAbm.aspx", true);
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            Backup b = new Backup();
            b.Server = "[local./SQLEXPRESS]";
            b.Nombre = lstBackupfiles.SelectedItem.Value;
            b.BaseDatos = "sgpt";
            backupBll.RestaurarBackup(b);
            Response.Redirect("~/soporte/backup/backupAbm.aspx", true);
        }
    }
}