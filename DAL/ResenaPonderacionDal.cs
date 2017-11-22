using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL.dominio
{
    public class ResenaPonderacionDal : DalGenerica<ResenaPonderacion>
    {
        public override string GetTableNameFuck()
        {
            return "ponderacion";
        }
    }
}
