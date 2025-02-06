using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuariosBLL
    {
        private UsuariosDAL usuarioDAL;

        public UsuariosBLL()
        {
            // No es necesario pasar connectionString porque lo maneja Conexion.ObtenerConexion()
            usuarioDAL = new UsuariosDAL();
        }

        public Usuarios Login(string correo, string contrasena)
        {
            Usuarios usuario = usuarioDAL.Login(correo, contrasena);
            if (usuario != null)
            {
                // Validar si es la primera vez que ingresa
                if (usuario.ContrasenaHash.SequenceEqual(HashPassword("12345")))
                {
                    throw new Exception("Es necesario cambiar la contraseña.");
                }
            }
            return usuario;
        }

        public void CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            usuarioDAL.CambiarContrasena(idUsuario, nuevaContrasena);
        }

        public void RegistrarUsuario(Usuarios usuario, string contrasena)
        {
            usuarioDAL.RegistrarUsuario(usuario, contrasena);
        }

        public List<Usuarios> ListarUsuarios()
        {
            return usuarioDAL.ListarUsuarios();
        }

        public Usuarios ObtenerUsuarioPorId(int idUsuario)
        {
            return usuarioDAL.ObtenerUsuarioPorId(idUsuario);
        }

        private byte[] HashPassword(string password)
        {
            return HashAlgorithm.Create("SHA512").ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

}
