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
        public frmRegistrarUsuario()
        {
            InitializeComponent();

            string[] permisos = { "Seleccione el tipo de usuario", "Administrador", "Usuario" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };

            cmbNacionalidad.DataSource = paises;
            cmbTipoUsuario.DataSource = permisos;

            dtpFecNac.MaxDate = DateTime.Today.AddYears(-18);
            dtpFecNac.MinDate = DateTime.Today.AddYears(-150);


            cmbProvincia.Enabled = false;
            cmbPartidoMunicipio.Enabled = false;
            cmbLocalidad.Enabled = false;


            //Valores Test
            txtNombre.Text = "asd";
            txtApellido.Text = "ads";
            txtDNI.Text = "12345678";
            txtTelefono.Text = "1234567890";
            txtEmail.Text = "asd@asd.asd";
            cmbTipoUsuario.SelectedIndex = 1;
        }

        //Eventos de los txt
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





        //Eventos Botones
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
            string[] usuario = new string[20];

            for (int i = 0; i < usuario.Length; i++) usuario[i] = "";

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
            MessageBox.Show("Localidad " + usuario[11]);
            usuario[12] = txtCodPostal.Text;
            usuario[13] = txtCalle.Text;
            usuario[14] = txtAltura.Text;
            usuario[15] = txtPiso.Text;
            usuario[16] = txtDepartamento.Text;

            //Usuario
            /*
            El nombre se genera con inicialnombre+apellido+3 ultimos caracteres del dni
            */
            string inicial = "";
            string apellido = "";
            string nros = "";
            string nombreUsuarioConstruido = "";
            inicial = txtNombre.Text.Substring(0, 1).ToLower();
            apellido = txtApellido.Text.ToLower();
            nros = txtDNI.Text.Substring(txtDNI.Text.Length-3, 3);
            /*Si ya existe se le agrega _X siendo X la cantidad de veces que aparece*/
            //Para esto, voy a contar por cada elemento de la lista de usuarios
            //Las veces que existe en la posicon 17 el nombre recientemente generado.
            //Si no existe, no le pongo nada. De otra forma le agrego _X
            //siendo X la cantidad de veces que aparece.
            //--El impedimento. No se de donde sale esa lista,
            //tal vez seria un buen momento para crearlo, pero la necesitaria en el Login
            //Asi que entiendo que el mejor momento seria que se cree ahi y traerlo aca para modificarlo
            nombreUsuarioConstruido = inicial + apellido + nros;
            
            //Contraseña
            Random random = new Random();
            long password = random.Next(10000000, 999999999);
            usuario[18] = password.ToString();
            
            //Faltaria validar que no se repita el nombre de usuario
            usuario[19] = "si";

            MessageBox.Show("Usuario registrado con exito");
        }



        //Eventos ComboBox
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
