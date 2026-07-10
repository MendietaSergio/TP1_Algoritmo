namespace TP_1_Heladeria
{
    public partial class frmLogin : Form
    {
        List<string[]> listaUsuarios = new List<string[]>();

        // Constructor sin parámetros (primera vez que inicia la app)
        public frmLogin()
        {
            InitializeComponent();
            imgHide1.Visible = true;
            imgShow1.Visible = false;
            lblError.Visible = false;

            // Inicializar lista con usuarios por defecto
            InicializarUsuarios();
        }

        // Constructor con parámetros (cuando vuelve a loguear desde frmPrincipal)
        public frmLogin(List<string[]> ListaUsuarios)
        {
            InitializeComponent();
            imgHide1.Visible = true;
            imgShow1.Visible = false;
            lblError.Visible = false;

            if (ListaUsuarios != null)
            {
                listaUsuarios = ListaUsuarios;
            }
            else
            {
                InicializarUsuarios();
            }
        }

        // Método para inicializar los usuarios por defecto
        private void InicializarUsuarios()
        {
            listaUsuarios = new List<string[]>();

            // 1. ARRAY: USUARIO ADMINISTRADOR (Completo)
            string[] usuarioAdmin = new string[20];
            usuarioAdmin[0] = "Juan";                         // txtNombre.Text
            usuarioAdmin[1] = "Pérez";                        // txtApellido.Text
            usuarioAdmin[2] = "35123456";                     // txtDNI.Text
            usuarioAdmin[3] = "1123456789";                   // txtTelefono.Text
            usuarioAdmin[4] = "juan.admin@correo.com";        // txtEmail.Text
            usuarioAdmin[5] = "Masculino";                    // Hardcodeado
            usuarioAdmin[6] = "Admin";                        // cmbTipoUsuario.SelectedValue
            usuarioAdmin[7] = "15/05/1990";                   // dtpFecNac.Text
            usuarioAdmin[8] = "Argentina";                    // cmbNacionalidad.SelectedValue
            usuarioAdmin[9] = "Buenos Aires";                 // cmbProvincia.SelectedValue
            usuarioAdmin[10] = "La Matanza";                  // cmbPartidoMunicipio.SelectedValue
            usuarioAdmin[11] = "San Justo";                   // cmbLocalidad (Resultado del operador ternario)
            usuarioAdmin[12] = "1754";                        // txtCodPostal.Text
            usuarioAdmin[13] = "Av. de Mayo";                 // txtCalle.Text
            usuarioAdmin[14] = "1234";                        // txtAltura.Text
            usuarioAdmin[15] = "2";                           // txtPiso.Text
            usuarioAdmin[16] = "B";                           // txtDepartamento.Text
            usuarioAdmin[17] = "jperez_admin";                // nombreUsuarioConstruido
            usuarioAdmin[18] = "AdminSecretPass123";          // password.ToString()
            usuarioAdmin[19] = "si";                          // Primer login

            // 2. ARRAY: USUARIO NORMAL (Con campos vacíos)
            string[] usuarioNormal = new string[20];
            usuarioNormal[0] = "María";                        // txtNombre.Text
            usuarioNormal[1] = "Gómez";                       // txtApellido.Text
            usuarioNormal[2] = "38987654";                    // txtDNI.Text
            usuarioNormal[3] = "1198765432";                  // txtTelefono.Text
            usuarioNormal[4] = "maria.gomez@correo.com";      // txtEmail.Text
            usuarioNormal[5] = "Femenino";                    // Modificado para el ejemplo
            usuarioNormal[6] = "Normal";                      // cmbTipoUsuario.SelectedValue
            usuarioNormal[7] = "22/09/1995";                  // dtpFecNac.Text
            usuarioNormal[8] = "Argentina";                   // cmbNacionalidad.SelectedValue
            usuarioNormal[9] = "CABA";                         // cmbProvincia.SelectedValue
            usuarioNormal[10] = "Comuna 1";                   // cmbPartidoMunicipio.SelectedValue
            usuarioNormal[11] = "";                           // cmbLocalidad (Entró por el else del ternario, queda vacío)
            usuarioNormal[12] = "1001";                       // txtCodPostal.Text
            usuarioNormal[13] = "Belgrano";                   // txtCalle.Text
            usuarioNormal[14] = "550";                        // txtAltura.Text
            usuarioNormal[15] = "";                           // txtPiso.Text (Vacío porque vive en casa)
            usuarioNormal[16] = "";                           // txtDepartamento.Text (Vacío)
            usuarioNormal[17] = "mgomez95";                   // nombreUsuarioConstruido
            usuarioNormal[18] = "UserPass456";                // password.ToString()
            usuarioNormal[19] = "no";                          // Primer login

            // AGREGAR LOS ARRAYS A LA LISTA
            listaUsuarios.Add(usuarioAdmin);
            listaUsuarios.Add(usuarioNormal);
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
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    if (txtUsuario.Text == listaUsuarios[i][17] && txtContrasenia.Text == listaUsuarios[i][18])
                    {
                        // si encuentra una coincidencia, deberia abrir el formulario principal de la app
                        // y cerrar el formulario de login
                        if (listaUsuarios[i][19] == "si")
                        {
                            frmCambioContrasena frmCambioContrasenia = new frmCambioContrasena(ListaUsuarios: listaUsuarios, indiceUsuario: i);
                            this.Hide();
                            frmCambioContrasenia.ShowDialog();
                            
                            return;
                        }
                        else
                        {
                            frmPrincipal frmPrincipal = new frmPrincipal(ListaUsuarios: listaUsuarios);
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
            //aca va lo del cambio de contraseña
        }
    }
}
