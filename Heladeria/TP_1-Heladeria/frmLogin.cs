using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace TP_1_Heladeria
{
    public partial class frmLogin : Form
    {
        private DB_Conexion CN = new DB_Conexion();
        private ValidacionDeCampos Validaciones = new ValidacionDeCampos();

        public frmLogin()
        {
            InitializeComponent();
            imgShow1.Visible = true;
            imgHide1.Visible = false;
            lblError.Visible = false;
        }
        

        //Eventos Botones
        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            try
            {

                TextBox[] txtBoxes = new TextBox[] {txtUsuario, txtContrasenia};
                Validaciones.TextoVacio(txtBoxes);
               

                
                

                //conectar();
                
                CN.Conectar_BD();

                string query = "SELECT * FROM Usuarios WHERE UsuarioCompleto = @UsuarioCompleto AND Pass = @Pass";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@UsuarioCompleto", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@Pass", txtContrasenia.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    //string nombre = reader["Nombre"].ToString();
                    //int primerInicio = Convert.ToInt32(reader["PrimerInicio"]);
                    
                    Usuario usuarioLogeado = new Usuario();

                    usuarioLogeado.id = Convert.ToInt32(reader["IdUsuario"]);
                    usuarioLogeado.Nombre = reader["Nombre"].ToString();
                    usuarioLogeado.Apellido = reader["Apellido"].ToString();
                    usuarioLogeado.DNI = Convert.ToInt32(reader["DNI"]);
                    usuarioLogeado.Telefono = reader["Telefono"].ToString();
                    usuarioLogeado.Email = reader["Email"].ToString(); 
                    usuarioLogeado.Genero = Convert.ToInt32(reader["IdGenero"]);
                    usuarioLogeado.TipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]);
                    usuarioLogeado.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
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
                    usuarioLogeado.UsuarioBase = reader["UsuarioBase"].ToString();
                    usuarioLogeado.Pass = reader["Pass"].ToString();
                    usuarioLogeado.PrimerInicio = Convert.ToBoolean(reader["PrimerInicio"]);
                    usuarioLogeado.UsuarioCompleto = reader["UsuarioCompleto"].ToString();

                    MessageBox.Show($"Inicio de sesión exitoso, {usuarioLogeado.Nombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if(usuarioLogeado.PrimerInicio)
                    {
                        frmCambioContrasena frmCambioContrasenia = new frmCambioContrasena(usuarioLogeado);
                        this.Hide();
                        frmCambioContrasenia.ShowDialog();

                        return;
                    }
                    else
                    {
                        frmPrincipal frmPrincipal = new frmPrincipal(usuarioLogeado);
                        this.Hide();
                        frmPrincipal.Show();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();

            }
            catch (Exception ex){
                MessageBox.Show($"Se ha producido un error: {ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
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
            frmRecuperarContrasena frmRecuperarContrasena = new frmRecuperarContrasena();
            this.Hide();

            frmRecuperarContrasena.ShowDialog();
        }

    
    }
}
