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

namespace pl_Gurkas.Vista.Planilla.CTS
{
    public partial class frmCalculoCTS : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        public frmCalculoCTS()
        {
            InitializeComponent();
        }
        private void consultaPlanilla()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calculo_cts  ";
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
        public void generar_planilla_cts()
        {

            try
            {
                registrar.generar_planilla_cts();
                consultaPlanilla();
                MessageBox.Show("Planilla CTS generado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR LA PLANILLA CTS \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            generar_planilla_cts();
        }

        private void frmCalculoCTS_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadPlanillas(cbounidadplanilla);
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cod_unidad = cbounidadplanilla.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calculo_cts_filtro_unidad @cod_unidad ";
                comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
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

        private void verificar()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calculo_cts_filtro_verificar  ";
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

        private void btnverificar_Click(object sender, EventArgs e)
        {
            verificar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calculo_cts_filtro_cod_empleado @cod_empleado ";
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Calculo de CTS";
            const string mensaje = "Estas seguro que deseas cerra el Calculo de CTS";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            verificar();
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_guardar_cts";
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos registrado correptamente");
            Vista.Planilla.CTS.frmGuardarCTS frmMesAnioCTS = new Vista.Planilla.CTS.frmGuardarCTS();
            frmMesAnioCTS.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosCTSExcel(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
