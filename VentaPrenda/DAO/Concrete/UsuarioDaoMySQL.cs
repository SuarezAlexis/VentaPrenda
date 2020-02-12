using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;
using VentaPrenda.Model;

namespace VentaPrenda.DAO.Concrete
{
    class UsuarioDaoMySQL : IUsuarioDao
    {
        private static readonly string SELECT_LIST_SQL = "SELECT U.ID, U.Username, U.Nombre, U.Bloqueado, U.IntentosFallidos, U.UltimoIngreso, BIT_OR(P.Permisos) Permisos FROM Usuario U LEFT JOIN Perfil_Usuario PU ON(PU.Usuario = U.ID) LEFT JOIN Perfil P ON(P.ID = PU.Perfil) GROUP BY ID";
        private static readonly string SELECT_PERFILES_SQL = "SELECT U.*, P.ID AS PerfilID, P.Nombre AS Perfil, P.Permisos, EXISTS(SELECT * FROM Perfil_Usuario WHERE Perfil = P.ID AND Usuario = U.ID) Habilitado FROM Usuario U, Perfil P";
        private static readonly string SELECT_COLORES_SQL = "SELECT * FROM ColoresGUI";
        private static readonly string INSERT_SQL = "INSERT INTO Usuario(Username,Nombre,Password) VALUES(@Username,@Nombre,@Password); SELECT LAST_INSERT_ID();";
        private static readonly string INSERT_COLORES_SQL = "INSERT INTO ColoresGUI(Usuario) VALUES(@ID)";
        private static readonly string UPDATE_SQL = "UPDATE Usuario SET Username = @Username, Nombre = @Nombre, Password = @Password, Bloqueado = @Bloqueado WHERE ID = @ID";
        private static readonly string UPDATE_PERFILES_SQL = "sp_UpdatePerfiles";
        private static readonly string UPDATE_COLORES_SQL = "UPDATE ColoresGUI SET FondoVentana = @FondoVentana, FondoBoton = @FondoBoton, FondoBotonActivo = @FondoBotonActivo, FondoLista = @FondoLista, Cancelado = @Cancelado, Pendiente = @Pendiente, Terminado = @Terminado, Entregado = @Entregado, Caducado = @Caducado WHERE Usuario = @Usuario";
        private static readonly string DELETE_SQL = "sp_DeleteUsuario";
        

        /// <summary>
        /// Obtiene un objeto UsuarioDto a partir del primer registro de una DataTable. 
        /// Devuelve nulo si la tabla no contiene filas.
        /// </summary>
        /// <param name="dt">Debe contener las columnas respectivas o se lanzará una exepción en tiempo de ejecución.</param>
        /// <returns></returns>
        private static UsuarioDto Map(DataTable dt)
        {
            UsuarioDto u = null;
            if(dt != null && dt.Rows.Count > 0)
            {
                u = new UsuarioDto
                {
                    ID = dt.Rows[0].Field<long>("ID"),
                    Nombre = dt.Rows[0].Field<string>("Nombre"),
                    Username = dt.Rows[0].Field<string>("Username"),
                    Contraseña = dt.Rows[0].Field<string>("Password"),
                    Bloqueado = Convert.ToBoolean(dt.Rows[0]["Bloqueado"]),
                    IntentosFallidos = Convert.ToInt32(dt.Rows[0]["IntentosFallidos"]),
                    UltimoIngreso = dt.Rows[0]["UltimoIngreso"].GetType() != typeof(DBNull)? Convert.ToDateTime(dt.Rows[0]["UltimoIngreso"]): new DateTime(),
                    Permisos = new Permisos(Convert.ToInt32(dt.Rows[0]["Permisos"]))
                };
                u.Logged = dt.Columns.Contains("Logged") && Convert.ToBoolean(dt.Rows[0]["Logged"]);

            }
            return u;
            
        }
        public UsuarioDto EliminarUsuario(UsuarioDto u)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_ID", u.ID.ToString());
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            /*
            Dictionary<PerfilDto, bool> perfiles = new Dictionary<PerfilDto, bool>();
            foreach(KeyValuePair<PerfilDto,bool> kvp in u.Perfiles)
            { perfiles.Add(kvp.Key, false); }
            u = dt.Rows.Count > 0 ? Map(dt) : new UsuarioDto();
            u.Perfiles = perfiles;
            u = dt.Rows.Count > 0 ? Map(dt) : new UsuarioDto();
            u.ID = -1;
            */
            return dt.Rows.Count > 0 ? Map(dt) : new UsuarioDto();
        }

