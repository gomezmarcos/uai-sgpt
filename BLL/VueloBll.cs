using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL.dominio
{
    public class VueloBll : AbstractBll<Vuelo>
    {
        private VueloDal dal = new VueloDal();
        public override DalGenerica<Vuelo> GetDal()
        {
            return dal;
        }

        public new Vuelo Registrar(Vuelo vuelo)
        {
            Vuelo guardado = dal.Registrar(vuelo);
            dal.RegistrarDestinos(vuelo);
            return guardado;
        }

        public new IList<Vuelo> BuscarTodos()
        {
            IList<Vuelo> vuelos =  dal.BuscarTodos();
            foreach (Vuelo v in vuelos )
            {
                IList<Destino> destinos = dal.BuscarOrigenAndDestino(v);
                v.objOrigen = destinos[0];
                v.objDestino = destinos[1];
            }
            return vuelos;
        }

        public new Vuelo BuscarPorId(long vueloId)
        {
            Vuelo v = base.BuscarPorId(vueloId);
            IList<Destino> destinos = dal.BuscarOrigenAndDestino(v);
            v.objOrigen = destinos[0];
            v.objDestino = destinos[1];
            return v;
        }

        public void EliminarDestinos(Vuelo vuelo)
        {
            dal.EliminarDestinos(vuelo);
        }

        public new Vuelo Modificar(Vuelo vuelo)
        {
            EliminarDestinos(vuelo);
            Vuelo v = base.Modificar(vuelo);
            dal.RegistrarDestinos(vuelo);
            return v;
        }
    }
}
