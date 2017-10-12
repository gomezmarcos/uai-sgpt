using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BE.servicio.idioma;
using DAL;
using DAL.servicio.idioma;

namespace BLL.servicio.idioma
{
    public class CulturaBll : AbstractBll<Cultura>
    {
        private CulturaDal dal = new CulturaDal();
        public override DalGenerica<Cultura> GetDal()
        {
            return dal;
        }
    }
}
