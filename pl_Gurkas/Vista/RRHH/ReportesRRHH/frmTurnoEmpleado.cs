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
    public partial class frmTurnoEmpleado : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();

        public frmTurnoEmpleado()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaPorTurno()
        {
            try
            {
                int turno = cboTurno.SelectedIndex;
                int id_empresa = Datos.EmpresaID._empresaid;
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_REPORTERRHH_PorTurno  " + turno + "," + id_empresa;


                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Asistencia";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Documento";
                dt.Columns[3].ColumnName = "Fecha Nacimiento";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Turno";
                dt.AcceptChanges();
                dgvPersonalTurno.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro ningun resultado" + ex, "error");
            }
        }
        private void frmTurnoEmpleado_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerTurnoRRHH(cboTurno);
            dgvPersonalTurno.RowHeadersVisible = false;
            dgvPersonalTurno.AllowUserToAddRows = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvPersonalTurno, progressBar1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarAsistenciaPorTurno();
        }
    }
}
