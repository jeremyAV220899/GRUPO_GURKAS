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

namespace pl_Gurkas.Vista.Planilla.CTS
{
    public partial class frmGuardarCTS : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmGuardarCTS()
        {
            InitializeComponent();
        }

        private void btnGuardadAsistencia_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(txtmes.Text);
            int anio = Convert.ToInt32(txtanio.Text);

            SqlCommand cmd = new SqlCommand("sp_actualizar_fecha_cts ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mes", SqlDbType.Int).Value = mes;
            cmd.Parameters.AddWithValue("@anio", SqlDbType.Int).Value = anio;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Datos Registrado correctamente", "Datos Registrado Correctamente");

        }

        private void frmGuardarCTS_Load(object sender, EventArgs e)
        {

        }
    }
}
