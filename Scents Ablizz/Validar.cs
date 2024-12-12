using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scents_Ablizz
{
    internal class Validar
    {
        //Validacion de solo numeros en las cajas de texto
        public static void SoloNumeros(KeyPressEventArgs pE)
        {
            if (char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if(char.IsControl(pE.KeyChar)) 
            {
                pE.Handled = false;
            }
            else
            {
                MessageBox.Show("Solo ingrese números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pE.Handled = true;
            }
        }
        //Validacion de solo letras en las cajas de texto
        public static void SoloLetras(KeyPressEventArgs pE)
        {
            if(Char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                MessageBox.Show("Solo ingrese letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pE.Handled = true;
            }
        }
    }
}
