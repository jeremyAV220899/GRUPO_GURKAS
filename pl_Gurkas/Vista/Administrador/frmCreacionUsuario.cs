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
    public partial class frmCreacionUsuario : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatos Llenadocbo = new Datos.LlenadoDeDatos();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.registrar Registrar = new Datos.registrar();

        public frmCreacionUsuario()
        {
            InitializeComponent();
        }
        private void crearusurio()
        {
            try
            {
                string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
                string empleado = txtNombreEmp.Text.ToUpper(); ;
                string _username = txtUserName.Text.ToUpper(); ;
                string _password = txtPassword.Text.ToUpper(); ;
                int area = cboArea.SelectedIndex;
                DateTime fechaCreacion = DateTime.Now;
                DateTime fechaVencimiento = fechaCreacion.AddDays(182);
                Registrar.RegistrarNuevoUsuario(cod_empleado, empleado, _username, _password, area, fechaCreacion, fechaVencimiento);
                MessageBox.Show("Datos registrado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede Regristrar el Usuario \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BuscarAVP(string codAVP)
        {
            try
            {
                SqlCommand comando = new SqlCommand("select NOMBRE_COMPLETO,DOCT_IDENT,NOMBRE_EMPLEADO,APELLIDO_PATERNO from t_mae_personal   WHERE cod_empleado = '" + codAVP + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    string Nombre = recorre["NOMBRE_EMPLEADO"].ToString();
                    string pl = Nombre.Substring(0, 1);

                    txtNombreEmp.Text = recorre["NOMBRE_COMPLETO"].ToString();
                    txtUserName.Text = pl + recorre["APELLIDO_PATERNO"].ToString();
                    txtPassword.Text = recorre["DOCT_IDENT"].ToString();
                    txtNombreEmp.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE ENCONTRO AL EMPLEADO VERIFIQUE EL CODIGO \n\n" + ex, "ERROR");
               
            }
        }
        private void frmCreacionUsuario_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerAreaAdministrador(cboArea);
            Llenadocbo.ObtenerPersonal(cboempleadoActivo);
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
            const string titulo = "Cerrar Registro de Creacion de Usuario";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Creacion de Usuario";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            BuscarAVP(cod_empleado);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            crearusurio();
        }
    }
}
