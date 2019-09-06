using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Model;

namespace VentaPrenda.DTO
{
    public class PagoDto
    {
        public long ID { get; set; }
        public NotaDto Nota { get; set; }
        public MetodoPago Metodo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public PagoDto()
        {
            ID = -1;
            Fecha = DateTime.Now;
        }

        public PagoDto(NotaDto nota) : this()
        { Nota = nota; }
        public override string ToString()
        {
            return "$ " + Monto + " " + Metodo;
        }
    }
}
