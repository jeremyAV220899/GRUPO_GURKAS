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

namespace pl_Gurkas.Vista.RRHH.ReportesRRHH
{
    public partial class frmPersonalPorUnidad : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        public frmPersonalPorUnidad()
        {
            InitializeComponent();
        }
        private void ConsultarPersonalUnidad(string unidad)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_PERSONALunidad  @cod_unidad";

                comando.Parameters.AddWithValue("cod_unidad", unidad);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio";
                dt.AcceptChanges();
                dgvPersonalPorSede.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void frmPersonalPorUnidad_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadRRHH(cboUnidad);
            dgvPersonalPorSede.RowHeadersVisible = false;
            dgvPersonalPorSede.AllowUserToAddRows = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvPersonalPorSede, progressBar1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string undiad = cboUnidad.SelectedValue.ToString();
            ConsultarPersonalUnidad(undiad);
        }
    }
}
