using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DAL.dominio;
using System.Data.SqlClient;

namespace BLL.dominio
{
    public class HotelBll : AbstractBll<Hotel>
    {
        private HotelDal hotelDal = new HotelDal();
        private DestinoDal destinoDal = new DestinoDal();
        public override DalGenerica<Hotel> GetDal()
        {
            return hotelDal;
        }
        public new Hotel Registrar(Hotel entity)
        {
            Hotel h = hotelDal.Registrar(entity);
            entity.Id = h.Id;

            RegistrarTags(entity);
            RegistrarDestinos(entity);

            return entity;
        }

        public new Hotel Modificar(Hotel entity)
        {
            Hotel h = hotelDal.Modificar(entity);
            entity.Id = h.Id;

            LimpiarDestinos(entity);
            LimpiarTags(entity);

            if (entity.fotos.Count > 0 )
            {
                LimpiarFotos(entity);
                RegistrarFotos(entity);
            }

            RegistrarTags(entity);
            RegistrarDestinos(entity);

            return entity;
        }

        private void RegistrarFotos(Hotel hotel)
        {
            string Consulta = "insert into Hotel_foto (hotelId, fotoId) values (@P1, @P2)";
            foreach (Foto f in hotel.fotos)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", hotel.Id);
                Params[1] = Helper.CrearParametro("@P2", f.Id);
                Helper.Create(Consulta, Params);
            }
        }

        private void LimpiarFotos(Hotel hotel)
        {
            string Consulta = "delete Hotel_Foto where hotelId = " + hotel.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }

        public new int Eliminar(Hotel entity)
        {
            int result = hotelDal.Eliminar(entity);
            LimpiarDestinos(entity);
            LimpiarTags(entity);
            return result;
        }

        private void LimpiarDestinos(Hotel hotel)
        {
            string Consulta = "delete Hotel_Destino where hotel_Id = " + hotel.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }

        public void AgregarFotos(Hotel h)
        {
            LimpiarFotos(h);
            RegistrarFotos(h);
        }

        private void LimpiarTags(Hotel hotel)
        {
            string Consulta = "delete Hotel_Tag where hotelId = " + hotel.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }

        private void RegistrarTags(Hotel hotel)
        {
            string Consulta = "insert into Hotel_Tag (hotelId, tagId) values (@P1, @P2)";
            foreach (Tag tag in hotel.tags)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", hotel.Id);
                Params[1] = Helper.CrearParametro("@P2", tag.Id);
                Helper.Create(Consulta, Params);
            }
        }

        private void RegistrarDestinos(Hotel hotel)
        {
            string Consulta = "insert into Hotel_Destino (hotel_Id, destino_id) values (@P1, @P2)";
            foreach (Destino destino in hotel.destinos)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", hotel.Id);
                Params[1] = Helper.CrearParametro("@P2", destino.Id);
                Helper.Create(Consulta, Params);
            }
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

        public bool existeRelacionConDestino(long hotelId, long destinoId)
        {
            return hotelDal.ExisteRelacionConDestino(hotelId, destinoId);
        }

        public bool existeRelacionConTag(long hotelId, long tagId)
        {
            return hotelDal.ExisteRelacionConTag(hotelId, tagId);
        }

        public List<Hotel> buscarPorDestino(long destinoId)
        {
            return hotelDal.buscarTodosPorDestinoId(destinoId);
        }
    }
}
