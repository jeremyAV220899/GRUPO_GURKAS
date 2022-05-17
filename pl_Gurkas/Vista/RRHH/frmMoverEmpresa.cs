using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.RRHH
{
    public partial class frmMoverEmpresa : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();

        public frmMoverEmpresa()
        {
            InitializeComponent();
        }

        private void frmMoverEmpresa_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalRRHHGeneral(cboempleadoActivo);
            Llenadocbo.ObtenerEmpresaRRHHGeneral(cboEmpresa);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro";
            const string mensaje = "Estas seguro que deseas cerra el Registro de actualizacion de Empresa Personal";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                //  DateTime fecha = DateTime.Now;
                //  obtenerip_nombre();
                // string username = Code.nivelUser._nombre;
                // string detalle = "Cerrar Registro de Personal";
                // string cod_buscado = "Cerro el registro de Personal";
                // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                this.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            int empresa = cboEmpresa.SelectedIndex;

            actualizar.ActualizarEmpresa(cod_empleado, empresa);

            MessageBox.Show("Datos actualizado correptamente", "Correpto");
        }
    }
}
