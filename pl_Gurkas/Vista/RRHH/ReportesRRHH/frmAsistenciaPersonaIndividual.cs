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
    public partial class frmAsistenciaPersonaIndividual : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        public frmAsistenciaPersonaIndividual()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaPersonal(String Cod_Trabajador, DateTime fechaInicio, DateTime FechaFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_PersonalAsistencia  @Cod_empleado,@fechainicio, @fechafin";
                comando.Parameters.AddWithValue("Cod_empleado", Cod_Trabajador);
                comando.Parameters.AddWithValue("fechainicio", fechaInicio);
                comando.Parameters.AddWithValue("fechafin", FechaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Codigo Empleado";
                dt.Columns[1].ColumnName = "Nombre Empleado";
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
                dgvAsistenciaPersonal.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvAsistenciaPersonal, progressBar1);
        }

        private void frmAsistenciaPersonaIndividual_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalRRHH(cboempleadoActivo);
            dgvAsistenciaPersonal.RowHeadersVisible = false;
            dgvAsistenciaPersonal.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();

            ConsultarAsistenciaPersonal(cod_empleado, dtpFechaInicio.Value, dtpFechaFin.Value);
        }
    }
}
