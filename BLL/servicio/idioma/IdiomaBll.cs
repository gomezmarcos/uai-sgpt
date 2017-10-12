using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.servicio.idioma;
using BE;
using DAL;
using DAL.servicio.idioma;

namespace BLL.servicio.idioma
{
    public class IdiomaBll : AbstractBll<Idioma>
    {
        IdiomaDal idiomaDal = new IdiomaDal();
        EntradaBll entradaBll = new EntradaBll();

        public override DalGenerica<Idioma> GetDal()
        {
            return idiomaDal;
        }

        public Idioma ObtenerPorUsuario(Usuario usuario)
        {
            int IdiomaId =  idiomaDal.ObtenerIdiomaPorUsuario(usuario); //lo saca de la tabla USUARIO_IDIOMA, no de idioma.
            
            Dictionary<string, object> propiedades = new Dictionary<string, object>();
            propiedades.Add("fk_idioma", IdiomaId);
            IList<Entrada> entradas = entradaBll.BuscarTodos(propiedades);

            Idioma idioma = base.BuscarPorId(usuario.Id);
            idioma.Entradas = entradas;

            return idioma;
        }
    }
}
