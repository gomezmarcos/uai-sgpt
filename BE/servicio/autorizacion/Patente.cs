using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.servicio.autorizacion
{
    public class Patente : IBusinessEntity, IPatente, IComparable<Patente>
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }

        public void agregarHijo(IPatente hijo)
        {
            //do nothing :) //Necesario para armar arbol de permisos
        }

        public string GetCodigoPatente()
        {
            return Codigo;
        }

        public bool EsPatenteValidaParaElUsuario(string codigoPatente)
        {
            return this.Codigo.ToLower().Equals(codigoPatente.ToLower());
        }

        public int CompareTo(Patente other)
        {
            return this.Codigo.CompareTo(other.Codigo);
        }

        public List<string> GetCodigoPatenteComoLista()
        {
            List<string> lista = new List<string>();
            lista.Add(this.Codigo);
            return lista;
        }

        public List<long> GetIdPatenteComoLista()
        {
            List<long> lista = new List<long>();
            lista.Add(this.Id);
            return lista;
        }
    }
}
