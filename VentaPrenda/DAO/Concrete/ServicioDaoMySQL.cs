using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;

namespace VentaPrenda.DAO.Concrete
{
    public class ServicioDaoMySQL : IServicioDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Servicio";
        private static readonly string SELECT_PRENDAS_SQL = "SELECT P.* FROM Servicio_Prenda SP JOIN Prenda P ON(P.ID = SP.Prenda) WHERE SP.Servicio = @ID";
        private static readonly string INSERT_SQL = "INSERT INTO Servicio(Nombre,Descripcion,Costo,Habilitado) VALUES(@Nombre,@Descripcion,@Costo,@Habilitado); SELECT LAST_INSERT_ID();";
        private static readonly string UPDATE_PRENDAS_SQL = "sp_UpdateServicioPrenda";
        private static readonly string UPDATE_SQL = "UPDATE Servicio SET Nombre = @Nombre, Descripcion = @Descripcion, Costo = @Costo, Habilitado = @Habilitado WHERE ID = @ID";
        private static readonly string DELETE_SQL = "sp_DeleteServicio";

        private static ServicioDto Map(DataRow dr)
        {
            ServicioDto dto = null;
            if(dr != null)
            {
                dto = new ServicioDto
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Descripcion = dr["Descripcion"].ToString(),
                    Costo = Convert.ToDecimal(dr["Costo"]),
                    Habilitado = Convert.ToBoolean(dr["Habilitado"])
                };
            }
            return dto;
        }

        private static CatalogoDto PrendaMap(DataRow dr)
        {
            CatalogoDto p = null;
            if(dr != null)
            {
                p = new CatalogoDto
                {
                    ID = Convert.ToInt16(dr["ID"]),
                    Nombre = dr["Nombre"].ToString(),
                    Habilitado = Convert.ToBoolean(dr["Habilitado"])
                };
            }
            return p;
        }

        public ServicioDto EliminarServicio(ServicioDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", dto.ID);
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public ServicioDto GetServicio(int id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + " WHERE ID = " + id);
            ServicioDto servicio = dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@ID", id);
            foreach(DataRow dr in  MySqlDbContext.Query(SELECT_PRENDAS_SQL, param).Rows)
            { servicio.Prendas.Add(PrendaMap(dr)); }

            return servicio;
        }

        public DataTable GetServicios()
        {
            return MySqlDbContext.Query(SELECT_SQL + " ORDER BY Nombre ASC");
        }

        public ServicioDto GuardarServicio(ServicioDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Nombre", dto.Nombre);
            param.Add("@Descripcion", dto.Descripcion);
            param.Add("@Costo", dto.Costo);
            param.Add("@Habilitado", dto.Habilitado);

            if (dto.ID > 0)
            {
                param.Add("@ID", dto.ID);
                MySqlDbContext.Update(UPDATE_SQL, param);
            }
            else
            {
                try
                {
                    DataTable dt = MySqlDbContext.Query(INSERT_SQL, param);
                    dto.ID = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : -1;
                }
                catch (MySqlException e)
                {
                    if (e.Number == 1062)
                    { throw new DuplicateKeyException(e); }
                }
            }
            GuardarPrendas(dto.Prendas, dto.ID);
            return dto;
        }

        private void GuardarPrendas(List<CatalogoDto> Prendas, int ServicioID)
        {
            Dictionary<string,object> param = new Dictionary<string, object>();
            param.Add("@p_Servicio", ServicioID);
            string prendas = "";
            foreach (CatalogoDto p in Prendas)
            {
                prendas += p.ID + ",";
            }
            prendas = prendas.Substring(0, Math.Max(0,prendas.Length - 1));
            param.Add("@p_Prendas", prendas);
            MySqlDbContext.Call(UPDATE_PRENDAS_SQL, param);
        }
    }
}
