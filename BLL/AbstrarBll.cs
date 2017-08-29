using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BLL
{
    public abstract class AbstractBll<T> where T : IBusinessEntity
    {
        public T BuscarPorId(long id)
        {
            return GetDal().BuscarPorId(id);
        }
        public IList<T> BuscarTodos()
        {
            return GetDal().BuscarTodos();
        }
        public void Eliminar(T entidad)
        {
            GetDal().Eliminar(entidad);
        }
        public T Modificar(T entidad)
        {
            return GetDal().Modificar(entidad);
        }
        public T Registrar(T entidad)
        {
            return GetDal().Registrar(entidad);
        }

        public abstract DAL.DalGenerica<T> GetDal();
        
    }
}
