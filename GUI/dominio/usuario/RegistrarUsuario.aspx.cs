using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.servicio.autorizacion;
using BLL.servicio;
using BLL;
using BLL.servicio.encriptacion;
using BLL.servicio.autorizacion;

namespace GUI.dominio.usuario
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        UsuarioBll usuarioBll = new UsuarioBll();
        AutorizacionRamaBll ramaBll = new AutorizacionRamaBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default", true);

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.Alias = txtAlias.Text;
            u.Area = "Cliente";
            u.Contrasena = Encriptador.Encriptar(txtPassword.Text);
            u.Email = txtEmail.Text;
            u.FechaCreacion = new DateTime();
            u.FechaActualizacion = new DateTime();

            u.objPatente = ramaBll.Buscar(new Dictionary<string, object>
            {
                {"codigo", "CLI" }
            });
            u.objPatente.Id = u.objPatente.Id;

            Response.Redirect("~/Default", true);
        }
    }
}