using MySql.Data.MySqlClient;
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

namespace pl_Gurkas.Vista.RRHH.Postulante
{
    public partial class frmPostulante : Form
    {
        Datos.ConexionMysql conexion = new Datos.ConexionMysql();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Datos.agregarDatosMysql Registrarmysql = new Datos.agregarDatosMysql();

        public frmPostulante()
        {
            InitializeComponent();
        }

        private void frmPostulante_Load(object sender, EventArgs e)
        {
            //llenado del combo del dgv
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "EstadoPostulante";
            Llenadocbo.ObtenerTipoPostulante(dgvCmb);
            dgvCmb.Name = "EstadoPostulante";
            dgvAsistencia.Columns.Add(dgvCmb);

            //dgvAsistencia.RowHeadersVisible = false;
            //dgvAsistencia.AllowUserToAddRows = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comand;
            string query = "SELECT * FROM  v_postulantes_datos ";
            comand = new MySqlCommand(query, conexion.ObtenerConexionPostulantes());
            comand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter dta = new MySqlDataAdapter(comand);
            dta.Fill(dt);
            dt.Columns[0].ColumnName = "Apellido Paterno";
            dt.Columns[1].ColumnName = "Apellido Materno";
            dt.Columns[2].ColumnName = "Nombre";
            dt.Columns[3].ColumnName = "Fecha Nacimiento";
            dt.Columns[4].ColumnName = "Edad";
            dt.Columns[5].ColumnName = "Tipo de Documento";
            dt.Columns[6].ColumnName = "Numero de Documento";
            dt.Columns[7].ColumnName = "Fecha de Emision de DNI";
            dt.Columns[8].ColumnName = "Fecha de Caducacion de DNI";
            dt.Columns[9].ColumnName = "Ubigeo";
            dt.Columns[10].ColumnName = "Sexo";
            dt.Columns[11].ColumnName = "Brevete";
            dt.Columns[12].ColumnName = "Numero de Brevete";
            dt.Columns[13].ColumnName = "Nacionalidad";
            dt.Columns[14].ColumnName = "Departamento";
            dt.Columns[15].ColumnName = "Provincia";
            dt.Columns[16].ColumnName = "Distrito";
            dt.Columns[17].ColumnName = "Direccion";
            dt.Columns[18].ColumnName = "Telefono";
            dt.Columns[19].ColumnName = "Correo";
            dt.Columns[20].ColumnName = "Estado Civil";
            dt.Columns[21].ColumnName = "Grado Instruccion";
            dt.Columns[22].ColumnName = "Talla Camisa";
            dt.Columns[23].ColumnName = "Talla Pantalon";
            dt.Columns[24].ColumnName = "Estatura";
            dt.Columns[25].ColumnName = "Calzado";
            dt.AcceptChanges();
            dgvAsistencia.DataSource = dt;
        }
    }
}
