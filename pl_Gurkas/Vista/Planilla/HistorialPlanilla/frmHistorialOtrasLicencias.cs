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

namespace pl_Gurkas.Vista.Planilla.HistorialPlanilla
{
    public partial class frmHistorialOtrasLicencias : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        public frmHistorialOtrasLicencias()
        {
            InitializeComponent();
        }
        private void buscar_cod_emepladpo(string cod_empleado)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_otras_licencias_cod_empleado  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA SOLICITADA";
                dt.Columns[1].ColumnName = "Cod_Empleado";
                dt.Columns[2].ColumnName = "NOMBRE DE TRABAJADOR";
                dt.Columns[3].ColumnName = "AREA";
                dt.Columns[4].ColumnName = "PUESTO";
                dt.Columns[5].ColumnName = "UNIDAD";
                dt.Columns[6].ColumnName = "TIPO DE LICENCIA";
                dt.Columns[7].ColumnName = "TIPO DE DOCUMENTO";
                dt.Columns[8].ColumnName = "Fecha Inicio";
                dt.Columns[9].ColumnName = "Fecha Fin";
                dt.Columns[10].ColumnName = "Nº DIAS";
                dt.Columns[11].ColumnName = "TOTAL";
                dt.Columns[12].ColumnName = "REGIMEN PENSIONARIO";
                dt.Columns[13].ColumnName = "% AFP";
                dt.Columns[14].ColumnName = "APP OBLIGATORIA";
                dt.Columns[15].ColumnName = "COMISION OBLIGATORIA";
                dt.Columns[16].ColumnName = "PRIMA SEGURO";
                dt.Columns[17].ColumnName = "CANT. AFP";
                dt.Columns[18].ColumnName = "NETO A PAGAR";
                dt.Columns[19].ColumnName = "Tipo de Documento";
                dt.Columns[20].ColumnName = "Num Documento";
                dt.Columns[21].ColumnName = "Cuenta";
                dt.Columns[22].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buscar_mes_anio_empleado(string cod_empleado, int mes, int anio)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_otras_licencias  @cod_empleado,@mes,@anio";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA SOLICITADA";
                dt.Columns[1].ColumnName = "Cod_Empleado";
                dt.Columns[2].ColumnName = "NOMBRE DE TRABAJADOR";
                dt.Columns[3].ColumnName = "AREA";
                dt.Columns[4].ColumnName = "PUESTO";
                dt.Columns[5].ColumnName = "UNIDAD";
                dt.Columns[6].ColumnName = "TIPO DE LICENCIA";
                dt.Columns[7].ColumnName = "TIPO DE DOCUMENTO";
                dt.Columns[8].ColumnName = "Fecha Inicio";
                dt.Columns[9].ColumnName = "Fecha Fin";
                dt.Columns[10].ColumnName = "Nº DIAS";
                dt.Columns[11].ColumnName = "TOTAL";
                dt.Columns[12].ColumnName = "REGIMEN PENSIONARIO";
                dt.Columns[13].ColumnName = "% AFP";
                dt.Columns[14].ColumnName = "APP OBLIGATORIA";
                dt.Columns[15].ColumnName = "COMISION OBLIGATORIA";
                dt.Columns[16].ColumnName = "PRIMA SEGURO";
                dt.Columns[17].ColumnName = "CANT. AFP";
                dt.Columns[18].ColumnName = "NETO A PAGAR";
                dt.Columns[19].ColumnName = "Tipo de Documento";
                dt.Columns[20].ColumnName = "Num Documento";
                dt.Columns[21].ColumnName = "Cuenta";
                dt.Columns[22].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buscar_mes_anio(int mes, int anio,int empresa)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_otras_licencias_anio_mes_2  @mes,@anio,@empresa";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA SOLICITADA";
                dt.Columns[1].ColumnName = "Cod_Empleado";
                dt.Columns[2].ColumnName = "NOMBRE DE TRABAJADOR";
                dt.Columns[3].ColumnName = "AREA";
                dt.Columns[4].ColumnName = "PUESTO";
                dt.Columns[5].ColumnName = "UNIDAD";
                dt.Columns[6].ColumnName = "TIPO DE LICENCIA";
                dt.Columns[7].ColumnName = "TIPO DE DOCUMENTO";
                dt.Columns[8].ColumnName = "Fecha Inicio";
                dt.Columns[9].ColumnName = "Fecha Fin";
                dt.Columns[10].ColumnName = "Nº DIAS";
                dt.Columns[11].ColumnName = "TOTAL";
                dt.Columns[12].ColumnName = "REGIMEN PENSIONARIO";
                dt.Columns[13].ColumnName = "% AFP";
                dt.Columns[14].ColumnName = "APP OBLIGATORIA";
                dt.Columns[15].ColumnName = "COMISION OBLIGATORIA";
                dt.Columns[16].ColumnName = "PRIMA SEGURO";
                dt.Columns[17].ColumnName = "CANT. AFP";
                dt.Columns[18].ColumnName = "NETO A PAGAR";
                dt.Columns[19].ColumnName = "Tipo de Documento";
                dt.Columns[20].ColumnName = "Num Documento";
                dt.Columns[21].ColumnName = "Cuenta";
                dt.Columns[22].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmHistorialOtrasLicencias_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerPersonalPLANILLA(cboEmpleadoMesAnio);
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Planilla de otras Licencias";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Planilla de otras Licencias";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            buscar_cod_emepladpo(cod_empleado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboEmpleadoMesAnio.SelectedValue.ToString();
            int mes = Convert.ToInt32(txtmesunidad.Text);
            int anio = Convert.ToInt32(txtunidadanio.Text);
            buscar_mes_anio_empleado(cod_empleado, mes, anio);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(txtm.Text);
            int anio = Convert.ToInt32(txta.Text);
            int empresa = Datos.EmpresaID._empresaid;
            buscar_mes_anio(mes, anio,empresa);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarraOtrasLicencias(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
