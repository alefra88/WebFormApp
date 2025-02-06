using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;

namespace DaL
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class Conexion
    {
        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        public static bool ValidarUsuario(string usuario, string contrasena, out bool requiereCambio)
        {
            bool esValido = false;
            requiereCambio = false;

            using (SqlConnection con = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_LoginUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int resultado = Convert.ToInt32(reader["Resultado"]);
                        requiereCambio = Convert.ToBoolean(reader["CambioContrasena"]);
                        esValido = (resultado == 1);
                    }
                }
            }
            return esValido;
        }
    }

}
