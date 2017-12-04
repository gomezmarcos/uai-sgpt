using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.servicio.verificacion;
using DAL.servicio.verificacion;
using DAL;
using BLL.servicio.encriptacion;

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
            verificacion.Hash = Encriptador.Encriptar(hash);

            dal.Modificar(verificacion);
        }

        public String verificarIntegridad()
        {
            String hash = "";
            UsuarioBll usuarioBll = new UsuarioBll();
            foreach (Usuario u in usuarioBll.BuscarTodos())
            {
                if (!u.verificacion.Equals(u.GenerarVerificacion()))
                {
                    return "La verificacion del usuario con ID " + u.Id + " no ha sido satisfactoria. Se necesita restaurar el sistema.";
                }
                hash += u.verificacion;
            }
            Verificacion verificacion = dal.BuscarPorId(1);
            if (!verificacion.Hash.Equals(Encriptador.Encriptar(hash)))
            {
                return "La verificacion no ha sido satisfactoria. Algun registro ha sido agregado o eliminado de la tabla Usuario";
            }
            return "Verificacion exitosa";

        }
    }
}
