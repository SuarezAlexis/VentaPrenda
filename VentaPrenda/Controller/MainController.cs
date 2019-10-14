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
        COLORES,
        PRENDAS,    
        TIPOS_PRENDA,
        USUARIOS,
        PERFILES,
        BALANCE,
        REPORTES,
        DESCUENTOS,
        SERVICIOS,
        HISTORIAL,
        TICKET,
        DATABASE,
        PERSONALIZAR
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
            _mainView.SetColors(DtoMapper.ColoresGUIDto(Usuario.Colores));
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
                case Funcion.COLORES:
                    dto = DaoManager.CatalogoDao.GetColor((short)id);
                    break;
                case Funcion.PRENDAS:
                    dto = DaoManager.CatalogoDao.GetPrenda((short)id);
                    break;
                case Funcion.TIPOS_PRENDA:
                    dto = DaoManager.CatalogoDao.GetTipoPrenda((short)id);
                    break;
                case Funcion.SERVICIOS:
                    dto = DaoManager.ServicioDao.GetServicio((int)id);
                    break;
                case Funcion.DESCUENTOS:
                    dto = DaoManager.DescuentoDao.GetDescuento((int)id);
                    break;
                case Funcion.NOTA:
                    dto = DaoManager.NotaDao.GetNota(id);
                    break;
                case Funcion.CLIENTES:
                    dto = DaoManager.ClienteDao.GetCliente((int)id);
                    break;
                case Funcion.BALANCE:
                    dto = DaoManager.MovimientoDao.GetMovimiento(id);
                    break;
                case Funcion.REPORTES:
                    //dto = DaoManager.ArregloDao.GetColor((short)id);
                    break;
                case Funcion.HISTORIAL:
                    dto = DaoManager.HistorialDao.GetHistorial(id);
                    break;
            }
            _mainView.Dto = dto;
            _mainView.UpdateModo();
        }
        
        public decimal MontoAcumulado(int clienteID, DateTime desde)
        { return Service.Reportes.MontoAcumulado(clienteID, desde); }

        public int ServiciosAcumulados(int clienteID, DateTime desde)
        { return Service.Reportes.ServiciosAcumulados(clienteID, desde); }

        public void ImprimirNota(NotaDto nota)
        { TicketPrinter.PrintTicket(nota,Usuario); }

        public ClienteDto ClienteStats(ClienteDto Dto)
        {
            Dto.Estadisticas = DtoProvider.ClienteStats(Dto.ID).Estadisticas;
            return Dto;
        }

        public void Reporte(ReporteDto Dto)
        {
            switch(Dto.Tipo)
            {
                case TipoReporte.Clientes:
                    _mainView.DataSource = Service.Reportes.Clientes(Dto.Desde, Dto.Hasta);
                    break;
                case TipoReporte.Ingresos:
                    _mainView.DataSource = Service.Reportes.Ingresos(Dto.Desde,Dto.Hasta);
                    break;
                case TipoReporte.Produccion:
                    _mainView.DataSource = Service.Reportes.Produccion(Dto.Desde, Dto.Hasta);
                    break;
            }
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

        public void Colores()
        {
            Funcion = Funcion.COLORES;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.CatalogoDao.GetColores();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Prendas()
        {
            Funcion = Funcion.PRENDAS;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.CatalogoDao.GetPrendas();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void TiposPrenda()
        {
            Funcion = Funcion.TIPOS_PRENDA;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.CatalogoDao.GetTiposPrenda();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Servicios()
        {
            Funcion = Funcion.SERVICIOS;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.ServicioDao.GetServicios();
            PrendaItemDto.Prendas = DtoProvider.PrendasAsList();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Descuentos()
        {
            Funcion = Funcion.DESCUENTOS;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.DescuentoDao.GetDescuentos();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Ticket()
        {
            Funcion = Funcion.TICKET;
            Modo = Modo.SELECCION;
            _mainView.DataSource = null;
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
            _mainView.Dto = DaoManager.TicketConfigDao.GetConfig();
        }

        public void Notas()
        {
            Funcion = Funcion.NOTA;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.NotaDao.GetNotas();
            NotaDto.Clientes = DtoProvider.ClientesAsList();
            NotaDto.Descuentos = DtoProvider.DescuentosAsList();
            PrendaItemDto.Prendas = DtoProvider.PrendasAsList();
            PrendaItemDto.Tipos = DtoProvider.TiposPrendaAsList();
            PrendaItemDto.Colores = DtoProvider.ColoresAsList();
            ServicioItemDto.Descuentos = new List<DescuentoDto>(NotaDto.Descuentos);
            ServicioItemDto.Servicios = DtoProvider.ServiciosAsList();
            ServicioItemDto.Usuarios = DtoProvider.UsuariosAsList();
            ServicioItemDto.Descuentos.RemoveAll((d) => d.Unidades < 0);
            NotaDto.Descuentos.RemoveAll((d) => d.Porcentaje < 0);
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Clientes()
        {
            Funcion = Funcion.CLIENTES;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.ClienteDao.GetClientes();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Balance()
        {
            Funcion = Funcion.BALANCE;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.MovimientoDao.GetMovimientos();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Reportes()
        {
            Funcion = Funcion.REPORTES;
            Modo = Modo.SELECCION;
            _mainView.DataSource = null;
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Historial()
        {
            Funcion = Funcion.HISTORIAL;
            Modo = Modo.SELECCION;
            _mainView.DataSource = DaoManager.HistorialDao.GetHistorial();
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void BaseDeDatos()
        {
            Funcion = Funcion.DATABASE;
            Modo = Modo.SELECCION;
            _mainView.DataSource = null;
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
        }

        public void Personalizar()
        {
            Funcion = Funcion.PERSONALIZAR;
            Modo = Modo.SELECCION;
            _mainView.DataSource = null;
            _mainView.UpdateModo();
            _mainView.UpdateFuncion();
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
                    _mainView.UpdateModo();
                    _mainView.UpdateFuncion();
                    break;
                case Modo.SOLO_LECTURA:
                    Modo = Modo.SELECCION;
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
                char op;
                if (Funcion == Funcion.PERSONALIZAR)
                    op = 'U';
                else
                    op = Convert.ToInt64(dto.GetType().GetProperty("ID").GetValue(dto)) > 0? 'U' : 'I';
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
                    case Funcion.COLORES:
                        _mainView.Dto = DaoManager.CatalogoDao.GuardarColor((CatalogoDto)dto);
                        _mainView.DataSource = DaoManager.CatalogoDao.GetColores();
                        break;
                    case Funcion.PRENDAS:
                        _mainView.Dto = DaoManager.CatalogoDao.GuardarPrenda((CatalogoDto)dto);
                        _mainView.DataSource = DaoManager.CatalogoDao.GetPrendas();
                        break;
                    case Funcion.TIPOS_PRENDA:
                        _mainView.Dto = DaoManager.CatalogoDao.GuardarTipoPrenda((CatalogoDto)dto);
                        _mainView.DataSource = DaoManager.CatalogoDao.GetTiposPrenda();
                        break;
                    case Funcion.SERVICIOS:
                        _mainView.Dto = DaoManager.ServicioDao.GuardarServicio((ServicioDto)dto);
                        _mainView.DataSource = DaoManager.ServicioDao.GetServicios();
                        break;
                    case Funcion.DESCUENTOS:
                        _mainView.Dto = DaoManager.DescuentoDao.GuardarDescuento((DescuentoDto)dto);
                        _mainView.DataSource = DaoManager.DescuentoDao.GetDescuentos();
                        break;
                    case Funcion.NOTA:
                        NotaDto nota = (NotaDto)dto;
                        if(nota.Cliente.ID < 0)
                        { nota.Cliente = DaoManager.ClienteDao.GuardarCliente(nota.Cliente); }
                        _mainView.Dto = DaoManager.NotaDao.GuardarNota(nota);
                        _mainView.DataSource = DaoManager.NotaDao.GetNotas();
                        break;
                    case Funcion.CLIENTES:
                        _mainView.Dto = DaoManager.ClienteDao.GuardarCliente((ClienteDto)dto);
                        _mainView.DataSource = DaoManager.ClienteDao.GetClientes();
                        break;
                    case Funcion.BALANCE:
                        _mainView.Dto = DaoManager.MovimientoDao.GuardarMovimiento((MovimientoDto)dto);
                        _mainView.DataSource = DaoManager.MovimientoDao.GetMovimientos();
                        break;
                    case Funcion.REPORTES:
                        break;
                    case Funcion.TICKET:
                        _mainView.Dto = DaoManager.TicketConfigDao.GuardarConfig((TicketConfigDto)dto);
                        break;
                    case Funcion.PERSONALIZAR:
                        _mainView.Dto = DaoManager.UsuarioDao.GuardarColores((ColoresGUIDto)dto, Usuario.ID);
                        break;
                }
                HistorialService.GuardarHistoria(Usuario, op, Funcion, dto);
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
            HistorialService.GuardarHistoria(Usuario, 'D', Funcion, dto);
            switch(Funcion)
            {
                case Funcion.PERFILES:
                    _mainView.Dto = DaoManager.PerfilDao.EliminarPerfil((PerfilDto)dto);
                    _mainView.DataSource = DaoManager.PerfilDao.GetPerfiles();
                    break;
                case Funcion.USUARIOS:
                    _mainView.Dto = DaoManager.UsuarioDao.EliminarUsuario((UsuarioDto)dto);
                    _mainView.DataSource = DaoManager.UsuarioDao.GetUsuarios();
                    //_mainView.Dto = DtoProvider.UsuarioDto();
                    break;
                case Funcion.COLORES:
                    _mainView.Dto = DaoManager.CatalogoDao.EliminarColor((CatalogoDto)dto);
                    _mainView.DataSource = DaoManager.CatalogoDao.GetColores();
                    break;
                case Funcion.PRENDAS:
                    _mainView.Dto = DaoManager.CatalogoDao.EliminarPrenda((CatalogoDto)dto);
                    _mainView.DataSource = DaoManager.CatalogoDao.GetPrendas();
                    break;
                case Funcion.TIPOS_PRENDA:
                    _mainView.Dto = DaoManager.CatalogoDao.EliminarTipoPrenda((CatalogoDto)dto);
                    _mainView.DataSource = DaoManager.CatalogoDao.GetTiposPrenda();
                    break;
                case Funcion.SERVICIOS:
                    _mainView.Dto = DaoManager.ServicioDao.EliminarServicio((ServicioDto)dto);
                    _mainView.DataSource = DaoManager.ServicioDao.GetServicios();
                    break;
                case Funcion.DESCUENTOS:
                    _mainView.Dto = DaoManager.DescuentoDao.EliminarDescuento((DescuentoDto)dto);
                    _mainView.DataSource = DaoManager.DescuentoDao.GetDescuentos();
                    break;
                case Funcion.NOTA:
                    _mainView.Dto = DaoManager.NotaDao.EliminarNota((NotaDto)dto);
                    _mainView.DataSource = DaoManager.NotaDao.GetNotas();
                    break;
                case Funcion.CLIENTES:
                    _mainView.Dto = DaoManager.ClienteDao.EliminarCliente((ClienteDto)dto);
                    _mainView.DataSource = DaoManager.ClienteDao.GetClientes();
                    break;
                case Funcion.BALANCE:
                    _mainView.Dto = DaoManager.MovimientoDao.EliminarMovimiento((MovimientoDto)dto);
                    _mainView.DataSource = DaoManager.MovimientoDao.GetMovimientos();
                    break;
                case Funcion.REPORTES:
                    
                    break;
            }
            Modo = Modo.SELECCION;
            _mainView.UpdateModo();
        }

    }
}
