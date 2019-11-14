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
            /*
            Console.WriteLine("Iniciando migración de perfiles...");
            if (!Migracion.Perfiles()) return;
            Console.WriteLine("Iniciando migración de usuarios...");
            if (!Migracion.Usuarios()) return;
            Console.WriteLine("Iniciando migración de catálogos...");
            if (!Migracion.Catalogos()) return;
            Console.WriteLine("Iniciando migración de servicios...");
            if (!Migracion.Servicios()) return;
            Console.WriteLine("Iniciando migración de clientes...");
            if (!Migracion.Clientes()) return;
            */
            Console.WriteLine("Iniciando migración de notas...");
            if (!Migracion.Notas()) return;
        }
    }
}
