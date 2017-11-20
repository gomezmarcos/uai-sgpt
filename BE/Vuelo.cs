using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Vuelo : IBusinessEntity
    {
        public string UID { get; set; }
        public string Empresa { get; set; }
        public Destino objDestino { get; set; }
        public Destino objOrigen { get; set; }
        public decimal Precio { get; set; }
    }
}
