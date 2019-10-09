using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.DAO.Abstract
{
    interface IDbContext
    {
        DbConnection GetConnection();
        DataTable Query(string query);
        DataTable Query(string query, Dictionary<string, object> param);
        int Update(string query);
        int Update(string query, Dictionary<string, object> param);
        DataTable Call(string proc, Dictionary<string, object> param);
    }
}
