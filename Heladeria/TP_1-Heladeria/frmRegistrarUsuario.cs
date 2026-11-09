using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using TP_1_Heladeria;
using System.Dynamic;
using Microsoft.Data.SqlClient;

namespace TP_1_Heladeria
{
    public partial class frmRegistrarUsuario : Form
    {

        ValidacionDeCampos validacion = new ValidacionDeCampos();

        SqlConnection CN;
        public void Limpiar()
        {
            TextBox[] txtCampos =
                { txtNombre, txtApellido, txtDNI,
                txtTelefono, txtEmail,
                txtCodPostal, txtCalle,txtAltura,
                txtPiso,txtPiso,txtDepartamento };
            ComboBox[] cmbCamposParaLimpiar =
                { cmbProvincia, cmbPartidoMunicipio,
                 cmbLocalidad };


            foreach (TextBox campo in txtCampos) campo.Text = "";
            foreach (ComboBox campo in cmbCamposParaLimpiar) campo.DataSource = null;
            cmbNacionalidad.SelectedIndex = 0;
            cmbTipoUsuario.SelectedIndex = 0;


            rdbMasculino.Checked = true;
            txtNombre.Focus();
        }

        Usuario usuario = new Usuario();
        

        public frmRegistrarUsuario(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;

            string CadenaConexion = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0; DataBase=Heladeria";
            CN = new SqlConnection(CadenaConexion);

            //Estoy por aca
            try {
                SqlDataAdapter adapter = new SqlDataAdapter();
               
            }
            catch (Exception ex) {
                MessageBox.Show($"Error al conectar la DB \n{ex.Message}", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally 
            {
                if (CN.State == System.Data.ConnectionState.Open)
                {
                    CN.Close();
                    CN.Dispose();
                }
            }

            string[] permisos = { cmbTipoUsuario.AccessibleDescription, "Administrador", "General" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };


            cmbNacionalidad.DataSource = paises;
            cmbTipoUsuario.DataSource = permisos;

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);

            cmbProvincia.Enabled = false;
            cmbPartidoMunicipio.Enabled = false;
            cmbLocalidad.Enabled = false;


            //PARA LAS PRUEBAS!!
            //SACAR
            txtNombre.Text = "asd";
            txtApellido.Text = "asd";
            txtDNI.Text = "12312312";
            txtTelefono.Text = "1231231231";
            txtEmail.Text = "asd@asd.asd";
            cmbTipoUsuario.SelectedIndex = 1;

        }


        //Eventos de los txt
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }


