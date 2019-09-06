using System.Collections.Generic;

namespace VentaPrenda.DTO
{
    public class PrendaItemDto
    {
        public static List<CatalogoDto> Prendas { get; set; }
        public static List<CatalogoDto> Tipos { get; set; }
        public static List<CatalogoDto> Colores { get; set; }

        public long ID { get; set; }
        public NotaDto Nota { get; set; }
        public int Cantidad { get; set; }
        public CatalogoDto Prenda { get; set; }
        public CatalogoDto TipoPrenda { get; set; }
        public CatalogoDto Color { get; set; }
        public List<ServicioItemDto> Servicios { get; set; }

        public PrendaItemDto()
        {
            ID = -1;
            Cantidad = 1;
            Servicios = new List<ServicioItemDto>();
        }

        public override string ToString()
        {
            return Cantidad + " " + Prenda + " " + TipoPrenda + " " + Color;
        }
    }
}