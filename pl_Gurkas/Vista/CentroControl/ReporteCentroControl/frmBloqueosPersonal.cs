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
    public partial class frmBloqueosPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();
        public frmBloqueosPersonal()
        {
            InitializeComponent();
        }

        private void frmBloqueosPersonal_Load(object sender, EventArgs e)
        {
            dgvMarcacionFechaTurno.RowHeadersVisible = false;
            dgvMarcacionFechaTurno.AllowUserToAddRows = false;
        }
        private void AsistenciaTurnoMarcacion( DateTime fechainicio, DateTime fechafin)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_CONSULTA_DE_BAJAS @FECHA_INICIO,@FECHA_FIN";
                comando.Parameters.AddWithValue("FECHA_INICIO", fechainicio);
                comando.Parameters.AddWithValue("FECHA_FIN", fechafin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "CODIGO";
                dt.Columns[1].ColumnName = "UNIDAD";
                dt.Columns[2].ColumnName = "AGENTE";
                dt.Columns[3].ColumnName = "MARCACION";
                dt.Columns[4].ColumnName = "FECHA";
                dt.Columns[5].ColumnName = "TURNO";
                dt.Columns[6].ColumnName = "< DE 3 MESES";
                dt.Columns[7].ColumnName = ">  DE 3 MESES";
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
           
            AsistenciaTurnoMarcacion( dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBajasCentroControl(dgvMarcacionFechaTurno, progressBar1);
        }
    }
}
