using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Exceptions
{
    class CouldNotConnectException : DatabaseException
    {
        public CouldNotConnectException(Exception innerException) : base("No fue posible establecer una conexión con la base de datos.",innerException)
        {            
        }
    }
}
