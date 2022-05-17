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

namespace pl_Gurkas.Vista.CentroControl
{
    public partial class frmAsistenciaPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Datos.agregarDatosMysql Registrarmysql = new Datos.agregarDatosMysql();

        public frmAsistenciaPersonal()
        {
            InitializeComponent();
        }
        public void PersonalSinAsistenciaResumenConMarcacionTotal(DateTime fecha, String Cod_Unidad, int turno, int empresa)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_personalsinmarcacion_unidades_centro_control_Resumen_total_v2 @unidad,@turno ";
                //comando.Parameters.AddWithValue("fecha", fecha);
                comando.Parameters.AddWithValue("unidad", Cod_Unidad);
                comando.Parameters.AddWithValue("turno", turno);
                //comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    lblTotalMarcaciones.Text = recorre["totalTitular"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
        public void PersonalSinAsistenciaResumenConMarcacion(DateTime fecha, String Cod_Unidad, int turno, int empresa)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "sp_personalsinmarcacion_unidades_centro_control_Resumen_conMarcacion_v2 @unidad,@turno ";
              //  comando.Parameters.AddWithValue("fecha", fecha);
                comando.Parameters.AddWithValue("unidad", Cod_Unidad);
                comando.Parameters.AddWithValue("turno", turno);
                //comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    lblPersonalConMarcacion.Text = recorre["totalConMarcacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
        public void PersonalSinAsistenciaResumen(DateTime fecha, String Cod_Unidad, int turno, int empresa)
        {
          
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_BuscarEMpleadoUnidadSede_TEST2  @unidad,@turno ";
              //  comando.Parameters.AddWithValue("fecha", fecha);
                comando.Parameters.AddWithValue("unidad", Cod_Unidad);
                comando.Parameters.AddWithValue("turno", turno);
              //  comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    String res = recorre["totalSinMarcacion"].ToString();
                    lblCantidadDePersonalSinMarcacion.Text = res;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
        public void PersonalSinMarcacions(DateTime fecha,String Cod_Unidad,int turno, int empresa)
        {
            DateTime dia = fecha;
            string cod_unidad = Cod_Unidad;
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_BuscarEMpleadoUnidadSede_TEST1  @unidad,@turno";
       //         comando.Parameters.AddWithValue("fecha", dia);
                comando.Parameters.AddWithValue("unidad", cod_unidad);
                comando.Parameters.AddWithValue("turno", turno);
         //       comando.Parameters.AddWithValue("empresa", empresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Sede";
                dt.Columns[3].ColumnName = "Turno";
                dt.Columns[4].ColumnName = "Estado";
                dt.AcceptChanges();
                dgvPersonalEstatura.DataSource = dt;
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro ningun resultado \n\n " + ex, "ERROR");

            }
        }
        private void verificar(DateTime fecha, String Cod_Unidad, int turno, int empresa)
        {
            lblCantidadDePersonalSinMarcacion.Text = "0";
            lblPersonalConMarcacion.Text = "0";
            lblTotalMarcaciones.Text = "0";
            PersonalSinMarcacions(fecha, Cod_Unidad, turno, empresa);
           PersonalSinAsistenciaResumen(fecha, Cod_Unidad, turno, empresa);
            PersonalSinAsistenciaResumenConMarcacion(fecha, Cod_Unidad, turno, empresa);
            PersonalSinAsistenciaResumenConMarcacionTotal(fecha, Cod_Unidad, turno, empresa);
        }
        private void showDialogs(String message, Color bdColor)
        {
            Vista.MensajeEmergente.DialogForm dialog = new Vista.MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        }
        private void frmAsistenciaPersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerUnidadCentroControl(cboUnidad);
            Llenadocbo.ObtenerTurnoCentroControl(cboturnos);
            Llenadocbo.ObtenerHorasLaboralesCentroControl(cboHoras);
            Llenadocbo.ObtenerPersonalCentroControl(cboempleadoActivo);
          
            timer1.Enabled = true;
            cboHoras.SelectedIndex = 2;

            //llenado del combo del dgv
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "TipoAsistencia";
            Llenadocbo.ObtenerTipoAsistenciaCentroControl(dgvCmb);
            dgvCmb.Name = "TipoAsistencia";
            dgvAsistencia.Columns.Add(dgvCmb);

