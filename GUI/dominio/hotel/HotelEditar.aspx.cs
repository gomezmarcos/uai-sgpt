using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.dominio;
using BLL.util;
using BE;

namespace GUI.dominio.hotel
{
    public partial class HotelEditar : System.Web.UI.Page
    {
        TagBll tagBll = new TagBll();
        HotelBll hotelBll = new HotelBll();
        DestinoBll destinoBll = new DestinoBll();
        FotoBll fotoBll = new FotoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            var hotelId = Int64.Parse(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                Hotel h = hotelBll.BuscarPorId(hotelId);
                txtNombre.Text = h.Nombre;
                txtDireccion.Text = h.Direccion;
                txtLat.Text = h.Latitud;
                txtLong.Text = h.Longitud;
                txtDireccion.Text = h.Direccion;
                txtHabitaciones.Text = h.Habitaciones;
                txtDescripcion.Text = h.Descripcion;
                txtPrecio.Text = h.Precio.ToString();
            }

            foreach (Destino d in destinoBll.BuscarTodos())
            {
                ListItem item = new ListItem();
                item.Value = d.Id.ToString();
                item.Text = d.Descripcion;
                if (!IsPostBack && hotelBll.existeRelacionConDestino(hotelId, d.Id))
                {
                    item.Selected = true;
                }
                lstDestinos.Items.Add(item);
            }

            foreach (Tag t in tagBll.BuscarTodos())
            {
                ListItem item = new ListItem();
                item.Value = t.Id.ToString();
                item.Text = t.Codigo;
                if (!IsPostBack && hotelBll.existeRelacionConTag(hotelId, t.Id))
                {
                    item.Selected = true;
                }
                chkTags.Items.Add(item);
            }

            tblFotos.Rows.Clear();
            TableHeaderRow hrow = new TableHeaderRow();
            hrow.Cells.Add( new TableHeaderCell {Text = "Nombre"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha de Creacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            tblFotos.Rows.Add(hrow);

            IList<Foto> fotos = fotoBll.buscarPorHotelId(hotelId);
            foreach (Foto h in fotos)
            {
                TableRow row = new TableRow();
                row.Cells.Add( new TableCell {Text = h.nombre});
                row.Cells.Add( new TableCell {Text = h.FechaCreacion.ToString()});
                tblFotos.Rows.Add(row);
            }
            if (fotos.Count>0)
            {
                Foto f = fotos[0];
                imagenPrincipal.ImageUrl = f.path;
                imagenPrincipal.AlternateText = f.nombre;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HotelAbm.aspx", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var hotelId = Int64.Parse(Request.QueryString["id"]);
            Hotel h = hotelBll.BuscarPorId(hotelId);

            h.Nombre = txtNombre.Text;
            h.Descripcion = txtDescripcion.Text;
            h.Direccion = txtDireccion.Text;
            h.Latitud = txtLat.Text;
            h.Longitud = txtLong.Text;
            h.FechaActualizacion = new DateTime();
            h.FechaCreacion = new DateTime();
            h.Habitaciones = txtHabitaciones.Text;
            h.Precio =Decimal.Parse( txtPrecio.Text);

            h.tags = chkTags.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(x => new Tag()
                {
                    Id = Int32.Parse( x.Value.ToString())
                })
                .ToList();

            h.destinos = lstDestinos.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(d => new Destino()
                {
                    Id = Int32.Parse(d.Value.ToString())
                })
                .ToList();

            h.fotos = ArmarFotos(files, hotelId);

            hotelBll.Modificar(h);

            Response.Redirect("HotelAbm.aspx", true);
        }

        private IList<Foto> ArmarFotos(FileUpload files, long hotelId)
        {
            IList<Foto> resultado = new List<Foto>();
            if ((files.PostedFiles != null) )
            {
                foreach (HttpPostedFile ff in files.PostedFiles)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~") + "\\fotos\\hotel\\" + hotelId );
                    string fn = System.IO.Path.GetFileName(ff.FileName);
                    string SaveLocation = Server.MapPath("~") + "\\fotos\\hotel\\" + hotelId + "\\" + fn;

                    Foto f = new Foto
                    {
                        nombre = fn,
                        path = "/fotos/hotel/" + hotelId + "/" + fn
                    };
                    f = fotoBll.Registrar(f);
                    try
                    {
                        ff.SaveAs(SaveLocation);
                        Response.Write("The file has been uploaded.");
                        resultado.Add(f);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                return new List<Foto>();
            }
            return resultado;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            var hotelId = Int64.Parse(Request.QueryString["id"]);
            Hotel h = new Hotel();
            h.Id = hotelId;
            hotelBll.Eliminar(h);
            Response.Redirect("HotelAbm.aspx", true);
        }
    }
}