using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.backup;
using System.IO;
using BE;
using System.Web;
using System.Data;

namespace DAL.servicio.backup
{
    public class BackupDal 
    {
        private IList<Backup> ObtenerBackups()
        {
            return null;
        }

        public IList<Backup> BuscarBasesDeDatos()
        {
            IList<Backup> resultado = new List<Backup>();
            SqlHelper Helper = new SqlHelper();
            System.Data.DataTable dt = Helper.Retrieve("select * from sys.databases", null);
            foreach (DataRow row in dt.Rows)
            {
                Backup b = new Backup();
                b.Nombre = (string)row["name"];
                b.BaseDatosId = (int)row["database_id"];
                resultado.Add(b);
            }
            return resultado;
        }

        public void RestaurarBackup(Backup b)
        {
            SqlHelper Helper = new SqlHelper();
            Helper.Update("USE MASTER; RESTORE DATABASE " + b.BaseDatos + " FROM DISK = '" + b.Nombre + "'" + " WITH REPLACE", null);
        }

        public void CrearBackup(Backup b)
        {
            SqlHelper Helper = new SqlHelper();
            Helper.Update("BACKUP DATABASE " + b.Nombre + " TO DISK = '" + b.Archivo + "' WITH NOFORMAT, NOINIT, NAME ='" + b.Nombre + " - Full Database Backup',SKIP, NOREWIND, NOUNLOAD, STATS = 10", null);
        }
    }
}
