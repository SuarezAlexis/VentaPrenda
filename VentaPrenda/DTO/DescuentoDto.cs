using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class DescuentoDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime VigenciaInicio { get; set; }
        public DateTime VigenciaFin { get; set; }
        public decimal MontoMinimo { get; set; }
        public bool SoloNota { get; set; }
        public decimal CantMinima { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Unidades { get; set; }

        public DescuentoDto()
        {
            ID = -1;
            Nombre = "Ninguno";
        }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            else
            {
                if (this == obj) return true;
                DescuentoDto d = (DescuentoDto)obj;
                return ID == d.ID;
            }
        }
    }
}
