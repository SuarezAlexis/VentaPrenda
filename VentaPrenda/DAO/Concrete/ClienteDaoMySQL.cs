using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;

namespace VentaPrenda.DAO.Concrete
{
    public class ClienteDaoMySQL : IClienteDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Cliente";
        private static readonly string SELECT_STATS_SQL = "SELECT * FROM ClienteStatsView";
        private static readonly string INSERT_SQL = "INSERT INTO Cliente(Nombre,Domicilio,Colonia,CP,Telefono,Email,Habilitado) VALUES(@Nombre,@Domicilio,@Colonia,@CP,@Telefono,@Email,@Habilitado); SELECT LAST_INSERT_ID();";
        private static readonly string UPDATE_SQL = "UPDATE Cliente SET Nombre = @Nombre, Domicilio = @Domicilio, Colonia = @Colonia, CP = @CP, Telefono = @Telefono, Email = @Email,Habilitado = @Habilitado WHERE ID = @ID";
        private static readonly string DELETE_SQL = "sp_DeleteCliente";

        private static ClienteDto Map(DataRow dr)
        {
            ClienteDto dto = null;
            if (dr != null)
            {
                dto = new ClienteDto
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Domicilio = dr["Domicilio"].ToString(),
                    Colonia = dr["Colonia"].ToString(),
                    CP = dr["CP"].ToString(),
                    Telefono = dr["Telefono"].ToString(),
                    Email = dr["Email"].ToString(),
                    Habilitado = Convert.ToBoolean(dr["Habilitado"])
                };
            }
            return dto;
        }

        public ClienteDto EliminarCliente(ClienteDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", dto.ID);
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public ClienteDto GetCliente(int id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + " WHERE ID = " + id);
            ClienteDto c = dt.Rows.Count > 0? Map(dt.Rows[0]) : null;
            foreach(DataRow dr in MySqlDbContext.Query(SELECT_STATS_SQL + " WHERE ID = " + id).Rows)
            {
                c.Estadisticas.MontoTotal += Convert.ToDecimal(dr["Monto"].GetType() != typeof(DBNull) ? dr["Monto"] : 0);
                c.Estadisticas.NotasTotal++;
                c.Estadisticas.PrendasTotal += Convert.ToInt32(dr["Prendas"]);
                c.Estadisticas.ServiciosTotal += Convert.ToInt32(dr["Servicios"]);
                if(Convert.ToDateTime(dr["Fecha"]) >= c.Estadisticas.Periodo)
                {
                    c.Estadisticas.MontoPeriodo += Convert.ToDecimal(dr["Monto"].GetType() != typeof(DBNull) ? dr["Monto"] : 0);
                    c.Estadisticas.NotasPeriodo++;
                    c.Estadisticas.PrendasPeriodo += Convert.ToInt32(dr["Prendas"]);
                    c.Estadisticas.ServiciosPeriodo += Convert.ToInt32(dr["Servicios"]);    
                }
            }
            return c;
        }

        public DataTable GetClientes()
        {
            return MySqlDbContext.Query(SELECT_SQL);
        }

        public ClienteDto GuardarCliente(ClienteDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Nombre", dto.Nombre);
            param.Add("@Domicilio", dto.Domicilio);
            param.Add("@Colonia", dto.Colonia);
            param.Add("@CP", dto.CP);
            param.Add("@Telefono", dto.Telefono);
            param.Add("@Email", dto.Email);
            param.Add("@Habilitado", dto.Habilitado);

            if (dto.ID > 0)
            {
                param.Add("@ID", dto.ID);
                MySqlDbContext.Update(UPDATE_SQL, param);
            }
            else
            {
                try
                {
                    DataTable dt = MySqlDbContext.Query(INSERT_SQL, param);
                    dto.ID = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : -1;
                }
                catch (MySqlException e)
                {
                    if (e.Number == 1062)
                    { throw new DuplicateKeyException(e); }
                }
            }
            return dto;
        }
    }
}
