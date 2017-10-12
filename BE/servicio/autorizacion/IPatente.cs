using System.Collections.Generic;

namespace BE.servicio.autorizacion
{
    public interface IPatente
    {
        bool EsPatenteValidaParaElUsuario(string codigoPatente);
        string GetCodigoPatente();
        void agregarHijo(IPatente hijo);
        List<string> GetCodigoPatenteComoLista();
    }
}