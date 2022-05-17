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

namespace pl_Gurkas.Vista.Planilla.SueldoEmpleado
{
    public partial class frmSueldoEmpleado : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();

        public frmSueldoEmpleado()
        {
            InitializeComponent();
        }

        private void frmSueldoEmpleado_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadPlanillas(cboUnidad);
            Llenadocbo.ObtenerPuestolPlanilla(cboPuesto);
            txtid.Visible = false;
        }

        private void buscar_puesto(string cod_unidad , int cod_puesto)
        {
            SqlCommand comando = new SqlCommand("select * from t_unidad_puesto_sueldo WHERE cod_unidad = '" + cod_unidad + "' and id_puesto_empleado ="+cod_puesto, conexion.conexionBD());

            SqlDataReader recorre = comando.ExecuteReader();
            while (recorre.Read())
            {
                txtrmv.Text = recorre["MV"].ToString();
                txtsueldo.Text = recorre["sueldo"].ToString();
                txtid.Text = recorre["id_unidad_puesto_sueldo"].ToString();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_Unidad = cboUnidad.SelectedValue.ToString();
            int cod_puesto = cboPuesto.SelectedIndex;
            buscar_puesto(cod_Unidad, cod_puesto);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_Unidad = cboUnidad.SelectedValue.ToString();
                int cod_puesto = cboPuesto.SelectedIndex;
                double rmv = Convert.ToDouble(txtrmv.Text);
                double sueldo = Convert.ToDouble(txtsueldo.Text);
                registrar.registrarSueldoUnidadPuesto(cod_Unidad, rmv, sueldo, cod_puesto);
                MessageBox.Show("Datos registrado Exitosamente", "Datos Registrados", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_Unidad = cboUnidad.SelectedValue.ToString();
                int cod_puesto = cboPuesto.SelectedIndex;
                double rmv = Convert.ToDouble(txtrmv.Text);
                double sueldo = Convert.ToDouble(txtsueldo.Text);
                int id = Convert.ToInt32(txtid.Text);
                actualizar.ActualizarSueldoUnidadPuesto(cod_Unidad, rmv, sueldo, cod_puesto, id);
                MessageBox.Show("Datos registrado Exitosamente", "Datos Registrados", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