        //Eventos Botones
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validaciones
            ////Requeridas ////
            try
            {
                
                validacion.TextoVacio([txtNombre, txtApellido, txtDNI, txtTelefono, txtEmail]);
                validacion.TipoEnteroPositivo([txtTelefono, txtDNI]);
                validacion.NroEnteroEntre(txtTelefono, 1000000000, 9999999999);
                validacion.NroEnteroEntre(txtDNI, 3000000, 99999999);
                validacion.EMail(txtEmail);
            }
            catch (Exception ex) {
                MessageBox.Show($"Error - {ex.Message}", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //No Requeridas
            //////////////////////////////
            TextBox[] txtCamposOpcionales = [txtCodPostal, txtPiso, txtAltura];
            int[] longitudes = [0, 8, 0, 2, 0, int.MaxValue];
                
            foreach (TextBox campo in txtCamposOpcionales)
            {
                try
                {
                    //Primera Longitud Correspondiente
                    int pLongitudC = txtCamposOpcionales.IndexOf(campo) * 2;
                    validacion.LongitudTexto(campo, longitudes[pLongitudC], longitudes[pLongitudC + 1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error - {ex.Message}\n\nEste campo es opcional, por lo que podria simplemente borrarlo", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            try
            {
                if (!(string.IsNullOrEmpty(txtAltura.Text)))
                    validacion.TipoEnteroPositivo([txtAltura]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error - {ex.Message}\n\nEste campo es opcional, por lo que podria simplemente borrarlo", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            try
            {
                //Preparo el nombre de usuario
                string inicial = "";
                string apellido = "";
                string nros = "";
                string nombreUsuarioConstruido = "";
                inicial = txtNombre.Text.Substring(0, 1).ToLower();
                apellido = txtApellido.Text.ToLower();
                nros = txtDNI.Text.Substring(txtDNI.Text.Length - 3, 3);

                nombreUsuarioConstruido = inicial + apellido + nros;

                int cantVeces = 1;
                string qry = "SELECT COUNT(*) FROM Usuarios WHERE UsuarioBase = @UsuarioBase";

                SqlCommand cmd = new SqlCommand(qry, CN);

                cmd.Parameters.AddWithValue("@UsuarioBase", nombreUsuarioConstruido);
                CN.Open();

                cantVeces += (int)cmd.ExecuteScalar();
                string usuarioBase = nombreUsuarioConstruido;
                if (cantVeces > 1)
                    nombreUsuarioConstruido = nombreUsuarioConstruido + "_" + cantVeces;

                Random random = new Random();
                long password = random.Next(10000000, 999999999);
               
              //Cargo los datos
                qry =
                    @"INSERT INTO usuarios 
                    (nombre, apellido, dni, telefono, email, idGenero, idTipoUsuario, fechaNacimiento,
                     idNacionalidad, idProvincia, idPartidoMunicipio, idLocalidad, CodigoPostal, Calle, Altura, Piso, Departamento,
                     pass, usuarioBase, primerInicio, usuarioCompleto
                     ) 
                    VALUES 
                    (@nombre, @apellido, @dni, @telefono, @email, @idGenero, @idTipoUsuario, @fechaNacimiento,
                     @idNacionalidad, @idProvincia, @idPartidoMunicipio, @idLocalidad, @CodigoPostal, @Calle, @Altura, @Piso, @Departamento,
                     @pass, @usuarioBase, @primerInicio, @usuarioCompleto)";
                cmd = new SqlCommand(qry, CN);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@dni", txtDNI.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@idGenero", rdbMasculino.Checked == true? 1 : 2 );
                cmd.Parameters.AddWithValue("@idTipoUsuario", cmbTipoUsuario.SelectedIndex+1);
                cmd.Parameters.AddWithValue("@fechaNacimiento", dtpFecNac.Value);
                cmd.Parameters.AddWithValue("@pass", password.ToString());
                cmd.Parameters.AddWithValue("@usuarioBase", usuarioBase);
                cmd.Parameters.AddWithValue("@primerInicio", 1);
                cmd.Parameters.AddWithValue("@usuarioCompleto", nombreUsuarioConstruido);

                cmd.Parameters.AddWithValue("@idNacionalidad", cmbNacionalidad.SelectedIndex <= 0? DBNull.Value : cmbNacionalidad.SelectedIndex);
                cmd.Parameters.AddWithValue("@idProvincia", cmbProvincia.SelectedIndex <= 0 ? DBNull.Value : cmbProvincia.SelectedIndex);
                cmd.Parameters.AddWithValue("@idPartidoMunicipio", cmbPartidoMunicipio.SelectedIndex <= 0 ? DBNull.Value : cmbPartidoMunicipio.SelectedIndex);
                cmd.Parameters.AddWithValue("@idLocalidad", cmbLocalidad.SelectedIndex <= 0 ? DBNull.Value : cmbLocalidad.SelectedIndex);
                cmd.Parameters.AddWithValue("@CodigoPostal", string.IsNullOrEmpty(txtCodPostal.Text)? DBNull.Value : txtCodPostal.Text );
                cmd.Parameters.AddWithValue("@Calle", string.IsNullOrEmpty(txtCalle.Text)? DBNull.Value : txtCalle.Text);
                cmd.Parameters.AddWithValue("@Altura", string.IsNullOrEmpty(txtAltura.Text)? DBNull.Value : txtAltura.Text);
                cmd.Parameters.AddWithValue("@Piso", string.IsNullOrEmpty(txtPiso.Text) ? DBNull.Value : txtPiso.Text);
                cmd.Parameters.AddWithValue("@Departamento", string.IsNullOrEmpty(txtDepartamento.Text) ? DBNull.Value : txtDepartamento.Text);



                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario registrado con exito. La contraseña es " + password.ToString());
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar la DB \n{ex.Message}", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if(CN.State == System.Data.ConnectionState.Open)
                {
                    CN.Close();
                    CN.Dispose();
                }
            }
            
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form principal = new frmPrincipal(usuario);
            principal.Show();
            this.Close();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult deseaCerrar = MessageBox.Show("Desea cerrar la aplicacion?", "Cerrar Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (deseaCerrar == DialogResult.Yes)
                Application.Exit();
        }



        //Eventos ComboBox
        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text)&&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            BindingList<string> provincias = new BindingList<string> { cmbProvincia.AccessibleDescription };


            if (cmbNacionalidad.SelectedValue != null && cmbNacionalidad.SelectedIndex != -1)
            {
                cmbProvincia.Enabled = true;
                cmbProvincia.DataSource = provincias;
                if (cmbNacionalidad.SelectedValue.ToString().ToLower() == "argentina")
                {
                    provincias.Add("Buenos Aires");
                    provincias.Add("Cordoba");
                }
                else if (cmbNacionalidad.SelectedValue.ToString().ToLower() == "uruguay")
                {
                    provincias.Add("Montevideo");
                    provincias.Add("Canelones");
                }
                else
                {
                    cmbProvincia.DataSource = null;
                    cmbProvincia.Enabled = false;
                }

            }*/

            //No estaba relacionado con nada, pero tenia que dar 2 opciones que trae de la DB

        }
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<string> municipio = new BindingList<string> { cmbPartidoMunicipio.AccessibleDescription };

            if (cmbProvincia.SelectedValue != null && cmbProvincia.SelectedIndex != -1)
            {

                cmbPartidoMunicipio.Enabled = true;
                cmbPartidoMunicipio.DataSource = municipio;
                if (cmbProvincia.SelectedValue.ToString().ToLower() == "buenos aires")
                {
                    municipio.Add("Lomas de Zamora");
                    municipio.Add("Lanus");
                }
                else if (cmbProvincia.SelectedValue.ToString().ToLower() == "cordoba")
                {
                    municipio.Add("Villa Carlos Paz");
                    municipio.Add("Cosquin");
                }
                else if (cmbProvincia.SelectedValue.ToString().ToLower() == "montevideo")
                {
                    municipio.Add("B");
                    municipio.Add("CH");
                }
                else if (cmbProvincia.SelectedValue.ToString().ToLower() == "canelones")
                {
                    municipio.Add("18 de Mayo");
                    municipio.Add("Aguas Corrientes");
                }
                else
                {
                    cmbPartidoMunicipio.DataSource = null;
                    cmbPartidoMunicipio.Enabled = false;
                }
            }

        }
        private void cmbPartidoMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindingList<string> localidad = new BindingList<string> { cmbLocalidad.AccessibleDescription };


            if (cmbPartidoMunicipio.SelectedValue != null && cmbPartidoMunicipio.SelectedIndex != -1)
            {

                cmbLocalidad.Enabled = true;
                cmbLocalidad.DataSource = localidad;
                if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "lomas de zamora")
                {
                    localidad.Add("Lomas de Zamora");
                    localidad.Add("Temperley");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "villa carlos paz")
                {
                    localidad.Add("Villa Domingues");
                    localidad.Add("La Quinta");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "lanus")
                {
                    localidad.Add("Lanus");
                    localidad.Add("Valentin Alsina");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "cosquin")
                {
                    localidad.Add("Casa Grande");
                    localidad.Add("Villa Hermoso");

                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "b")
                {
                    localidad.Add("Ciudad Vieja");
                    localidad.Add("Centro");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "ch")
                {
                    localidad.Add("Pocitos");
                    localidad.Add("Punta Carretas");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "18 de mayo")
                {
                    localidad.Add("El Dorado");
                    localidad.Add("Villa Alegria");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "aguas corrientes")
                {
                    localidad.Add("-");
                    localidad.Add("-");
                }
                else
                {
                    cmbLocalidad.DataSource = null;
                    cmbLocalidad.Enabled = false;
                }

            }
        }

       
    }
}
