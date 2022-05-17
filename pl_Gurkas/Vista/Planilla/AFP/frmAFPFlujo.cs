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

namespace pl_Gurkas.Vista.Planilla.AFP
{
    public partial class frmAFPFlujo : Form
    {
        public int _afp;
        public int _codcomisionafp;
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        public frmAFPFlujo()
        {
            InitializeComponent();
        }

        private void frmAFPFlujo_Load(object sender, EventArgs e)
        {
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SP_BuscarAFP  @Cod_TipoComisionAFP,@Cod_AFP ";
            comando.Parameters.AddWithValue("@Cod_TipoComisionAFP", _codcomisionafp);
            comando.Parameters.AddWithValue("@Cod_AFP", _afp);
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                txtCSF.Text = leer["CSF_F_AFP"].ToString();
                txtps.Text = leer["PS_AFP"].ToString();
                txtaofp.Text = leer["AOFP_AFP"].ToString();
                txtrma.Text = leer["RMA_AFP"].ToString();
                DTPfecha.Text = leer["fecha_afp"].ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal csf = Convert.ToDecimal(txtcomisionsobreflujo.Text);
            decimal ps = Convert.ToDecimal(txtprimadeseguro.Text);
            decimal aofp = Convert.ToDecimal(txtaporteofondopensiones.Text);
            decimal mra = Convert.ToDecimal(txtremuneracionmaxima.Text);
            DateTime fecha = dateTimePicker2.Value;
            DateTime fecha_i = DTPfecha.Value;
            try
            {
                actualizar.actualizarAFPFlujo(_codcomisionafp, _afp, csf, ps, aofp, mra, fecha, fecha_i);
                MessageBox.Show("Actualizacion Correcta", "Datos Actualizados");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la actualizacion correspondiente" + ex, "ERROR");
            }
        }
    }
}
