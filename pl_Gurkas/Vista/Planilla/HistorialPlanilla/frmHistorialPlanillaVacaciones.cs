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
    public partial class frmHistorialPlanillaVacaciones : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();

        public frmHistorialPlanillaVacaciones()
        {
            InitializeComponent();
        }
        private void buscar_cod_emepladpo(string cod_empleado)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_vacaciones_cod_empleado  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "cod_empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "UNIDAD";
                dt.Columns[3].ColumnName = "Puesto";
                dt.Columns[4].ColumnName = "F. ING. PLANILLA";
                dt.Columns[5].ColumnName = "ANTIGÜEDAD";
                dt.Columns[6].ColumnName = "PERIODO PAGADO";
                dt.Columns[7].ColumnName = "D. ACUMULADO";
                dt.Columns[8].ColumnName = "Fecha Inicio";
                dt.Columns[9].ColumnName = "Fecha Fin";
                dt.Columns[10].ColumnName = "TOTAL DIAS DISFRUTADOS";
                dt.Columns[11].ColumnName = "DIAS VENDIDOS";
                dt.Columns[12].ColumnName = "DIAS PENDIENTES";
                dt.Columns[13].ColumnName = "Sueldo";
                dt.Columns[14].ColumnName = "Asignacion Familiar";
                dt.Columns[15].ColumnName = "SUELDO BASICO DE LA UNIDAD";
                dt.Columns[16].ColumnName = "V. BRUTAS";
                dt.Columns[17].ColumnName = "AFP/ONP";
                dt.Columns[18].ColumnName = "AFP/ONP %";
                dt.Columns[19].ColumnName = "APP OBLIGATORIO";
                dt.Columns[20].ColumnName = "Comisión";
                dt.Columns[21].ColumnName = "Prima Seguro";
                dt.Columns[22].ColumnName = "DSCTO S.P";
                dt.Columns[23].ColumnName = "TOTAL A PAGAR";
                dt.Columns[24].ColumnName = "Tipo Documentos";
                dt.Columns[25].ColumnName = "Num Documento";
                dt.Columns[26].ColumnName = "CUENTA";
                dt.Columns[27].ColumnName = "BANCO";
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
                comando.CommandText = "sp_historial_planilla_vacaciones  @cod_empleado,@mes,@anio";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "cod_empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "UNIDAD";
                dt.Columns[3].ColumnName = "Puesto";
                dt.Columns[4].ColumnName = "F. ING. PLANILLA";
                dt.Columns[5].ColumnName = "ANTIGÜEDAD";
                dt.Columns[6].ColumnName = "PERIODO PAGADO";
                dt.Columns[7].ColumnName = "D. ACUMULADO";
                dt.Columns[8].ColumnName = "Fecha Inicio";
                dt.Columns[9].ColumnName = "Fecha Fin";
                dt.Columns[10].ColumnName = "TOTAL DIAS DISFRUTADOS";
                dt.Columns[11].ColumnName = "DIAS VENDIDOS";
                dt.Columns[12].ColumnName = "DIAS PENDIENTES";
                dt.Columns[13].ColumnName = "Sueldo";
                dt.Columns[14].ColumnName = "Asignacion Familiar";
                dt.Columns[15].ColumnName = "SUELDO BASICO DE LA UNIDAD";
                dt.Columns[16].ColumnName = "V. BRUTAS";
                dt.Columns[17].ColumnName = "AFP/ONP";
                dt.Columns[18].ColumnName = "AFP/ONP %";
                dt.Columns[19].ColumnName = "APP OBLIGATORIO";
                dt.Columns[20].ColumnName = "Comisión";
                dt.Columns[21].ColumnName = "Prima Seguro";
                dt.Columns[22].ColumnName = "DSCTO S.P";
                dt.Columns[23].ColumnName = "TOTAL A PAGAR";
                dt.Columns[24].ColumnName = "Tipo Documentos";
                dt.Columns[25].ColumnName = "Num Documento";
                dt.Columns[26].ColumnName = "CUENTA";
                dt.Columns[27].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buscar_mes_anio(int mes, int anio, int empresa)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_vacaciones_anio_mes_2  @mes,@anio,@empresa";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "cod_empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "UNIDAD";
                dt.Columns[3].ColumnName = "Puesto";
                dt.Columns[4].ColumnName = "F. ING. PLANILLA";
                dt.Columns[5].ColumnName = "ANTIGÜEDAD";
                dt.Columns[6].ColumnName = "PERIODO PAGADO";
                dt.Columns[7].ColumnName = "D. ACUMULADO";
                dt.Columns[8].ColumnName = "Fecha Inicio";
                dt.Columns[9].ColumnName = "Fecha Fin";
                dt.Columns[10].ColumnName = "TOTAL DIAS DISFRUTADOS";
                dt.Columns[11].ColumnName = "DIAS VENDIDOS";
                dt.Columns[12].ColumnName = "DIAS PENDIENTES";
                dt.Columns[13].ColumnName = "Sueldo";
                dt.Columns[14].ColumnName = "Asignacion Familiar";
                dt.Columns[15].ColumnName = "SUELDO BASICO DE LA UNIDAD";
                dt.Columns[16].ColumnName = "V. BRUTAS";
                dt.Columns[17].ColumnName = "AFP/ONP";
                dt.Columns[18].ColumnName = "AFP/ONP %";
                dt.Columns[19].ColumnName = "APP OBLIGATORIO";
                dt.Columns[20].ColumnName = "Comisión";
                dt.Columns[21].ColumnName = "Prima Seguro";
                dt.Columns[22].ColumnName = "DSCTO S.P";
                dt.Columns[23].ColumnName = "TOTAL A PAGAR";
                dt.Columns[24].ColumnName = "Tipo Documentos";
                dt.Columns[25].ColumnName = "Num Documento";
                dt.Columns[26].ColumnName = "CUENTA";
                dt.Columns[27].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmHistorialPlanillaVacaciones_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerPersonalPLANILLA(cboEmpleadoMesAnio);
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Historial de Vacaciones";
            const string mensaje = "Estas seguro que deseas cerra el Historial de Vacaciones";
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
            buscar_mes_anio(mes, anio, empresa);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarraVacaciones(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
