using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP_1_Heladeria
{
    public partial class frmRecuperarContrasena : Form
    {
        public string[] usuario;
        public BindingList<string[]> usuarios = new BindingList<string[]>();
        public frmRecuperarContrasena(BindingList<string[]> _usuarios, string[] _usuario)
        {
            InitializeComponent();
            usuarios = _usuarios;
            usuario = _usuario;

        }
    }
}
