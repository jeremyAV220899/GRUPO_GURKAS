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

namespace pl_Gurkas.Vista.Andorid
{
    public partial class frmAsistenciAndroid : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmAsistenciAndroid()
        {
            InitializeComponent();
        }

        private void CargarNumeroDeHijo()
        {
            cboTipoDaros.Items.Insert(0, "No tiene");
            cboTipoDaros.Items.Insert(1, "Insertar Asistencia");
            cboTipoDaros.Items.Insert(2, "Actualizar Asistencia");
            cboTipoDaros.SelectedIndex = 0;
        }

        public void ExportarDatosBarraPlanillaPlame(DataGridView dgView, string anio)
        {
            var resultado = folderBrowserDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {

                using (var writetext = new StreamWriter(folderBrowserDialog1.SelectedPath + "\\" + anio + ".sql"))
                {
                    foreach (DataGridViewRow row in dgView.Rows)
                    {
                        writetext.WriteLine($"{row.Cells[0].Value}");
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string anio = txtanio.Text;
            int order = cboTipoDaros.SelectedIndex;
            if (order == 1)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_insertar_android_fechas   @fi,  @ff";
                comando.Parameters.AddWithValue("fi", dtpFechaInicio.Value);
                comando.Parameters.AddWithValue("ff", dtpFechaFin.Value);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "datos";
                dt.AcceptChanges();
                dgvPlameArchivo.DataSource = dt;
                ExportarDatosBarraPlanillaPlame(dgvPlameArchivo, anio);
            }
            if (order == 2)
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_actualizar_android_fechas   @fi,  @ff";
                comando.Parameters.AddWithValue("fi", dtpFechaInicio.Value);
                comando.Parameters.AddWithValue("ff", dtpFechaFin.Value);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "datos";
                dt.AcceptChanges();
                dgvPlameArchivo.DataSource = dt;
                ExportarDatosBarraPlanillaPlame(dgvPlameArchivo, anio);
            }
           

            // txtmes.Enabled = false;
            // txtanio.Enabled = false;
           SqlCommand comando_2 = conexion.conexionBD().CreateCommand();
           comando_2.CommandType = CommandType.Text;
           comando_2.CommandText = "sp_eliminar_android";
           comando_2.ExecuteNonQuery();

            MessageBox.Show("Se genero exitosamente el archivo", "Completo");
        }

        private void frmAsistenciAndroid_Load(object sender, EventArgs e)
        {
            CargarNumeroDeHijo();
            dgvPlameArchivo.RowHeadersVisible = false;
            dgvPlameArchivo.AllowUserToAddRows = false;
            dgvPlameArchivo.Visible = false;
        }

    }
}
