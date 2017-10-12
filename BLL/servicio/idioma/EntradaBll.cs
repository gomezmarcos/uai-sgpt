using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.servicio.idioma;
using DAL;
using DAL.servicio.idioma;

namespace BLL.servicio.idioma
{
    class EntradaBll : AbstractBll<Entrada>
    {
        EntradaDal entradaDal = new EntradaDal();
        public override DalGenerica<Entrada> GetDal()
        {
            return entradaDal;
        }
    }
}
