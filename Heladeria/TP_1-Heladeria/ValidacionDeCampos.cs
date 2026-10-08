using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_1_Heladeria
{
    internal class ValidacionDeCampos
    {
        public void TextoVacio(TextBox[] textBoxes)
        {
            foreach (TextBox txtBox in textBoxes)
                if (string.IsNullOrWhiteSpace(txtBox.Text))
                {
                    txtBox.Focus();
                    throw new Exception($"El campo {txtBox.AccessibleName} esta vacio");
                }    

        }
        
        public void NroEnteroEntre(TextBox txtBox, long minimo, long maximo)
        {
            if((Convert.ToInt32(txtBox.Text) < minimo) || (Convert.ToInt32(txtBox.Text) > maximo))
            {
                txtBox.Focus();
                throw new Exception($"El campo {txtBox.AccessibleName} esta fuera de rango.\nDebe tomar un valor entre {minimo} y {maximo}");
            }
        }

        public void TipoEntero(TextBox[] txtBoxes)
        {
            foreach(TextBox txtBox in txtBoxes)
                if(!int.TryParse(txtBox.Text, out int val))
                {
                    txtBox.Focus();
                    throw new Exception($"El campo {txtBox.AccessibleName} esperaba un valor numerico");
                }
        }

        public void EMail(TextBox txtBox)
        {
            bool esValido = Regex.IsMatch(txtBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!esValido)
            {
                txtBox.Focus();
                throw new Exception("Valores no soportados en el campo Email. \nDebe tener al menos un @ y un .");
            }
        }

        public void LongitudTexto(TextBox txtBox, int longitudMinima, int longitudMaxima) {
            if ((txtBox.Text.Length < longitudMinima) || (txtBox.Text.Length > longitudMaxima))
            {
                txtBox.Focus();
                throw new Exception($"Valores no soportados en el campo Email. \nDebe entre {longitudMinima} y {longitudMaxima} caracteres de longitud");
            }
        }
        public void LimitesNumero(TextBox txtBox, int valorMinimoAlcanzado, int valorMaximoAlcanzado) {
            if ((Convert.ToInt64(txtBox.Text) < valorMinimoAlcanzado)|| (Convert.ToInt64(txtBox.Text) > valorMaximoAlcanzado))
            {
                txtBox.Focus();
                throw new Exception($"Valores no soportados en el campo Email. \nDebe entre \n{valorMinimoAlcanzado} y {valorMaximoAlcanzado} \ncaracteres de longitud");
            }
        }
    }
}
