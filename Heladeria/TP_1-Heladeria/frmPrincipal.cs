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
        List<string[]> listaUsuarios = new List<string[]>();

        public frmPrincipal(List<string[]> ListaUsuarios)
        {
            InitializeComponent();
            listaUsuarios = ListaUsuarios;
        }

        private void btnCerraSesion_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin(ListaUsuarios: listaUsuarios);
            frmLogin.Show();
            this.Close();
        }
    }
}
