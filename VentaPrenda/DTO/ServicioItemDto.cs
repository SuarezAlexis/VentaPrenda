using System.Collections.Generic;

namespace VentaPrenda.DTO
{
    public class ServicioItemDto
    {
        public static List<DescuentoDto> Descuentos { get; set; }   
        public static List<ServicioDto> Servicios { get; set; }
        public static List<UsuarioDto> Usuarios { get; set; }

        public long ID { get; set; }
        public PrendaItemDto PrendaItem { get; set; }
        public int Cantidad { get; set; }
        public ServicioDto Servicio { get; set; }
        public decimal Monto { get; set; }
        public DescuentoDto Descuento { get; set; }
        public UsuarioDto Encargado { get; set; }

        public ServicioItemDto()
        {
            ID = -1;
            Descuentos = Descuentos == null? new List<DescuentoDto>() : Descuentos;
            Servicios = Servicios == null? new List<ServicioDto>() : Servicios;
            Usuarios = Usuarios == null? new List<UsuarioDto>() : Usuarios;
        }

        public override string ToString()
        {
            return Cantidad + " " + Servicio;
        }

    }
}