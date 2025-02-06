using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class Login : Page
    {
        protected void Login_Click(object sender, EventArgs e)
        {
            string usuario = this.usuario.Value;
            string contrasena = this.contrasena.Value;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                // Mostrar error de datos incompletos
                Response.Write("<script>alert('Por favor, ingrese todos los datos');</script>");
                return;
            }

            // Validar en la base de datos
            bool loginExitoso = ValidarLogin(usuario, contrasena);

            if (loginExitoso)
            {
                // Verificar si es la primera vez que el usuario ingresa
                bool esPrimeraVez = VerificarPrimerIngreso(usuario);
                if (esPrimeraVez)
                {
                    Response.Redirect("CambiarContrasena.aspx");
                }
                else
                {
                    // Redirigir al dashboard
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
        }

        private bool ValidarLogin(string usuario, string contrasena)
        {
            // Validar las credenciales en la base de datos
            // Aquí se conecta con el DAL para verificar usuario y contraseña
            return true; // Asumiendo que la validación es exitosa para el ejemplo
        }

        private bool VerificarPrimerIngreso(string usuario)
        {
            // Verificar si es la primera vez que el usuario ingresa
            return true; // Asumimos que es la primera vez para el ejemplo
        }
    }
}
