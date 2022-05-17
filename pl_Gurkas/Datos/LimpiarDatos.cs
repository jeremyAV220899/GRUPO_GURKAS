using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Datos
{
    class LimpiarDatos
    {
        public void limpiarPanel(Panel p)
        {
            /*Si se encuentra en Panel*/
            foreach (var txt in p.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = 0;
                }
                else if (txt is DateTimePicker)
                {
                    ((DateTimePicker)txt).Value = DateTime.Now;
                }
            }
        }
        public void LimpiarGroupBox(GroupBox gb)
        {
            /*si se encuentra en un groupbox*/
            foreach (var txt in gb.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = 0;
                }
                else if (txt is DateTimePicker)
                {
                    ((DateTimePicker)txt).Value = DateTime.Now;
                }
            }
        }
        public void LimpiarCampo(Control control)
        {
            /*si encuentra solo en un formulario*/
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = 0;
                }
                else if (txt is DateTimePicker)
                {
                    ((DateTimePicker)txt).Value = DateTime.Now;
                }
            }
        }
    }
}
