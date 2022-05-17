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
    public partial class frmPersonalPorEdad : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        public frmPersonalPorEdad()
        {
            InitializeComponent();
        }
        private void ConsultarAsistencia(int edadInicio, int EdadFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHHEdadConsulta  @edadInica, @edadFinal";
                comando.Parameters.AddWithValue("edadInica", edadInicio);
                comando.Parameters.AddWithValue("edadFinal", EdadFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Estado Empleado";
                dt.Columns[1].ColumnName = "Cod Empleado";
                dt.Columns[2].ColumnName = "Empleado";
                dt.Columns[3].ColumnName = "Num Identidad";
                dt.Columns[4].ColumnName = "Edad";
                dt.Columns[5].ColumnName = "Empresa";
                dt.Columns[6].ColumnName = "Fecha Nacimineto";
                dt.Columns[7].ColumnName = "Fecha Emision";
                dt.Columns[8].ColumnName = "Fecha Vencimiento";
                dt.Columns[9].ColumnName = "Sexo";
                dt.Columns[10].ColumnName = "Nacionalidad ";
                dt.Columns[11].ColumnName = "Departamento ";
                dt.Columns[12].ColumnName = "Provincia ";
                dt.Columns[13].ColumnName = "Distrito ";
                dt.Columns[14].ColumnName = "Direccion ";
                dt.Columns[15].ColumnName = "Telefono";
                dt.Columns[16].ColumnName = "Celular";
                dt.Columns[17].ColumnName = "Talla Prenda";
                dt.Columns[18].ColumnName = "Talla Pantalon";
                dt.Columns[19].ColumnName = "Calzado";
                dt.Columns[20].ColumnName = "Estatura";
                dt.Columns[21].ColumnName = "Correo";
                dt.Columns[22].ColumnName = "Grado Instruccion";
                dt.Columns[23].ColumnName = "Brevete";
                dt.Columns[24].ColumnName = "Numero Brevete";
                dt.Columns[25].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvEdadPersonal.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void frmPersonalPorEdad_Load(object sender, EventArgs e)
        {
            txtEdadInicio.MaxLength = 2;
            txtEdadFin.MaxLength = 2;
            dgvEdadPersonal.RowHeadersVisible = false;
            dgvEdadPersonal.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtEdadInicio.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Edad Inicial", "Advertencia");
            }
            else if (txtEdadFin.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Edad Final", "Advertencia");
            }
            else
            {
                int edadInicio = (int)Convert.ToInt64(txtEdadInicio.Text);
                int EdadFin = (int)Convert.ToInt64(txtEdadFin.Text);
                ConsultarAsistencia(edadInicio, EdadFin);
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvEdadPersonal, progressBar1);
        }
    }
}
