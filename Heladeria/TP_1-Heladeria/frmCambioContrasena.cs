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

        public frmCambioContrasena(BindingList<string[]> _usuarios, int indiceUsuario)
        {
            InitializeComponent();
            imgHide1.Visible = true;
            imgShow1.Visible = false;
            imgHide2.Visible = true;
            imgShow2.Visible = false;
            lblError.Visible = false;
            usuarios = _usuarios;
            indiceUsuario = indiceUsuario;
        }

        private void imgShow1_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            imgHide1.Visible = true;
            imgShow1.Visible = false;
        }

        private void imgHide1_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';
            imgHide1.Visible = false;
            imgShow1.Visible = true;
        }

        private void imgShow2_Click(object sender, EventArgs e)
        {
            txtPass2.PasswordChar = '*';
            imgHide2.Visible = true;
            imgShow2.Visible = false;
        }

        private void imgHide2_Click(object sender, EventArgs e)
        {
            txtPass2.PasswordChar = '\0';
            imgHide2.Visible = false;
            imgShow2.Visible = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtPass2.Text = "";
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            lblError.Visible=false;
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
            if(txtPass.MaxLength <= 8 )
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
            usuarios[indiceUsuario][19] = "no";
            MessageBox.Show(
                "¡La contraseña se generó exitosamente!",
                    "Cambio guardado", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
            frmPrincipal frmPrincipal = new frmPrincipal(usuarios, indiceUsuario);
            frmPrincipal.Show();
            this.Close();
            return;
        }
    }
}
