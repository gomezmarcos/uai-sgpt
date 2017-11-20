using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.dominio
{
    public class TagDal : DalGenerica<Tag>
    {
        public override string GetTableNameFuck()
        {
            return "Tag";
        }
    }
}
