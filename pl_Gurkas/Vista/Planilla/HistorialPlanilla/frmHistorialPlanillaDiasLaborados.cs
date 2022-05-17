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
    public partial class frmHistorialPlanillaDiasLaborados : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        public frmHistorialPlanillaDiasLaborados()
        {
            InitializeComponent();
        }
        private void planilla_completa_genral_personal(string cod_empleado)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_empleado_planila_historial  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Fecha Inicio";
                dt.Columns[3].ColumnName = "Unidad";
                dt.Columns[4].ColumnName = "Turno";
                dt.Columns[5].ColumnName = "Permiso 1° Quincena";
                dt.Columns[6].ColumnName = "Permiso 2° Quincena";
                dt.Columns[7].ColumnName = "Permiso Total";
                dt.Columns[8].ColumnName = "Licencia 1° Quincena";
                dt.Columns[9].ColumnName = "Licencia 2° Quincena";
                dt.Columns[10].ColumnName = "Licencia Total";
                dt.Columns[11].ColumnName = "Suspension 1° Quincena";
                dt.Columns[12].ColumnName = "Suspension 2° Quincena";
                dt.Columns[13].ColumnName = "Suspension Total";
                dt.Columns[14].ColumnName = "Vacaciones 1° Quincena";
                dt.Columns[15].ColumnName = "Vacaciones 2° Quincena";
                dt.Columns[16].ColumnName = "Vacaciones Total";
                dt.Columns[17].ColumnName = "Faltas 1° Quincena";
                dt.Columns[18].ColumnName = "Faltas 2° Quincena";
                dt.Columns[19].ColumnName = "Faltas Total";
                dt.Columns[20].ColumnName = "CANT. TARDANZAS 1° Quincena";
                dt.Columns[21].ColumnName = "CANT. TARDANZAS 2° Quincena";
                dt.Columns[22].ColumnName = "CANT. TARDANZAS Total";
                dt.Columns[23].ColumnName = "Dias Inafectos 1° Quincena";
                dt.Columns[24].ColumnName = "Dias Inafectos 2° Quincena";
                dt.Columns[25].ColumnName = "Dias Inafectos Total";
                dt.Columns[26].ColumnName = "Dias Laborados 1° Quincena";
                dt.Columns[27].ColumnName = "Dias Laborados 2° Quincena";
                dt.Columns[28].ColumnName = "Dias Laborados Total";
                dt.Columns[29].ColumnName = "Feriados 1° Quincena";
                dt.Columns[30].ColumnName = "Feriados 2° Quincena";
                dt.Columns[31].ColumnName = "Feriados Total";
                dt.Columns[32].ColumnName = "Descanso 1° Quincena";
                dt.Columns[33].ColumnName = "Descanso 2° Quincena";
                dt.Columns[34].ColumnName = "Descanso Total";
                dt.Columns[35].ColumnName = "Total de Dias Laborados 1° Quincena";
                dt.Columns[36].ColumnName = "Total de Dias Laborados 2° Quincena";
                dt.Columns[37].ColumnName = "Total de Dias Laborados Total";
                dt.Columns[38].ColumnName = "Sueldo Mensual 1° Quincena";
                dt.Columns[39].ColumnName = "Sueldo Mensual 2° Quincena";
                dt.Columns[40].ColumnName = "REMUN. BASICO 1° Quincena";
                dt.Columns[41].ColumnName = "REMUN. BASICO 2° Quincena";
                dt.Columns[42].ColumnName = "REMUN. BASICO Total";
                dt.Columns[43].ColumnName = "Pago Feriado 1° Quincena";
                dt.Columns[44].ColumnName = "Pago Feriado 2° Quincena";
                dt.Columns[45].ColumnName = "Pago Feriado Total";
                dt.Columns[46].ColumnName = "H.E 25% 1° Quincena";
                dt.Columns[47].ColumnName = "H.E 25% 2° Quincena";
                dt.Columns[48].ColumnName = "H.E 25% Total";
                dt.Columns[49].ColumnName = "H.E 35% 1° Quincena";
                dt.Columns[50].ColumnName = "H.E 35% 2° Quincena";
                dt.Columns[51].ColumnName = "H.E 35% Total";
                dt.Columns[52].ColumnName = "bonif. 1° Quincena";
                dt.Columns[53].ColumnName = "bonif. 2° Quincena";
                dt.Columns[54].ColumnName = "bonif. Total";
                dt.Columns[55].ColumnName = "Asignacion Familiar 1° Quincena";
                dt.Columns[56].ColumnName = "Asignacion Familiar 2° Quincena";
                dt.Columns[57].ColumnName = "Asignacion Familiar Total";
                dt.Columns[58].ColumnName = "REINGRESO AFECTO 1° Quincena";
                dt.Columns[59].ColumnName = "REINGRESO AFECTO 2° Quincena";
                dt.Columns[60].ColumnName = "REINGRESO AFECTO Total";
                dt.Columns[61].ColumnName = "DSCTO TARDANZAS 1° Quincena";
                dt.Columns[62].ColumnName = "DSCTO TARDANZAS 2° Quincena";
                dt.Columns[63].ColumnName = "DSCTO TARDANZAS Total";
                dt.Columns[64].ColumnName = "TOTAL INGRESO 1° Quincena";
                dt.Columns[65].ColumnName = "TOTAL INGRESO 2° Quincena";
                dt.Columns[66].ColumnName = "TOTAL INGRESO Total";
                dt.Columns[67].ColumnName = "Essalud 1° Quincena";
                dt.Columns[68].ColumnName = "Essalud 2° Quincena";
                dt.Columns[69].ColumnName = "Essalud Total";
                dt.Columns[70].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[71].ColumnName = "AFP / ONP % 1° Quincena";
                dt.Columns[72].ColumnName = "AFP / ONP % 2° Quincena";
                dt.Columns[73].ColumnName = "APP OBLIGATORIO 1° Quincena";
                dt.Columns[74].ColumnName = "APP OBLIGATORIO 2° Quincena";
                dt.Columns[75].ColumnName = "APP OBLIGATORIO Total";
                dt.Columns[76].ColumnName = "Comisión 1° Quincena";
                dt.Columns[77].ColumnName = "Comisión 2° Quincena";
                dt.Columns[78].ColumnName = "Comisión Total";
                dt.Columns[79].ColumnName = "Prima Seguro 1° Quincena";
                dt.Columns[80].ColumnName = "Prima Seguro 2° Quincena";
                dt.Columns[81].ColumnName = "Prima Seguro Total";
                dt.Columns[82].ColumnName = "CANT.AFP / ONP 1° Quincena";
                dt.Columns[83].ColumnName = "CANT.AFP / ONP 2° Quincena";
                dt.Columns[84].ColumnName = "CANT.AFP / ONP Total";
                dt.Columns[85].ColumnName = "PENALIDAD 1° Quincena";
                dt.Columns[86].ColumnName = "PENALIDAD 2° Quincena";
                dt.Columns[87].ColumnName = "PENALIDAD Total";
                dt.Columns[88].ColumnName = "RENTA 5TA 1° Quincena";
                dt.Columns[89].ColumnName = "RENTA 5TA 2° Quincena";
                dt.Columns[90].ColumnName = "RENTA 5TA Total";
                dt.Columns[91].ColumnName = "Descuento SUCAMEC 1° Quincena";
                dt.Columns[92].ColumnName = "Descuento SUCAMEC 2° Quincena";
                dt.Columns[93].ColumnName = "Descuento SUCAMEC Total";
                dt.Columns[94].ColumnName = "RETENCION DE ALIMENTOS 1° Quincena";
                dt.Columns[95].ColumnName = "RETENCION DE ALIMENTOS 2° Quincena";
                dt.Columns[96].ColumnName = "RETENCION DE ALIMENTOS Total";
                dt.Columns[97].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS 1° Quincena";
                dt.Columns[98].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS 2° Quincena";
                dt.Columns[99].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS Total";
                dt.Columns[100].ColumnName = "DESCUENTO DE MULTA ELECTRAL 1° Quincena";
                dt.Columns[101].ColumnName = "DESCUENTO DE MULTA ELECTRAL 2° Quincena";
                dt.Columns[102].ColumnName = "DESCUENTO DE MULTA ELECTRAL Total";
                dt.Columns[103].ColumnName = "EXCESO DE PAGO 1° Quincena";
                dt.Columns[104].ColumnName = "EXCESO DE PAGO 2° Quincena";
                dt.Columns[105].ColumnName = "EXCESO DE PAGO Total";
                dt.Columns[106].ColumnName = "DESCUENTO DE PRUEBA COVID 1° Quincena";
                dt.Columns[107].ColumnName = "DESCUENTO DE PRUEBA COVID 2° Quincena";
                dt.Columns[108].ColumnName = "DESCUENTO DE PRUEBA COVID Total";
                dt.Columns[109].ColumnName = "DESCUENTO DE PAPELES 1° Quincena";
                dt.Columns[110].ColumnName = "DESCUENTO DE PAPELES 2° Quincena";
                dt.Columns[111].ColumnName = "DESCUENTO DE PAPELES Total";
                dt.Columns[112].ColumnName = "PRESTAMOS 1° Quincena";
                dt.Columns[113].ColumnName = "PRESTAMOS 2° Quincena";
                dt.Columns[114].ColumnName = "PRESTAMOS Total";
                dt.Columns[115].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO 1° Quincena";
                dt.Columns[116].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO 2° Quincena";
                dt.Columns[117].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO Total";
                dt.Columns[118].ColumnName = "Total Descuentos 1° Quincena";
                dt.Columns[119].ColumnName = "Total Descuentos 2° Quincena";
                dt.Columns[120].ColumnName = "Total Descuentos Total";
                dt.Columns[121].ColumnName = "Total A Cobrar 1° Quincena";
                dt.Columns[122].ColumnName = "Total A Cobrar 2° Quincena";
                dt.Columns[123].ColumnName = "Total A Cobrar Total";
                dt.Columns[124].ColumnName = "REINGRESOS NO AFECTOS 1° Quincena";
                dt.Columns[125].ColumnName = "REINGRESOS NO AFECTOS 2° Quincena";
                dt.Columns[126].ColumnName = "REINGRESOS NO AFECTOS Total";
                dt.Columns[127].ColumnName = "BONO / MOVILIDAD 1° Quincena";
                dt.Columns[128].ColumnName = "BONO / MOVILIDAD 2° Quincena";
                dt.Columns[129].ColumnName = "BONO / MOVILIDAD Total";
                dt.Columns[130].ColumnName = "BONO ARMADO 1° Quincena";
                dt.Columns[131].ColumnName = "BONO ARMADO 2° Quincena";
                dt.Columns[132].ColumnName = "BONO ARMADO Total";
                dt.Columns[133].ColumnName = "DIAS INAFECTOS PAGO 1° Quincena";
                dt.Columns[134].ColumnName = "DIAS INAFECTOS PAGO 2° Quincena";
                dt.Columns[135].ColumnName = "DIAS INAFECTOS PAGO Total";
                dt.Columns[136].ColumnName = "NETO A PAGAR 1° Quincena";
                dt.Columns[137].ColumnName = "NETO A PAGAR 2° Quincena";
                dt.Columns[138].ColumnName = "NETO A PAGAR Total";
                dt.Columns[139].ColumnName = "DNI EMPELADO";
                dt.Columns[140].ColumnName = "CUENTA";
                dt.Columns[141].ColumnName = "BANCO";
                dt.Columns[142].ColumnName = "FECHA GENERADA 1° Quincena";
                dt.Columns[143].ColumnName = "FECHA GENERADA 2° Quincena";
                dt.Columns[144].ColumnName = "Mes";
                dt.Columns[145].ColumnName = "Año";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_completa_genral_unidad(string cod_unidad, int mes, int anio)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_undidad_planila_historial  @cod_unidad,@mes,@anio";
                comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Fecha Inicio";
                dt.Columns[3].ColumnName = "Unidad";
                dt.Columns[4].ColumnName = "Turno";
                dt.Columns[5].ColumnName = "Permiso 1° Quincena";
                dt.Columns[6].ColumnName = "Permiso 2° Quincena";
                dt.Columns[7].ColumnName = "Permiso Total";
                dt.Columns[8].ColumnName = "Licencia 1° Quincena";
                dt.Columns[9].ColumnName = "Licencia 2° Quincena";
                dt.Columns[10].ColumnName = "Licencia Total";
                dt.Columns[11].ColumnName = "Suspension 1° Quincena";
                dt.Columns[12].ColumnName = "Suspension 2° Quincena";
                dt.Columns[13].ColumnName = "Suspension Total";
                dt.Columns[14].ColumnName = "Vacaciones 1° Quincena";
                dt.Columns[15].ColumnName = "Vacaciones 2° Quincena";
                dt.Columns[16].ColumnName = "Vacaciones Total";
                dt.Columns[17].ColumnName = "Faltas 1° Quincena";
                dt.Columns[18].ColumnName = "Faltas 2° Quincena";
                dt.Columns[19].ColumnName = "Faltas Total";
                dt.Columns[20].ColumnName = "CANT. TARDANZAS 1° Quincena";
                dt.Columns[21].ColumnName = "CANT. TARDANZAS 2° Quincena";
                dt.Columns[22].ColumnName = "CANT. TARDANZAS Total";
                dt.Columns[23].ColumnName = "Dias Inafectos 1° Quincena";
                dt.Columns[24].ColumnName = "Dias Inafectos 2° Quincena";
                dt.Columns[25].ColumnName = "Dias Inafectos Total";
                dt.Columns[26].ColumnName = "Dias Laborados 1° Quincena";
                dt.Columns[27].ColumnName = "Dias Laborados 2° Quincena";
                dt.Columns[28].ColumnName = "Dias Laborados Total";
                dt.Columns[29].ColumnName = "Feriados 1° Quincena";
                dt.Columns[30].ColumnName = "Feriados 2° Quincena";
                dt.Columns[31].ColumnName = "Feriados Total";
                dt.Columns[32].ColumnName = "Descanso 1° Quincena";
                dt.Columns[33].ColumnName = "Descanso 2° Quincena";
                dt.Columns[34].ColumnName = "Descanso Total";
                dt.Columns[35].ColumnName = "Total de Dias Laborados 1° Quincena";
                dt.Columns[36].ColumnName = "Total de Dias Laborados 2° Quincena";
                dt.Columns[37].ColumnName = "Total de Dias Laborados Total";
                dt.Columns[38].ColumnName = "Sueldo Mensual 1° Quincena";
                dt.Columns[39].ColumnName = "Sueldo Mensual 2° Quincena";
                dt.Columns[40].ColumnName = "REMUN. BASICO 1° Quincena";
                dt.Columns[41].ColumnName = "REMUN. BASICO 2° Quincena";
                dt.Columns[42].ColumnName = "REMUN. BASICO Total";
                dt.Columns[43].ColumnName = "Pago Feriado 1° Quincena";
                dt.Columns[44].ColumnName = "Pago Feriado 2° Quincena";
                dt.Columns[45].ColumnName = "Pago Feriado Total";
                dt.Columns[46].ColumnName = "H.E 25% 1° Quincena";
                dt.Columns[47].ColumnName = "H.E 25% 2° Quincena";
                dt.Columns[48].ColumnName = "H.E 25% Total";
                dt.Columns[49].ColumnName = "H.E 35% 1° Quincena";
                dt.Columns[50].ColumnName = "H.E 35% 2° Quincena";
                dt.Columns[51].ColumnName = "H.E 35% Total";
                dt.Columns[52].ColumnName = "bonif. 1° Quincena";
                dt.Columns[53].ColumnName = "bonif. 2° Quincena";
                dt.Columns[54].ColumnName = "bonif. Total";
                dt.Columns[55].ColumnName = "Asignacion Familiar 1° Quincena";
                dt.Columns[56].ColumnName = "Asignacion Familiar 2° Quincena";
                dt.Columns[57].ColumnName = "Asignacion Familiar Total";
                dt.Columns[58].ColumnName = "REINGRESO AFECTO 1° Quincena";
                dt.Columns[59].ColumnName = "REINGRESO AFECTO 2° Quincena";
                dt.Columns[60].ColumnName = "REINGRESO AFECTO Total";
                dt.Columns[61].ColumnName = "DSCTO TARDANZAS 1° Quincena";
                dt.Columns[62].ColumnName = "DSCTO TARDANZAS 2° Quincena";
                dt.Columns[63].ColumnName = "DSCTO TARDANZAS Total";
                dt.Columns[64].ColumnName = "TOTAL INGRESO 1° Quincena";
                dt.Columns[65].ColumnName = "TOTAL INGRESO 2° Quincena";
                dt.Columns[66].ColumnName = "TOTAL INGRESO Total";
                dt.Columns[67].ColumnName = "Essalud 1° Quincena";
                dt.Columns[68].ColumnName = "Essalud 2° Quincena";
                dt.Columns[69].ColumnName = "Essalud Total";
                dt.Columns[70].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[71].ColumnName = "AFP / ONP % 1° Quincena";
                dt.Columns[72].ColumnName = "AFP / ONP % 2° Quincena";
                dt.Columns[73].ColumnName = "APP OBLIGATORIO 1° Quincena";
                dt.Columns[74].ColumnName = "APP OBLIGATORIO 2° Quincena";
                dt.Columns[75].ColumnName = "APP OBLIGATORIO Total";
                dt.Columns[76].ColumnName = "Comisión 1° Quincena";
                dt.Columns[77].ColumnName = "Comisión 2° Quincena";
                dt.Columns[78].ColumnName = "Comisión Total";
                dt.Columns[79].ColumnName = "Prima Seguro 1° Quincena";
                dt.Columns[80].ColumnName = "Prima Seguro 2° Quincena";
                dt.Columns[81].ColumnName = "Prima Seguro Total";
                dt.Columns[82].ColumnName = "CANT.AFP / ONP 1° Quincena";
                dt.Columns[83].ColumnName = "CANT.AFP / ONP 2° Quincena";
                dt.Columns[84].ColumnName = "CANT.AFP / ONP Total";
                dt.Columns[85].ColumnName = "PENALIDAD 1° Quincena";
                dt.Columns[86].ColumnName = "PENALIDAD 2° Quincena";
                dt.Columns[87].ColumnName = "PENALIDAD Total";
                dt.Columns[88].ColumnName = "RENTA 5TA 1° Quincena";
                dt.Columns[89].ColumnName = "RENTA 5TA 2° Quincena";
                dt.Columns[90].ColumnName = "RENTA 5TA Total";
                dt.Columns[91].ColumnName = "Descuento SUCAMEC 1° Quincena";
                dt.Columns[92].ColumnName = "Descuento SUCAMEC 2° Quincena";
                dt.Columns[93].ColumnName = "Descuento SUCAMEC Total";
                dt.Columns[94].ColumnName = "RETENCION DE ALIMENTOS 1° Quincena";
                dt.Columns[95].ColumnName = "RETENCION DE ALIMENTOS 2° Quincena";
                dt.Columns[96].ColumnName = "RETENCION DE ALIMENTOS Total";
                dt.Columns[97].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS 1° Quincena";
                dt.Columns[98].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS 2° Quincena";
                dt.Columns[99].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS Total";
                dt.Columns[100].ColumnName = "DESCUENTO DE MULTA ELECTRAL 1° Quincena";
                dt.Columns[101].ColumnName = "DESCUENTO DE MULTA ELECTRAL 2° Quincena";
                dt.Columns[102].ColumnName = "DESCUENTO DE MULTA ELECTRAL Total";
                dt.Columns[103].ColumnName = "EXCESO DE PAGO 1° Quincena";
                dt.Columns[104].ColumnName = "EXCESO DE PAGO 2° Quincena";
                dt.Columns[105].ColumnName = "EXCESO DE PAGO Total";
                dt.Columns[106].ColumnName = "DESCUENTO DE PRUEBA COVID 1° Quincena";
                dt.Columns[107].ColumnName = "DESCUENTO DE PRUEBA COVID 2° Quincena";
                dt.Columns[108].ColumnName = "DESCUENTO DE PRUEBA COVID Total";
                dt.Columns[109].ColumnName = "DESCUENTO DE PAPELES 1° Quincena";
                dt.Columns[110].ColumnName = "DESCUENTO DE PAPELES 2° Quincena";
                dt.Columns[111].ColumnName = "DESCUENTO DE PAPELES Total";
                dt.Columns[112].ColumnName = "PRESTAMOS 1° Quincena";
                dt.Columns[113].ColumnName = "PRESTAMOS 2° Quincena";
                dt.Columns[114].ColumnName = "PRESTAMOS Total";
                dt.Columns[115].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO 1° Quincena";
                dt.Columns[116].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO 2° Quincena";
                dt.Columns[117].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO Total";
                dt.Columns[118].ColumnName = "Total Descuentos 1° Quincena";
                dt.Columns[119].ColumnName = "Total Descuentos 2° Quincena";
                dt.Columns[120].ColumnName = "Total Descuentos Total";
                dt.Columns[121].ColumnName = "Total A Cobrar 1° Quincena";
                dt.Columns[122].ColumnName = "Total A Cobrar 2° Quincena";
                dt.Columns[123].ColumnName = "Total A Cobrar Total";
                dt.Columns[124].ColumnName = "REINGRESOS NO AFECTOS 1° Quincena";
                dt.Columns[125].ColumnName = "REINGRESOS NO AFECTOS 2° Quincena";
                dt.Columns[126].ColumnName = "REINGRESOS NO AFECTOS Total";
                dt.Columns[127].ColumnName = "BONO / MOVILIDAD 1° Quincena";
                dt.Columns[128].ColumnName = "BONO / MOVILIDAD 2° Quincena";
                dt.Columns[129].ColumnName = "BONO / MOVILIDAD Total";
                dt.Columns[130].ColumnName = "BONO ARMADO 1° Quincena";
                dt.Columns[131].ColumnName = "BONO ARMADO 2° Quincena";
                dt.Columns[132].ColumnName = "BONO ARMADO Total";
                dt.Columns[133].ColumnName = "DIAS INAFECTOS PAGO 1° Quincena";
                dt.Columns[134].ColumnName = "DIAS INAFECTOS PAGO 2° Quincena";
                dt.Columns[135].ColumnName = "DIAS INAFECTOS PAGO Total";
                dt.Columns[136].ColumnName = "NETO A PAGAR 1° Quincena";
                dt.Columns[137].ColumnName = "NETO A PAGAR 2° Quincena";
                dt.Columns[138].ColumnName = "NETO A PAGAR Total";
                dt.Columns[139].ColumnName = "DNI EMPELADO";
                dt.Columns[140].ColumnName = "CUENTA";
                dt.Columns[141].ColumnName = "BANCO";
                dt.Columns[142].ColumnName = "FECHA GENERADA 1° Quincena";
                dt.Columns[143].ColumnName = "FECHA GENERADA 2° Quincena";
                dt.Columns[144].ColumnName = "Mes";
                dt.Columns[145].ColumnName = "Año";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_fin_mes(int mes, int anio,int ID_EMPRESA)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_fin_mes_busqueda  @mes,@anio,@ID_EMPRESA";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("ID_EMPRESA", ID_EMPRESA);
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
                dt.Columns[7].ColumnName = "Suspension";
                dt.Columns[8].ColumnName = "Vacaciones";
                dt.Columns[9].ColumnName = "Faltas";
                dt.Columns[10].ColumnName = "CANT. TARDANZAS";
                dt.Columns[11].ColumnName = "Dias Inafectos";
                dt.Columns[12].ColumnName = "Dias Laborados";
                dt.Columns[13].ColumnName = "Feriados";
                dt.Columns[14].ColumnName = "Descanso";
                dt.Columns[15].ColumnName = "Total de Dias Laborados";
                dt.Columns[16].ColumnName = "Sueldo Mensual";
                dt.Columns[17].ColumnName = "REMUN. BASICO";
                dt.Columns[18].ColumnName = "Pago Feriado";
                dt.Columns[19].ColumnName = "H.E 25%";
                dt.Columns[20].ColumnName = "H.E 35%";
                dt.Columns[21].ColumnName = "bonif.";
                dt.Columns[22].ColumnName = "Asignacion Familiar";
                dt.Columns[23].ColumnName = "REINGRESO AFECTO";
                dt.Columns[24].ColumnName = "DSCTO TARDANZAS";
                dt.Columns[25].ColumnName = "TOTAL INGRESO";
                dt.Columns[26].ColumnName = "Essalud";
                dt.Columns[27].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[28].ColumnName = "AFP / ONP %";
                dt.Columns[29].ColumnName = "APP OBLIGATORIO";
                dt.Columns[30].ColumnName = "Comisión";
                dt.Columns[31].ColumnName = "Prima Seguro";
                dt.Columns[32].ColumnName = "CANT.AFP / ONP";
                dt.Columns[33].ColumnName = "PENALIDAD";
                dt.Columns[34].ColumnName = "RENTA 5TA";
                dt.Columns[35].ColumnName = "Descuento SUCAMEC";
                dt.Columns[36].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[37].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS";
                dt.Columns[38].ColumnName = "DESCUENTO DE MULTA ELECTRAL";
                dt.Columns[39].ColumnName = "EXCESO DE PAGO";
                dt.Columns[40].ColumnName = "DESCUENTO DE PRUEBA COVID";
                dt.Columns[41].ColumnName = "DESCUENTO DE PAPELES";
                dt.Columns[42].ColumnName = "PRESTAMOS";
                dt.Columns[43].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO";
                dt.Columns[44].ColumnName = "Total Descuentos";
                dt.Columns[45].ColumnName = "Total A Cobrar";
                dt.Columns[46].ColumnName = "REINGRESOS NO AFECTOS";
                dt.Columns[47].ColumnName = "BONO / MOVILIDAD";
                dt.Columns[48].ColumnName = "BONO ARMADO";
                dt.Columns[49].ColumnName = "DIAS INAFECTOS PAGO";
                dt.Columns[50].ColumnName = "NETO A PAGAR";
                dt.Columns[51].ColumnName = "DNI EMPELADO";
                dt.Columns[52].ColumnName = "CUENTA";
                dt.Columns[53].ColumnName = "BANCO";
               // dt.Columns[54].ColumnName = "FECHA GENERADA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_completa(int mes, int anio,int ID_EMPRESA)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_total_busqueda  @mes,@anio,@ID_EMPRESA";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("ID_EMPRESA", ID_EMPRESA);
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
                dt.Columns[7].ColumnName = "Suspension";
                dt.Columns[8].ColumnName = "Vacaciones";
                dt.Columns[9].ColumnName = "Faltas";
                dt.Columns[10].ColumnName = "CANT. TARDANZAS";
                dt.Columns[11].ColumnName = "Dias Inafectos";
                dt.Columns[12].ColumnName = "Dias Laborados";
                dt.Columns[13].ColumnName = "Feriados";
                dt.Columns[14].ColumnName = "Descanso";
                dt.Columns[15].ColumnName = "Total de Dias Laborados";
                dt.Columns[16].ColumnName = "Sueldo Mensual";
                dt.Columns[17].ColumnName = "REMUN. BASICO";
                dt.Columns[18].ColumnName = "Pago Feriado";
                dt.Columns[19].ColumnName = "H.E 25%";
                dt.Columns[20].ColumnName = "H.E 35%";
                dt.Columns[21].ColumnName = "bonif.";
                dt.Columns[22].ColumnName = "Asignacion Familiar";
                dt.Columns[23].ColumnName = "REINGRESO AFECTO";
                dt.Columns[24].ColumnName = "DSCTO TARDANZAS";
                dt.Columns[25].ColumnName = "TOTAL INGRESO";
                dt.Columns[26].ColumnName = "Essalud";
                dt.Columns[27].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[28].ColumnName = "AFP / ONP %";
                dt.Columns[29].ColumnName = "APP OBLIGATORIO";
                dt.Columns[30].ColumnName = "Comisión";
                dt.Columns[31].ColumnName = "Prima Seguro";
                dt.Columns[32].ColumnName = "CANT.AFP / ONP";
                dt.Columns[33].ColumnName = "PENALIDAD";
                dt.Columns[34].ColumnName = "RENTA 5TA";
                dt.Columns[35].ColumnName = "Descuento SUCAMEC";
                dt.Columns[36].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[37].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS";
                dt.Columns[38].ColumnName = "DESCUENTO DE MULTA ELECTRAL";
                dt.Columns[39].ColumnName = "EXCESO DE PAGO";
                dt.Columns[40].ColumnName = "DESCUENTO DE PRUEBA COVID";
                dt.Columns[41].ColumnName = "DESCUENTO DE PAPELES";
                dt.Columns[42].ColumnName = "PRESTAMOS";
                dt.Columns[43].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO";
                dt.Columns[44].ColumnName = "Total Descuentos";
                dt.Columns[45].ColumnName = "Total A Cobrar";
                dt.Columns[46].ColumnName = "REINGRESOS NO AFECTOS";
                dt.Columns[47].ColumnName = "BONO / MOVILIDAD";
                dt.Columns[48].ColumnName = "BONO ARMADO";
                dt.Columns[49].ColumnName = "DIAS INAFECTOS PAGO";
                dt.Columns[50].ColumnName = "NETO A PAGAR";
                dt.Columns[51].ColumnName = "DNI EMPELADO";
                dt.Columns[52].ColumnName = "CUENTA";
                dt.Columns[53].ColumnName = "BANCO";
                // dt.Columns[55].ColumnName = "FECHA GENERADA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_quincena(int mes, int anio,int ID_EMPRESA)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_planilla_quincena_busqueda  @mes,@anio, @ID_EMPRESA";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("ID_EMPRESA", ID_EMPRESA);
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
                dt.Columns[7].ColumnName = "Suspension";
                dt.Columns[8].ColumnName = "Vacaciones";
                dt.Columns[9].ColumnName = "Faltas";
                dt.Columns[10].ColumnName = "CANT. TARDANZAS";
                dt.Columns[11].ColumnName = "Dias Inafectos";
                dt.Columns[12].ColumnName = "Dias Laborados";
                dt.Columns[13].ColumnName = "Feriados";
                dt.Columns[14].ColumnName = "Descanso";
                dt.Columns[15].ColumnName = "Total de Dias Laborados";
                dt.Columns[16].ColumnName = "Sueldo Mensual";
                dt.Columns[17].ColumnName = "REMUN. BASICO";
                dt.Columns[18].ColumnName = "Pago Feriado";
                dt.Columns[19].ColumnName = "H.E 25%";
                dt.Columns[20].ColumnName = "H.E 35%";
                dt.Columns[21].ColumnName = "bonif.";
                dt.Columns[22].ColumnName = "Asignacion Familiar";
                dt.Columns[23].ColumnName = "REINGRESO AFECTO";
                dt.Columns[24].ColumnName = "DSCTO TARDANZAS";
                dt.Columns[25].ColumnName = "TOTAL INGRESO";
                dt.Columns[26].ColumnName = "Essalud";
                dt.Columns[27].ColumnName = "SISTEMA PENSIONARIO";
                dt.Columns[28].ColumnName = "AFP / ONP %";
                dt.Columns[29].ColumnName = "APP OBLIGATORIO";
                dt.Columns[30].ColumnName = "Comisión";
                dt.Columns[31].ColumnName = "Prima Seguro";
                dt.Columns[32].ColumnName = "CANT.AFP / ONP";
                dt.Columns[33].ColumnName = "PENALIDAD";
                dt.Columns[34].ColumnName = "RENTA 5TA";
                dt.Columns[35].ColumnName = "Descuento SUCAMEC";
                dt.Columns[36].ColumnName = "RETENCION DE ALIMENTOS";
                dt.Columns[37].ColumnName = "DESCUENTOS DE BOTAS/ZAPATOS";
                dt.Columns[38].ColumnName = "DESCUENTO DE MULTA ELECTRAL";
                dt.Columns[39].ColumnName = "EXCESO DE PAGO";
                dt.Columns[40].ColumnName = "DESCUENTO DE PRUEBA COVID";
                dt.Columns[41].ColumnName = "DESCUENTO DE PAPELES";
                dt.Columns[42].ColumnName = "PRESTAMOS";
                dt.Columns[43].ColumnName = "DESCUENTO DE PERDIDA DE EQUIPO";
                dt.Columns[44].ColumnName = "Total Descuentos";
                dt.Columns[45].ColumnName = "Total A Cobrar";
                dt.Columns[46].ColumnName = "REINGRESOS NO AFECTOS";
                dt.Columns[47].ColumnName = "BONO / MOVILIDAD";
                dt.Columns[48].ColumnName = "BONO ARMADO";
                dt.Columns[49].ColumnName = "DIAS INAFECTOS PAGO";
                dt.Columns[50].ColumnName = "NETO A PAGAR";
                dt.Columns[51].ColumnName = "DNI EMPELADO";
                dt.Columns[52].ColumnName = "CUENTA";
                dt.Columns[53].ColumnName = "BANCO";
                // dt.Columns[54].ColumnName = "FECHA GENERADA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            planilla_completa_genral_personal(cod_empleado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cod_unidad = cbounidad.SelectedValue.ToString();
            int mes = Convert.ToInt32(txtmesunidad.Text);
            int anio = Convert.ToInt32(txtunidadanio.Text);
            planilla_completa_genral_unidad(cod_unidad, mes, anio);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int planilla = cboPlanilla.SelectedIndex;
            int ID_EMPRESA = cboEmpresa.SelectedIndex;
            int mes = Convert.ToInt32(txtmes.Text);
            int anio = Convert.ToInt32(txtanio.Text);
            if (planilla == 1)
            {
                planilla_quincena(mes, anio, ID_EMPRESA);
            }
            if (planilla == 2)
            {
                planilla_fin_mes(mes, anio, ID_EMPRESA);
            }
            if (planilla == 3)
            {
                planilla_completa(mes, anio, ID_EMPRESA);
            }
        }
        private void CargarHistorialPlanilla()
        {
            cboPlanilla.Items.Insert(0, "Seleccione una Planilla");
            cboPlanilla.Items.Insert(1, "Primera Quincena");
            cboPlanilla.Items.Insert(2, "Segunda Quincena");
            cboPlanilla.Items.Insert(3, "Planilla Completa");
            cboPlanilla.SelectedIndex = 0;
        }

        private void frmHistorialPlanillaDiasLaborados_Load(object sender, EventArgs e)
        {
            CargarHistorialPlanilla();
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerUnidadPlanillas(cbounidad);
            Llenadocbo.ObtenerEmpresaPLANILLA(cboEmpresa);
            dgvHistorialPlanilla.RowHeadersVisible = false;
            dgvHistorialPlanilla.AllowUserToAddRows = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Historial de Planilla";
            const string mensaje = "Estas seguro que deseas cerra el Historial de Planilla";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarraPlanilla(dgvHistorialPlanilla, progressBar1);
        }
    }
}
