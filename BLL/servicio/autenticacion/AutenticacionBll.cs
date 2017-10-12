using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.autenticacion;
using BE;
using BLL.servicio;
using BLL.servicio.encriptacion;
namespace BLL.servicio.autenticacion
{
    public class AutenticacionBll
    {
        private const string RESPUESTA_INCORRECTO = "INCORRECTO";
        private const string RESPUESTA_DESHABILITADO = "DESHABILITADO";
        private const string RESPUESTA_CORRECTO = "CORRECTO";

        private const string ESTADO_DESHABILITADO = "DESHABILITADO";
        private const string ESTADO_HABILITADO = "HABILITADO";

        private UsuarioBll usuarioBll = new UsuarioBll();
        private Dictionary<string, RespuestaAtenticacion> respuestas = new Dictionary<string, RespuestaAtenticacion>();

        public AutenticacionBll()
        {
            respuestas.Add(RESPUESTA_INCORRECTO, new RespuestaAtenticacion(false, "AUTENTICACION_VALORES_INCORRECTOS"));
            respuestas.Add(RESPUESTA_DESHABILITADO, new RespuestaAtenticacion(false, "AUTENTICACION_USUARIO_DESHABILITADO"));
            respuestas.Add(RESPUESTA_CORRECTO, new RespuestaAtenticacion(true, ""));
        }

        public RespuestaAtenticacion Autenticar(Usuario usuario) {
            Dictionary<string, object> p = new Dictionary<string, object>
            {
                { "alias", usuario.Alias }
            };
            Usuario usuarioEncontrado = usuarioBll.Buscar(p);

            if (usuarioEncontrado == null)
            {
                return respuestas[RESPUESTA_INCORRECTO];
            }

            if (usuarioEncontrado.Estado == ESTADO_DESHABILITADO)
            {
                return respuestas[RESPUESTA_DESHABILITADO];
            }

            if (usuarioEncontrado.Contrasena == Encriptador.Encriptar(usuario.Contrasena))
            {
                usuarioEncontrado.Reintento = 0;
                usuarioBll.Modificar(usuarioEncontrado);
                return respuestas[RESPUESTA_CORRECTO];

            } else
            {
                AumentarReintentos(usuarioEncontrado);
                return respuestas[RESPUESTA_INCORRECTO];
            }
        }

        public Usuario DeshabilitarUsuario(Usuario usuario)
        {
            usuario.Estado = ESTADO_DESHABILITADO;
            return usuarioBll.Modificar(usuario);

        }

        public Usuario HabilitarUsuario(Usuario usuario)
        {
            usuario.Estado = ESTADO_HABILITADO;
            usuario.Reintento = 0;
            return usuarioBll.Modificar(usuario);
        }

        public Usuario ResetearContrasena(Usuario usuario, string contrasenaNueva)
        {
            usuario.Estado = ESTADO_DESHABILITADO;
            usuario.Reintento = 0;
            usuario.Contrasena = Encriptador.Encriptar(contrasenaNueva);
            return usuarioBll.Modificar(usuario);
        }

        private Usuario AumentarReintentos(Usuario usuario)
        {
            usuario.Reintento ++;
            if (usuario.Reintento >= 3)
            {
                usuario.Estado = ESTADO_DESHABILITADO;
            }
            return usuarioBll.Modificar(usuario);
        }
    }
}
