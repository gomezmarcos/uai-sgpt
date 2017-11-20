using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.dominio;
using DAL.utilitarios;
using DAL;
using System.Data.SqlClient;

namespace BLL.dominio
{
    public class PaqueteBll : AbstractBll<Paquete>
    {
        private PaqueteDal dal = new PaqueteDal();
        private DestinoDal destinoDal = new DestinoDal();
        private TagDal tagDal = new TagDal();
        private HotelDal hotelDal = new HotelDal();
        private VueloDal vueloDal = new VueloDal();
        private FotoDal fotoDal = new FotoDal();

        public override DalGenerica<Paquete> GetDal()
        {
            return dal;
        }

        public new IList<Paquete> BuscarTodos()
        {
            IList<Paquete> paquetes = base.BuscarTodos();
            foreach (Paquete p in paquetes)
            {
                p.Destinos = this.BuscarDestinosPorId(p.Id);
                p.Tags = this.BuscarTagsPorId(p.Id);
                p.Vuelos = this.BuscarVuelosPorId(p.Id);
                p.Hoteles = this.BuscarHotelesPorId(p.Id);
                p.Fotos = this.BuscarFotosPorId(p.Id);
            }
            return paquetes;
        }

        public IList<Foto> BuscarFotosPorId(long id)
        {
            IList<Foto> resultado = new List<Foto>();
            IList<int> list = dal.BuscarFotosPorId(id);

            foreach (int tagId in list)
                resultado.Add(fotoDal.BuscarPorId(tagId));
            return resultado;
        }

        public IList<Hotel> BuscarHotelesPorId(long id)
        {
            IList<Hotel> resultado = new List<Hotel>();

            IList<int> list = dal.BuscarHotelesPorId(id);
            foreach (int tagId in list)
                resultado.Add(hotelDal.BuscarPorId(tagId));
            return resultado;
        }

        public IList<Tag> BuscarTagsPorId(long id)
        {
            IList<Tag> resultado = new List<Tag>();

            IList<int> list = dal.BuscarTagsPorId(id);
            foreach (int tagId in list)
                resultado.Add(tagDal.BuscarPorId(tagId));
            return resultado;
        }

        public IList<Vuelo> BuscarVuelosPorId(long id)
        {
            IList<Vuelo> resultado = new List<Vuelo>();

            IList<int> list = dal.BuscarVuelosPorId(id);
            foreach (int tagId in list)
                resultado.Add(vueloDal.BuscarPorId(tagId));
            return resultado;
        }

        public new Paquete Registrar(Paquete entity)
        {
            Paquete p = dal.Registrar(entity);
            entity.Id = p.Id;

            RegistrarTags(entity);
            RegistrarDestinos(entity);
            RegistrarHoteles(entity);
            RegistrarVuelos(entity);

            return entity;
        }

        public new Paquete Modificar(Paquete entity)
        {
            Paquete modificado = dal.Modificar(entity);
            LimpiarReferencias(modificado);

            RegistrarTags(entity);
            RegistrarDestinos(entity);
            RegistrarHoteles(entity);
            RegistrarVuelos(entity);

            return entity;
        }

        private void RegistrarFotos(Paquete paquete)
        {
            string Consulta = "insert into paquete_foto (paqueteId, fotoId) values (@P1, @P2)";
            foreach (Foto f in paquete.Fotos)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", paquete.Id);
                Params[1] = Helper.CrearParametro("@P2", f.Id);
                Helper.Create(Consulta, Params);
            }
        }

        private void RegistrarVuelos(Paquete entidad)
        {
            string Consulta = "insert into paquete_vuelo (paqueteId, vueloId) values (@P1, @P2)";
            foreach (Vuelo v in entidad.Vuelos)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", entidad.Id);
                Params[1] = Helper.CrearParametro("@P2", v.Id);
                Helper.Create(Consulta, Params);
            }
        }
        private void RegistrarTags(Paquete entidad)
        {
            string Consulta = "insert into paquete_Tag (paqueteId, tagId) values (@P1, @P2)";
            foreach (Tag tag in entidad.Tags)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", entidad.Id);
                Params[1] = Helper.CrearParametro("@P2", tag.Id);
                Helper.Create(Consulta, Params);
            }
        }

        private void RegistrarHoteles(Paquete entidad)
        {
            string Consulta = "insert into paquete_hotel (paqueteId, hotelId) values (@P1, @P2)";
            foreach (Hotel hotel in entidad.Hoteles)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", entidad.Id);
                Params[1] = Helper.CrearParametro("@P2", hotel.Id);
                Helper.Create(Consulta, Params);
            }
        }
        public IList<Destino> BuscarDestinosPorId(long id)
        {
            IList<Destino> resultado = new List<Destino>();

            IList<int> list = dal.BuscarDestinoPorId(id);
            foreach (int destinoId in list)
                resultado.Add(destinoDal.BuscarPorId(destinoId));
            return resultado;
        }

        public void LimpiarReferencias(Paquete paquete)
        {
            LimpiarTags(paquete);
            LimpiarFotos(paquete);
            LimpiarVuelos(paquete);
            LimpiarHoteles(paquete);
            LimpiarDestinos(paquete);
        }

        private void LimpiarDestinos(Paquete hotel)
        {
            string Consulta = "delete paquete_destino where paqueteId = " + hotel.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }
        private void LimpiarHoteles(Paquete hotel)
        {
            string Consulta = "delete paquete_hotel where paqueteId = " + hotel.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }

        private void LimpiarTags(Paquete hotel)
        {
            string Consulta = "delete paquete_Tag where paqueteId = " + hotel.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }

        private void LimpiarVuelos(Paquete hotel)
        {
            string Consulta = "delete paquete_Vuelo where paqueteId = " + hotel.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }
        private void RegistrarDestinos(Paquete entidad)
        {
            string Consulta = "insert into paquete_Destino (paqueteId, destinoId) values (@P1, @P2)";
            foreach (Destino destino in entidad.Destinos)
            {
                SqlHelper Helper = new SqlHelper();
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = Helper.CrearParametro("@P1", entidad.Id);
                Params[1] = Helper.CrearParametro("@P2", destino.Id);
                Helper.Create(Consulta, Params);
            }
        }

        public void AgregarFotos(Paquete paquete)
        {
            LimpiarFotos(paquete);
            RegistrarFotos(paquete);
        }

        private void LimpiarFotos(Paquete entidad)
        {
            string Consulta = "delete paquete_Foto where paqueteId = " + entidad.Id;
            SqlHelper Helper = new SqlHelper();
            Helper.Delete(Consulta, null);
        }
    }
}
