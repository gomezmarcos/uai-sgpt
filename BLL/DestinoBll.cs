using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.dominio;
using DAL;

namespace BLL.dominio
{
    public class DestinoBll : AbstractBll<Destino>
    {
        private DestinoDal dal = new DestinoDal();
        public override DalGenerica<Destino> GetDal()
        {
            return dal;
        }
    }
}
