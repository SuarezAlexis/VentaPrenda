using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public enum TipoReporte
    {
        Clientes,
        Ingresos
    }

    public class ReporteDto
    {
        public DateTime Desde;
        public DateTime Hasta;
        public TipoReporte Tipo;
    }
}
