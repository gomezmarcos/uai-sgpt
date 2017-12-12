using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.dominio
{
    public class PaqueteDal : DalGenerica<Paquete>
    {
        public override string GetTableNameFuck()
        {
            return "Paquete";
        }

        public IList<int> BuscarDestinoPorId(long paqueteId)
        {
            string Consulta = "select destinoId from paquete_Destino where paqueteId = @P1";
            return ObtenerIds(paqueteId, Consulta);
        }

        public IList<int> BuscarTagsPorId(long paqueteId)
        {
            string Consulta = "select tagId from paquete_tag where paqueteId = @P1";
            return ObtenerIds(paqueteId,Consulta);
        }

        public IList<int> BuscarVuelosPorId(long paqueteId)
        {
            string Consulta = "select vueloId  from paquete_vuelo where paqueteId = @P1";
            return ObtenerIds(paqueteId,Consulta);
        }

        public IList<int> BuscarHotelesPorId(long paqueteId)
        {
            string Consulta = "select hotelId  from paquete_hotel where paqueteId = @P1";
            return ObtenerIds(paqueteId,Consulta);
        }

        public IList<int> BuscarFotosPorId(long paqueteId)
        {
            string Consulta = "select fotoId  from paquete_foto where paqueteId = @P1";
            return ObtenerIds(paqueteId,Consulta);
        }
        private IList<int> ObtenerIds(long id, string Consulta)
        {
            IList<int> resultado = new List<int>();
            SqlParameter[] SelectParam = new SqlParameter[1];
            SqlHelper Helper = new SqlHelper();
            SelectParam[0] = Helper.CrearParametro("@P1", id);
            DataTable dt = Helper.Retrieve(Consulta, SelectParam);
            foreach (DataRow row in dt.Rows)
                resultado.Add((int)row[0]);
            return resultado;
        }

        public void Comprar(Usuario usuario, Paquete paquete)
        {
            string Consulta = "insert into usuario_paquete (usuarioId,paqueteId,precio,fechaCreacion,fechaActualizacion) values (@P0, @P1,@P2,@P3,@P4)";
            SqlParameter[] SelectParam = new SqlParameter[5];
            SqlHelper Helper = new SqlHelper();
            SelectParam[0] = Helper.CrearParametro("@P0", usuario.Id);
            SelectParam[1] = Helper.CrearParametro("@P1", paquete.Id);
            SelectParam[2] = Helper.CrearParametro("@P2", paquete.Precio);
            SelectParam[3] = Helper.CrearParametro("@P3", DateTime.Now);
            SelectParam[4] = Helper.CrearParametro("@P4", DateTime.Now);
            Helper.Create(Consulta, SelectParam);
        }
    }
}