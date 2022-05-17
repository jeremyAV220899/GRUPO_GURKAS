using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Planilla.Plame
{
    public partial class frmPlataformaPlame : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();

        public frmPlataformaPlame()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Planilla";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Planilla";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_plame_antes_salir_eliminartemp";
                comando.ExecuteNonQuery();
                this.Close();
            }
        }

        private void frmPlataformaPlame_Load(object sender, EventArgs e)
        {
            int empresa = Datos.EmpresaID._empresaid;
            if (empresa == 1)
            {
                txtruc.Text = "20546468101";
                txtruchora.Text = "20546468101";
            }
            if (empresa == 2) {
                txtruc.Text = "20603200587";
                txtruchora.Text = "20603200587";
            }
            //LLenadoCombo.ObtenerPersonal(cboempleadoActivo);
            dgvPlame.RowHeadersVisible = false;
            dgvPlame.AllowUserToAddRows = false;
            dgvPlameArchivo.RowHeadersVisible = false;
            dgvPlameArchivo.AllowUserToAddRows = false;
            dgvPlameArchivo.Visible = false;
        }
        public void ExportarDatosBarraPlanillaPlame(DataGridView dgView, string anio, string mes, string ruc)
        {
            var resultado = folderBrowserDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {

                using (var writetext = new StreamWriter(folderBrowserDialog1.SelectedPath + "\\0601" + anio + mes + ruc + ".rem"))
                {
                    foreach (DataGridViewRow row in dgView.Rows)
                    {
                        writetext.WriteLine($"{row.Cells[0].Value}");
                    }
                }
            }
        }
        public void ExportarDatosBarraPlanillaPlameHoras(DataGridView dgView, string anio, string mes, string ruc)
        {
            var resultado = folderBrowserDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {

                using (var writetext = new StreamWriter(folderBrowserDialog1.SelectedPath + "\\0601" + anio + mes + ruc + ".jor"))
                {
                    foreach (DataGridViewRow row in dgView.Rows)
                    {
                        writetext.WriteLine($"{row.Cells[0].Value}");
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(txtm.Text);
            int anio = Convert.ToInt32(txta.Text);
            int empresa = Datos.EmpresaID._empresaid;
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_antes_plame_empleado_buscar  @anio,@mes,@empresa";
                comando.Parameters.AddWithValue("anio", anio);
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod AVP";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Tipo Documento";
                dt.Columns[3].ColumnName = "Num Documento";
                dt.Columns[4].ColumnName = "REMUNERACIÓN O JORNAL BÁSICO - 0121";
                dt.Columns[5].ColumnName = "TRABAJO SOBRETIEMPO (H. EXTRAS 25%) - 0105";
                dt.Columns[6].ColumnName = "TRABAJO SOBRETIEMPO (H. EXTRAS 35%) - 0106";
                dt.Columns[7].ColumnName = "TRABAJO EN FERIADO O DÍA DESCANSO - 0107";
                dt.Columns[8].ColumnName = "ASIGNACIÓN FAMILIAR - 0201";
                dt.Columns[9].ColumnName = "BONIFICACION - 1011";
                dt.Columns[10].ColumnName = "REINTEGROS INAFECTOS APORTACIONES - 1008";
                dt.Columns[11].ColumnName = "MOV SUPEDIT A ASIST CUBRE TRASLADO - 0909";
                dt.Columns[12].ColumnName = "MOV SUPEDIT A ASIST CUBRE TRASLADO - DIAS INAFECTO - 0909";
                dt.Columns[13].ColumnName = "BONO DE PRODUCTIVIDAD - 0902";
                dt.Columns[14].ColumnName = "REINTEGROS - 1006";
                dt.Columns[15].ColumnName = "ADELANTO - 0701";
                dt.Columns[16].ColumnName = "TARDANZAS - 0704";
                dt.Columns[17].ColumnName = "OTROS DESC NO DEDUC DE BASE IMPONIB - 0706";
                dt.Columns[18].ColumnName = "RENTA DE 5TA - 0605";
                dt.Columns[19].ColumnName = "DESC. AUTORIZADO MANDATO JUDICIAL - 0703";
                dt.Columns[20].ColumnName = "APORTE OBLIGATORIA AFP - 0608";
                dt.Columns[21].ColumnName = "COMISION AFP - 0601";
                dt.Columns[22].ColumnName = "PRIMA SEGURO - 0606";
                dt.Columns[23].ColumnName = "SISTEMA NAC. DE PENSIONES DL 19990 - 0607";
                dt.Columns[24].ColumnName = "REMUNERACIÓN VACACIONAL - 0118";
                dt.Columns[25].ColumnName = "SUBSIDIO INCAPACIDAD POR ENFERMEDAD - 0916";
                dt.Columns[26].ColumnName = "ASIGNACIÓN POR NACIMIENTO DE HIJOS - 0205";
                dt.Columns[27].ColumnName = "ASIGNACIÓN FALLECIMIENTO FAMILIARES - 0206";
                dt.Columns[28].ColumnName = "SUBSIDIOS POR MATERNIDAD - 0915";
                dt.AcceptChanges();
                dgvPlame.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string anio = txtanio.Text;
            string mes = txtmes.Text;
            string ruc = txtruc.Text;
            int empresa = Datos.EmpresaID._empresaid; 
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_generar_plame_plago  @anio, @mes,  @ruc,@empresa";
            comando.Parameters.AddWithValue("anio", anio);
            comando.Parameters.AddWithValue("mes", mes);
            comando.Parameters.AddWithValue("ruc", ruc);
            comando.Parameters.AddWithValue("empresa", empresa);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(comando);
            dta.Fill(dt);
            dt.Columns[0].ColumnName = "plame";
            dt.AcceptChanges();
            dgvPlameArchivo.DataSource = dt;
            ExportarDatosBarraPlanillaPlame(dgvPlameArchivo, anio, mes, ruc);

            // txtmes.Enabled = false;
            // txtanio.Enabled = false;
            SqlCommand comando_2 = conexion.conexionBD().CreateCommand();
            comando_2.CommandType = CommandType.Text;
            comando_2.CommandText = "sp_plame_antes_salir_eliminartemp";
            comando_2.ExecuteNonQuery();

            MessageBox.Show("Se genero exitosamente el archivo", "Completo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string anio = txtaniohora.Text;
            string mes = txtmeshora.Text;
            string ruc = txtruchora.Text;
            int empresa = Datos.EmpresaID._empresaid;
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_generar_plame_plago_horas_plamet  @anio, @mes,  @ruc,@empresa";
            comando.Parameters.AddWithValue("anio", anio);
            comando.Parameters.AddWithValue("mes", mes);
            comando.Parameters.AddWithValue("ruc", ruc);
            comando.Parameters.AddWithValue("empresa", empresa);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(comando);
            dta.Fill(dt);
            dt.Columns[0].ColumnName = "plame";
            dt.AcceptChanges();
            dgvPlameArchivo.DataSource = dt;
            ExportarDatosBarraPlanillaPlameHoras(dgvPlameArchivo, anio, mes, ruc);

            // txtmes.Enabled = false;
            // txtanio.Enabled = false;
            SqlCommand comando_2 = conexion.conexionBD().CreateCommand();
            comando_2.CommandType = CommandType.Text;
            comando_2.CommandText = "sp_plame_antes_salir_eliminartemp";
            comando_2.ExecuteNonQuery();

            MessageBox.Show("Se genero exitosamente el archivo", "Completo");
        }
    }
}
