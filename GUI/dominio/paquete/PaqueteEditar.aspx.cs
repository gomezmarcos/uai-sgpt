using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL.dominio;
using BLL.util;
using BLL;

namespace GUI.dominio.paquete
{
    public partial class PaqueteEditar : System.Web.UI.Page
    {
        private HotelBll hotelBll = new HotelBll();
        private DestinoBll destinoBll = new DestinoBll();
        private VueloBll vueloBll = new VueloBll();
        private TagBll tagBll = new TagBll();
        private PaqueteBll paqueteBll = new PaqueteBll();
        private FotoBll fotoBll = new FotoBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            var paqueteId = Int64.Parse(Request.QueryString["id"]);
            Paquete paquete = paqueteBll.BuscarPorId(paqueteId);

            if (!IsPostBack)
            {
                txtDescripcion.Text = paquete.Descripcion;
                txtPrecio.Text = paquete.Precio.ToString();
                txtTitulo.Text = paquete.Titulo;

                foreach (Hotel h in hotelBll.BuscarTodos())
                {
                    bool isHotelSelected = false;
                    IList<Hotel> hoteles = paqueteBll.BuscarHotelesPorId(paqueteId);
                    foreach (Hotel hh in hoteles)
                        if (hh.Id == h.Id)
                            isHotelSelected = true;

                    ListItem i = new ListItem()
                    {
                        Text = h.Nombre + " - " + h.Precio,
                        Value = h.Id.ToString(),
                        Selected = isHotelSelected
                    };
                    lstHoteles.Items.Add(i);
                }

                foreach (Destino d in destinoBll.BuscarTodos())
                {
                    bool isDestinoSelected = false;
                    IList<Destino> destinos = paqueteBll.BuscarDestinosPorId(paqueteId);
                    foreach (Destino hh in destinos)
                        if (hh.Id == d.Id)
                            isDestinoSelected = true;
                    ListItem i = new ListItem()
                    {
                        Text = d.Descripcion,
                        Value = d.Id.ToString(),
                        Selected = isDestinoSelected
                    };
                    lstDestinos.Items.Add(i);
                }

                foreach (Vuelo h in vueloBll.BuscarTodos())
                {
                    bool isVueloSelected = false;
                    IList<Vuelo> vuelos = paqueteBll.BuscarVuelosPorId(paqueteId);
                    foreach (Vuelo hh in vuelos)
                        if (hh.Id == h.Id)
                            isVueloSelected = true;
                    ListItem i = new ListItem()
                    {
                        Text = h.Empresa + " - " + h.objOrigen.Codigo + " - " + h.objDestino.Codigo + " - " + h.Precio,
                        Value = h.Id.ToString(),
                        Selected = isVueloSelected
                    };
                    lstVuelos.Items.Add(i);
                }

                foreach (Tag h in tagBll.BuscarTodos())
                {
                    bool isTagSelected = false;
                    IList<Tag> tags = paqueteBll.BuscarTagsPorId(paqueteId);
                    foreach (Tag hh in tags)
                        if (hh.Id == h.Id)
                            isTagSelected = true;
                    ListItem i = new ListItem()
                    {
                        Text = h.Codigo,
                        Value = h.Id.ToString(),
                        Selected=isTagSelected
                    };
                    lstTags.Items.Add(i);
                }

            /*para mostrar la lista de imagenes en una tabla*/
            tblFotos.Rows.Clear();
            TableHeaderRow hrow = new TableHeaderRow();
            hrow.Cells.Add( new TableHeaderCell {Text = "Nombre"});
            hrow.Cells.Add( new TableHeaderCell {Text = "Fecha de Creacion"});
            hrow.Cells.Add( new TableHeaderCell {Text = ""});
            tblFotos.Rows.Add(hrow);

            IList<Foto> fotos = fotoBll.buscarPorPaqueteId(paqueteId);
            foreach (Foto h in fotos)
            {
                TableRow row = new TableRow();
                row.Cells.Add( new TableCell {Text = h.nombre});
                row.Cells.Add( new TableCell {Text = h.FechaCreacion.ToString()});
                tblFotos.Rows.Add(row);
            }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaqueteAbm.aspx", true);
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            var paqueteId = Int64.Parse(Request.QueryString["id"]);
            Paquete paquete = paqueteBll.BuscarPorId(paqueteId);
            paqueteBll.LimpiarReferencias(paquete);
            paqueteBll.Eliminar(paquete);
            Response.Redirect("PaqueteAbm.aspx", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var paqueteId = Int64.Parse(Request.QueryString["id"]);
            Paquete paquete = paqueteBll.BuscarPorId(paqueteId);
            paquete.Hoteles = lstHoteles.Items
                .Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(i => new Hotel
                {
                    Id = Int32.Parse(i.Value),
                })
                .ToList<Hotel>();

            paquete.Vuelos = lstVuelos.Items
                .Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(i => new Vuelo
                {
                    Id = Int32.Parse(i.Value),
                })
                .ToList<Vuelo>();

            paquete.Tags = lstTags.Items
                .Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(i => new Tag
                {
                    Id = Int32.Parse(i.Value),
                })
                .ToList<Tag>();

            paquete.Destinos = lstDestinos.Items
                .Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(i => new Destino
                {
                    Id = Int32.Parse(i.Value),
                })
                .ToList<Destino>();

            paquete.Precio = decimal.Parse(txtPrecio.Text);
            paquete.Descripcion = txtDescripcion.Text;
            paquete.Titulo = txtTitulo.Text;

            Paquete modificado = paqueteBll.Modificar(paquete);

            paquete.Fotos = ArmarFotos(files, modificado.Id);

            paqueteBll.AgregarFotos(paquete);

            Response.Redirect("PaqueteAbm.aspx", true);

        }

        private IList<Foto> ArmarFotos(FileUpload files, long entidadId)
        {
            IList<Foto> resultado = new List<Foto>();
            if ((files.PostedFiles != null) )
            {
                foreach (HttpPostedFile ff in files.PostedFiles)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~\\fotos\\paquete\\" + entidadId ));
                    string fn = System.IO.Path.GetFileName(ff.FileName);
                    string SaveLocation = Server.MapPath("~") + "\\fotos\\paquete\\" + entidadId + "\\" + fn;
                    Foto f = new Foto
                    {
                        nombre = fn,
                        path = "/fotos/paquete/" + entidadId + "/" + fn
                    };
                    f = fotoBll.Registrar(f);
                    try
                    {
                        ff.SaveAs(SaveLocation);
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
    }
}