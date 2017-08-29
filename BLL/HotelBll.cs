using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    //public class HotelBll : IGenericInterface<Hotel>
    public class HotelBll : AbstractBll<Hotel>
    {
        private DalGenerica<Hotel> dal = new HotelDal();

        public override DalGenerica<Hotel> GetDal()
        {
            return dal;
        }
    }
}
