using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Planilla.GuardarPlanilla
{
    public partial class frmDatosPlanillaExcel : Form
    {
        public DateTime _fecha;
        public DateTime _fecchagenerada;
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmDatosPlanillaExcel()
        {
            InitializeComponent();
            MessageBox.Show("Solo se puede subir la planilla Completa por excel", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void CargarNumeroDeHijo()
        {
            cbotipoorder.Items.Insert(0, "Selecciones una carga");
            cbotipoorder.Items.Insert(1, "Primera Quincena");
            cbotipoorder.Items.Insert(2, "Segunda Quincena");

            cbotipoorder.SelectedIndex = 0;
        }
        DataView importarDatos(string nombrearchivo)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0'", nombrearchivo);
            OleDbConnection conector = new OleDbConnection(conexion);
            conector.Open();
            OleDbCommand consulta = new OleDbCommand("select * from [Hoja1$]", conector);
            OleDbDataAdapter adaptador = new OleDbDataAdapter
            {
                SelectCommand = consulta
            };
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            conector.Close();
            return ds.Tables[0].DefaultView;
        }

        private void frmDatosPlanillaExcel_Load(object sender, EventArgs e)
        {
            CargarNumeroDeHijo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls;*.xlsx;",
                Title = "Seleccionar Archivo"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = importarDatos(openFileDialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cod_order = cbotipoorder.SelectedIndex;
            const string titulo = "Guardar Datos en el Sistema";
            const string mensaje = "Porfavor verificar antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICACION DE DATOS";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                if (cod_order == 1)
                {
                    try
                    {
                    SqlCommand comando = new SqlCommand("sp_insertar_datos_planillas_15 ", conexion.conexionBD());
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Cod Empleado"].Value != null && row.Cells["Empleado"].Value != null && row.Cells["Fecha Inicio"].Value != null
                             && row.Cells["Unidad"].Value != null && row.Cells["Turno"].Value != null && row.Cells["Permiso"].Value != null
                             && row.Cells["Licencia"].Value != null && row.Cells["Descanso Medico"].Value != null
                             && row.Cells["Suspension"].Value != null && row.Cells["Vacaciones"].Value != null
                             && row.Cells["Faltas"].Value != null && row.Cells["CANT TARDANZAS"].Value != null && row.Cells["Dias Inafectos"].Value != null
                             && row.Cells["Dias Laborados"].Value != null && row.Cells["Feriados"].Value != null && row.Cells["Descanso"].Value != null
                             && row.Cells["Total de Dias Laborados"].Value != null && row.Cells["Sueldo Mensual"].Value != null && row.Cells["REMUN BASICO"].Value != null
                             && row.Cells["Pago Feriado"].Value != null && row.Cells["H_E 25%"].Value != null && row.Cells["H_E 35%"].Value != null
                             && row.Cells["bonif"].Value != null && row.Cells["Asignacion Familiar"].Value != null && row.Cells["REINGRESO AFECTO"].Value != null
                             && row.Cells["DSCTO TARDANZAS"].Value != null && row.Cells["TOTAL INGRESO"].Value != null && row.Cells["Essalud"].Value != null
                             && row.Cells["SISTEMA PENSIONARIO"].Value != null && row.Cells["AFP / ONP %"].Value != null && row.Cells["APP OBLIGATORIO"].Value != null
                             && row.Cells["Comisión"].Value != null && row.Cells["Prima Seguro"].Value != null && row.Cells["CANT_AFP / ONP"].Value != null
                             && row.Cells["PENALIDAD"].Value != null && row.Cells["RENTA 5TA"].Value != null
                             && row.Cells["Descuento SUCAMEC"].Value != null && row.Cells["RETENCION DE ALIMENTOS"].Value != null && row.Cells["DESCUENTOS DE BOTAS/ZAPATOS"].Value != null
                             && row.Cells["DESCUENTO DE MULTA ELECTRAL"].Value != null && row.Cells["EXCESO DE PAGO"].Value != null && row.Cells["DESCUENTO DE PRUEBA COVID"].Value != null
                             && row.Cells["DESCUENTO DE PAPELES"].Value != null && row.Cells["PRESTAMOS"].Value != null && row.Cells["DESCUENTO DE PERDIDA DE EQUIPO"].Value != null
                             && row.Cells["Total Descuentos"].Value != null && row.Cells["Total A Cobrar"].Value != null && row.Cells["REINGRESOS NO AFECTOS"].Value != null
                             && row.Cells["BONO / MOVILIDAD"].Value != null && row.Cells["BONO ARMADO"].Value != null && row.Cells["DIAS INAFECTOS PAGO"].Value != null
                             && row.Cells["NETO A PAGAR"].Value != null && row.Cells["DNI EMPELADO"].Value != null && row.Cells["CUENTA"].Value != null
                             && row.Cells["BANCO"].Value != null)
                        {
                            comando.Parameters.Clear();
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.AddWithValue("@Cod_Empleado_15", SqlDbType.VarChar).Value = row.Cells["Cod Empleado"].Value;
                            comando.Parameters.AddWithValue("@Empleado_15", SqlDbType.VarChar).Value = row.Cells["Empleado"].Value;
                            comando.Parameters.AddWithValue("@Fecha_Inicio_15", SqlDbType.VarChar).Value = row.Cells["Fecha Inicio"].Value;
                            comando.Parameters.AddWithValue("@Unidad_15", SqlDbType.VarChar).Value = row.Cells["Unidad"].Value;
                            comando.Parameters.AddWithValue("@Turno_15", SqlDbType.VarChar).Value = row.Cells["Turno"].Value;
                            comando.Parameters.AddWithValue("@Permiso_15", SqlDbType.Int).Value = row.Cells["Permiso"].Value;
                            comando.Parameters.AddWithValue("@Licencia_15", SqlDbType.Int).Value = row.Cells["Licencia"].Value;
                            comando.Parameters.AddWithValue("@Descanso_Medico_15", SqlDbType.Int).Value = row.Cells["Descanso Medico"].Value;
                            comando.Parameters.AddWithValue("@Suspension_15", SqlDbType.Int).Value = row.Cells["Suspension"].Value;
                            comando.Parameters.AddWithValue("@Vacaciones_15", SqlDbType.Int).Value = row.Cells["Vacaciones"].Value;
                            comando.Parameters.AddWithValue("@Faltas_15", SqlDbType.Int).Value = row.Cells["Faltas"].Value;
                            comando.Parameters.AddWithValue("@CANT_TARDANZAS_15", SqlDbType.Int).Value = row.Cells["CANT TARDANZAS"].Value;
                            comando.Parameters.AddWithValue("@Dias_Inafectos_15", SqlDbType.Int).Value = row.Cells["Dias Inafectos"].Value;
                            comando.Parameters.AddWithValue("@Dias_Laborados_15", SqlDbType.Int).Value = row.Cells["Dias Laborados"].Value;
                            comando.Parameters.AddWithValue("@Feriados_15", SqlDbType.Int).Value = row.Cells["Feriados"].Value;
                            comando.Parameters.AddWithValue("@Descanso_15", SqlDbType.Int).Value = row.Cells["Descanso"].Value;
                            comando.Parameters.AddWithValue("@Total_de_Dias_Laborados_15", SqlDbType.Int).Value = row.Cells["Total de Dias Laborados"].Value;
                            comando.Parameters.AddWithValue("@Sueldo_Mensual_15", SqlDbType.Decimal).Value = row.Cells["Sueldo Mensual"].Value;
                            comando.Parameters.AddWithValue("@REMUN_BASICO_15", SqlDbType.Decimal).Value = row.Cells["REMUN BASICO"].Value;
                            comando.Parameters.AddWithValue("@Pago_Feriado_15", SqlDbType.Decimal).Value = row.Cells["Pago Feriado"].Value;
                            comando.Parameters.AddWithValue("@H_E_25_15", SqlDbType.Decimal).Value = row.Cells["H_E 25%"].Value;
                            comando.Parameters.AddWithValue("@H_E_35_15", SqlDbType.Decimal).Value = row.Cells["H_E 35%"].Value;
                            comando.Parameters.AddWithValue("@bonif_15", SqlDbType.Decimal).Value = row.Cells["bonif"].Value;
                            comando.Parameters.AddWithValue("@Asignacion_Familiar_15", SqlDbType.Decimal).Value = row.Cells["Asignacion Familiar"].Value;
                            comando.Parameters.AddWithValue("@REINGRESO_AFECTO_15", SqlDbType.Decimal).Value = row.Cells["REINGRESO AFECTO"].Value;
                            comando.Parameters.AddWithValue("@DSCTO_TARDANZAS_15", SqlDbType.Decimal).Value = row.Cells["DSCTO TARDANZAS"].Value;
                            comando.Parameters.AddWithValue("@TOTAL_INGRESO_15", SqlDbType.Decimal).Value = row.Cells["TOTAL INGRESO"].Value;
                            comando.Parameters.AddWithValue("@Essalud_15", SqlDbType.Decimal).Value = row.Cells["Essalud"].Value;
                            comando.Parameters.AddWithValue("@SISTEMA_PENSIONARIO_15", SqlDbType.VarChar).Value = row.Cells["SISTEMA PENSIONARIO"].Value;
                            comando.Parameters.AddWithValue("@AFP_ONP_15", SqlDbType.Decimal).Value = row.Cells["AFP / ONP %"].Value;
                            comando.Parameters.AddWithValue("@APP_OBLIGATORIO_15", SqlDbType.Decimal).Value = row.Cells["APP OBLIGATORIO"].Value;
                            comando.Parameters.AddWithValue("@Comisión_15", SqlDbType.Decimal).Value = row.Cells["Comisión"].Value;
                            comando.Parameters.AddWithValue("@Prima_Seguro_15", SqlDbType.Decimal).Value = row.Cells["Prima Seguro"].Value;
                            comando.Parameters.AddWithValue("@CANT_AFP_ONP_15", SqlDbType.Decimal).Value = row.Cells["CANT_AFP / ONP"].Value;
                           // comando.Parameters.AddWithValue("@Desp_TARDANZA_15", SqlDbType.Decimal).Value = row.Cells["Desp TARDANZA"].Value;
                            comando.Parameters.AddWithValue("@PENALIDAD_15", SqlDbType.Decimal).Value = row.Cells["PENALIDAD"].Value;
                            comando.Parameters.AddWithValue("@RENTA_5TA_15", SqlDbType.Decimal).Value = row.Cells["RENTA 5TA"].Value;
                            comando.Parameters.AddWithValue("@Descuento_SUCAMEC_15", SqlDbType.Decimal).Value = row.Cells["Descuento SUCAMEC"].Value;
                            comando.Parameters.AddWithValue("@RETENCION_DE_ALIMENTOS_15", SqlDbType.Decimal).Value = row.Cells["RETENCION DE ALIMENTOS"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTOS_DE_BOTAS_ZAPATOS_15", SqlDbType.Decimal).Value = row.Cells["DESCUENTOS DE BOTAS/ZAPATOS"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_MULTA_ELECTRAL_15", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE MULTA ELECTRAL"].Value;
                            comando.Parameters.AddWithValue("@EXCESO_DE_PAGO_15", SqlDbType.Decimal).Value = row.Cells["EXCESO DE PAGO"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_PRUEBA_COVID_15", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE PRUEBA COVID"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_PAPELES_15", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE PAPELES"].Value;
                            comando.Parameters.AddWithValue("@PRESTAMOS_15", SqlDbType.Decimal).Value = row.Cells["PRESTAMOS"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_PERDIDA_DE_EQUIPO_15", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE PERDIDA DE EQUIPO"].Value;

                            comando.Parameters.AddWithValue("@Total_Descuentos_15", SqlDbType.Decimal).Value = row.Cells["Total Descuentos"].Value;
                            comando.Parameters.AddWithValue("@Total_A_Cobrar_15", SqlDbType.Decimal).Value = row.Cells["Total A Cobrar"].Value;
                            comando.Parameters.AddWithValue("@REINGRESOS_NO_AFECTOS_15", SqlDbType.Decimal).Value = row.Cells["REINGRESOS NO AFECTOS"].Value;
                            comando.Parameters.AddWithValue("@BONO_MOVILIDAD_15", SqlDbType.Decimal).Value = row.Cells["BONO / MOVILIDAD"].Value;
                            comando.Parameters.AddWithValue("@BONO_ARMADO_15", SqlDbType.Decimal).Value = row.Cells["BONO ARMADO"].Value;
                            comando.Parameters.AddWithValue("@DIAS_INAFECTOS_PAGO_15", SqlDbType.Decimal).Value = row.Cells["DIAS INAFECTOS PAGO"].Value;
                            comando.Parameters.AddWithValue("@NETO_A_PAGAR_15", SqlDbType.Decimal).Value = row.Cells["NETO A PAGAR"].Value;

                            comando.Parameters.AddWithValue("@DNI_EMPELADO_15", SqlDbType.VarChar).Value = row.Cells["DNI EMPELADO"].Value;
                            comando.Parameters.AddWithValue("@CUENTA_15", SqlDbType.VarChar).Value = row.Cells["CUENTA"].Value;
                            comando.Parameters.AddWithValue("@BANCO_15", SqlDbType.VarChar).Value = row.Cells["BANCO"].Value;
                            //comando.Parameters.AddWithValue("@FECHA_GENERADA_15", SqlDbType.VarChar).Value = row.Cells["FECHA GENERADA"].Value;
                            comando.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Datos registrado correptamente");
                    Vista.Planilla.GuardarPlanilla.frmMesAnioPlanilla frmMesAnioPlanilla = new Vista.Planilla.GuardarPlanilla.frmMesAnioPlanilla();
                    frmMesAnioPlanilla._tipo = cod_order;
                    frmMesAnioPlanilla.ShowDialog();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("error " + ex);
                    }
                }

                if (cod_order == 2)
                {
                    SqlCommand comando = new SqlCommand("sp_insertar_datos_planillas ", conexion.conexionBD());
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Cod Empleado"].Value != null && row.Cells["Empleado"].Value != null && row.Cells["Fecha Inicio"].Value != null
                             && row.Cells["Unidad"].Value != null && row.Cells["Turno"].Value != null && row.Cells["Permiso"].Value != null
                             && row.Cells["Licencia"].Value != null && row.Cells["Descanso Medico"].Value != null
                             && row.Cells["Suspension"].Value != null && row.Cells["Vacaciones"].Value != null
                             && row.Cells["Faltas"].Value != null && row.Cells["CANT TARDANZAS"].Value != null && row.Cells["Dias Inafectos"].Value != null
                             && row.Cells["Dias Laborados"].Value != null && row.Cells["Feriados"].Value != null && row.Cells["Descanso"].Value != null
                             && row.Cells["Total de Dias Laborados"].Value != null && row.Cells["Sueldo Mensual"].Value != null && row.Cells["REMUN BASICO"].Value != null
                             && row.Cells["Pago Feriado"].Value != null && row.Cells["H_E 25%"].Value != null && row.Cells["H_E 35%"].Value != null
                             && row.Cells["bonif"].Value != null && row.Cells["Asignacion Familiar"].Value != null && row.Cells["REINGRESO AFECTO"].Value != null
                             && row.Cells["DSCTO TARDANZAS"].Value != null && row.Cells["TOTAL INGRESO"].Value != null && row.Cells["Essalud"].Value != null
                             && row.Cells["SISTEMA PENSIONARIO"].Value != null && row.Cells["AFP / ONP %"].Value != null && row.Cells["APP OBLIGATORIO"].Value != null
                             && row.Cells["Comisión"].Value != null && row.Cells["Prima Seguro"].Value != null && row.Cells["CANT_AFP / ONP"].Value != null
                             && row.Cells["PENALIDAD"].Value != null && row.Cells["RENTA 5TA"].Value != null
                             && row.Cells["Descuento SUCAMEC"].Value != null && row.Cells["RETENCION DE ALIMENTOS"].Value != null && row.Cells["DESCUENTOS DE BOTAS/ZAPATOS"].Value != null
                             && row.Cells["DESCUENTO DE MULTA ELECTRAL"].Value != null && row.Cells["EXCESO DE PAGO"].Value != null && row.Cells["DESCUENTO DE PRUEBA COVID"].Value != null
                             && row.Cells["DESCUENTO DE PAPELES"].Value != null && row.Cells["PRESTAMOS"].Value != null && row.Cells["DESCUENTO DE PERDIDA DE EQUIPO"].Value != null
                             && row.Cells["Total Descuentos"].Value != null && row.Cells["Total A Cobrar"].Value != null && row.Cells["REINGRESOS NO AFECTOS"].Value != null
                             && row.Cells["BONO / MOVILIDAD"].Value != null && row.Cells["BONO ARMADO"].Value != null && row.Cells["DIAS INAFECTOS PAGO"].Value != null
                             && row.Cells["NETO A PAGAR"].Value != null && row.Cells["DNI EMPELADO"].Value != null && row.Cells["CUENTA"].Value != null
                             && row.Cells["BANCO"].Value != null)
                        {
                            comando.Parameters.Clear();
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.AddWithValue("@Cod_Empleado_30", SqlDbType.VarChar).Value = row.Cells["Cod Empleado"].Value;
                            comando.Parameters.AddWithValue("@Empleado_30", SqlDbType.VarChar).Value = row.Cells["Empleado"].Value;
                            comando.Parameters.AddWithValue("@Fecha_Inicio_30", SqlDbType.VarChar).Value = row.Cells["Fecha Inicio"].Value;
                            comando.Parameters.AddWithValue("@Unidad_30", SqlDbType.VarChar).Value = row.Cells["Unidad"].Value;
                            comando.Parameters.AddWithValue("@Turno_30", SqlDbType.VarChar).Value = row.Cells["Turno"].Value;
                            comando.Parameters.AddWithValue("@Permiso_30", SqlDbType.Int).Value = row.Cells["Permiso"].Value;
                            comando.Parameters.AddWithValue("@Licencia_30", SqlDbType.Int).Value = row.Cells["Licencia"].Value;
                            comando.Parameters.AddWithValue("@Descanso_Medico_15", SqlDbType.Int).Value = row.Cells["Descanso Medico"].Value;
                            comando.Parameters.AddWithValue("@Suspension_30", SqlDbType.Int).Value = row.Cells["Suspension"].Value;
                            comando.Parameters.AddWithValue("@Vacaciones_30", SqlDbType.Int).Value = row.Cells["Vacaciones"].Value;
                            comando.Parameters.AddWithValue("@Faltas_30", SqlDbType.Int).Value = row.Cells["Faltas"].Value;
                            comando.Parameters.AddWithValue("@CANT_TARDANZAS_30", SqlDbType.Int).Value = row.Cells["CANT TARDANZAS"].Value;
                            comando.Parameters.AddWithValue("@Dias_Inafectos_30", SqlDbType.Int).Value = row.Cells["Dias Inafectos"].Value;
                            comando.Parameters.AddWithValue("@Dias_Laborados_30", SqlDbType.Int).Value = row.Cells["Dias Laborados"].Value;
                            comando.Parameters.AddWithValue("@Feriados_30", SqlDbType.Int).Value = row.Cells["Feriados"].Value;
                            comando.Parameters.AddWithValue("@Descanso_30", SqlDbType.Int).Value = row.Cells["Descanso"].Value;
                            comando.Parameters.AddWithValue("@Total_de_Dias_Laborados_30", SqlDbType.Int).Value = row.Cells["Total de Dias Laborados"].Value;
                            comando.Parameters.AddWithValue("@Sueldo_Mensual_30", SqlDbType.Decimal).Value = row.Cells["Sueldo Mensual"].Value;
                            comando.Parameters.AddWithValue("@REMUN_BASICO_30", SqlDbType.Decimal).Value = row.Cells["REMUN BASICO"].Value;
                            comando.Parameters.AddWithValue("@Pago_Feriado_30", SqlDbType.Decimal).Value = row.Cells["Pago Feriado"].Value;
                            comando.Parameters.AddWithValue("@H_E_25_30", SqlDbType.Decimal).Value = row.Cells["H_E 25%"].Value;
                            comando.Parameters.AddWithValue("@H_E_35_30", SqlDbType.Decimal).Value = row.Cells["H_E 35%"].Value;
                            comando.Parameters.AddWithValue("@bonif_30", SqlDbType.Decimal).Value = row.Cells["bonif"].Value;
                            comando.Parameters.AddWithValue("@Asignacion_Familiar_30", SqlDbType.Decimal).Value = row.Cells["Asignacion Familiar"].Value;
                            comando.Parameters.AddWithValue("@REINGRESO_AFECTO_30", SqlDbType.Decimal).Value = row.Cells["REINGRESO AFECTO"].Value;
                            comando.Parameters.AddWithValue("@DSCTO_TARDANZAS_30", SqlDbType.Decimal).Value = row.Cells["DSCTO TARDANZAS"].Value;
                            comando.Parameters.AddWithValue("@TOTAL_INGRESO_30", SqlDbType.Decimal).Value = row.Cells["TOTAL INGRESO"].Value;
                            comando.Parameters.AddWithValue("@Essalud_30", SqlDbType.Decimal).Value = row.Cells["Essalud"].Value;
                            comando.Parameters.AddWithValue("@SISTEMA_PENSIONARIO_30", SqlDbType.VarChar).Value = row.Cells["SISTEMA PENSIONARIO"].Value;
                            comando.Parameters.AddWithValue("@AFP_ONP_30", SqlDbType.Decimal).Value = row.Cells["AFP / ONP %"].Value;
                            comando.Parameters.AddWithValue("@APP_OBLIGATORIO_30", SqlDbType.Decimal).Value = row.Cells["APP OBLIGATORIO"].Value;
                            comando.Parameters.AddWithValue("@Comisión_30", SqlDbType.Decimal).Value = row.Cells["Comisión"].Value;
                            comando.Parameters.AddWithValue("@Prima_Seguro_30", SqlDbType.Decimal).Value = row.Cells["Prima Seguro"].Value;
                            comando.Parameters.AddWithValue("@CANT_AFP_ONP_30", SqlDbType.Decimal).Value = row.Cells["CANT_AFP / ONP"].Value;
                            //comando.Parameters.AddWithValue("@Desp_TARDANZA_30", SqlDbType.Decimal).Value = row.Cells["Desp TARDANZA"].Value;
                            comando.Parameters.AddWithValue("@PENALIDAD_30", SqlDbType.Decimal).Value = row.Cells["PENALIDAD"].Value;
                            comando.Parameters.AddWithValue("@RENTA_5TA_30", SqlDbType.Decimal).Value = row.Cells["RENTA 5TA"].Value;
                            comando.Parameters.AddWithValue("@Descuento_SUCAMEC_30", SqlDbType.Decimal).Value = row.Cells["Descuento SUCAMEC"].Value;
                            comando.Parameters.AddWithValue("@RETENCION_DE_ALIMENTOS_30", SqlDbType.Decimal).Value = row.Cells["RETENCION DE ALIMENTOS"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTOS_DE_BOTAS_ZAPATOS_30", SqlDbType.Decimal).Value = row.Cells["DESCUENTOS DE BOTAS/ZAPATOS"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_MULTA_ELECTRAL_30", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE MULTA ELECTRAL"].Value;
                            comando.Parameters.AddWithValue("@EXCESO_DE_PAGO_30", SqlDbType.Decimal).Value = row.Cells["EXCESO DE PAGO"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_PRUEBA_COVID_30", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE PRUEBA COVID"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_PAPELES_30", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE PAPELES"].Value;
                            comando.Parameters.AddWithValue("@PRESTAMOS_30", SqlDbType.Decimal).Value = row.Cells["PRESTAMOS"].Value;
                            comando.Parameters.AddWithValue("@DESCUENTO_DE_PERDIDA_DE_EQUIPO_30", SqlDbType.Decimal).Value = row.Cells["DESCUENTO DE PERDIDA DE EQUIPO"].Value;

                            comando.Parameters.AddWithValue("@Total_Descuentos_30", SqlDbType.Decimal).Value = row.Cells["Total Descuentos"].Value;
                            comando.Parameters.AddWithValue("@Total_A_Cobrar_30", SqlDbType.Decimal).Value = row.Cells["Total A Cobrar"].Value;
                            comando.Parameters.AddWithValue("@REINGRESOS_NO_AFECTOS_30", SqlDbType.Decimal).Value = row.Cells["REINGRESOS NO AFECTOS"].Value;
                            comando.Parameters.AddWithValue("@BONO_MOVILIDAD_30", SqlDbType.Decimal).Value = row.Cells["BONO / MOVILIDAD"].Value;
                            comando.Parameters.AddWithValue("@BONO_ARMADO_30", SqlDbType.Decimal).Value = row.Cells["BONO ARMADO"].Value;
                            comando.Parameters.AddWithValue("@DIAS_INAFECTOS_PAGO_30", SqlDbType.Decimal).Value = row.Cells["DIAS INAFECTOS PAGO"].Value;
                            comando.Parameters.AddWithValue("@NETO_A_PAGAR_30", SqlDbType.Decimal).Value = row.Cells["NETO A PAGAR"].Value;

                            comando.Parameters.AddWithValue("@DNI_EMPELADO_30", SqlDbType.VarChar).Value = row.Cells["DNI EMPELADO"].Value;
                            comando.Parameters.AddWithValue("@CUENTA_30", SqlDbType.VarChar).Value = row.Cells["CUENTA"].Value;
                            comando.Parameters.AddWithValue("@BANCO_30", SqlDbType.VarChar).Value = row.Cells["BANCO"].Value;
                           // comando.Parameters.AddWithValue("@FECHA_GENERADA_30", SqlDbType.VarChar).Value = row.Cells["FECHA GENERADA"].Value;

                            comando.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Datos registrado correptamente");

                    Vista.Planilla.GuardarPlanilla.frmMesAnioPlanilla frmMesAnioPlanilla = new Vista.Planilla.GuardarPlanilla.frmMesAnioPlanilla();
                    frmMesAnioPlanilla._tipo = cod_order;
                    frmMesAnioPlanilla.ShowDialog();
                }


            }
        }
    }
}
