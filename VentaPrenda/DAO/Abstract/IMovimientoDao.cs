using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface IMovimientoDao
    {
        MovimientoDto EliminarMovimiento(MovimientoDto dto);
        MovimientoDto GetMovimiento(long id);
        DataTable GetMovimientos();
        MovimientoDto GuardarMovimiento(MovimientoDto dto);
    }
}
