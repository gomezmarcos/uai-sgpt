using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL.dominio
{
    public class ResenaDal : DalGenerica<Resena>
    {
        public override string GetTableNameFuck()
        {
            return "resena";
        }
        public new Resena Registrar(Resena entity)
        {
            Resena guardada = base.Registrar(entity);
            entity.Id = guardada.Id;
            string Consulta = "update resena set hotelId = @P1, usuarioId = @P2 where id = @P3";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[3];
            Params[0] = Helper.CrearParametro("@P1", entity.objHotel.Id);
            Params[1] = Helper.CrearParametro("@P2", entity.objUsuario.Id);
            Params[2] = Helper.CrearParametro("@P3", guardada.Id);
            Helper.Update(Consulta, Params);
            return guardada;
        }
    }
}
