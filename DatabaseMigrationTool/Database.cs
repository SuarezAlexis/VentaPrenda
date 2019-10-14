using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ElBuenAjuste
{
    public class Database
    {
        private static SqlConnection conn;
        public static DataTable Query(string query)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                table.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch (SqlException e)
            {
                /*
                ProcessStartInfo procStartInfo = new ProcessStartInfo();
                procStartInfo.FileName = "cmd.exe";
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                procStartInfo.RedirectStandardInput = true;

                //command contains the command to be executed in cmd
                using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
                {
                    proc.StartInfo = procStartInfo;
                    proc.Start();
                    using (StreamWriter sw = proc.StandardInput)
                    {
                        if(sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("sc config MSSQLSERVER start=auto");
                            sw.WriteLine("net start MSSQLSERVER");
                        }
                    }
                }
                conn.Open();
                table.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                */
                throw e;
            }
            return table;
        }

        public static string DateTimeFormat(DateTime fecha)
        {
            string query = "";
            query += "'" + fecha.Year.ToString();
            query += fecha.Month < 10 ? "0" + fecha.Month.ToString() : fecha.Month.ToString();
            query += fecha.Day < 10 ? "0" + fecha.Day.ToString() : fecha.Day.ToString();
            query += " ";
            query += fecha.Hour < 10 ? "0" + fecha.Hour.ToString() + ":" : fecha.Hour.ToString() + ":";
            query += fecha.Minute < 10 ? "0" + fecha.Minute.ToString() + ":" : fecha.Minute.ToString() + ":";
            query += fecha.Second < 10 ? "0" + fecha.Second.ToString() : fecha.Second.ToString();
            query += "'";
            return query;
        }
    }
}
