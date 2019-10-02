using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Model;

namespace VentaPrenda.DTO
{
    public class NotaDto
    {
        public static List<ClienteDto> Clientes { get; set; }
        public static List<DescuentoDto> Descuentos { get; set; }
        public long ID { get; set; }
        public Estatus Estatus { get; set; }
        public ClienteDto Cliente { get; set; }
        public DateTime Recibido { get; set; }
        public DateTime Entregado { get; set; }
        public List<PagoDto> Pagos { get; set; }
        public List<PrendaItemDto> Prendas { get; set; }
        public string Observaciones { get; set; }
        public DescuentoDto Descuento { get; set; }
        public Usuario Recibio { get; set; }

        public NotaDto()
        {
            ID = -1;
            Pagos = new List<PagoDto>();
            Prendas = new List<PrendaItemDto>();
        }


        public override string ToString()
        {
            return "Nota " + ID + " - " + Cliente;
        }
    }
}
