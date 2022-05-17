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
    public partial class frmRegistroDatosFamiliarez : Form
    {
        private DataTable dt;
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        public frmRegistroDatosFamiliarez()
        {
            InitializeComponent();
        }
        private void InsertarFamiliarColaborador()
        {
            try
            {
                string codEmpleado = cboempleadoActivo.SelectedValue.ToString();
                string Esposo = txtEsposo.Text;
                string dniespo = txtdniEsposa.Text;
                string hijo1 = txtHijo1.Text;
                string dni1 = txtdni1.Text;
                string hijo2 = txtHijo2.Text;
                string dni2 = txtdni2.Text;
                string hijo3 = txtHijo3.Text;
                string dni3 = txtdni3.Text;
                string hijo4 = txtHijo4.Text;
                string dni4 = txtdni4.Text;
                int cantidad_hijos = cboNumeroHijos.SelectedIndex;
               registrar.InsertarFamiliarColaborador(codEmpleado, Esposo, dniespo, hijo1, dni1, hijo2, dni2, hijo3, dni3, hijo4, dni4,cantidad_hijos);
                MessageBox.Show("Datos registrado correptamente", "Correpto");
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede Regristrar Los Familiares del colaborador verifique el codigo\n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvVista()
        {
            dt = new DataTable();
            dt.Columns.Add("Cod Empleado");
            dt.Columns.Add("Espos@ / Conviviente");
            dt.Columns.Add("DNI Eapos@");
            dt.Columns.Add("Hijo 1");
            dt.Columns.Add("DNI Hijo 1");
            dt.Columns.Add("Hijo 2");
            dt.Columns.Add("DNI Hijo 2");
            dt.Columns.Add("Hijo 3");
            dt.Columns.Add("DNI Hijo 3");
            dt.Columns.Add("Hijo 4");
            dt.Columns.Add("DNI Hijo 4");
            dgvFamiliarPersonal.DataSource = dt;
        }
        private void CargarNumeroDeHijo()
        {
            cboNumeroHijos.Items.Insert(0, "No tiene");
            cboNumeroHijos.Items.Insert(1, "1 hijo");
            cboNumeroHijos.Items.Insert(2, "2 hijos");
            cboNumeroHijos.Items.Insert(3, "3 hijos");
            cboNumeroHijos.Items.Insert(4, "4 hijos");
            cboNumeroHijos.SelectedIndex = 0;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Familiares";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Familiares";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmRegistroDatosFamiliarez_Load(object sender, EventArgs e)
        {
            CargarNumeroDeHijo();
            dgvFamiliarPersonal.RowHeadersVisible = false;
            dgvFamiliarPersonal.AllowUserToAddRows = false;
            Llenadocbo.ObtenerPersonalRRHH(cboempleadoActivo);
            dgvVista();
        }

        private void cboNumeroHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNumeroHijos.SelectedIndex == 0)
            {
                txtHijo1.Text = "NO TIENE";
                txtHijo1.Enabled = false;
                txtHijo2.Text = "NO TIENE";
                txtHijo2.Enabled = false;
                txtHijo3.Text = "NO TIENE";
                txtHijo3.Enabled = false;
                txtHijo4.Text = "NO TIENE";
                txtHijo4.Enabled = false;
                txtdni1.Text = "NO TIENE";
                txtdni1.Enabled = false;
                txtdni2.Text = "NO TIENE";
                txtdni2.Enabled = false;
                txtdni3.Text = "NO TIENE";
                txtdni3.Enabled = false;
                txtdni4.Text = "NO TIENE";
                txtdni4.Enabled = false;
            }
            else if (cboNumeroHijos.SelectedIndex == 1)
            {
                //LimpiarDatos.LimpiarGroupBox(groupBox1);
                txtHijo2.Text = "NO TIENE";
                txtHijo2.Enabled = false;
                txtHijo3.Text = "NO TIENE";
                txtHijo3.Enabled = false;
                txtHijo4.Text = "NO TIENE";
                txtHijo4.Enabled = false;
                txtdni2.Text = "NO TIENE";
                txtdni2.Enabled = false;
                txtdni3.Text = "NO TIENE";
                txtdni3.Enabled = false;
                txtdni4.Text = "NO TIENE";
                txtdni4.Enabled = false;
                txtHijo1.Enabled = true;
                txtdni1.Enabled = true;
            }
            else if (cboNumeroHijos.SelectedIndex == 2)
            {
               // LimpiarDatos.LimpiarGroupBox(groupBox1);
                txtHijo3.Text = "NO TIENE";
                txtHijo3.Enabled = false;
                txtHijo4.Text = "NO TIENE";
                txtHijo4.Enabled = false;
                txtdni3.Text = "NO TIENE";
                txtdni3.Enabled = false;
                txtdni4.Text = "NO TIENE";
                txtdni4.Enabled = false;
                txtHijo1.Enabled = true;
                txtdni1.Enabled = true;
                txtHijo2.Enabled = true;
                txtdni2.Enabled = true;
            }
            else if (cboNumeroHijos.SelectedIndex == 3)
            {
                //LimpiarDatos.LimpiarGroupBox(groupBox1);
                txtHijo4.Text = "NO TIENE";
                txtHijo4.Enabled = false;
                txtdni4.Text = "NO TIENE";
                txtdni4.Enabled = false;
                txtHijo1.Enabled = true;
                txtdni1.Enabled = true;
                txtHijo2.Enabled = true;
                txtdni2.Enabled = true;
                txtHijo3.Enabled = true;
                txtdni3.Enabled = true;
            }
            else if (cboNumeroHijos.SelectedIndex == 4)
            {
               // LimpiarDatos.LimpiarGroupBox(groupBox1);
                txtHijo1.Enabled = true;
                txtdni1.Enabled = true;
                txtHijo2.Enabled = true;
                txtdni2.Enabled = true;
                txtHijo3.Enabled = true;
                txtdni3.Enabled = true;
                txtdni4.Enabled = true;
                txtHijo4.Enabled = true;
            }
        }

        private void txtdniEsposa_TextChanged(object sender, EventArgs e)
        {
            txtdniEsposa.MaxLength = 9;
        }

        private void txtdni1_TextChanged(object sender, EventArgs e)
        {
            txtdni1.MaxLength = 9;
        }

        private void txtdni2_TextChanged(object sender, EventArgs e)
        {
            txtdni2.MaxLength = 9;
        }

        private void txtdni3_TextChanged(object sender, EventArgs e)
        {
            txtdni3.MaxLength = 9;
        }

        private void txtdni4_TextChanged(object sender, EventArgs e)
        {
            txtdni4.MaxLength = 9;
        }

        private void btnNuevoFamiliarPersonal_Click(object sender, EventArgs e)
        {
            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.limpiarPanel(panel1);
        }

        private void buscar(string cod_emeplado) {

            try
            {

                SqlCommand comando = new SqlCommand("SELECT * FROM v_datos_familiares where cod_empleado = '" + cod_emeplado + "'", conexion.conexionBD());
                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtEsposo.Text = recorre["Esposa_nombre"].ToString();
                    txtdniEsposa.Text = recorre["dni_esposa"].ToString();
                    txtHijo1.Text = recorre["Nombre_hijo_1"].ToString();
                    txtdni1.Text = recorre["dni_1"].ToString();
                    txtHijo2.Text = recorre["Nombre_hijo_2"].ToString();
                    txtdni2.Text = recorre["dni_2"].ToString();
                    txtHijo3.Text = recorre["Nombre_hijo_3"].ToString();
                    txtdni3.Text = recorre["dni_3"].ToString();
                    txtHijo4.Text = recorre["Nombre_hijo_4"].ToString();
                    txtdni4.Text = recorre["dni_4"].ToString();
                    string n = recorre["Cantidad_Hijos"].ToString();
                    cboNumeroHijos.SelectedIndex = Convert.ToInt32(n);
                }
            }
            catch (Exception err)
            {
                
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO SP_BUCARPERSONAL \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

        }


        private void btnBuscarFamiliarPersonal_Click(object sender, EventArgs e)
        {
            string codAVP = cboempleadoActivo.SelectedValue.ToString();
            buscar(codAVP);
        }

        private void btnAgregarFamiliar_Click(object sender, EventArgs e)
        {
            InsertarFamiliarColaborador();
        }
    }
}
