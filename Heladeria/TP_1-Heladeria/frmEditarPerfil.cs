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
        private DB_Conexion CN = new DB_Conexion();
        private Usuario usuario;
        private int indiceLogeado;
        private int idUsuarioEditando;
        private bool esModoAdmin;

        public frmEditarPerfil(Usuario _usuario, int _indiceLogeado = 0, bool _esModoAdmin = false)
        {
            InitializeComponent();

            usuario = _usuario;
            indiceLogeado = _indiceLogeado;
            esModoAdmin = _esModoAdmin;
            idUsuarioEditando = usuario.id;

            string[] permisos = { cmbTipoUsuario.AccessibleDescription, "Administrador", "General" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };

            cmbUsuarioEditado.Items.Clear();

            if (esModoAdmin) // Modo Gestión de Usuarios (Admin)
            {
                lblTitulo.Text = "Gestión de Usuarios";
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
                    MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CN.Desconectar();
                }

                // Seleccionar al usuario logueado en la lista por defecto
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

            // Carga inicial de datos desde la base de datos
            try
            {
                CN.Conectar_BD();
                string queryUser = "SELECT * FROM Usuarios WHERE IdUsuario = @Id";
                SqlCommand cmdUser = new SqlCommand(queryUser, CN.MostrarConexion());
                cmdUser.Parameters.AddWithValue("@Id", usuario.id);
                SqlDataReader r = cmdUser.ExecuteReader();
                if (r.Read())
                {
                    txtNombre.Text = r["Nombre"].ToString();
                    txtApellido.Text = r["Apellido"].ToString();
                    txtDNI.Text = r["DNI"].ToString();
                    txtTelefono.Text = r["Telefono"].ToString();
                    txtEmail.Text = r["Email"].ToString();

                    string gen = r["Genero"]?.ToString() ?? "";
                    if (gen.ToLower() == "masculino" || gen == "1")
                        rdbMasculino.Checked = true;
                    else
                        rdbFemenino.Checked = true;

                    string tip = r["TipoUsuario"]?.ToString() ?? "";
                    cmbTipoUsuario.SelectedIndex = (tip.ToLower() == "administrador" || tip == "1") ? 1 : 2;

                    if (r["FechaNacimiento"] != DBNull.Value)
                        dtpFecNac.Value = Convert.ToDateTime(r["FechaNacimiento"]);

                    txtCalle.Text = r["Calle"]?.ToString();
                    txtAltura.Text = r["Altura"]?.ToString();
                    txtPiso.Text = r["Piso"]?.ToString();
                    txtDepartamento.Text = r["Departamento"]?.ToString();
                    txtCodPostal.Text = r["CodigoPostal"]?.ToString();

                    CargarUbicacion(r["Nacionalidad"]?.ToString(), r["Provincia"]?.ToString(), r["PartidoMunicipio"]?.ToString(), r["Localidad"]?.ToString());
                }
            }
            catch
            {
                // Respaldo con los datos en memoria si la BD no responde
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDNI.Text = usuario.DNI.ToString();
                txtTelefono.Text = usuario.Telefono;
                txtEmail.Text = usuario.Email;
                if (usuario.Genero == 1) rdbMasculino.Checked = true; else rdbFemenino.Checked = true;
                cmbTipoUsuario.SelectedIndex = (usuario.TipoUsuario == 1) ? 1 : 2;
                if (usuario.FechaNacimiento != DateTime.MinValue) dtpFecNac.Value = usuario.FechaNacimiento;
                txtCodPostal.Text = usuario.CodigoPostal;
                txtCalle.Text = usuario.Calle;
                txtAltura.Text = usuario.Altura > 0 ? usuario.Altura.ToString() : "";
                txtPiso.Text = usuario.Piso > 0 ? usuario.Piso.ToString() : "";
                txtDepartamento.Text = usuario.Departamento;
                CargarUbicacion(usuario.Nacionalidad, usuario.Provincia, usuario.Municipio, usuario.Localidad);
            }
            finally
            {
                CN.Desconectar();
            }

            cmbProvincia.Enabled = (cmbNacionalidad.SelectedValue != null && cmbNacionalidad.SelectedIndex > 0);
            cmbPartidoMunicipio.Enabled = (cmbProvincia.SelectedValue != null && cmbProvincia.SelectedIndex > 0);
            cmbLocalidad.Enabled = (cmbPartidoMunicipio.SelectedValue != null && cmbPartidoMunicipio.SelectedIndex > 0);

            ValidarCamposObligatorios();

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
                txtDNI.Enabled = false;
                cmbUsuarioEditado.Enabled = true;
                btnEliminar.Enabled = true;
                btnEliminar.Visible = true;
            }

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);
        }

        private void ValidarCamposObligatorios()
        {
            bool valido = txtNombre.Text.Trim().Length > 0 &&
                          txtApellido.Text.Trim().Length > 0 &&
                          txtDNI.Text.Trim().Length > 0 &&
                          txtTelefono.Text.Trim().Length > 0 &&
                          txtEmail.Text.Trim().Length > 0 &&
                          (cmbTipoUsuario.SelectedIndex == 1 || cmbTipoUsuario.SelectedIndex == 2);

            btnGuardarCambios.Enabled = valido;
            grpUbicacion.Enabled = valido;
        }

        // Eventos Combo
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
            ValidarCamposObligatorios();
        }

        private void cmbUsuarioEditado_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    idUsuarioEditando = Convert.ToInt32(reader["IdUsuario"]);

                    txtNombre.Text = reader["Nombre"].ToString();
                    txtApellido.Text = reader["Apellido"].ToString();
                    txtDNI.Text = reader["DNI"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtEmail.Text = reader["Email"].ToString();

                    string genero = reader["Genero"]?.ToString() ?? "";
                    if (genero.ToLower() == "masculino" || genero == "1")
                        rdbMasculino.Checked = true;
                    else
                        rdbFemenino.Checked = true;

                    string tipo = reader["TipoUsuario"]?.ToString() ?? "";
                    if (tipo.ToLower() == "administrador" || tipo == "1")
                        cmbTipoUsuario.SelectedIndex = 1;
                    else
                        cmbTipoUsuario.SelectedIndex = 2;

                    if (reader["FechaNacimiento"] != DBNull.Value)
                        dtpFecNac.Value = Convert.ToDateTime(reader["FechaNacimiento"]);

                    txtCalle.Text = reader["Calle"]?.ToString();
                    txtAltura.Text = reader["Altura"]?.ToString();
                    txtPiso.Text = reader["Piso"]?.ToString();
                    txtDepartamento.Text = reader["Departamento"]?.ToString();
                    txtCodPostal.Text = reader["CodigoPostal"]?.ToString();

                    CargarUbicacion(
                        reader["Nacionalidad"]?.ToString(),
                        reader["Provincia"]?.ToString(),
                        reader["PartidoMunicipio"]?.ToString(),
                        reader["Localidad"]?.ToString()
                    );

                    // Un Administrador no puede eliminarse a sí mismo
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

        private void CargarUbicacion(string? nac, string? prov, string? mun, string? loc)
        {
            if (string.IsNullOrWhiteSpace(nac))
            {
                cmbNacionalidad.SelectedIndex = 0;
                return;
            }

            for (int i = 0; i < cmbNacionalidad.Items.Count; i++)
            {
                if (cmbNacionalidad.Items[i].ToString().Equals(nac, StringComparison.OrdinalIgnoreCase))
                {
                    cmbNacionalidad.SelectedIndex = i;
                    break;
                }
            }

            if (!string.IsNullOrWhiteSpace(prov) && cmbProvincia.Items != null)
            {
                for (int i = 0; i < cmbProvincia.Items.Count; i++)
                {
                    if (cmbProvincia.Items[i].ToString().Equals(prov, StringComparison.OrdinalIgnoreCase))
                    {
                        cmbProvincia.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(mun) && cmbPartidoMunicipio.Items != null)
            {
                for (int i = 0; i < cmbPartidoMunicipio.Items.Count; i++)
                {
                    if (cmbPartidoMunicipio.Items[i].ToString().Equals(mun, StringComparison.OrdinalIgnoreCase))
                    {
                        cmbPartidoMunicipio.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(loc) && cmbLocalidad.Items != null)
            {
                for (int i = 0; i < cmbLocalidad.Items.Count; i++)
                {
                    if (cmbLocalidad.Items[i].ToString().Equals(loc, StringComparison.OrdinalIgnoreCase))
                    {
                        cmbLocalidad.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        // Eventos TextBox
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCamposObligatorios();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            ValidarCamposObligatorios();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            ValidarCamposObligatorios();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            ValidarCamposObligatorios();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidarCamposObligatorios();
        }

        // Eventos Botones
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal(usuario);
            principal.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validaciones Nombre y Apellido
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text.Trim().Length < 2)
            {
                MessageBox.Show("El nombre debe tener al menos 2 caracteres.", "Error Nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text.Trim().Length < 2)
            {
                MessageBox.Show("El apellido debe tener al menos 2 caracteres.", "Error Apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return;
            }

            // Validaciones DNI
            int DNI = 0;
            if (!int.TryParse(txtDNI.Text, out DNI))
            {
                MessageBox.Show("Se esperaba un valor numérico para el DNI.", "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }
            if (DNI <= 0 || DNI > 99999999)
            {
                MessageBox.Show("El número de DNI debe ser mayor a 0 y tener como máximo 8 caracteres.", "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }

            // Validaciones Teléfono
            long tel = 0;
            if (!long.TryParse(txtTelefono.Text, out tel))
            {
                MessageBox.Show("Se esperaba un valor numérico para el Teléfono.", "Error Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }
            if (tel <= 0 || tel > 9999999999)
            {
                MessageBox.Show("El teléfono debe ser un número positivo de hasta 10 dígitos.", "Error Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }

            // Validaciones Email
            bool esValido = Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!esValido)
            {
                MessageBox.Show("El correo electrónico no es válido. Debe incluir '@' y un dominio con punto '.'", "Error Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // Validar que el Email no esté en uso por otro usuario
            try
            {
                CN.Conectar_BD();
                string queryCheckMail = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email AND IdUsuario != @IdUsuario";
                SqlCommand cmdCheckMail = new SqlCommand(queryCheckMail, CN.MostrarConexion());
                cmdCheckMail.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmdCheckMail.Parameters.AddWithValue("@IdUsuario", idUsuarioEditando);
                int countMail = Convert.ToInt32(cmdCheckMail.ExecuteScalar());

                if (countMail > 0)
                {
                    MessageBox.Show("El correo electrónico ingresado ya se encuentra registrado por otro usuario.", "Email en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el correo electrónico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                CN.Desconectar();
            }

            // Validaciones No Requeridos
            if (txtCodPostal.Text.Length > 8)
            {
                MessageBox.Show("El código postal no puede tener más de 8 caracteres.", "Error CP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodPostal.Focus();
                return;
            }

            int altura = 0;
            if (!int.TryParse(txtAltura.Text, out altura) && (txtAltura.Text != ""))
            {
                MessageBox.Show("Se esperaba un valor numérico para la Altura.", "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }
            if (altura <= 0 && txtAltura.Text != "")
            {
                MessageBox.Show("La altura debe ser un valor positivo.", "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }

            if (txtPiso.Text.Length > 2)
            {
                MessageBox.Show("El piso no puede exceder 2 caracteres.", "Error Piso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    Nacionalidad = @Nacionalidad,
                                    Provincia = @Provincia,
                                    PartidoMunicipio = @PartidoMunicipio,
                                    Localidad = @Localidad,
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
                cmd.Parameters.AddWithValue("@Piso", string.IsNullOrWhiteSpace(txtPiso.Text) ? (object)DBNull.Value : txtPiso.Text.Trim());
                cmd.Parameters.AddWithValue("@Departamento", txtDepartamento.Text.Trim());
                cmd.Parameters.AddWithValue("@CodigoPostal", txtCodPostal.Text.Trim());
                cmd.Parameters.AddWithValue("@Nacionalidad", (cmbNacionalidad.SelectedIndex > 0) ? cmbNacionalidad.Text.Trim() : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Provincia", (cmbProvincia.SelectedIndex > 0) ? cmbProvincia.Text.Trim() : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PartidoMunicipio", (cmbPartidoMunicipio.SelectedIndex > 0) ? cmbPartidoMunicipio.Text.Trim() : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Localidad", (cmbLocalidad.SelectedIndex > 0) ? cmbLocalidad.Text.Trim() : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoUsuario", (cmbTipoUsuario.SelectedIndex == 1) ? "Administrador" : "Usuario");
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuarioEditando);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    // Si se editó el propio usuario logueado, actualizamos sus datos en memoria
                    if (idUsuarioEditando == usuario.id)
                    {
                        usuario.Nombre = txtNombre.Text.Trim();
                        usuario.Apellido = txtApellido.Text.Trim();
                        usuario.Telefono = txtTelefono.Text.Trim();
                        usuario.Email = txtEmail.Text.Trim();
                        usuario.Genero = rdbMasculino.Checked ? 1 : 2;
                        usuario.TipoUsuario = (cmbTipoUsuario.SelectedIndex == 1) ? 1 : 2;
                        usuario.FechaNacimiento = dtpFecNac.Value;
                        usuario.Calle = txtCalle.Text.Trim();
                        usuario.CodigoPostal = txtCodPostal.Text.Trim();
                        if (int.TryParse(txtAltura.Text, out int alt)) usuario.Altura = alt;
                        if (int.TryParse(txtPiso.Text, out int piso)) usuario.Piso = piso;
                        usuario.Departamento = txtDepartamento.Text.Trim();
                        usuario.Nacionalidad = (cmbNacionalidad.SelectedIndex > 0) ? cmbNacionalidad.Text.Trim() : "";
                        usuario.Provincia = (cmbProvincia.SelectedIndex > 0) ? cmbProvincia.Text.Trim() : "";
                        usuario.Municipio = (cmbPartidoMunicipio.SelectedIndex > 0) ? cmbPartidoMunicipio.Text.Trim() : "";
                        usuario.Localidad = (cmbLocalidad.SelectedIndex > 0) ? cmbLocalidad.Text.Trim() : "";
                    }

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
            DialogResult deseaCerrar = MessageBox.Show("¿Desea cerrar la aplicación?", "Cerrar Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (deseaCerrar == DialogResult.Yes)
                Application.Exit();
        }
    }
}
