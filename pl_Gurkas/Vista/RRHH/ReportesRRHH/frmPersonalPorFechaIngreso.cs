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
    public partial class frmPersonalPorFechaIngreso : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        int id_empresa = Datos.EmpresaID._empresaid;
        public frmPersonalPorFechaIngreso()
        {
            InitializeComponent();
        }
        private void ConsultarFechaIngreso(DateTime fechaInicio, DateTime FechaFin,int empresa)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHHFechaIngreso  @fechaInicio, @FechaFin,@id_empresa";
                comando.Parameters.AddWithValue("fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("FechaFin", FechaFin);
                comando.Parameters.AddWithValue("id_empresa", empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio Laboral";
                dt.Columns[6].ColumnName = "Puesto ";
                dt.Columns[7].ColumnName = "Sede";
                dt.Columns[8].ColumnName = "Turno";
                dt.Columns[9].ColumnName = "Estado Personal";
                dt.AcceptChanges();
                dgvFechaIngresoPersonal.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void frmPersonalPorFechaIngreso_Load(object sender, EventArgs e)
        {
            dgvFechaIngresoPersonal.RowHeadersVisible = false;
            dgvFechaIngresoPersonal.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarFechaIngreso(dtpFechaInicio.Value, dtpFechaFin.Value, id_empresa);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvFechaIngresoPersonal, progressBar1);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Reporte RRHH";
            const string mensaje = "Estas seguro que deseas cerra el reporte de Personal por Fecha de ingreso";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                // obtenerip_nombre();
                // string username = Code.nivelUser._nombre;
                string detalle = "Cerrar Registro de Personal";
                string cod_buscado = "Cerro el registro de Personal";
                // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                this.Close();
            }
        }
    }
}
