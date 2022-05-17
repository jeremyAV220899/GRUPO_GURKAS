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

namespace pl_Gurkas.Vista.Planilla.ReportePlanilla
{
    public partial class frmReporteAsistenciaPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();

        public frmReporteAsistenciaPersonal()
        {
            InitializeComponent();
        }
        private void buscarasistencia(DateTime finicio , DateTime ffin )
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RESUMEN_ASISTENCIA_PLANILLA  @fechaInicio, @fechaFin";
                //comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
                comando.Parameters.AddWithValue("fechaInicio", finicio);
                comando.Parameters.AddWithValue("fechaFin", ffin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.AcceptChanges();
                dgvAsistenciaPersonalGeneralSede.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex, "");

                //throw;
            }
        }

        private void buscarasistenciaTotal(DateTime finicio, DateTime ffin)
        {
            try
            {
                int empresa = Datos.EmpresaID._empresaid;
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RESUMEN_ASISTENCIA_PLANILLA_TOTAL  @fechaInicio, @fechaFin,@empresa";
                //comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
                comando.Parameters.AddWithValue("fechaInicio", finicio);
                comando.Parameters.AddWithValue("fechaFin", ffin);
                comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.AcceptChanges();
                dgvAsistenciaPersonalGeneralSede.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex, "");

                //throw;
            }
        }

        private void frmReporteAsistenciaPersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadPlanillas(cboUnidad);
            lbcodigosUnidad.Visible = false;
            dgvAsistenciaPersonalGeneralSede.RowHeadersVisible = false;
            dgvAsistenciaPersonalGeneralSede.AllowUserToAddRows = false;
        }
        private void unidad_temporal()
        {
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SP_TEMPORA_UNIDAD_ASISTENCIA_RESUMEN";
            comando.ExecuteNonQuery();
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {

            unidad_temporal();
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            DateTime fechaconsulta = DateTime.Now.Date;
            SqlCommand comando = new SqlCommand("sp_insertar_unidad_resumen_asistencia @param1", conexion.conexionBD());
            for (int i = 0; i < lbcodigosUnidad.Items.Count; i++)
            {
                // string info = lbcodigosUnidad.Items[i].ToString();
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@param1", lbcodigosUnidad.Items[i].ToString());
                comando.ExecuteNonQuery();
            }

            buscarasistencia(dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string nombre = "Resumen Tareaje";// cboUnidad.GetItemText(cboUnidad.SelectedItem);
            string fi = dtpFechaInicio.Value.Date.ToString("dd-MM-yyyy");
            string ff = dtpFechaFin.Value.Date.ToString("dd-MM-yyyy");
            Excel.ReporteAsistenciaPlanillaExcel(dgvAsistenciaPersonalGeneralSede, progressBar1, nombre, fi, ff);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbunidades.Items.Add(cboUnidad.GetItemText(cboUnidad.SelectedItem));
            lbcodigosUnidad.Items.Add(cboUnidad.SelectedValue.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {

            lbunidades.Items.Clear();
            lbcodigosUnidad.Items.Clear();
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_eliminar_unidad_asistencia_resumen";
            comando.ExecuteNonQuery();
        }

        private void btnAsistenciaCompleta_Click(object sender, EventArgs e)
        {
            buscarasistenciaTotal(dtpFechaInicio.Value, dtpFechaFin.Value);
        }
    }
}
