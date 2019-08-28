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
        private static string extractKey(Exception e)
        {
            int firstIdx = e.Message.IndexOf("'");
            int secondIdx = e.Message.IndexOf("'", firstIdx + 1);
            return e.Message.Substring(firstIdx, secondIdx - firstIdx + 1);
        }
        public DuplicateKeyException(Exception innerException) : base("Error al insertar en base de datos. Ya existe un registro con el identificador: " + extractKey(innerException) + ".", innerException)
        {
            DuplicatedKey = extractKey(innerException);
        }
    }
}
