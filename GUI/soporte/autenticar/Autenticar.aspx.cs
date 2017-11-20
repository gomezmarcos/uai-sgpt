using BE;
using BE.servicio.autenticacion;
using BE.servicio.autorizacion;
using BLL.servicio.autenticacion;
using BLL.servicio.autorizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace GUI
{
    public partial class Autenticar : System.Web.UI.Page
    {
        private AutenticacionBll autenticacionBll = new AutenticacionBll();
        private UsuarioBll usuarioBll = new UsuarioBll();
        private AutorizacionBll autorizacionBll = new AutorizacionBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtAlias.Focus();
                txtAlias.Text = "";

            }
        }

        /*
         * En el SubmitForm es donde valido y verifico la opcion elegida para saber a donde hay que redirigir (CRUD).
         * Tambien es donde hago las validaciones
         */
        protected void SubmitForm(object sender, EventArgs e)
        {
            RespuestaAtenticacion r = autenticacionBll.Autenticar(new Usuario
            {
                Contrasena = txtPassword.Text,
                Alias = txtAlias.Text
            });

            if (r.EsExitosa) {
                IList<Usuario> lista = usuarioBll.BuscarTodos(new Dictionary<string, object>
                    {
                        { "alias", txtAlias.Text }
                    }
                );

                Usuario u = lista[0];
                IPatente p = autorizacionBll.ObtenerPatentePorUsuario(u);
                u.objPatente = (PatenteRama) p;

                Session["usuario"] = lista[0];


                FormsAuthentication.SetAuthCookie(this.txtAlias.Text.Trim(), false);
                if (Request["returnUrl"] == null)
                {
                    Response.Redirect("~/Default"); //como si fuese mi login
                } else
                {
                    Response.Redirect(Request["returnUrl"]); //como si fuese mi login
                }
            }

            //Como no se proceso correctamente, vuelvo a la pagina (si! sin hacer nada) y actualizo los campos deseados.
            tieneError.Value = "true";
            lblError.Text = r.MensajeError;
        }
    }
}