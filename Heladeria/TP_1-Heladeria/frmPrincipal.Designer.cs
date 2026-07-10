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
            btnCerraSesion = new Button();
            SuspendLayout();
            // 
            // btnCerraSesion
            // 
            btnCerraSesion.Location = new Point(606, 53);
            btnCerraSesion.Name = "btnCerraSesion";
            btnCerraSesion.Size = new Size(135, 23);
            btnCerraSesion.TabIndex = 0;
            btnCerraSesion.Text = "Cerrar Sesion";
            btnCerraSesion.UseVisualStyleBackColor = true;
            btnCerraSesion.Click += btnCerraSesion_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerraSesion);
            Name = "frmPrincipal";
            Text = "Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCerraSesion;
    }
}