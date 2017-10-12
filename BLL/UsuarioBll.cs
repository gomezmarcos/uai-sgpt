using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DAL.servicio;
using BLL.servicio.verificacion;
using BE.servicio.verificacion;

namespace BLL
{
    public class UsuarioBll : AbstractBll<Usuario>, VerificacionRecalculable
    {
        private UsuarioDal usuarioDal = new UsuarioDal();
        private VerificacionBll verificacionBll = new VerificacionBll();

        public override DalGenerica<Usuario> GetDal()
        {
            return usuarioDal;
        }

        public new Usuario Registrar(Usuario usuario)
        {
            Usuario u = base.Registrar(usuario);
            usuario.verificacion = usuario.GenerarVerificacion();
            u = base.Modificar(usuario);

            Recalcular<Usuario>();

            return u;
        }

        public new void Eliminar(Usuario usuario)
        {
            base.Eliminar(usuario);
            Recalcular<Usuario>();
        }

        public new Usuario Modificar(Usuario usuario)
        {
            usuario.verificacion = usuario.GenerarVerificacion();
            Usuario u = base.Modificar(usuario);
            Recalcular<Usuario>();
            return u;
        }

        public void Recalcular<T>() where T : IVerificable
        {
            verificacionBll.recalcular<Usuario>(this);//actualizar entidad Verificacion DVV
        }
    }
}
