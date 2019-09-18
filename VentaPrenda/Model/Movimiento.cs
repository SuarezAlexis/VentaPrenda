using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public class Movimiento
    {
        public long ID { get; set; }
        public string Concepto { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string NumFactura { get; set; }
        public string RFC { get; set; }
        public DateTime FechaFactura { get; set; }
        public bool Deducible { get { return !String.IsNullOrEmpty(NumFactura); } }
    }
}
