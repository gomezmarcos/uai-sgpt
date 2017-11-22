using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.backup;
using DAL.servicio.backup;
using DAL;
using System.Data;
using BE.servicio.bitacora;

namespace BLL.servicio.backup
{
    public class BackupBll
    {
        private bitacora.Bitacora bitacora = new servicio.bitacora.Bitacora();
        private BackupDal dal = new BackupDal();
        public IList<Backup> BuscarBasesDeDatos()
        {
            return dal.BuscarBasesDeDatos();
        }

        public void CrearBackup(Backup b)
        {
            dal.CrearBackup(b);
            Evento ev = new Evento();
            ev.Autor = "Tecnico";
            ev.Descripcion = "Backup Creado!";
            ev.Modulo = "Backup/Restore";
            bitacora.RegistrarEvento(ev);
        }

        public void RestaurarBackup(Backup b)
        {
            dal.RestaurarBackup(b);
            Evento ev = new Evento();
            ev.Autor = "Tecnico";
            ev.Descripcion = "Backup Restaurado!";
            ev.Modulo = "Backup/Restore";
            bitacora.RegistrarEvento(ev);
        }
    }
}
