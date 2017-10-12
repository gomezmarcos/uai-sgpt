using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.servicio.autorizacion;
using System.Data.SqlClient;
using System.Data;

namespace DAL.servicio.autorizacion
{
    public class AutorizacionDal : DalGenerica<Patente>
    {
        public override string GetTableNameFuck()
        {
            return "PATENTE";
        }

        public IList<long> BuscarIdPatentes(Usuario usuario)
        {
            string Consulta = "SELECT patente FROM USUARIO_PATENTE  WHERE usuario=@P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", usuario.Id);
            DataTable dt = Helper.Retrieve(Consulta, Params);

            IList<long> ids = new List<long>();
            foreach (DataRow row in dt.Rows)
                ids.Add(long.Parse(row["patente"].ToString()));
            return ids;
        }
    }
}
