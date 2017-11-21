using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;
using DAL.dominio;

namespace DAL
{
    public class VueloDal : DalGenerica<Vuelo>
    {
        private DestinoDal destinoDal = new DestinoDal();
        public override string GetTableNameFuck()
        {
            return "VUELO";
        }

        public new Vuelo BuscarPorId(long id)
        {
            Vuelo v = base.BuscarPorId(id);

            return v;
        }

        public void RegistrarDestinos(Vuelo vuelo)
        {
            string Consulta = "insert into VUELO_DESTINO (vueloId, origenId, destinoId) values (@P1, @P2, @P3)";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[3];
            Params[0] = Helper.CrearParametro("@P1", vuelo.Id);
            Params[1] = Helper.CrearParametro("@P2", vuelo.objOrigen.Id);
            Params[2] = Helper.CrearParametro("@P3", vuelo.objDestino.Id);
            DataTable dt = Helper.Retrieve(Consulta, Params);
        }

        public IList<Destino> BuscarOrigenAndDestino(Vuelo vuelo)
        {
            string Consulta = "select * from VUELO_DESTINO where vueloId = @P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", vuelo.Id);
            DataTable dt = Helper.Retrieve(Consulta, Params);

            IList<Destino> destinos = new List<Destino>();
            long origenId = long.Parse(dt.Rows[0][1].ToString()) ;
            long destinoId = long.Parse(dt.Rows[0][2].ToString()) ;
            destinos.Add(destinoDal.BuscarPorId(origenId));
            destinos.Add(destinoDal.BuscarPorId(destinoId));
            return destinos;
        }

        public void EliminarDestinos(Vuelo vuelo)
        {
            string Consulta = "delete VUELO_DESTINO where vueloId = @P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", vuelo.Id);
            Helper.Delete(Consulta, Params);
        }
    }
}
