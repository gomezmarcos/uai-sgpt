using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.servicio.backup
{
    public class Backup : IBusinessEntity
    {
        public string Nombre { get; set; }
        public int BaseDatosId { get; set; }
        public string BaseDatos { get; set; }
        public string Server { get; set; }
        public string Archivo { get; set; }
    }
}
