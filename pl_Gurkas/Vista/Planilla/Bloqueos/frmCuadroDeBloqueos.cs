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

namespace pl_Gurkas.Vista.Planilla.Bloqueos
{
    public partial class frmCuadroDeBloqueos : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        public frmCuadroDeBloqueos()
        {
            InitializeComponent();
        }

        private void frmCuadroDeBloqueos_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnverificar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_VISTA_BLOQUEOS_TEMPORALES  ";
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "UNIDAD";
                dt.Columns[2].ColumnName = "AGENTE";
                dt.Columns[3].ColumnName = "MARCACION";
                dt.Columns[4].ColumnName = "FECHA";
                dt.Columns[5].ColumnName = "TURNO";
                dt.Columns[6].ColumnName = "< DE 3 MESES";
                dt.Columns[7].ColumnName = "> DE 3 MESES";
                dt.AcceptChanges();
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int mes = Convert.ToInt32(txtMes.Text);
            int anio = Convert.ToInt32(txtAnio.Text);
            try
            {
                SqlCommand comando = new SqlCommand("sp_guardar_bloqueos @cod_personal, @unidad, @nombre_completo, @marcacion, @fecha_baja,@turno,@menor_tres_meses,@mayor_tres_meses,@mes,@anio,@nombre_guardado", conexion.conexionBD());
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@cod_personal", Convert.ToString(row.Cells["Cod Empleado"].Value));
                        comando.Parameters.AddWithValue("@unidad", Convert.ToString(row.Cells["UNIDAD"].Value));
                        comando.Parameters.AddWithValue("@nombre_completo", Convert.ToString(row.Cells["AGENTE"].Value));
                        comando.Parameters.AddWithValue("@marcacion", Convert.ToString(row.Cells["MARCACION"].Value));
                        comando.Parameters.AddWithValue("@fecha_baja", Convert.ToString(row.Cells["FECHA"].Value));
                        comando.Parameters.AddWithValue("@turno", Convert.ToString(row.Cells["TURNO"].Value));
                        comando.Parameters.AddWithValue("@menor_tres_meses", Convert.ToString(row.Cells["< DE 3 MESES"].Value));
                        comando.Parameters.AddWithValue("@mayor_tres_meses", Convert.ToString(row.Cells["> DE 3 MESES"].Value));
                        comando.Parameters.AddWithValue("@mes", SqlDbType.Int).Value = mes;
                        comando.Parameters.AddWithValue("@anio", SqlDbType.Int).Value = anio;
                        comando.Parameters.AddWithValue("@nombre_guardado", SqlDbType.VarChar).Value = nombre;

                    comando.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Datos registrado correptamente");
                //limpiar datos del datagriview 
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.Clear();
                // obtenerip_nombre();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" No se pudo realizar el guardado del la asistencia del personal \n\n Verifique su conexion al Servidor" + ex, "Error");
            }
        }
    }
}
