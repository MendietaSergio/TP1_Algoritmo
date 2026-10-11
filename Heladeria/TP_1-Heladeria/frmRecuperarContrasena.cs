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
        int indiceUsuario;
             public frmRecuperarContrasena()
        {
            InitializeComponent();
            lblError.Visible = false;
        }
        Boolean avanzo = false;
        string codigo = "";
        // Instancias tu clase de conexión centralizada
        DB_Conexion CN = new DB_Conexion();
        //SqlConnection CN = null;
        //
        ValidacionDeCampos Validaciones = new ValidacionDeCampos();


        //Eventos Botones
        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
                  
            try {
                TextBox[] textBoxes = new TextBox[] { txtEmail };
                Validaciones.TextoVacio(textBoxes);
                Validaciones.EMail(txtEmail);
                CN.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
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
            }
            finally
            {
                CN.Desconectar();

            }
            //UPDATE envio de codigo
            if (avanzo)
            {
                try
                {

                    CN.Conectar_BD();
                    
                    //Actualizo el codigo en la bse de datos, porque no tenemos envio de mail por ahora.
                    string queryUpdate = "UPDATE Usuarios set cod_Recupero=@cod_Recupero WHERE Email =@Email";

                    SqlCommand cmdUpdateCod = new SqlCommand(queryUpdate, CN.MostrarConexion());

                    cmdUpdateCod.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmdUpdateCod.Parameters.AddWithValue("@cod_Recupero", codigo);

                    cmdUpdateCod.ExecuteNonQuery();

                    txtCodigo.Text = "";
                    codigo= "";
                    txtCodigo.Focus();
                    avanzo = true;
                    
                }
                catch (Exception ex)
                {
                MessageBox.Show($"Se ha producido un error: {ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Error al enviar el codigo: " + ex.Message);
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
                TextBox[] textBoxes = new TextBox[] { txtCodigo };
                Validaciones.TextoVacio(textBoxes);
                CN.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE Email = @Email AND cod_Recupero = @cod_Recupero";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
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
                MessageBox.Show($"Se ha producido un error: {ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Error al validar el codigo: " + ex.Message);
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
                TextBox[] textBoxes = new TextBox[] { txtNuevaContra, txtConfirmarContra };
                Validaciones.TextoVacio(textBoxes);
                Validaciones.LongitudTexto(txtNuevaContra, 8, 20);
                Validaciones.LongitudTexto(txtConfirmarContra, 8, 20);
                Validaciones.compararContrasenias(txtNuevaContra, txtConfirmarContra);
                CN.Conectar_BD();
                string queryUpdate = "UPDATE Usuarios set pass=@pass, cod_recupero='' WHERE Email =@Email";

                SqlCommand cmdUpdateCod = new SqlCommand(queryUpdate, CN.MostrarConexion());

                cmdUpdateCod.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdUpdateCod.Parameters.AddWithValue("@pass", txtConfirmarContra.Text);

                cmdUpdateCod.ExecuteNonQuery();

                lblError.Visible = false;
                MessageBox.Show("¡Éxito! Contraseña cambiada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmLogin login = new frmLogin();
                login.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la contraseña: " + ex.Message);
            }
            finally
            {
                CN.Desconectar();
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
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
