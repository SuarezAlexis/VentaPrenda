using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class HistorialDto
    {
        public long ID { get; set; }
        public UsuarioDto Usuario { get; set; }
        public String Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public List<DatoHistorialDto> Cambios { get; set; }

        public HistorialDto() { ID = -1; Cambios = new List<DatoHistorialDto>(); }

        public override string ToString()
        {
            return ID + " " + Concepto + " " + Fecha.ToShortDateString();
        }
    }

    public class DatoHistorialDto
    {
        public long ID { get; set; }
        public HistorialDto Historial { get; set; }
        public char Operacion { get; set; }
        public String Tabla { get; set; }
        public String Columna { get; set; }
        public String Valor { get; set; }

        public DatoHistorialDto() { ID = -1; }
    }
}
