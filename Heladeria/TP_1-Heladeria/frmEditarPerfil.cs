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
        public string[] usuario;
        public List<string[]> usuarios = new List<string[]>();
        public frmEditarPerfil(List<string[]> _usuarios, string[] _usuario)
        {
            InitializeComponent();

            usuarios = _usuarios;
            usuario = _usuario;

            string[] permisos = { cmbTipoUsuario.AccessibleDescription, "Administrador", "General" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };

            cmbNacionalidad.DataSource = paises;
            cmbTipoUsuario.DataSource = permisos;

            //Carga de datos
            {

                txtNombre.Text = usuario[0];
                txtApellido.Text = usuario[1];
                txtDNI.Text = usuario[2];
                txtTelefono.Text = usuario[3];
                txtEmail.Text = usuario[4];

                if (usuario[5].ToLower() == "masculino")
                    rdbMasculino.Checked = true;
                else
                    rdbFemenino.Checked = true;


                cmbTipoUsuario.Text = usuario[6];
                dtpFecNac.Text = usuario[7];
                cmbNacionalidad.Text = usuario[8];
                cmbProvincia.Text = usuario[9];
                cmbPartidoMunicipio.Text = usuario[10];
                cmbLocalidad.Text = usuario[11];
                txtCodPostal.Text = usuario[12];
                txtCalle.Text = usuario[13];
                txtAltura.Text = usuario[14];
                txtPiso.Text = usuario[15];
                txtDepartamento.Text = usuario[16];
                cmbUsuarioEditado.SelectedValue = usuario[17];

            }
            //Me fijo que el campo del que depende 1 campo de la ubicacion, este disponible para habilitarlo
            {
                if (cmbNacionalidad.SelectedValue != "")
                    cmbProvincia.Enabled = true;
                else
                    cmbProvincia.Enabled = false;

                if (cmbProvincia.SelectedValue != "")
                    cmbPartidoMunicipio.Enabled = true;
                else
                    cmbPartidoMunicipio.Enabled = false;

                if (cmbPartidoMunicipio.SelectedValue != "")
                    cmbLocalidad.Enabled = true;
                else
                    cmbLocalidad.Enabled = false;
            }
            //Me aseguro de que todos los items esten cargados con sus longitudes correctas
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
            //Ahora voy a bloquear los datos que no tienen que modificar los usuarios
            if (usuario[6].ToLower() != "administrador")
            {
                cmbTipoUsuario.Enabled = false;
                txtDNI.Enabled = false;
                //Tengo que agregar un cmb para Nombre de Usuario
                //Los datos tiene que ser readonly, pero el admin tiene que poder
                //Cambiar de usuario, pero no modificar el nombre de usuario.
                //Esto puedo hacerlo bloqueando el boton guardar si el selectedValue no existe en la lista de usuarios

            }/*
            else if (usuario[17]=! ){
                //No esta todavia pero quiero agregarle que pueda cambiar de usuario para modificar
            }*/


        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal(usuarios, usuario);
            principal.Show();
            this.Hide();
        }


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
            if (DNI <= 0 || DNI > 99999999)
            {
                MessageBox.Show("Valores no soportados en el campo DNI",
                    "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }
            /*
             * Telefono
             *      Num 10 pos como mucho
                */
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
            /*

         * Email
         *   Busca que tenga un arroba y un punto, como hablamos en clase*/
            bool esValido = Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!esValido)
            {
                MessageBox.Show("Valores no soportados en el campo Email",
                    "Error Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            /*
         * Genero
         *      No necesito una validacion extra. 
         *      Esta seleccionado por defecto masculino
         * Tipo de Usuario
         *      Ya esta hecho. Si no pongo un tipo valido, se bloquea el boton
         * Fecha de Nacimiento
         *      Solo se van a poder fechas hasta hace 18 años, por lo que no se van a poder poner fechas futuras.
         *      Tampoco me interesa ver hace 150 años. Es un monton, pero lo voy a frenar ahi.
         * 
         *  ////No Requeridas ////
         * 
         * Nacionalidad, Provincia, Partido/Municipio y Localidad 
         *          Si los index son 0 o null, que se guarde ""
         * Cod Postal
         *      Hasta 8 caracteres.
         *      */
            if (txtCodPostal.Text.Length > 8)
            {
                MessageBox.Show("Valores no soportados en el campo Codigo Postal",
                        "Error CP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodPostal.Focus();
                return;
            }
            /*
         * Altura
         *      Num*/
            if (!int.TryParse(txtAltura.Text, out int altura) && (txtAltura.Text != ""))
            {
                MessageBox.Show("Se esperaba un valor numerico para la Altura",
                    "Error Altura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltura.Focus();
                return;
            }
            /*
         * Piso
         *      Text. Valido que no sean 2, porque por lo gral se identifica con 2 caracteres */
            if (txtPiso.Text.Length > 2)
            {
                MessageBox.Show("Valores no soportados en el campo Piso",
                        "Error Piso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPiso.Focus();
                return;
            }
            /*
             * Departamento
             *      Text
             * 
             * 
             * 
             *   
             * Una vez que pase todas las validaciones, 
             * deberia simular una carga. Lo vamos a hacer con un array de string,
             * 
             * 
             */
            //string[] usuario = new string[20];

            //for (int i = 0; i < usuario.Length; i++) usuario[i] = "";

            int guardarEn = usuarios.FindIndex(nom => nom[17] == usuario[17]);
            usuario[0] = txtNombre.Text;
            usuario[1] = txtApellido.Text;
            usuario[2] = txtDNI.Text;
            usuario[3] = txtTelefono.Text;
            usuario[4] = txtEmail.Text;
            if (rdbMasculino.Checked)
                usuario[5] = "Masculino";
            else
                usuario[5] = "Femenino";
            usuario[6] = cmbTipoUsuario.SelectedValue.ToString();
            usuario[7] = dtpFecNac.Text;
            if (cmbNacionalidad.SelectedIndex > 0)
                usuario[8] = cmbNacionalidad.SelectedValue.ToString();
            if (cmbProvincia.SelectedIndex > 0)
                usuario[9] = cmbProvincia.SelectedValue.ToString();
            if (cmbPartidoMunicipio.SelectedIndex > 0)
                usuario[10] = cmbPartidoMunicipio.SelectedValue.ToString();
            usuario[11] = cmbLocalidad.SelectedIndex > 0 ? cmbLocalidad.SelectedValue.ToString() : "";
            //MessageBox.Show("Localidad " + usuario[11]);
            usuario[12] = txtCodPostal.Text;
            usuario[13] = txtCalle.Text;
            usuario[14] = txtAltura.Text;
            usuario[15] = txtPiso.Text;
            usuario[16] = txtDepartamento.Text;

            //Usuario
            //No se tocan esos datos

            MessageBox.Show("Se edito el usuario exitosamente");


            usuarios[guardarEn] = usuario;
            frmPrincipal prin = new frmPrincipal(usuarios, usuario);
            prin.Show();
            this.Hide();
        }

        private void btnEditarContrasena_Click(object sender, EventArgs e)
        {

            //Solamente la contraseña del logeado porque hay una opcion para recuperar contraseña
            frmRecuperarContrasena frm = new frmRecuperarContrasena(usuarios, usuario);
            frm.ShowDialog();
            
        }


        ///////////////////////////////////////////////////////////////


    }
}
