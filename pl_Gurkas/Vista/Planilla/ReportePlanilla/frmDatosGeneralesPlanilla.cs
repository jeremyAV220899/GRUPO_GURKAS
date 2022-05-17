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

namespace pl_Gurkas.Vista.Planilla.ReportePlanilla
{
    public partial class frmDatosGeneralesPlanilla : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla ExcelPlanilla = new ExportacionExcelPlanilla.ExcelPlanilla();
        public frmDatosGeneralesPlanilla()
        {
            InitializeComponent();
        }

        private void frmDatosGeneralesPlanilla_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerEmpresaPLANILLA(cboEmpresa);
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerUnidadPlanillas(cboUnidad);
            dgvDatosLaboralesGneral.RowHeadersVisible = false;
            dgvDatosLaboralesGneral.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_empleado_datos_laborales  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Regimen Pensionario";
                dt.Columns[3].ColumnName = "AFP";
                dt.Columns[4].ColumnName = "AFP CUSS";
                dt.Columns[5].ColumnName = "Movimiento AFP";
                dt.Columns[6].ColumnName = "Tipo de Comision AFP";
                dt.Columns[7].ColumnName = "Ocupacion";
                dt.Columns[8].ColumnName = "Banco Sueldo";
                dt.Columns[9].ColumnName = "Cta Sueldo";
                dt.Columns[10].ColumnName = "Tipo de Moneda de Cta Sueldo";
                dt.Columns[11].ColumnName = "Banco CTS";
                dt.Columns[12].ColumnName = "Cta CTS";
                dt.Columns[13].ColumnName = "Tipo de Moneda de Cta CTS";
                dt.Columns[14].ColumnName = "Sueldo Basico";
                dt.Columns[15].ColumnName = "Tipo Remuneracion";
                dt.Columns[16].ColumnName = "Periodo Remuneracion";
                dt.Columns[17].ColumnName = "Sueldo Bruto";
                dt.Columns[18].ColumnName = "Bono familiar";
                dt.Columns[19].ColumnName = "Fecha Inicio de Contrato";
                dt.Columns[20].ColumnName = "Bono de Productividad 1";
                dt.Columns[21].ColumnName = "Bono de Produccion 1";
                dt.Columns[22].ColumnName = "Penalidad";
                dt.Columns[23].ColumnName = "RENTA de 5TA";
                dt.Columns[24].ColumnName = "SUCAMEC  Descuentos";
                dt.Columns[25].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[26].ColumnName = "Descuentos de BOTAS/ZAPATOS";
                dt.Columns[27].ColumnName = "Descuentos de MULTA ELECTRAL";
                dt.Columns[28].ColumnName = "EXCESO DE PAGO";
                dt.Columns[29].ColumnName = "Otros Descuentos";
                dt.Columns[30].ColumnName = "Bono Armado";
                dt.Columns[31].ColumnName = "Reingreso No Afectos";
                dt.Columns[32].ColumnName = "Reingreso Afectos";
                dt.Columns[33].ColumnName = "Unidad";
                dt.Columns[34].ColumnName = "Empresa";
                dt.Columns[35].ColumnName = "Estado";

