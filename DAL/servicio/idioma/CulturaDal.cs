using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.idioma;
namespace DAL.servicio.idioma
{
    public class CulturaDal : DalGenerica<Cultura>
    {
        public override string GetTableNameFuck()
        {
            return "Cultura";
        }
    }
}
