using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.verificacion;

namespace BLL.servicio.verificacion
{
    public interface VerificacionRecalculable
    {
        void Recalcular<T>() where T : IVerificable;
    }
}
