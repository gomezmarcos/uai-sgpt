using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.servicio.bitacora;
using BE.servicio.bitacora;
using System.Web.UI.HtmlControls;

namespace GUI
{

    public partial class Bitacora : System.Web.UI.Page
    {
        private class BitacoraFormulario
        {
            public IList<Evento> Eventos { get; set; }
            public String FiltroNombre { get; set; }
            public String FiltroValor { get; set; }
        }
        
        private BLL.servicio.bitacora.Bitacora b = new BLL.servicio.bitacora.Bitacora();

        //aca cargo todo lo necesario para mostrar la pagina la primera vez (!IsPostBack)
        //tambien guardo lo submiteado por el usuario (caso dropdownlist)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                filtro.Items.Add(new ListItem("", ""));
                filtro.Items.Add(new ListItem("Autor", "Autor"));
                filtro.Items.Add(new ListItem("Modulo", "Modulo"));
                filtro.Items.Add(new ListItem("Descripcion", "Descripcion"));

                ArmarEncabezadoDeTabla(tablaEventos);
                foreach (Evento evento in b.buscarTodos())
                {
                    TableRow row = ArmarFilaDeTabla(evento);
                    tablaEventos.Rows.Add(row);
                }
            }
        }

        protected void Buscar(object sender, EventArgs e)
        {
            tablaEventos.Rows.Clear();

            foreach (Evento evento in BuscarEventos())
                tablaEventos.Rows.Add(ArmarFilaDeTabla(evento));
        }

        private IList<Evento> BuscarEventos()
        {
            if (filtro.SelectedValue != "")
            {
                Dictionary<string, object> prop = new Dictionary<string, object>();
                prop.Add(filtro.SelectedValue, valorFiltro.Text);
                if (filtro.SelectedValue == "Descripcion")
                    return b.buscarTodosConLike(prop);
                else
                    return b.buscarTodos(prop);
            }
            else
                return b.buscarTodos();
        }

        private TableRow ArmarFilaDeTabla(Evento evento)
        {
            TableRow row = new TableRow();

            TableCell cId = new TableCell();
            cId.Text = evento.Id.ToString();

            TableCell cFecha = new TableCell();
            cFecha.Text = evento.FechaCreacion.ToString();

            TableCell cAutor = new TableCell();
            cAutor.Text = evento.Autor.ToString();

            TableCell cModulo = new TableCell();
            cModulo.Text = evento.Modulo.ToString();

            TableCell cDescripcion = new TableCell();
            cDescripcion.Text = evento.Descripcion.ToString();

            row.Cells.Add(cId);
            row.Cells.Add(cFecha);
            row.Cells.Add(cAutor);
            row.Cells.Add(cModulo);
            row.Cells.Add(cDescripcion);
            return row;
        }

        private void ArmarEncabezadoDeTabla(Table tablaEventos)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableHeaderCell()
            {
                Text = "Id"
            });
            row.Cells.Add(new TableHeaderCell()
            {
                Text = "Fecha"
            });
            row.Cells.Add(new TableHeaderCell()
            {
                Text = "Usuario"
            });
            row.Cells.Add(new TableHeaderCell()
            {
                Text = "Modulo"
            });
            row.Cells.Add(new TableHeaderCell()
            {
                Text = "Descripcion"
            });
            tablaEventos.Rows.Add(row);
        }

    }
}
