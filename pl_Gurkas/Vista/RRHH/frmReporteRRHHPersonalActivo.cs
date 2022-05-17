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

namespace pl_Gurkas.Vista.RRHH
{
    public partial class frmReporteRRHHPersonalActivo : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        public frmReporteRRHHPersonalActivo()
        {
            InitializeComponent();
        }

        private void frmReporteRRHHPersonalActivo_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerEmpresaRRHHGeneral(cboEmpresa);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id_empresa = cboEmpresa.SelectedIndex;
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_personal_activo  @id_empresa";
                comando.Parameters.AddWithValue("id_empresa", id_empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Fecha Inicio Laboral";
                dt.Columns[3].ColumnName = "Fecha Nacimiento Empleado";
                dt.Columns[4].ColumnName = "Unidad";
                dt.Columns[5].ColumnName = "Turno";
                dt.Columns[6].ColumnName = "Puesto";
                dt.Columns[7].ColumnName = "Tipo Documento";
                dt.Columns[8].ColumnName = "Numero de Documento";
                dt.Columns[9].ColumnName = "Estado Personal";
                dt.Columns[10].ColumnName = "Empresa";
                dt.AcceptChanges();
                dgvRegistroPersonal.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvRegistroPersonal, progressBar1);
        }
    }
}
