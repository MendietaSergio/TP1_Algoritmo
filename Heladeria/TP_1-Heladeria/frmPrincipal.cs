using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP_1_Heladeria
{

    public partial class frmPrincipal : Form
    {

        public string[] usuario;
        public BindingList<string[]> usuarios = new BindingList<string[]>();
        int indiceLogeado;
        public frmPrincipal(BindingList<string[]> _usuarios, int _indiceLogeado)
        {
            InitializeComponent();
            usuarios = _usuarios;
            indiceLogeado = _indiceLogeado;
            usuario = usuarios[indiceLogeado];

            lblUsuario.Text = usuario[0];
            if (usuario[6].ToLower() == "administrador")
            {
                btnRegistrarUsuario.Visible = true;
                btnEditarPerfil.Text = "Editar Perfiles";
            }
            else
                btnRegistrarUsuario.Visible = false;
        }


        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Form RegistrarUsuario = new frmRegistrarUsuario(usuarios, indiceLogeado);
            RegistrarUsuario.Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil(usuarios, indiceLogeado);
            frm.Show();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult deseaCerrar = MessageBox.Show("Desea cerrar la aplicacion?", "Cerrar Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (deseaCerrar == DialogResult.Yes) 
                Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form login = new frmLogin(usuarios);
            login.Show();
            this.Close();
        }
    }
}
