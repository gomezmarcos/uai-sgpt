using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.verificacion;
using BE.servicio.idioma;

namespace BE
{
    public class Usuario : IBusinessEntity, IVerificable
    {
        public string Area { get; set; }
        public string Alias { get; set; }

        public string Estado { get; set; }
        public int Reintento { get; set; }
        public string Contrasena { get; set; }

        public Idioma Idioma { get; set; }

        public String verificacion { get; set; }//necesario porque implementa IVerificable

        public string GenerarVerificacion()
        {
            return Alias+0;
        }
    }
}
