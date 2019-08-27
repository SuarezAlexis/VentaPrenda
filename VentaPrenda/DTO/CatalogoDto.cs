using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DTO
{
    public class CatalogoDto
    {
        public short ID { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public CatalogoDto() { }

        public CatalogoDto(CatalogoDto c)
        {
            this.ID = c.ID;
            this.Nombre = c.Nombre;
            this.Habilitado = c.Habilitado;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
