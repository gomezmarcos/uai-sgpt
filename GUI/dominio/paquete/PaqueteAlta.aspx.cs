using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.dominio;
using BE;
using BLL.util;

namespace GUI.dominio.paquete
{
    public partial class PaqueteAlta : System.Web.UI.Page
    {
        private HotelBll hotelBll = new HotelBll();
        private PaqueteBll paqueteBll = new PaqueteBll();
        private TagBll tagBll = new TagBll();
        private VueloBll vueloBll = new VueloBll();
        private FotoBll fotoBll = new FotoBll();
        private DestinoBll destinoBll = new DestinoBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Hotel h in hotelBll.BuscarTodos())
            {
                ListItem i = new ListItem()
                {
                    Text = h.Nombre + " - " + h.Precio,
                    Value = h.Id.ToString()
                };
                lstHoteles.Items.Add(i);
            } 

            foreach(Destino d in destinoBll.BuscarTodos())
            {
                ListItem i = new ListItem()
                {
                    Text = d.Descripcion ,
                    Value = d.Id.ToString()
                };
                lstDestinos.Items.Add(i);
            }

            foreach(Vuelo h in vueloBll.BuscarTodos())
            {
                ListItem i = new ListItem()
                {
                    Text = h.Empresa + " - " + h.objOrigen.Codigo + " - " + h.objDestino.Codigo + " - " + h.Precio,
                    Value = h.Id.ToString()
                };
                lstVuelos.Items.Add(i);
            }

            foreach(Tag h in tagBll.BuscarTodos())
            {
                ListItem i = new ListItem()
                {
                    Text = h.Codigo,
                    Value = h.Id.ToString()
                };
                lstTags.Items.Add(i);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaqueteAbm.aspx", true);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete();
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

            Paquete guardado = paqueteBll.Registrar(paquete);

            paquete.Fotos = ArmarFotos(files, guardado.Id);

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