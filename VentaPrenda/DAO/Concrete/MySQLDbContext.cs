using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Exceptions;

namespace VentaPrenda.DAO.Concrete
{
    public class MySqlDbContext
    {
        private static MySqlConnection conn;
        private static readonly string ConnString = "LocalMySQL";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConfigurationManager.ConnectionStrings[ConnString].ConnectionString);
        }

        public static DataTable Query(string query)
        {
            using (conn = GetConnection())
            {
                DataTable table = new DataTable();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    conn.Open();
                    table.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                    return table;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static DataTable Query(string query, Dictionary<string,string> param)
        {
            using (conn = GetConnection())
            {
                DataTable table = new DataTable();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                foreach (KeyValuePair<string, string> p in param)
                { cmd.Parameters.AddWithValue(p.Key, p.Value); }

                try
                {
                    conn.Open();
                    table.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                    return table;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static int Update(string query)
        {
            int rows = -1;
            using (conn = GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();
                    return rows;
                } catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static int Update(string query, Dictionary<string,string> param)
        {
            int rows = -1;
            using (conn = GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                foreach(KeyValuePair<string,string> p in param)
                { cmd.Parameters.AddWithValue(p.Key,p.Value); }
                try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static DataTable Call(string proc, Dictionary<string, string> param)
        {
            conn = GetConnection();
            DataTable table = new DataTable();
            MySqlCommand cmd = new MySqlCommand(proc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, string> p in param)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            try
            {
                conn.Open();
                table.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042:
                        throw new CouldNotConnectException(e);
                    default:
                        throw e;
                }
            }
            return table;
        }
    }
}
