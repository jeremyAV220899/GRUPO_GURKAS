using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.CentroControl.ReporteCentroControl
{
    public partial class frmConsultaDeCantidadDeAsistenciaDeCadaSede : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC  Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();
        public frmConsultaDeCantidadDeAsistenciaDeCadaSede()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaPersonalSede(int cod_turno, DateTime fechaInicio, DateTime FechaFin, int cod_ordenamiento)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_TAREAJECantidadAsistenciaSede  @fechainicio,@fechafin,@Cod_turno,@Cod_ordenamiento";
                comando.Parameters.AddWithValue("Cod_turno", cod_turno);
                comando.Parameters.AddWithValue("fechainicio", fechaInicio);
                comando.Parameters.AddWithValue("fechafin", FechaFin);
                comando.Parameters.AddWithValue("Cod_ordenamiento", cod_ordenamiento);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Nombre Sede";
                dt.AcceptChanges();
                dgvConsultarAsistenciaSede.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro ningun resultado \n\n " + ex, "ERROR");
            }

        }

        private void frmConsultaDeCantidadDeAsistenciaDeCadaSede_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerOrdenamientoCentroControl(cboOrdenamiento);
            Llenadocbo.ObtenerTurnoCentroControl(cboTurno);
            dgvConsultarAsistenciaSede.RowHeadersVisible = false;
            dgvConsultarAsistenciaSede.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int cod_turno = cboTurno.SelectedIndex;
            int cod_ordenamiento = cboOrdenamiento.SelectedIndex;
            ConsultarAsistenciaPersonalSede(cod_turno, dtpFechaInicio.Value, dtpFechaFin.Value, cod_ordenamiento);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string nombre = cboOrdenamiento.GetItemText(cboOrdenamiento.SelectedItem);
            string fi = dtpFechaInicio.Value.Date.ToString("dd-MM-yyyy");
            string ff = dtpFechaFin.Value.Date.ToString("dd-MM-yyyy");

            Excel.ReporteResumenTareajeOrdenamietoExcel(dgvConsultarAsistenciaSede, progressBar1,nombre,fi,ff);
        }
    }
}