        /// <summary>
        /// Ejecuta procedimiento de inicio de sesión en base de datos y obtiene registro del usuario solicitado.
        /// Devuelve nulo si el usuario no se encontró.
        /// La bandera Logged del objeto UsuarioDto indica si la autenticación fue correcta.
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        public UsuarioDto GetUsuario(LoginDto loginDto)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("p_Username", loginDto.Usuario);
            param.Add("p_Password", loginDto.Contraseña);
            UsuarioDto u = Map(MySqlDbContext.Call("sp_Login", param));
            u.Colores = GetColores(u.ID);
            return u;            
        }

        public UsuarioDto GetUsuario(long id)
        {
            DataTable dt = MySqlDbContext.Query(SELECT_PERFILES_SQL + " WHERE U.ID = " + id);
            UsuarioDto u = Map(dt);
            u.Permisos = new Permisos();
            foreach (DataRow dr in dt.Rows)
            {
                u.Perfiles.Add(new PerfilDto
                {
                    ID = Convert.ToInt16(dr["PerfilID"]),
                    Nombre = dr["Perfil"].ToString()
                }, Convert.ToBoolean(dr["Habilitado"]));
            }
            u.Colores = GetColores(id);
            return u;
        }

        public DataTable GetUsuarios()
        {
            return MySqlDbContext.Query(SELECT_LIST_SQL);
        }

        public UsuarioDto GuardarUsuario(UsuarioDto u)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Nombre", u.Nombre);
            param.Add("@Username", u.Username);

            if (u.ID > 0)
            {
                string sql = UPDATE_SQL;
                if (u.Contraseña.Length > 0)
                    param.Add("@Password", u.Contraseña);
                else
                    sql = sql.Replace(", Password = @Password","");
                param.Add("@ID", u.ID.ToString());
                param.Add("@Bloqueado", u.Bloqueado);
                MySqlDbContext.Update(sql, param);
            }
            else
            {
                param.Add("@Password", u.Contraseña);
                try
                {
                    DataTable dt = MySqlDbContext.Query(INSERT_SQL, param);
                    u.ID = (short)(dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : -1);
                    param = new Dictionary<string, object>();
                    GuardarColores(u.ID);
                } catch(MySqlException e)
                {
                    if(e.Number == 1062)
                    { throw new DuplicateKeyException(e); }
                }
            }

            param = new Dictionary<string, object>();
            param.Add("@p_Usuario", u.ID.ToString());
            string perfiles = "";
            foreach (KeyValuePair<PerfilDto, bool> kvp in u.Perfiles)
            {
                perfiles += kvp.Value ? kvp.Key.ID + "," : "";
            }
            perfiles = perfiles.Substring(0, Math.Max(0,perfiles.Length - 1));
            param.Add("@p_Perfiles", perfiles);
            MySqlDbContext.Call(UPDATE_PERFILES_SQL, param);

            return u;
        }

        private ColoresGUIDto GetColores(long id)
        {
            ColoresGUIDto c = new ColoresGUIDto();
            foreach (DataRow dr in MySqlDbContext.Query(SELECT_COLORES_SQL + " WHERE Usuario = '" + id + "'").Rows)
            {
                c.FondoVentana = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["FondoVentana"]));
                c.FondoBoton = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["FondoBoton"]));
                c.FondoBotonActivo = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["FondoBotonActivo"]));
                c.FondoLista = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["FondoLista"]));
                c.Cancelado = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["Cancelado"]));
                c.Pendiente = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["Pendiente"]));
                c.Terminado = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["Terminado"]));
                c.Entregado = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["Entregado"]));
                c.Caducado = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["Caducado"]));
            }
            return c;
        }

        public ColoresGUIDto GuardarColores(ColoresGUIDto c, long id)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@FondoVentana", c.FondoVentana.ToArgb());
            param.Add("@FondoBoton", c.FondoBoton.ToArgb());
            param.Add("@FondoBotonActivo", c.FondoBotonActivo.ToArgb());
            param.Add("@FondoLista", c.FondoLista.ToArgb());
            param.Add("@Cancelado", c.Cancelado.ToArgb());
            param.Add("@Pendiente", c.Pendiente.ToArgb());
            param.Add("@Terminado", c.Terminado.ToArgb());
            param.Add("@Entregado", c.Entregado.ToArgb());
            param.Add("@Caducado", c.Cancelado.ToArgb());
            param.Add("@Usuario", id);
            MySqlDbContext.Query(UPDATE_COLORES_SQL, param);
            return c;
        }

        private ColoresGUIDto GuardarColores(long id)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@ID", id);
            MySqlDbContext.Query(INSERT_COLORES_SQL, param);
            return new ColoresGUIDto();
        }

    }
}
