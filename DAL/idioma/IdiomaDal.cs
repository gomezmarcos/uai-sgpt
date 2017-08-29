using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.idioma;

namespace DAL.idioma
{
    public class IdiomaDal
    {
        public Idioma Traducir(string Cultura, string Pagina)
        {
            string Consulta = "SELECT OBJ_CONTROL AS CONTROL, OBJ_TEXTO AS TEXTO FROM OBJETO " +
                "WHERE IDIOMA_ID=@P1 AND OBJ_PAGINA=@P2";
            SqlHelper Helper = new SqlHelper();
            SqlParameter[] Params = new SqlParameter[2];
            Params[0] = Helper.CrearParametro("@P1", Cultura);
            Params[1] = Helper.CrearParametro("@P2", Pagina);
            DataTable dt = Helper.Retrieve(Consulta, Params);
            Control Control = null;
            List<Control> Controles = new List<Control>();

            foreach (DataRow fila in dt.Rows)
            {
                Control = new Control();
                Control.Nombre = fila["CONTROL"].ToString();
                Control.Texto = fila["TEXTO"].ToString();
                Control.Pagina = Pagina;
                Controles.Add(Control);
            }

            Idioma Idioma = new Idioma();
            Idioma.Cultura = Cultura;
            Idioma.Controles = Controles;
            return Idioma;
        }
    }
}
