using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;
using VentaPrenda.Model;
using VentaPrenda.Service;
using VentaPrenda.View.Abstract;
using VentaPrenda.View.Concrete.Detalles;

namespace VentaPrenda.Controller
{
    public enum Funcion
    {
        NINGUNA,
        NOTA,
        CLIENTES,
        SELECCION_CATALOGOS,
        CATALOGOS,
        USUARIOS,
        PERFILES,
        GASTOS,
        REPORTES,
        DESCUENTOS,
        ARREGLOS
    };

    public enum Modo {
        NINGUNO,
        SELECCION,
        SOLO_LECTURA,
        EDICION
    };
    public class MainController
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private IMainView _mainView;
        public Usuario Usuario;
        public Modo Modo { get; set; }
        public Funcion Funcion { get; set; }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public MainController(IMainView mainView, Usuario u)
        {
            Usuario = u;
            _mainView = mainView;
            _mainView.Controller = this;            
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        public void ShowView()
        {
            _mainView.SetProfile(Usuario.Permisos);
            _mainView.ShowDashboard();
        }

        public void FillDetalle(long id)
        {
            Modo = Modo.SOLO_LECTURA;
            object dto = null;
            switch (Funcion)
            {
                case Funcion.PERFILES:
                    dto = DaoManager.PerfilDao.GetPerfil((short)id);
                    break;
                case Funcion.USUARIOS:
                    dto = DaoManager.UsuarioDao.GetUsuario(id);
                    break;
            }
            _mainView.Dto = dto;
            _mainView.UpdateModo();
        }
        
        /************************ MÉTODOS: Funciones ***********************/
        public void Perfiles()
        {
            Funcion = Funcion.PERFILES;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.PerfilDao.GetPerfiles();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Usuarios()
        {
            Funcion = Funcion.USUARIOS;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.UsuarioDao.GetUsuarios();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
            _mainView.Dto = DtoProvider.UsuarioDto();
        }

        /***************** MÉTODOS: Botones de Edición *******************/
        public void Regresar()
        {
            switch (Modo)
            {
                case Modo.SELECCION:
                    Modo = Modo.NINGUNO;
                    Funcion = Funcion.NINGUNA;
                    _mainView.DataSource = null;
                    _mainView.Dto = null;
                    _mainView.UpdateModo();
                    _mainView.UpdateFuncion();
                    break;
                case Modo.SOLO_LECTURA:
                    Modo = Modo.SELECCION;
                    _mainView.Dto = null;
                    _mainView.UpdateModo();
                    _mainView.UpdateFuncion();
                    break;
                case Modo.EDICION:
                    Modo = Modo.SOLO_LECTURA;
                    _mainView.Dto = _mainView.Dto;
                    _mainView.UpdateModo();
                    break;
            }
        }

        public void Nuevo()
        {
            switch(Funcion)
            {
                case Funcion.USUARIOS:
                    _mainView.Dto = DtoProvider.UsuarioDto();
                    break;
            }
            Modo = Modo.SELECCION;
            _mainView.UpdateModo();
        }

        public bool Guardar(object dto)
        {
            bool success = false;
            try
            {
                switch (Funcion)
                {
                    case Funcion.PERFILES:
                        _mainView.Dto = DaoManager.PerfilDao.GuardarPerfil((PerfilDto)dto);
                        _mainView.DataSource = DaoManager.PerfilDao.GetPerfiles();
                        break;
                    case Funcion.USUARIOS:
                        UsuarioDto usuarioDto = (UsuarioDto)dto;
                        usuarioDto.Contraseña = Cipher.Encrypt(usuarioDto.Contraseña);
                        _mainView.Dto = DaoManager.UsuarioDao.GuardarUsuario(usuarioDto);
                        _mainView.DataSource = DaoManager.UsuarioDao.GetUsuarios();
                        break;
                }
                Modo = Modo.SOLO_LECTURA;
                _mainView.UpdateModo();
                success = true;
            } catch(DuplicateKeyException dke)
            {
                _mainView.DuplicateKeyAlert(dke.DuplicatedKey);
                success = false;
            }
            return success;
        }
        public void Editar()
        {
            Modo = Modo.EDICION;
            _mainView.UpdateModo();
        }

        public void Eliminar(object dto)
        {
            switch(Funcion)
            {
                case Funcion.PERFILES:
                    _mainView.Dto = DaoManager.PerfilDao.EliminarPerfil((PerfilDto)dto);
                    _mainView.DataSource = DaoManager.PerfilDao.GetPerfiles();
                    break;
                case Funcion.USUARIOS:
                    _mainView.Dto = DaoManager.UsuarioDao.EliminarUsuario((UsuarioDto)dto);
                    _mainView.DataSource = DaoManager.UsuarioDao.GetUsuarios();
                    _mainView.Dto = DtoProvider.UsuarioDto();
                    break;
            }
            Modo = Modo.SELECCION;
            _mainView.UpdateModo();
        }
    }
}
