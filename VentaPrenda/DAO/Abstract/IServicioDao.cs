using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface IServicioDao
    {
        ServicioDto GetServicio(int id);
        DataTable GetServicios();
        ServicioDto GuardarServicio(ServicioDto dto);
        ServicioDto EliminarServicio(ServicioDto dto);
    }
}
