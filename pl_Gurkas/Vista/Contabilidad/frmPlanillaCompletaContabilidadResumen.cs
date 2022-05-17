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

namespace pl_Gurkas.Vista.Contabilidad
{
    public partial class frmPlanillaCompletaContabilidadResumen : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        public frmPlanillaCompletaContabilidadResumen()
        {
            InitializeComponent();
        }
        private void CargarHistorialPlanilla()
        {
            cboPlanilla.Items.Insert(0, "Seleccione una Planilla");
            cboPlanilla.Items.Insert(1, "Primera Quincena Resumen");
            cboPlanilla.Items.Insert(2, "Segunda Quincena Resumen");
            cboPlanilla.Items.Insert(3, "Planilla Completa Resumen");
            cboPlanilla.SelectedIndex = 0;
        }
        private void planilla_completa_contavilidad(int mes, int anio, int ID_EMPRESA)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_CONTABILIDAD_VISTA  @mes,@anio, @ID_EMPRESA";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("ID_EMPRESA", ID_EMPRESA);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "UNIDAD";
                dt.Columns[1].ColumnName = "TOTAL INGRESO";
                dt.Columns[2].ColumnName = "TOTAL DE ESSALUD";
                dt.Columns[3].ColumnName = "TOTAL DE DESCUENTOS POR PENALIDAD";
                dt.Columns[4].ColumnName = "TOTAL DE DESCUENTOS POR RENTA 5";
                dt.Columns[5].ColumnName = "TOTAL DE DESCUENTOS POR SUCAMEC";
                dt.Columns[6].ColumnName = "TOTAL DE DESCUENTOS POR RETENCION DE ALIMENTOS";
                dt.Columns[7].ColumnName = "TOTAL DE DESCUENTOS POR BOTAS O ZAPATOS";
                dt.Columns[8].ColumnName = "TOTAL DE DESCUENTOS POR MULTA ELECTRAL";
                dt.Columns[9].ColumnName = "TOTAL DE DESCUENTOS POR EXCESO DE PAGO";
                dt.Columns[10].ColumnName ="TOTAL DE DESCUENTOS POR PRUEBA COVID";
                dt.Columns[11].ColumnName ="TOTAL DE DESCUENTOS POR PRESTAMOS";
                dt.Columns[12].ColumnName ="TOTAL DE DESCUENTOS POR PERDIDA DE EQUIPO";
                dt.Columns[13].ColumnName ="TOTAL DE DESCUENTOS POR PAPELES";
                dt.Columns[14].ColumnName ="TOTAL POR BONO ARMADO";
                dt.Columns[15].ColumnName ="TOTAL POR BONO MOVILIDAD";
                dt.Columns[16].ColumnName ="TOTAL POR DIAS INAFECTOS PAGO";
                dt.Columns[17].ColumnName = "TOTAL POR NETO A PAGAR";
                dt.Columns[18].ColumnName = "TOTAL POR ONP";
                dt.Columns[19].ColumnName = "TOTAL POR INTEGRA";
                dt.Columns[20].ColumnName = "TOTAL POR PROFUTURO";
                dt.Columns[21].ColumnName = "TOTAL POR PRIMA";
                dt.Columns[22].ColumnName = "TOTAL POR HABITA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_quincena_contavilidad(int mes, int anio, int ID_EMPRESA)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_CONTABILIDAD_VISTA_15  @mes,@anio, @ID_EMPRESA";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("ID_EMPRESA", ID_EMPRESA);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "UNIDAD";
                dt.Columns[1].ColumnName = "TOTAL INGRESO";
                dt.Columns[2].ColumnName = "TOTAL DE ESSALUD";
                dt.Columns[3].ColumnName = "TOTAL DE DESCUENTOS POR PENALIDAD";
                dt.Columns[4].ColumnName = "TOTAL DE DESCUENTOS POR RENTA 5";
                dt.Columns[5].ColumnName = "TOTAL DE DESCUENTOS POR SUCAMEC";
                dt.Columns[6].ColumnName = "TOTAL DE DESCUENTOS POR RETENCION DE ALIMENTOS";
                dt.Columns[7].ColumnName = "TOTAL DE DESCUENTOS POR BOTAS O ZAPATOS";
                dt.Columns[8].ColumnName = "TOTAL DE DESCUENTOS POR MULTA ELECTRAL";
                dt.Columns[9].ColumnName = "TOTAL DE DESCUENTOS POR EXCESO DE PAGO";
                dt.Columns[10].ColumnName = "TOTAL DE DESCUENTOS POR PRUEBA COVID";
                dt.Columns[11].ColumnName = "TOTAL DE DESCUENTOS POR PRESTAMOS";
                dt.Columns[12].ColumnName = "TOTAL DE DESCUENTOS POR PERDIDA DE EQUIPO";
                dt.Columns[13].ColumnName = "TOTAL DE DESCUENTOS POR PAPELES";
                dt.Columns[14].ColumnName = "TOTAL POR BONO ARMADO";
                dt.Columns[15].ColumnName = "TOTAL POR BONO MOVILIDAD";
                dt.Columns[16].ColumnName = "TOTAL POR DIAS INAFECTOS PAGO";
                dt.Columns[17].ColumnName = "TOTAL POR NETO A PAGAR";
                dt.Columns[18].ColumnName = "TOTAL POR ONP";
                dt.Columns[19].ColumnName = "TOTAL POR INTEGRA";
                dt.Columns[20].ColumnName = "TOTAL POR PROFUTURO";
                dt.Columns[21].ColumnName = "TOTAL POR PRIMA";
                dt.Columns[22].ColumnName = "TOTAL POR HABITA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_fin_mes_contavilidad(int mes, int anio, int ID_EMPRESA)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_CONTABILIDAD_VISTA_30  @mes,@anio, @ID_EMPRESA";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("ID_EMPRESA", ID_EMPRESA);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "UNIDAD";
                dt.Columns[1].ColumnName = "TOTAL INGRESO";
                dt.Columns[2].ColumnName = "TOTAL DE ESSALUD";
                dt.Columns[3].ColumnName = "TOTAL DE DESCUENTOS POR PENALIDAD";
                dt.Columns[4].ColumnName = "TOTAL DE DESCUENTOS POR RENTA 5";
                dt.Columns[5].ColumnName = "TOTAL DE DESCUENTOS POR SUCAMEC";
                dt.Columns[6].ColumnName = "TOTAL DE DESCUENTOS POR RETENCION DE ALIMENTOS";
                dt.Columns[7].ColumnName = "TOTAL DE DESCUENTOS POR BOTAS O ZAPATOS";
                dt.Columns[8].ColumnName = "TOTAL DE DESCUENTOS POR MULTA ELECTRAL";
                dt.Columns[9].ColumnName = "TOTAL DE DESCUENTOS POR EXCESO DE PAGO";
                dt.Columns[10].ColumnName = "TOTAL DE DESCUENTOS POR PRUEBA COVID";
                dt.Columns[11].ColumnName = "TOTAL DE DESCUENTOS POR PRESTAMOS";
                dt.Columns[12].ColumnName = "TOTAL DE DESCUENTOS POR PERDIDA DE EQUIPO";
                dt.Columns[13].ColumnName = "TOTAL DE DESCUENTOS POR PAPELES";
                dt.Columns[14].ColumnName = "TOTAL POR BONO ARMADO";
                dt.Columns[15].ColumnName = "TOTAL POR BONO MOVILIDAD";
                dt.Columns[16].ColumnName = "TOTAL POR DIAS INAFECTOS PAGO";
                dt.Columns[17].ColumnName = "TOTAL POR NETO A PAGAR";
                dt.Columns[18].ColumnName = "TOTAL POR ONP";
                dt.Columns[19].ColumnName = "TOTAL POR INTEGRA";
                dt.Columns[20].ColumnName = "TOTAL POR PROFUTURO";
                dt.Columns[21].ColumnName = "TOTAL POR PRIMA";
                dt.Columns[22].ColumnName = "TOTAL POR HABITA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmPlanillaCompletaContabilidadResumen_Load(object sender, EventArgs e)
        {
            CargarHistorialPlanilla();
            Llenadocbo.ObtenerEmpresaPLANILLA(cboEmpresa);
            dgvHistorialPlanilla.RowHeadersVisible = false;
            dgvHistorialPlanilla.AllowUserToAddRows = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int planilla = cboPlanilla.SelectedIndex;
            int ID_EMPRESA = cboEmpresa.SelectedIndex;
            int mes = Convert.ToInt32(txtmes.Text);
            int anio = Convert.ToInt32(txtanio.Text);
            if (planilla == 1)
            {
                planilla_quincena_contavilidad(mes, anio, ID_EMPRESA);
            }
            if (planilla == 2)
            {
                planilla_fin_mes_contavilidad(mes, anio, ID_EMPRESA);
            }
            if (planilla == 3)
            {
                planilla_completa_contavilidad(mes, anio, ID_EMPRESA);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarraPlanillaContabilidad(dgvHistorialPlanilla, progressBar1);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Contabilidad";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Contabilidad";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                string detalle = "Salio del modulo de asistencia";
                string accion = "Cerro el Registro de asistencia del  Personal";

                this.Close();
            }
        }
    }
}
