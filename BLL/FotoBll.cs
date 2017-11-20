using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DAL.dominio;
using System.Data.SqlClient;
using DAL.utilitarios;

namespace BLL.util
{
    public class FotoBll : AbstractBll<Foto>
    {
        private FotoDal dal = new FotoDal();
        public override DalGenerica<Foto> GetDal()
        {
            return dal;
        }

        public IList<Foto> buscarPorHotelId(long hotelId)
        {
            return dal.buscarPorHotelId(hotelId);
        }

        public IList<Foto> buscarPorPaqueteId(long paqueteId)
        {
            return dal.buscarPorPaqueteId(paqueteId);
        }
    }
}
