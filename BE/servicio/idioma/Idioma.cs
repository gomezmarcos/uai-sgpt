using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.servicio.idioma
{
    public class Idioma : IBusinessEntity
    {
        public string Cultura { get; set; }
        public String Nombre { get; set; }
        public IList<Entrada> Entradas { get; set; }

        public string Traducir(string controlId)
        {
            foreach (Entrada entrada in Entradas)
            {
                if (entrada.Clave.ToString() == controlId)
                {
                    return entrada.Valor;
                }
            }
            return "";
        }
    }
}
