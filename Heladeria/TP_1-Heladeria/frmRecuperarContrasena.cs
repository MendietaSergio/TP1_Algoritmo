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

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            // Si el email está vacío, avisamos y salimos
            if (txtEmail.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Complete el campo.";
                txtEmail.Focus();
                return;
            }
            // Chequear email
            bool esValido = Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!esValido)
            {
                lblError.Visible = true;
                lblError.Text = "Email invalido.";
                txtEmail.Focus();
                return;
            }

            // Si llegamos acá, significa que hay texto.
            // Como es un trabajo práctico sin base de datos real, 
            // vamos a simular que el usuario existe (o puedes poner un if simple con un email fijo si quieres probar).

            while (true)
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (txtEmail.Text == usuarios[i][4])
                    {
                        indiceUsuario = i;
                        MessageBox.Show("Código enviado a " + txtEmail.Text + "\nEl código es: 1234");
                        lblError.Visible = false;
                        // Ahora habilitamos lo que estaba bloqueado
                        txtCodigo.Enabled = true;
                        btnValidarCodigo.Enabled = true;

                        // Desactivamos este botón para que no lo aprieten dos veces
                        btnEnviarCodigo.Enabled = false;

                        // Cambiamos el mensaje de arriba
                        lblEstado.Text = "Ingresá el código que te llego (1234)";

                        // Limpiamos el campo de código por si acaso
                        txtCodigo.Text = "";
                        txtCodigo.Focus(); // Dejamos el cursor listo para escribir
                        return;
                    }
                }
                lblError.Visible = true;
                lblError.Text = "Error: los datos son incorrectos.";
                txtEmail.Focus();
                break;
            }

        }
        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            // 1. Verificar que no haya escrito nada en el código
            if (txtCodigo.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Falta poner el codigo.";
                txtCodigo.Focus();
                return;
            }

            // 2. Verificar si el código es correcto (asumimos que es "1234" como pedía el TP)
            if (txtCodigo.Text == "1234")
            {
                // ¡Código correcto!
                MessageBox.Show("¡Código válido! Ahora podés poner tu nueva contraseña.");

                // Habilitamos las cajas de contraseña
                txtNuevaContra.Enabled = true;
                txtConfirmarContra.Enabled = true;

                // Habilitamos el botón final
                btnGuardarContra.Enabled = true;

                // Desactivamos el botón de validar para que no lo aprieten de nuevo
                btnValidarCodigo.Enabled = false;

                // Limpiamos el campo de código y ponemos el foco en la nueva contraseña
                txtCodigo.Text = "";
                txtNuevaContra.Focus();
                lblError.Visible = false;
                // Actualizamos el mensaje de estado
                lblEstado.Text = "Código válido. Ingresá tu nueva contraseña.";
            }
            else
            {
                // Código incorrecto
                lblError.Visible = true;
                lblError.Text = "El código que ingresaste es incorrecto. Intentá de nuevo.";
                txtCodigo.Focus();

                // Limpiamos el campo de código para que intente de nuevo
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
        }


        private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            // 1. Verificar que no estén vacías
            if (txtNuevaContra.Text == "" || txtConfirmarContra.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "¡Falta completar las contraseñas!.";
                txtNuevaContra.Focus();
                return;
            }

            // 2. Verificar longitud (al menos 8)
            if (txtNuevaContra.Text.Length < 8)
            {
                lblError.Visible = true;
                lblError.Text = "La contraseña debe tener al menos 8 caracteres.";
                txtNuevaContra.Focus();
                return;
            }

            // 3. Verificar que coincidan
            if (txtNuevaContra.Text != txtConfirmarContra.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Las contraseñas no coinciden.";
                txtConfirmarContra.Focus();
                return;
            }

            usuarios[indiceUsuario][18] = txtNuevaContra.Text;
            lblError.Visible = false;
            // ¡SI LLEGAMOS AQUÍ, ES QUE TODO ESTÁ BIEN!
            MessageBox.Show("¡Éxito! Contraseña cambiada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerrar este formulario
            this.Close();
            frmLogin login = new frmLogin(usuarios);
            login.Show();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin(usuarios);
            login.Show();
            this.Close();
        }

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
    }
}
