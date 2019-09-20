using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class ServicioDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public bool Habilitado { get; set; }
        public List<CatalogoDto> Prendas { get; set; }

        public ServicioDto()
        {
            ID = -1;
            Prendas = new List<CatalogoDto>();
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
                ServicioDto s = (ServicioDto)obj;
                return ID == s.ID;
            }
        }
    }
}
