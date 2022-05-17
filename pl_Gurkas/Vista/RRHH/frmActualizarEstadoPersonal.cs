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
    public partial class frmActualizarEstadoPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        public frmActualizarEstadoPersonal()
        {
            InitializeComponent();
        }

        private void frmActualizarEstadoPersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalRRHH(cboempleadoActivo);
            Llenadocbo.ObtenerEstadoPersonalRRHH(cboEstadoEmp);
            Llenadocbo.ObtenerEstadoPermiteMarcacion(cboEstadoPersonalTareaje);
        }

        private void cboempleadoActivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codEmpleado = cboempleadoActivo.SelectedValue.ToString();

                SqlCommand comando = new SqlCommand("SELECT * FROM v_actualizar_Estado_personal WHERE Cod_empleado = '" + codEmpleado + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    cboEstadoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_PERSONAL"].ToString());
                    cboEstadoPersonalTareaje.SelectedIndex = Convert.ToInt32(recorre["cod_estado_personal"].ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            string codEmpleado = cboempleadoActivo.SelectedValue.ToString();
            int estado_personal_RRHH = cboEstadoEmp.SelectedIndex;
            int estado_tareaje = cboEstadoPersonalTareaje.SelectedIndex;
            try
            {
                actualizar.ActualizarEstadoPerosnal(codEmpleado, estado_personal_RRHH, estado_tareaje);
                MessageBox.Show("Datos Actualizado Exitosamente", "Registrado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se puede Actualizado los datos del personal " + ex, "ERROR");
            }
        }
    }
}
