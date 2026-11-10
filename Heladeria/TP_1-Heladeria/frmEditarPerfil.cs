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
        private class ItemCombo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public ItemCombo(int id, string nombre)
            {
                Id = id;
                Nombre = nombre;
            }

            public override string ToString() => Nombre;
        }

        private DB_Conexion CN = new DB_Conexion();
        private Usuario usuario;
        private int idUsuarioEditando;
        private bool esModoAdmin;
        private bool isCargando = false;

        public frmEditarPerfil(int idUsuario, bool _esModoAdmin = false) : this(ObtenerUsuarioPorId(idUsuario), 0, _esModoAdmin)
        {
        }

        public frmEditarPerfil(Usuario _usuario) : this(_usuario, 0, _usuario != null && _usuario.TipoUsuario == 1)
        {
        }

        public frmEditarPerfil(Usuario _usuario, bool _esModoAdmin) : this(_usuario, 0, _esModoAdmin)
        {
        }

        private static Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            Usuario u = new Usuario { id = idUsuario };
            DB_Conexion cn = new DB_Conexion();
            try
            {
                cn.Conectar_BD();
                string query = "SELECT * FROM Usuarios WHERE IdUsuario = @Id";
                SqlCommand cmd = new SqlCommand(query, cn.MostrarConexion());
                cmd.Parameters.AddWithValue("@Id", idUsuario);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        u.Nombre = r["Nombre"].ToString() ?? "";
                        u.Apellido = r["Apellido"].ToString() ?? "";
                        u.UsuarioCompleto = r["UsuarioCompleto"].ToString() ?? "";
                        u.TipoUsuario = Convert.ToInt32(r["IdTipoUsuario"]);
                        u.Genero = Convert.ToInt32(r["IdGenero"]);
                        u.Email = r["Email"].ToString() ?? "";
                        u.Telefono = r["Telefono"].ToString() ?? "";
                        u.DNI = Convert.ToInt32(r["DNI"]);
                    }
                }
            }
            catch { }
            finally
            {
                cn.Desconectar();
            }
            return u;
        }

        public frmEditarPerfil(Usuario _usuario, int _indiceLogeado = 0, bool _esModoAdmin = false)
        {
            InitializeComponent();

            usuario = _usuario;
            esModoAdmin = _esModoAdmin;
            idUsuarioEditando = usuario.id;

            // Inicializar comboboxes base
            CargarTiposUsuario();
            CargarNacionalidades();

            cmbUsuarioEditado.Items.Clear();

            if (esModoAdmin) // Modo Gestión de Usuarios (Admin)
            {
                lblTitulo.Text = "Gestión de Usuarios";
                try
                {
                    CN.Conectar_BD();
                    string query = "SELECT UsuarioCompleto FROM Usuarios ORDER BY UsuarioCompleto";
                    SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbUsuarioEditado.Items.Add(reader["UsuarioCompleto"].ToString() ?? "");
                        }
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
                if (pos >= 0)
                    cmbUsuarioEditado.SelectedIndex = pos;
                else if (cmbUsuarioEditado.Items.Count > 0)
                    cmbUsuarioEditado.SelectedIndex = 0;
            }
            else // Modo Mi Perfil
            {
                lblTitulo.Text = "Editar Mi Perfil";
                cmbUsuarioEditado.Items.Add(usuario.UsuarioCompleto);
                cmbUsuarioEditado.SelectedIndex = 0;
                CargarDatosUsuario(usuario.id);
            }

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

        private void CargarTiposUsuario()
        {
            cmbTipoUsuario.Items.Clear();
            cmbTipoUsuario.Items.Add(new ItemCombo(0, "Seleccione el tipo de usuario"));
            try
            {
                CN.Conectar_BD();
                string query = "SELECT IdTipoUsuario, TipoDeUsuario FROM TiposUsuario ORDER BY IdTipoUsuario";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        cmbTipoUsuario.Items.Add(new ItemCombo(Convert.ToInt32(r["IdTipoUsuario"]), r["TipoDeUsuario"].ToString() ?? ""));
                    }
                }
            }
            catch
            {
                cmbTipoUsuario.Items.Add(new ItemCombo(1, "Administrador"));
                cmbTipoUsuario.Items.Add(new ItemCombo(2, "General"));
            }
            finally
            {
                CN.Desconectar();
            }
            cmbTipoUsuario.SelectedIndex = 0;
        }

        private void CargarNacionalidades()
        {
            cmbNacionalidad.Items.Clear();
            cmbNacionalidad.Items.Add(new ItemCombo(0, "Seleccione la Nacionalidad"));
            try
            {
                CN.Conectar_BD();
                string query = "SELECT IdNacionalidad, Nacionalidad FROM Nacionalidades ORDER BY Nacionalidad";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        cmbNacionalidad.Items.Add(new ItemCombo(Convert.ToInt32(r["IdNacionalidad"]), r["Nacionalidad"].ToString() ?? ""));
                    }
                }
            }
            catch
            {
                cmbNacionalidad.Items.Add(new ItemCombo(1, "Argentino"));
                cmbNacionalidad.Items.Add(new ItemCombo(2, "Uruguayo"));
            }
            finally
            {
                CN.Desconectar();
            }
            cmbNacionalidad.SelectedIndex = 0;
        }

        private void CargarProvincias()
        {
            cmbProvincia.Items.Clear();
            cmbProvincia.Items.Add(new ItemCombo(0, "Seleccione la Provincia"));

            if (cmbNacionalidad.SelectedIndex > 0)
            {
                cmbProvincia.Enabled = true;
                try
                {
                    CN.Conectar_BD();
                    string query = "SELECT IdProvincia, Provincia FROM Provincias ORDER BY Provincia";
                    SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            cmbProvincia.Items.Add(new ItemCombo(Convert.ToInt32(r["IdProvincia"]), r["Provincia"].ToString() ?? ""));
                        }
                    }
                }
                catch { }
                finally
                {
                    CN.Desconectar();
                }
            }
            else
            {
                cmbProvincia.Enabled = false;
            }

            if (cmbProvincia.Items.Count > 0) cmbProvincia.SelectedIndex = 0;
        }

        private void CargarMunicipios(int idProvincia)
        {
            cmbPartidoMunicipio.Items.Clear();
            cmbPartidoMunicipio.Items.Add(new ItemCombo(0, "Seleccione el Municipio"));

            if (idProvincia > 0)
            {
                cmbPartidoMunicipio.Enabled = true;
                try
                {
                    CN.Conectar_BD();
                    string query = "SELECT IdPartidoMunicipio, PartidoMunicipio FROM Municipios WHERE IdProvincia = @IdProv ORDER BY PartidoMunicipio";
                    SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                    cmd.Parameters.AddWithValue("@IdProv", idProvincia);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            cmbPartidoMunicipio.Items.Add(new ItemCombo(Convert.ToInt32(r["IdPartidoMunicipio"]), r["PartidoMunicipio"].ToString() ?? ""));
                        }
                    }
                }
                catch { }
                finally
                {
                    CN.Desconectar();
                }
            }
            else
            {
                cmbPartidoMunicipio.Enabled = false;
            }

            if (cmbPartidoMunicipio.Items.Count > 0) cmbPartidoMunicipio.SelectedIndex = 0;
        }

        private void CargarLocalidades(int idMunicipio)
        {
            cmbLocalidad.Items.Clear();
            cmbLocalidad.Items.Add(new ItemCombo(0, "Seleccione la Localidad"));

            if (idMunicipio > 0)
            {
                cmbLocalidad.Enabled = true;
                try
                {
                    CN.Conectar_BD();
                    string query = "SELECT IdLocalidad, Localidad FROM Localidades WHERE IdPartidoMunicipio = @IdMun ORDER BY Localidad";
                    SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                    cmd.Parameters.AddWithValue("@IdMun", idMunicipio);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            cmbLocalidad.Items.Add(new ItemCombo(Convert.ToInt32(r["IdLocalidad"]), r["Localidad"].ToString() ?? ""));
                        }
                    }
                }
                catch { }
                finally
                {
                    CN.Desconectar();
                }
            }
            else
            {
                cmbLocalidad.Enabled = false;
            }

            if (cmbLocalidad.Items.Count > 0) cmbLocalidad.SelectedIndex = 0;
        }

        private void CargarDatosUsuario(int idUser)
        {
            isCargando = true;

            string nombre = "";
            string apellido = "";
            string dni = "";
            string tel = "";
            string email = "";
            int idGenero = 1;
            int idTipo = 2;
            DateTime? fecNac = null;
            string calle = "";
            string altura = "";
            string piso = "";
            string depto = "";
            string cp = "";
            int? idNac = null;
            int? idProv = null;
            int? idMun = null;
            int? idLoc = null;
            bool encontrado = false;

            try
            {
                CN.Conectar_BD();
                string queryUser = "SELECT * FROM Usuarios WHERE IdUsuario = @Id";
                SqlCommand cmdUser = new SqlCommand(queryUser, CN.MostrarConexion());
                cmdUser.Parameters.AddWithValue("@Id", idUser);
                using (SqlDataReader r = cmdUser.ExecuteReader())
                {
                    if (r.Read())
                    {
                        encontrado = true;
                        idUsuarioEditando = Convert.ToInt32(r["IdUsuario"]);
                        nombre = r["Nombre"].ToString() ?? "";
                        apellido = r["Apellido"].ToString() ?? "";
                        dni = r["DNI"].ToString()?.Trim() ?? "";
                        tel = r["Telefono"].ToString()?.Trim() ?? "";
                        email = r["Email"].ToString() ?? "";
                        idGenero = Convert.ToInt32(r["IdGenero"]);
                        idTipo = Convert.ToInt32(r["IdTipoUsuario"]);
                        if (r["FechaNacimiento"] != DBNull.Value)
                            fecNac = Convert.ToDateTime(r["FechaNacimiento"]);
                        calle = r["Calle"]?.ToString() ?? "";
                        altura = r["Altura"]?.ToString() ?? "";
                        piso = r["Piso"]?.ToString() ?? "";
                        depto = r["Departamento"]?.ToString() ?? "";
                        cp = r["CodigoPostal"]?.ToString() ?? "";
                        idNac = r["IdNacionalidad"] != DBNull.Value ? Convert.ToInt32(r["IdNacionalidad"]) : null;
                        idProv = r["IdProvincia"] != DBNull.Value ? Convert.ToInt32(r["IdProvincia"]) : null;
                        idMun = r["IdPartidoMunicipio"] != DBNull.Value ? Convert.ToInt32(r["IdPartidoMunicipio"]) : null;
                        idLoc = r["IdLocalidad"] != DBNull.Value ? Convert.ToInt32(r["IdLocalidad"]) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isCargando = false;
                return;
            }
            finally
            {
                CN.Desconectar();
            }

            if (encontrado)
            {
                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
                txtDNI.Text = dni;
                txtTelefono.Text = tel;
                txtEmail.Text = email;

                if (idGenero == 2)
                    rdbMasculino.Checked = true;
                else
                    rdbFemenino.Checked = true;

                SeleccionarComboPorId(cmbTipoUsuario, idTipo);

                if (fecNac.HasValue)
                    dtpFecNac.Value = fecNac.Value;

                txtCalle.Text = calle;
                txtAltura.Text = altura;
                txtPiso.Text = piso;
                txtDepartamento.Text = depto;
                txtCodPostal.Text = cp;

                CargarUbicacion(idNac, idProv, idMun, idLoc);

                btnEliminar.Enabled = (idUsuarioEditando != usuario.id);
            }

            isCargando = false;
        }

        private void SeleccionarComboPorId(ComboBox cmb, int id)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (cmb.Items[i] is ItemCombo item && item.Id == id)
                {
                    cmb.SelectedIndex = i;
                    return;
                }
            }
            if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
        }

        private void CargarUbicacion(int? idNac, int? idProv, int? idMun, int? idLoc)
        {
            // 1. Nacionalidad
            if (idNac.HasValue && idNac.Value > 0)
                SeleccionarComboPorId(cmbNacionalidad, idNac.Value);
            else
                cmbNacionalidad.SelectedIndex = 0;

            // 2. Provincia
            CargarProvincias();
            if (idProv.HasValue && idProv.Value > 0)
                SeleccionarComboPorId(cmbProvincia, idProv.Value);
            else if (cmbProvincia.Items.Count > 0)
                cmbProvincia.SelectedIndex = 0;

            // 3. Municipio
            int provId = (cmbProvincia.SelectedItem is ItemCombo p && p.Id > 0) ? p.Id : (idProv ?? 0);
            CargarMunicipios(provId);
            if (idMun.HasValue && idMun.Value > 0)
                SeleccionarComboPorId(cmbPartidoMunicipio, idMun.Value);
            else if (cmbPartidoMunicipio.Items.Count > 0)
                cmbPartidoMunicipio.SelectedIndex = 0;

            // 4. Localidad
            int munId = (cmbPartidoMunicipio.SelectedItem is ItemCombo m && m.Id > 0) ? m.Id : (idMun ?? 0);
            CargarLocalidades(munId);
            if (idLoc.HasValue && idLoc.Value > 0)
                SeleccionarComboPorId(cmbLocalidad, idLoc.Value);
            else if (cmbLocalidad.Items.Count > 0)
                cmbLocalidad.SelectedIndex = 0;
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
            if (isCargando) return;
            CargarProvincias();
            CargarMunicipios(0);
            CargarLocalidades(0);
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCargando) return;
            int idProv = (cmbProvincia.SelectedItem is ItemCombo p && p.Id > 0) ? p.Id : 0;
            CargarMunicipios(idProv);
            CargarLocalidades(0);
        }

        private void cmbPartidoMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCargando) return;
            int idMun = (cmbPartidoMunicipio.SelectedItem is ItemCombo m && m.Id > 0) ? m.Id : 0;
            CargarLocalidades(idMun);
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarCamposObligatorios();
        }

        private void cmbUsuarioEditado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!esModoAdmin || cmbUsuarioEditado.SelectedItem == null)
                return;

            string usuarioSeleccionado = cmbUsuarioEditado.SelectedItem.ToString() ?? "";
            try
            {
                CN.Conectar_BD();
                string query = "SELECT IdUsuario FROM Usuarios WHERE UsuarioCompleto = @UsuarioCompleto";
                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@UsuarioCompleto", usuarioSeleccionado);
                object? result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    int idTarget = Convert.ToInt32(result);
                    CargarDatosUsuario(idTarget);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Desconectar();
            }
        }

        // Eventos TextBox
        private void txtNombre_TextChanged(object sender, EventArgs e) => ValidarCamposObligatorios();
        private void txtApellido_TextChanged(object sender, EventArgs e) => ValidarCamposObligatorios();
        private void txtDNI_TextChanged(object sender, EventArgs e) => ValidarCamposObligatorios();
        private void txtTelefono_TextChanged(object sender, EventArgs e) => ValidarCamposObligatorios();
        private void txtEmail_TextChanged(object sender, EventArgs e) => ValidarCamposObligatorios();

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
            if (!int.TryParse(txtDNI.Text.Trim(), out DNI))
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
            if (!long.TryParse(txtTelefono.Text.Trim(), out tel))
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

            // Validaciones Campos Opcionales
            if (txtCodPostal.Text.Trim().Length > 8)
            {
                MessageBox.Show("El código postal no puede tener más de 8 caracteres.", "Error CP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodPostal.Focus();
                return;
            }

            int altura = 0;
            if (!int.TryParse(txtAltura.Text.Trim(), out altura) && (txtAltura.Text.Trim() != ""))
            {
                MessageBox.Show("Se esperaba un valor numérico para la Altura.", "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }
            if (altura <= 0 && txtAltura.Text.Trim() != "")
            {
                MessageBox.Show("La altura debe ser un valor positivo.", "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }

            if (txtPiso.Text.Trim().Length > 2)
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
                                    IdGenero = @IdGenero, 
                                    IdTipoUsuario = @IdTipoUsuario,
                                    FechaNacimiento = @FechaNacimiento,
                                    Calle = @Calle,
                                    Altura = @Altura,
                                    Piso = @Piso,
                                    Departamento = @Departamento,
                                    CodigoPostal = @CodigoPostal,
                                    IdNacionalidad = @IdNacionalidad,
                                    IdProvincia = @IdProvincia,
                                    IdPartidoMunicipio = @IdPartidoMunicipio,
                                    IdLocalidad = @IdLocalidad
                                WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, CN.MostrarConexion());
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                // En tabla Generos: 1 = Femenino, 2 = Masculino
                cmd.Parameters.AddWithValue("@IdGenero", rdbMasculino.Checked ? 2 : 1);
                // En tabla TiposUsuario: 1 = Administrador, 2 = General
                int idTipo = (cmbTipoUsuario.SelectedItem is ItemCombo tip && tip.Id > 0) ? tip.Id : 2;
                cmd.Parameters.AddWithValue("@IdTipoUsuario", idTipo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFecNac.Value.Date);
                cmd.Parameters.AddWithValue("@Calle", txtCalle.Text.Trim());
                cmd.Parameters.AddWithValue("@Altura", string.IsNullOrWhiteSpace(txtAltura.Text) ? (object)DBNull.Value : Convert.ToInt32(txtAltura.Text.Trim()));
                cmd.Parameters.AddWithValue("@Piso", string.IsNullOrWhiteSpace(txtPiso.Text) ? (object)DBNull.Value : txtPiso.Text.Trim());
                cmd.Parameters.AddWithValue("@Departamento", txtDepartamento.Text.Trim());
                cmd.Parameters.AddWithValue("@CodigoPostal", txtCodPostal.Text.Trim());

                int idNac = (cmbNacionalidad.SelectedItem is ItemCombo nac && nac.Id > 0) ? nac.Id : 0;
                cmd.Parameters.AddWithValue("@IdNacionalidad", idNac > 0 ? (object)idNac : DBNull.Value);

                int idProv = (cmbProvincia.SelectedItem is ItemCombo prov && prov.Id > 0) ? prov.Id : 0;
                cmd.Parameters.AddWithValue("@IdProvincia", idProv > 0 ? (object)idProv : DBNull.Value);

                int idMun = (cmbPartidoMunicipio.SelectedItem is ItemCombo mun && mun.Id > 0) ? mun.Id : 0;
                cmd.Parameters.AddWithValue("@IdPartidoMunicipio", idMun > 0 ? (object)idMun : DBNull.Value);

                int idLoc = (cmbLocalidad.SelectedItem is ItemCombo loc && loc.Id > 0) ? loc.Id : 0;
                cmd.Parameters.AddWithValue("@IdLocalidad", idLoc > 0 ? (object)idLoc : DBNull.Value);

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
                        usuario.Genero = rdbMasculino.Checked ? 2 : 1;
                        usuario.TipoUsuario = idTipo;
                        usuario.FechaNacimiento = dtpFecNac.Value;
                        usuario.Calle = txtCalle.Text.Trim();
                        usuario.CodigoPostal = txtCodPostal.Text.Trim();
                        if (int.TryParse(txtAltura.Text, out int alt)) usuario.Altura = alt;
                        if (int.TryParse(txtPiso.Text, out int piso)) usuario.Piso = piso;
                        usuario.Departamento = txtDepartamento.Text.Trim();
                        usuario.Nacionalidad = (cmbNacionalidad.SelectedItem is ItemCombo n && n.Id > 0) ? n.Id : 0;
                        usuario.Provincia = (cmbProvincia.SelectedItem is ItemCombo pr && pr.Id > 0) ? pr.Id : 0;
                        usuario.Municipio = (cmbPartidoMunicipio.SelectedItem is ItemCombo mu && mu.Id > 0) ? mu.Id : 0;
                        usuario.Localidad = (cmbLocalidad.SelectedItem is ItemCombo lc && lc.Id > 0) ? lc.Id : 0;
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
