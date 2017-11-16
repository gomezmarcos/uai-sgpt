using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HotelDal : DalGenerica<Hotel>
    {
        public override string GetTableNameFuck()
        {
            return "Hotel";
        }

        public List<Hotel> buscarTodosPorDestinoId(long destinoId)
        {
            string Consulta = "select h.* from hotel h inner join hotel_destino hd on hd.hotel_id = h.id where hd.destino_id = @P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", destinoId);
            DataTable dt = Helper.Retrieve(Consulta, Params);

            return new SqlHelper().MapMany<Hotel>(dt);
        }
    }
}
