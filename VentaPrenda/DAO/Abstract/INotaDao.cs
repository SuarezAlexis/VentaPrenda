using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface INotaDao
    {
        NotaDto GetNota(long id);
        DataTable GetNotas();
        NotaDto GuardarNota(NotaDto dto);
        NotaDto EliminarNota(NotaDto dto);
    }
}
