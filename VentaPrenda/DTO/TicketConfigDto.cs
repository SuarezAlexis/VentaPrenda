using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class TicketConfigDto
    {
        public String Encabezado { get; set; }
        public String Pie { get; set; }
        public String PrinterName { get; set; }
        public Image Logo { get; set; }
        public int Ancho { get; set; }
    }
}
