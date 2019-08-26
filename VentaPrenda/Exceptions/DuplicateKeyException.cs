using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Exceptions
{
    class DuplicateKeyException : DatabaseException
    {
        public string DuplicatedKey { get; set; }
        public DuplicateKeyException(string duplicateId, Exception innerException) : base("Error al insertar en base de datos. Ya existe un registro con el identificador: " + duplicateId + ".", innerException)
        {
            DuplicatedKey = duplicateId;
        }
    }
}
