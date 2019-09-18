using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO.Concrete;

namespace VentaPrenda.Service
{
    public class Reportes
    {
        private static readonly string INGRESOS_SQL = "sp_ReporteNotas";
        private static readonly string CLIENTES_SQL = "SELECT C.ID, C.Nombre, SUM(Monto) Monto, SUM(Prendas) Prendas, SUM(Servicios) Servicios, C.Domicilio, C.Colonia, C.CP, C.Email, C.Habilitado FROM ClienteStatsView CSV JOIN Cliente C ON(C.ID = CSV.ID)WHERE Fecha BETWEEN  @Inicio AND @Fin GROUP BY ID";
        private static readonly string CLIENTE_STATS_SQL = "SELECT SUM(Monto) Monto, SUM(Prendas) Prendas, SUM(Servicios) Servicios FROM ClienteStatsView WHERE ID = @ID AND Fecha >= TIMESTAMP(@Fecha)";


        public static DataTable Ingresos(DateTime desde, DateTime hasta)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_Inicio", desde);
            param.Add("p_Fin", hasta.AddDays(1));
            return MySqlDbContext.Call(INGRESOS_SQL, param);
        }

        public static DataTable Clientes(DateTime desde, DateTime hasta)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Inicio", desde);
            param.Add("@Fin", hasta.AddDays(1));
            return MySqlDbContext.Query(CLIENTES_SQL,param);
        }

        public static decimal MontoAcumulado(int clienteID, DateTime desde)
        {
            if (clienteID >= 0)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@ID", clienteID);
                param.Add("@Fecha", desde);
                DataTable dt = MySqlDbContext.Query(CLIENTE_STATS_SQL, param);
                return dt.Rows.Count > 0 && dt.Rows[0]["Monto"].GetType() != typeof(DBNull) ? Convert.ToDecimal(dt.Rows[0]["Monto"]) : 0M;
            }
            else
            { return 0; }
        }

        public static int ServiciosAcumulados(int clienteID, DateTime desde)
        {
            if(clienteID >= 0)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@ID", clienteID);
                param.Add("@Fecha", desde);
                DataTable dt = MySqlDbContext.Query(CLIENTE_STATS_SQL, param);
                return dt.Rows.Count > 0 && dt.Rows[0]["Servicios"].GetType() != typeof(DBNull) ? Convert.ToInt32(dt.Rows[0]["Servicios"]) : 0;
            }
            else
            { return 0; }
            
        }
    }
}
