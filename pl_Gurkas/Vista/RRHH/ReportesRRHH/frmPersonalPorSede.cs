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
    public partial class frmPersonalPorSede : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        public frmPersonalPorSede()
        {
            InitializeComponent();
        }
        private void ConsultarPersonalSede(string sede)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_PERSONALSEDE  @cod_sede";

                comando.Parameters.AddWithValue("cod_sede", sede);
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

        private void llenado_combo()
        {
            Llenadocbo.ObtenerUnidadRRHH(cboUnidad);
        }
        private void frmPersonalPorSede_Load(object sender, EventArgs e)
        {
            llenado_combo();
            dgvPersonalPorSede.RowHeadersVisible = false;
            dgvPersonalPorSede.AllowUserToAddRows = false;
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeRRHH(cboSede, cod_unidad);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string Sede = cboSede.SelectedValue.ToString();
            ConsultarPersonalSede(Sede);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvPersonalPorSede, progressBar1);
        }
    }
}
