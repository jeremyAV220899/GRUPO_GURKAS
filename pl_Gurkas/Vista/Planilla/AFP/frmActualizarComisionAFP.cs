using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Planilla.AFP
{
    public partial class frmActualizarComisionAFP : Form
    {
        Datos.LlenadoDatosPlanilla LLenadocbo = new Datos.LlenadoDatosPlanilla();
        public frmActualizarComisionAFP()
        {
            InitializeComponent();
        }

        private void frmActualizarComisionAFP_Load(object sender, EventArgs e)
        {
            LLenadocbo.ObtenerAFPPLANILLASACTUALIZAR(cboAFP);
            LLenadocbo.ObtenerTipoComisionAFPPLANILLASACTUALIZAR(cboTipoComicion);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codafp = cboTipoComicion.SelectedIndex;
            int afp = cboAFP.SelectedIndex;
            if (afp != 0)
            {
                if (codafp != 0)
                {
                    if (codafp == 1)
                    {
                        Vista.Planilla.AFP.frmAFPFlujo objafpflujo = new frmAFPFlujo();
                        objafpflujo._codcomisionafp = codafp;
                        objafpflujo._afp = afp;
                        objafpflujo.ShowDialog();
                    }
                    else if (codafp == 2)
                    {
                        Vista.Planilla.AFP.frmAFPMixta objafpmixto = new frmAFPMixta();
                        objafpmixto._codcomisionafp = codafp;
                        objafpmixto._afp = afp;
                        objafpmixto.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una comision", "Veriicar");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una AFP", "Verificar");
            }
        }
    }
}
