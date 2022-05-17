using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.MensajeEmergente
{
    public partial class DialogForm : Form
    {
        public DialogForm(String message, Color bgColor)
        {
            InitializeComponent();
            BackColor = bgColor;
            lblMessage.Text = message;
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            Top = 20;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 20;
            timerClose.Start();
        }
        private void timerClose_Tick_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
