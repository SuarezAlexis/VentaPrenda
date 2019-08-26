using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO;
using VentaPrenda.DTO;

namespace VentaPrenda.Service
{
    public class DtoProvider
    {
        public static UsuarioDto UsuarioDto()
        {
            UsuarioDto dto = new UsuarioDto();
            foreach (DataRow dr in DaoManager.PerfilDao.GetPerfiles().Rows)
            {
                dto.Perfiles.Add(new PerfilDto
                {
                    ID = Convert.ToInt16(dr["ID"]),
                    Nombre = dr["Nombre"].ToString()
                },
                false);
            }
            return dto;
        }
    }
}
