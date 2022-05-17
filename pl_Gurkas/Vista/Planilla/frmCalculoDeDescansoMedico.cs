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

namespace pl_Gurkas.Vista.Planilla
{
    public partial class frmCalculoDeDescansoMedico : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        public frmCalculoDeDescansoMedico()
        {
            InitializeComponent();
        }
        private void registrar_datos_vacaciones(string cod_empleado, DateTime f_inicio, DateTime f_fin, int n_dias, string area, string n_ciit
         , string diagnostico, string centro_medico, string contigencia, decimal renta, decimal sucamec, decimal alimentos, decimal botas,
          decimal multa, decimal excesopago, decimal covid, decimal papeles, decimal prestamos, decimal equipo)
        {
            try
            {
                registrar.Registrardescansomedico(cod_empleado, f_inicio, f_fin, n_dias, area, n_ciit, diagnostico, centro_medico, contigencia
                    , renta, sucamec, alimentos, botas, multa, excesopago, covid, papeles, prestamos, equipo);
                MessageBox.Show("Dato Registrado", "Correpto");
                BuscaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  \n\n" + ex, "Error");
            }
        }

        private void BuscaDatos()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_calculo_descanso_medico ";
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
                dt.Columns[17].ColumnName = "APP OBLIGATORIA";
                dt.Columns[18].ColumnName = "PRIMA SEGURO";
                dt.Columns[19].ColumnName = "COMISON AFP";
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
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO sp_buscar_vacaciones_descanso_medico_planilla" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmCalculoDeDescansoMedico_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleado);
            //txtnumerodias.Enabled = false;
            txtrenta.Text = "0.00";
            txtsucamec.Text = "0.00";
            txtalimentos.Text = "0.00";
            txtbotas.Text = "0.00";
            txtmulta.Text = "0.00";
            txtexcesopago.Text = "0.00";
            txtcovid.Text = "0.00";
            txtpapeles.Text = "0.00";
            txtprestamos.Text = "0.00";
            txtequipo.Text = "0.00";

            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime inicio = dtpinicio.Value.Date;
            DateTime fin = dateTimePicker2.Value.Date;
            int dias_disfrutados = ((fin - inicio).Days) + 1;
            txtnumerodias.Text = Convert.ToString(dias_disfrutados);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleado.SelectedValue.ToString();

            const string titulo = "Eliminar Descanso Medico";
            const string mensaje = "Estas seguro que desea eliminar el descanso medico";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_eliminar_descanso_medico @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Elimino correctamente ", "Correcto");
            }
            BuscaDatos();
        }

        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            DateTime f_inicio = dtpinicio.Value;
            DateTime f_fin = dateTimePicker2.Value;
            int n_dias = Convert.ToInt32(txtnumerodias.Text);
            string area = ttxtarea.Text;
            string n_ciit = txtciit.Text;
            string diagnostico = txtdiagnostico.Text;
            string centro_medico = txtcentroasistencia.Text;
            string contigencia = txtcontingencia.Text;

            decimal renta = Convert.ToDecimal(txtrenta.Text);
            decimal sucamec = Convert.ToDecimal(txtsucamec.Text);
            decimal alimentos = Convert.ToDecimal(txtalimentos.Text);
            decimal botas = Convert.ToDecimal(txtbotas.Text);
            decimal multa = Convert.ToDecimal(txtmulta.Text);
            decimal excesopago = Convert.ToDecimal(txtexcesopago.Text);
            decimal covid = Convert.ToDecimal(txtcovid.Text);
            decimal papeles = Convert.ToDecimal(txtpapeles.Text);
            decimal prestamos = Convert.ToDecimal(txtprestamos.Text);
            decimal equipo = Convert.ToDecimal(txtequipo.Text);

            registrar_datos_vacaciones(cod_empleado, f_inicio, f_fin, n_dias, area, n_ciit
            , diagnostico, centro_medico, contigencia, renta, sucamec, alimentos, botas, multa, excesopago, covid, papeles, prestamos, equipo);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            const string titulo = "Guardar Datos";
            const string mensaje = "Estas seguro que desea Guardar el descanso medico";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_guardar_descanso_medico ";
                comando.ExecuteNonQuery();
                MessageBox.Show("Se guardo correctamente en la base de datos ", "Correcto");
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

        private void button2_Click(object sender, EventArgs e)
        {
            BuscaDatos();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarraDescansoMedico(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
