using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Operaciones.Unidad
{
    public partial class frmActivarUnidad : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatosOperaciones Llenadocbo = new Datos.LlenadoDeDatosOperaciones();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public frmActivarUnidad()
        {
            InitializeComponent();
        }

        private void frmActivarUnidad_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadOperacions(cboUnidad);
            Llenadocbo.ObtenerEstadoUnidadOperacions(cboEstado);
        }

        private void btnGuardadAsistencia_Click(object sender, EventArgs e)
        {
            int cod_estado = cboEstado.SelectedIndex;
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            try
            {
                Actualizar.actualizarestadounidad(cod_unidad, cod_estado);
                MessageBox.Show("Actualizacion de estado completado exitosamente estado ", "Correcto");
                this.Close();
                modulo.auditoriaFunciones("Operaciones", "Boton de Guardar Activacion de Unidad", "Modificar estado de la unidad : " + cod_unidad + " Estado :"+ cod_estado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede actualizar el estado de la unidad " + ex, "Error");
            }
        }
    }
}
