using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using VentaPrenda.Exceptions;
using VentaPrenda.Service;

namespace VentaPrenda.DAO.Concrete
{
    public class MySqlDbContext
    {
        //Constants
        private static DbConnection conn;
        private static readonly string ConnString = "LocalMySQL";
        //Backup constants
        private static readonly string BackupConnString = "LocalMySQLBackup";
        private static readonly string MySqlBinPath = ConfigurationManager.AppSettings.Get("MySqlDumpUtilityPath");
        private static readonly byte[] FileHeader = Encoding.ASCII.GetBytes("-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)\n--\n-- Host: localhost    Database: VentaPrenda\n-- ------------------------------------------------------\n-- Server version	8.0.17");


        public static DbConnection GetConnection()
        {
            return new MySqlConnection(ConfigurationManager.ConnectionStrings[ConnString].ConnectionString);
        }

        public static DataTable Query(string query)
        {
            using (conn = GetConnection())
            {
                DataTable table = new DataTable();
                MySqlCommand cmd = new MySqlCommand(query, (MySqlConnection)conn);

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

        public static DataTable Query(string query, Dictionary<string,object> param)
        {
            using (conn = GetConnection())
            {
                DataTable table = new DataTable();
                MySqlCommand cmd = new MySqlCommand(query, (MySqlConnection)conn);

                foreach (KeyValuePair<string, object> p in param)
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
                MySqlCommand cmd = new MySqlCommand(query, (MySqlConnection)conn);
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

        public static int Update(string query, Dictionary<string,object> param)
        {
            int rows = -1;
            using (conn = GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, (MySqlConnection)conn);
                foreach(KeyValuePair<string,object> p in param)
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

        public static DataTable Call(string proc, Dictionary<string, object> param)
        {
            conn = GetConnection();
            DataTable table = new DataTable();
            MySqlCommand cmd = new MySqlCommand(proc, (MySqlConnection)conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> p in param)
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

        public static string Backup(string BackupFolder)
        {
            Dictionary<string, string> data = ConfigurationManager.ConnectionStrings[BackupConnString].ConnectionString.Split(';').ToDictionary(s => s.Substring(0, s.IndexOf('=')));
            string DbUid = data["Uid"].Substring(data["Uid"].IndexOf('=') + 1);
            string DbPwd = data["Pwd"].Substring(data["Pwd"].IndexOf('=') + 1); ;
            string DbServer = data["Server"].Substring(data["Server"].IndexOf('=') + 1); ;

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = MySqlBinPath + "\\mysqldump";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            string fileName = DateTime.Now.ToString("yyyyMMMdd-HHmmss").Replace(".", "");
            string args = string.Format("-R -u{0} --password={1} -h{2} --databases {3} -r\"{4}\" --add-drop-database --routines",
                DbUid,
                DbPwd,
                DbServer,
                "VentaPrenda",
                BackupFolder + "\\" + fileName);
            psi.Arguments = args;

            Logger.Log(DateTime.Now.ToString("[ yyyy-MM-dd HH:mm ]") + " Inicia respaldo: " + psi.FileName + " " + psi.Arguments);

            Process process = Process.Start(psi);
            Logger.Log(process.StandardOutput.ReadToEnd());
            process.WaitForExit();
            process.Close();
            Logger.Log(DateTime.Now.ToString("[ yyyy-MM-dd HH:mm ]") + " Termina respaldo ------------------------------------");
            return fileName;
        }

        public static void Restore(string BackupFile)
        {
            Dictionary<string, string> data = ConfigurationManager.ConnectionStrings[BackupConnString].ConnectionString.Split(';').ToDictionary(s => s.Substring(0, s.IndexOf('=')));
            string DbUid = data["Uid"].Substring(data["Uid"].IndexOf('=') + 1);
            string DbPwd = data["Pwd"].Substring(data["Pwd"].IndexOf('=') + 1); ;
            string DbServer = data["Server"].Substring(data["Server"].IndexOf('=') + 1); ;

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = MySqlBinPath + "\\mysql";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = false;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            string args = string.Format("--default-character-set=utf8 -u{0} --password={1} -h{2} {3}",
                DbUid,
                DbPwd,
                DbServer,
                "VentaPrenda");
            psi.Arguments = args;

            Process process = Process.Start(psi);
            process.StandardInput.WriteLine("SOURCE " + BackupFile);
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            process.Close();
        }

        public static bool ValidateBackupFile(string BackupFile)
        {
            bool valid = false;
            using (FileStream s = File.OpenRead(BackupFile))
            {
                byte[] header = new byte[FileHeader.Length];
                s.Read(header, 0, FileHeader.Length);
                for (int i = 0; i < FileHeader.Length; i++)
                {
                    if (header[i] == FileHeader[i])
                    { valid = true; }
                    else
                    { valid = false; break; }
                }
            }
            return valid;
        }
    }
}
