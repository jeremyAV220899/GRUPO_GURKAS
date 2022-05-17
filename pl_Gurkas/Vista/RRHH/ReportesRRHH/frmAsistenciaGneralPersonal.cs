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
    public partial class frmAsistenciaGneralPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        public frmAsistenciaGneralPersonal()
        {
            InitializeComponent();
        }
        private void ConsultarAsistencia(DateTime fechaInicio, DateTime FechaFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHH_AsistenciaGeneralPersonal  @fechaInicio, @FechaFin";
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
                dgvAsistenciaGeneralPersonal.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void frmAsistenciaGneralPersonal_Load(object sender, EventArgs e)
        {
            dgvAsistenciaGeneralPersonal.RowHeadersVisible = false;
            dgvAsistenciaGeneralPersonal.AllowUserToAddRows = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvAsistenciaGeneralPersonal, progressBar1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarAsistencia(dtpFechaInicio.Value, dtpFechaFin.Value);
        }
    }
}
