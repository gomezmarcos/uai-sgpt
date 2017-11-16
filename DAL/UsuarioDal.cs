using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;
using DAL.servicio.autorizacion;

namespace DAL
{
    public class UsuarioDal : DalGenerica<Usuario>
    {

        AutorizacionRamaDal autorizacionDal = new AutorizacionRamaDal();
        public override String GetTableNameFuck()
        {
            return "Usuario";
        }

        public new Usuario Registrar(Usuario u)
        {
            Usuario uu = base.Registrar(u);

            string Consulta = "insert into USUARIO_PATENTE (usuario, patente) values (@P1, @P2)";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[2];
            Params[0] = Helper.CrearParametro("@P1", uu.Id);
            Params[1] = Helper.CrearParametro("@P2", u.objPatente.Id);
            u.Id = Helper.Update(Consulta, Params);

            uu.objPatente = autorizacionDal.BuscarPorId(u.objPatente.Id);

            return uu;
        }

        public new Usuario Modificar(Usuario u)
        {
            Usuario updated = base.Modificar(u);

            if(u.objPatente != null)
            {

            string Consulta = "update USUARIO_PATENTE set patente = @P2 where usuario = @P1";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[2];
            Params[0] = Helper.CrearParametro("@P1", u.Id);
            Params[1] = Helper.CrearParametro("@P2", u.objPatente.Id);
            Helper.Update(Consulta, Params);
            updated.objPatente = autorizacionDal.BuscarPorId(u.objPatente.Id);
            }
            return updated;

        }
    }
}
