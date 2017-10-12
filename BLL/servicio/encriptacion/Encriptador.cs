using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.servicio.encriptacion
{
    public class Encriptador
    {
        public static String Encriptar(String valor)
        {
            byte[] hash =  MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(valor));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                builder.Append(hash[i].ToString("x2"));

            return builder.ToString();
        }
    }
}
