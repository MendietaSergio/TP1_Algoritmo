using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace TP_1_Heladeria
{
    public partial class frmEditarPerfil : Form
    {
        DB_Conexion CN = new DB_Conexion();
        ValidacionDeCampos Validaciones = new ValidacionDeCampos();
        // public List<string> listaUsuarios = new List<string>();
        // public BindingList<string[]> listaUsuarios = new BindingList<string[]>();
        //Usuario usuario = new Usuario();

        public string[] usuarioLogeado;
        public string[] usuarioEditando;
        public BindingList<string[]> usuarios = new BindingList<string[]>();
        int indiceLogeado;
        BindingList<string> nombreUsuarios = new BindingList<string>();

        public frmEditarPerfil(BindingList<string[]> _usuarios, int _indiceLogeado)
        {
            InitializeComponent();
            CargarUsuariosBD();
            CargarTipoUsuario();
            CargarNacionalidad();
            CargarProvincias();
            InabilitarTodosLosCampos();
            btnEliminar.Enabled = false;
            indiceLogeado = _indiceLogeado;
            //string[] permisos = { cmbTipoUsuario.AccessibleDescription, "Administrador", "General" };
            //BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };

            //cmbNacionalidad.DataSource = paises;
            //cmbTipoUsuario.DataSource = permisos;

            //{
            //    if (cmbNacionalidad.SelectedValue != null && cmbNacionalidad.SelectedIndex != 0)
            //        cmbProvincia.Enabled = true;
            //    else
            //        cmbProvincia.Enabled = false;

            //    if (cmbProvincia.SelectedValue != null && cmbProvincia.SelectedIndex != 0)
            //        cmbPartidoMunicipio.Enabled = true;
            //    else
            //        cmbPartidoMunicipio.Enabled = false;

            //    if (cmbPartidoMunicipio.SelectedValue != null && cmbPartidoMunicipio.SelectedIndex != 0)
            //        cmbLocalidad.Enabled = true;
            //    else
            //        cmbLocalidad.Enabled = false;
            //}

            //{
            //    if (txtNombre.Text.Length > 0 &&
            //       txtApellido.Text.Length > 0 &&
            //       txtDNI.Text.Length > 0 &&
            //       txtTelefono.Text.Length > 0 &&
            //       txtEmail.Text.Length > 0 &&
            //       (cmbTipoUsuario.SelectedIndex == 1
            //       ||
            //       cmbTipoUsuario.SelectedIndex == 2))
            //    {
            //        btnGuardarCambios.Enabled = true;
            //        grpUbicacion.Enabled = true;

            //    }
            //    else
            //    {
            //        btnGuardarCambios.Enabled = false;
            //        grpUbicacion.Enabled = false;
            //    }

            //}

            //if (usuarioLogeado[6].ToLower() != "administrador")
            //{
            //    cmbTipoUsuario.Enabled = false;
            //    txtDNI.Enabled = false;
            //    cmbUsuarioEditado.Enabled = false;
            //    btnGuardarCambios.Width = 201;
            //    btnEliminar.Enabled = false;
            //    btnEliminar.Visible = false;

            //}

            //dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            //dtpFecNac.MinDate = DateTime.Today.AddYears(-150);

        }

        public void CargarUsuariosBD()
        {
            try
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                // 1. Crear y agregar la opción por defecto ANTES de traer de la BD
                Usuario usuarioDefecto = new Usuario();
                usuarioDefecto.id = 0; // Usamos 0 para identificar que no es válido
                usuarioDefecto.UsuarioCompleto = "Seleccione un usuario";
                listaUsuarios.Add(usuarioDefecto);

                CN.Conectar_BD();
                string query = "SELECT * FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // 2. ¡CLAVE! Crear un objeto nuevo en CADA vuelta del bucle
                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["IdUsuario"]);
                    usuario.UsuarioCompleto = reader["UsuarioCompleto"].ToString();

                    // Guardar el objeto en la lista
                    listaUsuarios.Add(usuario);
                }
                reader.Close(); // Cerrar el lector al terminar

                // 3. Cargar la lista en el ComboBox
                cmbUsuarioEditado.DataSource = listaUsuarios;
                cmbUsuarioEditado.DisplayMember = "UsuarioCompleto";
                cmbUsuarioEditado.ValueMember = "id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
            }
        }
        public void CargarTipoUsuario()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuarios = new List<TipoUsuario>();
                // 1. Crear y agregar la opción por defecto
                TipoUsuario tipoDefecto = new TipoUsuario();
                tipoDefecto.IdTipoUsuario = 0;
                tipoDefecto.TipoDeUsuario = "Seleccione un tipo de usuario";
                listaTipoUsuarios.Add(tipoDefecto);

                CN.Conectar_BD();
                string query = "SELECT * FROM TiposUsuario";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // 2. ¡CLAVE! Crear un objeto nuevo en CADA vuelta del bucle
                    TipoUsuario tipoUsuario = new TipoUsuario();
                    tipoUsuario.IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]);
                    tipoUsuario.TipoDeUsuario = reader["TipoDeUsuario"].ToString();

                    // Guardar el objeto en la lista
                    listaTipoUsuarios.Add(tipoUsuario);
                }
                reader.Close(); // Cerrar el lector al terminar

                // 3. Cargar la lista en el ComboBox
                cmbTipoUsuario.DataSource = listaTipoUsuarios;
                cmbTipoUsuario.DisplayMember = "TipoDeUsuario";
                cmbTipoUsuario.ValueMember = "IdTipoUsuario";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
            }
        }
        public void CargarNacionalidad()
        {
            try
            {
                List<Nacionalidad> listaNacionalidades = new List<Nacionalidad>();
                // 1. Crear y agregar la opción por defecto
                Nacionalidad nacionalidadDefecto = new Nacionalidad();
                nacionalidadDefecto.IdNacionalidad = 0;
                nacionalidadDefecto.nacionalidad = "Seleccione una nacionalidad";
                listaNacionalidades.Add(nacionalidadDefecto);

                CN.Conectar_BD();
                string query = "SELECT * FROM Nacionalidades";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // 2. ¡CLAVE! Crear un objeto nuevo en CADA vuelta del bucle
                    Nacionalidad nacionalidad = new Nacionalidad();

                    nacionalidad.IdNacionalidad = Convert.ToInt32(reader["IdNacionalidad"]);
                    nacionalidad.nacionalidad = reader["nacionalidad"].ToString();

                    // Guardar el objeto en la lista
                    listaNacionalidades.Add(nacionalidad);
                }
                reader.Close(); // Cerrar el lector al terminar

                // 3. Cargar la lista en el ComboBox
                cmbNacionalidad.DataSource = listaNacionalidades;
                cmbNacionalidad.DisplayMember = "nacionalidad";
                cmbNacionalidad.ValueMember = "IdNacionalidad";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
            }
        }
        public void CargarProvincias()
        {
            try
            {
                List<Provincia> listaProvincias = new List<Provincia>();
                // 1. Crear y agregar la opción por defecto
                Provincia provinciaDefecto = new Provincia();
                provinciaDefecto.IdProvincia = 0;
                provinciaDefecto.provincia = "Seleccione una provincia";
                listaProvincias.Add(provinciaDefecto);

                CN.Conectar_BD();
                string query = "SELECT * FROM Provincias";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // 2. ¡CLAVE! Crear un objeto nuevo en CADA vuelta del bucle
                    Provincia provincia = new Provincia();

                    provincia.IdProvincia = Convert.ToInt32(reader["IdProvincia"]);
                    provincia.provincia = reader["provincia"].ToString();

                    // Guardar el objeto en la lista
                    listaProvincias.Add(provincia);
                }
                reader.Close(); // Cerrar el lector al terminar

                // 3. Cargar la lista en el ComboBox
                cmbProvincia.DataSource = listaProvincias;
                cmbProvincia.DisplayMember = "provincia";
                cmbProvincia.ValueMember = "IdProvincia";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
            }
        }

        //Eventos Combo
        private void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<string> provincias = new BindingList<string> { cmbProvincia.AccessibleDescription };

            //ESTO ANTES INABILITABA EL COMBO DE PROVINCIAS, AHORA NO, PERO NO SE SI ESTA BIEN
            //if (cmbNacionalidad.SelectedValue != null && cmbNacionalidad.SelectedIndex != -1)
            //{
            //    cmbProvincia.Enabled = true;
            //    cmbProvincia.DataSource = provincias;
            //    if (cmbNacionalidad.SelectedValue.ToString().ToLower() == "argentina")
            //    {
            //        provincias.Add("Buenos Aires");
            //        provincias.Add("Cordoba");
            //    }
            //    else if (cmbNacionalidad.SelectedValue.ToString().ToLower() == "uruguay")
            //    {
            //        provincias.Add("Montevideo");
            //        provincias.Add("Canelones");
            //    }
            //    else
            //    {
            //        cmbProvincia.DataSource = null;
            //        cmbProvincia.Enabled = false;
            //    }

            //}
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
        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void cmbUsuarioEditado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validamos que SelectedValue no sea nulo, sea un entero y sea mayor a 0 (nuestro "Seleccione un usuario")
            if (cmbUsuarioEditado.SelectedValue != null && cmbUsuarioEditado.SelectedValue is int idSeleccionado && idSeleccionado > 0)
            {
                try
                {
                    HabilitarTodosLosCampos();
                    btnEliminar.Enabled = true;
                    CN.Conectar_BD();
                    string query = "SELECT * FROM Usuarios WHERE idUsuario=@idUsuario;";
                    SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(cmbUsuarioEditado.SelectedValue));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtApellido.Text = reader["Apellido"].ToString();
                        txtDNI.Text = (reader["DNI"].ToString());
                        txtTelefono.Text = reader["Telefono"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        if (Convert.ToInt32(reader["IdGenero"]) == 2)
                        {
                            rdbMasculino.Checked = true;
                        }
                        else
                        {
                            rdbFemenino.Checked = true;
                        }
                        cmbTipoUsuario.Enabled = true;

                        // Le pasamos al SelectedValue el ID que vino de la base de datos y se mechea solo
                        //DBNull.Value es para evitar errores si el valor es nulo en la base de datos
                        if (reader["IdTipoUsuario"] != DBNull.Value)
                        {
                            cmbTipoUsuario.SelectedValue = Convert.ToInt32(reader["IdTipoUsuario"]);
                        }
                        else
                        {
                            cmbTipoUsuario.SelectedIndex = 0; // Selecciona la opción por defecto si es nulo
                        }
                        dtpFecNac.Text = (reader["FechaNacimiento"].ToString());
                        //no quiero cargar todo u,u


                        //    cmbNacionalidad.Text = usuarioEditando[8];
                        if (reader["IdNacionalidad"] != DBNull.Value)
                        {
                            cmbNacionalidad.SelectedValue = Convert.ToInt32(reader["IdNacionalidad"]);
                        }
                        else
                        {
                            cmbNacionalidad.SelectedIndex = 0; // Selecciona la opción por defecto si es nulo
                        }
                        //    cmbProvincia.Text = usuarioEditando[9];
                        if (reader["IdProvincia"] != DBNull.Value)
                        {
                            cmbProvincia.SelectedValue = Convert.ToInt32(reader["IdProvincia"]);
                        }
                        else
                        {
                            cmbProvincia.SelectedIndex = 0; // Selecciona la opción por defecto si es nulo
                        }
                        //    cmbPartidoMunicipio.Text = usuarioEditando[10];
                        //    cmbLocalidad.Text = usuarioEditando[11];
                        //    txtCodPostal.Text = usuarioEditando[12];
                        //    txtCalle.Text = usuarioEditando[13];
                        //    txtAltura.Text = usuarioEditando[14];
                        //    txtPiso.Text = usuarioEditando[15];
                        //    txtDepartamento.Text = usuarioEditando[16];
                        //    if (indiceLogeado != usuarios.IndexOf(usuarioEditando))
                        //        btnEditarContrasena.Enabled = false;
                        //    else
                        //        btnEditarContrasena.Enabled = true;
                        //}

                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se ha producido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CN.Desconectar();
                }

            }
            else
            {
                // Opcional pero recomendado: Si elijen "Seleccione un usuario", limpiamos los campos
                LimpiarCampos();
                InabilitarTodosLosCampos();
                btnEliminar.Enabled = false;
            }

        }

        //Eventos txt
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }


        //Eventos Botones
        private void btnVolver_Click(object sender, EventArgs e)
        {
            //frmPrincipal principal = new frmPrincipal(usuarios, indiceLogeado);//
            // principal.Show();
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            //Validaciones Requeridos            
            int DNI = 0;
            if (!int.TryParse(txtDNI.Text, out DNI))
            {
                MessageBox.Show("Se esperaba un valor numerico para el DNI",
                    "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }
            if (DNI <= 0 || DNI > 99999999)
            {
                MessageBox.Show("Valores no soportados en el campo DNI. \nEl Nro de DNI debe ser mayor a 0 y tiene que tener como maximo 8 caracteres de longitud",
                    "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }


            long tel = 0;
            if (!long.TryParse(txtTelefono.Text, out tel))
            {
                MessageBox.Show("Se esperaba un valor numerico para el Telefono",
                    "Error Telefono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }
            if (tel <= 0 || tel > 9999999999)
            {
                MessageBox.Show("Valores no soportados en el campo Telefono. \\nSe esperaba como mucho 10 caracteres y un numero positivo para el telefono\"",
                    "Error Telefono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }


            bool esValido = Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!esValido)
            {
                MessageBox.Show("Valores no soportados en el campo Email. \nDebe tener al menos un @ y un",
                    "Error Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            //Validacion No Requeridos
            if (txtCodPostal.Text.Length > 8)
            {
                MessageBox.Show("Valores no soportados en el campo Codigo Postal",
                        "Error CP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodPostal.Focus();
                return;
            }

            int altura = 0;
            if (!int.TryParse(txtAltura.Text, out altura) && (txtAltura.Text != ""))
            {
                MessageBox.Show("Se esperaba un valor numerico para la Altura",
                    "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }
            if (altura <= 0 && txtAltura.Text != "")
            {
                MessageBox.Show("Se esperaba un valor positivo para la Altura",
                    "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }

            if (txtPiso.Text.Length > 2)
            {
                MessageBox.Show("Valores no soportados en el campo Piso",
                        "Error Piso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPiso.Focus();
                return;
            }


            // 🟢 CÓDIGO NUEVO CON CONEXIÓN A BASE DE DATOS:
            try
            {
                // using (SqlConnection CN = new SqlConnection(CadenaConexionAccess))
                //{
                //    string query = @"UPDATE Usuarios SET 
                //            Nombre = @Nombre, 
                //            Apellido = @Apellido, 
                //            DNI = @DNI, 
                //            Telefono = @Telefono, 
                //            Email = @Email,
                //            Rol = @Rol 
                //         WHERE Username = @Username";

                //    SqlCommand cmd = new SqlCommand(query, CN);
                //    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                //    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                //    cmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                //    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                //    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                //    cmd.Parameters.AddWithValue("@Rol", cmbTipoUsuario.Text);
                //    cmd.Parameters.AddWithValue("@Username", cmbUsuarioEditado.Text);

                //    CN.Open();
                //    cmd.ExecuteNonQuery();

                //    MessageBox.Show("Usuario actualizado en la Base de Datos con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la Base de Datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditarContrasena_Click(object sender, EventArgs e)
        {

            //frmCambioContrasena frm = new frmCambioContrasena(usuarios, indiceLogeado);
            //frm.ShowDialog();

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if ((usuarioLogeado[6].ToLower() == "administrador") &&
            //    (usuarioEditando[17].ToLower() != usuarioLogeado[17].ToLower()))

            //{
            //    DialogResult respuesta = MessageBox.Show(
            //        "¿Esta seguro que desea eliminar este usuario? Los datos no se van a recuperar",
            //        "Eliminacion de Usuario", MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            //    if (respuesta == DialogResult.Yes)
            //    {

            //        string[] usuarioABorrar = usuarioEditando;
            //        usuarioEditando = usuarios[indiceLogeado];
            //        int nroIndiceBorrar = cmbUsuarioEditado.SelectedIndex;
            //        cmbUsuarioEditado.SelectedIndex = indiceLogeado;

            //        nombreUsuarios.RemoveAt(nroIndiceBorrar);
            //        usuarios.Remove(usuarioABorrar);



            //        MessageBox.Show("Usuario " + usuarioABorrar[17] + " eliminado", "Eliminado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //}
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult deseaCerrar = MessageBox.Show("Desea cerrar la aplicacion?", "Cerrar Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (deseaCerrar == DialogResult.Yes)
                Application.Exit();
        }
        public void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            rdbMasculino.Checked = false;
            rdbFemenino.Checked = false;
            //cmbTipoUsuario.SelectedIndex = 0;
            // ACÁ ESTABA EL ERROR: Era cmbTipoUsuario, no cmbUsuarioEditado
            if (cmbTipoUsuario.Items.Count > 0 || cmbTipoUsuario.DataSource != null)
            {
                cmbTipoUsuario.SelectedIndex = 0;
            }
            //como hago que qude vacio la fecha?

            dtpFecNac.Value = DateTime.Today;

            if (cmbNacionalidad.Items.Count > 0 || cmbNacionalidad.DataSource != null)
            {
                cmbNacionalidad.SelectedIndex = 0;
            }
            //cmbNacionalidad.SelectedIndex = 0;
            if (cmbProvincia.Items.Count > 0 || cmbProvincia.DataSource != null)
            {
                cmbProvincia.SelectedIndex = 0;
            }
            //cmbProvincia.SelectedIndex = 0;
            if (cmbPartidoMunicipio.Items.Count > 0 || cmbPartidoMunicipio.DataSource != null)
            {
                cmbPartidoMunicipio.SelectedIndex = 0;
            }
            //cmbPartidoMunicipio.SelectedIndex = 0;
            if (cmbLocalidad.Items.Count > 0 || cmbLocalidad.DataSource != null)
            {
                cmbLocalidad.SelectedIndex = 0;
            }
            //cmbLocalidad.SelectedIndex = 0;
            txtCodPostal.Clear();
            txtCalle.Clear();
            txtAltura.Clear();
            txtPiso.Clear();
            txtDepartamento.Clear();
        }
        public void LimpiarCamposUbicacion()
        {
            cmbNacionalidad.SelectedIndex = 0;
            cmbProvincia.SelectedIndex = 0;
            cmbPartidoMunicipio.SelectedIndex = 0;
            cmbLocalidad.SelectedIndex = 0;
            txtCodPostal.Clear();
            txtCalle.Clear();
            txtAltura.Clear();
            txtPiso.Clear();
            txtDepartamento.Clear();
        }

        public void InabilitarTodosLosCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            rdbMasculino.Enabled = false;
            rdbFemenino.Enabled = false;
            cmbTipoUsuario.Enabled = false;
            dtpFecNac.Enabled = false;
            cmbNacionalidad.Enabled = false;
            cmbProvincia.Enabled = false;
            cmbPartidoMunicipio.Enabled = false;
            cmbLocalidad.Enabled = false;
            txtCodPostal.Enabled = false;
            txtCalle.Enabled = false;
            txtAltura.Enabled = false;
            txtPiso.Enabled = false;
            txtDepartamento.Enabled = false;
        }
        public void HabilitarTodosLosCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDNI.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            rdbMasculino.Enabled = true;
            rdbFemenino.Enabled = true;
            cmbTipoUsuario.Enabled = true;
            dtpFecNac.Enabled = true;
            cmbNacionalidad.Enabled = true;
            cmbProvincia.Enabled = true;
            cmbPartidoMunicipio.Enabled = true;
            cmbLocalidad.Enabled = true;
            txtCodPostal.Enabled = true;
            txtCalle.Enabled = true;
            txtAltura.Enabled = true;
            txtPiso.Enabled = true;
            txtDepartamento.Enabled = true;
        }
    }
}
