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
                Permisos = dto.Permisos
            };
        }
    }
}
