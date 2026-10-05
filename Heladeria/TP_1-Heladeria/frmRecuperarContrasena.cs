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
        BindingList<string[]> usuarios = new BindingList<string[]>();
        int indiceUsuario;
        public frmRecuperarContrasena(BindingList<string[]> _usuarios)
        {
            InitializeComponent();
            usuarios = _usuarios;
            lblError.Visible = false;
        }
        Boolean avanzo = false;
        string codigo = "";
        // Instancias tu clase de conexión centralizada
        BD_Conexion db = new BD_Conexion();
        SqlConnection CN = null;
        //Eventos Botones
        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Complete el campo.";
                txtEmail.Focus();
                return;
            }

            bool esValido = Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!esValido)
            {
                lblError.Visible = true;
                lblError.Text = "Email invalido.";
                txtEmail.Focus();
                return;
            }
            
            
            try {
                
                CN = db.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    codigo = GenerarCodigoAlfanumerico();
                    MessageBox.Show("Código enviado a " + txtEmail.Text + "\nEl código es: " + codigo);
                    lblError.Visible = false;
                    txtCodigo.Enabled = true;
                    btnValidarCodigo.Enabled = true;
                    txtEmail.Enabled = false;

                    btnEnviarCodigo.Enabled = false;

                    lblEstado.Text = "Ingresá el código que te llegó por mail (el que esta en la base de datos)";

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
                MessageBox.Show("Error al enviar el código: " + ex.Message);
                avanzo = false;
                return;

            }
            finally
            {
                CN.Close();
                CN.Dispose();
            }
            //UPDATE envio de codigo
            if (avanzo)
            {
                try
                {

                    CN = db.Conectar_BD();
                    
                    //Actualizo el codigo en la bse de datos, porque no tenemos envio de mail por ahora.
                    string queryUpdate = "UPDATE Usuarios set cod_Recupero=@cod_Recupero WHERE Email =@Email";

                    SqlCommand cmdUpdateCod = new SqlCommand(queryUpdate, CN);

                    cmdUpdateCod.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmdUpdateCod.Parameters.AddWithValue("@cod_Recupero", codigo);

                    //SqlDataReader reader_update = cmdUpdateCod.ExecuteReader();
                    cmdUpdateCod.ExecuteNonQuery();

                    txtCodigo.Text = "";
                    codigo= "";
                    txtCodigo.Focus();
                    avanzo = true;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el codigo: " + ex.Message);
                    avanzo = false;
                }
                finally
                {
                    CN.Close();
                    CN.Dispose();
                }
            }
            
        }
        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Falta poner el codigo.";
                txtCodigo.Focus();
                return;
            }
            try
            {
                CN = db.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE Email = @Email AND cod_Recupero = @cod_Recupero";

                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@cod_Recupero", txtCodigo.Text );

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNuevaContra.Enabled = true;
                    txtConfirmarContra.Enabled = true;

                    btnGuardarContra.Enabled = true;

                    btnValidarCodigo.Enabled = false;

                    //txtCodigo.Text = "";
                    txtCodigo.Enabled = false;

                    //txtCodigo.Text = "";
                    txtCodigo.Focus();
                    avanzo = true;
                    lblError.Visible = true;
                    lblError.Text = "";
                } else
                {
                    lblError.Visible = true;
                    lblError.Text = "Código incorrecto.";
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar el codigo: " + ex.Message);
                avanzo = false;
                return;
            }
            finally
            {
                CN.Close();
                CN.Dispose();
            }
        }
        private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            if (txtNuevaContra.Text == "" || txtConfirmarContra.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "¡Falta completar las contraseñas!.";
                txtNuevaContra.Focus();
                return;
            }

            if (txtNuevaContra.Text.Length < 8)
            {
                lblError.Visible = true;
                lblError.Text = "La contraseña debe tener al menos 8 caracteres.";
                txtNuevaContra.Focus();
                return;
            }

            if (txtNuevaContra.Text != txtConfirmarContra.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Las contraseñas no coinciden.";
                txtConfirmarContra.Focus();
                return;
            }
            try
            {
                CN = db.Conectar_BD();
                string queryUpdate = "UPDATE Usuarios set pass=@pass, cod_recupero='' WHERE Email =@Email";

                SqlCommand cmdUpdateCod = new SqlCommand(queryUpdate, CN);

                cmdUpdateCod.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdUpdateCod.Parameters.AddWithValue("@pass", txtConfirmarContra.Text);

                //SqlDataReader reader_update = cmdUpdateCod.ExecuteReader();
                cmdUpdateCod.ExecuteNonQuery();

                lblError.Visible = false;
                MessageBox.Show("¡Éxito! Contraseña cambiada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmLogin login = new frmLogin(usuarios);
                login.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la contraseña: " + ex.Message);
            }
            finally
            {
                CN.Close();
                CN.Dispose();
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin(usuarios);
            login.Show();
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
