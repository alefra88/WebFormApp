using System;

namespace WebFormApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí podrías agregar algún código para mostrar el nombre de usuario si está en sesión
            if (Session["UsuarioNombre"] != null)
            {
                // Mostrar el saludo o realizar otras acciones
            }
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de creación de usuarios
            Response.Redirect("AltaUsuarios2.aspx");
        }

        protected void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de lista de usuarios
            Response.Redirect("Usuarios.aspx");
        }
    }
}
