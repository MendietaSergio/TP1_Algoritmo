using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP_1_Heladeria
{
    public partial class frmRegistrarUsuario : Form
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();


            /*List<string> ubicaciones = new List<string>
            {

                "Argentina",
                "Buenos Aires", "Cordoba",
                "Lomas de Zamora", "Villa Carlos Paz", "Lanús", "Cosquin",
                "Lomas de Zamora",  "Villa Domingues", "Lanus",          "Casa Grande",
                "Temperley",        "La Quinta",       "Valentin Alsina", "Villa Hermoso",




                "Uruguay",
                "Montevideo", "Canelones",
                "B",           "18 de Mayo",   "CH",              "Aguas Corrientes",
                "Ciudad Vieja","El Dorado",     "Pocitos"      , "-",
                "Centro",      "Villa Alegria", "Punta Carretas","-"

            };
            */
            string[] permisos = { "Seleccione el tipo de usuario", "Administrador", "Usuario" };
            BindingList<string> paises = new BindingList<string> { cmbNacionalidad.AccessibleDescription, "Argentina", "Uruguay" };

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

        public void AsignarDatosACmb(ComboBox cmbActual, ComboBox cmbSiguiente)
        {
            /*
            List<string> ubicaciones = new List<string>
            {

                "Argentina",
                "Buenos Aires", "Cordoba",
                "Lomas de Zamora", "Lanús", "Villa Carlos Paz", "Cosquin",
                "Lomas de Zamora", "Temperley", "Lanus", "Valentin Alsina", 
                "Villa Domingues", "La Quinta", "Casa Grande", "Villa Hermoso",

                "Uruguay",
                "Montevideo", "Canelones",
                "B", "CH", "18 de Mayo", "Aguas Corrientes",
                "Ciudad Vieja", "Centro", "Pocitos", "Punta Carretas", "El Dorado", "Villa Alegria", "-", "-"
            }; */
            List<string> ubicaciones = new List<string>
            {

                "Argentina",
                "Buenos Aires", "Cordoba",
                "Lomas de Zamora", "Villa Carlos Paz", "Lanús", "Cosquin",
                "Lomas de Zamora",  "Villa Domingues", "Lanus",          "Casa Grande",
                "Temperley",        "La Quinta",       "Valentin Alsina", "Villa Hermoso",




                "Uruguay",
                "Montevideo", "Canelones",
                "B",           "18 de Mayo",   "CH",              "Aguas Corrientes",
                "Ciudad Vieja","El Dorado",     "Pocitos"      , "-",
                "Centro",      "Villa Alegria", "Punta Carretas","-"

            };
            int seleccionadoGral = 0;
            int seleccionadoPos = 0;
            if (cmbActual.SelectedValue != null)
            {
                seleccionadoGral = ubicaciones.IndexOf(cmbActual.SelectedValue.ToString());
                seleccionadoPos = seleccionadoGral;
                //MessageBox.Show(seleccionadoGral.ToString());
            }
            int nivel = 0;
            int mitadDeLasUbicaciones = ubicaciones.Count() / 2;
            bool Arg = true;


            if (seleccionadoPos > mitadDeLasUbicaciones)
            {
                Arg = false;
                seleccionadoPos -= mitadDeLasUbicaciones;
            }


            while (true)
            {
                if (seleccionadoPos + 1 <= Math.Pow(2, nivel)) break;
                nivel++;
            }
            int mover = Convert.ToInt32(Math.Pow(2, nivel));
            string[] ubicacionesProximo = new string[3];

            for (int i = 1; i <= 2; i++)
            {
                ubicacionesProximo[i] = ubicaciones[seleccionadoGral + (i) * mover];
                //MessageBox.Show("Esta es la posicion " + (seleccionadoGral + (i) * mover).ToString());
            }
            MessageBox.Show("2 a la" + nivel.ToString());
            ubicacionesProximo[0] = "Seleccione " + cmbActual.AccessibleDescription;
            foreach (string ubicacion in ubicacionesProximo)
                //MessageBox.Show("La primera ubicacion que se va a agregar es" + ubicacion);

                cmbSiguiente.DataSource = ubicacionesProximo;
            cmbSiguiente.Enabled = true;


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
         *      Puedo buscar como hacerlo con IA
         *      Lo sigo debiendo
         * Genero
         *      No necesito una validacion extra. 
         *      Esta seleccionado por defecto masculino
         * Tipo de Usuario
         *      Ya esta hecho. Si no pongo un tipo valido, se bloquea el boton
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
         * Una vez que pase todas las validaciones, 
         * deberia simular una carga. Lo vamos a hacer con un array de string,
         * pero podria hacerlo con un array object
         * 
         */
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
                //MessageBox.Show(cmbNacionalidad.SelectedValue.ToString());
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
            //AsignarDatosACmb(cmbPartidoMunicipio, cmbLocalidad);
            List<string> ubicaciones = new List<string>
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

            };

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
