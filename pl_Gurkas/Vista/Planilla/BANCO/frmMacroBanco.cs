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

namespace pl_Gurkas.Vista.Planilla.BANCO
{
    public partial class frmMacroBanco : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla Excel = new Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla();

        public frmMacroBanco()
        {
            InitializeComponent();
        }

        private void frmMacroBanco_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerBancoPLANILLAS(cboBanco);
            dgvBancoExcel.Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Salir";
            const string mensaje = "Estas seguro que deseas cerra";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGenerarMacros_Click(object sender, EventArgs e)
        {
            int cod_banco = cboBanco.SelectedIndex;
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_banco_excel  @Cod_Banco";
            comando.Parameters.AddWithValue("Cod_Banco", cod_banco);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(comando);
            dta.Fill(dt);
            dt.AcceptChanges();
            dgvBancoExcel.DataSource = dt;
            MessageBox.Show("Exito", "Listo para la Exportacion");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvBancoExcel, progressBar1);
        }
    }
}
