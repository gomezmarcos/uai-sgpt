using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DestinoDal : DalGenerica<Destino>
    {
        public override string GetTableNameFuck()
        {
            return "Destino";
        }
    }
}
