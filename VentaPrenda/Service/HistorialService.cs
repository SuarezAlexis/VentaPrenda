using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Controller;
using VentaPrenda.DAO;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.Service
{
    public class HistorialService
    {
        /// <summary>
        /// Inserta un registro en el historial
        /// </summary>
        /// <param name="u">Usuario activo</param>
        /// <param name="op">Operación de base de datos { 'I', 'U', 'D' }</param>
        /// <param name="dto">Objeto alterado</param>
        public static void GuardarHistoria(Usuario u, char op, Funcion f, Object dto)
        {
            string concepto = Concepto(op,f);
            List<DatoHistorialDto> cambios = new List<DatoHistorialDto>();
            Type t = dto.GetType();
            foreach(PropertyInfo p in t.GetProperties())
            {
                if (!p.Name.Equals("Confirmacion") 
                    && !p.Name.Equals("Logged")
                    && !p.Name.Equals("Clientes")
                    && !p.Name.Equals("Descuentos")
                    && !p.Name.Equals("Estadisticas"))
                {
                    cambios.Add(new DatoHistorialDto
                    {
                        Operacion = op,
                        Tabla = Concepto('X', f),
                        Columna = p.Name,
                        Valor = ValueToString(p.GetValue(dto))
                    });
                    if( p.Name.Equals("Prendas") && dto is NotaDto)
                    {
                        foreach(PrendaItemDto prenda in (List<PrendaItemDto>)p.GetValue(dto))
                        {
                            cambios.Add(new DatoHistorialDto
                            {
                                Operacion = op,
                                Tabla = "PrendaItem " + prenda.ID,
                                Columna = "Servicios",
                                Valor = ValueToString(prenda.Servicios)
                            });
                            foreach (ServicioItemDto servicio in prenda.Servicios)
                            {
                                cambios.Add(new DatoHistorialDto
                                {
                                    Operacion = op,
                                    Tabla = "ServicioItem " + servicio.ID,
                                    Columna = "Descuento",
                                    Valor = ValueToString(servicio.Descuento)
                                });
                                cambios.Add(new DatoHistorialDto
                                {
                                    Operacion = op,
                                    Tabla = "ServicioItem " + servicio.ID,
                                    Columna = "Monto",
                                    Valor = ValueToString(servicio.Monto)
                                });
                                cambios.Add(new DatoHistorialDto
                                {
                                    Operacion = op,
                                    Tabla = "ServicioItem " + servicio.ID,
                                    Columna = "Elaboro",
                                    Valor = ValueToString(servicio.Encargado)
                                });
                            }
                        }
                    }
                }
            }
            HistorialDto h = new HistorialDto
            {
                Usuario = new UsuarioDto { ID = u.ID },
                Fecha = DateTime.Now,
                Concepto = concepto,
                Cambios = cambios
            };
            DaoManager.HistorialDao.Guardar(h);
        }

        private static String Concepto(char op, Funcion f)
        {
            string concepto = "";
            switch(op)
            {
                case 'I':
                    concepto += "Insertar "; break;
                case 'U':
                    concepto += "Actualizar "; break;
                case 'D':
                    concepto += "Eliminar "; break;
            }
            switch(f)
            {
                case Funcion.PERFILES:
                    concepto += "Perfil"; break;
                case Funcion.USUARIOS:
                    concepto += "Usuario"; break;
                case Funcion.COLORES:
                    concepto += "Color"; break;
                case Funcion.PRENDAS:
                    concepto += "Prenda"; break;
                case Funcion.TIPOS_PRENDA:
                    concepto += "TipoPrenda"; break;
                case Funcion.SERVICIOS:
                    concepto += "Servicio"; break;
                case Funcion.DESCUENTOS:
                    concepto += "Descuento"; break;
                case Funcion.NOTA:
                    concepto += "Nota"; break;
                case Funcion.CLIENTES:
                    concepto += "Cliente"; break;
                case Funcion.BALANCE:
                    concepto += "Movimiento"; break;
                case Funcion.TICKET:
                    concepto += "Ticket"; break;
                case Funcion.PERSONALIZAR:
                    concepto += "Colores GUI"; break;
            }
            return concepto;
        }

        public static String ValueToString(Object value)
        {
            string s = "NULL";
            if( value != null)
            {
                if(value is IList)
                {
                    s = "[ ";
                    foreach (Object o in (IList)value)
                    { s += o.ToString() + ", "; }
                    s = s.Trim(new char[] { ' ',',' });
                    s += " ]";
                } else
                {
                    if(value is IDictionary)
                    {
                        s = "{ ";
                        foreach(DictionaryEntry d in (IDictionary)value)
                        { s += d.Key.ToString() + ": " + d.Value.ToString() + ", "; }
                        s = s.Trim(new char[] { ' ',',' });
                        s += " }";
                    }
                    else
                    { s = value.ToString(); }
                }
            }
            return s;
        }
    }
}
