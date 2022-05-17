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
    public partial class frmHistorialCTS : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();

        public frmHistorialCTS()
        {
            InitializeComponent();
        }

        private void frmHistorialCTS_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerPersonalPLANILLA(cboEmpleadoMesAnio);
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }
        private void buscar_mes_anio(int mes, int anio)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_cts_filtro_mes_anio_a  @mes,@anio";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA INGRESO A PLANILLA";
                dt.Columns[1].ColumnName = "TIEMPO COMPUTABLE- POR MESES";
                dt.Columns[2].ColumnName = "POR DIAS";
                dt.Columns[3].ColumnName = "FALTAS INJUSTI.";
                dt.Columns[4].ColumnName = "COD. TRABAJADR";
                dt.Columns[5].ColumnName = "DNI";
                dt.Columns[6].ColumnName = "NOMBRES";
                dt.Columns[7].ColumnName = "UNIDAD";
                dt.Columns[8].ColumnName = "CUENTA";
                dt.Columns[9].ColumnName = "SUELDO BRUTO";
                dt.Columns[10].ColumnName = "PROM. REMUNERACION BASICA";
                dt.Columns[11].ColumnName = "ASIGN. FAM.";
                dt.Columns[12].ColumnName = "PROM. H.E.";
                dt.Columns[13].ColumnName = "1/6 GRATI";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "CTS ANUAL";
                dt.Columns[16].ColumnName = "CTS MENSUAL";
                dt.Columns[17].ColumnName = "CTS X Nª DE MESES";
                dt.Columns[18].ColumnName = "CTS X N° DE DIAS";
                dt.Columns[19].ColumnName = "CTS X N° FALTOS";
                dt.Columns[20].ColumnName = "TOTAL CTS MESES + CTS DIAS";
                dt.Columns[21].ColumnName = "INTERESES";
                dt.Columns[22].ColumnName = "TOTAL CTS";
                dt.Columns[23].ColumnName = "TOTAL A ABONAR";
                dt.Columns[24].ColumnName = "CUENTA CTS";
                dt.Columns[25].ColumnName = "BANCO";
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
                comando.CommandText = "sp_historial_cts_filtro_mes_anio  @cod_empleado,@mes,@anio";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA INGRESO A PLANILLA";
                dt.Columns[1].ColumnName = "TIEMPO COMPUTABLE- POR MESES";
                dt.Columns[2].ColumnName = "POR DIAS";
                dt.Columns[3].ColumnName = "FALTAS INJUSTI.";
                dt.Columns[4].ColumnName = "COD. TRABAJADR";
                dt.Columns[5].ColumnName = "DNI";
                dt.Columns[6].ColumnName = "NOMBRES";
                dt.Columns[7].ColumnName = "UNIDAD";
                dt.Columns[8].ColumnName = "CUENTA";
                dt.Columns[9].ColumnName = "SUELDO BRUTO";
                dt.Columns[10].ColumnName = "PROM. REMUNERACION BASICA";
                dt.Columns[11].ColumnName = "ASIGN. FAM.";
                dt.Columns[12].ColumnName = "PROM. H.E.";
                dt.Columns[13].ColumnName = "1/6 GRATI";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "CTS ANUAL";
                dt.Columns[16].ColumnName = "CTS MENSUAL";
                dt.Columns[17].ColumnName = "CTS X Nª DE MESES";
                dt.Columns[18].ColumnName = "CTS X N° DE DIAS";
                dt.Columns[19].ColumnName = "CTS X N° FALTOS";
                dt.Columns[20].ColumnName = "TOTAL CTS MESES + CTS DIAS";
                dt.Columns[21].ColumnName = "INTERESES";
                dt.Columns[22].ColumnName = "TOTAL CTS";
                dt.Columns[23].ColumnName = "TOTAL A ABONAR";
                dt.Columns[24].ColumnName = "CUENTA CTS";
                dt.Columns[25].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Planilla de Descanso Medico";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Descanso Medico";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_cts_filtro_cod_empleado @cod_empleado ";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA INGRESO A PLANILLA";
                dt.Columns[1].ColumnName = "TIEMPO COMPUTABLE- POR MESES";
                dt.Columns[2].ColumnName = "POR DIAS";
                dt.Columns[3].ColumnName = "FALTAS INJUSTI.";
                dt.Columns[4].ColumnName = "COD. TRABAJADR";
                dt.Columns[5].ColumnName = "DNI";
                dt.Columns[6].ColumnName = "NOMBRES";
                dt.Columns[7].ColumnName = "UNIDAD";
                dt.Columns[8].ColumnName = "CUENTA";
                dt.Columns[9].ColumnName = "SUELDO BRUTO";
                dt.Columns[10].ColumnName = "PROM. REMUNERACION BASICA";
                dt.Columns[11].ColumnName = "ASIGN. FAM.";
                dt.Columns[12].ColumnName = "PROM. H.E.";
                dt.Columns[13].ColumnName = "1/6 GRATI";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "CTS ANUAL";
                dt.Columns[16].ColumnName = "CTS MENSUAL";
                dt.Columns[17].ColumnName = "CTS X Nª DE MESES";
                dt.Columns[18].ColumnName = "CTS X N° DE DIAS";
                dt.Columns[19].ColumnName = "CTS X N° FALTOS";
                dt.Columns[20].ColumnName = "TOTAL CTS MESES + CTS DIAS";
                dt.Columns[21].ColumnName = "INTERESES";
                dt.Columns[22].ColumnName = "TOTAL CTS";
                dt.Columns[23].ColumnName = "TOTAL A ABONAR";
                dt.Columns[24].ColumnName = "CUENTA CTS";
                dt.Columns[25].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            buscar_mes_anio(mes, anio);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosCTSExcel(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
