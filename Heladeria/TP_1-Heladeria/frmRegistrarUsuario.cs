using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using TP_1_Heladeria;
/*
 
            {

                "Argentina",
                "Buenos Aires", "Cordoba",
                "Lomas de Zamora", "Villa Carlos Paz", "Lanus", "Cosquin",
                "Lomas de Zamora",  "Villa Domingues", "Lanus",          "Casa Grande",
                "Temperley",        "La Quinta",       "Valentin Alsina", "Villa Hermoso",




                "Uruguay",
                "Montevideo", "Canelones",
                "B",           "18 de Mayo",   "CH",              "Aguas Corrientes",
                "Ciudad Vieja","El Dorado",     "Pocitos"      , "-",
                "Centro",      "Villa Alegria", "Punta Carretas","-"

            }

 */




namespace TP_1_Heladeria
{
    public partial class frmRegistrarUsuario : Form
    {

        ValidacionDeCampos validacion = new ValidacionDeCampos();
        public void Limpiar()
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

        public BindingList<string[]> usuarios = new BindingList<string[]>();
        int indice;
        Usuario usuario = new Usuario();
        

        public frmRegistrarUsuario(Usuario _usuario, int _indice)
        {
            InitializeComponent();
            //usuarios = _usuarios;
            usuario = _usuario;
            indice = _indice;

            string[] permisos = { cmbTipoUsuario.AccessibleDescription, "Administrador", "General" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };


            cmbNacionalidad.DataSource = paises;
            cmbTipoUsuario.DataSource = permisos;

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);

            cmbProvincia.Enabled = false;
            cmbPartidoMunicipio.Enabled = false;
            cmbLocalidad.Enabled = false;

        }


        //Eventos de los txt
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
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
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
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
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
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
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
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
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
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


        //Eventos Botones
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ////Requeridas ////
            try
            {
                //Requeridas
                validacion.TextoVacio([txtNombre, txtApellido, txtDNI, txtTelefono, txtEmail]);
                validacion.TipoEntero([txtTelefono, txtDNI]);
                validacion.NroEnteroEntre(txtTelefono, 1000000000, 9999999999);
                validacion.NroEnteroEntre(txtDNI, 3000000, 99999999);
                validacion.EMail(txtEmail);

                
                
            }
            catch (Exception ex) {
                MessageBox.Show($"Error - {ex.Message}", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //No Requeridas

            validacion.LongitudTexto(txtCodPostal, 0, 8);
            validacion.LongitudTexto(txtPiso, 0, 2);
            if(!(string.IsNullOrWhiteSpace(txtAltura.Text)))
            {
                validacion.TipoEntero([txtAltura]);
                validacion.LimitesNumero(txtAltura, 0, int.MaxValue);
            }

            //Hasta aca llegue
            string[] usuarioNuevo = new string[21];

            for (int i = 0; i < usuarioNuevo.Length; i++) usuarioNuevo[i] = "";

            usuarioNuevo[0] = txtNombre.Text;
            usuarioNuevo[1] = txtApellido.Text;
            usuarioNuevo[2] = txtDNI.Text;
            usuarioNuevo[3] = txtTelefono.Text;
            usuarioNuevo[4] = txtEmail.Text;
            if (rdbMasculino.Checked)
                usuarioNuevo[5] = "Masculino";
            else
                usuarioNuevo[5] = "Femenino";
            usuarioNuevo[6] = cmbTipoUsuario.SelectedValue.ToString(); //Acordate que lo estas manejando con un array
            usuarioNuevo[7] = dtpFecNac.Text;
            if (cmbNacionalidad.SelectedIndex > 0)
                usuarioNuevo[8] = cmbNacionalidad.SelectedValue.ToString();
            if (cmbProvincia.SelectedIndex > 0)
                usuarioNuevo[9] = cmbProvincia.SelectedValue.ToString();
            if (cmbPartidoMunicipio.SelectedIndex > 0)
                usuarioNuevo[10] = cmbPartidoMunicipio.SelectedValue.ToString();
            usuarioNuevo[11] = cmbLocalidad.SelectedIndex > 0 ? cmbLocalidad.SelectedValue.ToString() : "";
            usuarioNuevo[12] = txtCodPostal.Text;
            usuarioNuevo[13] = txtCalle.Text;
            usuarioNuevo[14] = txtAltura.Text;
            usuarioNuevo[15] = txtPiso.Text;
            usuarioNuevo[16] = txtDepartamento.Text;

            string inicial = "";
            string apellido = "";
            string nros = "";
            string nombreUsuarioConstruido = "";
            inicial = txtNombre.Text.Substring(0, 1).ToLower();
            apellido = txtApellido.Text.ToLower();
            nros = txtDNI.Text.Substring(txtDNI.Text.Length - 3, 3);

            nombreUsuarioConstruido = inicial + apellido + nros;

            int cantVeces = 1;

            foreach (string[] usuario in usuarios)
                if (usuario[20] == nombreUsuarioConstruido)
                    cantVeces++;

            usuarioNuevo[20] = nombreUsuarioConstruido;


            if (cantVeces > 1)
                nombreUsuarioConstruido = nombreUsuarioConstruido + "_" + cantVeces;

            usuarioNuevo[17] = nombreUsuarioConstruido;

            Random random = new Random();
            long password = random.Next(10000000, 999999999);
            usuarioNuevo[18] = password.ToString();

            usuarioNuevo[19] = "si";

            usuarios.Add(usuarioNuevo);

            MessageBox.Show("Usuario registrado con exito. La contraseña es " + usuarioNuevo[18]);
            //  Limpiar();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form principal = new frmPrincipal(usuario);
            principal.Show();
            this.Close();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult deseaCerrar = MessageBox.Show("Desea cerrar la aplicacion?", "Cerrar Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (deseaCerrar == DialogResult.Yes)
                Application.Exit();
        }



        //Eventos ComboBox
        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (/*(txtNombre.Text.Length > 0 &&
               txtApellido.Text.Length > 0 &&
               txtDNI.Text.Length > 0 &&
               txtTelefono.Text.Length > 0 &&
               txtEmail.Text.Length > 0 &&*/
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text)&&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
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

       
    }
}
