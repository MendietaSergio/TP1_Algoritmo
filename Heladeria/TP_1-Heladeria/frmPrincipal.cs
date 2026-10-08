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

        //public string[] usuario;
        public BindingList<string[]> usuarios = new BindingList<string[]>();
        int indiceLogeado;
        Usuario usuario = new Usuario();
        public frmPrincipal(Usuario _usuario)
            //public frmPrincipal(Usuario _usuario, int _indiceLogeado)
        {
            InitializeComponent();
            /*
            usuarios = _usuarios;
            indiceLogeado = _indiceLogeado;*/
            usuario = _usuario;

            lblUsuario.Text = usuario.Nombre;
            if (usuario.TipoUsuario == 1)
            {
                btnRegistrarUsuario.Visible = true;
                btnEditarPerfil.Text = "Editar Perfiles";
            }
            else
                btnRegistrarUsuario.Visible = false;
        }


        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Form RegistrarUsuario = new frmRegistrarUsuario(usuario, indiceLogeado);
            RegistrarUsuario.Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil(usuario, indiceLogeado);
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
            Form login = new frmLogin();
            login.Show();
            this.Close();
        }
    }
}
