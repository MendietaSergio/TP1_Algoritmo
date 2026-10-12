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
            btnCerrarSesion = new Button();
            btnEditarPerfil = new Button();
            lblUsuario = new Label();
            btnRegistrarUsuario = new Button();
            btnCerrar = new Button();
            btnCambiarContraseña = new Button();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 18F);
            lblBienvenida.Location = new Point(14, 63);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(165, 41);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(294, 131);
            btnCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(103, 61);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(294, 63);
            btnEditarPerfil.Margin = new Padding(3, 4, 3, 4);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(103, 61);
            btnEditarPerfil.TabIndex = 2;
            btnEditarPerfil.Text = "Editar Perfil";
            btnEditarPerfil.UseVisualStyleBackColor = true;
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 18F);
            lblUsuario.Location = new Point(14, 105);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(165, 41);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Bienvenido";
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Location = new Point(14, 200);
            btnRegistrarUsuario.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(274, 61);
            btnRegistrarUsuario.TabIndex = 1;
            btnRegistrarUsuario.Text = "Registrar Usuarios";
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.DarkRed;
            btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(355, 5);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(41, 49);
            btnCerrar.TabIndex = 25;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.Location = new Point(294, 200);
            btnCambiarContraseña.Name = "btnCambiarContraseña";
            btnCambiarContraseña.Size = new Size(102, 61);
            btnCambiarContraseña.TabIndex = 26;
            btnCambiarContraseña.Text = "Cambiar Contraseña";
            btnCambiarContraseña.UseVisualStyleBackColor = true;
            btnCambiarContraseña.Click += btnCambiarContraseña_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 273);
            Controls.Add(btnCambiarContraseña);
            Controls.Add(btnCerrar);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(btnEditarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblBienvenida);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Button btnCerrarSesion;
        private Button btnEditarPerfil;
        private Label lblUsuario;
        private Button btnRegistrarUsuario;
        private Button btnCerrar;
        private Button btnCambiarContraseña;
    }
}