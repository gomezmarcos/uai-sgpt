using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.servicio.autorizacion;
using BE.servicio.autorizacion;
using BE;
using BLL.servicio.encriptacion;

namespace GUI.soporte.usuarios
{
    public partial class UsuarioSistemaAlta : System.Web.UI.Page
    {
        AutorizacionRamaBll bll = new AutorizacionRamaBll();
        UsuarioBll usuarioBll = new UsuarioBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<PatenteRama> ramas = bll.BuscarTodos(new Dictionary<string, object>
            {
                { "tipo", "rama"}
            });
            foreach (PatenteRama rama in ramas)
            {
                ListItem item = new ListItem(rama.Descripcion, rama.Id.ToString());
                lstRol.Items.Add(item);
            }
        }

        protected void lstRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.Alias = txtAlias.Text;
            u.Area = lstRol.Text;
            u.Contrasena = Encriptador.Encriptar(txtPassword.Text);
            u.Email = txtEmail.Text;
            u.FechaCreacion = new DateTime();
            u.FechaActualizacion = new DateTime();

            u.objPatente = new PatenteRama();
            u.objPatente.Id = Int32.Parse(lstRol.Text);

            usuarioBll.Registrar(u);

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioSistemaAbm.aspx", true);
        }
    }
}