using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private static readonly string UPDATE_SQL = "UPDATE Ticket SET Impresora = @Impresora, Encabezado = @Encabezado, Pie = @Pie, Logo = @Logo, Ancho = @Ancho WHERE ID = 1";

        private static TicketConfigDto Map(DataRow dr)
        {
            TicketConfigDto dto = null;
            if(dr != null)
            {
                dto = new TicketConfigDto
                {
                    PrinterName = dr["Impresora"].GetType() == typeof(DBNull) ? null : dr["Impresora"].ToString(),
                    Encabezado = dr["Encabezado"].GetType() == typeof(DBNull) ? String.Empty : dr["Encabezado"].ToString(),
                    Pie = dr["Pie"].GetType() == typeof(DBNull) ? String.Empty : dr["Pie"].ToString(),
                    Logo = dr["Logo"].GetType() == typeof(DBNull) ? null : Image.FromStream(new MemoryStream((byte[])dr["Logo"])),
                    Ancho = Convert.ToInt32(dr["Ancho"])
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
            byte[] ImgByteArray = null;
            if (dto.Logo != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    dto.Logo.Save(ms, ImageFormat.Png);
                    ImgByteArray = ms.ToArray();
                }
            }
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Impresora",dto.PrinterName);
            param.Add("@Encabezado", dto.Encabezado);
            param.Add("@Pie", dto.Pie);
            param.Add("@Logo", ImgByteArray);
            param.Add("@Ancho", dto.Ancho);
            MySqlDbContext.Update(UPDATE_SQL, param);
            return dto;
        }
    }
}
