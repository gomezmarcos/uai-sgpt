using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.servicio.idioma;
using BLL.servicio.bitacora;
using BLL.servicio.encriptacion;
using BLL.servicio.autenticacion;
using BLL.servicio.autorizacion;
using BE;
using BE.servicio.idioma;
using BE.servicio.bitacora;
using BE.servicio.autorizacion;
using System.IO;
using GUI.utiliadad;
using BLL.servicio.dominio;

namespace GUI
{
    public partial class Contact : Page
    {
        UsuarioBll usuarioBll = new UsuarioBll();
        HotelBll hotelBll = new HotelBll();
        IdiomaBll idiomaBll = new IdiomaBll();
        BLL.servicio.bitacora.Bitacora bitacora = new BLL.servicio.bitacora.Bitacora();
        AutenticacionBll autenticacionBll = new AutenticacionBll();
        AutorizacionBll autorizacionBll = new AutorizacionBll();

        protected void Page_Load(object sender, EventArgs ee)
        {
            IList<Hotel> hoteles = hotelBll.BuscarTodos();
            Hotel h = hotelBll.BuscarPorId(2);

            Evento e = new Evento();
            e.Autor = "Dago";
            e.Modulo = "hash";
            e.Descripcion = Encriptador.Encriptar("hi");
            bitacora.RegistrarEvento(e);

            IPatente patente = autorizacionBll.ObtenerPatentePorUsuario(usuarioBll.BuscarPorId(1));


            IList<Usuario> usuarios = usuarioBll.BuscarTodos();
            

        }
    }
}