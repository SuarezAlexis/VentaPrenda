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
using VentaPrenda.Model;

namespace VentaPrenda.DAO.Concrete
{
    public class PerfilDaoMySQL : IPerfilDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Perfil";
        private static readonly string INSERT_SQL = "INSERT INTO Perfil(Nombre,Permisos) VALUES (@Nombre,@Permisos); SELECT LAST_INSERT_ID();";
        private static readonly string UPDATE_SQL = "UPDATE Perfil SET Nombre = @Nombre, Permisos = @Permisos  WHERE ID = @ID";
        private static readonly string DELETE_SQL = "sp_DeletePerfil";


        private static PerfilDto Map(DataRow dr)
        {
            PerfilDto p = null;
            if(dr != null)
            {
                p = new PerfilDto {
                    ID = Convert.ToInt16(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Permisos = new Permisos { Numeric = Convert.ToInt32(dr["Permisos"])}
                };
            }
            return p;
        }
        public PerfilDto EliminarPerfil(PerfilDto p)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_Perfil", p.ID.ToString());
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public PerfilDto GetPerfil(short PerfilID)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + " WHERE ID = " + PerfilID);
            return dt.Rows.Count > 0? Map(dt.Rows[0]) : null;
        }

        public DataTable GetPerfiles()
        {
            return MySqlDbContext.Query(SELECT_SQL);
        }

        public PerfilDto GuardarPerfil(PerfilDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Nombre", dto.Nombre);
            param.Add("@Permisos", dto.Permisos.Numeric.ToString());

            if (dto.ID > 0)
            {
                param.Add("@ID", dto.ID.ToString());
                MySqlDbContext.Update(UPDATE_SQL, param);
            } else
            {
                try
                {
                    DataTable dt = MySqlDbContext.Query(INSERT_SQL, param);
                    dto.ID = (short)(dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : -1);
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
