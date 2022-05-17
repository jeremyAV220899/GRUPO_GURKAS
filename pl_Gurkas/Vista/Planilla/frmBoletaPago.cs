using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Planilla
{
    public partial class frmBoletaPago : Form
    {
        public frmBoletaPago()
        {
            InitializeComponent();
        }

        private void frmBoletaPago_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mes_int = Convert.ToInt32(txtMes.Text);
            int anio = Convert.ToInt32(txtAnio.Text);
            string cod_empleado = textBox1.Text;
            BoletaReporte.BoletaIndividual _boleta = new BoletaReporte.BoletaIndividual();
            _boleta.SetParameterValue("@cod_empleado", cod_empleado);
            _boleta.SetParameterValue("@mes", mes_int);
            _boleta.SetParameterValue("@anio", anio);

            crystalReportViewer1.ReportSource = _boleta;
        }
    }
}
