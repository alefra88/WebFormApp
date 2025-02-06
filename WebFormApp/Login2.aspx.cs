using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebFormApp
{
    public partial class Login2 : System.Web.UI.Page
    {
        UsuariosBLL usuariosBLL = new UsuariosBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validación de los campos
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MostrarAlerta("Por favor ingresa tu correo y contraseña.");
                return;
            }

            // Validación en la base de datos
            try
            {
                // Validar las credenciales
                int? idUsuario = usuariosBLL.ValidarCredenciales(correo, contrasena);

                if (idUsuario.HasValue)
                {
                    // Si las credenciales son correctas, guardar la información del usuario en la sesión
                    Session["UsuarioCorreo"] = correo;
                    Session["UsuarioId"] = idUsuario.Value;

                    // Redirigir al usuario a la página principal
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    MostrarAlerta("Correo o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al intentar iniciar sesión: " + ex.Message);
            }
        }

        private void MostrarAlerta(string mensaje)
        {
            Response.Write($"<script>alert('{mensaje}');</script>");
        }
    }
}