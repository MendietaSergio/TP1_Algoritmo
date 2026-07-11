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
            btnAtras = new Button();
            imgShow1 = new PictureBox();
            imgHide1 = new PictureBox();
            imgShow2 = new PictureBox();
            imgHide2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imgShow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgHide1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgShow2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgHide2).BeginInit();
            SuspendLayout();
            // 
            // lblTituloRecuperacion
            // 
            lblTituloRecuperacion.AutoSize = true;
            lblTituloRecuperacion.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRecuperacion.Location = new Point(141, 17);
            lblTituloRecuperacion.Margin = new Padding(2, 0, 2, 0);
            lblTituloRecuperacion.Name = "lblTituloRecuperacion";
            lblTituloRecuperacion.Size = new Size(266, 25);
            lblTituloRecuperacion.TabIndex = 0;
            lblTituloRecuperacion.Text = "Recuperación de Contraseña";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(29, 54);
            lblEstado.Margin = new Padding(2, 0, 2, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(238, 21);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Ingrese su email para comenzar";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(29, 108);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(29, 139);
            lblCodigo.Margin = new Padding(2, 0, 2, 0);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(137, 15);
            lblCodigo.TabIndex = 3;
            lblCodigo.Text = "Código de recuperación:";
            // 
            // lblNuevaContra
            // 
            lblNuevaContra.AutoSize = true;
            lblNuevaContra.Location = new Point(29, 186);
            lblNuevaContra.Margin = new Padding(2, 0, 2, 0);
            lblNuevaContra.Name = "lblNuevaContra";
            lblNuevaContra.Size = new Size(107, 15);
            lblNuevaContra.TabIndex = 4;
            lblNuevaContra.Text = "Nueva Contraseña:";
            // 
            // lblConfirmarContra
            // 
            lblConfirmarContra.AutoSize = true;
            lblConfirmarContra.Location = new Point(29, 229);
            lblConfirmarContra.Margin = new Padding(2, 0, 2, 0);
            lblConfirmarContra.Name = "lblConfirmarContra";
            lblConfirmarContra.Size = new Size(127, 15);
            lblConfirmarContra.TabIndex = 5;
            lblConfirmarContra.Text = "Confirmar Contraseña:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(181, 104);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(106, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtCodigo
            // 
            txtCodigo.Enabled = false;
            txtCodigo.Location = new Point(181, 135);
            txtCodigo.Margin = new Padding(2);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(106, 23);
            txtCodigo.TabIndex = 3;
            // 
            // txtNuevaContra
            // 
            txtNuevaContra.Enabled = false;
            txtNuevaContra.Location = new Point(181, 182);
            txtNuevaContra.Margin = new Padding(2);
            txtNuevaContra.Name = "txtNuevaContra";
            txtNuevaContra.PasswordChar = '*';
            txtNuevaContra.Size = new Size(106, 23);
            txtNuevaContra.TabIndex = 5;
            // 
            // txtConfirmarContra
            // 
            txtConfirmarContra.Enabled = false;
            txtConfirmarContra.Location = new Point(181, 226);
            txtConfirmarContra.Margin = new Padding(2);
            txtConfirmarContra.Name = "txtConfirmarContra";
            txtConfirmarContra.PasswordChar = '*';
            txtConfirmarContra.Size = new Size(106, 23);
            txtConfirmarContra.TabIndex = 6;
            // 
            // btnEnviarCodigo
            // 
            btnEnviarCodigo.Location = new Point(334, 107);
            btnEnviarCodigo.Margin = new Padding(2);
            btnEnviarCodigo.Name = "btnEnviarCodigo";
            btnEnviarCodigo.Size = new Size(188, 20);
            btnEnviarCodigo.TabIndex = 2;
            btnEnviarCodigo.Text = "Enviar Código";
            btnEnviarCodigo.UseVisualStyleBackColor = true;
            btnEnviarCodigo.Click += btnEnviarCodigo_Click;
            // 
            // btnValidarCodigo
            // 
            btnValidarCodigo.Enabled = false;
            btnValidarCodigo.Location = new Point(334, 138);
            btnValidarCodigo.Margin = new Padding(2);
            btnValidarCodigo.Name = "btnValidarCodigo";
            btnValidarCodigo.Size = new Size(188, 20);
            btnValidarCodigo.TabIndex = 4;
            btnValidarCodigo.Text = "Validar Código";
            btnValidarCodigo.UseVisualStyleBackColor = true;
            btnValidarCodigo.Click += btnValidarCodigo_Click;
            // 
            // btnGuardarContra
            // 
            btnGuardarContra.Enabled = false;
            btnGuardarContra.Location = new Point(334, 224);
            btnGuardarContra.Margin = new Padding(2);
            btnGuardarContra.Name = "btnGuardarContra";
            btnGuardarContra.Size = new Size(188, 20);
            btnGuardarContra.TabIndex = 7;
            btnGuardarContra.Text = "Guardar Nueva Contraseña";
            btnGuardarContra.UseVisualStyleBackColor = true;
            btnGuardarContra.Click += btnGuardarContra_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.FromArgb(192, 0, 0);
            lblError.Location = new Point(29, 258);
            lblError.Margin = new Padding(2, 0, 2, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(32, 15);
            lblError.TabIndex = 12;
            lblError.Text = "Error";
            // 
            // btnAtras
            // 
            btnAtras.BackColor = Color.DarkRed;
            btnAtras.ForeColor = Color.White;
            btnAtras.Location = new Point(511, 12);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(36, 37);
            btnAtras.TabIndex = 23;
            btnAtras.Text = "X";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += btnAtras_Click;
            // 
            // imgShow1
            // 
            imgShow1.Image = Properties.Resources.ojo;
            imgShow1.Location = new Point(291, 179);
            imgShow1.Name = "imgShow1";
            imgShow1.Size = new Size(33, 30);
            imgShow1.TabIndex = 24;
            imgShow1.TabStop = false;
            imgShow1.Click += imgShow1_Click;
            // 
            // imgHide1
            // 
            imgHide1.Image = Properties.Resources.cerrar_ojo;
            imgHide1.Location = new Point(292, 179);
            imgHide1.Name = "imgHide1";
            imgHide1.Size = new Size(32, 32);
            imgHide1.SizeMode = PictureBoxSizeMode.AutoSize;
            imgHide1.TabIndex = 25;
            imgHide1.TabStop = false;
            imgHide1.Visible = false;
            imgHide1.Click += imgHide1_Click;
            // 
            // imgShow2
            // 
            imgShow2.Image = Properties.Resources.ojo;
            imgShow2.Location = new Point(292, 222);
            imgShow2.Name = "imgShow2";
            imgShow2.Size = new Size(32, 32);
            imgShow2.SizeMode = PictureBoxSizeMode.AutoSize;
            imgShow2.TabIndex = 26;
            imgShow2.TabStop = false;
            imgShow2.Click += imgShow2_Click;
            // 
            // imgHide2
            // 
            imgHide2.Image = Properties.Resources.cerrar_ojo;
            imgHide2.Location = new Point(292, 222);
            imgHide2.Name = "imgHide2";
            imgHide2.Size = new Size(32, 32);
            imgHide2.SizeMode = PictureBoxSizeMode.AutoSize;
            imgHide2.TabIndex = 27;
            imgHide2.TabStop = false;
            imgHide2.Visible = false;
            imgHide2.Click += imgHide2_Click;
            // 
            // frmRecuperarContrasena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 355);
            Controls.Add(imgHide2);
            Controls.Add(imgShow2);
            Controls.Add(imgHide1);
            Controls.Add(imgShow1);
            Controls.Add(btnAtras);
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
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRecuperarContrasena";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuprar Contrasenia";
            ((System.ComponentModel.ISupportInitialize)imgShow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgHide1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgShow2).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgHide2).EndInit();
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
        private Button btnAtras;
        private PictureBox imgShow1;
        private PictureBox imgHide1;
        private PictureBox imgShow2;
        private PictureBox imgHide2;
    }
}