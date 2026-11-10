using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TP_1_Heladeria
{
    public partial class frmCambioContrasena : Form
    {
        private Usuario usuario;
        private DB_Conexion CN = new DB_Conexion();

        public frmCambioContrasena(Usuario _usuario)
        {
            InitializeComponent();
            lblError.Visible = false;
            usuario = _usuario;

            if (!usuario.PrimerInicio)
            {
                lblTitulo.Text = "Cambio de Contraseña";
                lblTitulo.Location = new Point(106, 60);
                lblInfo.Visible = false;
                btnAtras.Visible = true;
            }
        }

        // Eventos Botones
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtPass2.Text = "";
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "Error: ";

            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Error: Campo vacío, revísalo.";
                txtPass.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPass2.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Error: Campo vacío, revísalo.";
                txtPass2.Focus();
                return;
            }
            if (txtPass.Text.Length < 8)
            {
                lblError.Visible = true;
                lblError.Text = "Error: La contraseña debe tener al menos 8 caracteres.";
                txtPass.Focus();
                return;
            }
            if (txtPass.Text != txtPass2.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Error: Las contraseñas no coinciden.";
                txtPass.Focus();
                return;
            }

            try
            {
                CN.Conectar_BD();
                string query = @"UPDATE dbo.Usuarios
                                 SET Pass = @Pass,
                                     PrimerInicio = 0
                                 WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion()))
                {
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text.Trim());
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.id);

                    int filas = cmd.ExecuteNonQuery();
                    if (filas == 0)
                    {
                        MessageBox.Show("No se encontró el usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                usuario.Pass = txtPass.Text.Trim();
                bool eraPrimerInicio = usuario.PrimerInicio;
                usuario.PrimerInicio = false;

                MessageBox.Show(
                    "¡La contraseña se actualizó exitosamente!",
                    "Cambio guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (eraPrimerInicio)
                {
                    frmPrincipal frmPrincipal = new frmPrincipal(usuario);
                    frmPrincipal.Show();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Eventos Imagenes
        private void imgShowContrasena_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';
            imgShowContrasena.Visible = false;
            imgHideContrasena.Visible = true;
        }
        private void imgHideContrasena_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            imgShowContrasena.Visible = true;
            imgHideContrasena.Visible = false;
        }
        private void imgHideConf_Click(object sender, EventArgs e)
        {

            txtPass2.PasswordChar = '*';
            imgHideConf.Visible = false;
            imgShowConf.Visible = true;
        }
        private void imgShowConf_Click(object sender, EventArgs e)
        {
            txtPass2.PasswordChar = '\0';
            imgHideConf.Visible = true;
            imgShowConf.Visible = false;
        }
    }
}
