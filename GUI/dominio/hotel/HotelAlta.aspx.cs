using BE;
using BLL.dominio;
using BLL.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.dominio.hotel
{
    public partial class HotelAlta : System.Web.UI.Page
    {
        TagBll tagBll = new TagBll();
        HotelBll hotelBll = new HotelBll();
        DestinoBll destinoBll = new DestinoBll();
        FotoBll fotoBll = new FotoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Destino d in destinoBll.BuscarTodos())
            {
                ListItem item = new ListItem();
                item.Value = d.Id.ToString();
                item.Text = d.Descripcion;
                lstDestinos.Items.Add(item);
            }

            foreach (Tag t in tagBll.BuscarTodos())
            {
                ListItem item = new ListItem();
                item.Value = t.Id.ToString();
                item.Text = t.Codigo;
                chkTags.Items.Add(item);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Hotel h = new Hotel();
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
            Hotel hh = hotelBll.Registrar(h);

            h.fotos = ArmarFotos(files, hh.Id);

            hotelBll.AgregarFotos(h);

            Response.Redirect("HotelAbm.aspx", true);
        }

        private IList<Foto> ArmarFotos(FileUpload files, long hotelId)
        {
            IList<Foto> resultado = new List<Foto>();
            if ((files.PostedFiles != null) )
            {
                foreach (HttpPostedFile ff in files.PostedFiles)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~") + @"\fotos\hotel\" + hotelId );

                    string fn = System.IO.Path.GetFileName(ff.FileName);
                    string SaveLocation = Server.MapPath("~") + @"\fotos\hotel\" + hotelId + "\\" + fn;
                    Foto f = new Foto
                    {
                        nombre = fn,
                        path = "/fotos/hotel/" + hotelId + "/" + fn
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HotelAbm.aspx", true);
        }
    }
}