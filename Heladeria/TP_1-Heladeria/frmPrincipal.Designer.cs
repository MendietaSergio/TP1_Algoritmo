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
            btnCerrar = new Button();
            btnEditarPerfil = new Button();
            btnCambiarContrasena = new Button();
            btnEditarPerfiles = new Button();
            btnRegistrarUsuario = new Button();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 13F);
            lblBienvenida.Location = new Point(15, 18);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(106, 25);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido,";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblUsuario.Location = new Point(15, 43);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(84, 28);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(230, 20);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(105, 34);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.DarkRed;
            btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(345, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(32, 28);
            btnCerrar.TabIndex = 25;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(15, 88);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(170, 42);
            btnEditarPerfil.TabIndex = 1;
            btnEditarPerfil.Text = "Editar Mi Perfil";
            btnEditarPerfil.UseVisualStyleBackColor = true;
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // btnCambiarContrasena
            // 
            btnCambiarContrasena.Location = new Point(195, 88);
            btnCambiarContrasena.Name = "btnCambiarContrasena";
            btnCambiarContrasena.Size = new Size(170, 42);
            btnCambiarContrasena.TabIndex = 2;
            btnCambiarContrasena.Text = "Cambiar Contraseña";
            btnCambiarContrasena.UseVisualStyleBackColor = true;
            btnCambiarContrasena.Click += btnCambiarContrasena_Click;
            // 
            // btnEditarPerfiles
            // 
            btnEditarPerfiles.Location = new Point(15, 142);
            btnEditarPerfiles.Name = "btnEditarPerfiles";
            btnEditarPerfiles.Size = new Size(350, 42);
            btnEditarPerfiles.TabIndex = 3;
            btnEditarPerfiles.Text = "Editar Perfiles (Admin)";
            btnEditarPerfiles.UseVisualStyleBackColor = true;
            btnEditarPerfiles.Click += btnEditarPerfiles_Click;
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Location = new Point(15, 194);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(350, 42);
            btnRegistrarUsuario.TabIndex = 4;
            btnRegistrarUsuario.Text = "Registrar Nuevo Usuario";
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 250);
            Controls.Add(btnCerrar);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(btnEditarPerfiles);
            Controls.Add(btnCambiarContrasena);
            Controls.Add(btnEditarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblUsuario);
            Controls.Add(lblBienvenida);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Label lblUsuario;
        private Button btnCerrarSesion;
        private Button btnCerrar;
        private Button btnEditarPerfil;
        private Button btnCambiarContrasena;
        private Button btnEditarPerfiles;
        private Button btnRegistrarUsuario;
    }
}
