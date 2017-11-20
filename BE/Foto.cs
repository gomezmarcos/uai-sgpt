using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Foto : IBusinessEntity
    {
        public String nombre { get; set; }
        public String path { get; set; }
    }
}
