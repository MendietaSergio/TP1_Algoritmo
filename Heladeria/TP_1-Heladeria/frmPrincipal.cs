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
        public frmPrincipal()
        {
            InitializeComponent();
            //string[] args = Environment.GetCommandLineArgs();
            string[] usuario =
                {
                    "Gustavo",
                    "Martinez",
                    "12345678",
                    "1234567890",
                    "gus@mar.tinez",
                    "Masculino",
                    //"Usuario",
                    "Administrador",
                    "6/12/1990",
                    "argentina",
                    "buenos aires",
                    "lomas de zamora",
                    "lomas de zamora",
                    "1934",
                    "Calle falsa",
                    "123",
                    "",
                    "",
                    "gmartinez678",
                    "123456",
                    "No"  };
            lblUsuario.Text = usuario[0];
            if (usuario[6].ToLower() == "administrador")
                btnRegistrarUsuario.Visible = true;
            else
                btnRegistrarUsuario.Visible = false;
        }


        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Form RegistrarUsuario = new frmRegistrarUsuario();
            RegistrarUsuario.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Aca quiero volver el usuario a vacio
            Form login = new frmLogin();
            login.Show();
            //Eventualmente, cambiar a close
            this.Hide();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            //Aca tengo que ver como pasarle los datos al proximo formulario
            Form EditarPerfil = new frmEditarPerfil();
            EditarPerfil.Show();
            this.Hide();
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            //Aca tengo que ver como pasarle los datos al proximo formulario
            Form cambiarContrasena = new frmCambioContrasena();
            cambiarContrasena.Show();
            this.Hide();
        }
    }
}
