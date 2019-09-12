using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class ClienteDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }
        public EstadisticasCliente Estadisticas { get; set; }

        public ClienteDto()
        {
            ID = -1;
            Estadisticas = new EstadisticasCliente();
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
                ClienteDto c = (ClienteDto)obj;
                return ID == c.ID;
            }
        }
    }

    public class EstadisticasCliente
    {
        public DateTime Periodo = DateTime.Now.AddMonths(-1);
        public int NotasTotal;
        public int NotasPeriodo;
        public int ServiciosTotal;
        public int ServiciosPeriodo;
        public int PrendasTotal;
        public int PrendasPeriodo;
        public decimal MontoTotal;
        public decimal MontoPeriodo;
    }
}
