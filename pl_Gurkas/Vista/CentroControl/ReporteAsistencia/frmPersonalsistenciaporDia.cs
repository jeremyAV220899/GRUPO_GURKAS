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
    public partial class frmPersonalsistenciaporDia : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();

        public frmPersonalsistenciaporDia()
        {
            InitializeComponent();
        }
        private void ConsultarPersonalregistradoSede(DateTime fechaInicio)
        {
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_TAREAJEpersonalSede  @FechaCreacion,@cod_unidad";
                comando.Parameters.AddWithValue("FechaCreacion", fechaInicio);
                comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Asistencia";
                dt.Columns[3].ColumnName = "Descanso";
                dt.Columns[4].ColumnName = "Descanso Trabajado";
                dt.Columns[5].ColumnName = "Falta";
                dt.Columns[6].ColumnName = "Permiso";
                dt.Columns[7].ColumnName = "Tardanza";
                dt.Columns[8].ColumnName = "Vacaciones";
                dt.Columns[9].ColumnName = "Suspension";
                dt.Columns[10].ColumnName = "Licencia";
                dt.Columns[11].ColumnName = "Renganche";
                dt.AcceptChanges();
                dgvRegistrarPorSede.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void frmPersonalsistenciaporDia_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadCentroControl(cboUnidad);
            dgvRegistrarPorSede.RowHeadersVisible = false;
            dgvRegistrarPorSede.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarPersonalregistradoSede( dtpFecha.Value);
        }
    }
}
