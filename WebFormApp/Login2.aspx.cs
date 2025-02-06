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

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MostrarAlerta("Por favor ingresa tu correo y contraseña.");
                return;
            }

            try
            {
                // Obtener credenciales
                var resultado = usuariosBLL.ValidarCredenciales(correo, contrasena);

                if (resultado.IdUsuario.HasValue)
                {
                    Session["UsuarioCorreo"] = correo;
                    Session["UsuarioId"] = resultado.IdUsuario.Value;
                    Session["UsuarioNombre"] = resultado.NombreUsuario; // Guardar nombre en sesión

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