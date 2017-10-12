using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.verificacion;
namespace DAL.servicio.verificacion
{
    public class VerificacionDal : DalGenerica<Verificacion>
    {
        public override string GetTableNameFuck()
        {
            return "Verificacion";
        }
    }
}
