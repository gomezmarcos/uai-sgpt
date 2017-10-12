using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.servicio.bitacora
{
    public class EventoDal : DalGenerica<BE.servicio.bitacora.Evento>
    {
        public override string GetTableNameFuck()
        {
            return "Evento";
        }
    }
}
