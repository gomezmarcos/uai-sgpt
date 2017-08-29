using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BLL
{
    public interface IGenericInterface<T> where T : IBusinessEntity
    {
        T BuscarPorId(long id);
        IList<T> BuscarTodos();
        void Eliminar(T entidad);
        T Modificar(T entidad);
        T Registrar(T entidad);

        DAL.IDalGenerica<T> GetDal();
    }
}