                dt.AcceptChanges();
                dgvDatosLaboralesGneral.DataSource = dt;
            }
            catch (Exception err)
            {
                try
                {
                    MessageBox.Show("Debe ingresar un codigo De Empleado" + err);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO SP_BUCARPERSONAL \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Busqueda por empresa*/
            int cod_Empresa = cboEmpresa.SelectedIndex;
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_empresa_datos_laborales  @cod_Empresa";
                comando.Parameters.AddWithValue("cod_Empresa", cod_Empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Regimen Pensionario";
                dt.Columns[3].ColumnName = "AFP";
                dt.Columns[4].ColumnName = "AFP CUSS";
                dt.Columns[5].ColumnName = "Movimiento AFP";
                dt.Columns[6].ColumnName = "Tipo de Comision AFP";
                dt.Columns[7].ColumnName = "Ocupacion";
                dt.Columns[8].ColumnName = "Banco Sueldo";
                dt.Columns[9].ColumnName = "Cta Sueldo";
                dt.Columns[10].ColumnName = "Tipo de Moneda de Cta Sueldo";
                dt.Columns[11].ColumnName = "Banco CTS";
                dt.Columns[12].ColumnName = "Cta CTS";
                dt.Columns[13].ColumnName = "Tipo de Moneda de Cta CTS";
                dt.Columns[14].ColumnName = "Sueldo Basico";
                dt.Columns[15].ColumnName = "Tipo Remuneracion";
                dt.Columns[16].ColumnName = "Periodo Remuneracion";
                dt.Columns[17].ColumnName = "Sueldo Bruto";
                dt.Columns[18].ColumnName = "Bono familiar";
                dt.Columns[19].ColumnName = "Fecha Inicio de Contrato";
                dt.Columns[20].ColumnName = "Bono de Productividad 1";
                dt.Columns[21].ColumnName = "Bono de Produccion 1";
                dt.Columns[22].ColumnName = "Penalidad";
                dt.Columns[23].ColumnName = "RENTA de 5TA";
                dt.Columns[24].ColumnName = "SUCAMEC  Descuentos";
                dt.Columns[25].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[26].ColumnName = "Descuentos de BOTAS/ZAPATOS";
                dt.Columns[27].ColumnName = "Descuentos de MULTA ELECTRAL";
                dt.Columns[28].ColumnName = "EXCESO DE PAGO";
                dt.Columns[29].ColumnName = "Otros Descuentos";
                dt.Columns[30].ColumnName = "Bono Armado";
                dt.Columns[31].ColumnName = "Reingreso No Afectos";
                dt.Columns[32].ColumnName = "Reingreso Afectos";
                dt.Columns[33].ColumnName = "Unidad";
                dt.Columns[34].ColumnName = "Empresa";
                dt.Columns[35].ColumnName = "Estado";

                dt.AcceptChanges();
                dgvDatosLaboralesGneral.DataSource = dt;
            }
            catch (Exception err)
            {
                try
                {
                    MessageBox.Show("Debe Seleccionar una Empresa" + err);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR  \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Busqueda por unidad*/
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_unidad_datos_laborales  @cod_unidad";
                comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Regimen Pensionario";
                dt.Columns[3].ColumnName = "AFP";
                dt.Columns[4].ColumnName = "AFP CUSS";
                dt.Columns[5].ColumnName = "Movimiento AFP";
                dt.Columns[6].ColumnName = "Tipo de Comision AFP";
                dt.Columns[7].ColumnName = "Ocupacion";
                dt.Columns[8].ColumnName = "Banco Sueldo";
                dt.Columns[9].ColumnName = "Cta Sueldo";
                dt.Columns[10].ColumnName = "Tipo de Moneda de Cta Sueldo";
                dt.Columns[11].ColumnName = "Banco CTS";
                dt.Columns[12].ColumnName = "Cta CTS";
                dt.Columns[13].ColumnName = "Tipo de Moneda de Cta CTS";
                dt.Columns[14].ColumnName = "Sueldo Basico";
                dt.Columns[15].ColumnName = "Tipo Remuneracion";
                dt.Columns[16].ColumnName = "Periodo Remuneracion";
                dt.Columns[17].ColumnName = "Sueldo Bruto";
                dt.Columns[18].ColumnName = "Bono familiar";
                dt.Columns[19].ColumnName = "Fecha Inicio de Contrato";
                dt.Columns[20].ColumnName = "Bono de Productividad 1";
                dt.Columns[21].ColumnName = "Bono de Produccion 1";
                dt.Columns[22].ColumnName = "Penalidad";
                dt.Columns[23].ColumnName = "RENTA de 5TA";
                dt.Columns[24].ColumnName = "SUCAMEC  Descuentos";
                dt.Columns[25].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[26].ColumnName = "Descuentos de BOTAS/ZAPATOS";
                dt.Columns[27].ColumnName = "Descuentos de MULTA ELECTRAL";
                dt.Columns[28].ColumnName = "EXCESO DE PAGO";
                dt.Columns[29].ColumnName = "Otros Descuentos";
                dt.Columns[30].ColumnName = "Bono Armado";
                dt.Columns[31].ColumnName = "Reingreso No Afectos";
                dt.Columns[32].ColumnName = "Reingreso Afectos";
                dt.Columns[33].ColumnName = "Unidad";
                dt.Columns[34].ColumnName = "Empresa";
                dt.Columns[35].ColumnName = "Estado";

                dt.AcceptChanges();
                dgvDatosLaboralesGneral.DataSource = dt;
            }
            catch (Exception err)
            {
                try
                {
                    MessageBox.Show("Debe Seleccionar una Unidad" + err);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR  \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelPlanilla.ExportarDatosBarra(dgvDatosLaboralesGneral, progressBar1);
        }
    }
}
