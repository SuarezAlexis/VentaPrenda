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
    public class DescuentoDaoMySQL : IDescuentoDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Descuento";
        private static readonly string INSERT_SQL = "INSERT INTO Descuento(Nombre,VigenciaInicio,VigenciaFin,MontoMinimo,CantMinima,Porcentaje,Unidades) VALUES(@Nombre,@VigenciaInicio,@VigenciaFin,@MontoMinimo,@CantMinima,@Porcentaje,@Unidades); SELECT LAST_INSERT_ID();";
        private static readonly string UPDATE_SQL = "UPDATE Descuento SET Nombre = @Nombre, VigenciaInicio = @VigenciaInicio, VigenciaFin = @VigenciaFin, MontoMinimo = @MontoMinimo, CantMinima = @CantMinima, Porcentaje = @Porcentaje, Unidades = @Unidades WHERE ID = @ID";
        private static readonly string DELETE_SQL = "sp_DeleteDescuento";

        private static DescuentoDto Map(DataRow dr)
        {
            DescuentoDto dto = null;
            if (dr != null)
            {
                dto = new DescuentoDto
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    VigenciaInicio = Convert.ToDateTime(dr["VigenciaInicio"]),
                    VigenciaFin = Convert.ToDateTime(dr["VigenciaFin"]),
                    CantMinima = Convert.ToDecimal(dr["CantMinima"]),
                    MontoMinimo = Convert.ToDecimal(dr["MontoMinimo"]),
                    Porcentaje = Convert.ToDecimal(dr["Porcentaje"]),
                    Unidades = Convert.ToDecimal(dr["Unidades"])
                };
            }
            return dto;
        }

        public DescuentoDto EliminarDescuento(DescuentoDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", dto.ID);
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public DescuentoDto GetDescuento(int id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + " WHERE ID = " + id);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public DataTable GetDescuentos()
        {
            return MySqlDbContext.Query(SELECT_SQL);
        }

        public DescuentoDto GuardarDescuento(DescuentoDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Nombre", dto.Nombre);
            param.Add("@VigenciaInicio", dto.VigenciaInicio);
            param.Add("@VigenciaFin", dto.VigenciaFin);
            param.Add("@MontoMinimo", dto.MontoMinimo);
            param.Add("@CantMinima", dto.CantMinima);
            param.Add("@Porcentaje", dto.Porcentaje);
            param.Add("@Unidades", dto.Unidades);

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
