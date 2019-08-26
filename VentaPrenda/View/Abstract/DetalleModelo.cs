using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaPrenda.View.Abstract
{
    public class DetalleModelo : UserControl
    {
        public virtual bool ReadOnly { get; set; }
        public virtual object Dto { get; set; }
        public virtual void Clear() { }
        public virtual void Fill(Object model) { }
    }
}
