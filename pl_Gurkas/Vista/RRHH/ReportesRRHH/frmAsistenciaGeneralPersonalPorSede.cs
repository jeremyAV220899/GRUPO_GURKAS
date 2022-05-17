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

namespace pl_Gurkas.Vista.RRHH.ReportesRRHH
{
    public partial class frmAsistenciaGeneralPersonalPorSede : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();

        public frmAsistenciaGeneralPersonalPorSede()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaSede(DateTime fechaInicio, DateTime FechaFin, string Sede)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHH_AsistenciaGeneralPersonalSede @Sede, @fechaInicio, @FechaFin";
                comando.Parameters.AddWithValue("Sede", Sede);
                comando.Parameters.AddWithValue("fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("FechaFin", FechaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio";
                dt.Columns[6].ColumnName = "Sede ";
                dt.Columns[7].ColumnName = "Tipo Asistencia";
                dt.Columns[8].ColumnName = "Fecha Asistencia";
                dt.Columns[9].ColumnName = "Turno";
                dt.Columns[10].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvAsistenciaPersonalGeneralSede.DataSource = dt;
            }
            catch (Exception)
            {
                /*
                 MessageBox.Show("", "");
                */
                throw;
            }
        }
        private void frmAsistenciaGeneralPersonalPorSede_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadRRHH(cboUnidad);
            dgvAsistenciaPersonalGeneralSede.RowHeadersVisible = false;
            dgvAsistenciaPersonalGeneralSede.AllowUserToAddRows = false;
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeRRHH(cboSede, cod_unidad);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvAsistenciaPersonalGeneralSede, progressBar1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sede = cboSede.SelectedValue.ToString();
            ConsultarAsistenciaSede(dtpFechaInicio.Value, dtpFechaFin.Value, sede);
        }
    }
}
