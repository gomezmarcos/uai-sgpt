using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.utilitarios
{
    public class FotoDal : DalGenerica<Foto>
    {
        public override string GetTableNameFuck()
        {
            return "Foto";
        }

        public IList<Foto> buscarPorHotelId(long hotelId)
        {
            IList<Foto> resultado = new List<Foto>();

            string Consulta = "select fotoId from hotel_foto where hotelId=@P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", hotelId);
            DataTable dt = Helper.Retrieve(Consulta, Params);

            foreach (DataRow row in dt.Rows)
            {
                Foto f = this.BuscarPorId(Int32.Parse(row[0].ToString()));
                resultado.Add(f);
            }
            return resultado;
        }

        public IList<Foto> buscarPorPaqueteId(long paqueteId)
        {
            IList<Foto> resultado = new List<Foto>();

            string Consulta = "select * from paquete_foto where paqueteId=@P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", paqueteId);
            DataTable dt = Helper.Retrieve(Consulta, Params);

            foreach (DataRow row in dt.Rows)
            {
                Foto f = this.BuscarPorId(Int32.Parse(row[1].ToString()));
                resultado.Add(f);
            }
            return resultado;
        }
    }
}
