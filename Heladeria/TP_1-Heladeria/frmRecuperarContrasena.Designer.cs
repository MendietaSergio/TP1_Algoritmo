namespace TP_1_Heladeria
{
    partial class frmRecuperarContrasena
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
            lblTituloRecuperacion = new Label();
            lblEstado = new Label();
            lblEmail = new Label();
            lblCodigo = new Label();
            lblNuevaContra = new Label();
            lblConfirmarContra = new Label();
            txtEmail = new TextBox();
            txtCodigo = new TextBox();
            txtNuevaContra = new TextBox();
            txtConfirmarContra = new TextBox();
            btnEnviarCodigo = new Button();
            btnValidarCodigo = new Button();
            btnGuardarContra = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblTituloRecuperacion
            // 
            lblTituloRecuperacion.AutoSize = true;
            lblTituloRecuperacion.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRecuperacion.Location = new Point(202, 28);
            lblTituloRecuperacion.Name = "lblTituloRecuperacion";
            lblTituloRecuperacion.Size = new Size(387, 38);
            lblTituloRecuperacion.TabIndex = 0;
            lblTituloRecuperacion.Text = "Recuperación de Contraseña";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(42, 90);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(361, 32);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Ingrese su email para comenzar";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(42, 168);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(42, 208);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(206, 25);
            lblCodigo.TabIndex = 3;
            lblCodigo.Text = "Código de recuperación:";
            // 
            // lblNuevaContra
            // 
            lblNuevaContra.AutoSize = true;
            lblNuevaContra.Location = new Point(42, 245);
            lblNuevaContra.Name = "lblNuevaContra";
            lblNuevaContra.Size = new Size(160, 25);
            lblNuevaContra.TabIndex = 4;
            lblNuevaContra.Text = "Nueva Contraseña:";
            // 
            // lblConfirmarContra
            // 
            lblConfirmarContra.AutoSize = true;
            lblConfirmarContra.Location = new Point(42, 282);
            lblConfirmarContra.Name = "lblConfirmarContra";
            lblConfirmarContra.Size = new Size(189, 25);
            lblConfirmarContra.TabIndex = 5;
            lblConfirmarContra.Text = "Confirmar Contraseña:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(258, 162);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 6;
            // 
            // txtCodigo
            // 
            txtCodigo.Enabled = false;
            txtCodigo.Location = new Point(258, 202);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(150, 31);
            txtCodigo.TabIndex = 7;
            // 
            // txtNuevaContra
            // 
            txtNuevaContra.Enabled = false;
            txtNuevaContra.Location = new Point(258, 239);
            txtNuevaContra.Name = "txtNuevaContra";
            txtNuevaContra.Size = new Size(150, 31);
            txtNuevaContra.TabIndex = 8;
            // 
            // txtConfirmarContra
            // 
            txtConfirmarContra.Enabled = false;
            txtConfirmarContra.Location = new Point(258, 276);
            txtConfirmarContra.Name = "txtConfirmarContra";
            txtConfirmarContra.Size = new Size(150, 31);
            txtConfirmarContra.TabIndex = 9;
            // 
            // btnEnviarCodigo
            // 
            btnEnviarCodigo.Location = new Point(477, 159);
            btnEnviarCodigo.Name = "btnEnviarCodigo";
            btnEnviarCodigo.Size = new Size(269, 34);
            btnEnviarCodigo.TabIndex = 10;
            btnEnviarCodigo.Text = "Enviar Código";
            btnEnviarCodigo.UseVisualStyleBackColor = true;
            btnEnviarCodigo.Click += btnEnviarCodigo_Click;
            // 
            // btnValidarCodigo
            // 
            btnValidarCodigo.Enabled = false;
            btnValidarCodigo.Location = new Point(477, 199);
            btnValidarCodigo.Name = "btnValidarCodigo";
            btnValidarCodigo.Size = new Size(269, 34);
            btnValidarCodigo.TabIndex = 11;
            btnValidarCodigo.Text = "Validar Código";
            btnValidarCodigo.UseVisualStyleBackColor = true;
            btnValidarCodigo.Click += btnValidarCodigo_Click;
            // 
            // btnGuardarContra
            // 
            btnGuardarContra.Enabled = false;
            btnGuardarContra.Location = new Point(477, 273);
            btnGuardarContra.Name = "btnGuardarContra";
            btnGuardarContra.Size = new Size(269, 34);
            btnGuardarContra.TabIndex = 6;
            btnGuardarContra.Text = "Guardar Nueva Contraseña";
            btnGuardarContra.UseVisualStyleBackColor = true;
            btnGuardarContra.Click += btnGuardarContra_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.FromArgb(192, 0, 0);
            lblError.Location = new Point(42, 330);
            lblError.Name = "lblError";
            lblError.Size = new Size(50, 25);
            lblError.TabIndex = 12;
            lblError.Text = "Error";
            // 
            // frmRecuperarContrasena
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 390);
            Controls.Add(lblError);
            Controls.Add(btnGuardarContra);
            Controls.Add(btnValidarCodigo);
            Controls.Add(btnEnviarCodigo);
            Controls.Add(txtConfirmarContra);
            Controls.Add(txtNuevaContra);
            Controls.Add(txtCodigo);
            Controls.Add(txtEmail);
            Controls.Add(lblConfirmarContra);
            Controls.Add(lblNuevaContra);
            Controls.Add(lblCodigo);
            Controls.Add(lblEmail);
            Controls.Add(lblEstado);
            Controls.Add(lblTituloRecuperacion);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRecuperarContrasena";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuprar Contrasenia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloRecuperacion;
        private Label lblEstado;
        private Label lblEmail;
        private Label lblCodigo;
        private Label lblNuevaContra;
        private Label lblConfirmarContra;
        private TextBox txtEmail;
        private TextBox txtCodigo;
        private TextBox txtNuevaContra;
        private TextBox txtConfirmarContra;
        private Button btnEnviarCodigo;
        private Button btnValidarCodigo;
        private Button btnGuardarContra;
        private Label lblError;
    }
}