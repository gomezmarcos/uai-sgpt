using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.idioma;
using BE;

namespace DAL.servicio.idioma
{
    public class IdiomaDal : DalGenerica<Idioma>
    {
        public override string GetTableNameFuck()
        {
            return "Idioma";
        }

        public int ObtenerIdiomaPorUsuario(Usuario usuario)
        {
            string Consulta = "SELECT idioma FROM USUARIO_IDIOMA  WHERE usuario=@P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = Helper.CrearParametro("@P1", usuario.Id);
            DataTable dt = Helper.Retrieve(Consulta, Params);

            return int.Parse(dt.Rows[0]["idioma"].ToString());
        }
    }
}
