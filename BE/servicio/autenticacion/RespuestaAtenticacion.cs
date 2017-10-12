namespace BE.servicio.autenticacion
{
    public class RespuestaAtenticacion
    {
        public bool EsExitosa{ get; set; }
        public string MensajeError { get; set; }

        public RespuestaAtenticacion(bool respuesta, string mensajeError)
        {
            this.EsExitosa = respuesta;
            this.MensajeError = mensajeError;
        }
    }
}