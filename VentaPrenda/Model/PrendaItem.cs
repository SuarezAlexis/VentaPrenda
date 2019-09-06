using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public class PrendaItem
    {
        public long ID { get; set; }
        public Nota Nota { get; set; }
        public int Cantidad { get; set; }
        public Prenda Prenda { get; set; }
        public TipoPrenda TipoPrenda { get; set; }
        public Color Color { get; set; }
        public List<ServicioItem> Servicios { get; set; }
    }

    public class ServicioItem
    {
        public long ID { get; set; }
        public PrendaItem PrendaItem { get; set; }
        public int Cantidad { get; set; }
        public Servicio Servicio { get; set; }
        public decimal Monto { get; set; }
        public Descuento Descuento { get; set; }
        public Usuario Encargado { get; set; }

    }
}
