using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Controller;
using VentaPrenda.DTO;

namespace VentaPrenda.View.Abstract
{
    public interface ILoginView
    {
        /************************** ATRIBUTOS ******************************/
        AccountController Controller { get; set; }

        /*************************** MÉTODOS *******************************/
        LoginDto RequestCredentials();
        void WrongCredentials();

    }
}
