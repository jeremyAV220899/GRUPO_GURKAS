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

namespace pl_Gurkas.Vista.Planilla.CargaDeDatos
{
    public partial class frmPersonalNoRegistrado : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public frmPersonalNoRegistrado()
        {
            InitializeComponent();
        }

        private void frmPersonalNoRegistrado_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_resumen_carag_masiva ";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(comando);
            dta.Fill(dt);
            dt.Columns[0].ColumnName = "Cod Empleado";
            dt.Columns[1].ColumnName = "Empleado";
            dt.Columns[2].ColumnName = "Unidad";
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
        }
    }
}
