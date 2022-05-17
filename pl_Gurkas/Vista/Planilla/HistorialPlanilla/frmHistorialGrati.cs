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
    public partial class frmHistorialGrati : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        public frmHistorialGrati()
        {
            InitializeComponent();
        }

        private void frmHistorialGrati_Load(object sender, EventArgs e)
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
                comando.CommandText = "sp_historial_grati_filtro_mes_anio_2  @mes,@anio";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA INGRESO A PLANILLA";
                dt.Columns[1].ColumnName = "MES";
                dt.Columns[2].ColumnName = "DIAS NO LABORADOS / FALTAS";
                dt.Columns[3].ColumnName = "COD. TRABAJADR";
                dt.Columns[4].ColumnName = "DNI";
                dt.Columns[5].ColumnName = "NOMBRES";
                dt.Columns[6].ColumnName = "UNIDAD";
                dt.Columns[7].ColumnName = "SUELDO";
                dt.Columns[8].ColumnName = "PROM. REMUNERACION BASICA";
                dt.Columns[9].ColumnName = "ASIGN. FAM.";
                dt.Columns[10].ColumnName = "PROM. H.E.";
                dt.Columns[11].ColumnName = "PROM DIURNA NOCT";
                dt.Columns[12].ColumnName = "MOVILIDAD";
                dt.Columns[13].ColumnName = "PROM FERIADO";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "GRATI SEMESTRAL";
                dt.Columns[16].ColumnName = "GRATI MENSUAL";
                dt.Columns[17].ColumnName = "GRATI X Nª DE MESES";
                dt.Columns[18].ColumnName = "DIAS NO LABORADOS";
                dt.Columns[19].ColumnName = "GRATI X Nª DE MESES ANTES DE BO";
                dt.Columns[20].ColumnName = "BONIF 9%";
                dt.Columns[21].ColumnName = "GRATI 1";
                dt.Columns[22].ColumnName = "DESCUENTOS/RTENCION ALIMENTOS";
                dt.Columns[23].ColumnName = "TOTAL GRATIF";
                dt.Columns[24].ColumnName = "GRATI 2";
                dt.Columns[25].ColumnName = "GRATI A PAGAR";
                dt.Columns[26].ColumnName = "CUENTA SUELDO";
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
                comando.CommandText = "sp_historial_grati_filtro_mes_anio  @cod_empleado,@mes,@anio";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA INGRESO A PLANILLA";
                dt.Columns[1].ColumnName = "MES";
                dt.Columns[2].ColumnName = "DIAS NO LABORADOS / FALTAS";
                dt.Columns[3].ColumnName = "COD. TRABAJADR";
                dt.Columns[4].ColumnName = "DNI";
                dt.Columns[5].ColumnName = "NOMBRES";
                dt.Columns[6].ColumnName = "UNIDAD";
                dt.Columns[7].ColumnName = "SUELDO";
                dt.Columns[8].ColumnName = "PROM. REMUNERACION BASICA";
                dt.Columns[9].ColumnName = "ASIGN. FAM.";
                dt.Columns[10].ColumnName = "PROM. H.E.";
                dt.Columns[11].ColumnName = "PROM DIURNA NOCT";
                dt.Columns[12].ColumnName = "MOVILIDAD";
                dt.Columns[13].ColumnName = "PROM FERIADO";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "GRATI SEMESTRAL";
                dt.Columns[16].ColumnName = "GRATI MENSUAL";
                dt.Columns[17].ColumnName = "GRATI X Nª DE MESES";
                dt.Columns[18].ColumnName = "DIAS NO LABORADOS";
                dt.Columns[19].ColumnName = "GRATI X Nª DE MESES ANTES DE BO";
                dt.Columns[20].ColumnName = "BONIF 9%";
                dt.Columns[21].ColumnName = "GRATI 1";
                dt.Columns[22].ColumnName = "DESCUENTOS/RTENCION ALIMENTOS";
                dt.Columns[23].ColumnName = "TOTAL GRATIF";
                dt.Columns[24].ColumnName = "GRATI 2";
                dt.Columns[25].ColumnName = "GRATI A PAGAR";
                dt.Columns[26].ColumnName = "CUENTA SUELDO";
                dt.Columns[27].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_grati_filtro_cod_empleado @cod_empleado ";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA INGRESO A PLANILLA";
                dt.Columns[1].ColumnName = "MES";
                dt.Columns[2].ColumnName = "DIAS NO LABORADOS / FALTAS";
                dt.Columns[3].ColumnName = "COD. TRABAJADR";
                dt.Columns[4].ColumnName = "DNI";
                dt.Columns[5].ColumnName = "NOMBRES";
                dt.Columns[6].ColumnName = "UNIDAD";
                dt.Columns[7].ColumnName = "SUELDO";
                dt.Columns[8].ColumnName = "PROM. REMUNERACION BASICA";
                dt.Columns[9].ColumnName = "ASIGN. FAM.";
                dt.Columns[10].ColumnName = "PROM. H.E.";
                dt.Columns[11].ColumnName = "PROM DIURNA NOCT";
                dt.Columns[12].ColumnName = "MOVILIDAD";
                dt.Columns[13].ColumnName = "PROM FERIADO";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "GRATI SEMESTRAL";
                dt.Columns[16].ColumnName = "GRATI MENSUAL";
                dt.Columns[17].ColumnName = "GRATI X Nª DE MESES";
                dt.Columns[18].ColumnName = "DIAS NO LABORADOS";
                dt.Columns[19].ColumnName = "GRATI X Nª DE MESES ANTES DE BO";
                dt.Columns[20].ColumnName = "BONIF 9%";
                dt.Columns[21].ColumnName = "GRATI 1";
                dt.Columns[22].ColumnName = "DESCUENTOS/RTENCION ALIMENTOS";
                dt.Columns[23].ColumnName = "TOTAL GRATIF";
                dt.Columns[24].ColumnName = "GRATI 2";
                dt.Columns[25].ColumnName = "GRATI A PAGAR";
                dt.Columns[26].ColumnName = "CUENTA SUELDO";
                dt.Columns[27].ColumnName = "BANCO";
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
            Excel.ExportarDatosGRATIFICACIONExcel(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
