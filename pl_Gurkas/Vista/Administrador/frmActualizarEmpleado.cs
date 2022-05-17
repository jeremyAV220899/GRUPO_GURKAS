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

namespace pl_Gurkas.Vista.Administrador
{
    public partial class frmActualizarEmpleado : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatos Llenadocbo = new Datos.LlenadoDeDatos();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.registrar Registrar = new Datos.registrar();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        public frmActualizarEmpleado()
        {
            InitializeComponent();
        }
        private void BuscarAVP(string codAVP)
        {
            try
            {
                SqlCommand comando = new SqlCommand("select * from T_USUARIO   WHERE cod_empleado = '" + codAVP + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtNombreEmp.Text = recorre["Nombre"].ToString();
                    txtUserName.Text =  recorre["USERNAME"].ToString();
                    txtPassword.Text = recorre["PASSWORD1"].ToString();
                    txtNombreEmp.Enabled = false;
                    cboArea.SelectedIndex = Convert.ToInt32(recorre["ID_ROL"].ToString());
                    cboEstado.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_USUARIO"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE ENCONTRO AL EMPLEADO VERIFIQUE EL CODIGO \n\n" + ex, "ERROR");

            }
        }

        private void frmActualizarEmpleado_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerAreaAdministrador(cboArea);
            Llenadocbo.ObtenerPersonal(cboempleadoActivo);
            Llenadocbo.ObtenerEstadoUser(cboEstado);

            txtNombreEmp.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            cboArea.Enabled = false;
            cboEstado.Enabled = false;
            txtobservaciones.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            BuscarAVP(cod_empleado);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            cboArea.Enabled = true;
            cboEstado.Enabled = true;
            txtobservaciones.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtPassword.PasswordChar = '*';
            }
            else
           if (txtPassword.Text != "")
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Edicion de Usuario";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Edicion de Usuario";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
                string empleado = txtNombreEmp.Text.ToUpper(); ;
                string _username = txtUserName.Text.ToUpper(); ;
                string _password = txtPassword.Text.ToUpper(); ;
                int area = cboArea.SelectedIndex;
                int estado = cboEstado.SelectedIndex;
                string observaciones = txtobservaciones.Text;
                Actualizar.ActualizarUsuario(cod_empleado, area,  estado, observaciones);
                MessageBox.Show("Datos actualizado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox2);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
        
                cboArea.Enabled = false;
                txtPassword.Enabled = false;
                cboEstado.Enabled = false;
                txtobservaciones.Enabled = false;
                cboempleadoActivo.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede actualizado el Usuario \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
