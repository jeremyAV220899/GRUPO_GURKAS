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

namespace pl_Gurkas.Vista.CentroControl.ReporteAsistencia
{
    public partial class frmAsistenciadePersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();
        public frmAsistenciadePersonal()
        {
            InitializeComponent();
        }

        private void frmAsistenciadePersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadCentroControl(cboUnidad);
            dgvAsistenciaPersonal.RowHeadersVisible = false;
            dgvAsistenciaPersonal.AllowUserToAddRows = false;
        }
        private void ConsultarAsistenciaPersonal(DateTime fechaInicio, DateTime FechaFin, string cod_unidad)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_TAREsistenciaPersonal  @fechainicio,@fechafin,@cod_unidad";
                comando.Parameters.AddWithValue("fechainicio", fechaInicio);
                comando.Parameters.AddWithValue("fechafin", FechaFin);
                comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Nombre Sede";
                dt.Columns[3].ColumnName = "Empresa";
                dt.Columns[4].ColumnName = "Asistencia";
                dt.Columns[5].ColumnName = "Descanso";
                dt.Columns[6].ColumnName = "Descanso Trabajado";
                dt.Columns[7].ColumnName = "Falta";
                dt.Columns[8].ColumnName = "Permiso";
                dt.Columns[9].ColumnName = "Tardanza";
                dt.Columns[10].ColumnName = "Vacaciones";
                dt.Columns[11].ColumnName = "Suspension";
                dt.Columns[12].ColumnName = "Licencia";
                dt.Columns[13].ColumnName = "Renganche";
                dt.AcceptChanges();
                dgvAsistenciaPersonal.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            ConsultarAsistenciaPersonal(dtpFechaInicio.Value, dtpFechaFin.Value, cod_unidad);
        }
    }
}
