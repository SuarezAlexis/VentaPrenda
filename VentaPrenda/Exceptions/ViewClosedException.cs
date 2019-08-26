using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Exceptions
{
    class ViewClosedException : Exception
    {
        Type ViewType { get; }
        public ViewClosedException(Type viewType)
        {
            ViewType = viewType;
        }
    }
}
