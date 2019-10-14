﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class ColoresGUIDto
    {
        public System.Drawing.Color FondoVentana { get; set; }
        public System.Drawing.Color FondoBoton { get; set; }
        public System.Drawing.Color FondoBotonActivo { get; set; }
        public System.Drawing.Color Cancelado { get; set; }
        public System.Drawing.Color Pendiente { get; set; }
        public System.Drawing.Color Terminado { get; set; }
        public System.Drawing.Color Entregado { get; set; }
        public System.Drawing.Color Caducado { get; set; }

        public ColoresGUIDto()
        {
            FondoVentana = SystemColors.Control;
            FondoBoton = SystemColors.ControlLight;
            FondoBotonActivo = SystemColors.ControlDark;
            Cancelado = System.Drawing.Color.Pink;
            Pendiente = System.Drawing.Color.LightYellow;
            Terminado = System.Drawing.Color.LightCyan;
            Entregado = System.Drawing.Color.Honeydew;
            Caducado = System.Drawing.Color.Thistle;
        }
    }
}
