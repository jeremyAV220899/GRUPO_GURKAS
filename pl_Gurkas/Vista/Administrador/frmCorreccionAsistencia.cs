using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Administrador
{
    public partial class frmCorreccionAsistencia : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatos Llenadocbo = new Datos.LlenadoDeDatos();
        Datos.registrar Registrar = new Datos.registrar();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        Datos.eliminar eliminar = new Datos.eliminar();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public frmCorreccionAsistencia()
        {
            InitializeComponent();
        }
        public void obtenerip_nombre()
        {
            string strHostName = string.Empty;
            // Obteniendo la dirección IP de la máquina local…
            // Primero obtenga el nombre de host de la máquina local.
            strHostName = Dns.GetHostName();
            // Luego, usando el nombre de host, obtenga la lista de direcciones IP.
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
            for (int i = 0; i < hostIPs.Length; i++)
            {
                lblIP.Text = "Direccion IP: " + hostIPs[i].ToString();

            }
            lblNombrePC.Text = "Nombre de la computadora: " + strHostName;
        }
        private void frmCorreccionAsistencia_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonal(cboPersonal);
            Llenadocbo.ObtenerUnidad(cboUnidadCorrecto);
            Llenadocbo.ObtenerTurno(cboturnoCorrecto);
            Llenadocbo.ObtenerAsistencias(cboTipoAsistenciaCorrecto);

            Llenadocbo.ObtenerPersonal(cboPersonalCorrecto);
            Llenadocbo.ObtenerPersonal(cboagregarpersonal);
            Llenadocbo.ObtenerUnidad(cboagregarunidad);
            Llenadocbo.ObtenerTurno(cboagregarturno);
            Llenadocbo.ObtenerAsistencias(cboagregarasistencia);
            dgvAsistencia.RowHeadersVisible = false;
            dgvAsistencia.AllowUserToAddRows = false;
            lblIP.Visible = false;
            lblNombrePC.Visible = false;
            groupBox4.Visible = false;


            Llenadocbo.ObtenerPersonal(cboPesonalC);
            Llenadocbo.ObtenerUnidad(cboUnidadC);
            Llenadocbo.ObtenerTurno(cboTurnoC);
            Llenadocbo.ObtenerAsistencias(cboTurnoC);
            Llenadocbo.ObtenerAsistencias(cboTipoAsistenciaC);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string cod_empleado = cboPersonal.SelectedValue.ToString();
                DateTime fecha = dtpFechaInicio.Value;
                DateTime fechadin = dtpFechaFin.Value;
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_AsistenciaPersonalBuscarError @cod_empleado,@fecha,@fechafin";
                comando.Parameters.AddWithValue("cod_empleado", cod_empleado);
                comando.Parameters.AddWithValue("fecha", fecha);
                comando.Parameters.AddWithValue("fechafin", fechadin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Trabajador";
                dt.Columns[2].ColumnName = "Sede";
                dt.Columns[3].ColumnName = "Fecha";
                dt.Columns[4].ColumnName = "Tipo Asistencia";
                dt.Columns[5].ColumnName = "Turno";
                dt.Columns[6].ColumnName = "idasistencia";
                dt.AcceptChanges();
                dgvAsistencia.DataSource = dt;
                dgvAsistencia.Columns[6].Visible = false;

                modulo.auditoriaFunciones("Administrador", "Buscar asistencia de empleado", "Resumen de Busqueda : Empleado : " + cod_empleado
                    + " Fecha Inicio : " + fecha +" Fecha Fin : "+ fechadin);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error no se puede encontrar la lista verifique el proceso almacenado SP_BuscarEMpleadoUnidadSede\n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Correpcion Asistencia";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Correpcion Asistencia";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardadAsistencia_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboagregarpersonal.SelectedValue.ToString();
            DateTime FechaInicio = dtpagregarfecha.Value;
            int codTurno = cboagregarturno.SelectedIndex;
            string codunidad = cboagregarunidad.SelectedValue.ToString();
            string codSede = cboagregarsede.SelectedValue.ToString();
            string tipoasistencia = cboagregarasistencia.SelectedValue.ToString();
            try
            {
                Registrar.RegistrarAsistenciaAdministrador(cod_empleado, FechaInicio, codTurno, codunidad, codSede, tipoasistencia);
                MessageBox.Show("Asistencia Actualizado correptamente ", "Correpto");

                modulo.auditoriaFunciones("Administrador", "Registrar asistencia de empleado", "Resumen de Registro : Empleado : " + cod_empleado
                  + " Fecha : " + FechaInicio + " Turno : " + codTurno + " Unidad : "+ codunidad + " Sede : "+ codSede + " Tipo de Asistencia : " + tipoasistencia);
            }
            catch (Exception ex)
            {
                MessageBox.Show("no se pudo registrar la asistencia" + ex, "error");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            const string titulo = "Corregir Asistencia Personal";
            const string mensaje = "Estas seguro que deseas Corregir la Asistencia del Personal";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                cboturnoCorrecto.Enabled = true;
                cboUnidadCorrecto.Enabled = true;
                cboCedeCorrecta.Enabled = true;
                cboPersonalCorrecto.Enabled = true;
                cboTipoAsistenciaCorrecto.Enabled = true;
                dtpFecha.Enabled = true;
                modulo.auditoriaFunciones("Administrador", "Corregir Asistencia", "Habilitar  opcion de correccion de tareaje para el registro : " + txtCodAsistencia.Text);
            }

        }

        private void dgvAsistencia_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cod_asistencia = dgvAsistencia.CurrentRow.Cells[6].Value.ToString();
                //
                SqlCommand comando = new SqlCommand("SELECT * FROM v_AsistenciaPersonallenarError WHERE id_asistencia = " + cod_asistencia + "", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {

                    cboturnoCorrecto.SelectedIndex = Convert.ToInt32(recorre["ID_TURNO_EMPLEADO"].ToString());
                    cboUnidadCorrecto.SelectedValue = recorre["Cod_unidad"].ToString();
                    cboCedeCorrecta.SelectedValue = recorre["Cod_sede"].ToString();
                    cboPersonalCorrecto.SelectedValue = recorre["Cod_empleado"].ToString();
                    cboTipoAsistenciaCorrecto.SelectedValue = recorre["id_TipoAsistencia"].ToString();
                    txtCodAsistencia.Text = recorre["id_asistencia"].ToString();
                    dtpFecha.Text = (recorre["FechaRegistroMarcacion"].ToString());



                    cboTurnoC.SelectedIndex = Convert.ToInt32(recorre["ID_TURNO_EMPLEADO"].ToString());
                    cboUnidadC.SelectedValue = recorre["Cod_unidad"].ToString();
                    xboSedeC.SelectedValue = recorre["Cod_sede"].ToString();
                    cboPesonalC.SelectedValue = recorre["Cod_empleado"].ToString();
                    cboTipoAsistenciaC.SelectedValue = recorre["id_TipoAsistencia"].ToString();
                    txtCodAsistenciaC.Text = recorre["id_asistencia"].ToString();
                    dtpFechaC.Text = (recorre["FechaRegistroMarcacion"].ToString());
                }
                cboturnoCorrecto.Enabled = false;
                cboUnidadCorrecto.Enabled = false;
                cboCedeCorrecta.Enabled = false;
                cboPersonalCorrecto.Enabled = false;
                cboTipoAsistenciaCorrecto.Enabled = false;
                dtpFecha.Enabled = false;



            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void btnEliminarAsistencia_Click(object sender, EventArgs e)
        {
            const string titulo = "Eliminar Asistencia Personal";
            const string mensaje = "Estas seguro que deseas Eliminar la Asistencia del Personal";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                obtenerip_nombre();
                string ip_pc = lblIP.Text;
                string nombre_pc = lblNombrePC.Text;
                DateTime Fecha = dtpFecha.Value;
                string cod_Asistencia_personal = txtCodAsistencia.Text;
                string nombre_usurio = "sistema";
                string turno_correcto = cboturnoCorrecto.SelectedItem.ToString();
                string unidad_correcta = cboUnidadCorrecto.SelectedValue.ToString();
                string sede_correcta = cboCedeCorrecta.SelectedValue.ToString();
                string personal_correcta = cboPersonalCorrecto.SelectedValue.ToString();
                string tipoasistencia_correcta = cboTipoAsistenciaCorrecto.SelectedValue.ToString();
                string detelle = "Turno : " + turno_correcto + "\n\n Cod_Unidad : " + unidad_correcta
                    + "\n\n Cod_Sede : " + sede_correcta + "\n\nCod_Personal : " + personal_correcta + "\n\n cod_Asistencia : " + tipoasistencia_correcta;

                string Datos = "Codigo de Asistencia : " + cod_Asistencia_personal + "Turno : " + turno_correcto + " Unidad : " + unidad_correcta
                + " Sede : " + sede_correcta + " Pesonal : " + personal_correcta + " Tipo Asistencia : " + tipoasistencia_correcta + " Fecha : " + Fecha;
                try
                {
                    eliminar.ActualizarAsistenciaPersonal(ip_pc, nombre_pc, Fecha, nombre_usurio, cod_Asistencia_personal, detelle);
                    MessageBox.Show("Asistencia eliminada correptamente ", "Correpto");

                    modulo.auditoriaFunciones("Administrador", "Eliminar asistencia", "Se elimino la asistencia de  : " + Datos);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminada la asistencia" + ex, "Correpto");
                }

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            obtenerip_nombre();
            string ip_pc = lblIP.Text;
            string nombre_pc = lblNombrePC.Text;
            int turno_correcto = cboturnoCorrecto.SelectedIndex;
            string unidad_correcta = cboUnidadCorrecto.SelectedValue.ToString();
            string sede_correcta = cboCedeCorrecta.SelectedValue.ToString();
            string personal_correcta = cboPersonalCorrecto.SelectedValue.ToString();
            string tipoasistencia_correcta = cboTipoAsistenciaCorrecto.SelectedValue.ToString();
            DateTime Fecha = dtpFecha.Value;
            string cod_Asistencia_personal = txtCodAsistencia.Text;
            string nombre_usurio = "SIS";

            string cod_Asistencia = txtCodAsistenciaC.Text;
            int id_turno = cboTurnoC.SelectedIndex;
            string unidad = cboUnidadC.SelectedValue.ToString();
            string sede = xboSedeC.SelectedValue.ToString();
            string personal = cboPesonalC.SelectedValue.ToString();
            string tipoasistencia = cboTipoAsistenciaC.SelectedValue.ToString();
            DateTime Fechas = dtpFechaC.Value;

            string Datos_nuevos = "Codigo de Asistencia : " + cod_Asistencia_personal + "Turno : " + turno_correcto + " Unidad : " + unidad_correcta
                + " Sede : " + sede_correcta + " Pesonal : " + personal_correcta + " Tipo Asistencia : " + tipoasistencia_correcta + " Fecha : " + Fecha;

            string Datos_antes = "Codigo de Asistencia : " + cod_Asistencia + "Turno : " + id_turno + " Unidad : " + unidad
                + " Sede : " + sede + " Pesonal : " + personal + " Tipo Asistencia : " + tipoasistencia + " Fecha : " + Fechas;
            try
            {
                Actualizar.ActualizarAsistenciaPersonal(ip_pc, nombre_pc, turno_correcto, unidad_correcta, sede_correcta, personal_correcta, tipoasistencia_correcta
                    , Fecha, nombre_usurio, cod_Asistencia_personal);
                MessageBox.Show("Asistencia Actualizado correptamente ", "Correpto");

                modulo.auditoriaFunciones("Administrador", "Guardar Asistencia Corregida ", "Resumen de Asistencia : Nuevo " + Datos_nuevos
                    + " Datos Antiguos : " + Datos_antes);

                cboturnoCorrecto.Enabled = true;
                cboUnidadCorrecto.Enabled = true;
                cboCedeCorrecta.Enabled = true;
                cboPersonalCorrecto.Enabled = true;
                cboTipoAsistenciaCorrecto.Enabled = true;
                dtpFecha.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la asistencia" + ex, "Correpto");
            }
        }

        private void cboagregarunidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboagregarunidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboagregarunidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSede(cboagregarsede, cod_unidad);
            }
        }

        private void cboUnidadCorrecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidadCorrecto.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidadCorrecto.SelectedValue.ToString();
                Llenadocbo.ObtenerSede(cboCedeCorrecta, cod_unidad);
            }
        }

        private void cboUnidadC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidadC.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidadC.SelectedValue.ToString();
                Llenadocbo.ObtenerSede(xboSedeC, cod_unidad);
            }
        }
    }
}
