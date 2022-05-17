using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Planilla.CargaDeDatos
{
    public partial class frmCargaDeDatosPlanillaDescuentos : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        public frmCargaDeDatosPlanillaDescuentos()
        {
            InitializeComponent();
        }
        public static string registrado;
        public static string noregistrado;
        DataView importarDatos(string nombrearchivo)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0'", nombrearchivo);
            OleDbConnection conector = new OleDbConnection(conexion);
            conector.Open();
            OleDbCommand consulta = new OleDbCommand("select * from [Hoja1$]", conector);
            OleDbDataAdapter adaptador = new OleDbDataAdapter
            {
                SelectCommand = consulta
            };
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            conector.Close();
            return ds.Tables[0].DefaultView;
        }
        private void crear_temp()
        {
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            SqlCommand comando = conexion.conexionBD().CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "sp_tmp_descuentos @cod_unidad";
            comando.Parameters.AddWithValue("cod_unidad", cod_unidad);
            comando.ExecuteNonQuery();
        }
        private void caracbo()
        {
            cbotipoorder.Items.Insert(0, "Seleccione un tipo de orden");
            cbotipoorder.Items.Insert(1, "Descuentos");
            cbotipoorder.Items.Insert(2, "Reingreso No Afecto");
            cbotipoorder.Items.Insert(3, "Reingreso Afecto");
            cbotipoorder.SelectedIndex = 0;
        }
        private void frmCargaDeDatosPlanillaDescuentos_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
            caracbo();
            Llenadocbo.ObtenerUnidadPlanillas(cboUnidad);
        }
        private void actuaizar_personal()
        {
            SqlCommand comandos = conexion.conexionBD().CreateCommand();
            comandos.CommandType = CommandType.Text;
            comandos.CommandText = "sp_personal_uniada_caga_masiva";
            comandos.ExecuteNonQuery();
        }
        private void detaelle_registro()
        {
            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM v_resumen_carga_masiva ", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    registrado = recorre["cantidad_registradad"].ToString();
                    noregistrado = recorre["cantindad_no_registrada"].ToString();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            crear_temp();
            int cod_order = cbotipoorder.SelectedIndex;
            string cod_unidad = cboUnidad.SelectedValue.ToString();
            const string titulo = "Guardar Datos en el Sistema";
            const string mensaje = "Porfavor verificar antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICACION DE DATOS";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                if (cod_order == 1)
                {
                    SqlCommand comando = new SqlCommand("sp_subir_planillas_descuentos_masivo @param1, @param2, @param3, @param4, @param5,@param6,@param7,@param8,@param9,@param10,@param11,@param12", conexion.conexionBD());
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Cod_empleado"].Value != null && row.Cells["PENALIDAD"].Value != null &&
                            row.Cells["RENTA_5TA"].Value != null && row.Cells["SUCAMEC_desp"].Value != null &&
                            row.Cells["RETENC_ALIMENTOS"].Value != null && row.Cells["BOTAS_ZAPATOS"].Value != null &&
                            row.Cells["desp_MULTA_ELECTRAL"].Value != null && row.Cells["EXCESO_DE_PAG"].Value != null &&
                           row.Cells["desp_covid"].Value != null && row.Cells["desp_papeles"].Value != null &&
                           row.Cells["Prestamos"].Value != null && row.Cells["Desc_Equipo"].Value != null)
                        {
                            comando.Parameters.Clear();
                            comando.Parameters.AddWithValue("@param1", Convert.ToString(row.Cells["Cod_empleado"].Value));
                            comando.Parameters.AddWithValue("@param2", Convert.ToDecimal(row.Cells["PENALIDAD"].Value));
                            comando.Parameters.AddWithValue("@param3", Convert.ToDecimal(row.Cells["RENTA_5TA"].Value));
                            comando.Parameters.AddWithValue("@param4", Convert.ToDecimal(row.Cells["SUCAMEC_desp"].Value));
                            comando.Parameters.AddWithValue("@param5", Convert.ToDecimal(row.Cells["RETENC_ALIMENTOS"].Value));
                            comando.Parameters.AddWithValue("@param6", Convert.ToDecimal(row.Cells["BOTAS_ZAPATOS"].Value));
                            comando.Parameters.AddWithValue("@param7", Convert.ToDecimal(row.Cells["desp_MULTA_ELECTRAL"].Value));
                            comando.Parameters.AddWithValue("@param8", Convert.ToDecimal(row.Cells["EXCESO_DE_PAG"].Value));
                            comando.Parameters.AddWithValue("@param9", Convert.ToDecimal(row.Cells["desp_covid"].Value));
                            comando.Parameters.AddWithValue("@param10", Convert.ToDecimal(row.Cells["desp_papeles"].Value));
                            comando.Parameters.AddWithValue("@param11", Convert.ToDecimal(row.Cells["Prestamos"].Value));
                            comando.Parameters.AddWithValue("@param12", Convert.ToDecimal(row.Cells["Desc_Equipo"].Value));
                            comando.ExecuteNonQuery();
                        }
                    }
                    actuaizar_personal();
                    detaelle_registro();
                    MessageBox.Show("Datos registrado correptamente \n Registrado Exitosamente :" + registrado
                        + "\n No Registrado : " + noregistrado + "\n SI = VERIFICAR PERSONAL NO REGISTRADO", "Correpto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resutlado == DialogResult.Yes)
                    {
                        Vista.Planilla.CargaDeDatos.frmPersonalNoRegistrado verificar = new Vista.Planilla.CargaDeDatos.frmPersonalNoRegistrado();
                        verificar.ShowDialog();
                    }
                }
                if (cod_order == 2)
                {
                    SqlCommand comando = new SqlCommand("sp_subir_planillas_descuentos_reingerso_no_afecto @param1, @param2", conexion.conexionBD());
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["COD_EMPLEADO"].Value != null && row.Cells["ReingresoNoAfecto"].Value != null)
                        {
                            comando.Parameters.Clear();
                            comando.Parameters.AddWithValue("@param1", Convert.ToString(row.Cells["COD_EMPLEADO"].Value));
                            comando.Parameters.AddWithValue("@param2", Convert.ToDecimal(row.Cells["ReingresoNoAfecto"].Value));
                            comando.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Datos registrado correptamente");
                }
                if (cod_order == 3)
                {
                    SqlCommand comando = new SqlCommand("sp_subir_planillas_descuentos_reingerso_afecto @param1, @param2", conexion.conexionBD());
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["COD_EMPLEADO"].Value != null && row.Cells["REINGRESOAFECTO"].Value != null)
                        {
                            comando.Parameters.Clear();
                            comando.Parameters.AddWithValue("@param1", Convert.ToString(row.Cells["COD_EMPLEADO"].Value));
                            comando.Parameters.AddWithValue("@param2", Convert.ToDecimal(row.Cells["REINGRESOAFECTO"].Value));
                            comando.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Datos registrado correptamente");
                }
                //  registrar_tabla();
            }
            else
            {
                MessageBox.Show("No se pudo Registrar los Datos  correptamente");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls;*.xlsx;",
                Title = "Seleccionar Archivo"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = importarDatos(openFileDialog.FileName);
            }
        }
    }
}
