using BE;
using DAL;
using DAL.dominio;

namespace BLL.dominio
{
    public class ResenaBll : AbstractBll<Resena>
    {
        private ResenaDal resenaDal = new ResenaDal();
        public override DalGenerica<Resena> GetDal()
        {
            return resenaDal;
        }
        public new Resena Registrar(Resena resena)
        {
            return resenaDal.Registrar(resena);
        }
    }
}