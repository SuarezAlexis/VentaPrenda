using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.Service
{
    public class DtoMapper
    {
        public static Usuario Usuario(UsuarioDto dto)
        {
            return new Usuario
            {
                ID = dto.ID,
                Username = dto.Username,
                Nombre = dto.Nombre,
                Contraseña = dto.Contraseña,
                Logged = dto.Logged,
                Bloqueado = dto.Bloqueado,
                UltimoIngreso = dto.UltimoIngreso,
                IntentosFallidos = dto.IntentosFallidos,
                Permisos = dto.Permisos,
                Colores = DtoMapper.ColoresGUI(dto.Colores)
            };
        }

        public static ColoresGUIDto ColoresGUIDto(ColoresGUI c)
        {
            return new ColoresGUIDto
            {
                Caducado = c.Caducado,
                Cancelado = c.Cancelado,
                Entregado = c.Entregado,
                FondoBoton = c.FondoBoton,
                FondoBotonActivo = c.FondoBotonActivo,
                FondoVentana = c.FondoVentana,
                Pendiente = c.Pendiente,
                Terminado = c.Terminado
            };
        }
        public static ColoresGUI ColoresGUI(ColoresGUIDto dto)
        {
            return new ColoresGUI
            {
                Caducado = dto.Caducado,
                Cancelado = dto.Cancelado,
                Entregado = dto.Entregado,
                FondoBoton = dto.FondoBoton,
                FondoBotonActivo = dto.FondoBotonActivo,
                FondoVentana = dto.FondoVentana,
                Pendiente = dto.Pendiente,
                Terminado = dto.Terminado
            };
        }

    }
}
