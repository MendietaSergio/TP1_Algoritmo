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
    public partial class frmEditarPerfil : Form
    {
        public string[] usuarioLogeado;
        public string[] usuarioEditando;
        public BindingList<string[]> usuarios = new BindingList<string[]>();
        int indiceLogeado;
        BindingList<string> nombreUsuarios = new BindingList<string>();

        public frmEditarPerfil(BindingList<string[]> _usuarios, int _indiceLogeado)
        {

            InitializeComponent();

            usuarios = _usuarios;
            indiceLogeado = _indiceLogeado;

            usuarioLogeado = usuarios[indiceLogeado];
            usuarioEditando = usuarioLogeado;

            string[] permisos = { cmbTipoUsuario.AccessibleDescription, "Administrador", "General" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };
            

            foreach (string[] usuarioActual in usuarios) nombreUsuarios.Add(usuarioActual[17]);



            cmbUsuarioEditado.DataSource = nombreUsuarios;
            cmbNacionalidad.DataSource = paises;
            cmbTipoUsuario.DataSource = permisos;

            {
                cmbUsuarioEditado.SelectedIndex = indiceLogeado;

                txtNombre.Text = usuarioEditando[0];
                txtApellido.Text = usuarioEditando[1];
                txtDNI.Text = usuarioEditando[2];
                txtTelefono.Text = usuarioEditando[3];
                txtEmail.Text = usuarioEditando[4];

                if (usuarioEditando[5].ToLower() == "masculino")
                    rdbMasculino.Checked = true;
                else
                    rdbFemenino.Checked = true;


                cmbTipoUsuario.Text = usuarioEditando[6];
                dtpFecNac.Text = usuarioEditando[7];

                cmbNacionalidad.Text = usuarioEditando[8];
                cmbProvincia.Text = usuarioEditando[9];
                cmbPartidoMunicipio.Text = usuarioEditando[10];
                cmbLocalidad.Text = usuarioEditando[11];

                txtCodPostal.Text = usuarioEditando[12];
                txtCalle.Text = usuarioEditando[13];
                txtAltura.Text = usuarioEditando[14];
                txtPiso.Text = usuarioEditando[15];
                txtDepartamento.Text = usuarioEditando[16];


            }
            
            {
                if (cmbNacionalidad.SelectedValue != null && cmbNacionalidad.SelectedIndex != 0)
                    cmbProvincia.Enabled = true;
                else
                    cmbProvincia.Enabled = false;

                if (cmbProvincia.SelectedValue != null && cmbProvincia.SelectedIndex != 0)
                    cmbPartidoMunicipio.Enabled = true;
                else
                    cmbPartidoMunicipio.Enabled = false;

                if (cmbPartidoMunicipio.SelectedValue != null && cmbPartidoMunicipio.SelectedIndex != 0)
                    cmbLocalidad.Enabled = true;
                else
                    cmbLocalidad.Enabled = false;
            }

            {
                if (txtNombre.Text.Length > 0 &&
                   txtApellido.Text.Length > 0 &&
                   txtDNI.Text.Length > 0 &&
                   txtTelefono.Text.Length > 0 &&
                   txtEmail.Text.Length > 0 &&
                   (cmbTipoUsuario.SelectedIndex == 1
                   ||
                   cmbTipoUsuario.SelectedIndex == 2))
                {
                    btnGuardarCambios.Enabled = true;
                    grpUbicacion.Enabled = true;

                }
                else
                {
                    btnGuardarCambios.Enabled = false;
                    grpUbicacion.Enabled = false;
                }

            }

            if (usuarioLogeado[6].ToLower() != "administrador")
            {
                cmbTipoUsuario.Enabled = false;
                txtDNI.Enabled = false;
                cmbUsuarioEditado.Enabled = false;
                btnGuardarCambios.Width = 201;
                btnEliminar.Enabled = false;
                btnEliminar.Visible = false;

            }

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);

        }



        //Eventos Combo
        private void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<string> provincias = new BindingList<string> { cmbProvincia.AccessibleDescription };


            if (cmbNacionalidad.SelectedValue != null && cmbNacionalidad.SelectedIndex != -1)
            {
                cmbProvincia.Enabled = true;
                cmbProvincia.DataSource = provincias;
                if (cmbNacionalidad.SelectedValue.ToString().ToLower() == "argentina")
                {
                    provincias.Add("Buenos Aires");
                    provincias.Add("Cordoba");
                }
                else if (cmbNacionalidad.SelectedValue.ToString().ToLower() == "uruguay")
                {
                    provincias.Add("Montevideo");
                    provincias.Add("Canelones");
                }
                else
                {
                    cmbProvincia.DataSource = null;
                    cmbProvincia.Enabled = false;
                }

            }
        }
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<string> municipio = new BindingList<string> { cmbPartidoMunicipio.AccessibleDescription };

            if (cmbProvincia.SelectedValue != null && cmbProvincia.SelectedIndex != -1)
            {

                cmbPartidoMunicipio.Enabled = true;
                cmbPartidoMunicipio.DataSource = municipio;
                if (cmbProvincia.SelectedValue.ToString().ToLower() == "buenos aires")
                {
                    municipio.Add("Lomas de Zamora");
                    municipio.Add("Lanus");
                }
                else if (cmbProvincia.SelectedValue.ToString().ToLower() == "cordoba")
                {
                    municipio.Add("Villa Carlos Paz");
                    municipio.Add("Cosquin");
                }
                else if (cmbProvincia.SelectedValue.ToString().ToLower() == "montevideo")
                {
                    municipio.Add("B");
                    municipio.Add("CH");
                }
                else if (cmbProvincia.SelectedValue.ToString().ToLower() == "canelones")
                {
                    municipio.Add("18 de Mayo");
                    municipio.Add("Aguas Corrientes");
                }
                else
                {
                    cmbPartidoMunicipio.DataSource = null;
                    cmbPartidoMunicipio.Enabled = false;
                }
            }
        }
        private void cmbPartidoMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<string> localidad = new BindingList<string> { cmbLocalidad.AccessibleDescription };


            if (cmbPartidoMunicipio.SelectedValue != null && cmbPartidoMunicipio.SelectedIndex != -1)
            {

                cmbLocalidad.Enabled = true;
                cmbLocalidad.DataSource = localidad;
                if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "lomas de zamora")
                {
                    localidad.Add("Lomas de Zamora");
                    localidad.Add("Temperley");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "villa carlos paz")
                {
                    localidad.Add("Villa Domingues");
                    localidad.Add("La Quinta");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "lanus")
                {
                    localidad.Add("Lanus");
                    localidad.Add("Valentin Alsina");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "cosquin")
                {
                    localidad.Add("Casa Grande");
                    localidad.Add("Villa Hermoso");

                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "b")
                {
                    localidad.Add("Ciudad Vieja");
                    localidad.Add("Centro");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "ch")
                {
                    localidad.Add("Pocitos");
                    localidad.Add("Punta Carretas");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "18 de mayo")
                {
                    localidad.Add("El Dorado");
                    localidad.Add("Villa Alegria");
                }
                else if (cmbPartidoMunicipio.SelectedValue.ToString().ToLower() == "aguas corrientes")
                {
                    localidad.Add("-");
                    localidad.Add("-");
                }
                else
                {
                    cmbLocalidad.DataSource = null;
                    cmbLocalidad.Enabled = false;
                }

            }

        }
        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void cmbUsuarioEditado_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioEditando = usuarios[cmbUsuarioEditado.SelectedIndex];

            {

                txtNombre.Text = usuarioEditando[0];
                txtApellido.Text = usuarioEditando[1];
                txtDNI.Text = usuarioEditando[2];
                txtTelefono.Text = usuarioEditando[3];
                txtEmail.Text = usuarioEditando[4];

                if (usuarioEditando[5].ToLower() == "masculino")
                    rdbMasculino.Checked = true;
                else
                    rdbFemenino.Checked = true;


                cmbTipoUsuario.Text = usuarioEditando[6];
                dtpFecNac.Text = usuarioEditando[7];
                cmbNacionalidad.Text = usuarioEditando[8];
                cmbProvincia.Text = usuarioEditando[9];
                cmbPartidoMunicipio.Text = usuarioEditando[10];
                cmbLocalidad.Text = usuarioEditando[11];
                txtCodPostal.Text = usuarioEditando[12];
                txtCalle.Text = usuarioEditando[13];
                txtAltura.Text = usuarioEditando[14];
                txtPiso.Text = usuarioEditando[15];
                txtDepartamento.Text = usuarioEditando[16];

                if (indiceLogeado != usuarios.IndexOf(usuarioEditando))
                    btnEditarContrasena.Enabled = false;
                else
                    btnEditarContrasena.Enabled = true;
            }

        }

        //Eventos txt
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&
               (cmbTipoUsuario.SelectedIndex == 1
               ||
               cmbTipoUsuario.SelectedIndex == 2))
            {
                btnGuardarCambios.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnGuardarCambios.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }


        //Eventos Botones
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal(usuarios, indiceLogeado);
            principal.Show();
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            //Validaciones Requeridos            
            int DNI = 0;
            if (!int.TryParse(txtDNI.Text, out DNI))
            {
                MessageBox.Show("Se esperaba un valor numerico para el DNI",
                    "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }
            if (DNI <= 0 || DNI > 99999999)
            {
                MessageBox.Show("Valores no soportados en el campo DNI",
                    "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }
            

            long tel = 0;
            if (!long.TryParse(txtTelefono.Text, out tel))
            {
                MessageBox.Show("Se esperaba un valor numerico para el Telefono",
                    "Error Telefono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }
            if (tel <= 0 || tel > 9999999999)
            {
                MessageBox.Show("Valores no soportados en el campo Telefono",
                    "Error Telefono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }
            

            bool esValido = Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!esValido)
            {
                MessageBox.Show("Valores no soportados en el campo Email",
                    "Error Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
                        
            //Validacion No Requeridos
            if (txtCodPostal.Text.Length > 8)
            {
                MessageBox.Show("Valores no soportados en el campo Codigo Postal",
                        "Error CP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodPostal.Focus();
                return;
            }

            int altura = 0;
            if (!int.TryParse(txtAltura.Text, out altura) && (txtAltura.Text != ""))
            {
                MessageBox.Show("Se esperaba un valor numerico para la Altura",
                    "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }
            if (altura <= 0 && txtAltura.Text != "")
            {
                MessageBox.Show("Se esperaba un valor positivo para la Altura",
                    "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }

            if (txtPiso.Text.Length > 2)
            {
                MessageBox.Show("Valores no soportados en el campo Piso",
                        "Error Piso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPiso.Focus();
                return;
            }


            int guardarEn = usuarios.ToList().FindIndex(nombreCuenta => nombreCuenta[17] == usuarioEditando[17]);
            usuarioEditando[0] = txtNombre.Text;
            usuarioEditando[1] = txtApellido.Text;
            usuarioEditando[2] = txtDNI.Text;
            usuarioEditando[3] = txtTelefono.Text;
            usuarioEditando[4] = txtEmail.Text;
            if (rdbMasculino.Checked)
                usuarioEditando[5] = "Masculino";
            else
                usuarioEditando[5] = "Femenino";
            usuarioEditando[6] = cmbTipoUsuario.SelectedValue.ToString();
            usuarioEditando[7] = dtpFecNac.Text;
            if (cmbNacionalidad.SelectedIndex >= 0)
                usuarioEditando[8] = cmbNacionalidad.SelectedValue.ToString();

            if (cmbProvincia.SelectedIndex >= 0)
                usuarioEditando[9] = cmbProvincia.SelectedValue.ToString();
            else
                usuarioEditando[9] = "";
            if (cmbPartidoMunicipio.SelectedIndex >= 0)
                usuarioEditando[10] = cmbPartidoMunicipio.SelectedValue.ToString();
            else
                usuarioEditando[10] = "";
            usuarioEditando[11] = cmbLocalidad.SelectedIndex >= 0 ? cmbLocalidad.SelectedValue.ToString() : "";
            usuarioEditando[12] = txtCodPostal.Text;
            usuarioEditando[13] = txtCalle.Text;
            usuarioEditando[14] = txtAltura.Text;
            usuarioEditando[15] = txtPiso.Text;
            usuarioEditando[16] = txtDepartamento.Text;

            MessageBox.Show("Se edito el usuario exitosamente");

            usuarios[guardarEn] = usuarioEditando;
            frmPrincipal prin = new frmPrincipal(usuarios, indiceLogeado);
            prin.Show();
            this.Close();
        }
        private void btnEditarContrasena_Click(object sender, EventArgs e)
        {

            frmCambioContrasena frm = new frmCambioContrasena(usuarios, indiceLogeado);
            frm.ShowDialog();

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((usuarioLogeado[6].ToLower() == "administrador") &&
                (usuarioEditando[17].ToLower() != usuarioLogeado[17].ToLower()))

            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Esta seguro que desea eliminar este usuario? Los datos no se van a recuperar",
                    "Eliminacion de Usuario",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {

                    string[] usuarioABorrar = usuarioEditando;
                    usuarioEditando = usuarios[indiceLogeado];
                    int nroIndiceBorrar = cmbUsuarioEditado.SelectedIndex;
                    cmbUsuarioEditado.SelectedIndex = indiceLogeado;

                    nombreUsuarios.RemoveAt(nroIndiceBorrar);
                    usuarios.Remove(usuarioABorrar);
                    
                    

                    MessageBox.Show("Usuario " + usuarioABorrar[17] + " eliminado", "Eliminado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
    }
}
