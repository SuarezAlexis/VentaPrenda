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
    public class NotaDaoMySQL : INotaDao
    {
        private static readonly string SELECT_SQL = "SELECT * FROM Nota";
        private static readonly string PRENDA_SELECT_SQL = "SELECT * FROM PrendaItem";
        private static readonly string SERVICIO_SELECT_SQL = "SELECT * FROM ServicioItem";
        private static readonly string INSERT_SQL = "INSERT INTO Nota (Estatus,Cliente,Recibido,Entregado,Observaciones,Descuento) VALUES (@Estatus,@Cliente,CURRENT_TIMESTAMP,@Entregado,@Observaciones,@Descuento); SELECT last_insert_id();";
        private static readonly string PRENDA_INSERT_SQL = "INSERT INTO PrendaItem(Nota,Cantidad,Prenda,Tipo,Color) VALUES";
        private static readonly string SERVICIO_INSERT_SQL = "INSERT INTO ServicioItem(PrendaItem,Cantidad,Servicio,Monto,Descuento,Encargado) VALUES";
        private static readonly string UPDATE_SQL = "UPDATE Descuento SET Nombre = @Nombre, VigenciaInicio = @VigenciaInicio, VigenciaFin = @VigenciaFin, MontoMinimo = @MontoMinimo, CantMinima = @CantMinima, SoloNota = @SoloNota, Porcentaje = @Porcentaje, Unidades = @Unidades WHERE ID = @ID";
        private static readonly string DELETE_SQL = "sp_DeleteDescuento";

        private static NotaDto Map(DataTable dt)
        {
            NotaDto dto = null;
            if(dt.Rows.Count > 0)
            {
                dto = new NotaDto { };
            }
            return dto;
        }

        private static PrendaItemDto MapPrenda(DataRow dr)
        {
            PrendaItemDto dto = null;
            if(dr != null)
            {
                dto = new PrendaItemDto
                {
                    ID = Convert.ToInt64(dr["ID"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"])
                };
            }
            return dto;
        }

        public NotaDto EliminarNota(NotaDto dto)
        {
            throw new NotImplementedException();
        }

        public NotaDto GetNota(long id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetNotas()
        {
            throw new NotImplementedException();
        }

        public NotaDto GuardarNota(NotaDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Estatus", (short)dto.Estatus);
            param.Add("@Cliente", dto.Cliente.ID);
            param.Add("@Entregado", dto.Entregado);
            param.Add("@Observaciones", dto.Observaciones);
            param.Add("@Descuento", dto.Descuento.ID);

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
                    dto.ID = dt.Rows.Count > 0 ? Convert.ToInt64(dt.Rows[0][0]) : -1;
                    GuardarPrendas(dto.Prendas);
                }
                catch (MySqlException e)
                {
                    if (e.Number == 1062)
                    { throw new DuplicateKeyException(e); }
                }
            }
            return dto;
        }

        private void GuardarPrendas(List<PrendaItemDto> Prendas)
        {
            string query = PRENDA_INSERT_SQL;
            foreach (PrendaItemDto p in Prendas)
            {
                query += "(" + p.Nota.ID + "," + p.Cantidad + "," + p.Prenda.ID + "," + p.TipoPrenda != null? p.TipoPrenda.ID.ToString() : "NULL" + "," + p.Color.ID + "),";
            } query.Trim(new char[] { ',' });
            query += "; " + PRENDA_SELECT_SQL + " WHERE Nota = " + Prendas[0].Nota.ID;
            try
            {
                DataTable dt = MySqlDbContext.Query(query);
                int i = 0;
                foreach(DataRow dr in dt.Rows)
                { Prendas[i++].ID = Convert.ToInt64(dr["ID"]); }
            } catch (MySqlException e)
            {
                //Registrar en log
                throw e;
            }
        }

        private void GuardarServicios(List<ServicioItemDto> Servicios)
        {
            string query = SERVICIO_INSERT_SQL;
            foreach(ServicioItemDto s in Servicios)
            {
                query += "(),";
            } query.Trim(new char[] { ',' });
            query += "; " + SERVICIO_SELECT_SQL + " WHERE PrendaItem = " + Servicios[0].PrendaItem.ID;
            try
            {
                DataTable dt = MySqlDbContext.Query(query);
                int i = 0;
                foreach(DataRow dr in dt.Rows)
                { Servicios[i++].ID = Convert.ToInt64(dr["ID"]); }
            }
            catch (MySqlException e)
            {
                //Registrar en log
                throw e;
            }
        }
    }
}
