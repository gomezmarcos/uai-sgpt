using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    class BllGenerica<T> where T : IBusinessEntity
    {
        DalGenerica<T> dal;

        public T BuscarPorId(long id)
        {
            return this.dal.BuscarPorId(id);
        }

        public IList<T> BuscarTodos()
        {
            return dal.BuscarTodos();
        }

        public void Eliminar(T entidad)
        {
            dal.Eliminar(entidad);
        }

        public T Modificar(T entidad)
        {
            return dal.Modificar(entidad);
        }

        public T Registrar(T entidad)
        {
            return dal.Registrar(entidad);
        }

        public void SetDal(DalGenerica<T> dal)
        {
            this.dal = dal;
        }
    }
}
