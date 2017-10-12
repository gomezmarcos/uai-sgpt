using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.servicio.idioma;

namespace DAL.servicio.idioma
{
    public class EntradaDal : DalGenerica<Entrada>
    {
        public override string GetTableNameFuck()
        {
            return "Entrada";
        }
    }
}
