namespace TP_1_Heladeria
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblContrasenia = new Label();
            lblUsuario = new Label();
            lblLogin = new Label();
            btnInicioSesion = new Button();
            btnSalir = new Button();
            imgHide1 = new PictureBox();
            imgShow1 = new PictureBox();
            txtContrasenia = new TextBox();
            txtUsuario = new TextBox();
            linkOldPass = new LinkLabel();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)imgHide1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgShow1).BeginInit();
            SuspendLayout();
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Location = new Point(40, 180);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(70, 15);
            lblContrasenia.TabIndex = 2;
            lblContrasenia.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(40, 129);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(151, 59);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(94, 40);
            lblLogin.TabIndex = 3;
            lblLogin.Text = "Login";
            // 
            // btnInicioSesion
            // 
            btnInicioSesion.Location = new Point(219, 281);
            btnInicioSesion.Name = "btnInicioSesion";
            btnInicioSesion.Size = new Size(118, 23);
            btnInicioSesion.TabIndex = 4;
            btnInicioSesion.Text = "Iniciar Sesion";
            btnInicioSesion.UseVisualStyleBackColor = true;
            btnInicioSesion.Click += btnInicioSesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(41, 281);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(118, 23);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // imgHide1
            // 
           // imgHide1.Image = Properties.Resources.cerrar_ojo;
            imgHide1.Location = new Point(295, 176);
            imgHide1.Name = "imgHide1";
            imgHide1.Size = new Size(26, 19);
            imgHide1.SizeMode = PictureBoxSizeMode.Zoom;
            imgHide1.TabIndex = 21;
            imgHide1.TabStop = false;
            imgHide1.Click += imgHide1_Click;
            // 
            // imgShow1
            // 
           // imgShow1.Image = Properties.Resources.ojo;
            imgShow1.Location = new Point(295, 176);
            imgShow1.Name = "imgShow1";
            imgShow1.Size = new Size(26, 19);
            imgShow1.SizeMode = PictureBoxSizeMode.Zoom;
            imgShow1.TabIndex = 20;
            imgShow1.TabStop = false;
            imgShow1.Click += imgShow1_Click;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenia.Location = new Point(151, 176);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PasswordChar = '*';
            txtContrasenia.Size = new Size(138, 22);
            txtContrasenia.TabIndex = 18;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(151, 127);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(138, 22);
            txtUsuario.TabIndex = 17;
            // 
            // linkOldPass
            // 
            linkOldPass.AutoSize = true;
            linkOldPass.Location = new Point(120, 329);
            linkOldPass.Name = "linkOldPass";
            linkOldPass.Size = new Size(141, 15);
            linkOldPass.TabIndex = 22;
            linkOldPass.TabStop = true;
            linkOldPass.Text = "¿Olvidaste tu contraseña?";
            linkOldPass.LinkClicked += linkOldPass_LinkClicked;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.FromArgb(192, 0, 0);
            lblError.Location = new Point(84, 228);
            lblError.Name = "lblError";
            lblError.Size = new Size(35, 15);
            lblError.TabIndex = 23;
            lblError.Text = "Error:";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 367);
            Controls.Add(lblError);
            Controls.Add(linkOldPass);
            Controls.Add(imgHide1);
            Controls.Add(imgShow1);
            Controls.Add(txtContrasenia);
            Controls.Add(txtUsuario);
            Controls.Add(btnSalir);
            Controls.Add(btnInicioSesion);
            Controls.Add(lblLogin);
            Controls.Add(lblContrasenia);
            Controls.Add(lblUsuario);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)imgHide1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgShow1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContrasenia;
        private Label lblUsuario;
        private Label lblLogin;
        private Button btnInicioSesion;
        private Button btnSalir;
        private PictureBox imgHide1;
        private PictureBox imgShow1;
        private TextBox txtContrasenia;
        private TextBox txtUsuario;
        private LinkLabel linkOldPass;
        private Label lblError;
    }
}
