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
        public List<string[]> usuarios = new List<string[]>();
        public frmRecuperarContrasena(List<string[]> _usuarios, string[] _usuario)
        {
            InitializeComponent();
            usuarios = _usuarios;
            usuario = _usuario;

        }
    }
}
