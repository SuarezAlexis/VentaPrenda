using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public class Historial
    {
        public long ID { get; set; }
        public Usuario Usuario { get; set; }
        public String Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public List<DatoHistorial> Cambios { get; set; }
    }

    public class DatoHistorial
    {
        public long ID { get; set; }
        public Historial Historial { get; set; }
        public char Operacion { get; set; }
        public String Tabla { get; set; }
        public String Columna { get; set; }
        public String Valor { get; set; }

    }
}
