using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.servicio.autorizacion
{
    public class PatenteRama : IBusinessEntity, IPatente, IComparable<PatenteRama>
    {
        public string Codigo { get; set; }
        public HashSet<IPatente> Patentes { get; set; }
//        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }

        public PatenteRama()
        {
            this.Patentes = new HashSet<IPatente>();
            this.Tipo = "rama";
        }

        public string GetCodigoPatente()
        {
            return this.Codigo;
        }

        public void agregarHijo(IPatente hijo)
        {
            this.Patentes.Add(hijo);
        }

        public bool EsPatenteValidaParaElUsuario(string codigoPatente)
        {
            if (codigoPatente.ToLower() == GetCodigoPatente().ToLower())
            {
                return true;
            }
            foreach (IPatente p in Patentes)
            {
                if (p.EsPatenteValidaParaElUsuario(codigoPatente))
                {
                    return true;
                }
            };
            return false;
        }

        public int CompareTo(PatenteRama other)
        {
            return this.Codigo.CompareTo(other.Codigo);
        }

        public List<string> GetCodigoPatenteComoLista()
        {
            List<string> lista = new List<string>();
            foreach (IPatente p in Patentes)
            {
                lista.AddRange(p.GetCodigoPatenteComoLista());
            }
            return lista;
        }
    }
}
