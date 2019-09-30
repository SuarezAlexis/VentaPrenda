using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface ITicketConfigDao
    {
        TicketConfigDto GetConfig();
        TicketConfigDto GuardarConfig(TicketConfigDto dto);
    }
}
