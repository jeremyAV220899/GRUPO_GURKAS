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

namespace pl_Gurkas.Vista.Planilla.ReportePlanilla
{
    public partial class frmHistorialDatosEmpleado : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Vista.Planilla.ExportacionExcelPlanilla.ExcelPlanilla ExcelPlanilla = new ExportacionExcelPlanilla.ExcelPlanilla();
        public frmHistorialDatosEmpleado()
        {
            InitializeComponent();
        }

        private void frmHistorialDatosEmpleado_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            dgvSueldos.RowHeadersVisible = false;
            dgvSueldos.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_historial_sueldo  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Sueldo Basico";
                dt.Columns[3].ColumnName = "Sueldo Bruto";
                dt.Columns[4].ColumnName = "Fecha Inicio Sueldo";
                dt.Columns[5].ColumnName = "Fecha Inicio Fin";
                dt.Columns[6].ColumnName = "Bono Armado";
                dt.Columns[7].ColumnName = "Bonificacion";
                dt.Columns[8].ColumnName = "Movilidad";
                dt.Columns[9].ColumnName = "Banco";
                dt.Columns[10].ColumnName = "Cuenta";
                dt.Columns[11].ColumnName = "Asignacion Familiar";
                dt.Columns[12].ColumnName = "Bono Feriado";
                dt.Columns[13].ColumnName = "Regimen Pensionario";
                dt.Columns[14].ColumnName = "AFP CUPSS";
                dt.Columns[15].ColumnName = "Tipo Comision";
                dt.Columns[16].ColumnName = "Movimiento AFP";
                dt.Columns[17].ColumnName = "AFP/ONP";

                dt.AcceptChanges();
                dgvSueldos.DataSource = dt;
            }
            catch (Exception err)
            {
                try
                {
                    MessageBox.Show("Debe ingresar un codigo De Empleado" + err);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO SP_BUCARPERSONAL \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
