namespace TP_1_Heladeria
{
    partial class frmCambioContrasena
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
            lblInfo = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            btnLimpiar = new Button();
            btnContinuar = new Button();
            label7 = new Label();
            label8 = new Label();
            txtPass = new TextBox();
            txtPass2 = new TextBox();
            imgHideConf = new PictureBox();
            imgShowContrasena = new PictureBox();
            imgShowConf = new PictureBox();
            imgHideContrasena = new PictureBox();
            lblError = new Label();
            btnAtras = new Button();
            ((System.ComponentModel.ISupportInitialize)imgHideConf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgShowContrasena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgShowConf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgHideContrasena).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(171, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(223, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "¡ Bienvenido !";
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfo.Location = new Point(27, 60);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(496, 51);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Te informamos que al ingresar por primera vez, tenes que cambiar la contraseña a una mas segura para poder continuar\r\n ";
            lblInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Arial", 9.75F);
            label4.Location = new Point(38, 319);
            label4.Name = "label4";
            label4.Size = new Size(173, 23);
            label4.TabIndex = 3;
            label4.Text = "Minimo  de 8 caracteres.";
            // 
            // label5
            // 
            label5.Font = new Font("Arial", 9.75F);
            label5.Location = new Point(38, 296);
            label5.Name = "label5";
            label5.Size = new Size(173, 23);
            label5.TabIndex = 4;
            label5.Text = "Los campos deben coincidir.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 268);
            label3.Name = "label3";
            label3.Size = new Size(289, 19);
            label3.TabIndex = 6;
            label3.Text = "Respetando las reglas de validaciones:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 128, 0);
            btnLimpiar.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(38, 396);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(201, 47);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.Green;
            btnContinuar.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnContinuar.ForeColor = Color.White;
            btnContinuar.Location = new Point(303, 396);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(201, 47);
            btnContinuar.TabIndex = 3;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(65, 137);
            label7.Name = "label7";
            label7.Size = new Size(77, 16);
            label7.TabIndex = 9;
            label7.Text = "Contraseña:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(65, 187);
            label8.Name = "label8";
            label8.Size = new Size(130, 16);
            label8.TabIndex = 10;
            label8.Text = "Repeti la contraseña:";
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.Location = new Point(224, 135);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(138, 22);
            txtPass.TabIndex = 1;
            // 
            // txtPass2
            // 
            txtPass2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass2.Location = new Point(224, 184);
            txtPass2.Name = "txtPass2";
            txtPass2.PasswordChar = '*';
            txtPass2.Size = new Size(138, 22);
            txtPass2.TabIndex = 2;
            // 
            // imgHideConf
            // 
            imgHideConf.Image = Properties.Resources.cerrar_ojo;
            imgHideConf.Location = new Point(368, 174);
            imgHideConf.Name = "imgHideConf";
            imgHideConf.Size = new Size(32, 32);
            imgHideConf.SizeMode = PictureBoxSizeMode.AutoSize;
            imgHideConf.TabIndex = 21;
            imgHideConf.TabStop = false;
            imgHideConf.Visible = false;
            imgHideConf.Click += imgHideConf_Click;
            // 
            // imgShowContrasena
            // 
            imgShowContrasena.Image = Properties.Resources.ojo;
            imgShowContrasena.Location = new Point(368, 125);
            imgShowContrasena.Name = "imgShowContrasena";
            imgShowContrasena.Size = new Size(32, 32);
            imgShowContrasena.SizeMode = PictureBoxSizeMode.AutoSize;
            imgShowContrasena.TabIndex = 20;
            imgShowContrasena.TabStop = false;
            imgShowContrasena.Click += imgShowContrasena_Click;
            // 
            // imgShowConf
            // 
            imgShowConf.Image = Properties.Resources.ojo;
            imgShowConf.Location = new Point(368, 174);
            imgShowConf.Name = "imgShowConf";
            imgShowConf.Size = new Size(32, 32);
            imgShowConf.SizeMode = PictureBoxSizeMode.AutoSize;
            imgShowConf.TabIndex = 19;
            imgShowConf.TabStop = false;
            imgShowConf.Click += imgShowConf_Click;
            // 
            // imgHideContrasena
            // 
            imgHideContrasena.Image = Properties.Resources.cerrar_ojo;
            imgHideContrasena.Location = new Point(368, 125);
            imgHideContrasena.Name = "imgHideContrasena";
            imgHideContrasena.Size = new Size(32, 32);
            imgHideContrasena.SizeMode = PictureBoxSizeMode.AutoSize;
            imgHideContrasena.TabIndex = 18;
            imgHideContrasena.TabStop = false;
            imgHideContrasena.Visible = false;
            imgHideContrasena.Click += imgHideContrasena_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.FromArgb(192, 0, 0);
            lblError.Location = new Point(184, 357);
            lblError.Name = "lblError";
            lblError.Size = new Size(53, 16);
            lblError.TabIndex = 17;
            lblError.Text = "Errores:";
            // 
            // btnAtras
            // 
            btnAtras.BackColor = Color.DarkRed;
            btnAtras.ForeColor = Color.White;
            btnAtras.Location = new Point(500, 8);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(36, 37);
            btnAtras.TabIndex = 22;
            btnAtras.Text = "X";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Visible = false;
            btnAtras.Click += btnAtras_Click;
            // 
            // frmCambioContrasena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 468);
            Controls.Add(btnAtras);
            Controls.Add(lblError);
            Controls.Add(imgHideContrasena);
            Controls.Add(imgShowConf);
            Controls.Add(imgShowContrasena);
            Controls.Add(imgHideConf);
            Controls.Add(txtPass2);
            Controls.Add(txtPass);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnContinuar);
            Controls.Add(btnLimpiar);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblInfo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCambioContrasena";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambio Contrasenia";
            ((System.ComponentModel.ISupportInitialize)imgHideConf).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgShowContrasena).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgShowConf).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgHideContrasena).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblInfo;
        private Label label4;
        private Label label5;
        private Label label3;
        private Button btnLimpiar;
        private Button btnContinuar;
        private Label label7;
        private Label label8;
        private TextBox txtPass;
        private TextBox txtPass2;
        private PictureBox imgHideConf;
        private PictureBox imgShowContrasena;
        private PictureBox imgShowConf;
        private PictureBox imgHideContrasena;
        private Label lblError;
        private Button btnAtras;
    }
}