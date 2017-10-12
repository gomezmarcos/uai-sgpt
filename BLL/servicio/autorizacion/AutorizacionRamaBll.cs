using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BE.servicio.autorizacion;
using DAL;
using DAL.servicio.autorizacion;
using BE;

namespace BLL.servicio.autorizacion
{
    public class AutorizacionRamaBll : AbstractBll<PatenteRama>
    {
        private AutorizacionRamaDal autorizacionDal = new AutorizacionRamaDal();
        private AutorizacionDal dal = new AutorizacionDal();
        public override DalGenerica<PatenteRama> GetDal()
        {
            return autorizacionDal;
        }

        public new PatenteRama Modificar(PatenteRama rama)
        {
            base.Modificar(rama);
            EliminarHijos(rama);
            this.RegistrarHijos(rama);
            return (PatenteRama)ObtenerPatentePorPatente(rama.Id);
        }

        public new void Eliminar(PatenteRama rama)
        {
            base.Eliminar(rama);
            EliminarHijos(rama);
        }

        private void EliminarHijos(PatenteRama rama)
        {
            dal.Eliminar(new Dictionary<String, object>
                {
                    { "fk_patente", rama.Id }
                });
        }

        public void RegistrarHijos(PatenteRama patente)
        {
            autorizacionDal.RegistrarHijos(patente);
        }

        public IPatente ObtenerPatentePorPatente(long ramaId)
        {
            PatenteRama rama = BuscarPorId(ramaId);
            ArmarHijos(rama, rama.Id);
            return rama;
        }

            private void ArmarHijos(IPatente patente, long patenteId)
        {
            IList<Patente> patentes = dal.BuscarTodos(new Dictionary<String, object>
                {
                    { "fk_patente", patenteId }
                }
            );

            foreach (Patente p in patentes)
            {
                if (p.Tipo == "rama")
                {
                    PatenteRama pr = new PatenteRama
                    {
                        Id = p.Id,
                        Codigo = p.Codigo,
                    };
                    ArmarHijos(pr, pr.Id);
                    patente.agregarHijo(pr);
                }
                else
                    patente.agregarHijo(p);
            }
        }
    }
}