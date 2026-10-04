using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace TP_1_Heladeria
{
    public partial class frmLogin : Form
    {
        Usuario usuario = new Usuario();
        public int indiceUsuario;
        public BindingList<string[]> usuarios = new BindingList<string[]>();
        string CadenaConexionAccess = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0; DataBase=Heladeria";
        SqlConnection CN; 

        void conectar()
        {
            try
            {
                CN = new SqlConnection(CadenaConexionAccess);
                CN.Open();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar la DB > " + ex.Message);
            }
        }

        
        

        
        
            

        
        public frmLogin(BindingList<string[]> _usuarios)
        {
            InitializeComponent();
            imgShow1.Visible = true;
            imgHide1.Visible = false;
            lblError.Visible = false;
            usuarios = _usuarios;

        }

        //Eventos Botones
        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            try{

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


                conectar();
                string query = "SELECT * FROM Usuarios WHERE UsuarioCompleto = @UsuarioCompleto AND Pass = @Pass";

                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@UsuarioCompleto", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@Pass", txtContrasenia.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    //string nombre = reader["Nombre"].ToString();
                    //int primerInicio = Convert.ToInt32(reader["PrimerInicio"]);
                    
                  ///  Usuario usuario = new Usuario();

                    usuario.id = Convert.ToInt32(reader["IdUsuario"]);
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Apellido = reader["Apellido"].ToString();
                    usuario.DNI = Convert.ToInt32(reader["DNI"]);
                    usuario.Telefono = reader["Telefono"].ToString();
                    usuario.Email = reader["Email"].ToString(); 
                    usuario.Genero = Convert.ToInt32(reader["IdGenero"]);
                    usuario.TipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]);
                    usuario.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    /* 
                        --- Voy a obviar los datos que sean opcionales ---
                    usuario.Nacionalidad = Convert.ToInt32(reader["IdNacionalidad"]);
                    usuario.Provincia = Convert.ToInt32(reader["IdProvincia"]);
                    usuario.Municipio = Convert.ToInt32(reader["IdPartidoMunicipio"]);
                    usuario.Localidad= Convert.ToInt32(reader["IdLocalidad"]);
                    usuario.CodigoPostal = reader["CodigoPostal"].ToString();
                    usuario.Calle = reader["Calle"].ToString();
                    usuario.Altura = Convert.ToInt32(reader["Altura"]);
                    usuario.Piso = Convert.ToInt32(reader["Piso"]);
                    usuario.Departamento = reader["Departamento"].ToString();
                    */
                    usuario.UsuarioBase = reader["UsuarioBase"].ToString();
                    usuario.Pass = reader["Pass"].ToString();
                    usuario.PrimerInicio = reader["PrimerInicio"].ToString() == "1"? true : false;
                    usuario.UsuarioCompleto = reader["UsuarioCompleto"].ToString();

                    MessageBox.Show($"Inicio de sesión exitoso, {usuario.Nombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

                reader.Close();

            }
            catch (Exception ex){
                lblError.Visible = true;
                lblError.Text = "Error: los datos son incorrectos.";
                txtUsuario.Focus();
                MessageBox.Show($"Se ha producido un error: {ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                CN.Close();
                CN.Dispose();
            }
            if(usuario != null)
            {
                if (usuario.PrimerInicio)
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
        private void btnSalir_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        //Eventos Imagenes
        private void imgHide1_Click(object sender, EventArgs e)
        {
            txtContrasenia.PasswordChar = '\0';
            imgShow1.Visible = false;
            imgHide1.Visible = true;
        }
        private void imgShow1_Click(object sender, EventArgs e)
        {
            txtContrasenia.PasswordChar = '*';
            imgShow1.Visible = true;
            imgHide1.Visible = false;
        }

        //Eventos LinkdLbl
        private void linkOldPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContrasena frmRecuperarContrasena = new frmRecuperarContrasena(usuarios);
            this.Hide();

            frmRecuperarContrasena.ShowDialog();
        }

    
    }
}
