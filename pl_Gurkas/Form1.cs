using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CargarTipoConexion()
        {
            cboTipoConexion.Items.Insert(0, "Selecciona un tipo");
            cboTipoConexion.Items.Insert(1, "Empresa");
            cboTipoConexion.Items.Insert(2, "Fuera de la Empresa");
            cboTipoConexion.SelectedIndex = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarTipoConexion();
        }
        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            int tipo_conexion = cboTipoConexion.SelectedIndex;
            Vista.PantallaInicio.frmPantallaPrincipal frmPantallaPrincipal = new Vista.PantallaInicio.frmPantallaPrincipal();
            frmPantallaPrincipal._conexion = tipo_conexion;
            frmPantallaPrincipal.Show();
            this.Hide();
        }
    }
}
