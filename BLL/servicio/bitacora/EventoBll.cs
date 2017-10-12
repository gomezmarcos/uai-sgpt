using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.bitacora;
using DAL.servicio.bitacora;
using DAL;

namespace BLL.servicio.bitacora
{
    public class EventoBll : AbstractBll<Evento>
    {
        private EventoDal eventoDal = new EventoDal();
        public override DalGenerica<Evento> GetDal()
        {
            return eventoDal;
        }
    }
}
