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
    public partial class frmEditarPerfil : Form
    {
        public frmEditarPerfil()
        {
            InitializeComponent();
            /*
            string[] usuario = {
                    "Gustavo",
                    "Martinez",
                    "12345678",
                    "1234567890",
                    "asd@asd.com",
                    "Masculino",
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
                    "No"
             };

            txtNombre.Text = usuario[0];
            txtApellido.Text = usuario[1];
            txtDNI.Text = usuario[2];
            txtTelefono.Text = usuario[3];
            txtEmail.Text = usuario[4];

            if (usuario[5].ToLower() == "masculino")
                rdbMasculino.Checked = true;
            else
                rdbFemenino.Checked = true;


            cmbTipoUsuario.Text = usuario[6];
            dtpFecNac.Text = usuario[7];
            cmbNacionalidad.Text = usuario[8];
            cmbProvincia.Text = usuario[9];
            cmbPartidoMunicipio.Text = usuario[10];
            cmbLocalidad.Text = usuario[11];
            txtCodPostal.Text = usuario[12];
            txtCalle.Text = usuario[13];
            txtAltura.Text = usuario[14];
            txtPiso.Text = usuario[15];
            txtDepartamento.Text = usuario[16];
            */
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text);
        }
        ///////////////////////////////////////////////////////////////


    }
}
