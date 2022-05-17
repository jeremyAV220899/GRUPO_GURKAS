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

namespace pl_Gurkas.Vista.RRHH.CargaDatos
{
    public partial class frmCargaDatosIngresantesPlanillas : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmCargaDatosIngresantesPlanillas()
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
        private void frmCargaDatosIngresantesPlanillas_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
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
            const string titulo = "Guardar Datos en el Sistema";
            const string mensaje = "Porfavor verificar antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICACION DE DATOS";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = new SqlCommand("sp_insertar_ingresantes_planilla_rrhh", conexion.conexionBD());
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["APELLIDOS_NOMBRES"].Value != null &&
                        row.Cells["DNI_CEX"].Value != null  &&
                        row.Cells["BANCO"].Value != null && row.Cells["NUMERO_DE_CUENTA"].Value != null &&
                        row.Cells["AFP_ONP"].Value != null && row.Cells["CUSSP"].Value != null &&
                        row.Cells["COMISION"].Value != null && row.Cells["ASIGNACION_FAMILIAR"].Value != null)
                    {
                        comando.Parameters.Clear();
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@apellidos_nombres", SqlDbType.VarChar).Value = row.Cells["APELLIDOS_NOMBRES"].Value;
                        comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = row.Cells["DNI_CEX"].Value;
                        comando.Parameters.AddWithValue("@banco", SqlDbType.VarChar).Value = row.Cells["BANCO"].Value;
                        comando.Parameters.AddWithValue("@numero_cuenta", SqlDbType.VarChar).Value = row.Cells["NUMERO_DE_CUENTA"].Value;
                        comando.Parameters.AddWithValue("@afp_onp", SqlDbType.VarChar).Value = row.Cells["AFP_ONP"].Value;
                        comando.Parameters.AddWithValue("@CUSSP", SqlDbType.VarChar).Value = row.Cells["CUSSP"].Value;
                        comando.Parameters.AddWithValue("@comision", SqlDbType.VarChar).Value = row.Cells["COMISION"].Value;
                        comando.Parameters.AddWithValue("@asignacion_familiar", SqlDbType.VarChar).Value = row.Cells["ASIGNACION_FAMILIAR"].Value;
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Datos registrado correptamente \n Registrado Exitosamente "
                   , "Correpto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }
    }
}
