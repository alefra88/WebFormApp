using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class CambioContrasena : System.Web.UI.Page
    {

        private UsuariosBLL usuarioBLL = new UsuariosBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioPendienteCambio"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores del formulario
                int idUsuario = Convert.ToInt32(Session["UsuarioId"]); // Asegúrate de convertir a int
                string nuevaContrasena = txtNuevaContrasena.Text.Trim();
                string fraseSecreta = "Master"; // O la frase secreta que determines

                // Llamar al método para cambiar la contraseña
                UsuariosDAL usuariosDAL = new UsuariosDAL();
                usuariosDAL.CambiarContrasena(idUsuario, nuevaContrasena, fraseSecreta);

                // Redirigir o mostrar mensaje de éxito
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                
            }
        }



    }

}