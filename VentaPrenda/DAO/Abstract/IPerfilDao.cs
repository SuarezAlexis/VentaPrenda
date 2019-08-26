using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface IPerfilDao
    {
        PerfilDto GetPerfil(short PerfilID);
        DataTable GetPerfiles();
        PerfilDto GuardarPerfil(PerfilDto dto);
        PerfilDto EliminarPerfil(PerfilDto p);
    }
}
