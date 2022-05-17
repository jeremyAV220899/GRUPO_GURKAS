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
    public partial class frmCalculoDeOtrasLicencia : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();

        public frmCalculoDeOtrasLicencia()
        {
            InitializeComponent();
        }
        private void BuscaDatos()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_otras_licencias_planilla ";
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
                dt.Columns[15].ColumnName = "COMISION";
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
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO sp_buscar_vacaciones_descanso_medico_planilla" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void registrar_detalles(string cod_empleado, int dias, DateTime finicio, DateTime fin, int tipo_licencia, string tipo_documento, string area)
        {
            try
            {
                registrar.Registrarotraslicencias(cod_empleado, dias, finicio, fin, tipo_licencia, tipo_documento, area);
                MessageBox.Show("Dato Registrado", "Correpto");
                BuscaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  \n\n" + ex, "Error");
            }
        }
        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtpinicio.Value.Date;
            DateTime fin = dateTimePicker2.Value.Date;
            int dias = Convert.ToInt32(txtdias.Text);
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            int tipo_licencia = cboTipoLicencia.SelectedIndex;
            string tipo_documento = txttipodocumento.Text;
            string area = TXTAREA.Text;
            registrar_detalles(cod_empleado, dias, inicio, fin, tipo_licencia, tipo_documento, area);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            const string titulo = "Guardar Registro de Planilla de otras Licencias";
            const string mensaje = "Estas seguro que deseas Guardar el Registro de Planilla de otras Licencias";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_guardar_OTRAS_LICENCIAS ";
                comando.ExecuteNonQuery();
                MessageBox.Show("Se guardo correctamente", "Exito");
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            BuscaDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadol.SelectedValue.ToString();
            const string titulo = "Eliminar Registro de Planilla de otras Licencias";
            const string mensaje = "Estas seguro que deseas Eliminar el Registro de Planilla de otras Licencias";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_eliminar_otras_licencias @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Elimino correctamente ", "Correcto");
            }
            BuscaDatos();
        }

        private void frmCalculoDeOtrasLicencia_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadol);
            Llenadocbo.obtenerTipoLicenciaPLANILLA(cboTipoLicencia);
            //txtdias.Enabled = false;
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime inicio = dtpinicio.Value.Date;
            DateTime fin = dateTimePicker2.Value.Date;
            int dias_disfrutados = ((fin - inicio).Days) + 1;
            txtdias.Text = Convert.ToString(dias_disfrutados);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarraOtrasLicencias(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
