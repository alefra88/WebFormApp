using DaL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;

namespace DAL
{
    public class UsuariosDAL
        
    {
        public Usuarios Login(string correo, string contrasena)
        {
            Usuarios usuario = null;

            using (SqlConnection conn = Conexion.ObtenerConexion()) 
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuarios
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        Nombre = reader["Nombre"].ToString(),
                        ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                        CorreoElectronico = reader["CorreoElectronico"].ToString(),
                        ContrasenaHash = (byte[])reader["ContrasenaHash"],
                        Salt = (byte[])reader["Salt"],
                        FechaRegistro = (DateTime)reader["FechaRegistro"]
                    };
                }
            }

            return usuario;
        }

        public void CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_CambiarContrasena", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@NuevaContrasena", nuevaContrasena);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RegistrarUsuario(Usuarios usuario, string contrasena)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(new Usuarios
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        Nombre = reader["Nombre"].ToString(),
                        ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                        CorreoElectronico = reader["CorreoElectronico"].ToString(),
                        FechaRegistro = (DateTime)reader["FechaRegistro"]
                    });
                }
            }

            return usuarios;
        }

        public Usuarios ObtenerUsuarioPorId(int idUsuario)
        {
            Usuarios usuario = null;

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuarios
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        Nombre = reader["Nombre"].ToString(),
                        ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        CorreoElectronico = reader["CorreoElectronico"].ToString(),
                        FechaRegistro = (DateTime)reader["FechaRegistro"]
                    };
                }
            }

            return usuario;
        }
    }
}
