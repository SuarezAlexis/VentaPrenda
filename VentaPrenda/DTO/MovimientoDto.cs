using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class MovimientoDto
    {
        public long ID { get; set; }
        public string Concepto { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public override string ToString()
        {
            return Concepto;
        }
    }
}
