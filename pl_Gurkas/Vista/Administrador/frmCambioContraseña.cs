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
    public partial class frmCambioContraseña : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatos Llenadocbo = new Datos.LlenadoDeDatos();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.registrar Registrar = new Datos.registrar();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        public frmCambioContraseña()
        {
            InitializeComponent();
        }

        private void frmCambioContraseña_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonal(cboempleadoActivo);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = new SqlCommand("select * from T_USUARIO   WHERE cod_empleado = '" + cod_empleado + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtUserName.Text = recorre["Username"].ToString();
                    txtxpaswwordActual.Text = recorre["PASSWORD1"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE ENCONTRO AL EMPLEADO VERIFIQUE EL CODIGO \n\n" + ex, "ERROR");
                cboempleadoActivo.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtxpaswwordActual.PasswordChar = '*';
                txtpasswordNuevo.PasswordChar = '*';
                txtpasswordRepite.PasswordChar = '*';
            }
            else
            {
                if (txtxpaswwordActual.Text != "")
                {
                    txtxpaswwordActual.PasswordChar = '\0';
                }
                if (txtpasswordNuevo.Text != "")
                {
                    txtpasswordNuevo.PasswordChar = '\0';
                }
                if (txtpasswordRepite.Text != "")
                {
                    txtpasswordRepite.PasswordChar = '\0';
                }
            }
        }

        private void btnActualizarContrasena_Click(object sender, EventArgs e)
        {
            if (txtpasswordNuevo.Text.Equals(txtpasswordRepite.Text))
            {
                string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
                string username = txtUserName.Text.ToUpper(); ;
                string pactual = txtxpaswwordActual.Text.ToUpper(); ;
                string pnuevo = txtpasswordNuevo.Text.ToUpper(); ;
                string prepite = txtpasswordRepite.Text.ToUpper(); ;
                DateTime fechaCreacion = DateTime.Now;
                DateTime fechaVencimiento = fechaCreacion.AddDays(182);
                try
                {
                    Actualizar.ActualizarContraUser(cod_empleado, username, pnuevo, fechaCreacion, fechaVencimiento);
                    MessageBox.Show("contraseña actualizada exitosamente", "correpto");
                    this.Close();
                    MessageBox.Show("Ingrese Nuevamente al sistema", "inicio");

                    //  frmLogin objLogin = new frmLogin();
                    //  objLogin.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR" + ex, "error");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no son iguales \n por favor validar contraseña", "Validar");
            }
        }
    }
}
