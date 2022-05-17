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

namespace pl_Gurkas.Vista.Planilla.CargaDeDatos
{
    public partial class frmCargaDeDatosAsistencia : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmCargaDeDatosAsistencia()
        {
            InitializeComponent();
        }
        public static string registrado;
        public static string noregistrado;
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
        private void frmCargaDeDatosAsistencia_Load(object sender, EventArgs e)
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
                SqlCommand comando = new SqlCommand("sp_subir_planillas_descuentos @param1, @param2, @param3, @param4, @param5,@param6,@param7,@param8,@param9,@param10,@param11,@param12,@param13,@param14,@param15", conexion.conexionBD());
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Cod Empleado"].Value != null && row.Cells["Empleado"].Value != null &&
                        row.Cells["ASISTENCIA"].Value != null && row.Cells["DESCANSO"].Value != null &&
                        row.Cells["DESCANSO TRABAJADO"].Value != null && row.Cells["DESCANSO MEDICO"].Value != null &&
                        row.Cells["FALTA"].Value != null && row.Cells["FERIADO"].Value != null &&
                        row.Cells["LICENCIA"].Value != null && row.Cells["PERMISO"].Value != null &&
                        row.Cells["RENGANCHE"].Value != null && row.Cells["SUSPENCION"].Value != null &&
                        row.Cells["TARDANZA"].Value != null && row.Cells["VACACIONES"].Value != null &&
                        row.Cells["TOTAL"].Value != null)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@param1", Convert.ToString(row.Cells["Cod Empleado"].Value));
                        comando.Parameters.AddWithValue("@param2", Convert.ToString(row.Cells["Empleado"].Value));
                        comando.Parameters.AddWithValue("@param3", Convert.ToInt32(row.Cells["ASISTENCIA"].Value));
                        comando.Parameters.AddWithValue("@param4", Convert.ToInt32(row.Cells["DESCANSO"].Value));
                        comando.Parameters.AddWithValue("@param5", Convert.ToInt32(row.Cells["DESCANSO TRABAJADO"].Value));
                        comando.Parameters.AddWithValue("@param6", Convert.ToInt32(row.Cells["DESCANSO MEDICO"].Value));
                        comando.Parameters.AddWithValue("@param7", Convert.ToInt32(row.Cells["FALTA"].Value));
                        comando.Parameters.AddWithValue("@param8", Convert.ToInt32(row.Cells["FERIADO"].Value));
                        comando.Parameters.AddWithValue("@param9", Convert.ToInt32(row.Cells["LICENCIA"].Value));
                        comando.Parameters.AddWithValue("@param10", Convert.ToInt32(row.Cells["PERMISO"].Value));
                        comando.Parameters.AddWithValue("@param11", Convert.ToInt32(row.Cells["RENGANCHE"].Value));
                        comando.Parameters.AddWithValue("@param12", Convert.ToInt32(row.Cells["SUSPENCION"].Value));
                        comando.Parameters.AddWithValue("@param13", Convert.ToInt32(row.Cells["TARDANZA"].Value));
                        comando.Parameters.AddWithValue("@param14", Convert.ToInt32(row.Cells["VACACIONES"].Value));
                        comando.Parameters.AddWithValue("@param15", Convert.ToInt32(row.Cells["TOTAL"].Value));
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Datos registrado correptamente \n Registrado Exitosamente " 
                   , "Correpto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }
    }
}