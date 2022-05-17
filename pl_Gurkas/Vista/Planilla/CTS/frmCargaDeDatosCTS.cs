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

namespace pl_Gurkas.Vista.Planilla.CTS
{
    public partial class frmCargaDeDatosCTS : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmCargaDeDatosCTS()
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
        private void frmCargaDeDatosCTS_Load(object sender, EventArgs e)
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
                SqlCommand comando = new SqlCommand("sp_insertar_cts_datos", conexion.conexionBD());
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["FECHA_INGRESO_A_PLANILLA"].Value != null &&
                        row.Cells["TIEMPO_COMPUTABLE_POR_MESES"].Value != null &&
                        row.Cells["POR_DIAS"].Value != null && row.Cells["FALTAS_INJUSTI"].Value != null &&
                        row.Cells["COD_TRABAJADR"].Value != null && row.Cells["1_6_GRATI"].Value != null )
                    {
                        comando.Parameters.Clear();
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@fecha_ingreso", SqlDbType.VarChar).Value = row.Cells["FECHA_INGRESO_A_PLANILLA"].Value;
                        comando.Parameters.AddWithValue("@tiempo_computa", SqlDbType.Int).Value = row.Cells["TIEMPO_COMPUTABLE_POR_MESES"].Value;
                        comando.Parameters.AddWithValue("@por_dias", SqlDbType.Int).Value = row.Cells["POR_DIAS"].Value;
                        comando.Parameters.AddWithValue("@falta", SqlDbType.Int).Value = row.Cells["FALTAS_INJUSTI"].Value;
                        comando.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = row.Cells["COD_TRABAJADR"].Value;
                        comando.Parameters.AddWithValue("@grati_1_6", SqlDbType.Decimal).Value = row.Cells["1_6_GRATI"].Value;
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Datos registrado correptamente \n Registrado Exitosamente "
                   , "Correpto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
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
    }
}
