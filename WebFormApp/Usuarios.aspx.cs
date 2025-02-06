using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebFormApp
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private UsuariosBLL usuariosBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (usuariosBLL == null)
                {
                    usuariosBLL = new UsuariosBLL();
                }

                
                CargarUsuarios();
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                
                int usuarioId = Convert.ToInt32(e.CommandArgument);

                
                Response.Redirect("DetalleUsuario.aspx?idUsuario=" + usuarioId);
            }
        }


        private void CargarUsuarios()
        {
            
            var usuarios = usuariosBLL.ListarUsuarios();

           
            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }
    }
}

