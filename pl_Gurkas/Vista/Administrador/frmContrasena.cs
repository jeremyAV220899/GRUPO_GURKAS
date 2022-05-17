using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Administrador
{
    public partial class frmContrasena : Form
    {
        Datos.Login login = new Datos.Login();
        public frmContrasena()
        {
            InitializeComponent();
        }

        private void btnGuardadAsistencia_Click(object sender, EventArgs e)
        {
         

            string usurname = txtUser.Text.ToUpper();
            string pass = txtPass.Text.ToUpper();

            login.IniciarSesionAdmin(this, usurname, pass);
        }

        private void frmContrasena_Load(object sender, EventArgs e)
        {

        }
    }
}
