using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Operaciones.Sede
{
    public partial class frmSede : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatosOperaciones Llenadocbo = new Datos.LlenadoDeDatosOperaciones();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();

        public frmSede()
        {
            InitializeComponent();
        }

        private void frmSede_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadOperacions(cboUnidad);
            Llenadocbo.ObtenerEstadoSedeOperacions(cboEstado);
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeOperaciones(cboSede, cod_unidad);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cod_estado = cboEstado.SelectedIndex;
            string cod_sede = cboSede.SelectedValue.ToString();
            try
            {
                Actualizar.actualizarestadoSede(cod_sede, cod_estado);
                MessageBox.Show("Actualizacion de estado completado exitosamente estado ", "Correcto");
                modulo.auditoriaFunciones("Operaciones", "Boton de Guardar Activacion de sede", "Modificar estado de la sede : " + cod_sede);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede actualizar el estado de la sede " + ex, "Error");
            }
        }
    }
}
