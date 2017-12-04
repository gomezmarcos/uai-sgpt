using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.servicio.autorizacion;
using BLL;
using BLL.servicio.autorizacion;
using BLL.servicio.encriptacion;

namespace GUI.soporte.usuarios
{
    /*TODO:
     * Falta eliminar un usuario - tambien hay que eliminar todos los registros en USUARIO_PATENTE -- no imprescindible
     * Falta que aparezca seleccionado el combo de rol a editar - esta harcodeado. Hay que ir a buscar el unico el valor USUARIO_PATENTE
     */

    public partial class UsuarioSistemaEditar : System.Web.UI.Page
    {
        UsuarioBll bll = new UsuarioBll();
        AutorizacionRamaBll autorizacionBll = new AutorizacionRamaBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPassword.Attributes["type"] = "password";
            if (!IsPostBack)
            {
                var usuarioId = Int64.Parse(Request.QueryString["id"]);
                Usuario u = bll.BuscarPorId(usuarioId);
                txtAlias.Text = u.Alias;
                txtEmail.Text = u.Email;
                txtPassword.Text = u.Contrasena;

            IList<PatenteRama> ramas = autorizacionBll.BuscarTodos(new Dictionary<string, object>
            {
                { "tipo", "rama"}
            });
            foreach (PatenteRama rama in ramas)
            {
                ListItem item = new ListItem(rama.Descripcion, rama.Id.ToString());
                lstRol.Items.Add(item);
                    lstRol.SelectedValue = "4";
            }
            }

        }

        protected void lstRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var usuarioId = Int64.Parse(Request.QueryString["id"]);
            Usuario u = bll.BuscarPorId(usuarioId);
            u.Alias = txtAlias.Text;
            u.Email = txtEmail.Text;
            if (u.Contrasena.Equals(txtPassword.Text)) //hack para enmascarar edicion de contrasenas.
            {
                u.Contrasena = txtPassword.Text;
            } else
            {
                u.Contrasena = Encriptador.Encriptar(txtPassword.Text);
            }

            PatenteRama p = new PatenteRama();
            p.Id =  Int32.Parse( lstRol.SelectedValue);
            u.objPatente = p;

            bll.Modificar(u);
            Response.Redirect("UsuarioSistemaAbm.aspx", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioSistemaAbm.aspx", true);
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            var usuarioId = Int64.Parse(Request.QueryString["id"]);
            Usuario u = new Usuario();
            u.Id = usuarioId;
            bll.Eliminar(u);
            Response.Redirect("UsuarioSistemaAbm.aspx", true);
        }
    }
}