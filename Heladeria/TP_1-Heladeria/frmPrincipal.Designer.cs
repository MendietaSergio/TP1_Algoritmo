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
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 18F);
            lblBienvenida.Location = new Point(12, 47);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(134, 32);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(272, 98);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(75, 46);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(272, 47);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(75, 46);
            btnEditarPerfil.TabIndex = 2;
            btnEditarPerfil.Text = "Editar Perfil";
            btnEditarPerfil.UseVisualStyleBackColor = true;
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 18F);
            lblUsuario.Location = new Point(12, 79);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(134, 32);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Bienvenido";
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Location = new Point(12, 150);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(335, 46);
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
            btnCerrar.Location = new Point(311, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(36, 37);
            btnCerrar.TabIndex = 25;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 205);
            Controls.Add(btnCerrar);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(btnEditarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblBienvenida);
            FormBorderStyle = FormBorderStyle.None;
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
    }
}