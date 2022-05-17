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
    public partial class frmPersonalPorEmpresa : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatos Llenadocbo = new Datos.LlenadoDeDatos();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        public frmPersonalPorEmpresa()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaCodigo(int CodEmpresa)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHHEmpresaPersonal  @Cod_empresa";
                comando.Parameters.AddWithValue("Cod_empresa", CodEmpresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.AcceptChanges();
                dgvPersonalEmpresa.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void frmPersonalPorEmpresa_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerEmpresa(cboEmpresa);
            dgvPersonalEmpresa.RowHeadersVisible = false;
            dgvPersonalEmpresa.AllowUserToAddRows = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvPersonalEmpresa, progressBar1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int cod_empresa = cboEmpresa.SelectedIndex;
            ConsultarAsistenciaCodigo(cod_empresa);
        }
    }
}
