using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDalGenerica<T> where T : IBusinessEntity
    {

        String GetTableName();
        T BuscarPorId(long id);

         
        IList<T> BuscarTodos();
        void Eliminar(T entidad);
        T Modificar(T entidad);
        T Registrar(T entidad);


    }
}
