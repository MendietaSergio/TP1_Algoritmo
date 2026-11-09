using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace TP_1_Heladeria
{
    public partial class frmCambioContrasena : Form
    {
        Usuario usuario = new Usuario();
        ValidacionDeCampos Validaciones = new ValidacionDeCampos();
        public frmCambioContrasena(Usuario _usuario)
        {
            InitializeComponent();

            lblError.Visible = false;

            //usuarios = _usuarios;
            usuario = _usuario;
            //indiceUsuario = _indiceUsuario;

            if (!usuario.PrimerInicio)
            {
                lblTitulo.Text = "Cambio de Contraseña";
                lblTitulo.Location = new Point(106, 60);
                lblInfo.Visible = false;
                btnAtras.Visible = true;

            }
        }

        //Eventos Botones
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtPass2.Text = "";
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        { 


            //if (txtPass.Text == "")
            //{
            //    lblError.Visible = true;
            //    lblError.Text = lblError.Text + "Campo vacio, revisalos.";
            //    txtPass.Focus();
            //    return;
            //}
            //if (txtPass2.Text == "")
            //{
            //    lblError.Visible = true;
            //    lblError.Text = lblError.Text + "Campo vacio, revisalos.";
            //    txtPass2.Focus();
            //    return;
            //}
            //if (txtPass.MaxLength <= 8)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = lblError.Text + "Contraseña menor a 8 caracteres.";
            //    txtPass.Focus();
            //    return;
            //}
            //if (txtPass2.MaxLength <= 8)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = lblError.Text + "Contraseña menor a 8 caracteres.";
            //    txtPass2.Focus();
            //    return;
            //}

            //if (txtPass.Text != txtPass2.Text)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = lblError.Text + "Contraseñas no coinciden.";
            //    txtPass.Focus();

            //    return;
            //}


        
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(txtPass2.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Error: completá los dos campos.";
                return;
            }

            if (txtPass.Text != txtPass2.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Error: las contraseñas no coinciden.";
                return;
            }

            if (txtPass.Text.Length < 8)
            {
                lblError.Visible = true;
                lblError.Text = "Error: la contraseña debe tener al menos 8 caracteres.";
                return;
            }

            DB_Conexion CN = new DB_Conexion();

            try
            {
                CN.Conectar_BD();

                string query = @"UPDATE dbo.Usuarios
                         SET Pass = @Pass,
                             PrimerInicio = 0
                         WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd =
                    new SqlCommand(query, CN.MostrarConexion()))
                {
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.id);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas == 0)
                    {
                        MessageBox.Show("No se encontró el usuario.");
                        return;
                    }
                }

                usuario.Pass = txtPass.Text;
                usuario.PrimerInicio = false;

                MessageBox.Show(
                    "¡La contraseña se cambió correctamente!",
                    "Cambio guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña: " + ex.Message);
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
