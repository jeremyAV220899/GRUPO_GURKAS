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

namespace pl_Gurkas.Vista.CentroControl.Android
{
    public partial class frmMigrarAndroidAsistencia : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.agregarDatosMysql Registrarmysql = new Datos.agregarDatosMysql();
        public frmMigrarAndroidAsistencia()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaPersonal( DateTime fechaInicio)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_PlanillasistenciaPersonalAndroid  @fechainicio";
                comando.Parameters.AddWithValue("fechainicio", fechaInicio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "ID Asistencia";
                dt.Columns[1].ColumnName = "TipoAsistencia";
                dt.Columns[2].ColumnName = "Cod Empleado";
                dt.Columns[3].ColumnName = "Fecha Vista";
                dt.Columns[4].ColumnName = "Codigo sede";
                dt.Columns[5].ColumnName = "Codigo Unidad";
                dt.Columns[6].ColumnName = "Fecha";
                dt.AcceptChanges();
                dgvAsistenciaDetalladoEmpleado.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarAsistenciaPersonal( dtpFechaInicio.Value);
        }

        private void btnGuardadAsistencia_Click(object sender, EventArgs e)
        {
            DateTime f = dtpFechaInicio.Value.Date;
            DateTime fa = DateTime.Now.Date;
            if (f == fa)
            {
                MessageBox.Show("Solo se puede cargar el dia anterior \n Ya que ese dia cuenta con asistencia completa",
                    "ERROR EN LA FECHA");
            }
            else
            {
                foreach (DataGridViewRow row in dgvAsistenciaDetalladoEmpleado.Rows)
                {
                    if (row.Cells["ID Asistencia"].Value != null && row.Cells["TipoAsistencia"].Value != null)
                    {
                        Registrarmysql.RegistroAsistencia(Convert.ToInt32(row.Cells["ID Asistencia"].Value), 
                            Convert.ToString(row.Cells["TipoAsistencia"].Value),
                             Convert.ToString(row.Cells["Cod Empleado"].Value),
                              Convert.ToString(row.Cells["Fecha Vista"].Value),
                               Convert.ToString(row.Cells["Codigo sede"].Value),
                               Convert.ToString(row.Cells["Codigo Unidad"].Value),
                               Convert.ToDateTime(row.Cells["Fecha"].Value)
                           );
                    }
                }
                MessageBox.Show("Se acaba de migar toda la asistencia de forma correcta ",
                 "Migracion exitosa");
            }
        }
    }
}
