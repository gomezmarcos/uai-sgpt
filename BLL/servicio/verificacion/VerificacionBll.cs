using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.servicio.verificacion;
using DAL.servicio.verificacion;
using DAL;

namespace BLL.servicio.verificacion
{
    public class VerificacionBll : AbstractBll<Verificacion>
    {
        private VerificacionDal dal = new VerificacionDal();
        public override DalGenerica<Verificacion> GetDal()
        {
            return dal;
        }

        public void recalcular<T>(AbstractBll<T> bll) where T : IBusinessEntity
        {
            IList<T> elementos = bll.BuscarTodos();
            String hash = "";
            foreach (T e in elementos)
                hash += ((IVerificable)e).GenerarVerificacion();

            Dictionary<string, object> propiedades = new Dictionary<string, object>();
            propiedades.Add("entidad", typeof(T).Name);
            Verificacion verificacion = base.BuscarTodos(propiedades)[0];
            verificacion.Hash = hash.GetHashCode().ToString();

            dal.Modificar(verificacion);
        }
    }
}
