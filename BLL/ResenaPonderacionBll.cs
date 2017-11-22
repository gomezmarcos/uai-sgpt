using System;
using BE;
using DAL;
using DAL.dominio;
using System.Collections.Generic;

namespace BLL.dominio
{
    public class ResenaPonderacionBll : AbstractBll<ResenaPonderacion>
    {
        private ResenaPonderacionDal resenaDal = new ResenaPonderacionDal();
        private HotelBll hotelBll = new HotelBll();
        private ResenaBll resenaBll = new ResenaBll();
        public override DalGenerica<ResenaPonderacion> GetDal()
        {
            return resenaDal;
        }

        public void CalcularRanking(ResenaPonderacion ponderacion)
        {
            foreach(Hotel h in hotelBll.BuscarTodos())
            {
                IList<Resena> resenas = resenaBll.BuscarTodos(new System.Collections.Generic.Dictionary<string, object>()
                {
                    { "hotelId", h.Id }
                });
                int AcumuladoLimpieza = 0;
                int AcumuladoUbicacion = 0;
                int AcumuladoPrecio = 0;
                int AcumuladoAtencion = 0;
                foreach (Resena r in resenas)
                {
                    AcumuladoAtencion += r.Atencion;
                    AcumuladoLimpieza += r.Limpieza;
                    AcumuladoPrecio += r.Precio;
                    AcumuladoUbicacion += r.Ubicacion;
                }
                int Cantidad = resenas.Count;
                if (Cantidad > 0 )
                {
                    int resultado = AcumuladoUbicacion / Cantidad * ponderacion.Ubicacion / 10;
                    resultado += AcumuladoPrecio / Cantidad * ponderacion.Precio / 10;
                    resultado += AcumuladoLimpieza / Cantidad * ponderacion.Limpieza / 10;
                    resultado += AcumuladoAtencion / Cantidad * ponderacion.Atencion / 10;
                    h.Puntos = resultado;
                } else
                {
                    h.Puntos = 1;
                }
                hotelBll.ActualizarPuntaje(h);
            }
        }
    }
}