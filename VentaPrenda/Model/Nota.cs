using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public enum Estatus
    {
        Cancelado,
        Pendiente,
        Terminado,
        Entregado,
        Caducado
    }
    public class Nota
    {
        public long ID { get; set; }
        public Estatus Estatus { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Recibido { get; set; }
        public DateTime Entregado { get; set; }
        public List<Pago> Pagos { get; set; }
        public List<PrendaItem> Prendas { get; set; }
        public string Observaciones { get; set; }
        public Descuento Descuento { get; set; }
    }
}
