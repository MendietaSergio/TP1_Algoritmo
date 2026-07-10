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
       
        public int indiceUsuario;
        public List<string[]> usuarios = new List<string[]>();
        public frmPrincipal(List<string[]> _usuarios, int indiceUsuario)
        {
            InitializeComponent();
            usuarios = _usuarios;

            lblUsuario.Text = usuarios[indiceUsuario][0];
            if (usuarios[indiceUsuario][6].ToLower() == "administrador")
                btnRegistrarUsuario.Visible = true;
            else
                btnRegistrarUsuario.Visible = false;
        }


        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            //Sacarle a Registra el usuario. No se para que necesitaria eso
            Form RegistrarUsuario = new frmRegistrarUsuario(usuarios);
            RegistrarUsuario.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Aca quiero volver el usuario a vacio
            Form login = new frmLogin(usuarios);
            login.Show();
            //Eventualmente, cambiar a close
            this.Hide();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            //Aca tengo que ver como pasarle los datos al proximo formulario
            frmEditarPerfil frm = new frmEditarPerfil(usuarios, indiceUsuario);
            frm.Show();
            this.Hide();
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            //Aca tengo que ver como pasarle los datos al proximo formulario
            Form cambiarContrasena = new frmCambioContrasena(usuarios, indiceUsuario);
            cambiarContrasena.Show();
            this.Hide();
        }
    }
}
