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

namespace pl_Gurkas.Vista.Operaciones.ReporteOperaciones
{
    public partial class frmEstadoPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatosOperaciones Llenadocbo = new Datos.LlenadoDeDatosOperaciones();
        Vista.CentroControl.ExportacionExcelCC.ExcelCC Excel = new Vista.CentroControl.ExportacionExcelCC.ExcelCC();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public frmEstadoPersonal()
        {
            InitializeComponent();
        }

        private void frmEstadoPersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonaEstadolOperaciones(cboempleadoActivo);
            txtcodavp.Enabled = false;
            txtTurno.Enabled = false;
            txtunidad.Enabled = false;
            txtdocumento.Enabled = false;
        }

        private void btnBuscarAVP_Click(object sender, EventArgs e)
        {
            if (txtcodavp.Text.Length > 0)
            {
                txtcodavp.Text = "";
            }
            string dni_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = new SqlCommand("select * from v_estado_personal   WHERE COD_EMPLEADO = '" + dni_empleado + "'", conexion.conexionBD());
                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtcodavp.Text = recorre["DESCP_ESTADO_PERSONAL"].ToString();
                    txtTurno.Text = recorre["DESCP_TURNO"].ToString();
                    txtdocumento.Text = recorre["DOCT_IDENT"].ToString();
                    txtunidad.Text = recorre["RAZON_SOCIAL"].ToString();
                }

                modulo.auditoriaFunciones("Operaciones", "Buscar Estado Personal", "Busqueda del Estado Personal : " + dni_empleado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE ENCONTRO AL EMPLEADO VERIFIQUE EL CODIGO \n\n" + ex, "ERROR");

            }
        }
    }
}
