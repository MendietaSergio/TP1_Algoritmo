using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TP_1_Heladeria
{
    public partial class frmRecuperarContrasena : Form
    {
        public frmRecuperarContrasena()
        {
            InitializeComponent();
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            // Si el email está vacío, avisamos y salimos
            if (txtEmail.Text == "")
            {
                MessageBox.Show("¡Falta poner el email!");
                return;
            }
            // Chequear email
            bool esValido = Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!esValido)
            {
                MessageBox.Show("Mail invalido.");
                return;
            }

            // Si llegamos acá, significa que hay texto.
            // Como es un trabajo práctico sin base de datos real, 
            // vamos a simular que el usuario existe (o puedes poner un if simple con un email fijo si quieres probar).

            MessageBox.Show("Código enviado a " + txtEmail.Text + "\nEl código es: 1234");

            // Ahora habilitamos lo que estaba bloqueado
            txtCodigo.Enabled = true;
            btnValidarCodigo.Enabled = true;

            // Desactivamos este botón para que no lo aprieten dos veces
            btnEnviarCodigo.Enabled = false;

            // Cambiamos el mensaje de arriba
            lblEstado.Text = "Ingresá el código que te llego (1234)";

            // Limpiamos el campo de código por si acaso
            txtCodigo.Text = "";
            txtCodigo.Focus(); // Dejamos el cursor listo para escribir
        }
        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            // 1. Verificar que no haya escrito nada en el código
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("¡Falta poner el código!");
                return;
            }

            // 2. Verificar si el código es correcto (asumimos que es "1234" como pedía el TP)
            if (txtCodigo.Text == "1234")
            {
                // ¡Código correcto!
                MessageBox.Show("¡Código válido! Ahora podés poner tu nueva contraseña.");

                // Habilitamos las cajas de contraseña
                txtNuevaContra.Enabled = true;
                txtConfirmarContra.Enabled = true;

                // Habilitamos el botón final
                btnGuardarContra.Enabled = true;

                // Desactivamos el botón de validar para que no lo aprieten de nuevo
                btnValidarCodigo.Enabled = false;

                // Limpiamos el campo de código y ponemos el foco en la nueva contraseña
                txtCodigo.Text = "";
                txtNuevaContra.Focus();

                // Actualizamos el mensaje de estado
                lblEstado.Text = "Código válido. Ingresá tu nueva contraseña.";
            }
            else
            {
                // Código incorrecto
                MessageBox.Show("El código que ingresaste es incorrecto. Intentá de nuevo.");

                // Limpiamos el campo de código para que intente de nuevo
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
        }

        
            private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            // 1. Verificar que no estén vacías
            if (txtNuevaContra.Text == "" || txtConfirmarContra.Text == "")
            {
                MessageBox.Show("¡Falta completar las contraseñas!");
                return;
            }

            // 2. Verificar longitud (al menos 8)
            if (txtNuevaContra.Text.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.");
                return;
            }

            // 3. Verificar que coincidan
            if (txtNuevaContra.Text != txtConfirmarContra.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                txtConfirmarContra.Text = ""; // Limpiamos la confirmación
                txtConfirmarContra.Focus();
                return;
            }


          
            // ¡SI LLEGAMOS AQUÍ, ES QUE TODO ESTÁ BIEN!
            MessageBox.Show("¡Éxito! Contraseña cambiada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerrar este formulario
            this.Close();
        }
    }
    
}
