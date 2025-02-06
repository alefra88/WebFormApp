using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using System.Configuration;

namespace DAL
{
    public class UsuariosDAL
        
    {
        private string claveDefault = ConfigurationManager.AppSettings["ClaveDefault"];
        private string fraseSecreta = ConfigurationManager.AppSettings["FraseSecreta"];


        public (int?, string) ValidarCredenciales(string correo, string contrasena)
        {
            int? idUsuario = null;
            string nombreUsuario = null;

            using (SqlConnection con = Conexion.ObtenerConexion()) 
            {
                using (SqlCommand cmd = new SqlCommand("sp_LoginUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                    cmd.Parameters.AddWithValue("@Contrasena", claveDefault);
                    cmd.Parameters.AddWithValue("@FraseSecreta", fraseSecreta); 

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        idUsuario = reader.GetInt32(0); 
                        nombreUsuario = reader.GetString(1); 
                    }
                }
            }
            return (idUsuario, nombreUsuario);
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
                cmd.Parameters.AddWithValue("@Contrasena", claveDefault);
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

        public void CambiarContrasena(int idUsuario, string nuevaContrasena, string fraseSecreta)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CambiarContrasena", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@NuevaContrasena", nuevaContrasena);
                    cmd.Parameters.AddWithValue("@FraseSecreta", fraseSecreta);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
