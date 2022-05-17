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
    public partial class frmHistorialDescansoMedico : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        public frmHistorialDescansoMedico()
        {
            InitializeComponent();
        }
        private void buscar_cod_emepladpo(string cod_empleado)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_descanso_medico_cod_empleado  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA";
                dt.Columns[1].ColumnName = "cod_empleado";
                dt.Columns[2].ColumnName = "Empleado";
                dt.Columns[3].ColumnName = "AREA";
                dt.Columns[4].ColumnName = "PUESTO";
                dt.Columns[5].ColumnName = "UNIDAD";
                dt.Columns[6].ColumnName = "DIAGNOSTICO";
                dt.Columns[7].ColumnName = "N° CIIT";
                dt.Columns[8].ColumnName = "CENTRO ASISTENCIAL";
                dt.Columns[9].ColumnName = "CONTINGENCIA";
                dt.Columns[10].ColumnName = "INICIO";
                dt.Columns[11].ColumnName = "FIN";
                dt.Columns[12].ColumnName = "Nº DIAS";
                dt.Columns[13].ColumnName = "SUELDO Basico";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "REGIMEN PENSIONARIO";
                dt.Columns[16].ColumnName = "% AFP";
                dt.Columns[17].ColumnName = "APP OBLIGATORIO";
                dt.Columns[18].ColumnName = "COMISION";
                dt.Columns[19].ColumnName = "PRIMA SEGURO";
                dt.Columns[20].ColumnName = "CANT. AFP";
                dt.Columns[21].ColumnName = "RENTA 5TA";
                dt.Columns[22].ColumnName = "SUCAMEC";
                dt.Columns[23].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[24].ColumnName = "BOTAS/ZAPATOS";
                dt.Columns[25].ColumnName = "MULTA ELECTORAL";
                dt.Columns[26].ColumnName = "EXCESO DE PAGO";
                dt.Columns[27].ColumnName = "COVID";
                dt.Columns[28].ColumnName = "PAPELES";
                dt.Columns[29].ColumnName = "PRESTAMOS";
                dt.Columns[30].ColumnName = "EQUIPOS";
                dt.Columns[31].ColumnName = "NETO A PAGAR";
                dt.Columns[32].ColumnName = "TIPO DOCUMENTO";
                dt.Columns[33].ColumnName = "NUMERO DE DOCUMENTO";
                dt.Columns[34].ColumnName = "NUMERO DE CUENTA";
                dt.Columns[35].ColumnName = "BANCO";
                dt.Columns[36].ColumnName = "FECHA INICIO";
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
                comando.CommandText = "sp_historial_planilla_descanso_medico  @cod_empleado,@mes,@anio";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA";
                dt.Columns[1].ColumnName = "cod_empleado";
                dt.Columns[2].ColumnName = "Empleado";
                dt.Columns[3].ColumnName = "AREA";
                dt.Columns[4].ColumnName = "PUESTO";
                dt.Columns[5].ColumnName = "UNIDAD";
                dt.Columns[6].ColumnName = "DIAGNOSTICO";
                dt.Columns[7].ColumnName = "N° CIIT";
                dt.Columns[8].ColumnName = "CENTRO ASISTENCIAL";
                dt.Columns[9].ColumnName = "CONTINGENCIA";
                dt.Columns[10].ColumnName = "INICIO";
                dt.Columns[11].ColumnName = "FIN";
                dt.Columns[12].ColumnName = "Nº DIAS";
                dt.Columns[13].ColumnName = "SUELDO Basico";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "REGIMEN PENSIONARIO";
                dt.Columns[16].ColumnName = "% AFP";
                dt.Columns[17].ColumnName = "APP OBLIGATORIO";
                dt.Columns[18].ColumnName = "COMISION";
                dt.Columns[19].ColumnName = "PRIMA SEGURO";
                dt.Columns[20].ColumnName = "CANT. AFP";
                dt.Columns[21].ColumnName = "RENTA 5TA";
                dt.Columns[22].ColumnName = "SUCAMEC";
                dt.Columns[23].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[24].ColumnName = "BOTAS/ZAPATOS";
                dt.Columns[25].ColumnName = "MULTA ELECTORAL";
                dt.Columns[26].ColumnName = "EXCESO DE PAGO";
                dt.Columns[27].ColumnName = "COVID";
                dt.Columns[28].ColumnName = "PAPELES";
                dt.Columns[29].ColumnName = "PRESTAMOS";
                dt.Columns[30].ColumnName = "EQUIPOS";
                dt.Columns[31].ColumnName = "NETO A PAGAR";
                dt.Columns[32].ColumnName = "TIPO DOCUMENTO";
                dt.Columns[33].ColumnName = "NUMERO DE DOCUMENTO";
                dt.Columns[34].ColumnName = "NUMERO DE CUENTA";
                dt.Columns[35].ColumnName = "BANCO";
                dt.Columns[36].ColumnName = "FECHA INICIO";
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
                comando.CommandText = "sp_historial_planilla_descanso_medico_anio_mes_2  @mes,@anio,@empresa ";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "FECHA";
                dt.Columns[1].ColumnName = "cod_empleado";
                dt.Columns[2].ColumnName = "Empleado";
                dt.Columns[3].ColumnName = "AREA";
                dt.Columns[4].ColumnName = "PUESTO";
                dt.Columns[5].ColumnName = "UNIDAD";
                dt.Columns[6].ColumnName = "DIAGNOSTICO";
                dt.Columns[7].ColumnName = "N° CIIT";
                dt.Columns[8].ColumnName = "CENTRO ASISTENCIAL";
                dt.Columns[9].ColumnName = "CONTINGENCIA";
                dt.Columns[10].ColumnName = "INICIO";
                dt.Columns[11].ColumnName = "FIN";
                dt.Columns[12].ColumnName = "Nº DIAS";
                dt.Columns[13].ColumnName = "SUELDO Basico";
                dt.Columns[14].ColumnName = "TOTAL";
                dt.Columns[15].ColumnName = "REGIMEN PENSIONARIO";
                dt.Columns[16].ColumnName = "% AFP";
                dt.Columns[17].ColumnName = "APP OBLIGATORIO";
                dt.Columns[18].ColumnName = "COMISION";
                dt.Columns[19].ColumnName = "PRIMA SEGURO";
                dt.Columns[20].ColumnName = "CANT. AFP";
                dt.Columns[21].ColumnName = "RENTA 5TA";
                dt.Columns[22].ColumnName = "SUCAMEC";
                dt.Columns[23].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[24].ColumnName = "BOTAS/ZAPATOS";
                dt.Columns[25].ColumnName = "MULTA ELECTORAL";
                dt.Columns[26].ColumnName = "EXCESO DE PAGO";
                dt.Columns[27].ColumnName = "COVID";
                dt.Columns[28].ColumnName = "PAPELES";
                dt.Columns[29].ColumnName = "PRESTAMOS";
                dt.Columns[30].ColumnName = "EQUIPOS";
                dt.Columns[31].ColumnName = "NETO A PAGAR";
                dt.Columns[32].ColumnName = "TIPO DOCUMENTO";
                dt.Columns[33].ColumnName = "NUMERO DE DOCUMENTO";
                dt.Columns[34].ColumnName = "NUMERO DE CUENTA";
                dt.Columns[35].ColumnName = "BANCO";
                dt.Columns[36].ColumnName = "FECHA INICIO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmHistorialDescansoMedico_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerPersonalPLANILLA(cboEmpleadoMesAnio);
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
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
            Excel.ExportarDatosBarraDescansoMedico(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
