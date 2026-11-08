using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace TP_1_Heladeria
{
    public partial class frmEditarPerfil : Form
    {
        public string[] usuarioLogeado;
        public string[] usuarioEditando;
        // public BindingList<string[]> usuarios = new BindingList<string[]>();
        int indiceLogeado;
        // BindingList<string> nombreUsuarios = new BindingList<string>();
        DB_Conexion CN = new DB_Conexion();
        ValidacionDeCampos validacion = new ValidacionDeCampos();
        Usuario usuario;
        int idUsuarioEditando;
        bool esModoAdmin;

        //public frmEditarPerfil(BindingList<string[]> _usuarios, int _indiceLogeado)
        public frmEditarPerfil(Usuario _usuario, int _indiceLogeado = 1, bool _esModoAdmin = true)
        {

            InitializeComponent();

            usuario = _usuario;
            indiceLogeado = _indiceLogeado;
            esModoAdmin = _esModoAdmin;
            idUsuarioEditando = usuario.id;
            string[] permisos = { cmbTipoUsuario.AccessibleDescription, "Administrador", "General" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };


            // foreach (string[] usuarioActual in usuarios) nombreUsuarios.Add(usuarioActual[17]);



            // cmbUsuarioEditado.DataSource = nombreUsuarios;
            cmbUsuarioEditado.Items.Clear();
            if (esModoAdmin) // Modo Editar Usuarios (Admin)
            {
                lblTitulo.Text = "Gestión de Usuarios"; // O el label de título que tengas
                try
                {
                    CN.Conectar_BD();
                    string query = "SELECT UsuarioCompleto FROM Usuarios ORDER BY UsuarioCompleto";
                    SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbUsuarioEditado.Items.Add(reader["UsuarioCompleto"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message);
                }
                finally
                {
                    CN.Desconectar();
                }
                // Seleccionamos al usuario actual en la lista por defecto
                int pos = cmbUsuarioEditado.Items.IndexOf(usuario.UsuarioCompleto);
                cmbUsuarioEditado.SelectedIndex = (pos >= 0) ? pos : 0;
            }
            else // Modo Mi Perfil
            {
                lblTitulo.Text = "Editar Mi Perfil";
                cmbUsuarioEditado.Items.Add(usuario.UsuarioCompleto);
                cmbUsuarioEditado.SelectedIndex = 0;
            }
            cmbNacionalidad.DataSource = paises;
            cmbTipoUsuario.DataSource = permisos;

            {
                // cmbUsuarioEditado.SelectedIndex = indiceLogeado;

                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDNI.Text = usuario.DNI.ToString();
                txtTelefono.Text = usuario.Telefono;
                txtEmail.Text = usuario.Email;

                if (usuario.Genero == 1)
                    rdbMasculino.Checked = true;
                else
                    rdbFemenino.Checked = true;


                // cmbTipoUsuario.Text = usuario.TipoUsuario;
                cmbTipoUsuario.Text = (usuario.TipoUsuario == 1) ? "Administrador" : "General";
                // dtpFecNac.Text = usuario.FechaNacimiento;
                if (usuario.FechaNacimiento != DateTime.MinValue){
                    dtpFecNac.Value = usuario.FechaNacimiento;
            }
                cmbNacionalidad.Text = usuario.Nacionalidad;
                cmbProvincia.Text = usuario.Provincia;
                cmbPartidoMunicipio.Text = usuario.Municipio;
                cmbLocalidad.Text = usuario.Localidad;

                txtCodPostal.Text = usuario.CodigoPostal;
                txtCalle.Text = usuario.Calle;
                txtAltura.Text = usuario.Altura > 0 ? usuario.Altura.ToString():"";
                txtPiso.Text = usuario.Piso > 0 ? usuario.Piso.ToString(): "";
                txtDepartamento.Text = usuario.Departamento;


            }

            {
                if (cmbNacionalidad.SelectedValue != null && cmbNacionalidad.SelectedIndex != 0)
                    cmbProvincia.Enabled = true;
                else
                    cmbProvincia.Enabled = false;

                if (cmbProvincia.SelectedValue != null && cmbProvincia.SelectedIndex != 0)
                    cmbPartidoMunicipio.Enabled = true;
                else
                    cmbPartidoMunicipio.Enabled = false;

                if (cmbPartidoMunicipio.SelectedValue != null && cmbPartidoMunicipio.SelectedIndex != 0)
                    cmbLocalidad.Enabled = true;
                else
                    cmbLocalidad.Enabled = false;
            }

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

            if (!esModoAdmin)
                {
                    cmbTipoUsuario.Enabled = false;
                    txtDNI.Enabled = false;
                    cmbUsuarioEditado.Enabled = false;
                    btnGuardarCambios.Width = 201;
                    btnEliminar.Enabled = false;
                    btnEliminar.Visible = false;
                }
                else
                {
                    cmbTipoUsuario.Enabled = true;
                    txtDNI.Enabled = false; // El DNI suele ser fijo/identificador único
                    cmbUsuarioEditado.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnEliminar.Visible = true;
                }

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);

        }



        //Eventos Combo
        private void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            }
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
            // Solo actuamos si estamos en modo Admin y hay un usuario seleccionado
            if (!esModoAdmin || cmbUsuarioEditado.SelectedItem == null)
                return;

            string usuarioSeleccionado = cmbUsuarioEditado.SelectedItem.ToString();

            try
            {
                CN.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE UsuarioCompleto = @UsuarioCompleto";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@UsuarioCompleto", usuarioSeleccionado);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Guardamos el ID del usuario que estamos editando actualmente
                    idUsuarioEditando = Convert.ToInt32(reader["IdUsuario"]);

                    // Cargamos sus datos en las cajas de texto
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtApellido.Text = reader["Apellido"].ToString();
                    txtDNI.Text = reader["DNI"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtEmail.Text = reader["Email"].ToString();

                    // Género
                    string genero = reader["Genero"]?.ToString() ?? "";
                    if (genero.ToLower() == "masculino" || genero == "1")
                        rdbMasculino.Checked = true;
                    else
                        rdbFemenino.Checked = true;

                    // Tipo de Usuario (Rol)
                    string tipo = reader["TipoUsuario"]?.ToString() ?? "";
                    if (tipo.ToLower() == "administrador" || tipo == "1")
                        cmbTipoUsuario.Text = "Administrador";
                    else
                        cmbTipoUsuario.Text = "General";

                    // Fecha de Nacimiento
                    if (reader["FechaNacimiento"] != DBNull.Value)
                        dtpFecNac.Value = Convert.ToDateTime(reader["FechaNacimiento"]);

                    // Domicilio
                    txtCalle.Text = reader["Calle"]?.ToString();
                    txtAltura.Text = reader["Altura"]?.ToString();
                    txtPiso.Text = reader["Piso"]?.ToString();
                    txtDepartamento.Text = reader["Departamento"]?.ToString();
                    txtCodPostal.Text = reader["CodigoPostal"]?.ToString();

                    // Seguridad: Un Admin NO puede eliminarse a sí mismo
                    btnEliminar.Enabled = (idUsuarioEditando != usuario.id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
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
            frmPrincipal principal = new frmPrincipal(usuario);
            principal.Show();
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
            try
            {
                CN.Conectar_BD();

                string query = @"UPDATE Usuarios SET 
                                    Nombre = @Nombre, 
                                    Apellido = @Apellido, 
                                    Telefono = @Telefono, 
                                    Email = @Email, 
                                    Genero = @Genero, 
                                    FechaNacimiento = @FechaNacimiento,
                                    Calle = @Calle,
                                    Altura = @Altura,
                                    Piso = @Piso,
                                    Departamento = @Departamento,
                                    CodigoPostal = @CodigoPostal,
                                    TipoUsuario = @TipoUsuario
                                WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Genero", rdbMasculino.Checked ? "Masculino" : "Femenino");
                cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFecNac.Value);   
                cmd.Parameters.AddWithValue("@Calle", txtCalle.Text.Trim());
                cmd.Parameters.AddWithValue("@Altura", string.IsNullOrWhiteSpace(txtAltura.Text) ? (object)DBNull.Value : Convert.ToInt32(txtAltura.Text));
                cmd.Parameters.AddWithValue("@Piso", string.IsNullOrWhiteSpace(txtPiso.Text) ? (object)DBNull.Value : Convert.ToInt32(txtPiso.Text));
                cmd.Parameters.AddWithValue("@Departamento", txtDepartamento.Text.Trim());
                cmd.Parameters.AddWithValue("@CodigoPostal", txtCodPostal.Text.Trim());
                cmd.Parameters.AddWithValue("@TipoUsuario", (cmbTipoUsuario.Text == "Administrador") ? "Administrador" : "Usuario");                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuarioEditando);   

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    // Actualizamos el objeto en memoria para que el menú principal tenga los datos nuevos
                    usuario.Nombre = txtNombre.Text.Trim();
                    usuario.Apellido = txtApellido.Text.Trim();
                    usuario.Telefono = txtTelefono.Text.Trim();
                    usuario.Email = txtEmail.Text.Trim();
                    usuario.Genero = rdbMasculino.Checked ? 1 : 2;
                    usuario.FechaNacimiento = dtpFecNac.Value;
                    usuario.Calle = txtCalle.Text.Trim();
                    usuario.CodigoPostal = txtCodPostal.Text.Trim();
                    if (int.TryParse(txtAltura.Text, out int alt)) usuario.Altura = alt;
                    if (int.TryParse(txtPiso.Text, out int piso)) usuario.Piso = piso;
                    usuario.Departamento = txtDepartamento.Text.Trim();

                    MessageBox.Show("Perfil actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmPrincipal prin = new frmPrincipal(usuario);
                    prin.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
            }

            // int guardarEn = usuarios.ToList().FindIndex(nombreCuenta => nombreCuenta[17] == usuarioEditando[17]);
            // usuarioEditando[0] = txtNombre.Text;
            // usuarioEditando[1] = txtApellido.Text;
            // usuarioEditando[2] = txtDNI.Text;
            // usuarioEditando[3] = txtTelefono.Text;
            // usuarioEditando[4] = txtEmail.Text;
            // if (rdbMasculino.Checked)
            //     usuarioEditando[5] = "Masculino";
            // else
            //     usuarioEditando[5] = "Femenino";
            // usuarioEditando[6] = cmbTipoUsuario.SelectedValue.ToString();
            // usuarioEditando[7] = dtpFecNac.Text;
            // if (cmbNacionalidad.SelectedIndex >= 0)
            //     usuarioEditando[8] = cmbNacionalidad.SelectedValue.ToString();

            // if (cmbProvincia.SelectedIndex >= 0)
            //     usuarioEditando[9] = cmbProvincia.SelectedValue.ToString();
            // else
            //     usuarioEditando[9] = "";
            // if (cmbPartidoMunicipio.SelectedIndex >= 0)
            //     usuarioEditando[10] = cmbPartidoMunicipio.SelectedValue.ToString();
            // else
            //     usuarioEditando[10] = "";
            // usuarioEditando[11] = cmbLocalidad.SelectedIndex >= 0 ? cmbLocalidad.SelectedValue.ToString() : "";
            // usuarioEditando[12] = txtCodPostal.Text;
            // usuarioEditando[13] = txtCalle.Text;
            // usuarioEditando[14] = txtAltura.Text;
            // usuarioEditando[15] = txtPiso.Text;
            // usuarioEditando[16] = txtDepartamento.Text;

            // MessageBox.Show("Se edito el usuario exitosamente");

            // usuarios[guardarEn] = usuarioEditando;
            // frmPrincipal prin = new frmPrincipal(usuario);
            // prin.Show();
            // this.Close();
        }
        private void btnEditarContrasena_Click(object sender, EventArgs e)
        {

            frmCambioContrasena frm = new frmCambioContrasena(usuario);
            frm.ShowDialog();

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioEditando == usuario.id)
            {
                MessageBox.Show("No podés eliminar tu propia cuenta de Administrador.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseás eliminar este usuario? Los datos no se podrán recuperar.",
                "Eliminar Usuario",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    CN.Conectar_BD();
                    string query = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";
                    SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuarioEditando);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refrescamos la pantalla para actualizar la lista de usuarios
                    frmEditarPerfil recargar = new frmEditarPerfil(usuario, 0, true);
                    recargar.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CN.Desconectar();
                }
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // DialogResult deseaCerrar = MessageBox.Show("Desea cerrar la aplicacion?", "Cerrar Sistema",
            //     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            // if (deseaCerrar == DialogResult.Yes)
            //     Application.Exit();
        }
    }
}