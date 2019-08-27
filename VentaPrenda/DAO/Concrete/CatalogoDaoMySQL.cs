using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;

namespace VentaPrenda.DAO.Concrete
{
    enum Catalogo
    {
        Color,
        Prenda,
        TipoPrenda
    }
    public class CatalogoDaoMySQL : ICatalogoDao
    {
        public static readonly string SELECT_SQL = "SELECT * FROM ";
        public static readonly string INSERT_SQL = "(Nombre,Habilitado) VALUES(@Nombre,@Habilitado); SELECT LAST_INSERT_ID();";
        public static readonly string UPDATE_SQL = " SET Nombre = @Nombre, Habilitado = @Habilitado WHERE ID = @ID";
        public static readonly string DELETE_SQL = "sp_DeleteCatalogo";
        

        private static CatalogoDto Map(DataRow dr)
        {
            CatalogoDto c = null;
            if(dr != null)
            {
                c = new CatalogoDto
                {
                    ID = Convert.ToInt16(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Habilitado = Convert.ToBoolean(dr["Habilitado"])
                };
            }
            return c;
        }

        private CatalogoDto Eliminar(CatalogoDto dto, Catalogo cat)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", dto.ID);
            param.Add("p_Cat", cat.ToString());
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        private CatalogoDto GetRecord(Catalogo cat, short id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + cat + " WHERE ID = " + id);
            return dt != null && dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        private CatalogoDto Guardar(CatalogoDto dto, Catalogo cat)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Nombre", dto.Nombre);
            param.Add("@Habilitado", dto.Habilitado ? 1 : 0);

            if (dto.ID > 0)
            {
                param.Add("@ID", dto.ID.ToString());
                MySqlDbContext.Update("UPDATE " + cat + UPDATE_SQL, param);
            }
            else
            {
                try
                {
                    DataTable dt = MySqlDbContext.Query("INSERT INTO " + cat + INSERT_SQL, param);
                    dto.ID = (short)(dt.Rows.Count > 0 ? Convert.ToInt16(dt.Rows[0][0]) : -1);
                }
                catch (MySqlException e)
                {
                    if (e.Number == 1062)
                    {
                        int firstIdx = e.Message.IndexOf("'");
                        int secondIdx = e.Message.IndexOf("'", firstIdx + 1);
                        string duplicateId = e.Message.Substring(firstIdx, secondIdx - firstIdx + 1);
                        throw new DuplicateKeyException(duplicateId, e);
                    }
                }
            }
            return dto;
        }

        public CatalogoDto EliminarColor(CatalogoDto dto)
        { return Eliminar(dto, Catalogo.Color); }

        public CatalogoDto EliminarPrenda(CatalogoDto dto)
        { return Eliminar(dto, Catalogo.Prenda); }

        public CatalogoDto EliminarTipoPrenda(CatalogoDto dto)
        { return Eliminar(dto, Catalogo.TipoPrenda); }

        public CatalogoDto GetColor(short ColorID)
        { return GetRecord(Catalogo.Color, ColorID); }
        public CatalogoDto GetPrenda(short PrendaID)
        { return GetRecord(Catalogo.Prenda, PrendaID); }
        public CatalogoDto GetTipoPrenda(short TipoPrendaID)
        { return GetRecord(Catalogo.TipoPrenda, TipoPrendaID); }

        public DataTable GetColores()
        { return MySqlDbContext.Query(SELECT_SQL + "Color"); }       

        public DataTable GetPrendas()
        { return MySqlDbContext.Query(SELECT_SQL + "Prenda"); }


        public DataTable GetTiposPrenda()
        { return MySqlDbContext.Query(SELECT_SQL + "TipoPrenda"); }

        public CatalogoDto GuardarColor(CatalogoDto dto)
        { return Guardar(dto, Catalogo.Color); }

        public CatalogoDto GuardarPrenda(CatalogoDto dto)
        { return Guardar(dto, Catalogo.Prenda); }

        public CatalogoDto GuardarTipoPrenda(CatalogoDto dto)
        { return Guardar(dto, Catalogo.TipoPrenda); }
    }
}
