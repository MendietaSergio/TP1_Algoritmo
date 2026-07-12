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


            while (true)
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (txtEmail.Text == usuarios[i][4])
                    {
                        indiceUsuario = i;
                        MessageBox.Show("Código enviado a " + txtEmail.Text + "\nEl código es: 1234");
                        lblError.Visible = false;

                        txtCodigo.Enabled = true;
                        btnValidarCodigo.Enabled = true;

                        btnEnviarCodigo.Enabled = false;

                        lblEstado.Text = "Ingresá el código que te llego (1234)";

                        txtCodigo.Text = "";
                        txtCodigo.Focus(); 
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
            if (txtCodigo.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Falta poner el codigo.";
                txtCodigo.Focus();
                return;
            }

            if (txtCodigo.Text == "1234")
            {
                MessageBox.Show("¡Código válido! Ahora podés poner tu nueva contraseña.");

                txtNuevaContra.Enabled = true;
                txtConfirmarContra.Enabled = true;

                btnGuardarContra.Enabled = true;

                btnValidarCodigo.Enabled = false;

                txtCodigo.Text = "";
                txtCodigo.Enabled = false;

                txtNuevaContra.Focus();
                lblError.Visible = false;
                lblEstado.Text = "Código válido. Ingresá tu nueva contraseña.";

                imgShow1.Visible = true;
                imgShow2.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "El código que ingresaste es incorrecto. Intentá de nuevo.";
                txtCodigo.Focus();

                txtCodigo.Text = "";
                txtCodigo.Focus();
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

            usuarios[indiceUsuario][18] = txtNuevaContra.Text;
            lblError.Visible = false;
            MessageBox.Show("¡Éxito! Contraseña cambiada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
