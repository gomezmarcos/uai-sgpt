using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    //public class UsuarioBll : IGenericInterface<Usuario>
    public class UsuarioBll : AbstractBll<Usuario>
    {
        private DalGenerica<Usuario> usuarioDal = new UsuarioDal();
        public override DalGenerica<Usuario> GetDal()
        {
            return usuarioDal;
        }
    }
}
