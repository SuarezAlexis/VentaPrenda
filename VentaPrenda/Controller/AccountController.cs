using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.DAO;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;
using VentaPrenda.Model;
using VentaPrenda.Service;
using VentaPrenda.View.Abstract;

namespace VentaPrenda.Controller
{
    public class AccountController
    {
        /************************** ATRIBUTOS ******************************/
        private ILoginView _loginView;
        private IUsuarioDao _usuarioDao;
        public Usuario Usuario { get; set; }

        /************************ CONSTRUCTORES ****************************/
        public AccountController(ILoginView loginView)
        {
            _loginView = loginView;
            _loginView.Controller = this;
            _usuarioDao = DaoManager.UsuarioDao;
        }

        /*************************** MÉTODOS *******************************/
        public bool Authenticate()
        {
            try
            {
                do
                {
                    LoginDto dto = _loginView.RequestCredentials();
                    Usuario = DtoMapper.Usuario(_usuarioDao.GetUsuario(dto));
                    if (Usuario == null || !Usuario.Logged)
                    {
                        if(Usuario != null && Usuario.Bloqueado)
                            _loginView.BlockedUser();
                        else
                            _loginView.WrongCredentials();
                    }                        
                } while (Usuario == null || !Usuario.Logged);
                
            }
            catch(ViewClosedException vce)
            {
                return false;
            }
            catch(CouldNotConnectException cnce)
            {
                //Registrar el Log
                MessageBox.Show(
                    cnce.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return Usuario != null && Usuario.Logged;
        }
    }
}
