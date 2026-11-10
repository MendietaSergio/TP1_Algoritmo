using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP_1_Heladeria
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuario = new Usuario();
        private bool cerrandoSesion = false;

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
                this.ClientSize = new Size(380, 245);
            }
            else
            {
                btnEditarPerfiles.Visible = false;
                btnRegistrarUsuario.Visible = false;
                this.ClientSize = new Size(380, 140);
            }
        }

        // 1. Editar Mi Perfil (para todos los usuarios)
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            cerrandoSesion = true;
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
            cerrandoSesion = true;
            frmEditarPerfil frm = new frmEditarPerfil(usuario, true); // Modo administración (gestión de todos los perfiles)
            frm.Show();
            this.Close();
        }

        // 4. Registrar Nuevo Usuario (solo Administrador)
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            cerrandoSesion = true;
            Form registrar = new frmRegistrarUsuario(usuario);
            registrar.Show();
            this.Close();
        }

        // 5. Cerrar Sesión
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            cerrandoSesion = true;
            Form login = new frmLogin();
            login.Show();
            this.Close();
        }

        // 6. Al cerrar con la [X] nativa del formulario
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrandoSesion && e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
