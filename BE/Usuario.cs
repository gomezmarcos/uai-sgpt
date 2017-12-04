using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.verificacion;
using BE.servicio.idioma;
using BE.servicio.autorizacion;

namespace BE
{
    public class Usuario : IBusinessEntity, IVerificable
    {
        public string Area { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }

        public string Estado { get; set; }
        public int Reintento { get; set; }
        public string Contrasena { get; set; }

        public Idioma objIdioma { get; set; }
        public PatenteRama objPatente { get; set; }

        public String verificacion { get; set; }//necesario porque implementa IVerificable

        public string GenerarVerificacion()
        {
            return Alias+Email+0;
        }
    }
}
