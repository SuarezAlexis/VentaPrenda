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
    public class TicketConfigDaoMySQL : ITicketConfigDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Ticket WHERE ID = 1";
        private static readonly string UPDATE_SQL = "UPDATE Ticket SET Impresora = @Impresora, Encabezado = @Encabezado, Pie = @Pie WHERE ID = 1";

        private static TicketConfigDto Map(DataRow dr)
        {
            TicketConfigDto dto = null;
            if(dr != null)
            {
                dto = new TicketConfigDto
                {
                    PrinterName = dr["Impresora"].GetType() == typeof(DBNull)? null : dr["Impresora"].ToString(),
                    Encabezado = dr["Encabezado"].GetType() == typeof(DBNull) ? null : dr["Encabezado"].ToString(),
                    Pie = dr["Pie"].GetType() == typeof(DBNull) ? null : dr["Pie"].ToString()
                };
            }
            return dto;
        }

        public TicketConfigDto GetConfig()
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public TicketConfigDto GuardarConfig(TicketConfigDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Impresora",dto.PrinterName);
            param.Add("@Encabezado", dto.Encabezado);
            param.Add("@Pie", dto.Pie);
            MySqlDbContext.Update(UPDATE_SQL, param);
            return dto;
        }
    }
}
