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
            
            usuarioDAL = new UsuariosDAL();
        }

        public Usuarios Login(string correo, string contrasena)
        {
            return usuarioDAL.Login(correo, contrasena);
        }

        public int? ValidarCredenciales(string correo, string contrasena)
        {
            return UsuariosDAL.ValidarUsuario(correo, contrasena);
        }

        public void RegistrarUsuario(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string correo, string contrasena,string frase)
        {
            usuarioDAL.RegistrarUsuario(nombre,apellidoPaterno, apellidoMaterno, fechaNacimiento, correo,contrasena,frase);
        }

        public List<Usuarios> ListarUsuarios()
        {
            return usuarioDAL.ListarUsuarios();
        }

        public ENT.Usuarios ObtenerUsuarioPorId(int idUsuario)
        {
            return usuarioDAL.ObtenerUsuarioPorId(idUsuario);
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            using (var sha512 = new SHA512Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];

                Buffer.BlockCopy(salt, 0, combinedBytes, 0, salt.Length);
                Buffer.BlockCopy(passwordBytes, 0, combinedBytes, salt.Length, passwordBytes.Length);

                return sha512.ComputeHash(combinedBytes);
            }
        }

    }

}
