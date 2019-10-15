using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Service
{
    public class Logger
    {
        private static readonly string FilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Log.txt";

        public static void Log(string text)
        {
            StreamWriter sw;
            if (!File.Exists(FilePath))
            { sw = File.CreateText(FilePath); }
            else
            { sw = File.AppendText(FilePath); }
            sw.WriteLine(text);
            sw.Dispose();
        }
    }
}
