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

namespace pl_Gurkas.Vista.Comercial.ReporteComercial
{
    public partial class frmDetalleEmpleado : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatosComercial Llenadocbo = new Datos.LlenadoDeDatosComercial();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public frmDetalleEmpleado()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaCodigo(int CodEmpresa)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_comercial_detalle_empleado  @Cod_empresa";
                comando.Parameters.AddWithValue("Cod_empresa", CodEmpresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Apellido Paterno";
                dt.Columns[2].ColumnName = "Apellido Materno";
                dt.Columns[3].ColumnName = "Nombres";
                dt.Columns[4].ColumnName = "Tipo Documento";
                dt.Columns[5].ColumnName = "Num Identidad";
                dt.Columns[6].ColumnName = "Fecha Nacimineto";
                dt.Columns[7].ColumnName = "Fecha Inicio de Contrato";
                dt.Columns[8].ColumnName = "Edad";
                dt.Columns[9].ColumnName = "Sueldo Basico";
                dt.Columns[10].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvDetalle.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
        private void frmDetalleEmpleado_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerEmpresaComercial(cboEmpresa);
            Llenadocbo.ObtenerPersonalComercial(cboempleadoActivo);
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AllowUserToAddRows = false;
        }

        private void btnConsultarPersonalEmpresa_Click(object sender, EventArgs e)
        {
            int cod_empresa = cboEmpresa.SelectedIndex;
            ConsultarAsistenciaCodigo(cod_empresa);

            modulo.auditoriaFunciones("Comercial", "Buscar del personal por empresa", "Busqueda de la personal de la empresa : " + cod_empresa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_comercial_detalle_empleado_cod  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Apellido Paterno";
                dt.Columns[2].ColumnName = "Apellido Materno";
                dt.Columns[3].ColumnName = "Nombres";
                dt.Columns[4].ColumnName = "Tipo Documento";
                dt.Columns[5].ColumnName = "Num Identidad";
                dt.Columns[6].ColumnName = "Fecha Nacimineto";
                dt.Columns[7].ColumnName = "Fecha Inicio de Contrato";
                dt.Columns[8].ColumnName = "Edad";
                dt.Columns[9].ColumnName = "Sueldo Basico";
                dt.Columns[10].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvDetalle.DataSource = dt;


                modulo.auditoriaFunciones("Comercial", "Busqueda de personal ", "Busqueda del personal  : " + cod_empleado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            modulo.auditoriaFunciones("Comercial", "Exel", "Generar excel : " + cod_empleado);
        }
    }
}
