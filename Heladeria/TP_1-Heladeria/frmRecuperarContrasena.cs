using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TP_1_Heladeria
{
    public partial class frmRecuperarContrasena : Form
    {
        public frmRecuperarContrasena()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private bool avanzo = false;
        private string codigo = "";
        private DB_Conexion CN = new DB_Conexion();
        private ValidacionDeCampos Validaciones = new ValidacionDeCampos();


        //Eventos Botones
        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmail.Text = txtEmail.Text.Trim();
                txtEmail.AccessibleName = "Email";
                TextBox[] textBoxes = new TextBox[] { txtEmail };
                Validaciones.TextoVacio(textBoxes);
                Validaciones.EMail(txtEmail);
                CN.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE LOWER(Email) = LOWER(@Email)";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    codigo = GenerarCodigoAlfanumerico();
                    MessageBox.Show("Código enviado a " + txtEmail.Text + "\nEl código es: " + codigo, "Código de Recuperación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblError.Visible = false;
                    txtCodigo.Enabled = true;
                    btnValidarCodigo.Enabled = true;
                    txtEmail.Enabled = false;

                    btnEnviarCodigo.Enabled = false;

                    lblEstado.Text = "Ingresá el código que te llegó por mail (el que está en la base de datos)";

                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                    avanzo = true;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Email no registrado.";
                    txtEmail.Focus();
                    avanzo = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                MessageBox.Show("Error al enviar el código: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                avanzo = false;
            }
            finally
            {
                CN.Desconectar();
            }

            // UPDATE envio de codigo
            if (avanzo)
            {
                try
                {
                    CN.Conectar_BD();
                    string queryUpdate = "UPDATE Usuarios SET cod_Recupero = @cod_Recupero WHERE LOWER(Email) = LOWER(@Email)";

                    SqlCommand cmdUpdateCod = new SqlCommand(queryUpdate, CN.MostrarConexion());
                    cmdUpdateCod.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmdUpdateCod.Parameters.AddWithValue("@cod_Recupero", codigo);

                    cmdUpdateCod.ExecuteNonQuery();

                    txtCodigo.Text = "";
                    codigo = "";
                    txtCodigo.Focus();
                    avanzo = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el código en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    avanzo = false;
                }
                finally
                {
                    CN.Desconectar();
                }
            }
        }

        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = txtCodigo.Text.Trim();
                txtCodigo.AccessibleName = "Código";
                TextBox[] textBoxes = new TextBox[] { txtCodigo };
                Validaciones.TextoVacio(textBoxes);
                CN.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE LOWER(Email) = LOWER(@Email) AND cod_Recupero = @cod_Recupero";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@cod_Recupero", txtCodigo.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNuevaContra.Enabled = true;
                    txtConfirmarContra.Enabled = true;
                    btnGuardarContra.Enabled = true;
                    btnValidarCodigo.Enabled = false;
                    txtCodigo.Enabled = false;
                    txtNuevaContra.Focus();
                    avanzo = true;
                    lblError.Visible = false;
                    lblError.Text = "";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Código incorrecto.";
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                MessageBox.Show("Error al validar el código: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                avanzo = false;
            }
            finally
            {
                CN.Desconectar();
            }
        }

        private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            try
            {
                txtNuevaContra.AccessibleName = "Nueva Contraseña";
                txtConfirmarContra.AccessibleName = "Confirmar Contraseña";
                TextBox[] textBoxes = new TextBox[] { txtNuevaContra, txtConfirmarContra };
                Validaciones.TextoVacio(textBoxes);
                Validaciones.LongitudTexto(txtNuevaContra, 8, 20);
                Validaciones.LongitudTexto(txtConfirmarContra, 8, 20);
                Validaciones.compararContrasenias(txtNuevaContra, txtConfirmarContra);

                CN.Conectar_BD();
                string queryUpdate = "UPDATE Usuarios SET Pass = @pass, cod_Recupero = NULL WHERE LOWER(Email) = LOWER(@Email)";

                SqlCommand cmdUpdateCod = new SqlCommand(queryUpdate, CN.MostrarConexion());
                cmdUpdateCod.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdUpdateCod.Parameters.AddWithValue("@pass", txtConfirmarContra.Text);

                cmdUpdateCod.ExecuteNonQuery();

                lblError.Visible = false;
                MessageBox.Show("¡Éxito! Contraseña cambiada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                MessageBox.Show("Error al guardar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void imgShow1_Click(object sender, EventArgs e)
        {
            txtNuevaContra.PasswordChar = '\0';
            imgShow1.Visible = false;
            imgHide1.Visible = true;
        }
        private void imgHide1_Click(object sender, EventArgs e)
        {
            txtNuevaContra.PasswordChar = '*';
            imgShow1.Visible = true;
            imgHide1.Visible = false;
        }
        private void imgShow2_Click(object sender, EventArgs e)
        {
            txtConfirmarContra.PasswordChar = '\0';
            imgShow2.Visible = false;
            imgHide2.Visible = true;
        }
        private void imgHide2_Click(object sender, EventArgs e)
        {
            txtConfirmarContra.PasswordChar = '*';
            imgShow2.Visible = true;
            imgHide2.Visible = false;
        }
        public string GenerarCodigoAlfanumerico()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] resultado = new char[4];

            for (int i = 0; i < 4; i++)
            {
                // Elige un índice al azar entre 0 y la longitud de la cadena 'caracteres'
                resultado[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(resultado);
        }
    }
}
