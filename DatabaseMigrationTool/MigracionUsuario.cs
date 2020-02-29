using ElBuenAjuste;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace DatabaseMigrationTool
{
    public class Migracion
    {
        public static bool Perfiles()
        {
            string query = "SELECT * FROM Perfil";
            Console.Write("Obteniendo datos de SQLServer...");
            DataTable dt = Database.Query(query);
            Console.WriteLine("completado.");
            Console.Write("Convirtiendo datos e insertando en MySQL...");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    PerfilDto p = new PerfilDto
                    {
                        ID = -1,
                        Nombre = dr["Nombre"].ToString(),
                        Permisos = new Permisos
                        {
                            Notas = Convert.ToBoolean(dr["Nota"]),
                            Clientes = Convert.ToBoolean(dr["Clientes"]),
                            Usuarios = Convert.ToBoolean(dr["Usuarios"]),
                            Perfiles = Convert.ToBoolean(dr["Perfiles"]),
                            Balance = Convert.ToBoolean(dr["Gastos"]),
                            Reportes = Convert.ToBoolean(dr["Reportes"]),
                            Descuentos = Convert.ToBoolean(dr["Descuentos"]),
                            AdmonUsuarios = Convert.ToBoolean(dr["AdmonUsuarios"]),
                            AdmonPerfiles = Convert.ToBoolean(dr["AdmonPerfiles"]),
                            GenerarNota = Convert.ToBoolean(dr["GeneraNota"]),
                            EditarNota = Convert.ToBoolean(dr["EditaNota"]),
                            EliminarNota = Convert.ToBoolean(dr["EliminaNota"]),
                            AdmonClientes = Convert.ToBoolean(dr["AdmonClientes"]),
                            AdmonCatalogos = Convert.ToBoolean(dr["AdmonCatalogos"]),
                            Catalogos = Convert.ToBoolean(dr["AdmonCatalogos"]),
                            AdmonMovimientos = Convert.ToBoolean(dr["GeneraGastos"]),
                            GeneraMovimientos = Convert.ToBoolean(dr["GeneraGastos"]),
                            Database = false,
                            Ticket = false,
                            Historial = false
                        }
                    };
                    DaoManager.PerfilDao.GuardarPerfil(p);
                } catch(Exception e)
                {
                    Console.WriteLine("ocurrió un error en el registro " + i);
                    Console.WriteLine("Error: " + e.GetType());
                    Console.WriteLine("Mensaje: " + e.Message);
                    Console.WriteLine("Traza:\n" + e.StackTrace);
                    return false;
                }
                i++;
            }
            Console.WriteLine("completado: " + i + " registros migrados.");
            return true;
        }

        public static bool Usuarios()
        {
            Dictionary<PerfilDto, bool> Perfiles = new Dictionary<PerfilDto, bool>();            
            foreach (DataRow dr in DaoManager.PerfilDao.GetPerfiles().Rows)
            {
                Perfiles.Add(new PerfilDto
                {
                    ID = Convert.ToInt16(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Permisos = new Permisos { Numeric = Convert.ToInt32(dr["Permisos"]) }
                },false);
            }
            Console.Write("Obteniendo datos de SQLServer...");
            DataTable dt = Database.Query("SELECT * FROM Usuario");
            Console.WriteLine("completado.");
            Console.Write("Convirtiendo datos e insertando en MySQL...");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    UsuarioDto u = new UsuarioDto
                    {
                        ID = -1,
                        Nombre = dr["Nombre"].ToString(),
                        Bloqueado = Convert.ToBoolean(dr["Bloqueado"]),
                        Contraseña = dr["Contraseña"].ToString(),
                        IntentosFallidos = Convert.ToInt32(dr["IntentosFallidos"]),
                        Username = dr["Clave"].ToString(),
                        Perfiles = new Dictionary<PerfilDto, bool>()
                    };
                    DataTable PerfilesTable = Database.Query("SELECT * FROM Perfil p JOIN Usuario_Perfil up ON up.PerfilID = p.ID WHERE up.UsuarioID = Convert(UNIQUEIDENTIFIER, '" + dr["ID"].ToString() + "')");
                    foreach (DataRow PerfilRow in PerfilesTable.Rows)
                    {
                        u.Perfiles.Add(Perfiles.First(kvp => kvp.Key.Nombre.Equals(PerfilRow["Nombre"].ToString())).Key, true);
                    }
                    DaoManager.UsuarioDao.GuardarUsuario(u);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error en el registro " + i);
                    Console.WriteLine("Error: " + e.GetType());
                    Console.WriteLine("Mensaje: " + e.Message);
                    Console.WriteLine("Traza:\n" + e.StackTrace);
                    return false;
                }
                i++;
            }
            Console.WriteLine("completado: " + i + " registros migrados.");
            return true;
        }

        public static bool Catalogos()
        {
            Console.WriteLine("CATALOGO: Color");
            Console.Write("Obteniendo datos de SQLServer...");
            DataTable dt = Database.Query("SELECT * FROM Color");
            Console.WriteLine("completado.");
            Console.Write("Convirtiendo datos e insertando en MySQL...");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    CatalogoDto c = new CatalogoDto
                    {
                        ID = -1,
                        Nombre = dr["Nombre"].ToString(),
                        Habilitado = true
                    };
                    DaoManager.CatalogoDao.GuardarColor(c);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error en el registro " + i);
                    Console.WriteLine("Error: " + e.GetType());
                    Console.WriteLine("Mensaje: " + e.Message);
                    Console.WriteLine("Traza:\n" + e.StackTrace);
                    return false;
                }
                i++;
            }
            Console.WriteLine("completado: " + i + " registros migrados.\n");

            Console.WriteLine("CATALOGO: Prenda");
            Console.Write("Obteniendo datos de SQLServer...");
            dt = Database.Query("SELECT * FROM Prenda");
            Console.WriteLine("completado.");
            Console.Write("Convirtiendo datos e insertando en MySQL...");
            i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    CatalogoDto p = new CatalogoDto
                    {
                        ID = -1,
                        Nombre = dr["Nombre"].ToString(),
                        Habilitado = true
                    };
                    DaoManager.CatalogoDao.GuardarPrenda(p);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error en el registro " + i);
                    Console.WriteLine("Error: " + e.GetType());
                    Console.WriteLine("Mensaje: " + e.Message);
                    Console.WriteLine("Traza:\n" + e.StackTrace);
                    return false;
                }
                i++;
            }
            Console.WriteLine("completado: " + i + " registros migrados.\n");

            Console.WriteLine("CATALOGO: TipoPrenda");
            Console.Write("Obteniendo datos de SQLServer...");
            dt = Database.Query("SELECT * FROM Tipo_Prenda");
            Console.WriteLine("completado.");
            Console.Write("Convirtiendo datos e insertando en MySQL...");
            i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    CatalogoDto t = new CatalogoDto
                    {
                        ID = -1,
                        Nombre = dr["Nombre"].ToString(),
                        Habilitado = true
                    };
                    DaoManager.CatalogoDao.GuardarTipoPrenda(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error en el registro " + i);
                    Console.WriteLine("Error: " + e.GetType());
                    Console.WriteLine("Mensaje: " + e.Message);
                    Console.WriteLine("Traza:\n" + e.StackTrace);
                    return false;
                }
                i++;
            }
            Console.WriteLine("completado: " + i + " registros migrados.\n");
            return true;
        }

        public static bool Servicios()
        {
            Console.Write("Obteniendo datos de SQLServer...");
            DataTable dt = Database.Query("SELECT * FROM Arreglo");
            Console.WriteLine("completado.");
            Console.Write("Convirtiendo datos e insertando en MySQL...");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    ServicioDto s = new ServicioDto
                    {
                        ID = -1,
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Costo = Convert.ToDecimal(dr["CostoBase"]),
                        Prendas = new List<CatalogoDto>(),
                        Habilitado = true
                    };
                    DaoManager.ServicioDao.GuardarServicio(s);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error en el registro " + i);
                    Console.WriteLine("Error: " + e.GetType());
                    Console.WriteLine("Mensaje: " + e.Message);
                    Console.WriteLine("Traza:\n" + e.StackTrace);
                    return false;
                }
                i++;
            }
            Console.WriteLine("completado: " + i + " registros migrados.");
            return true;
        }

        public static bool Clientes()
        {
            Console.Write("Obteniendo datos de SQLServer...");
            DataTable dt = Database.Query("SELECT * FROM Cliente");
            Console.WriteLine("completado.");
            Console.Write("Convirtiendo datos e insertando en MySQL...");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    ClienteDto c = new ClienteDto
                    {
                        ID = -1,
                        Nombre = dr["Nombre"].ToString(),
                        Domicilio = dr["Domicilio"].ToString(),
                        Colonia = dr["Colonia"].ToString(),
                        CP = dr["CP"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Email = dr["Email"].ToString(),
                        Habilitado = true
                    };
                    DaoManager.ClienteDao.GuardarCliente(c);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error en el registro " + i);
                    Console.WriteLine("Error: " + e.GetType());
                    Console.WriteLine("Mensaje: " + e.Message);
                    Console.WriteLine("Traza:\n" + e.StackTrace);
                    return false;
                }
                i++;
            }
            Console.WriteLine("completado: " + i + " registros migrados.");
            return true;
        }

        public static bool Movimientos()
        {
            DataTable dt = Database.Query("SELECT * FROM Gasto");
            return true;
        }

        public static bool Notas(long desde)
        {
            DataTable clientes = DaoManager.ClienteDao.GetClientes();
            DataTable colores = DaoManager.CatalogoDao.GetColores();
            DataTable prendas = DaoManager.CatalogoDao.GetPrendas();
            DataTable tiposPrenda = DaoManager.CatalogoDao.GetTiposPrenda();
            DataTable servicios = DaoManager.ServicioDao.GetServicios();
            DataTable usuarios = DaoManager.UsuarioDao.GetUsuarios();

            DataTable dt = Database.Query("SELECT N.ID, N.FechaEntrada, N.FechaSalida, N.EstatusID, E.Nombre AS EstatusNombre, N.ClienteID, C.Nombre AS ClienteNombre, C.Telefono AS ClienteTelefono, N.DescuentoID, D.Nombre AS DescuentoNombre FROM Nota N JOIN Estatus_Nota E ON E.ID = N.EstatusID JOIN Cliente C ON C.ID = N.ClienteID LEFT JOIN Descuento D ON D.ID = N.DescuentoID" + (desde >= 0 ? " WHERE N.ID >= " + desde + " " : "") + "ORDER BY N.ID ASC");
            Console.WriteLine("Se encontraron " + dt.Rows.Count + " notas.");
            int i = 0;
            foreach(DataRow dr in dt.Rows)
            {
                NotaDto n = new NotaDto
                {
                    ID = Convert.ToInt64(dr["ID"]),
                    Recibido = Convert.ToDateTime(dr["FechaEntrada"]),
                    Entregado = Convert.ToDateTime(dr["FechaSalida"]),
                }; 
                Console.WriteLine("Nota " + n.ID + " [ " + i + " de " + dt.Rows.Count + " " + (((float)i/dt.Rows.Count) * 100).ToString("0.00") + "% ]");

                foreach (DataRow c in clientes.Rows)
                {
                    if( c["Nombre"].ToString().Equals(dr["ClienteNombre"].ToString()) )
                    { 
                        n.Cliente = new ClienteDto { ID = Convert.ToInt32(c["ID"]) };
                        break; 
                    }
                }
                if (n.Cliente == null) { Console.WriteLine("no se encontró cliente"); }

                DataTable prendaItemsDT = Database.Query("SELECT PN.ID, PN.PrendaID, P.Nombre AS PrendaNombre, PN.ColorID, C.Nombre AS ColorNombre, PN.Cantidad, PN.DescuentoID, D.Nombre AS DescuentoNombre, PN.TipoPrendaID, TP.Nombre AS TipoPrendaNombre, PN.SubtipoPrendaID, SP.Nombre AS SubtipoPrendaNombre FROM Prenda_Nota PN JOIN Prenda P ON P.ID = PN.PrendaID JOIN Color C ON C.ID = PN.ColorID LEFT JOIN Descuento D ON D.ID = PN.DescuentoID LEFT JOIN Tipo_Prenda TP ON TP.ID = PN.TipoPrendaID LEFT JOIN Subtipo_Prenda SP ON SP.ID = PN.SubtipoPrendaID WHERE NotaID = " + dr["ID"]);
                n.Prendas = new List<PrendaItemDto>();
                foreach(DataRow pdr in prendaItemsDT.Rows)
                {
                    PrendaItemDto prenda = new PrendaItemDto
                    {
                        Nota = n,
                        Cantidad = Convert.ToInt32(pdr["Cantidad"]),
                    };

                    foreach (DataRow p in prendas.Rows)
                    {
                        if(p["Nombre"].ToString().Equals(pdr["PrendaNombre"].ToString()))
                        { 
                            prenda.Prenda = new CatalogoDto { ID = Convert.ToInt16(p["ID"])};
                            break; 
                        }
                    }

                    foreach (DataRow c in colores.Rows)
                    {
                        if (c["Nombre"].ToString().Equals(pdr["ColorNombre"].ToString()))
                        { 
                            prenda.Color = new CatalogoDto { ID = Convert.ToInt16(c["ID"]) };
                            break; 
                        }
                    }

                    foreach (DataRow t in tiposPrenda.Rows)
                    {
                        if(t["Nombre"].ToString().Equals(pdr["TipoPrendaNombre"].ToString()))
                        { 
                            prenda.TipoPrenda = new CatalogoDto { ID = Convert.ToInt16(t["ID"])};
                            break; 
                        }
                    }

                    DataTable servicioItemsDT = Database.Query("SELECT APN.*, P.NotaID, A.Nombre AS NombreArreglo, A.CostoBase, U.Clave AS UsuarioNombre, D.Nombre AS DescuentoNombre FROM Arreglo_Prenda_Nota APN JOIN Prenda_Nota P ON P.ID = APN.PrendaNotaID JOIN Arreglo A ON A.ID = APN.ArregloID LEFT JOIN Usuario U ON U.ID = APN.UsuarioID LEFT JOIN Descuento D ON D.ID = APN.DescuentoID WHERE PrendaNotaID = CONVERT(UNIQUEIDENTIFIER, '" + pdr["ID"] + "')");
                    prenda.Servicios = new List<ServicioItemDto>();
                    foreach(DataRow sdr in servicioItemsDT.Rows)
                    {
                        ServicioItemDto servicio = new ServicioItemDto
                        {
                            PrendaItem = prenda,
                            Cantidad = Convert.ToInt32(sdr["Cantidad"]),
                            Monto = Convert.ToDecimal(sdr["Costo"]) * Convert.ToInt32(sdr["Cantidad"])
                        };

                        foreach(DataRow u in usuarios.Rows)
                        {
                            if (u["Username"].ToString().Equals(sdr["UsuarioNombre"].ToString()))
                            { 
                                servicio.Encargado = new UsuarioDto { ID = Convert.ToInt64(u["ID"]) };
                                break;
                            }
                        }

                        foreach(DataRow s in servicios.Rows)
                        {
                            if(s["Nombre"].ToString().Equals(sdr["NombreArreglo"].ToString()))
                            { 
                                servicio.Servicio = new ServicioDto { ID = Convert.ToInt32(s["ID"]) };
                                break; 
                            }
                        }
                        prenda.Servicios.Add(servicio);
                    }

                    n.Prendas.Add(prenda);
                }

                DataTable pagosDT = Database.Query("SELECT P.*, U.Clave, TP.Nombre AS NombreTipoPago FROM Pago P JOIN Usuario U ON U.ID = P.UsuarioID JOIN Tipo_Pago TP ON TP.ID = P.TipoPagoID WHERE NotaID = " + n.ID);
                n.Pagos = new List<PagoDto>();
                foreach(DataRow pdr in pagosDT.Rows)
                {
                    PagoDto pago = new PagoDto
                    {
                        Fecha = Convert.ToDateTime(pdr["Fecha"]),
                        Metodo = pdr["NombreTipoPago"].ToString().Equals("Efectivo") ? MetodoPago.Efectivo : MetodoPago.Tarjeta,
                        Nota = n,
                        Monto = Convert.ToDecimal(pdr["Monto"])
                    };
                    n.Pagos.Add(pago);
                }

                switch(dr["EstatusNombre"].ToString())
                {
                    case "En proceso":
                        n.Estatus = Estatus.Terminado;
                        break;
                    case "Entregada":
                        n.Estatus = Estatus.Entregado;
                        break;
                    case "Donada":
                        n.Estatus = Estatus.Caducado;
                        break;
                    default:
                        n.Estatus = Estatus.Pendiente;
                        break;
                }

                DaoManager.NotaDao.InsertarNota(n);
                i++;
            }
            return true;
        }
    }
}
