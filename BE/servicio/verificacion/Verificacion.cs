using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.servicio.verificacion
{
    public class Verificacion : IBusinessEntity
    {
        public String Entidad { get; set; }
        public String Hash { get; set; }
    }
}
