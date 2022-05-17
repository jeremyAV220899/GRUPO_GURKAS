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
    public partial class frmAsignarUnidadUsuario : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatos Llenadocbo = new Datos.LlenadoDeDatos();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.registrar Registrar = new Datos.registrar();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        public frmAsignarUnidadUsuario()
        {
            InitializeComponent();
        }
        private void showDialogs(String message, Color bdColor)
        {
            MensajeEmergente.DialogForm dialog = new MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        }
        private void BuscaDatos(string codAVP)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_buscar_unidad_usuarios  @cod_empleado";
                comando.Parameters.AddWithValue("cod_empleado", codAVP);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Codigo de Empleado";
                dt.Columns[1].ColumnName = "Nombre";
                dt.Columns[2].ColumnName = "Codigo de Unidad";
                dt.Columns[3].ColumnName = "Unidad";
                dt.Columns[4].ColumnName = "Estado";
                dt.AcceptChanges();
                dgvUnidadAsignadas.DataSource = dt;
                DateTime fecha = DateTime.Now;
             //   obtenerip_nombre();
               // string username = Code.nivelUser._nombre;
               // string detalle = "Buscar Datos";
                //string cod_buscado = "Codigo de empleado Buscado : " + codAVP;
                // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                showDialogs("Datos Encontrados", Color.FromArgb(0, 200, 81));

            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR EN EL PROCESO ALMACENADO SP_BUCARPERSONAL" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                showDialogs("ERROR", Color.FromArgb(255, 53, 71));
            }
        }
        private void frmAsignarUnidadUsuario_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUsuario(cbousuario);
            Llenadocbo.ObtenerUnidad(cbounidad);
            Llenadocbo.EstadoUsuarioUnidad(cboestado);

            Llenadocbo.ObtenerUnidad(cbou);
            Llenadocbo.EstadoUsuarioUnidad(cboe);

            dgvUnidadAsignadas.RowHeadersVisible = false;
            dgvUnidadAsignadas.AllowUserToAddRows = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod = cbousuario.SelectedValue.ToString();
            BuscaDatos(cod);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cod = cbousuario.SelectedValue.ToString();
            string uni = cbounidad.SelectedValue.ToString();
            int estado = cboestado.SelectedIndex;
            try
            {
                Registrar.RegistrarNuevoUnidadUsuarip(cod, uni, estado);
                MessageBox.Show("Unidad Asignada", "Correpto");
                showDialogs("Datos Registrados", Color.FromArgb(0, 200, 81));
                BuscaDatos(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Asignar unidad \n\n" + ex, "Correpto");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
                const string titulo = "Cerrar Asignacion de Unidad";
                const string mensaje = "Estas seguro que deseas cerra la Asignacion de Unidad";
                var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resutlado == DialogResult.Yes)
                {
                    this.Close();
                }   
        }

        private void dgvUnidadAsignadas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string codEmpleado = dgvUnidadAsignadas.CurrentRow.Cells[0].Value.ToString();
                string cod_unidad = dgvUnidadAsignadas.CurrentRow.Cells[2].Value.ToString();

                SqlCommand comando = new SqlCommand("SELECT * FROM v_user_unidad_desp WHERE cod_empleado = '" + codEmpleado + "' and cod_unidad = '" + cod_unidad + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtusuario.Text = recorre["Nombre"].ToString();
                    cboe.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_UNIDAD_USUARIO"].ToString());
                    cbou.SelectedValue = recorre["cod_unidad"].ToString();

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cod = cbousuario.SelectedValue.ToString();
            string uni = cbou.SelectedValue.ToString();
            int estado = cboe.SelectedIndex;
            try
            {
                Actualizar.ActualizarNuevoUnidadUsuarip(cod, uni, estado);
                MessageBox.Show("Unidad Actualizado", "Correpto");
                showDialogs("Datos Actualizado", Color.FromArgb(0, 200, 81));
                BuscaDatos(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en actualizar \n\n" + ex, "Correpto");
            }
        }
    }
}
