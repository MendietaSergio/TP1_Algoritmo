using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP_1_Heladeria
{
    public partial class frmRegistrarUsuario : Form
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
            String[] permisos = { "Seleccione el tipo de usuario", "Administrador", "Usuario" };
            BindingList<string> paises = new BindingList<string> { "Seleccione la nacionalidad del usuario", "Argentina", "Uruguay" };
            cmbNacionalidad.DataSource = paises;
            cmbTipoUsuario.DataSource = permisos;

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);


            cmbProvincia.Enabled = false;
            cmbPartidoMunicipio.Enabled = false;
            cmbLocalidad.Enabled = false;
            /*txtCalle.Enabled = false;
            txtAltura.Enabled = false;
            txtDepartamento.Enabled = false;
            txtPiso.Enabled = false;
            txtCodPostal.Enabled = false;*/
        }

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
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            TextBox[] txtCampos =
                { txtNombre, txtApellido, txtDNI,
                txtTelefono, txtEmail,
                txtCodPostal, txtCalle,txtAltura,
                txtPiso,txtPiso,txtDepartamento };
            ComboBox[] cmbCamposParaLimpiar =
                { cmbProvincia, cmbPartidoMunicipio,
                 cmbLocalidad };


            foreach (TextBox campo in txtCampos) campo.Text = "";
            foreach (ComboBox campo in cmbCamposParaLimpiar) campo.DataSource = null;
            cmbNacionalidad.SelectedIndex = 0;
            cmbTipoUsuario.SelectedIndex = 0;


            rdbMasculino.Checked = true;
            txtNombre.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Aca tengo que meter las validaciones.
            /*
             * ////Requeridas ////
             * Nombre y Apellido, 
             *      no llevan validacion extra. Con lo que puse para que se bloquee el boton, estamos bien.
             * DNI
             *      Validar que la longitud sea menor a 8 y que sea numerio*/
            int DNI = 0;
            if (!int.TryParse(txtDNI.Text, out DNI))
            {
                MessageBox.Show("Se esperaba un valor numerico para el DNI",
                    "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }
            /*
             * Telefono
             *      Num 10 pos como mucho
             * Email
             *      Puedo buscar como hacerlo con IA
             * Genero
             *      No necesito una validacion extra. Esta seleccionado por defecto masculino
             * Tipo de Usuario
             *      Tiene que estas cargado
             * Fecha de Nacimiento
             *      Solo se van a poder fechas de hace 18 años, por lo que no se van a poder poner fechas futuras.
             *      Tampoco me interesa ver hace 150 años. Es un monton, pero lo voy a frenar ahi.
             * 
             *  ////No Requeridas ////
             * 
             * Nacionalidad, Provincia, Partido/Municipio y Localidad tienen que ser ComboBox. Cambiar.
             *          Si los index son 0, que se guarde ""
             * Cod Postal
             *      Hasta 8 caracteres.
             * Altura
             *      Num
             * Piso
             *      Text
             * Departamento
             *      Text
             * 
             * 
             * 
             *   
             * 
             * 
             */
        }

        private void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<string> provincias = new BindingList<string> { "Seleccion la provincia" };
            cmbProvincia.DataSource = provincias;
            cmbProvincia.Enabled = true;
            if (cmbNacionalidad.SelectedIndex == 1)
            {
                provincias.Add("Buenos Aires");
                provincias.Add("Cordoba");
            }
            else if (cmbNacionalidad.SelectedIndex == 2)
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
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
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
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
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
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
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
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
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
                btnAceptar.Enabled = true;
                grpUbicacion.Enabled = true;

            }
            else
            {
                btnAceptar.Enabled = false;
                grpUbicacion.Enabled = false;
            }
        }
    }
}
