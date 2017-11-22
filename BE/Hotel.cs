using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Hotel : IBusinessEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Habitaciones { get; set; }
        public decimal Precio { get; set; }
        public int Puntos { get; set; }
        public IList<Tag> tags { get; set; }
        public IList<Foto> fotos { get; set; }
        public IList<Destino> destinos { get; set; }
    }
}
