namespace TP_1_Heladeria
{
    partial class frmEditarPerfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtDNI = new TextBox();
            lblDNI = new Label();
            grpPersonales = new GroupBox();
            grpGenero = new GroupBox();
            rdbFemenino = new RadioButton();
            rdbMasculino = new RadioButton();
            dtpFecNac = new DateTimePicker();
            cmbTipoUsuario = new ComboBox();
            lblFecNac = new Label();
            lblTipoUsuario = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            grpUbicacion = new GroupBox();
            cmbLocalidad = new ComboBox();
            cmbPartidoMunicipio = new ComboBox();
            cmbProvincia = new ComboBox();
            cmbNacionalidad = new ComboBox();
            lblDepartamento = new Label();
            txtDepartamento = new TextBox();
            lblPiso = new Label();
            txtPiso = new TextBox();
            lblAltura = new Label();
            txtAltura = new TextBox();
            lblCalle = new Label();
            txtCalle = new TextBox();
            lblCodPostal = new Label();
            txtCodPostal = new TextBox();
            lblLocalidad = new Label();
            lblPartidoMunicipio = new Label();
            lblNacionalidad = new Label();
            lblProvincia = new Label();
            btnGuardarCambios = new Button();
            btnVolver = new Button();
            btnEditarContrasena = new Button();
            cmbUsuarioEditado = new ComboBox();
            grpPersonales.SuspendLayout();
            grpGenero.SuspendLayout();
            grpUbicacion.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(31, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(163, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Editar el Usuario:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(32, 32);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(104, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(197, 23);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(104, 58);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(197, 23);
            txtApellido.TabIndex = 2;
            txtApellido.TextChanged += txtApellido_TextChanged;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(32, 61);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(104, 87);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(197, 23);
            txtDNI.TabIndex = 3;
            txtDNI.TextChanged += txtDNI_TextChanged;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(32, 90);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(27, 15);
            lblDNI.TabIndex = 5;
            lblDNI.Text = "DNI";
            // 
            // grpPersonales
            // 
            grpPersonales.Controls.Add(grpGenero);
            grpPersonales.Controls.Add(dtpFecNac);
            grpPersonales.Controls.Add(cmbTipoUsuario);
            grpPersonales.Controls.Add(lblFecNac);
            grpPersonales.Controls.Add(lblTipoUsuario);
            grpPersonales.Controls.Add(lblEmail);
            grpPersonales.Controls.Add(txtEmail);
            grpPersonales.Controls.Add(lblTelefono);
            grpPersonales.Controls.Add(txtTelefono);
            grpPersonales.Controls.Add(lblDNI);
            grpPersonales.Controls.Add(txtDNI);
            grpPersonales.Controls.Add(lblNombre);
            grpPersonales.Controls.Add(txtNombre);
            grpPersonales.Controls.Add(txtApellido);
            grpPersonales.Controls.Add(lblApellido);
            grpPersonales.Location = new Point(31, 54);
            grpPersonales.Name = "grpPersonales";
            grpPersonales.Size = new Size(344, 338);
            grpPersonales.TabIndex = 7;
            grpPersonales.TabStop = false;
            grpPersonales.Text = "Requeridos";
            // 
            // grpGenero
            // 
            grpGenero.Controls.Add(rdbFemenino);
            grpGenero.Controls.Add(rdbMasculino);
            grpGenero.Location = new Point(32, 174);
            grpGenero.Name = "grpGenero";
            grpGenero.Size = new Size(269, 52);
            grpGenero.TabIndex = 19;
            grpGenero.TabStop = false;
            grpGenero.Text = "Genero";
            // 
            // rdbFemenino
            // 
            rdbFemenino.AutoSize = true;
            rdbFemenino.Location = new Point(179, 22);
            rdbFemenino.Name = "rdbFemenino";
            rdbFemenino.Size = new Size(78, 19);
            rdbFemenino.TabIndex = 7;
            rdbFemenino.Text = "Femenino";
            rdbFemenino.UseVisualStyleBackColor = true;
            // 
            // rdbMasculino
            // 
            rdbMasculino.AutoSize = true;
            rdbMasculino.Checked = true;
            rdbMasculino.Location = new Point(15, 22);
            rdbMasculino.Name = "rdbMasculino";
            rdbMasculino.Size = new Size(80, 19);
            rdbMasculino.TabIndex = 6;
            rdbMasculino.TabStop = true;
            rdbMasculino.Text = "Masculino";
            rdbMasculino.UseVisualStyleBackColor = true;
            // 
            // dtpFecNac
            // 
            dtpFecNac.Location = new Point(24, 302);
            dtpFecNac.Name = "dtpFecNac";
            dtpFecNac.Size = new Size(269, 23);
            dtpFecNac.TabIndex = 9;
            // 
            // cmbTipoUsuario
            // 
            cmbTipoUsuario.AccessibleDescription = "Seleccione el tipo de usuario";
            cmbTipoUsuario.FormattingEnabled = true;
            cmbTipoUsuario.Location = new Point(24, 253);
            cmbTipoUsuario.Name = "cmbTipoUsuario";
            cmbTipoUsuario.Size = new Size(197, 23);
            cmbTipoUsuario.TabIndex = 8;
            cmbTipoUsuario.SelectedIndexChanged += cmbTipoUsuario_SelectedIndexChanged;
            // 
            // lblFecNac
            // 
            lblFecNac.AutoSize = true;
            lblFecNac.Location = new Point(24, 284);
            lblFecNac.Name = "lblFecNac";
            lblFecNac.Size = new Size(119, 15);
            lblFecNac.TabIndex = 15;
            lblFecNac.Text = "Fecha de Nacimiento";
            // 
            // lblTipoUsuario
            // 
            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.Location = new Point(24, 235);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new Size(90, 15);
            lblTipoUsuario.TabIndex = 13;
            lblTipoUsuario.Text = "Tipo de Usuario";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(32, 148);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(104, 145);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(197, 23);
            txtEmail.TabIndex = 5;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(32, 119);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(53, 15);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(104, 116);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(197, 23);
            txtTelefono.TabIndex = 4;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            // 
            // grpUbicacion
            // 
            grpUbicacion.Controls.Add(cmbLocalidad);
            grpUbicacion.Controls.Add(cmbPartidoMunicipio);
            grpUbicacion.Controls.Add(cmbProvincia);
            grpUbicacion.Controls.Add(cmbNacionalidad);
            grpUbicacion.Controls.Add(lblDepartamento);
            grpUbicacion.Controls.Add(txtDepartamento);
            grpUbicacion.Controls.Add(lblPiso);
            grpUbicacion.Controls.Add(txtPiso);
            grpUbicacion.Controls.Add(lblAltura);
            grpUbicacion.Controls.Add(txtAltura);
            grpUbicacion.Controls.Add(lblCalle);
            grpUbicacion.Controls.Add(txtCalle);
            grpUbicacion.Controls.Add(lblCodPostal);
            grpUbicacion.Controls.Add(txtCodPostal);
            grpUbicacion.Controls.Add(lblLocalidad);
            grpUbicacion.Controls.Add(lblPartidoMunicipio);
            grpUbicacion.Controls.Add(lblNacionalidad);
            grpUbicacion.Controls.Add(lblProvincia);
            grpUbicacion.Location = new Point(391, 54);
            grpUbicacion.Name = "grpUbicacion";
            grpUbicacion.Size = new Size(329, 289);
            grpUbicacion.TabIndex = 17;
            grpUbicacion.TabStop = false;
            grpUbicacion.Text = "Extras";
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.AccessibleDescription = "Seleccione la Localidad";
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(142, 116);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(159, 23);
            cmbLocalidad.TabIndex = 13;
            // 
            // cmbPartidoMunicipio
            // 
            cmbPartidoMunicipio.AccessibleDescription = "Seleccione el Municipio";
            cmbPartidoMunicipio.FormattingEnabled = true;
            cmbPartidoMunicipio.Location = new Point(142, 87);
            cmbPartidoMunicipio.Name = "cmbPartidoMunicipio";
            cmbPartidoMunicipio.Size = new Size(159, 23);
            cmbPartidoMunicipio.TabIndex = 12;
            cmbPartidoMunicipio.SelectedIndexChanged += cmbPartidoMunicipio_SelectedIndexChanged;
            // 
            // cmbProvincia
            // 
            cmbProvincia.AccessibleDescription = "Seleccione la Provincia";
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Location = new Point(142, 58);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(159, 23);
            cmbProvincia.TabIndex = 11;
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            // 
            // cmbNacionalidad
            // 
            cmbNacionalidad.AccessibleDescription = "Seleccione la Nacionalidad";
            cmbNacionalidad.FormattingEnabled = true;
            cmbNacionalidad.Location = new Point(142, 29);
            cmbNacionalidad.Name = "cmbNacionalidad";
            cmbNacionalidad.Size = new Size(159, 23);
            cmbNacionalidad.TabIndex = 10;
            cmbNacionalidad.SelectedIndexChanged += cmbNacionalidad_SelectedIndexChanged;
            // 
            // lblDepartamento
            // 
            lblDepartamento.AutoSize = true;
            lblDepartamento.Location = new Point(32, 264);
            lblDepartamento.Name = "lblDepartamento";
            lblDepartamento.Size = new Size(83, 15);
            lblDepartamento.TabIndex = 17;
            lblDepartamento.Text = "Departamento";
            // 
            // txtDepartamento
            // 
            txtDepartamento.Location = new Point(142, 261);
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(159, 23);
            txtDepartamento.TabIndex = 18;
            // 
            // lblPiso
            // 
            lblPiso.AutoSize = true;
            lblPiso.Location = new Point(32, 235);
            lblPiso.Name = "lblPiso";
            lblPiso.Size = new Size(29, 15);
            lblPiso.TabIndex = 15;
            lblPiso.Text = "Piso";
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(142, 232);
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(159, 23);
            txtPiso.TabIndex = 17;
            // 
            // lblAltura
            // 
            lblAltura.AutoSize = true;
            lblAltura.Location = new Point(32, 206);
            lblAltura.Name = "lblAltura";
            lblAltura.Size = new Size(39, 15);
            lblAltura.TabIndex = 13;
            lblAltura.Text = "Altura";
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(142, 203);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(159, 23);
            txtAltura.TabIndex = 16;
            // 
            // lblCalle
            // 
            lblCalle.AutoSize = true;
            lblCalle.Location = new Point(32, 177);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(33, 15);
            lblCalle.TabIndex = 11;
            lblCalle.Text = "Calle";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(142, 174);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(159, 23);
            txtCalle.TabIndex = 15;
            // 
            // lblCodPostal
            // 
            lblCodPostal.AutoSize = true;
            lblCodPostal.Location = new Point(32, 148);
            lblCodPostal.Name = "lblCodPostal";
            lblCodPostal.Size = new Size(81, 15);
            lblCodPostal.TabIndex = 9;
            lblCodPostal.Text = "Código Postal";
            // 
            // txtCodPostal
            // 
            txtCodPostal.Location = new Point(142, 145);
            txtCodPostal.Name = "txtCodPostal";
            txtCodPostal.Size = new Size(159, 23);
            txtCodPostal.TabIndex = 14;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(32, 119);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(58, 15);
            lblLocalidad.TabIndex = 7;
            lblLocalidad.Text = "Localidad";
            // 
            // lblPartidoMunicipio
            // 
            lblPartidoMunicipio.AutoSize = true;
            lblPartidoMunicipio.Location = new Point(32, 90);
            lblPartidoMunicipio.Name = "lblPartidoMunicipio";
            lblPartidoMunicipio.Size = new Size(104, 15);
            lblPartidoMunicipio.TabIndex = 5;
            lblPartidoMunicipio.Text = "Partido/Municipio";
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Location = new Point(32, 32);
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.Size = new Size(77, 15);
            lblNacionalidad.TabIndex = 1;
            lblNacionalidad.Text = "Nacionalidad";
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(32, 61);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(56, 15);
            lblProvincia.TabIndex = 3;
            lblProvincia.Text = "Provincia";
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new Point(391, 349);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(202, 41);
            btnGuardarCambios.TabIndex = 19;
            btnGuardarCambios.Text = "Guardar Cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Click += btnAceptar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(599, 7);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 40);
            btnVolver.TabIndex = 21;
            btnVolver.Text = "Volver al Menu Principal";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnEditarContrasena
            // 
            btnEditarContrasena.Location = new Point(599, 349);
            btnEditarContrasena.Name = "btnEditarContrasena";
            btnEditarContrasena.Size = new Size(121, 40);
            btnEditarContrasena.TabIndex = 22;
            btnEditarContrasena.Text = "Editar Clave de Acceso";
            btnEditarContrasena.UseVisualStyleBackColor = true;
            btnEditarContrasena.Click += btnEditarContrasena_Click;
            // 
            // cmbUsuarioEditado
            // 
            cmbUsuarioEditado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioEditado.FormattingEnabled = true;
            cmbUsuarioEditado.Location = new Point(200, 12);
            cmbUsuarioEditado.Name = "cmbUsuarioEditado";
            cmbUsuarioEditado.Size = new Size(201, 23);
            cmbUsuarioEditado.TabIndex = 23;
            cmbUsuarioEditado.SelectedIndexChanged += cmbUsuarioEditado_SelectedIndexChanged;
            // 
            // frmEditarPerfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(747, 406);
            Controls.Add(cmbUsuarioEditado);
            Controls.Add(btnEditarContrasena);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardarCambios);
            Controls.Add(grpUbicacion);
            Controls.Add(grpPersonales);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmEditarPerfil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Usuario";
            grpPersonales.ResumeLayout(false);
            grpPersonales.PerformLayout();
            grpGenero.ResumeLayout(false);
            grpGenero.PerformLayout();
            grpUbicacion.ResumeLayout(false);
            grpUbicacion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtDNI;
        private Label lblDNI;
        private GroupBox grpPersonales;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFecNac;
        private Label lblTipoUsuario;
        private GroupBox grpUbicacion;
        private Label lblPiso;
        private TextBox txtPiso;
        private Label lblAltura;
        private TextBox txtAltura;
        private Label lblCalle;
        private TextBox txtCalle;
        private Label lblCodPostal;
        private TextBox txtCodPostal;
        private Label lblLocalidad;
        private Label lblPartidoMunicipio;
        private Label lblNacionalidad;
        private Label lblProvincia;
        private ComboBox cmbTipoUsuario;
        private GroupBox grpGenero;
        private RadioButton rdbFemenino;
        private RadioButton rdbMasculino;
        private DateTimePicker dtpFecNac;
        private Button btnGuardarCambios;
        private Label lblDepartamento;
        private TextBox txtDepartamento;
        private ComboBox cmbLocalidad;
        private ComboBox cmbPartidoMunicipio;
        private ComboBox cmbProvincia;
        private ComboBox cmbNacionalidad;
        private Button btnVolver;
        private Button btnEditarContrasena;
        private ComboBox cmbUsuarioEditado;
    }
}