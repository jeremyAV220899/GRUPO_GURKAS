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
    public partial class frmCalculoDeVacaciones : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();

        public frmCalculoDeVacaciones()
        {
            InitializeComponent();
        }
        private void BuscaDatos()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_vacaciones_descanso_medico_planilla ";
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
                dt.Columns[19].ColumnName = "APP OBLIGATORIA";
                dt.Columns[20].ColumnName = "PRIMA SEGURO";
                dt.Columns[21].ColumnName = "COMISION AFP";
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
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO sp_buscar_vacaciones_descanso_medico_planilla" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void registrar_detalles(string cod_empleado, int priodo_inicio, int periodo_fin,
          int dias_acumulados, int dias_vendidos, int dias_disfrutados, DateTime finicio, DateTime ffin, decimal sueldo)
        {
            try
            {
                registrar.RegistrarAsistenciasVacacionesDescansoM(cod_empleado, priodo_inicio, periodo_fin, dias_acumulados, dias_vendidos, dias_disfrutados
                    , finicio, ffin, sueldo);
                MessageBox.Show("Dato Registrado", "Correpto");
                BuscaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  \n\n" + ex, "Error");
            }
        }
        private void frmCalculoDeVacaciones_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerPersonalPLANILLA(cboEmpleadoV);
            txtdiasdisfrutados.Text = "0";
            txtDiasVendidos.Text = "0";
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Planilla de Vacaciones";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Planilla de Vacaciones";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            const string titulo = "Guardar Registro de Planilla de Vacaciones";
            const string mensaje = "Estas seguro que deseas Guardar el Registro de Planilla de Vacaciones";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_guardar_vacaciones ";
                comando.ExecuteNonQuery();
                MessageBox.Show("Guardado Exitosamente", "Exito");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscaDatos();
        }

        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            int periodo_inicio = Convert.ToInt32(txtpinicio.Text);
            int periodo_fin = Convert.ToInt32(txtperiodofin.Text);
            int dias_acumulados = Convert.ToInt32(txtdiasacumulados.Text);
            int dias_disfrutados = Convert.ToInt32(txtdiasdisfrutados.Text);
            int dias_vendidos = Convert.ToInt32(txtDiasVendidos.Text);
            DateTime inicio = dtpinicio.Value.Date;
            DateTime fin = dateTimePicker2.Value.Date;

            decimal sueldo = Convert.ToDecimal(textBox1.Text);

            registrar_detalles(cod_empleado, periodo_inicio, periodo_fin, dias_acumulados, dias_vendidos, dias_disfrutados, inicio, fin, sueldo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboEmpleadoV.SelectedValue.ToString();
            const string titulo = "Eliminar   Vacaciones";
            const string mensaje = "Estas seguro que deseas Eliminar la Vacaciones";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_eliminar_vacaciones @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Elimino correctamente ", "Correcto");
            }
            BuscaDatos();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime inicio = dtpinicio.Value.Date;
            DateTime fin = dateTimePicker2.Value.Date;
            int dias_disfrutados = ((fin - inicio).Days) + 1;
            txtdiasdisfrutados.Text = Convert.ToString(dias_disfrutados);
        }

        private void cboempleadoActivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            SqlCommand cmd = new SqlCommand(" select SUELDO_BRUTO from t_mae_datos_laborales where cod_empleado = @cod_empleado", conexion.conexionBD());
            cmd.Parameters.AddWithValue("cod_empleado", cod_empleado);
            SqlDataReader recorre = cmd.ExecuteReader();
            while (recorre.Read())
            {
                textBox1.Text = recorre["SUELDO_BRUTO"].ToString();

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarraVacaciones(dgvPlataformaPlanilla, progressBar1);
        }
    }
}
