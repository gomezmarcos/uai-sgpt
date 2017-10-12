using BE.servicio.autorizacion;
using BLL.servicio.autorizacion;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GUI.patentes
{
    public partial class PatentesAlta : System.Web.UI.Page
    {
        AutorizacionBll bll = new AutorizacionBll();
        AutorizacionRamaBll bllRama = new AutorizacionRamaBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<Patente> patentes = bll.BuscarTodos(new Dictionary<String, object>
                { { "fk_patente", null } } );
                
                foreach (Patente p in patentes)
                {
                    TreeNode NewNode = new TreeNode(p.Descripcion, p.Id.ToString())
                    {
                        PopulateOnDemand = false,
                        SelectAction = TreeNodeSelectAction.Expand
                    };
                    TreeView1.Nodes.Add(NewNode);
                    ArmarTreeNode(p, NewNode);
                }
            }
        }

        private void ArmarTreeNode(Patente patente, TreeNode node)
        {
            IList<Patente> pp = bll.BuscarTodos(new Dictionary<String, object>
            {
                { "fk_patente", patente.Id}
            });

            if (pp.Count > 0)
            {
                foreach (Patente p in pp)
                {
                    TreeNode nn = new TreeNode(p.Descripcion, p.Id.ToString());
                    nn.PopulateOnDemand = false;
                    nn.SelectAction = TreeNodeSelectAction.Expand;

                    node.ChildNodes.Add(nn);

                    ArmarTreeNode(p, nn);
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            PatenteRama nuevaPatente = new PatenteRama
            {
                Codigo = txtCodigo.Text,
                Descripcion = txtDescripcion.Text,
            };

            foreach (TreeNode node in TreeView1.CheckedNodes)
            {
                if (node.Checked)
                {
                    Patente p = new Patente();
                    p.Id = Convert.ToInt64(node.Value);
                    nuevaPatente.agregarHijo(p);
                }

            }

            PatenteRama rama = bllRama.Registrar(nuevaPatente);
            nuevaPatente.Id = rama.Id;
            bllRama.RegistrarHijos(nuevaPatente);
            Server.Transfer("PatenteAbm.aspx", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatenteAbm.aspx", true);
        }
    }
}