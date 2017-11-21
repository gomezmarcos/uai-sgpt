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

        public new Hotel BuscarPorId(long id)
        {
            Hotel h = base.BuscarPorId(id);
            return h;
        }

        public IList<int> BuscarFotosPorId(long hotelId)
        {
            
            IList<int> resultado = new List<int>();
            string Consulta = "select fotoId from hotel_foto hf where hf.hotelId = @P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", hotelId);
            DataTable dt = Helper.Retrieve(Consulta, Params);

            foreach (DataRow row in dt.Rows)
                resultado.Add(Int32.Parse(row[0].ToString()));
            return resultado;
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

        public bool ExisteRelacionConTag(long hotelId, long tagId)
        {
            string Consulta = "select * from  hotel_tag where hotelId = @P2 and tagId = @P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[2];
            Params[0] = Helper.CrearParametro("@P1", tagId);
            Params[1] = Helper.CrearParametro("@P2", hotelId);
            int cantidad = Helper.RetrieveScalar(Consulta, Params);
            if (cantidad > 0)
            {
                return true;
            }
            return false;
        }

        public bool ExisteRelacionConDestino(long hotelId, long destinoId)
        {
            string Consulta = "select * from  hotel_destino where hotel_id = @P2 and destino_id = @P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[2];
            Params[0] = Helper.CrearParametro("@P1", destinoId);
            Params[1] = Helper.CrearParametro("@P2", hotelId);
            int cantidad = Helper.RetrieveScalar(Consulta, Params);
            if (cantidad > 0)
            {
                return true;
            }
            return false;
        }
    }
}
