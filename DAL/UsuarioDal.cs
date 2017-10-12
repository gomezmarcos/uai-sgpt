using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;
using DAL.servicio.idioma;

namespace DAL
{
    public class UsuarioDal : DalGenerica<Usuario>
    {
        IdiomaDal idiomaDal = new IdiomaDal();
        public override String GetTableNameFuck()
        {
            return "Usuario";
        }

    }
}
