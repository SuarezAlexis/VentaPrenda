using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.Controller;
using VentaPrenda.DAO.Concrete;
using VentaPrenda.Model;
using VentaPrenda.View.Concrete;

namespace VentaPrenda
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            AccountController accountController = new AccountController(new LoginForm());
            if ( accountController.Authenticate() )
            {
                MainController mainController = new MainController(new MainView(), accountController.Usuario);
                mainController.ShowView();
            }
        }
    }
}
