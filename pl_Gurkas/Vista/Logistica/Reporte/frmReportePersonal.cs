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

namespace pl_Gurkas.Vista.Logistica.Reporte
{
    public partial class frmReportePersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.llenadoDatosLogistica Llenadocbo = new Datos.llenadoDatosLogistica();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        public frmReportePersonal()
        {
            InitializeComponent();
        }

        private void frmReportePersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerEmpresaLogistica(cboEmpresa);
            Llenadocbo.ObtenerPersonalLogistica(cboempleadoActivo);
        }
        private void ConsultarAsistenciaCodigo(int CodEmpresa)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_busacar_personal_logistica_codigo  @empresa";
                comando.Parameters.AddWithValue("empresa", CodEmpresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Estado";
                dt.Columns[3].ColumnName = "Empresa";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Reporte Personal";
            const string mensaje = "Estas seguro que deseas cerra el Reporte";
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvReporteGeneral, progressBar1);
        }

        private void btnConsultarPersonalEmpresa_Click(object sender, EventArgs e)
        {
            int cod_empresa = cboEmpresa.SelectedIndex;
            ConsultarAsistenciaCodigo(cod_empresa);
        }

        private void btnConsultarAsistecniaPersonal_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_busacar_personal_logistica_codigo_empelado  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Estado";
                dt.Columns[3].ColumnName = "Empresa";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
    }
}
