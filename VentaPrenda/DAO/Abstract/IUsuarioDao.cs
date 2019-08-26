using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.DAO.Abstract
{
    public interface IUsuarioDao
    {
        UsuarioDto GetUsuario(LoginDto loginDto);
        UsuarioDto GetUsuario(long id);
        DataTable GetUsuarios();
        UsuarioDto GuardarUsuario(UsuarioDto u);
        UsuarioDto EliminarUsuario(UsuarioDto u);
    }
}
