using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UsuarioDal : DalGenerica<Usuario>
    {
        public override String GetTableNameFuck()
        {
            return "Usuario";
        }
    }
}
