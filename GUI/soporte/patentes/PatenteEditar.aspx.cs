using BE.servicio.autorizacion;
using BLL.servicio.autorizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.patentes
{
    public partial class PatentesEditar : System.Web.UI.Page
    {
        AutorizacionBll bll = new AutorizacionBll();
        AutorizacionRamaBll ramabll = new AutorizacionRamaBll();
        List<string> patentesDeSistema = new List<string> {"TADM", "MKT", "CLI"};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["checkedPatentes"] = null; 
                var ramaId = Request.QueryString["id"];
                IPatente patenteValida = bll.ObtenerPatentePorPatente(Int64.Parse(ramaId));
                txtCodigo.Text = patenteValida.GetCodigoPatente();
                txtDescripcion.Text = ((PatenteRama)patenteValida).Descripcion;

                btnBorrar.Enabled = !patentesDeSistema.Contains(patenteValida.GetCodigoPatente());

                IList<Patente> patentes = bll.BuscarTodos(new Dictionary<String, object>
                { { "fk_patente", null } } );
                
                foreach (Patente p in patentes)
                {
                    TreeNode NewNode = new TreeNode(p.Descripcion, p.Id.ToString())
                    {
                        Checked = patenteValida.EsPatenteValidaParaElUsuario(p.Codigo),
                        PopulateOnDemand = false,
                        SelectAction = TreeNodeSelectAction.Expand,
                    };
                    TreeView1.Nodes.Add(NewNode);
                    ArmarTreeNode(p, NewNode, patenteValida);
                }

                IList<Patente> patentesNew = bll.BuscarTodos(new Dictionary<String, object>
                { { "tipo", "rama" } } );
                foreach (Patente item in patentesNew)
                {
                    ListItem i = new ListItem(item.Descripcion, item.Codigo);
                    ramas.Items.Add(i);
                }


            }
        }

        private void ArmarTreeNode(Patente patente, TreeNode node, IPatente patenteValida)
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
                    nn.Checked = patenteValida.EsPatenteValidaParaElUsuario(p.Codigo);

                    node.ChildNodes.Add(nn);

                    ArmarTreeNode(p, nn, patenteValida);
                }
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            var ramaId = Int64.Parse(Request.QueryString["id"]);
            bll.Eliminar(new Dictionary<String, object> { { "fk_patente", ramaId } } );

            Patente patenteParaBorrar = new Patente() { Id = ramaId };
            bll.Eliminar(patenteParaBorrar);
            Response.Redirect("PatenteAbm.aspx", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatenteAbm.aspx", true);
        }

        protected void patentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedValue = ((DropDownList)sender).SelectedValue;
            PatenteRama patenteSeleccionada = ramabll.BuscarTodos(new Dictionary<String, object>
            {
                { "codigo", selectedValue}
            })[0];

            var ramaId = Int64.Parse(Request.QueryString["id"]);
            IPatente ppp = ramabll.ObtenerPatentePorPatente(ramaId);

            IList<Patente> pp = bll.BuscarTodos(new Dictionary<String, object>
            {
                { "fk_patente", ((PatenteRama)patenteSeleccionada).Id}
            });
            patentes.Items.Clear();
            foreach (Patente p in pp)
            {
                Boolean esChequeada = ppp.EsPatenteValidaParaElUsuario(p.Codigo);
                ListItem i = new ListItem(p.Descripcion, p.Codigo );
                i.Enabled = true;
                i.Selected = esChequeada;
                patentes.Items.Add(i);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            var ramaId = Int64.Parse(Request.QueryString["id"]);
            PatenteRama ppp = (PatenteRama)ramabll.ObtenerPatentePorPatente(ramaId);

            HashSet<String> checkedIds = (HashSet<String>) Session["checkedPatentes"];
            checkedIds = checkedIds == null ? new HashSet<String>() : (HashSet<String>) Session["checkedPatentes"];

            foreach (ListItem node in patentes.Items)
                if (node.Selected)
                    checkedIds.Add(node.Value);

            foreach (String codigo in checkedIds)
            {
                Patente p = bll.Buscar(new Dictionary<String, object>
                {
                    { "codigo", codigo }
                });
                ppp.agregarHijo(p);
            }

            ppp.Codigo = txtCodigo.Text;
            ppp.Descripcion = txtDescripcion.Text;
            PatenteRama rama = ramabll.Modificar((PatenteRama)ppp);

            Response.Redirect("PatenteAbm.aspx", true);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            HashSet<String> checkedIds = (HashSet<String>) Session["checkedPatentes"];
            checkedIds = checkedIds == null ? new HashSet<String>() : (HashSet<String>) Session["checkedPatentes"];
            foreach (ListItem node in patentes.Items)
                if (node.Selected)
                    checkedIds.Add(node.Value);
                else
                    checkedIds.Remove(node.Value);

            Session["checkedPatentes"] = checkedIds;
        }
    }
}