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
    public partial class frmPlataformaCalculoPlanilla : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        private void consultaPlanilla()
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text; 
                comando.CommandText = "sp_vista_planilla  ";
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Fecha Inicio";
                dt.Columns[3].ColumnName = "Unidad";
                dt.Columns[4].ColumnName = "Turno";
                dt.Columns[5].ColumnName = "Permiso";
                dt.Columns[6].ColumnName = "Licencia";
                dt.Columns[7].ColumnName = "Descanso Medico";
                dt.Columns[8].ColumnName = "Suspension";
                dt.Columns[9].ColumnName = "Vacaciones";
                dt.Columns[10].ColumnName = "Faltas";
                dt.Columns[11].ColumnName = "CANT TARDANZAS";
                dt.Columns[12].ColumnName = "Dias Inafectos";
                dt.Columns[13].ColumnName = "Dias Laborados";
                dt.Columns[14].ColumnName = "Feriados";
                dt.Columns[15].ColumnName = "Descanso";
                dt.Columns[16].ColumnName = "Total de Dias Laborados";
                dt.Columns[17].ColumnName = "Sueldo Mensual";
                dt.Columns[18].ColumnName = "REMUN BASICO";
                dt.Columns[19].ColumnName = "Pago Feriado";
                dt.Columns[20].ColumnName = "H_E 25%";
                dt.Columns[21].ColumnName = "H_E 35%";
                dt.Columns[22].ColumnName = "bonif";
                dt.Columns[23].ColumnName = "Asignacion Familiar";
                dt.Columns[24].ColumnName = "REINTEGRO AFECTO";
                dt.Columns[25].ColumnName = "DSCTO TARDANZAS";
                dt.Columns[26].ColumnName = "TOTAL INGRESO";
                dt.Columns[27].ColumnName = "Essalud";
                dt.Columns[28].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[29].ColumnName = "AFP / ONP %";
                dt.Columns[30].ColumnName = "APP OBLIGATORIO";
                dt.Columns[31].ColumnName = "Comisión";
                dt.Columns[32].ColumnName = "Prima Seguro";
                dt.Columns[33].ColumnName = "CANT_AFP / ONP";
                dt.Columns[34].ColumnName = "PENALIDAD";
                dt.Columns[35].ColumnName = "RENTA 5TA";
                dt.Columns[36].ColumnName = "Descuento SUCAMEC";
                dt.Columns[37].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[38].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS";
                dt.Columns[39].ColumnName = "DESCUENTO DE MULTA ELECTRAL";
                dt.Columns[40].ColumnName = "EXCESO DE PAGO";
                dt.Columns[41].ColumnName = "DESCUENTO DE PRUEBA COVID";
                dt.Columns[42].ColumnName = "DESCUENTO DE PAPELES";
                dt.Columns[43].ColumnName = "PRESTAMOS";
                dt.Columns[44].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO";
                dt.Columns[45].ColumnName = "Total Descuentos";
                dt.Columns[46].ColumnName = "Total A Cobrar";
                dt.Columns[47].ColumnName = "REINTEGRO NO AFECTOS";
                dt.Columns[48].ColumnName = "BONO / MOVILIDAD";
                dt.Columns[49].ColumnName = "BONO ARMADO";
                dt.Columns[50].ColumnName = "DIAS INAFECTOS PAGO";
                dt.Columns[51].ColumnName = "NETO A PAGAR";
                dt.Columns[52].ColumnName = "DNI EMPELADO";
                dt.Columns[53].ColumnName = "CUENTA";
                dt.Columns[54].ColumnName = "BANCO";
                dt.AcceptChanges();
                dgvPlataformaPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void generar_planilla_bloqueos(DateTime fechaInicio, DateTime fechaFin)
        {

            try
            {
                registrar.generar_planilla_bloqueos(fechaInicio, fechaFin);
                consultaPlanilla();
                MessageBox.Show("Planilla generado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR LA PLANILLA \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void generar_planilla(DateTime fechaInicio, DateTime fechaFin)
        {

            try
            {
                registrar.generar_planilla(fechaInicio, fechaFin);
                consultaPlanilla();
                MessageBox.Show("Planilla generado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR LA PLANILLA \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void generar_planillaTotal(DateTime fechaInicio, DateTime fechaFin)
        {

            try
            {
                registrar.generar_planillaTotal(fechaInicio, fechaFin);
                consultaPlanilla();
                MessageBox.Show("Planilla generado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR LA PLANILLA \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public frmPlataformaCalculoPlanilla()
        {
            InitializeComponent();
        }
        private void unidad_temporal()
        {
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SP_TEMPORA_UNIDAD";
            comando.ExecuteNonQuery();
        }
        private void frmPlataformaCalculoPlanilla_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadPlanillas(cbounidadplanilla);
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            lbcodigosUnidad.Visible = false;
            dgvPlataformaPlanilla.RowHeadersVisible = false;
            dgvPlataformaPlanilla.AllowUserToAddRows = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbunidades.Items.Add(cbounidadplanilla.GetItemText(cbounidadplanilla.SelectedItem));
            lbcodigosUnidad.Items.Add(cbounidadplanilla.SelectedValue.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lbunidades.Items.Clear();
            lbcodigosUnidad.Items.Clear();
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_eliminar_unidad_planilla";
            comando.ExecuteNonQuery();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Planilla";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Planilla";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            unidad_temporal();
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            DateTime fechaconsulta = DateTime.Now.Date;
            SqlCommand comando = new SqlCommand("sp_insertar_cod_unidad_planilla @param1", conexion.conexionBD());
            for (int i = 0; i < lbcodigosUnidad.Items.Count; i++)
            {
                // string info = lbcodigosUnidad.Items[i].ToString();
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@param1", lbcodigosUnidad.Items[i].ToString());
                comando.ExecuteNonQuery();
            }
            generar_planilla(dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            const string titulo = "Eliminar";
            const string mensaje = "Estas seguro que deseas Actualizar los Datos";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_eliminar_carga_dias";
                comando.ExecuteNonQuery();
                MessageBox.Show("Actualizacion exitosamente", "Actualizado");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_vista_planilla_EMPLEADO  @COD_EMPLEADO";
                comando.Parameters.AddWithValue("COD_EMPLEADO", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Fecha Inicio";
                dt.Columns[3].ColumnName = "Unidad";
                dt.Columns[4].ColumnName = "Turno";
                dt.Columns[5].ColumnName = "Permiso";
                dt.Columns[6].ColumnName = "Licencia";
                dt.Columns[7].ColumnName = "Descanso Medico";
                dt.Columns[8].ColumnName = "Suspension";
                dt.Columns[9].ColumnName = "Vacaciones";
                dt.Columns[10].ColumnName = "Faltas";
                dt.Columns[11].ColumnName = "CANT TARDANZAS";
                dt.Columns[12].ColumnName = "Dias Inafectos";
                dt.Columns[13].ColumnName = "Dias Laborados";
                dt.Columns[14].ColumnName = "Feriados";
                dt.Columns[15].ColumnName = "Descanso";
                dt.Columns[16].ColumnName = "Total de Dias Laborados";
                dt.Columns[17].ColumnName = "Sueldo Mensual";
                dt.Columns[18].ColumnName = "REMUN BASICO";
                dt.Columns[19].ColumnName = "Pago Feriado";
                dt.Columns[20].ColumnName = "H_E 25%";
                dt.Columns[21].ColumnName = "H_E 35%";
                dt.Columns[22].ColumnName = "bonif";
                dt.Columns[23].ColumnName = "Asignacion Familiar";
                dt.Columns[24].ColumnName = "REINTEGRO AFECTO";
                dt.Columns[25].ColumnName = "DSCTO TARDANZAS";
                dt.Columns[26].ColumnName = "TOTAL INGRESO";
                dt.Columns[27].ColumnName = "Essalud";
                dt.Columns[28].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[29].ColumnName = "AFP / ONP %";
                dt.Columns[30].ColumnName = "APP OBLIGATORIO";
                dt.Columns[31].ColumnName = "Comisión";
                dt.Columns[32].ColumnName = "Prima Seguro";
                dt.Columns[33].ColumnName = "CANT_AFP / ONP";
                dt.Columns[34].ColumnName = "PENALIDAD";
                dt.Columns[35].ColumnName = "RENTA 5TA";
                dt.Columns[36].ColumnName = "Descuento SUCAMEC";
                dt.Columns[37].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[38].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS";
                dt.Columns[39].ColumnName = "DESCUENTO DE MULTA ELECTRAL";
                dt.Columns[40].ColumnName = "EXCESO DE PAGO";
                dt.Columns[41].ColumnName = "DESCUENTO DE PRUEBA COVID";
                dt.Columns[42].ColumnName = "DESCUENTO DE PAPELES";
                dt.Columns[43].ColumnName = "PRESTAMOS";
                dt.Columns[44].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO";
                dt.Columns[45].ColumnName = "Total Descuentos";
                dt.Columns[46].ColumnName = "Total A Cobrar";
                dt.Columns[47].ColumnName = "REINTEGRO NO AFECTOS";
                dt.Columns[48].ColumnName = "BONO / MOVILIDAD";
                dt.Columns[49].ColumnName = "BONO ARMADO";
                dt.Columns[50].ColumnName = "DIAS INAFECTOS PAGO";
                dt.Columns[51].ColumnName = "NETO A PAGAR";
                dt.Columns[52].ColumnName = "DNI EMPELADO";
                dt.Columns[53].ColumnName = "CUENTA";
                dt.Columns[54].ColumnName = "BANCO";
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
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_vista_planilla  ";
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Fecha Inicio";
                dt.Columns[3].ColumnName = "Unidad";
                dt.Columns[4].ColumnName = "Turno";
                dt.Columns[5].ColumnName = "Permiso";
                dt.Columns[6].ColumnName = "Licencia";
                dt.Columns[7].ColumnName = "Descanso Medico";
                dt.Columns[8].ColumnName = "Suspension";
                dt.Columns[9].ColumnName = "Vacaciones";
                dt.Columns[10].ColumnName = "Faltas";
                dt.Columns[11].ColumnName = "CANT TARDANZAS";
                dt.Columns[12].ColumnName = "Dias Inafectos";
                dt.Columns[13].ColumnName = "Dias Laborados";
                dt.Columns[14].ColumnName = "Feriados";
                dt.Columns[15].ColumnName = "Descanso";
                dt.Columns[16].ColumnName = "Total de Dias Laborados";
                dt.Columns[17].ColumnName = "Sueldo Mensual";
                dt.Columns[18].ColumnName = "REMUN BASICO";
                dt.Columns[19].ColumnName = "Pago Feriado";
                dt.Columns[20].ColumnName = "H_E 25%";
                dt.Columns[21].ColumnName = "H_E 35%";
                dt.Columns[22].ColumnName = "bonif";
                dt.Columns[23].ColumnName = "Asignacion Familiar";
                dt.Columns[24].ColumnName = "REINTEGRO AFECTO";
                dt.Columns[25].ColumnName = "DSCTO TARDANZAS";
                dt.Columns[26].ColumnName = "TOTAL INGRESO";
                dt.Columns[27].ColumnName = "Essalud";
                dt.Columns[28].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[29].ColumnName = "AFP / ONP %";
                dt.Columns[30].ColumnName = "APP OBLIGATORIO";
                dt.Columns[31].ColumnName = "Comisión";
                dt.Columns[32].ColumnName = "Prima Seguro";
                dt.Columns[33].ColumnName = "CANT_AFP / ONP";
                dt.Columns[34].ColumnName = "PENALIDAD";
                dt.Columns[35].ColumnName = "RENTA 5TA";
                dt.Columns[36].ColumnName = "Descuento SUCAMEC";
                dt.Columns[37].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[38].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS";
                dt.Columns[39].ColumnName = "DESCUENTO DE MULTA ELECTRAL";
                dt.Columns[40].ColumnName = "EXCESO DE PAGO";
                dt.Columns[41].ColumnName = "DESCUENTO DE PRUEBA COVID";
                dt.Columns[42].ColumnName = "DESCUENTO DE PAPELES";
                dt.Columns[43].ColumnName = "PRESTAMOS";
                dt.Columns[44].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO";
                dt.Columns[45].ColumnName = "Total Descuentos";
                dt.Columns[46].ColumnName = "Total A Cobrar";
                dt.Columns[47].ColumnName = "REINTEGRO NO AFECTOS";
                dt.Columns[48].ColumnName = "BONO / MOVILIDAD";
                dt.Columns[49].ColumnName = "BONO ARMADO";
                dt.Columns[50].ColumnName = "DIAS INAFECTOS PAGO";
                dt.Columns[51].ColumnName = "NETO A PAGAR";
                dt.Columns[52].ColumnName = "DNI EMPELADO";
                dt.Columns[53].ColumnName = "CUENTA";
                dt.Columns[54].ColumnName = "BANCO";
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
            const string titulo = "Eliminar";
            const string mensaje = "Estas seguro que deseas Actualizar los Datos";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_ACTUALIZAR_DESCUENTOS";
                comando.ExecuteNonQuery();
                MessageBox.Show("Actualizacion exitosamente", "Actualizado");
            }
        }

        private void BTNcARGAmASIVA_Click(object sender, EventArgs e)
        {
            Vista.Planilla.CargaDeDatos.frmCargaDeDatosPlanillaDescuentos cargaDatos = new Vista.Planilla.CargaDeDatos.frmCargaDeDatosPlanillaDescuentos();
            cargaDatos.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fi = dtpFechaInicio.Value.Date.ToString("dd-MM-yyyy");
            string ff = dtpFechaFin.Value.Date.ToString("dd-MM-yyyy");
            Excel.ExportarDatosPlanillaExcel(dgvPlataformaPlanilla, progressBar1, fi, ff);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Vista.Planilla.MensajeConfirmacion.frmGuardarPlanilla GuardarPlanilla
                = new Vista.Planilla.MensajeConfirmacion.frmGuardarPlanilla();
            GuardarPlanilla._fecha = dtpFechaFin.Value;
            GuardarPlanilla._fecchagenerada = DateTime.Now.Date;

            GuardarPlanilla.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Planilla.BANCO.frmMacroBanco frmGenerarExcelPlanillaBanco = new Planilla.BANCO.frmMacroBanco();
            frmGenerarExcelPlanillaBanco.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            DateTime fechaconsulta = DateTime.Now.Date;
            generar_planilla_bloqueos(dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            generar_planillaTotal(dtpFechaInicio.Value, dtpFechaFin.Value);
        }
    }
}
