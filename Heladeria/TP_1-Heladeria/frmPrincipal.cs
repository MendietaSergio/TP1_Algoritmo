using System.ComponentModel;

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
            usuario = _usuarios[indiceLogeado];

            lblUsuario.Text = usuario[0];
            if (usuario[6].ToLower() == "administrador")
                btnRegistrarUsuario.Visible = true;
            else
                btnRegistrarUsuario.Visible = false;
        }


        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Form RegistrarUsuario = new frmRegistrarUsuario(usuarios, indiceLogeado);
            RegistrarUsuario.Show();
            this.Hide();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form login = new frmLogin(usuarios);
            login.Show();
            this.Hide();
        }
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil(usuarios, indiceLogeado);
            frm.Show();
            this.Hide();
        }
    }
}
