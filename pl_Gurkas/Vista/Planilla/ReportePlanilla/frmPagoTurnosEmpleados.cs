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
    public partial class frmPagoTurnosEmpleados : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmPagoTurnosEmpleados()
        {
            InitializeComponent();
        }
        private void CargarHistorialPlanilla()
        {
            cboPlanilla.Items.Insert(0, "Seleccione una Planilla");
            cboPlanilla.Items.Insert(1, "Primera Quincena");
            cboPlanilla.Items.Insert(2, "Segunda Quincena");
            cboPlanilla.Items.Insert(3, "Planilla Completa");
            cboPlanilla.SelectedIndex = 0;
        }
        private void planilla_quincena(int mes, int anio)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_turnos_planilla_quincena  @mes,@anio";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Unidad";
                dt.Columns[1].ColumnName = "Total de Turno";
                // dt.Columns[54].ColumnName = "FECHA GENERADA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_fin_mes(int mes, int anio)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_turnos_planilla_fin_mes  @mes,@anio";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Unidad";
                dt.Columns[1].ColumnName = "Total de Turno";
                // dt.Columns[54].ColumnName = "FECHA GENERADA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void planilla_completa(int mes, int anio)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_turnos_planilla_completa  @mes,@anio";
                comando.Parameters.AddWithValue("mes", mes);
                comando.Parameters.AddWithValue("anio", anio);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Unidad";
                dt.Columns[1].ColumnName = "Total de Turno";
                // dt.Columns[55].ColumnName = "FECHA GENERADA";
                dt.AcceptChanges();
                dgvHistorialPlanilla.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmPagoTurnosEmpleados_Load(object sender, EventArgs e)
        {
            CargarHistorialPlanilla();
            dgvHistorialPlanilla.RowHeadersVisible = false;
            dgvHistorialPlanilla.AllowUserToAddRows = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int planilla = cboPlanilla.SelectedIndex;
            int mes = Convert.ToInt32(txtmes.Text);
            int anio = Convert.ToInt32(txtanio.Text);
            if (planilla == 1)
            {
                planilla_quincena(mes, anio);
            }
            if (planilla == 2)
            {
                planilla_fin_mes(mes, anio);
            }
            if (planilla == 3)
            {
                planilla_completa(mes, anio);
            }
        }
    }
}
