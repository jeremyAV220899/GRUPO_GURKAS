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

namespace pl_Gurkas.Vista.Comercial.ReporteComercial
{
    public partial class frmAsistenciaPersonalDetallado : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatosComercial Llenadocbo = new Datos.LlenadoDeDatosComercial();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public frmAsistenciaPersonalDetallado()
        {
            InitializeComponent();
        }
        private void ConsultarPersonalDetallado(DateTime fechaInicio, DateTime FechaFin, string cod_unidad)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_asistenciadetalladoPersonal  @fechainicio,@fechafin,@cod_unidad";
                comando.Parameters.AddWithValue("fechainicio", fechaInicio);
                comando.Parameters.AddWithValue("fechafin", FechaFin);
                comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Sede";
                dt.Columns[3].ColumnName = "Empresa";
                dt.Columns[4].ColumnName = "Num Documento";
                dt.Columns[5].ColumnName = "Fecha";
                dt.Columns[6].ColumnName = "Tipo Asistencia";
                dt.AcceptChanges();
                dgvAsistenciaPersonalDetallado.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            ConsultarPersonalDetallado(dtpFechaInicio.Value, dtpFechaFin.Value, cod_unidad);
            modulo.auditoriaFunciones("Comercial", "Buscar Asistencia de Personal Detallado", "Busqueda de la Asistencia de personal detallado de la unidad  : " + cod_unidad);
        }

        private void frmAsistenciaPersonalDetallado_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadComercial(cboUnidad);
            dgvAsistenciaPersonalDetallado.RowHeadersVisible = false;
            dgvAsistenciaPersonalDetallado.AllowUserToAddRows = false;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            modulo.auditoriaFunciones("Comercial", "Excel", "Excel de la Asistencia de personal detallado de la unidad  : " + cod_unidad);
        }
    }
}
