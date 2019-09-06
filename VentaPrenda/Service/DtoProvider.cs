using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.Service
{
    public class DtoProvider
    {
        private static List<CatalogoDto> CatalogoAsList(DataTable dt)
        {
            List<CatalogoDto> list = new List<CatalogoDto>();
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToBoolean(dr["Habilitado"]))
                {
                    list.Add(new CatalogoDto
                    {
                        ID = Convert.ToInt16(dr["ID"]),
                        Nombre = dr["Nombre"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return list;
        }

        public static UsuarioDto UsuarioDto()
        {
            UsuarioDto dto = new UsuarioDto();
            foreach (DataRow dr in DaoManager.PerfilDao.GetPerfiles().Rows)
            {
                dto.Perfiles.Add(new PerfilDto
                {
                    ID = Convert.ToInt16(dr["ID"]),
                    Nombre = dr["Nombre"].ToString()
                },
                false);
            }
            return dto;
        }

        public static List<ClienteDto> ClientesAsList()
        {
            List<ClienteDto> list = new List<ClienteDto>();
            foreach(DataRow dr in DaoManager.ClienteDao.GetClientes().Rows)
            {
                list.Add(new ClienteDto
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Domicilio = dr["Domicilio"].ToString(),
                    Colonia = dr["Colonia"].ToString(),
                    CP = dr["CP"].ToString(),
                    Telefono = dr["Telefono"].ToString(),
                    Email = dr["Email"].ToString(),
                    Habilitado = Convert.ToBoolean(dr["Habilitado"])
                });
            }
            return list;
        }

        public static List<CatalogoDto> PrendasAsList()
        { return CatalogoAsList(DaoManager.CatalogoDao.GetPrendas()); }

        public static List<CatalogoDto> ColoresAsList()
        { return CatalogoAsList(DaoManager.CatalogoDao.GetColores()); }

        public static List<CatalogoDto> TiposPrendaAsList()
        { return CatalogoAsList(DaoManager.CatalogoDao.GetTiposPrenda()); }

        public static List<DescuentoDto> DescuentosAsList()
        {
            List<DescuentoDto> list = new List<DescuentoDto>();
            foreach(DataRow dr in DaoManager.DescuentoDao.GetDescuentos().Rows)
            {
                DateTime inicio = Convert.ToDateTime(dr["VigenciaInicio"]);
                DateTime fin = Convert.ToDateTime(dr["VigenciaFin"]);
                DateTime now = DateTime.Now;
                if( now > inicio && now < fin )
                {
                    list.Add(new DescuentoDto
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Nombre = dr["Nombre"].ToString(),
                        VigenciaInicio = inicio,
                        VigenciaFin = fin,
                        CantMinima = Convert.ToDecimal(dr["CantMinima"]),
                        MontoMinimo = Convert.ToDecimal(dr["MontoMinimo"]),
                        Porcentaje = Convert.ToDecimal(dr["Porcentaje"]),
                        Unidades = Convert.ToDecimal(dr["Unidades"]),
                        SoloNota = Convert.ToBoolean(dr["SoloNota"])
                    }); 
                }
            }
            return list;
        }

        public static List<ServicioDto> ServiciosAsList()
        {
            List<ServicioDto> list = new List<ServicioDto>();
            foreach(DataRow dr in DaoManager.ServicioDao.GetServicios().Rows)
            {
                if(Convert.ToBoolean(dr["Habilitado"]))
                {
                    list.Add(new ServicioDto
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Costo = Convert.ToDecimal(dr["Costo"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return list;
        }

        public static List<UsuarioDto> UsuariosAsList()
        {
            List<UsuarioDto> list = new List<UsuarioDto>();
            foreach(DataRow dr in DaoManager.UsuarioDao.GetUsuarios().Rows)
            {
                list.Add(new UsuarioDto
                {
                    ID = Convert.ToInt64(dr["ID"]),
                    Nombre = dr.Field<string>("Nombre"),
                    Username = dr.Field<string>("Username"),
                    Bloqueado = Convert.ToBoolean(dr["Bloqueado"]),
                    IntentosFallidos = Convert.ToInt32(dr["IntentosFallidos"]),
                    UltimoIngreso = dr["UltimoIngreso"].GetType() != typeof(DBNull) ? Convert.ToDateTime(dr["UltimoIngreso"]) : new DateTime(),
                    Permisos = new Permisos(Convert.ToInt32(dr["Permisos"])),
                    Logged = false
                });
            }
            return list;
        }
    }
}
