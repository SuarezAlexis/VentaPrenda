using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public class Usuario
    {
        public long ID { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Contraseña { get; set; }
        public bool Bloqueado { get; set; }
        public int IntentosFallidos { get; set; }
        public Permisos Permisos { get; set; }
        public bool Logged { get; set; }
        public DateTime UltimoIngreso { get; set; }
        public ColoresGUI Colores { get; set; }

        public Usuario() { Colores = new ColoresGUI(); }

        public override string ToString()
        {
            return Username + " " + Nombre;
        }
    }
}
