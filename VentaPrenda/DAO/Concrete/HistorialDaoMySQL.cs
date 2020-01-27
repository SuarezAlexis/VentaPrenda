using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Concrete
{
    public class HistorialDaoMySQL : IHistorialDao
    {
        private static readonly String SELECT_SQL = "SELECT H.ID, U.ID UID, U.Nombre, U.Username, U.Bloqueado, U.IntentosFallidos, U.UltimoIngreso, H.Concepto, H.Fecha, DH.ID DHID, DH.Operacion, DH.Tabla, DH.Columna, DH.Valor FROM Historial H JOIN Usuario U ON(U.ID = H.Usuario) JOIN DatosHistorial DH ON(DH.Historial = H.ID)";
        private static readonly String SELECT_LIST_SQL = "SELECT H.ID, U.Username, U.Nombre, H.Concepto, H.Fecha FROM Historial H JOIN Usuario U ON(U.ID = H.Usuario) ORDER BY H.Fecha DESC";
        private static readonly String INSERT_SQL = "INSERT INTO Historial (Usuario,Concepto,Fecha) VALUES(@Usuario,@Concepto,@Fecha); SELECT LAST_INSERT_ID();";
        private static readonly String INSERT_DATOS_SQL = "INSERT INTO DatosHistorial(Historial,Operacion,Tabla,Columna,Valor) VALUES";

        private HistorialDto Map(DataTable dt)
        {
            HistorialDto h = null;
            if(dt.Rows.Count > 0)
            {
                h = new HistorialDto
                {
                    ID = Convert.ToInt64(dt.Rows[0]["ID"]),
                    Usuario = new UsuarioDto
                    {
                        ID = Convert.ToInt64(dt.Rows[0]["UID"]),
                        Nombre = dt.Rows[0]["Nombre"].ToString(),
                        Username = dt.Rows[0]["Username"].ToString(),
                        Bloqueado = Convert.ToBoolean(dt.Rows[0]["Bloqueado"]),
                        IntentosFallidos = Convert.ToInt32(dt.Rows[0]["IntentosFallidos"]),
                        UltimoIngreso = Convert.ToDateTime(dt.Rows[0]["UltimoIngreso"])
                    },
                    Concepto = dt.Rows[0]["Concepto"].ToString(),
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"])
                };
                foreach(DataRow dr in dt.Rows)
                {
                    DatoHistorialDto d = new DatoHistorialDto
                    {
                        ID = Convert.ToInt64(dr["DHID"]),
                        Historial = h,
                        Operacion = Convert.ToChar(dr["Operacion"]),
                        Tabla = dr["Tabla"].ToString(),
                        Columna = dr["Columna"].ToString(),
                        Valor = dr["Valor"].ToString()
                    };
                    h.Cambios.Add(d);
                }
            }
            return h;
        }

        public HistorialDto GetHistorial(long id)
        { return Map(MySqlDbContext.Query(SELECT_SQL + " WHERE H.ID = " + id)); }

        public DataTable GetHistorial()
        { return MySqlDbContext.Query(SELECT_LIST_SQL); }

        public HistorialDto Guardar(HistorialDto dto)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@Usuario", dto.Usuario.ID);
            param.Add("@Concepto", dto.Concepto);
            param.Add("@Fecha", DateTime.Now);
            DataTable dt = MySqlDbContext.Query(INSERT_SQL, param);
            dto.ID = dt.Rows.Count > 0 ? Convert.ToInt64(dt.Rows[0][0]) : -1;
            string query = INSERT_DATOS_SQL;
            foreach(DatoHistorialDto d in dto.Cambios)
            {
                query += " (" + dto.ID +","
                    + "'" + d.Operacion + "',"
                    + "'" + d.Tabla + "',"
                    + "'" + d.Columna + "',"
                    + "'" + d.Valor + "'),";
            }
            query = query.Trim(new char[] { ',' });
            MySqlDbContext.Query(query);
            return dto;            
        }
    }
}
