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
        public frmPrincipal(BindingList<string[]> _usuarios, int indiceUsuario)
        {
            InitializeComponent();
        }
    }
}
