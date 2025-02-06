using System;

namespace WebFormApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioNombre"] != null)
            {
                lblBienvenida.Text = "Bienvenido, " + Session["UsuarioNombre"].ToString() + "!";
            }
            else
            {
                Response.Redirect("~/Login2.aspx"); // Redirigir si no hay sesión activa
            }
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Lógica para crear un nuevo usuario
            Response.Redirect("~/AltaUsuarios2.aspx"); // Redirige a la página de creación de usuario
        }

        protected void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de lista de usuarios
            Response.Redirect("Usuarios.aspx");
        }
    }
}
