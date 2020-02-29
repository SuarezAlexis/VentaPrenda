using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Herramienta de migración de base de datos de ElBuenAjuste a VentaPrenda\n");
            if (args.Length == 0 || args.Contains("-p"))
            {
                Console.WriteLine("Iniciando migración de perfiles...");
                if (!Migracion.Perfiles()) return;
            }
            if (args.Length == 0 || args.Contains("-u"))
            {
                Console.WriteLine("Iniciando migración de usuarios...");
                if (!Migracion.Usuarios()) return;
            }
            if (args.Length == 0 || args.Contains("-cat"))
            {
                Console.WriteLine("Iniciando migración de catálogos...");
                if (!Migracion.Catalogos()) return;
            }
            if (args.Length == 0 || args.Contains("-s"))
            {
                Console.WriteLine("Iniciando migración de servicios...");
                if (!Migracion.Servicios()) return;
            }
            if (args.Length == 0 || args.Contains("-c"))
            {
                Console.WriteLine("Iniciando migración de clientes...");
                if (!Migracion.Clientes()) return;
            }
            if (args.Length == 0 || args.Contains("-n"))
            {
                long desde = -1;
                if(args.Contains("-n") && (args.Length - 1) > args.ToList().IndexOf("-n"))
                {
                    long.TryParse(args[args.ToList().IndexOf("-n") + 1], out desde);
                }
                Console.WriteLine("Iniciando migración de notas...");
                if (!Migracion.Notas(desde)) return;
            }
        }
    }
}
