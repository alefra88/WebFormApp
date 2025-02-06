using BLL;
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevaContrasena = txtNuevaContrasena.Text;
            string confirmarContrasena = txtConfirmarContrasena.Text;

            if (string.IsNullOrEmpty(nuevaContrasena) || nuevaContrasena.Length < 6)
            {
                Response.Write("<script>alert('La contraseña debe tener al menos 6 caracteres.');</script>");
                return;
            }

            if (nuevaContrasena != confirmarContrasena)
            {
                Response.Write("<script>alert('Las contraseñas no coinciden.');</script>");
                return;
            }

            
        }
    }

}