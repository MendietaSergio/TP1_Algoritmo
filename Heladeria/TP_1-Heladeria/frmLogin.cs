namespace TP_1_Heladeria
{
    public partial class frmLogin : Form
    {

        string[] usuario;
        List<string[]> usuarios;

        public frmLogin(List<string[]> _usuarios)
        {
            InitializeComponent();
            usuario = _usuarios[0];
            usuarios = _usuarios;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPrincipal prin = new frmPrincipal(usuarios, usuario);
            prin.Show();
            this.Hide();
        }
    }
}
