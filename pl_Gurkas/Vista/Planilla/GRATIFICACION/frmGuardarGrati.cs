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

namespace pl_Gurkas.Vista.Planilla.GRATIFICACION
{
    public partial class frmGuardarGrati : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmGuardarGrati()
        {
            InitializeComponent();
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

        private void frmGuardarGrati_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            const string titulo = "Guardar Datos en el Sistema";
            const string mensaje = "Porfavor verificar antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICACION DE DATOS";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = new SqlCommand("sp_insertar_gratificaion_datos", conexion.conexionBD());
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["FECHA_INGRESO_PLANILLA"].Value != null &&
                        row.Cells["MES"].Value != null &&
                        row.Cells["DIAS_NO_LABORADOS"].Value != null && row.Cells["cod_empleado"].Value != null &&
                        row.Cells["PROM_DIURNA_NOCT"].Value != null && row.Cells["MOVILIDAD"].Value != null
                        && row.Cells["PROM_FERIADO"].Value != null && row.Cells["DESCUENTOS_RTENCION_ALIMENTOS"].Value != null)
                    {
                        comando.Parameters.Clear();
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FECHA_INGRESO_PLANILLA", SqlDbType.VarChar).Value = row.Cells["FECHA_INGRESO_PLANILLA"].Value;
                        comando.Parameters.AddWithValue("@MES", SqlDbType.Int).Value = row.Cells["MES"].Value;
                        comando.Parameters.AddWithValue("@DIAS_NO_LABORADOS", SqlDbType.Int).Value = row.Cells["DIAS_NO_LABORADOS"].Value;
                        comando.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = row.Cells["cod_empleado"].Value;
                        comando.Parameters.AddWithValue("@PROM_DIURNA_NOCT", SqlDbType.Decimal).Value = row.Cells["PROM_DIURNA_NOCT"].Value;
                        comando.Parameters.AddWithValue("@MOVILIDAD", SqlDbType.Decimal).Value = row.Cells["MOVILIDAD"].Value;
                        comando.Parameters.AddWithValue("@PROM_FERIADO", SqlDbType.Decimal).Value = row.Cells["PROM_FERIADO"].Value;
                        comando.Parameters.AddWithValue("@DESCUENTOS_RTENCION_ALIMENTOS", SqlDbType.Decimal).Value = row.Cells["DESCUENTOS_RTENCION_ALIMENTOS"].Value;
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Datos registrado correptamente \n Registrado Exitosamente "
                   , "Correpto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }
    }
}
