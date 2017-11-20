using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.dominio;
using DAL;

namespace BLL.dominio
{
    public class TagBll : AbstractBll<Tag>
    {
        private TagDal tagDal = new TagDal();
        public override DalGenerica<Tag> GetDal()
        {
            return tagDal;
        }
    }
}
