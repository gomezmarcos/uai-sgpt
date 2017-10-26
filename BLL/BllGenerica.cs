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
        public T Buscar(Dictionary<string, object> parametros)
        {
            IList<T> respuesta = BuscarTodos(parametros);
            if (respuesta.Count == 0)
            {
                return null;
            }
            return respuesta[0];
        }
        public IList<T> BuscarTodos()
        {
            return GetDal().BuscarTodos();
        }

        public IList<T> BuscarTodos(Dictionary<string, object> parametros)
        {
            IList<T> respuesta = GetDal().BuscarTodos(parametros);
            if (respuesta.Count == 0)
            {
                return new List<T>();
            }
            return respuesta;
        }

        public IList<T> BuscarTodosConLike(Dictionary<string, object> parametros)
        {
            IList<T> respuesta = GetDal().BuscarTodosConLike(parametros);
            if (respuesta.Count == 0)
            {
                return new List<T>();
            }
            return respuesta;

        }

        public void Eliminar(T entidad)
        {
            GetDal().Eliminar(entidad);
        }

        public void Eliminar(Dictionary<string, object> parametros)
        {
            GetDal().Eliminar(parametros);
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
