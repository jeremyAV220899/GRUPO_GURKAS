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
    public partial class frmTardanza : Form
    {
        public DateTime _fecha;
        public string _cod_unidad;
        public string cod_sede;
        public int _turno;
        public int _empresa;
        public string _hora;
        public int _horastrabajo;

        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.frmLlenadoDeDatosCentroControl Llenadocbo = new Datos.frmLlenadoDeDatosCentroControl();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.registrar Registrar = new Datos.registrar();
        Datos.Actualizar Actualizar = new Datos.Actualizar();
        Datos.agregarDatosMysql Registrarmysql = new Datos.agregarDatosMysql();
        public frmTardanza()
        {
            InitializeComponent();
        }
        private void showDialogs(String message, Color bdColor)
        {
            Vista.MensajeEmergente.DialogForm dialog = new Vista.MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        }
        private void GuardarRenganche(string cod_empleado, string unidad, string sede, int empresa, string tipo_asistencia, DateTime fecha, int turno, int horas_laborales, string hora)
        {
            const string titulo = "Guardar Datos en el Sistema";
            const string mensaje = "Porfavor verificar  el RENGANCHE antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICACION DE DATOS";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_registrar_renganche ", conexion.conexionBD());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
                    cmd.Parameters.AddWithValue("@cod_unidad", SqlDbType.VarChar).Value = unidad;
                    cmd.Parameters.AddWithValue("@Cod_sede", SqlDbType.VarChar).Value = sede;
                    cmd.Parameters.AddWithValue("@id_empresa", SqlDbType.Int).Value = empresa;
                    cmd.Parameters.AddWithValue("@id_TipoAsistencia", SqlDbType.VarChar).Value = tipo_asistencia;
                    cmd.Parameters.AddWithValue("@Cod_turno", SqlDbType.Int).Value = turno;
                    cmd.Parameters.AddWithValue("@FechaMarcacion", SqlDbType.VarChar).Value = fecha;
                    cmd.Parameters.AddWithValue("@ID_HORAS_LABORALES", SqlDbType.Int).Value = horas_laborales;
                    cmd.Parameters.AddWithValue("@HoraRegistroMarcacion", SqlDbType.VarChar).Value = hora;
                    cmd.ExecuteNonQuery();


                  /*  Registrarmysql.RegistroAsistencia(tipo_asistencia, cod_empleado,
                        fecha.ToString(), sede, unidad, fecha);*/

                    //obtenerip_nombre();
                    DateTime fechas = DateTime.Now;
                    string detalle = "Registro de Personal Renganche codigo : " + cod_empleado;
                    string accion = "Renganche de Personal";
                    //string username = Code.nivelUser._nombre;
                    //    Registrar.RegistrarTareaje(fechas, nombrepc, username, ipuser, detalle, accion);
                    MessageBox.Show("Datos registrado correptamente");
                    showDialogs("Dato Guardado", Color.FromArgb(0, 200, 81));

                }
                catch (Exception EX)
                {
                    MessageBox.Show("ERROR AL REGISTRAR DATOS \n\n" + EX);
                    showDialogs("ERROR", Color.FromArgb(255, 53, 71));
                }
            }
            else
            {
                //obtenerip_nombre();
                DateTime fechas = DateTime.Now;
                string detalle = "Verificacion de Registro de Personal Renganche codigo : " + cod_empleado;
                string accion = "Verificar Renganche de Personal";
                // string username = Code.nivelUser._nombre;
                // registrar.RegistrarTareaje(fechas, nombrepc, username, ipuser, detalle, accion);
                MessageBox.Show("Porfavor verificar Datos", "Verificacion de datos");
                showDialogs("Verificacion de datos", Color.FromArgb(255, 187, 51));
            }

        }
        private void frmTardanza_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalCentroControl(cboempleadoActivo);
            //llenadocbo.ObtenerSede(cboCede);
            //string cod_unidad = cboUnidad.SelectedValue.ToString();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = _fecha;
            string unidad = _cod_unidad;
            string sede = cod_sede;
            int turno = _turno;
            int empresa = _empresa;
            string hora = _hora;
            int horas_trabajadas = _horastrabajo;
            string tipo_marcacion = "T";
            string Cod_Personal = cboempleadoActivo.SelectedValue.ToString();

            GuardarRenganche(Cod_Personal, unidad, sede, empresa, tipo_marcacion, fecha, turno, horas_trabajadas, hora);
        }
    }
}
