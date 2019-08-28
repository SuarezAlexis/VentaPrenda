using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface IClienteDao
    {
        ClienteDto EliminarCliente(ClienteDto dto);
        ClienteDto GetCliente(int id);
        DataTable GetClientes();
        ClienteDto GuardarCliente(ClienteDto dto);
    }
}
