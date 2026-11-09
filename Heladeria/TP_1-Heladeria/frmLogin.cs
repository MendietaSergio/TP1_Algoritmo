using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace TP_1_Heladeria
{
    public partial class frmLogin : Form
    {
       
        public int indiceUsuario;

        DB_Conexion CN = new DB_Conexion();
        ValidacionDeCampos Validaciones = new ValidacionDeCampos();

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
            Usuario usuarioLogeado = new Usuario();
            //Como no se a que formulario voy a necesitar llamar, por el momento voy a crear un formulario generico.
            //Mas adelante, cuando determine si es la primera vez que ingresa o no, le voy a asignar un tipo
            Form proximoFormulario = null;
            try
            {

                TextBox[] txtBoxes = new TextBox[] {txtUsuario, txtContrasenia};
                Validaciones.TextoVacio(txtBoxes);
               
                CN.Conectar_BD();

                string query = "SELECT * FROM Usuarios WHERE UsuarioCompleto = @UsuarioCompleto AND Pass = @Pass";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@UsuarioCompleto", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@Pass", txtContrasenia.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    //Requeridos
                    usuarioLogeado.id = Convert.ToInt32(reader["IdUsuario"]);
                    usuarioLogeado.Nombre = reader["Nombre"].ToString();
                    usuarioLogeado.Apellido = reader["Apellido"].ToString();
                    usuarioLogeado.DNI = Convert.ToInt32(reader["DNI"]);
                    usuarioLogeado.Telefono = reader["Telefono"].ToString();
                    usuarioLogeado.Email = reader["Email"].ToString(); 
                    usuarioLogeado.Genero = Convert.ToInt32(reader["IdGenero"]);
                    usuarioLogeado.TipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]);
                    usuarioLogeado.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);

                    //No Requeridos
                    usuarioLogeado.Nacionalidad = reader["IdNacionalidad"] != DBNull.Value? Convert.ToInt32(reader["IdNacionalidad"]) : 0;
                    usuarioLogeado.Provincia = reader["IdProvincia"] != DBNull.Value ? Convert.ToInt32(reader["IdProvincia"]) : 0;
                    usuarioLogeado.Municipio = reader["IdPartidoMunicipio"] != DBNull.Value ? Convert.ToInt32(reader["IdPartidoMunicipio"]) : 0;
                    usuarioLogeado.Localidad= reader["IdLocalidad"] != DBNull.Value ? Convert.ToInt32(reader["IdLocalidad"]) :0;
                    usuarioLogeado.CodigoPostal = reader["CodigoPostal"] != DBNull.Value ? reader["CodigoPostal"].ToString() : string.Empty;
                    usuarioLogeado.Calle = reader["Calle"] != DBNull.Value ? reader["Calle"].ToString() : string.Empty;
                    usuarioLogeado.Altura = reader["Altura"] != DBNull.Value ? Convert.ToInt32(reader["Altura"]) : 0;
                    usuarioLogeado.Piso = reader["Piso"] != DBNull.Value ? Convert.ToInt32(reader["Piso"]) : 0;
                    usuarioLogeado.Departamento = reader["Departamento"] != DBNull.Value ? reader["Departamento"].ToString() : string.Empty;
                    
                    usuarioLogeado.UsuarioBase = reader["UsuarioBase"].ToString();
                    usuarioLogeado.Pass = reader["Pass"].ToString();
                    usuarioLogeado.PrimerInicio = Convert.ToBoolean(reader["PrimerInicio"]);
                    usuarioLogeado.UsuarioCompleto = reader["UsuarioCompleto"].ToString();

                    MessageBox.Show($"Inicio de sesión exitoso, {usuarioLogeado.Nombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if(usuarioLogeado.PrimerInicio)
                        proximoFormulario = new frmCambioContrasena(usuarioLogeado);
                    else
                        proximoFormulario = new frmPrincipal(usuarioLogeado);


                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();

            }
            catch (Exception ex){
                MessageBox.Show($"Se ha producido un error al conectar con la DB\n{ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally{
                if (CN.MostrarConexion().State == System.Data.ConnectionState.Open)
                    CN.Desconectar();
            }

            //si tiro error, el formulario puede quedar null. En ese caso no deberia abrir nada
            if(proximoFormulario != null)
            {
                this.Hide();
                proximoFormulario.Show();
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
