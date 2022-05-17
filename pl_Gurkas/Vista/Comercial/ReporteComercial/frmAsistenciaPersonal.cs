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
    public partial class frmAsistenciaPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDeDatosComercial Llenadocbo = new Datos.LlenadoDeDatosComercial();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();

        public frmAsistenciaPersonal()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaPersonal(DateTime fechaInicio, DateTime FechaFin, string cod_unidad)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_TAREsistenciaPersonalunidad  @fechainicio,@fechafin,@cod_unidad";
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
                dt.Columns[14].ColumnName = "Feriado";
                dt.AcceptChanges();
                dgvAsistenciaPersonal.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
        private void frmAsistenciaPersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadComercial(cboUnidad);
            dgvAsistenciaPersonal.RowHeadersVisible = false;
            dgvAsistenciaPersonal.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            ConsultarAsistenciaPersonal(dtpFechaInicio.Value, dtpFechaFin.Value, cod_unidad);
            modulo.auditoriaFunciones("Comercial", "Buscar Asistencia de Personal", "Busqueda de la Asistencia de personal de la unidad  : " + cod_unidad);
        }

        private void cboTurno_Click(object sender, EventArgs e)
        {
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            modulo.auditoriaFunciones("Comercial", "Excel", "Generar excel de la Asistencia de personal de la unidad  : " + cod_unidad);
        }
    }
}
