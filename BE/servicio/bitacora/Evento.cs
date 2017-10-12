using BE;

namespace BE.servicio.bitacora
{
    public class Evento : IBusinessEntity
    {
        public string Autor { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
    }
}