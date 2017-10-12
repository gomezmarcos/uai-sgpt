using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.bitacora;
using System.Collections;

namespace BLL.servicio.bitacora
{
    public class Bitacora
    {
        private EventoBll eventoBll = new EventoBll();
        public void RegistrarEvento(Evento evento)
        {
            eventoBll.Registrar(evento);
        }

        public IList<Evento> buscarTodos()
        {
            return eventoBll.BuscarTodos();
        }

        public IList<Evento> buscarTodos(Dictionary<string, object> propiedades)
        {
            return eventoBll.BuscarTodos(propiedades);
        }

        public IList<Evento> buscarTodosConLike(Dictionary<string, object> prop)
        {
            return eventoBll.BuscarTodosConLike(prop);
        }
    }
}
