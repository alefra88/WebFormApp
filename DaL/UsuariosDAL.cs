using System.Security.Cryptography;
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
                    byte[] salt = (byte[])reader["Salt"];
                    byte[] contrasenaHashAlmacenada = (byte[])reader["ContrasenaHash"];

                    // Comparar el hash de la contraseña ingresada + salt con el hash almacenado
                    if (GenerarHash(contrasena, salt).SequenceEqual(contrasenaHashAlmacenada))
                    {
                        usuario = new Usuarios
                        {
                            IdUsuario = (int)reader["IdUsuario"],
                            Nombre = reader["Nombre"].ToString(),
                            ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                            ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                            CorreoElectronico = reader["CorreoElectronico"].ToString(),
                            FechaRegistro = (DateTime)reader["FechaRegistro"]
                        };
                    }
                    else
                    {
                        throw new Exception("Contraseña incorrecta.");
                    }
                }
                else
                {
                    throw new Exception("Usuario no encontrado.");
                }
            }

            return usuario;
        }



        public static int? ValidarUsuario(string correo, string contrasena)
        {
            int? idUsuario = null;
            string phrase = "Master";
            try
            {
                using (SqlConnection connection = Conexion.ObtenerConexion()) 
                {
                    SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@FraseSecreta", phrase);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        idUsuario = reader.GetInt32(0);  // Retorna el IdUsuario
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el usuario: " + ex.Message);
            }

            return idUsuario;
        }



        private byte[] GenerarHash(string contrasena, byte[] salt)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] contrasenaBytes = Encoding.UTF8.GetBytes(contrasena);
                byte[] combinedBytes = new byte[contrasenaBytes.Length + salt.Length];

                Buffer.BlockCopy(salt, 0, combinedBytes, 0, salt.Length);
                Buffer.BlockCopy(contrasenaBytes, 0, combinedBytes, salt.Length, contrasenaBytes.Length);

                return sha512.ComputeHash(combinedBytes);
            }
        }





        public void RegistrarUsuario(string nombre,string apellidoPaterno,string apellidoMaterno, DateTime fechaNacimiento,string correoElectronico, string contrasena, string fraseSecreta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);
                cmd.Parameters.AddWithValue("@FraseSecreta", fraseSecreta);



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
