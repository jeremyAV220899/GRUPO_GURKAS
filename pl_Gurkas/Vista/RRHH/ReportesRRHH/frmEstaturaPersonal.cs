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
    public partial class frmEstaturaPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        public frmEstaturaPersonal()
        {
            InitializeComponent();
        }
        private void ConsultaEstaturas(decimal estaturaInicio, decimal estaturaFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_ESTATURAPersonal  @estaturainicial, @estaturafinal";
                comando.Parameters.AddWithValue("estaturainicial", estaturaInicio);
                comando.Parameters.AddWithValue("estaturafinal", estaturaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Emision";
                dt.Columns[6].ColumnName = "Fecha Vencimiento";
                dt.Columns[7].ColumnName = "Sexo";
                dt.Columns[8].ColumnName = "Nacionalidad ";
                dt.Columns[9].ColumnName = "Departamento ";
                dt.Columns[10].ColumnName = "Provincia ";
                dt.Columns[11].ColumnName = "Distrito ";
                dt.Columns[12].ColumnName = "Direccion ";
                dt.Columns[13].ColumnName = "Telefono";
                dt.Columns[14].ColumnName = "Celular";
                dt.Columns[15].ColumnName = "Talla Prenda";
                dt.Columns[16].ColumnName = "Talla Pantalon";
                dt.Columns[17].ColumnName = "Calzado";
                dt.Columns[18].ColumnName = "Estatura";
                dt.Columns[19].ColumnName = "Correo";
                dt.Columns[20].ColumnName = "Grado Instruccion";
                dt.Columns[21].ColumnName = "Brevete";
                dt.Columns[22].ColumnName = "Numero Brevete";
                dt.Columns[23].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvPersonalEstatura.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void frmEstaturaPersonal_Load(object sender, EventArgs e)
        {
            dgvPersonalEstatura.RowHeadersVisible = false;
            dgvPersonalEstatura.AllowUserToAddRows = false;
        }

        private void txtEstaturaInicial_TextChanged(object sender, EventArgs e)
        {
            txtEstaturaInicial.MaxLength = 4;
        }

        private void txtEstaturaFin_TextChanged(object sender, EventArgs e)
        {
            txtEstaturaFin.MaxLength = 4;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvPersonalEstatura, progressBar1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtEstaturaInicial.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Estatura Inicial", "Advertencia");
            }
            else if (txtEstaturaFin.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Estatura Final", "Advertencia");
            }
            else
            {
                decimal estaturaInicio = Convert.ToDecimal(txtEstaturaInicial.Text);
                decimal estaturaFin = Convert.ToDecimal(txtEstaturaFin.Text);
                ConsultaEstaturas(estaturaInicio, estaturaFin);
            }
        }
    }
}
