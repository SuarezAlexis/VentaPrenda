﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
