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

        Usuario usuario = new Usuario();
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
            lblError.Visible = false;
            lblError.Text = "Error: ";
            if (txtPass.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = lblError.Text + "Campo vacio, revisalos.";
                txtPass.Focus();
                return;
            }
            if (txtPass2.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = lblError.Text + "Campo vacio, revisalos.";
                txtPass2.Focus();
                return;
            }
            if (txtPass.MaxLength <= 8)
            {
                lblError.Visible = true;
                lblError.Text = lblError.Text + "Contraseña menor a 8 caracteres.";
                txtPass.Focus();
                return;
            }
            if (txtPass2.MaxLength <= 8)
            {
                lblError.Visible = true;
                lblError.Text = lblError.Text + "Contraseña menor a 8 caracteres.";
                txtPass2.Focus();
                return;
            }

            if (txtPass.Text != txtPass2.Text)
            {
                lblError.Visible = true;
                lblError.Text = lblError.Text + "Contraseñas no coinciden.";
                txtPass.Focus();

                return;
            }
            usuarios[indiceUsuario][18] = txtPass.Text;
            MessageBox.Show(
                "¡La contraseña se generó exitosamente!",
                    "Cambio guardado", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );

            if (usuarios[indiceUsuario][19].ToLower() == "si")
            {
                frmPrincipal frmPrincipal = new frmPrincipal(usuario);
                frmPrincipal.Show();
                usuarios[indiceUsuario][19] = "no";
            }

            this.Close();
            return;
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
