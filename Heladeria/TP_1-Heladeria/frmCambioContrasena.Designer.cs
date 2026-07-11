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
            imgShow1 = new PictureBox();
            imgShow2 = new PictureBox();
            imgHide2 = new PictureBox();
            imgHide1 = new PictureBox();
            lblError = new Label();
            btnAtras = new Button();
            ((System.ComponentModel.ISupportInitialize)imgShow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgShow2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgHide2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgHide1).BeginInit();
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
            btnLimpiar.TabIndex = 7;
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
            btnContinuar.TabIndex = 8;
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
            txtPass.TabIndex = 11;
            // 
            // txtPass2
            // 
            txtPass2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass2.Location = new Point(224, 184);
            txtPass2.Name = "txtPass2";
            txtPass2.PasswordChar = '*';
            txtPass2.Size = new Size(138, 22);
            txtPass2.TabIndex = 12;
            // 
            // imgShow1
            // 
            imgShow1.Location = new Point(0, 0);
            imgShow1.Name = "imgShow1";
            imgShow1.Size = new Size(100, 50);
            imgShow1.TabIndex = 21;
            imgShow1.TabStop = false;
            // 
            // imgShow2
            // 
            imgShow2.Location = new Point(0, 0);
            imgShow2.Name = "imgShow2";
            imgShow2.Size = new Size(100, 50);
            imgShow2.TabIndex = 20;
            imgShow2.TabStop = false;
            // 
            // imgHide2
            // 
            imgHide2.Location = new Point(368, 180);
            imgHide2.Name = "imgHide2";
            imgHide2.Size = new Size(100, 50);
            imgHide2.TabIndex = 19;
            imgHide2.TabStop = false;
            // 
            // imgHide1
            // 
            imgHide1.Location = new Point(368, 124);
            imgHide1.Name = "imgHide1";
            imgHide1.Size = new Size(100, 50);
            imgHide1.TabIndex = 18;
            imgHide1.TabStop = false;
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
            Controls.Add(imgHide1);
            Controls.Add(imgHide2);
            Controls.Add(imgShow2);
            Controls.Add(imgShow1);
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
            ((System.ComponentModel.ISupportInitialize)imgShow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgShow2).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgHide2).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgHide1).EndInit();
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
        private PictureBox imgShow1;
        private PictureBox imgShow2;
        private PictureBox imgHide2;
        private PictureBox imgHide1;
        private Label lblError;
        private Button btnAtras;
    }
}