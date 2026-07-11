using System.ComponentModel;

namespace TP_1_Heladeria
{
    public partial class frmLogin : Form
    {
        public int indiceUsuario;
        public BindingList<string[]> usuarios = new BindingList<string[]>();


        public frmLogin(BindingList<string[]> _usuarios)
        {
            InitializeComponent();
            imgHide1.Visible = true;
            imgShow1.Visible = false;
            lblError.Visible = false;
            usuarios = _usuarios;

        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (txtUsuario.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Error: Campo vacio, revisalos.";
                txtUsuario.Focus();
                return;
            }
            if (txtContrasenia.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Error: Campo vacio, revisalos.";
                txtContrasenia.Focus();
                return;
            }
            // recorremos la lista para poder validar si los datos ingresados corresponde a un usuario registrado.
            while (true)
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (txtUsuario.Text == usuarios[i][17] && txtContrasenia.Text == usuarios[i][18])
                    {
                        indiceUsuario = i;

                        // si encuentra una coincidencia, deberia abrir el formulario principal de la app
                        // y cerrar el formulario de login
                        if (usuarios[i][19].ToLower() == "si")
                        {
                            frmCambioContrasena frmCambioContrasenia = new frmCambioContrasena(usuarios, indiceUsuario);
                            this.Hide();
                            frmCambioContrasenia.ShowDialog();

                            return;
                        }
                        else
                        {
                            frmPrincipal frmPrincipal = new frmPrincipal(usuarios, indiceUsuario);
                            this.Hide();
                            frmPrincipal.Show();
                            return;
                        }
                    }
                }
                lblError.Visible = true;
                lblError.Text = "Error: los datos son incorrectos.";
                txtUsuario.Focus();
                break;
            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void imgHide1_Click(object sender, EventArgs e)
        {
            txtContrasenia.PasswordChar = '\0';
            imgHide1.Visible = false;
            imgShow1.Visible = true;
        }

        private void imgShow1_Click(object sender, EventArgs e)
        {
            txtContrasenia.PasswordChar = '*';
            imgHide1.Visible = true;
            imgShow1.Visible = false;
        }

        private void linkOldPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContrasena frmRecuperarContrasena = new frmRecuperarContrasena(usuarios);
            this.Hide();
            frmRecuperarContrasena.ShowDialog();
            //aca va lo del cambio de contraseña
        }
    }
}