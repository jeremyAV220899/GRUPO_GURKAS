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

namespace pl_Gurkas.Vista.CentroControl.CargaDeDatos
{
    public partial class frmBloqueosPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmBloqueosPersonal()
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
        private void frmBloqueosPersonal_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = true;
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
                SqlCommand comando = new SqlCommand("sp_insertar_bloqueos_personal @param1, @param2, @param3, @param4, @param5,@param6,@param7,@param8", conexion.conexionBD());
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["CODIGO"].Value != null && row.Cells["UNIDAD"].Value != null &&
                        row.Cells["AGENTE"].Value != null && row.Cells["MARCACION"].Value != null &&
                        row.Cells["FECHA"].Value != null && row.Cells["TURNO"].Value != null &&
                        row.Cells["< DE 3 MESES"].Value != null && row.Cells[">  DE 3 MESES"].Value != null)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@param1", Convert.ToString(row.Cells["CODIGO"].Value));
                        comando.Parameters.AddWithValue("@param2", Convert.ToString(row.Cells["UNIDAD"].Value));
                        comando.Parameters.AddWithValue("@param3", Convert.ToString(row.Cells["AGENTE"].Value));
                        comando.Parameters.AddWithValue("@param4", Convert.ToString(row.Cells["MARCACION"].Value));
                        comando.Parameters.AddWithValue("@param5", Convert.ToString(row.Cells["FECHA"].Value));
                        comando.Parameters.AddWithValue("@param6", Convert.ToString(row.Cells["TURNO"].Value));
                        comando.Parameters.AddWithValue("@param7", Convert.ToString(row.Cells["< DE 3 MESES"].Value));
                        comando.Parameters.AddWithValue("@param8", Convert.ToString(row.Cells[">  DE 3 MESES"].Value));
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Datos registrado correptamente \n Registrado Exitosamente "
                   , "Correpto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string titulo = "Eliminar";
            const string mensaje = "Estas seguro que deseas Eliminar los Bloqueos subido anteriormente";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_eliminar_bloqueos";
                comando.ExecuteNonQuery();
                MessageBox.Show("Se elimino correctamente", "Exitoso");
            }
        }
    }
}
