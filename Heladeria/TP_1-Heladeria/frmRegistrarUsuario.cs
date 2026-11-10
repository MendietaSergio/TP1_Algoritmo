using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
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
                txtCodPostal, txtCalle, txtAltura,
                txtPiso, txtDepartamento };
            ComboBox[] cmbCamposParaLimpiar =
                { cmbPartidoMunicipio,
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


            try
            {
                //Cargo el datasource de los paises
                SqlCommand cmd;
                CN.Open();
                SqlDataReader reader;
                string qry;
                {
                    qry = "SELECT Nacionalidad From Nacionalidades;";
                    cmd = new SqlCommand(qry, CN);
                    BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription };

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        paises.Add(reader["Nacionalidad"].ToString());
                    reader.Close();

                    cmbNacionalidad.DataSource = paises;

                }
                //Cargo el datasource de las provincias
                {
                    qry = "SELECT Provincia FROM Provincias";
                    cmd = new SqlCommand(qry, CN);
                    List<string> provincias = new List<string> { cmbProvincia.AccessibleDescription };

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        provincias.Add(reader["Provincia"].ToString());
                    reader.Close();

                    cmbProvincia.DataSource = provincias;
                }
                //Cargo el datasource del tipo de usuarios
                {
                    qry = "SELECT TipoDeUsuario FROM TiposUsuario";
                    cmd = new SqlCommand(qry, CN);
                    List<string> permisos = new List<string> { cmbTipoUsuario.AccessibleDescription };

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        permisos.Add(reader["TipoDeUsuario"].ToString());
                    reader.Close();
                    cmbTipoUsuario.DataSource = permisos;
                }
            }
            catch (Exception ex)
            {
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

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);

            cmbPartidoMunicipio.Enabled = false;
            cmbLocalidad.Enabled = false;


            //Para pruebas
      
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
            if (
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
            string qry = "";
            string CadenaConexion = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0; DataBase=Heladeria";

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
            catch (Exception ex)
            {
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
                qry = "SELECT COUNT(*) FROM Usuarios WHERE UsuarioBase = @UsuarioBase";
                
                CN = new SqlConnection(CadenaConexion);
                SqlCommand cmd = new SqlCommand(qry, CN);

                cmd.Parameters.AddWithValue("@UsuarioBase", nombreUsuarioConstruido);
                CN.Open();

                cantVeces += (int)cmd.ExecuteScalar();
                string usuarioBase = nombreUsuarioConstruido;
                if (cantVeces > 1)
                    nombreUsuarioConstruido = nombreUsuarioConstruido + "_" + cantVeces;

                Random random = new Random();
                long password = random.Next(10000000, 999999999);


                //Verifico el DNI
                qry = "SELECT COUNT(*) FROM Usuarios WHERE DNI = @dni";
                cmd = new SqlCommand(qry, CN);
                cmd.Parameters.AddWithValue("@dni", txtDNI.Text);
                int repetido = (int)cmd.ExecuteScalar();
                if (repetido > 0)
                    throw new Exception("Ese DNI ya fue cargado previamente.");

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
                //Tiene un par de parametros la Qry =D
                //Requeridos
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@dni", txtDNI.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@idGenero", rdbMasculino.Checked == true ? 1 : 2);
                cmd.Parameters.AddWithValue("@idTipoUsuario", cmbTipoUsuario.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@fechaNacimiento", dtpFecNac.Value);
                cmd.Parameters.AddWithValue("@pass", password.ToString());
                cmd.Parameters.AddWithValue("@usuarioBase", usuarioBase);
                cmd.Parameters.AddWithValue("@primerInicio", 1);
                cmd.Parameters.AddWithValue("@usuarioCompleto", nombreUsuarioConstruido);
                //No requeridos
                //Estos tienen la opcion de estar vacios y la base de datos lo reconoceria
                cmd.Parameters.AddWithValue("@idNacionalidad", cmbNacionalidad.SelectedIndex <= 0 ? DBNull.Value : cmbNacionalidad.SelectedIndex);
                cmd.Parameters.AddWithValue("@idProvincia", cmbProvincia.SelectedIndex <= 0 ? DBNull.Value : cmbProvincia.SelectedIndex);
                cmd.Parameters.AddWithValue("@idPartidoMunicipio", cmbPartidoMunicipio.SelectedIndex <= 0 ? DBNull.Value : cmbPartidoMunicipio.SelectedIndex);
                cmd.Parameters.AddWithValue("@idLocalidad", cmbLocalidad.SelectedIndex <= 0 ? DBNull.Value : cmbLocalidad.SelectedIndex);
                cmd.Parameters.AddWithValue("@CodigoPostal", string.IsNullOrEmpty(txtCodPostal.Text) ? DBNull.Value : txtCodPostal.Text);
                cmd.Parameters.AddWithValue("@Calle", string.IsNullOrEmpty(txtCalle.Text) ? DBNull.Value : txtCalle.Text);
                cmd.Parameters.AddWithValue("@Altura", string.IsNullOrEmpty(txtAltura.Text) ? DBNull.Value : txtAltura.Text);
                cmd.Parameters.AddWithValue("@Piso", string.IsNullOrEmpty(txtPiso.Text) ? DBNull.Value : txtPiso.Text);
                cmd.Parameters.AddWithValue("@Departamento", string.IsNullOrEmpty(txtDepartamento.Text) ? DBNull.Value : txtDepartamento.Text);


                cmd.ExecuteNonQuery();

                MessageBox.Show($"Usuario registrado con exito.\nUsuario: {nombreUsuarioConstruido}\nContraseña: {password.ToString()}");
                Limpiar();

            }
            catch (Exception ex)
            {
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

        }
        private bool volviendo = false;

        private void btnVolver_Click(object sender, EventArgs e)
        {
            volviendo = true;
            frmPrincipal principal = new frmPrincipal(usuario);
            principal.Show();
            this.Hide();
        }



        //Eventos ComboBox
        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (
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

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedValue != null && (cmbProvincia.SelectedIndex > 0))
            {
                try
                {
                    string CadenaConexion = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0; DataBase=Heladeria";
                    CN = new SqlConnection(CadenaConexion);
                    SqlCommand cmd;
                    CN.Open();
                    SqlDataReader reader;
                    string qry;
                    {
                        qry = @"SELECT PartidoMunicipio From Municipios M 
                                INNER JOIN Provincias P 
                                ON M.IdProvincia = P.IdProvincia
                                WHERE P.Provincia = @provincia;";
                        cmd = new SqlCommand(qry, CN);
                        cmd.Parameters.AddWithValue("@provincia", cmbProvincia.SelectedValue.ToString());
                        BindingList<string> municipios = new BindingList<string> { cmbPartidoMunicipio.AccessibleDescription };

                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                            municipios.Add(reader["PartidoMunicipio"].ToString());
                        reader.Close();

                        cmbPartidoMunicipio.Enabled = true;
                        cmbPartidoMunicipio.DataSource = municipios;

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar la DB \n{ex.Message}", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPartidoMunicipio.Enabled = false;
                    cmbPartidoMunicipio.DataSource = null;
                }
                finally
                {
                    if (CN.State == System.Data.ConnectionState.Open)
                    {
                        CN.Close();
                        CN.Dispose();
                    }
                }
            }


        }
        private void cmbPartidoMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartidoMunicipio.SelectedValue != null && (cmbPartidoMunicipio.SelectedIndex > 0))
            {
                try
                {
                    string CadenaConexion = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0; DataBase=Heladeria";
                    CN = new SqlConnection(CadenaConexion);
                    SqlCommand cmd;
                    CN.Open();
                    SqlDataReader reader;
                    string qry;
                    {
                        qry = @"SELECT Localidad From Localidades L 
                                INNER JOIN Municipios M 
                                ON L.IdPartidoMunicipio = M.IdPartidoMunicipio
                                WHERE M.PartidoMunicipio= @Muni;";
                        cmd = new SqlCommand(qry, CN);
                        cmd.Parameters.AddWithValue("@Muni", cmbPartidoMunicipio.SelectedValue.ToString());
                        BindingList<string> localidades = new BindingList<string> { cmbLocalidad.AccessibleDescription };

                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                            localidades.Add(reader["Localidad"].ToString());
                        reader.Close();

                        cmbLocalidad.Enabled = true;
                        cmbLocalidad.DataSource = localidades;

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar la DB \n{ex.Message}", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbLocalidad.Enabled = false;
                    cmbLocalidad.DataSource = null;
                }
                finally
                {
                    if (CN.State == System.Data.ConnectionState.Open)
                    {
                        CN.Close();
                        CN.Dispose();
                    }
                }
            }
        }

        // Al cerrar el formulario
        private void frmRegistrarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!volviendo && e.CloseReason == CloseReason.UserClosing)
            {
                volviendo = true;
                frmPrincipal principal = new frmPrincipal(usuario);
                principal.Show();
            }
        }
    }
}
