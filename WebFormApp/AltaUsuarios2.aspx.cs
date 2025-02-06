using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class AltaUsuarios2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UsuariosBLL usuariosBLL = new UsuariosBLL();
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los controles de ASP.NET
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPaterno.Text.Trim();
            string apellidoMaterno = txtApellidoMaterno.Text.Trim();
            string fechaNacimientoStr = txtFechaNacimiento.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            string contrasena = "12345";
            string frase = "Master";

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidoPaterno) ||
                string.IsNullOrEmpty(apellidoMaterno) || string.IsNullOrEmpty(fechaNacimientoStr) ||
                string.IsNullOrEmpty(correo))
            {

                return;
            }

            // Validación de formato de correo electrónico
            if (!Regex.IsMatch(correo, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return;
            }

            // Validación de fecha
            if (!DateTime.TryParse(fechaNacimientoStr, out DateTime fechaNacimiento))
            {
                return;
            }

            // Registrar en la base de datos
            try
            {
                RegistrarUsuarioEnBD(nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, correo,contrasena,frase);
                Response.Redirect("~/Default.aspx", false);
            }
            catch (Exception ex)
            {
            }
        }

        private void RegistrarUsuarioEnBD(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string correo, string contrasena,string frase)
        {
            usuariosBLL.RegistrarUsuario(nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, correo, contrasena,frase);
        }
    }


}

