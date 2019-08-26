using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.Controller;
using VentaPrenda.Model;

namespace VentaPrenda.View.Abstract
{
    public interface IMainView
    {
        /************************** ATRIBUTOS ******************************/
        MainController Controller { get; set; }
        DataTable DataSource { get; set; }
        object Dto { get; set; }

        /*************************** MÉTODOS *******************************/
        void ShowDashboard();
        void UpdateModo();
        void UpdateFuncion();
        void SetProfile(Permisos permisos);
        void DuplicateKeyAlert(string duplicateKey);
    }
}
