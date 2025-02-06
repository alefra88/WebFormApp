using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ENT;

namespace WebFormApp
{
    public partial class DetalleUsuario : Page
    {
        private UsuariosBLL usuariosBLL;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicializar el objeto BLL
            usuariosBLL = new UsuariosBLL();

            if (!IsPostBack)
            {
                // Obtener el ID del usuario de la query string o de un parámetro
                if (Request.QueryString["IdUsuario"] != null)
                {
                    int usuarioId = Convert.ToInt32(Request.QueryString["IdUsuario"]);
                    CargarDetalleUsuario(usuarioId);
                }
            }
        }

        // Método para cargar los detalles del usuario en los controles de la página
        private void CargarDetalleUsuario(int idUsuario)
        {
            // Obtener el usuario a través de BLL
            ENT.Usuarios usuario = usuariosBLL.ObtenerUsuarioPorId(idUsuario); 

            if (usuario != null)
            {
                // Asignar los valores a los controles de la página
                txtNombre.Text = usuario.Nombre;
                txtApellidoPaterno.Text = usuario.ApellidoPaterno;
                txtApellidoMaterno.Text = usuario.ApellidoMaterno;
                txtFechaNacimiento.Text = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                txtCorreo.Text = usuario.CorreoElectronico;
            }
            else
            {
                // Si no se encuentra el usuario, podrías mostrar un mensaje o redirigir
                Response.Redirect("~/Usuarios.aspx"); // Redirigir si el usuario no existe
            }
        }

        // Método para el evento del botón Regresar
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            // Redirigir de vuelta a la página de usuarios
            Response.Redirect("~/Usuarios.aspx");
        }
    }
}