            dgvPersonalEstatura.RowHeadersVisible = false;
            dgvPersonalEstatura.AllowUserToAddRows = false;
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeCentroControl(cboCede, cod_unidad);
                Llenadocbo.ObtenerUnidadEmpresaCentroControl(cboEmpresa, cod_unidad);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de asistencia del  Personal";
            const string mensaje = "Estas seguro que deseas cerra el Registro de asistencia del Personal";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {  
                DateTime fecha = DateTime.Now;
                string detalle = "Salio del modulo de asistencia";
                string accion = "Cerro el Registro de asistencia del  Personal";
                
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboturnos.SelectedIndex != 0)
            {
                if (cboUnidad.SelectedIndex != 0)
                {
                    if (cboCede.SelectedIndex != 0)
                    {
                        if (cboHoras.SelectedIndex != 0)
                        {
                            try
                            {
                                string codUnidad = cboUnidad.SelectedValue.ToString();
                                string codSede = cboCede.SelectedValue.ToString();
                                int codTurno = cboturnos.SelectedIndex;
                                int empresa = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                                DateTime fecha_inicio = cboFechaInicio.Value;
                                SqlCommand comando = conexion.conexionBD().CreateCommand();
                                comando.CommandType = CommandType.Text;
                                comando.CommandText = "SP_BuscarEMpleadoUnidadSede @Cod_unidad, @Cod_sede,@Cod_Turno";
                                comando.Parameters.AddWithValue("Cod_unidad", codUnidad);
                                comando.Parameters.AddWithValue("Cod_sede", codSede);
                                comando.Parameters.AddWithValue("Cod_Turno", codTurno);
                                comando.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                SqlDataAdapter dta = new SqlDataAdapter(comando);
                                dta.Fill(dt);
                                dt.Columns[0].ColumnName = "Cod Empleado";
                                dt.Columns[1].ColumnName = "Trabajador";
                                dt.AcceptChanges();
                                dgvAsistencia.DataSource = dt;
                               // obtenerip_nombre();
                                DateTime fecha = DateTime.Now;
                                string detalle = "Buscar personal para asistencia unidad : " + codUnidad + " sede: " + codSede + " Turno : " + codTurno;
                                string accion = "Buscar personal Asistencia";
                                //string username = Code.nivelUser._nombre;
                                // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                               verificar(fecha_inicio, codUnidad, codTurno, empresa);
                                showDialogs("Datos Encontrados", Color.FromArgb(0, 200, 81));
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show("Error no se puede encontrar la lista del personal \n\n Verifique su conexion con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            //obtenerip_nombre();
                            DateTime fecha = DateTime.Now;
                            string detalle = "Falta ingresar o seleccionar una Hora Laboral";
                            string accion = "Falto Ingresar Hora Laboral - asistencia";
                           // string username = Code.nivelUser._nombre;
                           // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                            MessageBox.Show("Debe seleccionar una Hora Laboral ", "Verificar");
                            cboHoras.Focus();
                            showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                        }
                    }

                    else
                    {
                       // obtenerip_nombre();
                        DateTime fecha = DateTime.Now;
                        string detalle = "Falta ingresar o seleccionar una sede para registrar asistencia";
                        string accion = "Falto Ingresar sede - asistencia";
                        //string username = Code.nivelUser._nombre;
                       // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                        MessageBox.Show("Debe seleccionar una sede ", "Verificar");
                        cboCede.Focus();
                        showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                    }
                }
                else
                {
                 //   obtenerip_nombre();
                    DateTime fecha = DateTime.Now;
                    string detalle = "Falta ingresar o seleccionar una Unidad para registrar asistencia";
                    string accion = "Falto Ingresar Unidad - asistencia";
                 //   string username = Code.nivelUser._nombre;
                  //  registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                    MessageBox.Show("Debe seleccionar una Unidad ", "Verificar");
                    cboUnidad.Focus();
                    showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                }
            }
            else
            {
                //obtenerip_nombre();
                DateTime fecha1 = DateTime.Now;
                string detalle1 = "Falta ingresar o seleccionar un Turno para registrar asistencia";
                string accion1 = "Falto Ingresar Turno - asistencia";
                //string username1 = Code.nivelUser._nombre;
                //registrar.RegistrarTareaje(fecha1, nombrepc, username1, ipuser, detalle1, accion1);
                MessageBox.Show("Debe seleccionar un turno ", "Verificar");
                cboturnos.Focus();
                showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnBuscarAVP_Click(object sender, EventArgs e)
        {
            if (txtcodavp.Text.Length > 0)
            {
                txtcodavp.Text = "";
            }
            string dni_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = new SqlCommand("select Cod_empleado from t_mae_personal   WHERE Cod_empleado = '" + dni_empleado + "'", conexion.conexionBD());
                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtcodavp.Text = recorre["Cod_empleado"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE ENCONTRO AL EMPLEADO VERIFIQUE EL CODIGO \n\n" + ex, "ERROR");

            }
        }

        private void btnGuardadAsistencia_Click(object sender, EventArgs e)
        {
            int codTurno = cboturnos.SelectedIndex;
            int HoraLaboradas = cboHoras.SelectedIndex;
            string codunidad = cboUnidad.SelectedValue.ToString();
            string codSede = cboCede.SelectedValue.ToString();
            string hora = lblHora.Text;
            DateTime FechaInicio = cboFechaInicio.Value;

            int empresa =Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
             

            const string titulo = "Guardar Datos en el Sistema";
            const string mensaje = "Porfavor verificar  la asistencia antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICACION DE DATOS";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {

                try
                {
                   SqlCommand comando = new SqlCommand("SP_registrarAsistencia @Cod_empleado, @cod_unidad, @Cod_sede, @id_empresa, @id_TipoAsistencia,@Cod_turno,@FechaMarcacion,@ID_HORAS_LABORALES,@HoraRegistroMarcacion", conexion.conexionBD());

                    foreach (DataGridViewRow row in dgvAsistencia.Rows)
                   {
                      if (row.Cells["Cod Empleado"].Value != null && row.Cells["TipoAsistencia"].Value != null)
                      {
                              comando.Parameters.Clear();
                              comando.Parameters.AddWithValue("@Cod_empleado", Convert.ToString(row.Cells["Cod Empleado"].Value));
                              comando.Parameters.AddWithValue("@cod_unidad", SqlDbType.VarChar).Value = codunidad;
                              comando.Parameters.AddWithValue("@Cod_sede", SqlDbType.VarChar).Value = codSede;
                              comando.Parameters.AddWithValue("@id_empresa", SqlDbType.Int).Value = empresa;
                              comando.Parameters.AddWithValue("@id_TipoAsistencia", Convert.ToString(row.Cells["TipoAsistencia"].Value));
                              comando.Parameters.AddWithValue("@Cod_turno", SqlDbType.Int).Value = codTurno;
                              comando.Parameters.AddWithValue("@FechaMarcacion", SqlDbType.VarChar).Value = FechaInicio;
                              comando.Parameters.AddWithValue("@ID_HORAS_LABORALES", SqlDbType.Int).Value = HoraLaboradas;
                              comando.Parameters.AddWithValue("@HoraRegistroMarcacion", SqlDbType.VarChar).Value = hora;   
                              comando.ExecuteNonQuery();

                        /*   Registrarmysql.RegistroAsistencia(Convert.ToString(row.Cells["TipoAsistencia"].Value), Convert.ToString(row.Cells["Cod Empleado"].Value),
                              FechaInicio.ToString(),codSede, codunidad, FechaInicio);*/
                      }
                    }
                   MessageBox.Show("Datos registrado correptamente");
                   //limpiar datos del datagriview 
                   DataTable dt = (DataTable)dgvAsistencia.DataSource;
                   dt.Clear();
                  // obtenerip_nombre();
                   DateTime fecha = DateTime.Now;
                   string detalle = "Registro de asistencia Turno : " + codTurno + " Unidad : " + codunidad +
                   " sede : " + codSede;
                   string accion = "Registro de Asistencia del Personal";
                    // string username = Code.nivelUser._nombre;
                    // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                   // verificar(FechaInicio, codunidad, codTurno,empresa);
                    showDialogs("Datos Registrados", Color.FromArgb(0, 200, 81));
                }
                catch (Exception ex)
                {
                   MessageBox.Show(" No se pudo realizar el guardado del la asistencia del personal \n\n Verifique su conexion al Servidor " + ex,"Error");
                   showDialogs("ERROR", Color.FromArgb(255, 53, 71));
                }
            }
            else
            {
              //  obtenerip_nombre();
                MessageBox.Show("Porfavor verificar Datos", "Verificacion de datos");
                DateTime fecha = DateTime.Now;
                string detalle = "Verifica el Registro de asistencia Turno : " + codTurno + " Unidad : " + codunidad +
                " sede : " + codSede;
                string accion = "Verificacion de asistencia del personal";
                //string username = Code.nivelUser._nombre;
                //registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                showDialogs("Verificacion de datos", Color.FromArgb(255, 187, 51));
            }
        }
        private void btnRenganche_Click(object sender, EventArgs e)
        {
            if (cboturnos.SelectedIndex != 0)
            {
                if (cboUnidad.SelectedIndex != 0)
                {
                    if (cboCede.SelectedIndex != 0)
                    {
                        if(cboEmpresa.SelectedIndex != 0)
                        {
                           // obtenerip_nombre();

                            DateTime fecha = DateTime.Now;
                            string detalle = "Ingreso al modulo de Renganche de Personal";
                            string accion = "Modulo Renganche";
                           // string username = Code.nivelUser._nombre;
                           // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);

                            Vista.CentroControl.frmRenganchePersonal objRenganche = new frmRenganchePersonal();
                            objRenganche._fecha = cboFechaInicio.Value;
                            objRenganche._cod_unidad = cboUnidad.SelectedValue.ToString();
                            objRenganche.cod_sede = cboCede.SelectedValue.ToString();
                            objRenganche._turno = cboturnos.SelectedIndex;
                            objRenganche._empresa =Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                            objRenganche._hora =  lblHora.Text;
                            objRenganche._horastrabajo = cboHoras.SelectedIndex;
                            objRenganche.ShowDialog();
                        }
                        else
                        {
                            //  obtenerip_nombre();
                            DateTime fecha = DateTime.Now;
                            string detalle = "Falta ingresar o seleccionar la Empresa";
                            string accion = "Falto Ingresar Empresa";
                            //string username = Code.nivelUser._nombre;
                            //registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                            MessageBox.Show("Debe seleccionar una Empresa ", "Verificar");
                            cboCede.Focus();
                            showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                        }
                    }
                    else
                    {
                      //  obtenerip_nombre();
                        DateTime fecha = DateTime.Now;
                        string detalle = "Falta ingresar o seleccionar una sede";
                        string accion = "Falto Ingresar sede";
                        //string username = Code.nivelUser._nombre;
                        //registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                        MessageBox.Show("Debe seleccionar una sede ", "Verificar");
                        cboCede.Focus();
                        showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                    }
                }
                else
                {
                    //obtenerip_nombre();
                    DateTime fecha = DateTime.Now;
                    string detalle = "Falta ingresar o seleccionar una Unidad";
                    string accion = "Falto Ingresar Unidad";
                    //string username = Code.nivelUser._nombre;
                    //registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                    MessageBox.Show("Debe seleccionar una Unidad ", "Verificar");
                    cboUnidad.Focus();
                    showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                }
            }
            else
            {
                //obtenerip_nombre();
                DateTime fecha = DateTime.Now;
                string detalle = "Falta ingresar o seleccionar un Turno";
                string accion = "Falto Ingresar Turno";
              //  string username = Code.nivelUser._nombre;
               // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                MessageBox.Show("Debe seleccionar un turno ", "Verificar");
                cboturnos.Focus();
                showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
            }
        }

        private void btnTardanza_Click(object sender, EventArgs e)
        {
            if (cboturnos.SelectedIndex != 0)
            {
                if (cboUnidad.SelectedIndex != 0)
                {
                    if (cboCede.SelectedIndex != 0)
                    {
                        if (cboEmpresa.SelectedIndex != 0)
                        {
                            // obtenerip_nombre();

                            DateTime fecha = DateTime.Now;
                            string detalle = "Ingreso al modulo de Renganche de Personal";
                            string accion = "Modulo Renganche";
                            // string username = Code.nivelUser._nombre;
                            // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);

                            Vista.CentroControl.frmTardanza frmTardanza = new frmTardanza();
                            frmTardanza._fecha = cboFechaInicio.Value;
                            frmTardanza._cod_unidad = cboUnidad.SelectedValue.ToString();
                            frmTardanza.cod_sede = cboCede.SelectedValue.ToString();
                            frmTardanza._turno = cboturnos.SelectedIndex;
                            frmTardanza._empresa = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                            frmTardanza._hora = lblHora.Text;
                            frmTardanza._horastrabajo = cboHoras.SelectedIndex;
                            frmTardanza.ShowDialog();
                        }
                        else
                        {
                            //  obtenerip_nombre();
                            DateTime fecha = DateTime.Now;
                            string detalle = "Falta ingresar o seleccionar la Empresa";
                            string accion = "Falto Ingresar Empresa";
                            //string username = Code.nivelUser._nombre;
                            //registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                            MessageBox.Show("Debe seleccionar una Empresa ", "Verificar");
                            cboCede.Focus();
                            showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                        }
                    }
                    else
                    {
                        //  obtenerip_nombre();
                        DateTime fecha = DateTime.Now;
                        string detalle = "Falta ingresar o seleccionar una sede";
                        string accion = "Falto Ingresar sede";
                        //string username = Code.nivelUser._nombre;
                        //registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                        MessageBox.Show("Debe seleccionar una sede ", "Verificar");
                        cboCede.Focus();
                        showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                    }
                }
                else
                {
                    //obtenerip_nombre();
                    DateTime fecha = DateTime.Now;
                    string detalle = "Falta ingresar o seleccionar una Unidad";
                    string accion = "Falto Ingresar Unidad";
                    //string username = Code.nivelUser._nombre;
                    //registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                    MessageBox.Show("Debe seleccionar una Unidad ", "Verificar");
                    cboUnidad.Focus();
                    showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                }
            }
            else
            {
                //obtenerip_nombre();
                DateTime fecha = DateTime.Now;
                string detalle = "Falta ingresar o seleccionar un Turno";
                string accion = "Falto Ingresar Turno";
                //  string username = Code.nivelUser._nombre;
                // registrar.RegistrarTareaje(fecha, nombrepc, username, ipuser, detalle, accion);
                MessageBox.Show("Debe seleccionar un turno ", "Verificar");
                cboturnos.Focus();
                showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
            }
        }
    }
}