using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DAO.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;
using VentaPrenda.Model;

namespace VentaPrenda.DAO.Concrete
{
    class UsuarioDaoMySQL : IUsuarioDao
    {
        private static readonly string SELECT_LIST_SQL = "SELECT U.ID, U.Username, U.Nombre, U.Bloqueado, U.IntentosFallidos, U.UltimoIngreso, BIT_OR(P.Permisos) Permisos FROM Usuario U JOIN Perfil_Usuario PU ON(PU.Usuario = U.ID) JOIN Perfil P ON(P.ID = PU.Perfil)";
        private static readonly string SELECT_PERFILES_SQL = "SELECT U.*, P.ID AS PerfilID, P.Nombre AS Perfil, P.Permisos, PU.Perfil IS NOT NULL AND PU.Usuario IS NOT NULL Habilitado FROM Usuario U, Perfil P LEFT JOIN Perfil_Usuario PU ON(PU.Perfil = P.ID)";
        private static readonly string INSERT_SQL = "INSERT INTO Usuario(Username,Nombre,Password) VALUES(@Username,@Nombre,@Password)";
        private static readonly string UPDATE_SQL = "UPDATE Usuario SET Username = @Username, Nombre = @Nombre, Password = @Password WHERE ID = @ID";
        private static readonly string UPDATE_PERFILES_SQL = "sp_UpdatePerfiles";
        private static readonly string DELETE_SQL = "sp_DeleteUsuario";


        private static UsuarioDto Map(DataTable dt)
        {
            UsuarioDto u = null;
            if(dt != null && dt.Rows.Count > 0)
            {

                u = new UsuarioDto
                {
                    ID = Convert.ToInt64(dt.Rows[0]["ID"]),
                    Nombre = dt.Rows[0]["Nombre"].ToString(),
                    Username = dt.Rows[0]["Username"].ToString(),
                    Contraseña = dt.Rows[0]["Password"].ToString(),
                    Bloqueado = Convert.ToBoolean(dt.Rows[0]["Bloqueado"]),
                    IntentosFallidos = Convert.ToInt32(dt.Rows[0]["IntentosFallidos"]),
                    UltimoIngreso = Convert.ToDateTime(dt.Rows[0]["UltimoIngreso"]),
                    Logged = true,
                    Permisos = new Permisos(Convert.ToInt32(dt.Rows[0]["Permisos"]))
                };
            }
            return u;
            
        }
        public UsuarioDto EliminarUsuario(UsuarioDto u)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("p_Usuario", u.ID.ToString());
            DataTable dt = MySqlDbContext.Call(DELETE_SQL, param);
            return dt.Rows.Count > 0 ? Map(dt) : null;
        }

        public UsuarioDto GetUsuario(LoginDto loginDto)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("p_Username", loginDto.Usuario);
            param.Add("p_Password", loginDto.Contraseña);
            return Map(MySqlDbContext.Call("sp_Login", param));            
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
            return u;
        }

        public DataTable GetUsuarios()
        {
            return MySqlDbContext.Query(SELECT_LIST_SQL);
        }

        public UsuarioDto GuardarUsuario(UsuarioDto u)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
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
                MySqlDbContext.Update(sql, param);
            }
            else
            {
                param.Add("@Password", u.Contraseña);
                DataTable dt = MySqlDbContext.Query(INSERT_SQL, param);
                u.ID = (short)(dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : -1);
            }

            param = new Dictionary<string, string>();
            param.Add("@p_Usuario", u.ID.ToString());
            string perfiles = "";
            foreach (KeyValuePair<PerfilDto, bool> kvp in u.Perfiles)
            {
                perfiles += kvp.Value ? kvp.Key.ID + "," : "";
            }
            perfiles = perfiles.Substring(0, perfiles.Length - 1);
            param.Add("@p_Perfiles", perfiles);
            MySqlDbContext.Call(UPDATE_PERFILES_SQL, param);

            return u;
        }
    }
}
