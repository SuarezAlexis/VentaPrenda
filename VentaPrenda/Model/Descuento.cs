using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public class Descuento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime VigenciaInicio { get; set; }
        public DateTime VigenciaFin { get; set; }
        public decimal MontoMinimo { get; set; }
        public decimal CantMinima { get; set; }
        public bool SoloNota { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Unidades { get; set; }
    }
}
