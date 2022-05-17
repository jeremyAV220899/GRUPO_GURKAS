using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Planilla.GuardarPlanilla
{
    public partial class frmGuardarPlanilla : Form
    {
        public DateTime _fecha;
        public DateTime _fecchagenerada;
        Datos.registrar registrar = new Datos.registrar();
        public frmGuardarPlanilla()
        {
            InitializeComponent();
        }
        private void TipoDeDatos()
        {
            cbotipocarga.Items.Insert(0, "Seleccione un tipo de carga de datos");
            cbotipocarga.Items.Insert(1, "Guardado de datos por el sistema");
            cbotipocarga.Items.Insert(2, "Guardado de datos por Excel");
            cbotipocarga.SelectedIndex = 0;
        }

        private void frmGuardarPlanilla_Load(object sender, EventArgs e)
        {
            TipoDeDatos();
        }

        private void btnGuardadAsistencia_Click(object sender, EventArgs e)
        {
            int tipo = cbotipocarga.SelectedIndex;
            DateTime fecha = _fecha;
            DateTime fecchagenerada = _fecchagenerada;
            if (tipo == 1)
            {
                const string titulo = "Guardar Registro de Planilla";
                const string mensaje = "Estas seguro que deseas Guardar el Registro de Planilla \n";
                var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resutlado == DialogResult.Yes)
                {
                    try
                    {
                        registrar.RegistrarPlanilla(fecha, fecchagenerada);
                        MessageBox.Show("Datos Guardado Exitosamente", "Datos Guardado Exitosamente en la Base de Datos");
                        //this.Close();
                        /* if (fecha.Day >= 28)
                         {
                             btnBoleta.Enabled = true;
                         }*/
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar los datos " + ex, "ERROR");
                    }
                }
            }
            if (tipo == 2)
            {
                Vista.Planilla.GuardarPlanilla.frmDatosPlanillaExcel datosplanilla = new Vista.Planilla.GuardarPlanilla.frmDatosPlanillaExcel();
                datosplanilla._fecha = _fecha;
                datosplanilla._fecchagenerada = _fecchagenerada;
                datosplanilla.ShowDialog();
            }
        }
    }
}
