using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Paquete : IBusinessEntity
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public IList<Destino> Destinos { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Vuelo> Vuelos { get; set; }
        public IList<Hotel> Hoteles { get; set; }
        public decimal Precio { get; set; }
        public IList<Foto> Fotos { get; set; }
    }
}
