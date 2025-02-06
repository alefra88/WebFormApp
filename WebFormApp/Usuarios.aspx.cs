using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar la lista de usuarios al cargar la página
                CargarUsuarios();
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                // Obtener el ID del usuario seleccionado
                int usuarioId = Convert.ToInt32(e.CommandArgument);

                // Obtener los detalles del usuario de la base de datos
                CargarDetalleUsuario(usuarioId);

                // Mostrar el panel de detalles
                usuarioDetalle.Visible = true;
            }
        }

        private void CargarUsuarios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "EXEC sp_ListarUsuarios"; // Procedimiento almacenado para obtener usuarios
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUsuarios.DataSource = dt;
                gvUsuarios.DataBind();
            }
        }

        private void CargarDetalleUsuario(int IdUsuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "EXEC sp_ObtenerUsuarioPorID @IdUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtApellidoPaterno.Text = reader["ApellidoPaterno"].ToString();
                    txtApellidoMaterno.Text = reader["ApellidoMaterno"].ToString();
                    txtFechaNacimiento.Text = Convert.ToDateTime(reader["FechaNacimiento"]).ToString("yyyy-MM-dd");
                    txtCorreo.Text = reader["CorreoElectronico"].ToString();
                }
                con.Close();
            }
        }
    }
}
