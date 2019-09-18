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
    public class MovimientoDaoMySQL : IMovimientoDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Movimiento";
        private static readonly string INSERT_SQL = "INSERT INTO Movimiento(Concepto,Importe,Descripcion,Fecha,NumFactura,RFC,FechaFactura) VALUES(@Concepto,@Importe,@Descripcion,@Fecha,@NumFactura,@RFC,@FechaFactura); SELECT LAST_INSERT_ID();";
        private static readonly string UPDATE_SQL = "UPDATE Movimiento SET Concepto = @Concepto, Importe = @Importe, Descripcion = @Descripcion, Fecha = @Fecha, NumFactura = @NumFactura, RFC = @RFC, FechaFactura = @FechaFactura WHERE ID = @ID";
        private static readonly string DELETE_SQL = "sp_DeleteMovimiento";

        private static MovimientoDto Map(DataRow dr)
        {
            MovimientoDto dto = null;
            if (dr != null)
            {
                dto = new MovimientoDto
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Concepto = dr["Concepto"].ToString(),
                    Importe = Convert.ToDecimal(dr["Importe"]),
                    Descripcion = dr["Descripcion"].ToString(),
                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                    NumFactura = dr["NumFactura"].GetType() == typeof(DBNull)? string.Empty : dr["NumFactura"].ToString(),
                    RFC = dr["RFC"].GetType() == typeof(DBNull)? string.Empty : dr["RFC"].ToString(),
                    FechaFactura = dr["FechaFactura"].GetType() == typeof(DBNull)? new DateTime() : Convert.ToDateTime(dr["FechaFactura"])
                };
            }
            return dto;
        }

        public MovimientoDto EliminarMovimiento(MovimientoDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", dto.ID);
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public MovimientoDto GetMovimiento(long id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + " WHERE ID = " + id);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public DataTable GetMovimientos()
        {
            return MySqlDbContext.Query(SELECT_SQL);
        }

        public MovimientoDto GuardarMovimiento(MovimientoDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Concepto", dto.Concepto);
            param.Add("@Importe", dto.Importe);
            param.Add("@Descripcion", dto.Descripcion);
            param.Add("@Fecha", dto.Fecha);
            param.Add("@NumFactura", dto.NumFactura);
            param.Add("@RFC", dto.RFC);
            param.Add("@FechaFactura", dto.FechaFactura);

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
