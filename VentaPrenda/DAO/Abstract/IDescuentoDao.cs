using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface IDescuentoDao
    {
        DescuentoDto EliminarDescuento(DescuentoDto dto);
        DescuentoDto GetDescuento(int id);
        DataTable GetDescuentos();
        DescuentoDto GuardarDescuento(DescuentoDto dto);
    }
}
