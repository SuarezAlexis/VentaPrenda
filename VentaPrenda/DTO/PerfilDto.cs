using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Model;

namespace VentaPrenda.DTO
{
    public class PerfilDto
    {
        public short ID { get; set; }
        public string Nombre { get; set; }
        public Permisos Permisos { get; set; }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Nombre) ? "" : Nombre;
        }
    }
}
