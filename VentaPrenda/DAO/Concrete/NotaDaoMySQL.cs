using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.DAO.Concrete
{
    public class NotaDaoMySQL : INotaDao
    {
        private static readonly string SELECT_SQL = "SELECT N.ID NotaID, N.Estatus, N.Cliente ClienteID, C.Nombre ClienteNombre, C.Domicilio, C.Colonia, C.CP, C.Telefono, C.Email, C.Habilitado ClienteHabilitado, Recibido, Entregado, Observaciones, N.Descuento DescuentoID, D.Nombre DescuentoNombre, D.VigenciaInicio, D.VigenciaFin, D.MontoMinimo, D.CantMinima, D.Porcentaje, D.Unidades, D.SoloNota, PI.ID PrendaItemID, PI.Cantidad PrendaItemCantidad, PI.Prenda PrendaID, P.Nombre PrendaNombre, P.Habilitado PrendaHabilitado, PI.TipoPrenda TipoID, T.Nombre TipoNombre, T.Habilitado TipoHabilitado, PI.Color ColorID, Co.Nombre ColorNombre, Co.Habilitado ColorHabilitado, SI.ID ServicioItemID, SI.Cantidad ServicioItemCantidad, SI.Servicio ServicioID, S.Nombre ServicioNombre, S.Descripcion ServicioDescripcion, S.Costo ServicioCosto, S.Habilitado ServicioHabilitado, SI.Monto ServicioItemMonto, SI.Descuento ServicioItemDescuento, D2.Nombre SIDescNombre, D2.VigenciaInicio SIDescVigenciaInicio, D2.VigenciaFin SIDescVigenciaFin, D2.MontoMinimo SIDescMontoMinimo, D2.CantMinima SIDescCantMinima, D2.Porcentaje SIDescPorcentaje, D2.Unidades SIDescUnidades, D2.SoloNota SIDescSoloNota, SI.Encargado EncargadoID, E.Nombre EncargadoNombre, E.Username EncargadoUsername FROM Nota N JOIN Cliente C ON(C.ID = N.Cliente) LEFT JOIN Descuento D ON(D.ID = N.Descuento) JOIN PrendaItem PI ON(PI.Nota = N.ID) JOIN Prenda P ON(P.ID = PI.Prenda) LEFT JOIN TipoPrenda T ON(T.ID = PI.TipoPrenda) JOIN Color Co ON(Co.ID = PI.Color) JOIN ServicioItem SI ON(SI.PrendaItem = PI.ID) JOIN Servicio S ON(S.ID = SI.Servicio) LEFT JOIN Descuento D2 ON(D2.ID = SI.Descuento) LEFT JOIN Usuario E ON(E.ID = SI.Encargado)";
        private static readonly string LIST_SELECT_SQL = "SELECT N.ID, C.Nombre Cliente, CASE WHEN Estatus = 0 THEN 'Cancelado' WHEN Estatus = 1 THEN 'Pendiente' WHEN Estatus = 2 THEN 'Terminado' WHEN Estatus = 3 THEN 'Entregado' WHEN Estatus = 4 THEN 'Caducado' ELSE '' END Estatus, Recibido, Entregado FechaEntrega, D.Nombre Descuento FROM Nota N JOIN Cliente C ON (C.ID = N.Cliente) LEFT JOIN Descuento D ON (D.ID = N.Descuento)";
        private static readonly string PRENDA_SELECT_SQL = "SELECT * FROM PrendaItem";
        private static readonly string SERVICIO_SELECT_SQL = "SELECT * FROM ServicioItem";
        private static readonly string PAGO_SELECT_SQL = "SELECT * FROM Pago";
        private static readonly string SELECT_CLIENTE_STATS_SQL = "SELECT * FROM ClienteStatsView";

        private static readonly string INSERT_SQL = "INSERT INTO Nota (Estatus,Cliente,Recibido,Entregado,Observaciones,Descuento) VALUES (@Estatus,@Cliente,CURRENT_TIMESTAMP,@Entregado,@Observaciones,@Descuento); SELECT last_insert_id();";
        private static readonly string PRENDA_INSERT_SQL = "INSERT INTO PrendaItem(Nota,Cantidad,Prenda,TipoPrenda,Color) VALUES";
        private static readonly string SERVICIO_INSERT_SQL = "INSERT INTO ServicioItem(PrendaItem,Cantidad,Servicio,Monto,Descuento,Encargado) VALUES";
        private static readonly string PAGO_INSERT_SQL = "INSERT INTO Pago(Nota,Metodo,Monto,Fecha) VALUES";

        private static readonly string UPDATE_SQL = "UPDATE Nota SET Estatus = @Estatus, Cliente = @Cliente, Entregado = @Entregado, Observaciones = @Observaciones, Descuento = @Descuento WHERE ID = @ID";
        private static readonly string PRENDA_DELETE_SQL = "DELETE FROM PrendaItem";
        private static readonly string SERVICIO_DELETE_SQL = "DELETE FROM ServicioItem";
        private static readonly string PAGO_DELETE_SQL = "DELETE FROM Pago";
        private static readonly string DELETE_SQL = "sp_DeleteNota";

        private static NotaDto Map(DataTable dt)
        {
            NotaDto dto = null;
            if(dt.Rows.Count > 0)
            {
                dto = new NotaDto
                {
                    ID = Convert.ToInt64(dt.Rows[0]["NotaID"]),
                    Estatus = (Estatus)Convert.ToInt32(dt.Rows[0]["Estatus"]),
                    Cliente = new ClienteDto
                    {
                        ID = Convert.ToInt32(dt.Rows[0]["ClienteID"]),
                        Nombre = dt.Rows[0]["ClienteNombre"].ToString(),
                        Domicilio = dt.Rows[0]["Domicilio"].ToString(),
                        Colonia = dt.Rows[0]["Colonia"].ToString(),
                        CP = dt.Rows[0]["CP"].ToString(),
                        Telefono = dt.Rows[0]["Telefono"].ToString(),
                        Email = dt.Rows[0]["Email"].ToString(),
                        Habilitado = Convert.ToBoolean(dt.Rows[0]["ClienteHabilitado"])
                    },
                    Recibido = Convert.ToDateTime(dt.Rows[0]["Recibido"]),
                    Entregado = Convert.ToDateTime(dt.Rows[0]["Entregado"]),
                    Observaciones = dt.Rows[0]["Observaciones"].ToString(),
                    Descuento = dt.Rows[0]["DescuentoID"].GetType() == typeof(DBNull)? 
                    null : 
                    new DescuentoDto
                    {
                        ID = Convert.ToInt32(dt.Rows[0]["DescuentoID"]),
                        Nombre = dt.Rows[0]["DescuentoNombre"].ToString(),
                        VigenciaInicio = Convert.ToDateTime(dt.Rows[0]["VigenciaInicio"]),
                        VigenciaFin = Convert.ToDateTime(dt.Rows[0]["VigenciaFin"]),
                        MontoMinimo = Convert.ToDecimal(dt.Rows[0]["MontoMinimo"]),
                        CantMinima = Convert.ToDecimal(dt.Rows[0]["CantMinima"]),
                        Porcentaje = Convert.ToDecimal(dt.Rows[0]["Porcentaje"]),
                        Unidades = Convert.ToDecimal(dt.Rows[0]["Unidades"]),
                        SoloNota = Convert.ToBoolean(dt.Rows[0]["SoloNota"])
                    }
                };
                PrendaItemDto prenda = new PrendaItemDto();
                foreach (DataRow dr in dt.Rows)
                {
                    prenda = new PrendaItemDto(Convert.ToInt64(dr["PrendaItemID"]));
                    if (!dto.Prendas.Contains(prenda))
                    {
                        prenda = new PrendaItemDto
                        {
                            ID = prenda.ID,
                            Nota = dto,
                            Cantidad = Convert.ToInt32(dr["PrendaItemCantidad"]),
                            Prenda = new CatalogoDto
                            {
                                ID = Convert.ToInt16(dr["PrendaID"]),
                                Nombre = dr["PrendaNombre"].ToString(),
                                Habilitado = Convert.ToBoolean(dr["PrendaHabilitado"])
                            },
                            TipoPrenda = dr["TipoID"].GetType() == typeof(DBNull) ? null : new CatalogoDto
                            {
                                ID = Convert.ToInt16(dr["TipoID"]),
                                Nombre = dr["TipoNombre"].ToString(),
                                Habilitado = Convert.ToBoolean(dr["TipoHabilitado"])
                            },
                            Color = new CatalogoDto
                            {
                                ID = Convert.ToInt16(dr["ColorID"]),
                                Nombre = dr["ColorNombre"].ToString(),
                                Habilitado = Convert.ToBoolean(dr["ColorHabilitado"])
                            }
                        };
                        dto.Prendas.Add(prenda);
                    }
                    else
                    { prenda = dto.Prendas[dto.Prendas.IndexOf(prenda)]; }
                    prenda.Servicios.Add(new ServicioItemDto
                    {
                        ID = Convert.ToInt64(dr["ServicioItemID"]),
                        PrendaItem = prenda,
                        Cantidad = Convert.ToInt32(dr["ServicioItemCantidad"]),
                        Servicio = new ServicioDto
                        {
                            ID = Convert.ToInt32(dr["ServicioID"]),
                            Nombre = dr["ServicioNombre"].ToString(),
                            Descripcion = dr["ServicioDescripcion"].ToString(),
                            Costo =  Convert.ToDecimal(dr["ServicioCosto"]),
                            Habilitado = Convert.ToBoolean(dr["ServicioHabilitado"])
                        },
                        Monto = Convert.ToDecimal(dr["ServicioItemMonto"]),
                        Descuento = dt.Rows[0]["ServicioItemDescuento"].GetType() == typeof(DBNull) ? null : new DescuentoDto
                        {
                            ID = Convert.ToInt32(dt.Rows[0]["ServicioItemDescuento"]),
                            Nombre = dt.Rows[0]["SIDescNombre"].ToString(),
                            VigenciaInicio = Convert.ToDateTime(dt.Rows[0]["SIDescVigenciaInicio"]),
                            VigenciaFin = Convert.ToDateTime(dt.Rows[0]["SIDescVigenciaFin"]),
                            MontoMinimo = Convert.ToDecimal(dt.Rows[0]["SIDescMontoMinimo"]),
                            CantMinima = Convert.ToDecimal(dt.Rows[0]["SIDescCantMinima"]),
                            Porcentaje = Convert.ToDecimal(dt.Rows[0]["SIDescPorcentaje"]),
                            Unidades = Convert.ToDecimal(dt.Rows[0]["SIDescUnidades"]),
                            SoloNota = Convert.ToBoolean(dt.Rows[0]["SIDescSoloNota"])
                        },
                        Encargado = dr["EncargadoID"].GetType() == typeof(DBNull) ? null : new UsuarioDto
                        {
                            ID = Convert.ToInt64(dr["EncargadoID"]),
                            Nombre = dr["EncargadoNombre"].ToString(),
                            Username = dr["EncargadoUsername"].ToString()
                        }
                    });
                }
            }
            return dto;
        }

        public NotaDto EliminarNota(NotaDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", dto.ID);
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt) : null;
        }

        public NotaDto GetNota(long id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_SQL + " WHERE N.ID = " + id);
            NotaDto notaDto = dt.Rows.Count > 0 ? Map(dt) : null;
            foreach(DataRow dr in MySqlDbContext.Query(PAGO_SELECT_SQL + " WHERE Nota = " + id).Rows)
            {
                notaDto.Pagos.Add(new PagoDto
                {
                    ID = Convert.ToInt64(dr["ID"]),
                    Nota = notaDto,
                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                    Monto = Convert.ToDecimal(dr["Monto"]),
                    Metodo = (MetodoPago)Enum.Parse( typeof(MetodoPago), dr["Metodo"].ToString())
                });
            }
            foreach (DataRow dr in MySqlDbContext.Query(SELECT_CLIENTE_STATS_SQL + " WHERE ID = " + notaDto.Cliente.ID).Rows)
            {
                notaDto.Cliente.Estadisticas.MontoTotal += Convert.ToDecimal(dr["Monto"].GetType() != typeof(DBNull) ? dr["Monto"] : 0);
                notaDto.Cliente.Estadisticas.NotasTotal++;
                notaDto.Cliente.Estadisticas.PrendasTotal += Convert.ToInt32(dr["Prendas"]);
                notaDto.Cliente.Estadisticas.ServiciosTotal += Convert.ToInt32(dr["Servicios"]);
                if (Convert.ToDateTime(dr["Fecha"]) >= notaDto.Cliente.Estadisticas.Periodo)
                {
                    notaDto.Cliente.Estadisticas.MontoPeriodo += Convert.ToDecimal(dr["Monto"].GetType() != typeof(DBNull) ? dr["Monto"] : 0);
                    notaDto.Cliente.Estadisticas.NotasPeriodo++;
                    notaDto.Cliente.Estadisticas.PrendasPeriodo += Convert.ToInt32(dr["Prendas"]);
                    notaDto.Cliente.Estadisticas.ServiciosPeriodo += Convert.ToInt32(dr["Servicios"]);
                }
            }
            return notaDto;
        }

        public DataTable GetNotas()
        {
            return MySqlDbContext.Query(LIST_SELECT_SQL + " ORDER BY ID DESC");
        }

        public NotaDto GuardarNota(NotaDto dto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Estatus", (short)dto.Estatus);
            param.Add("@Cliente", dto.Cliente.ID);
            param.Add("@Entregado", dto.Entregado);
            param.Add("@Observaciones", dto.Observaciones);
            param.Add("@Descuento", dto.Descuento != null? (object)dto.Descuento.ID : null);

            if (dto.ID > 0)
            {
                param.Add("@ID", dto.ID);
                MySqlDbContext.Update(UPDATE_SQL, param);
            }
            else
            {
                DataTable dt = MySqlDbContext.Query(INSERT_SQL, param);
                dto.ID = dt.Rows.Count > 0 ? Convert.ToInt64(dt.Rows[0][0]) : -1;
            }

            GuardarPrendas(dto.Prendas);
            GuardarPagos(dto.Pagos);

            return dto;
        }

        private void GuardarPrendas(List<PrendaItemDto> Prendas)
        {
            string id_list = "(";
            string insert_values = "";
            string update_query = "";
            foreach (PrendaItemDto p in Prendas)
            {
                if (p.ID < 0)
                    insert_values += "(" + p.Nota.ID + "," + p.Cantidad + "," + p.Prenda.ID + "," + (p.TipoPrenda != null ? p.TipoPrenda.ID.ToString() : "NULL") + "," + p.Color.ID + "),";
                else
                    update_query += "UPDATE PrendaItem SET Cantidad = " + p.Cantidad + ", Prenda = " + p.Prenda.ID + ", TipoPrenda = " + (p.TipoPrenda != null ? p.TipoPrenda.ID.ToString() : "NULL") + ", Color = " + p.Color.ID + " WHERE ID = " + p.ID + "; ";
                id_list += p.ID >= 0? (p.ID + ",") : "";
            }
            insert_values = insert_values.Trim(new char[] { ',' }) + "; ";
            id_list = id_list.Trim(new char[] { ',' }) + ")";
            try
            {
                if (id_list.Length > "()".Length)
                {
                    string delete_ids = " WHERE Nota = " + Prendas[0].Nota.ID + " AND ID NOT IN" + id_list;
                    MySqlDbContext.Query(SERVICIO_DELETE_SQL  + " WHERE PrendaItem IN (SELECT ID FROM PrendaItem" + delete_ids + "); " 
                        + PRENDA_DELETE_SQL + delete_ids + ";");
                }
                if(insert_values.Length > 2)
                { 
                    DataTable dt = MySqlDbContext.Query(PRENDA_INSERT_SQL + insert_values + PRENDA_SELECT_SQL + " WHERE Nota = " + Prendas[0].Nota.ID + (id_list.Length > "()".Length? " AND ID NOT IN" + id_list : ""));
                    int i = 0;
                    foreach(PrendaItemDto p in Prendas)
                    { p.ID = p.ID < 0 ? Convert.ToInt64(dt.Rows[i++]["ID"]) : p.ID; }
                }
                if (!String.IsNullOrEmpty(update_query))
                { MySqlDbContext.Update(update_query); }
                foreach (PrendaItemDto p in Prendas)
                { GuardarServicios(p.Servicios); }
            } catch (MySqlException e)
            {
                //Registrar en log
                throw e;
            }
        }

        private void GuardarServicios(List<ServicioItemDto> Servicios)
        {
            string id_list = "(";
            string insert_values = "";
            string update_query = "";
            foreach(ServicioItemDto s in Servicios)
            {
                if (s.ID < 0)
                    insert_values += "(" + s.PrendaItem.ID + "," + s.Cantidad + "," + s.Servicio.ID + "," + s.Monto + "," + (s.Descuento != null ? s.Descuento.ID.ToString() : "NULL") + "," + (s.Encargado != null ? s.Encargado.ID.ToString() : "NULL") + "),";
                else
                    update_query += "UPDATE ServicioItem SET Cantidad = " + s.Cantidad + ", Servicio = " + s.Servicio.ID + ", Monto = " + s.Monto + ", Descuento = " + (s.Descuento != null ? s.Descuento.ID.ToString() : "NULL") + ", Encargado = " + (s.Encargado != null ? s.Encargado.ID.ToString() : "NULL") + " WHERE ID = " + s.ID + "; ";
                id_list += s.ID >= 0 ? (s.ID + ",") : "";
            }
            insert_values = insert_values.Trim(new char[] { ',' }) + "; ";
            id_list = id_list.Trim(new char[] { ',' }) + ")";
            try
            {
                if(id_list.Length > "()".Length)
                { MySqlDbContext.Query(SERVICIO_DELETE_SQL + " WHERE PrendaItem = " + Servicios[0].PrendaItem.ID + " AND ID NOT IN" + id_list); }
                if (insert_values.Length > 2)
                {
                    DataTable dt = MySqlDbContext.Query(SERVICIO_INSERT_SQL + insert_values + SERVICIO_SELECT_SQL + " WHERE PrendaItem = " + Servicios[0].PrendaItem.ID + (id_list.Length > "()".Length ? " AND ID NOT IN" + id_list : ""));
                    int i = 0;
                    foreach(ServicioItemDto s in Servicios.Where((servicio) => servicio.ID < 0 ))
                    { s.ID = Convert.ToInt64(dt.Rows[i++]["ID"]); }
                }
                if (!String.IsNullOrEmpty(update_query))
                { MySqlDbContext.Update(update_query); }
            }
            catch (MySqlException e)
            {
                //Registrar en log
                throw e;
            }
        }

        private void GuardarPagos(List<PagoDto> Pagos)
        {
            string id_list = "(";
            string insert_values = "";
            string update_query = "";
            foreach(PagoDto p in Pagos)
            {
                if (p.ID < 0)
                    insert_values += "(" + p.Nota.ID + ",'" + p.Metodo + "'," + p.Monto + ",CURRENT_TIMESTAMP),";
                else
                    update_query += "UPDATE Pago SET Metodo = '" + p.Metodo + "', Monto = " + p.Monto + " WHERE ID = " + p.ID + "; ";
                id_list += p.ID >= 0 ? (p.ID + ",") : "";
            }
            insert_values = insert_values.Trim(new char[] { ',' }) + "; ";
            id_list = id_list.Trim(new char[] { ',' }) + ")";
            try
            {
                if(id_list.Length > 2)
                { MySqlDbContext.Query(PAGO_DELETE_SQL + " WHERE Nota = " + Pagos[0].Nota.ID + " AND ID NOT IN" + id_list); }
                if (insert_values.Length > 2)
                {
                    DataTable dt = MySqlDbContext.Query(PAGO_INSERT_SQL + insert_values + PAGO_SELECT_SQL + " WHERE Nota = " + Pagos[0].Nota.ID + (id_list.Length > 2? " AND ID NOT IN" + id_list : ""));
                    int i = 0;
                    foreach(PagoDto p in Pagos.Where((pago) => pago.ID < 0))
                    { p.ID = Convert.ToInt64(dt.Rows[i++]["ID"]); }
                }
                if (!String.IsNullOrEmpty(update_query))
                { MySqlDbContext.Update(update_query); }
            }
            catch (MySqlException e)
            {
                //Registrar en log
                throw e;
            }
        }
    }
}
