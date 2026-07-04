namespace TP_1_Heladeria
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCambioContrasena frmCambioContrasenia = new frmCambioContrasena();

            frmCambioContrasenia.ShowDialog();
        }
    }
}
