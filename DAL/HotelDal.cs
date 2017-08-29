using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HotelDal : DalGenerica<Hotel>
    {
        public override string GetTableNameFuck()
        {
            return "Hotel";
        }
    }
}
