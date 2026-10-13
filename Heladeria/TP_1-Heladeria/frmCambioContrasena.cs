using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP_1_Heladeria
{
    public partial class frmCambioContrasena : Form
    {
        public int indiceUsuario;
        public BindingList<string[]> usuarios = new BindingList<string[]>();

        public frmCambioContrasena(BindingList<string[]> _usuarios, int _indiceUsuario)
        {
            InitializeComponent();
            lblError.Visible = false;
            usuarios = _usuarios;
            indiceUsuario = _indiceUsuario;

            if (usuarios[indiceUsuario][19].ToLower() == "no")
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
            //lblError.Visible = false;
            //lblError.Text = "Error: ";
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
            //usuarios[indiceUsuario][18] = txtPass.Text;
            //MessageBox.Show(
            //    "¡La contraseña se generó exitosamente!",
            //        "Cambio guardado", MessageBoxButtons.OK, MessageBoxIcon.Information
            //        );

            //if (usuarios[indiceUsuario][19].ToLower() == "si")
            //{
            //    frmPrincipal frmPrincipal = new frmPrincipal(usuario);
            //    frmPrincipal.Show();
            //    usuarios[indiceUsuario][19] = "no";
            //}

            //this.Close();
            //return;

            {
                lblError.Visible = false;

                if (string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    lblError.Text = "Error: Ingresá la nueva contraseña.";
                    lblError.Visible = true;
                    txtPass.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPass2.Text))
                {
                    lblError.Text = "Error: Confirmá la nueva contraseña.";
                    lblError.Visible = true;
                    txtPass2.Focus();
                    return;
                }

                if (txtPass.Text.Length < 8)
                {
                    lblError.Text = "Error: La contraseña debe tener al menos 8 caracteres.";
                    lblError.Visible = true;
                    txtPass.Focus();
                    return;
                }

                if (txtPass.Text != txtPass2.Text)
                {
                    lblError.Text = "Error: Las contraseñas no coinciden.";
                    lblError.Visible = true;
                    txtPass2.Focus();
                    return;
                }


                bool primerIngreso = usuario.PrimerInicio;

                try
                {
                    string cadenaConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=Heladeria;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = @"
            UPDATE dbo.Usuarios
            SET Pass = @Pass,
                PrimerInicio = 0
            WHERE IdUsuario = @IdUsuario";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Pass", txtPass.Text);
                            comando.Parameters.AddWithValue("@IdUsuario", usuario.id);

                            int filasAfectadas = comando.ExecuteNonQuery();

                            if (filasAfectadas != 1)
                            {
                                MessageBox.Show("No se pudo actualizar la contraseña.");
                                return;
                            }
                        }
                    }

                    usuario.Pass = txtPass.Text;
                    usuario.PrimerInicio = false;

                    MessageBox.Show(
                        "¡La contraseña se actualizó correctamente!",
                        "Cambio guardado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if (primerIngreso)
                    {
                        frmPrincipal formularioPrincipal = new frmPrincipal(usuario);

                        this.Hide();
                        formularioPrincipal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cambiar la contraseña: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
<<<<<<< Updated upstream
            usuarios[indiceUsuario][18] = txtPass.Text;
            MessageBox.Show(
                "¡La contraseña se generó exitosamente!",
                    "Cambio guardado", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );

            if (usuarios[indiceUsuario][19].ToLower() == "si")
            {
                frmPrincipal frmPrincipal = new frmPrincipal(usuarios, indiceUsuario);
                frmPrincipal.Show();
                usuarios[indiceUsuario][19] = "no";
            }

            this.Close();
            return;
=======
>>>>>>> Stashed changes
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
