using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public enum MetodoPago
    {
        Efectivo,
        Tarjeta
    }
    public class Pago
    {
        public long ID { get; set; }
        public Nota Nota { get; set; }
        public MetodoPago Metodo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

    }
}
