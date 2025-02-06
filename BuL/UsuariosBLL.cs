using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class UsuariosBLL
    {
        private UsuariosDAL usuarioDAL;

        public UsuariosBLL()
        {
            
            usuarioDAL = new UsuariosDAL();
        }


        public (int? IdUsuario, string NombreUsuario) ValidarCredenciales(string correo, string contrasena)
        {
            return new UsuariosDAL().ValidarCredenciales(correo, contrasena);
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

    }

}
