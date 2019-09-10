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

        public PrendaItemDto(long ID) :this()
        { this.ID = ID; }

        public override string ToString()
        {
            return Cantidad + " " + Prenda + " " + TipoPrenda + " " + Color;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            else
            {
                if (this == obj) return true;
                PrendaItemDto p = (PrendaItemDto)obj;
                return this.ID == p.ID;
            }
        }
    }
}