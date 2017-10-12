using BE;
using BE.servicio.autenticacion;
using BLL.servicio.autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Autenticar : System.Web.UI.Page
    {
        private AutenticacionBll autenticacionBll = new AutenticacionBll();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                Response.Redirect("About.aspx"); //como si fuese mi login
            }

            //Como no se proceso correctamente, vuelvo a la pagina (si! sin hacer nada) y actualizo los campos deseados.
            tieneError.Value = "true";
            lblError.Text = r.MensajeError;
        }
    }
}