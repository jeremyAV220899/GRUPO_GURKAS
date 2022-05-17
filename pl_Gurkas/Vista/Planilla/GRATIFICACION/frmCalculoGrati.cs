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

namespace pl_Gurkas.Vista.Planilla.GRATIFICACION
{
    public partial class frmCalculoGrati : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        public frmCalculoGrati()
        {
            InitializeComponent();
        }
        private void consultaPlanilla()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calulo_grati  ";
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
        public void generar_planilla_grati()
        {

            try
            {
                registrar.generar_planilla_grati();
                consultaPlanilla();
                MessageBox.Show("Planilla CTS generado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR LA PLANILLA CTS \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmCalculoGrati_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadPlanillas(cbounidadplanilla);
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Calculo de GRATIFICACION";
            const string mensaje = "Estas seguro que deseas cerra el Calculo de GRATIFICACION";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            generar_planilla_grati();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cod_unidad = cbounidadplanilla.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calulo_grati_filtro_unidad @cod_unidad ";
                comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
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
        private void verificar()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calulo_grati_filtro_verificar  ";
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
                comando.CommandText = "sp_calulo_grati_filtro_cod_empleado @cod_empleado ";
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

        private void btnverificar_Click(object sender, EventArgs e)
        {
            verificar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            verificar();
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_guardar_grati";
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos registrado correptamente");
            Vista.Planilla.GRATIFICACION.frmaniomesgrati frmMesAniograti = new Vista.Planilla.GRATIFICACION.frmaniomesgrati();
            frmMesAniograti.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosGRATIFICACIONExcel(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
