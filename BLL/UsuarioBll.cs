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
            Usuario u = usuarioDal.Registrar(usuario);
           // Usuario u = base.Registrar(usuario);
            u.verificacion = u.GenerarVerificacion();
            u = usuarioDal.Modificar(u);

            Recalcular<Usuario>();

            return u;
        }

        public new void Eliminar(Usuario usuario)
        {
            //falta eliminar referencias de idioma y patente
            base.Eliminar(usuario);
            Recalcular<Usuario>();
        }

        public new Usuario Modificar(Usuario usuario)
        {
            usuario.verificacion = usuario.GenerarVerificacion();
            Usuario u = usuarioDal.Modificar(usuario);
            Recalcular<Usuario>();
            return u;
        }

        public void Recalcular<T>() where T : IVerificable
        {
            verificacionBll.recalcular<Usuario>(this);//actualizar entidad Verificacion DVV
        }
    }
}
