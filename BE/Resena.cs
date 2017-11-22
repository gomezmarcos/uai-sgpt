﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Resena : IBusinessEntity
    {
        public int Limpieza { get; set; }
        public int Ubicacion { get; set; }
        public int Precio { get; set; }
        public int Atencion { get; set; }
        public Usuario objUsuario { get; set; }
        public Hotel objHotel { get; set; }
        public string descripcion { get; set; }
    }
}
