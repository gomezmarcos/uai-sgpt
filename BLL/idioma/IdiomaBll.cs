using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.idioma;
using DAL.idioma;

namespace BLL.idioma
{
    class IdiomaBll
    {
        IdiomaDal dal = new IdiomaDal();
        public Idioma Traducir(string Cultura, string Pagina)
        {
            return dal.Traducir(Cultura, Pagina);
        }
    }
}
