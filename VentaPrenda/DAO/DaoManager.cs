using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DAO.Concrete;

namespace VentaPrenda.DAO
{
    public class DaoManager
    {
        public static readonly IUsuarioDao UsuarioDao = new UsuarioDaoMySQL();
        public static readonly IPerfilDao PerfilDao = new PerfilDaoMySQL();
        public static readonly ICatalogoDao CatalogoDao = new CatalogoDaoMySQL();
        public static readonly IServicioDao ServicioDao = new ServicioDaoMySQL();
    }
}
