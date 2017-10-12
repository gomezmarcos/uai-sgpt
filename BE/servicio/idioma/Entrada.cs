using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.servicio.idioma
{
    public class Entrada : IBusinessEntity
    {
        public string Clave { get; set; }
        public string Valor { get; set; }
    }
}
