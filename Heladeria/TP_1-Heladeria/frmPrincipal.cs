using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP_1_Heladeria
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuario = new Usuario();

        public frmPrincipal(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;

            lblUsuario.Text = usuario.Nombre;

            // Verificamos permisos de Administrador:
            // TipoUsuario == 1 es Administrador, TipoUsuario == 2 es General
            if (usuario.TipoUsuario == 1)
            {
                btnEditarPerfiles.Visible = true;
                btnRegistrarUsuario.Visible = true;
                this.ClientSize = new Size(382, 250);
            }
            else
            {
                btnEditarPerfiles.Visible = false;
                btnRegistrarUsuario.Visible = false;
                this.ClientSize = new Size(382, 145);
            }
        }

        // 1. Editar Mi Perfil (para todos los usuarios)
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil(usuario, false); // Modo edición perfil propio
            frm.Show();
            this.Close();
        }

        // 2. Cambiar Contraseña (para todos los usuarios)
        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            frmCambioContrasena frm = new frmCambioContrasena(usuario);
            frm.ShowDialog();
        }

        // 3. Editar Perfiles (solo Administrador)
        private void btnEditarPerfiles_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil(usuario, true); // Modo administración (gestión de todos los perfiles)
            frm.Show();
            this.Close();
        }

        // 4. Registrar Nuevo Usuario (solo Administrador)
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Form registrar = new frmRegistrarUsuario(usuario);
            registrar.Show();
            this.Close();
        }

        // 5. Cerrar Sistema
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult deseaCerrar = MessageBox.Show("¿Desea cerrar la aplicación?", "Cerrar Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (deseaCerrar == DialogResult.Yes) 
                Application.Exit();
        }

        // 6. Cerrar Sesión
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form login = new frmLogin();
            login.Show();
            this.Close();
        }
    }
}
