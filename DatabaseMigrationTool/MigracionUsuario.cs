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
                        Nombre = dt.Rows[0]["Nombre"].ToString(),
                        Permisos = new Permisos
                        {
                            Notas = Convert.ToBoolean(dt.Rows[0]["Nota"]),
                            Clientes = Convert.ToBoolean(dt.Rows[0]["Clientes"]),
                            Usuarios = Convert.ToBoolean(dt.Rows[0]["Usuarios"]),
                            Perfiles = Convert.ToBoolean(dt.Rows[0]["Perfiles"]),
                            Balance = Convert.ToBoolean(dt.Rows[0]["Gastos"]),
                            Reportes = Convert.ToBoolean(dt.Rows[0]["Reportes"]),
                            Descuentos = Convert.ToBoolean(dt.Rows[0]["Descuentos"]),
                            AdmonUsuarios = Convert.ToBoolean(dt.Rows[0]["AdmonUsuarios"]),
                            AdmonPerfiles = Convert.ToBoolean(dt.Rows[0]["AdmonPerfiles"]),
                            GenerarNota = Convert.ToBoolean(dt.Rows[0]["GeneraNota"]),
                            EditarNota = Convert.ToBoolean(dt.Rows[0]["EditaNota"]),
                            EliminarNota = Convert.ToBoolean(dt.Rows[0]["EliminarNota"]),
                            AdmonClientes = Convert.ToBoolean(dt.Rows[0]["AdmonClientes"]),
                            AdmonCatalogos = Convert.ToBoolean(dt.Rows[0]["AdmonCatalogos"]),
                            Catalogos = Convert.ToBoolean(dt.Rows[0]["AdmonCatalogos"]),
                            AdmonMovimientos = Convert.ToBoolean(dt.Rows[0]["GeneraGastos"]),
                            GeneraMovimientos = Convert.ToBoolean(dt.Rows[0]["GeneraGastos"]),
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
                        ID = Convert.ToInt16(dr["ID"]),
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
                        ID = Convert.ToInt16(dr["ID"]),
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
                        ID = Convert.ToInt16(dr["ID"]),
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
                        Nombre = dt.Rows[0]["Nombre"].ToString(),
                        Domicilio = dt.Rows[0]["Domicilio"].ToString(),
                        Colonia = dt.Rows[0]["Colonia"].ToString(),
                        CP = dt.Rows[0]["CP"].ToString(),
                        Telefono = dt.Rows[0]["Telefono"].ToString(),
                        Email = dt.Rows[0]["Email"].ToString(),
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

        public static bool Notas()
        {
            DataTable clientes = DaoManager.ClienteDao.GetClientes();
            DataTable colores = DaoManager.CatalogoDao.GetColores();
            DataTable prendas = DaoManager.CatalogoDao.GetPrendas();
            DataTable tiposPrenda = DaoManager.CatalogoDao.GetTiposPrenda();
            DataTable servicios = DaoManager.ServicioDao.GetServicios();

            DataTable dt = Database.Query("SELECT N.ID, N.FechaEntrada, N.FechaSalida, N.EstatusID, E.Nombre AS EstatusNombre, N.ClienteID, C.Nombre AS ClienteNombre, C.Telefono AS ClienteTelefono, N.DescuentoID, D.Nombre AS DescuentoNombre FROM Nota N JOIN Estatus_Nota E ON E.ID = N.EstatusID JOIN Cliente C ON C.ID = N.ClienteID LEFT JOIN Descuento D ON D.ID = N.DescuentoID");

            foreach(DataRow dr in dt.Rows)
            {
                ClienteDto cliente = new ClienteDto();
                foreach (DataRow c in clientes.Rows)
                {
                    if( c["Nombre"].ToString().Equals(dr["ClienteNombre"].ToString()) )
                    { cliente.ID = Convert.ToInt32(c["ID"]); }
                }

                DataTable prendaItemsDT = Database.Query("SELECT PN.ID, PN.PrendaID, P.Nombre AS PrendaNombre, PN.ColorID, C.Nombre AS ColorNombre, PN.Cantidad, PN.DescuentoID, D.Nombre AS DescuentoNombre, PN.TipoPrendaID, TP.Nombre AS TipoPrendaNombre, PN.SubtipoPrendaID, SP.Nombre AS SubtipoPrendaNombre FROM Prenda_Nota PN JOIN Prenda P ON P.ID = PN.PrendaID JOIN Color C ON C.ID = PN.ColorID LEFT JOIN Descuento D ON D.ID = PN.DescuentoID LEFT JOIN Tipo_Prenda TP ON TP.ID = PN.TipoPrendaID LEFT JOIN Subtipo_Prenda SP ON SP.ID = PN.SubtipoPrendaID WHERE NotaID = " + dr["ID"]);
                List<PrendaItemDto> prendaItemsList = new List<PrendaItemDto>();
                foreach(DataRow p in prendaItemsDT.Rows)
                {
                    prendaItemsList.Add(new PrendaItemDto
                    {
                        Cantidad = Convert.ToInt32(p["Cantidad"]),
                        
                    });
                }

                NotaDto n = new NotaDto
                {
                    ID = Convert.ToInt64(dr["ID"]),
                    Recibido = Convert.ToDateTime(dr["FechaEntrada"]),
                    Entregado = Convert.ToDateTime(dr["FechaSalida"]),
                    Cliente = cliente,
                    
                };
            }
            return true;
        }
    }
}
