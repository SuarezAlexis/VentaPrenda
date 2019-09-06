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
    public class ServicioDaoMySQL : IServicioDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Servicio";
        private static readonly string INSERT_SQL = "INSERT INTO Servicio(Nombre,Descripcion,Costo,Habilitado) VALUES(@Nombre,@Descripcion,@Costo,@Habilitado); SELECT LAST_INSERT_ID();";
        private static readonly string UPDATE_SQL = "UPDATE Servicio SET Nombre = @Nombre, Descripcion = @Descripcion, Costo = @Costo, Habilitado = @Habilitado WHERE ID = @ID";
        private static readonly string DELETE_SQL = "sp_DeleteServicio";

        private static ServicioDto Map(DataRow dr)
        {
            ServicioDto dto = null;
            if(dr != null)
            {
                dto = new ServicioDto
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Descripcion = dr["Descripcion"].ToString(),
                    Costo = Convert.ToDecimal(dr["Costo"]),
                    Habilitado = Convert.ToBoolean(dr["Habilitado"])
                };
            }
            return dto;
        }

        public ServicioDto EliminarServicio(ServicioDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", dto.ID);
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public ServicioDto GetServicio(int id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + " WHERE ID = " + id);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public DataTable GetServicios()
        {
            return MySqlDbContext.Query(SELECT_SQL + " ORDER BY Nombre ASC");
        }

        public ServicioDto GuardarServicio(ServicioDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Nombre", dto.Nombre);
            param.Add("@Descripcion", dto.Descripcion);
            param.Add("@Costo", dto.Costo);
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
