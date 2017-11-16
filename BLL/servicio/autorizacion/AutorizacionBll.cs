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
    public class AutorizacionBll : AbstractBll<Patente>
    {
        private AutorizacionDal autorizacionDal = new AutorizacionDal();
        private AutorizacionRamaBll autorizacionRamaBll = new AutorizacionRamaBll();
        public override DalGenerica<Patente> GetDal()
        {
            return autorizacionDal;
        }

        /**
         * 
         * Al usar este metodo se traen todos los permisos anidados del usuario.
         *  -Si el usuario tiene un permiso hijo, pero no a su padre el mismo no se podra acceder.
         *  Esto es asi porque si no tiene el permiso padre, no busca las patentes que este contiene.
         * 
         * */
        public IPatente ObtenerPatentePorUsuario(Usuario usuario)
        {
            IList<PatenteRama> ramas = BuscarPatentesRama(usuario);
            foreach (var rama in ramas)
                ArmarHijos(rama, rama.Id, usuario);

            PatenteRama patenteReturn = new PatenteRama();
            patenteReturn.Codigo = "RAIZ";
            foreach (var r in ramas)
                patenteReturn.agregarHijo(r);
            return patenteReturn;
        }

        public IPatente ObtenerPatentePorPatente(long ramaId)
        {
            PatenteRama rama = autorizacionRamaBll.BuscarPorId(ramaId);
            ArmarHijos(rama, rama.Id);
            return rama;
        }

        public IList<long> BuscarIdPatentes(Usuario usuario)
        {
            return autorizacionDal.BuscarIdPatentes(usuario);
        }

        private IList<PatenteRama > BuscarPatentesRama(Usuario usuario)
        {
            IList<Patente> patentes = autorizacionDal.BuscarTodos(new Dictionary<String, object>
                {
                    { "tipo", "rama" }
                }
            );
            IList<PatenteRama> resultado = new List<PatenteRama>();
            foreach (var p in patentes)
                if (BuscarIdPatentes(usuario).Contains(p.Id))
                    resultado.Add(new PatenteRama
                    {
                        Id = p.Id,
                        Codigo = p.Codigo,
                    });
            return resultado;
        }

        public IList<Patente > BuscarPatentesRama()
        {
            IList<Patente> patentes = autorizacionDal.BuscarTodos(new Dictionary<String, object>
                {
                    { "tipo", "rama" }
                }
            );
            IList<Patente> resultado = new List<Patente>();
            foreach (var p in patentes)
                resultado.Add(new Patente
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Descripcion = p.Descripcion
                });
            return resultado;
        }

        private void ArmarHijos(IPatente patente, long patenteId, Usuario usuario)
        {
            IList<Patente> patentes = autorizacionDal.BuscarTodos(new Dictionary<String, object>
                {
                    { "fk_patente", patenteId }
                }
            );

            foreach (Patente p in patentes)
            {
                //if (!BuscarIdPatentes(usuario).Contains(p.Id))
                //    continue;
                if (p.Tipo == "rama")
                {
                    PatenteRama pr = new PatenteRama
                    {
                        Id = p.Id,
                        Codigo = p.Codigo,
                    };
                    ArmarHijos(pr, pr.Id, usuario);
                    patente.agregarHijo(pr);
                }
                else
                    patente.agregarHijo(p);
            }
        }

        private void ArmarHijos(IPatente patente, long patenteId)
        {
            IList<Patente> patentes = autorizacionDal.BuscarTodos(new Dictionary<String, object>
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