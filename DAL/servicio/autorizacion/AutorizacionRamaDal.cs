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
    public class AutorizacionRamaDal : DalGenerica<PatenteRama>
    {
        private AutorizacionDal autorizacionDal = new AutorizacionDal();

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

        public void RegistrarHijos(PatenteRama patente)
        {
            SqlHelper Helper = new SqlHelper();
            string consulta = "insert into PATENTE (codigo, descripcion, fechaActualizacion, fechaCreacion, fk_patente, tipo) values" +
                " (@P1, @P2, @P3, @P4, @P5, @P6)";

            List<string> patentes = patente.GetCodigoPatenteComoLista();
            foreach (string ppp in patentes)
            {
                Patente p = autorizacionDal.BuscarTodos(new Dictionary<string, object> { { "codigo", ppp } })[0];
                if (p.Tipo == "rama")
                {
                    continue;
                }
                
                SqlParameter[] Params = new SqlParameter[6];
                Params[0] = Helper.CrearParametro("@P1", p.Codigo);
                Params[1] = Helper.CrearParametro("@P2", p.Descripcion);
                Params[2] = Helper.CrearParametro("@P3", DateTime.Now);
                Params[3] = Helper.CrearParametro("@P4", DateTime.Now);
                Params[4] = Helper.CrearParametro("@P5", patente.Id);
                Params[5] = Helper.CrearParametro("@P6", "base");
                Helper.Create(consulta, Params);

            }
        }
    }
}