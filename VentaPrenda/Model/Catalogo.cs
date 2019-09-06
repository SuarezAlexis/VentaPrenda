using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public interface Catalogo
    {
        short ID { get; set; }
        string Nombre { get; set; }

        bool Habilitado { get; set; }

    }

    public class Color : Catalogo
    {
        public short ID { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
    }

    public class Prenda : Catalogo
    {
        public short ID { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
    }

    public class TipoPrenda : Catalogo
    {
        public short ID { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
    }
}
