using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Service;

namespace VentaPrenda.DTO
{
    public class LoginDto
    {
        private string _contraseña;
        public string Usuario { get; set; }
        public string Contraseña {
            get { return _contraseña; }
            set { _contraseña = Cipher.Encrypt(value); }
        }
    }
}
