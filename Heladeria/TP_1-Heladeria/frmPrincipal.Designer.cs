namespace TP_1_Heladeria
{
    partial class frmPrincipal
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
            lblBienvenida = new Label();
            lblUsuario = new Label();
            btnCerrarSesion = new Button();
            btnEditarPerfil = new Button();
            btnCambiarContrasena = new Button();
            btnEditarPerfiles = new Button();
            btnRegistrarUsuario = new Button();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 12F);
            lblBienvenida.Location = new Point(16, 15);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(93, 21);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido,";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblUsuario.Location = new Point(15, 36);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(84, 28);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(255, 18);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(110, 36);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(16, 80);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(168, 42);
            btnEditarPerfil.TabIndex = 1;
            btnEditarPerfil.Text = "Editar Mi Perfil";
            btnEditarPerfil.UseVisualStyleBackColor = true;
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // btnCambiarContrasena
            // 
            btnCambiarContrasena.Location = new Point(196, 80);
            btnCambiarContrasena.Name = "btnCambiarContrasena";
            btnCambiarContrasena.Size = new Size(169, 42);
            btnCambiarContrasena.TabIndex = 2;
            btnCambiarContrasena.Text = "Cambiar Contraseña";
            btnCambiarContrasena.UseVisualStyleBackColor = true;
            btnCambiarContrasena.Click += btnCambiarContrasena_Click;
            // 
            // btnEditarPerfiles
            // 
            btnEditarPerfiles.Location = new Point(16, 134);
            btnEditarPerfiles.Name = "btnEditarPerfiles";
            btnEditarPerfiles.Size = new Size(349, 42);
            btnEditarPerfiles.TabIndex = 3;
            btnEditarPerfiles.Text = "Editar Perfiles (Admin)";
            btnEditarPerfiles.UseVisualStyleBackColor = true;
            btnEditarPerfiles.Click += btnEditarPerfiles_Click;
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Location = new Point(16, 186);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(349, 42);
            btnRegistrarUsuario.TabIndex = 4;
            btnRegistrarUsuario.Text = "Registrar Nuevo Usuario";
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 245);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(btnEditarPerfiles);
            Controls.Add(btnCambiarContrasena);
            Controls.Add(btnEditarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblUsuario);
            Controls.Add(lblBienvenida);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            FormClosing += frmPrincipal_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Label lblUsuario;
        private Button btnCerrarSesion;
        private Button btnEditarPerfil;
        private Button btnCambiarContrasena;
        private Button btnEditarPerfiles;
        private Button btnRegistrarUsuario;
    }
}
