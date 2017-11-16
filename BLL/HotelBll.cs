using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL.servicio.dominio
{
    public class HotelBll : AbstractBll<Hotel>
    {
        private HotelDal hotelDal = new HotelDal();
        private DestinoDal destinoDal = new DestinoDal();
        public override DalGenerica<Hotel> GetDal()
        {
            return hotelDal;
        }

        public List<Hotel> buscarPorDestino(String destino)
        {
            Dictionary<String, Object> properties = new Dictionary<String, Object>();
            properties.Add("descripcion", destino);

            List<Hotel> hotelesResultado = new List<Hotel>();
            foreach (Destino d in destinoDal.BuscarTodosConLike(properties))
            {
                hotelDal.buscarTodosPorDestinoId(d.Id);
            }
            return hotelesResultado;
        }

        public List<Hotel> buscarPorDestino(long destinoId)
        {
            return hotelDal.buscarTodosPorDestinoId(destinoId);
        }
    }
}
