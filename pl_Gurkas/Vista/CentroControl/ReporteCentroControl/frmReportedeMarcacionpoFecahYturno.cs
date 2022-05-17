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
    public partial class frmReportedeMarcacionpoFecahYturno : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();
        public frmReportedeMarcacionpoFecahYturno()
        {
            InitializeComponent();
        }

        private void frmReportedeMarcacionpoFecahYturno_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerTipoAsistenciaCentroControl(cboTipoMarcacion);
            Llenadocbo.ObtenerTurnoCentroControl(cboTurno);

            dgvMarcacionFechaTurno.RowHeadersVisible = false;
            dgvMarcacionFechaTurno.AllowUserToAddRows = false;
        }
        private void AsistenciaTurnoMarcacion(string cod_tipomarcacion, int cod_turno, DateTime fechainicio, DateTime fechafin)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_TareajeBuscarFechayTurno  @TipoMarchacion,@codTurno,@fehcaInicio,@fechaFin";
                comando.Parameters.AddWithValue("TipoMarchacion", cod_tipomarcacion);
                comando.Parameters.AddWithValue("codTurno", cod_turno);
                comando.Parameters.AddWithValue("fehcaInicio", fechainicio);
                comando.Parameters.AddWithValue("fechaFin", fechafin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Nombre Sede";
                dt.Columns[2].ColumnName = "Empleado";
                dt.Columns[3].ColumnName = "Tipo Asistencia";
                dt.Columns[4].ColumnName = "Fecha Asistencia";
                dt.AcceptChanges();
                dgvMarcacionFechaTurno.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_tipomarcacion = cboTipoMarcacion.SelectedValue.ToString();
            int cod_turno = cboTurno.SelectedIndex;
            AsistenciaTurnoMarcacion(cod_tipomarcacion, cod_turno, dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string turno = cboTurno.GetItemText(cboTurno.SelectedItem);
            string tipo_marcacion = cboTipoMarcacion.GetItemText(cboTipoMarcacion.SelectedItem);
            string fi = dtpFechaInicio.Value.Date.ToString("dd-MM-yyyy");
            string ff = dtpFechaFin.Value.Date.ToString("dd-MM-yyyy");
            Excel.ReporteResumenTareajeTurnoFechaExcel(dgvMarcacionFechaTurno, progressBar1, turno, fi, ff, tipo_marcacion);
        }
    }
}
