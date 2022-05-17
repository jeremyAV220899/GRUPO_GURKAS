using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Principal
{
    public partial class frmPrincipalConsorcioGurkas : Form
    {
        public int _idempresa;
        public string _nombreempresa;
        public string _usuario;
        public string _perfil;
        public int _codrol;
        string ipuser = "";
        string nombrepc = "";
        string result = "";
        int estado = 0;

        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        Vista.ControlVistaFormulario controlvistaformulario = new Vista.ControlVistaFormulario();
        public frmPrincipalConsorcioGurkas()
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
                ipuser = "Direccion IP: " + hostIPs[i].ToString();

            }
            nombrepc = "Nombre de la computadora: " + strHostName;
        }

        public void perfiles()
        {
            int nivel = _codrol;
            if (nivel == 1)
            {
                recursosHumanosToolStripMenuItem.Enabled = true;
                centroDeControlToolStripMenuItem.Enabled = true;
                operacionesToolStripMenuItem.Enabled = true;
                comercialToolStripMenuItem.Enabled = true;
                logisticaToolStripMenuItem.Enabled = true;
                planillaToolStripMenuItem.Enabled = true;
                contabilidadToolStripMenuItem.Enabled = true;
                sucamecToolStripMenuItem.Enabled = true;
                administradorToolStripMenuItem.Enabled = true;
            }
            if (nivel == 2)
            {
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 3)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                //centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 4)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                //operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 5)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                // comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 6)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                // logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 7)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                //planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 8)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                //contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 9)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                //sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
        }
        private void frmPrincipalConsorcioGurkas_Load(object sender, EventArgs e)
        {
            lblempresanombre.Text = _nombreempresa;
            lblperfil.Text = _perfil;
            lblusuario.Text = _usuario;
            IsMdiContainer = true;
            perfiles();
        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void conexionAhInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Uri Url = new System.Uri("http://www.google.com/");
            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objResp;
            try
            {
                DateTime fecha = DateTime.Now;
                String anio = Convert.ToString(fecha.Year);
                objResp = WebRequest.GetResponse();
                result = "Su dispositivo está correctamente conectado a internet " + " Copyright © " + anio;
                estado = 1;
                objResp.Close();
                WebRequest = null;
                MessageBox.Show(result, "Conexion Exitosa");
            }
            catch (Exception ex)
            {
                result = "Error al intentar conectarse a internet ";
                estado = 2;
                WebRequest = null;
                MessageBox.Show(result, "Sin Conexion");
            }
        }

        private void conexionAlServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ping Pings = new Ping();
            int timeout = 10;

            if (Pings.Send("26.11.117.148", timeout).Status == IPStatus.Success)
            {
                DateTime fecha = DateTime.Now;
                String anio = Convert.ToString(fecha.Year);
                result = "Su dispositivo está correctamente conectado  al servidor " + " Copyright © " + anio;
                estado = 1;
                MessageBox.Show(result, "Conexion Exitosa");
            }
            else
            {
                result = "Error al intentar conectarse al sistema \n Verificar la conexion de la red VPN";
                estado = 2;
                MessageBox.Show(result, "Sin Conexion");
            }
        }

        private void vercionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modulo.auditoria("Archivos", "Comprobar la vercion del sistema  Gurkas", "", "");
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Sesión";
            const string mensaje = "Estas seguro que deseas Cerrar Sesión";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                obtenerip_nombre();

                modulo.auditoria("Archivos", "Cerrar Sesión Sistema", "", "");

                this.Close();
                Vista.frmLogin objLogin = new Vista.frmLogin();
                objLogin.Show();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string titulo = "Exit";
            const string mensaje = "Estas seguro que deseas Cerrar el Sistema";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                obtenerip_nombre();

                modulo.auditoria("Archivos", "Salir del Sistema por Completo", "", "");

                Application.Exit();
            }
        }

        private void registroDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistroDatosPersonal());
            modulo.auditoria("Recursos Humanos", "Personal", "Registro de Datos Personales RRHH", "");

        }

        private void registroDeDatosFamiliaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistroDatosFamiliarez());
            modulo.auditoria("Recursos Humanos", "Personal", "Registro de Datos Familiares RRHH", "");

        }

        private void registroDeDatosLaboralesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistrarDatosLaboralesRRHH());
            modulo.auditoria("Recursos Humanos", "Personal", "Registro de Datos Laborales RRHH", "");

        }

        private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmReporteGenrenalPersonal());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte General", "");

        }

        private void personalPorUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorUnidad());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Personal", "Personal Por Unidad");

        }

        private void personalPorSedeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorSede());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Personal", "Personal Por Sede");

        }

        private void personalPorEdadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEdad());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Personal", "Personal Por Edad");

        }

        private void personalPorEmpresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEmpresa());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Personal", " / Personal Por Empresa");

        }

        private void personalPorEstaturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmEstaturaPersonal());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Personal", "Personal Por Estatura");

        }

        private void personalPorTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmTurnoEmpleado());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Personal", "Personal Por Turno");

        }

        private void personalPorFechaInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorFechaIngreso());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Personal", "Personal Por Fecha Ingreso");

        }

        private void asistenciaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.frmAsistenciaPersonal());
            modulo.auditoria("Modulo de Centro de Control", "Tareaje de Personal", "", "");

        }

        private void asistenciaDePersonalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonaIndividual());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Asistencia de Personal", "Asistencia de Personal");

        }

        private void asistenciaGeneralDePersoanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGneralPersonal());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Asistencia de Personal", "Asistencia de General de Personal");

        }

        private void asistenciaPorUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonalPorUnidad());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Asistencia de Personal", "Asistencia de Personal");

        }

        private void asistenciaPorSedeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGeneralPersonalPorSede());
            modulo.auditoria("Recursos Humanos", "Modulo de Reporte", "Reporte de Asistencia de Personal", "Asistencia por Sede");

        }

        private void reporteDeAsistenciaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bajaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Baja de Personal","");

        }

        private void moverPersonalEntreEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmMoverEmpresa());
            modulo.auditoria("Recursos Humanos", "Mover Personal Entre Empresa", "", "");

        }

        private void estadoDelPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new RRHH.frmActualizarEstadoPersonal());
            modulo.auditoria("Recursos Humanos", "Modulo de Estado de Personal", "", "");

        }

        private void cargaMasivaDeDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.CargaDatos.frmCargaDatosIngresantesPlanillas());
            modulo.auditoria("Recursos Humanos", "Carga Masiva de los Datos Laborales", "", "");

        }

        private void cantidadDeAsistencaiDeCadaSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmConsultaDeCantidadDeAsistenciaDeCadaSede());
            modulo.auditoria("Centro de Control", "Reportes - C. CONTROL", "Cantidad de Asistencia de Cada Sede", "");

        }

        private void marcacionPorFechaYTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmReportedeMarcacionpoFecahYturno());
            modulo.auditoria("Centro de Control", "Reportes - C. CONTROL", "Marcacion por Fecha y Turno", "");

        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.fmrConsultaDeAsistenciaPorPersonal());
            modulo.auditoria("Centro de Control", "Reportes - C. CONTROL", "Consulta de Asistencia por personal", "");

        }

        private void asistenciaGeneralDelPersonalDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmAsistenciaDetalladoPorEmpleado());
            modulo.auditoria("Centro de Control", "Reportes - C. CONTROL", "Asistencia General del Personal Detallado", "");

        }

        private void asistenciaDePersonalPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalsistenciaporDia());
            modulo.auditoria("Centro de Control", "Reporte Asistencia", "Asistencia de Personal por Dia", "");

        }

        private void personalSinMarcacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalSinMarcacion());
            modulo.auditoria("Centro de Control", "Reporte Asistencia", "Personal sin Marcacion", "");

        }

        private void asistenciaDePersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmAsistenciadePersonal());
            modulo.auditoria("Centro de Control", "Reporte Asistencia", "Asistencia de Personal", "");

        }

        private void asistenciaDePersonalDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmAsistenciaDePersonalDetallado());
            modulo.auditoria("Centro de Control", "Reporte Asistencia", "Asistencia de Personal Detallado", "");

        }

        private void reporteDeBloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmBloqueosPersonal());
            modulo.auditoria("Centro de Control", "Bloqueos de Personal", "Reporte de Bloqueos de Personal", "");

        }

        private void bloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.CargaDeDatos.frmBloqueosPersonal());
            modulo.auditoria("Centro de Control", "Bloqueos de Personal", "Carga de Bloqueos de Personal", "");

        }

        private void activarUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.Unidad.frmActivarUnidad());
            modulo.auditoria("Operaciones", "Unidad", "Activar Unidad", "");

        }

        private void activarSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.Sede.frmSede());
            modulo.auditoria("Operaciones", "Sede", "Activar Sede", "");

        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmConsultadeAsistenciaPersonal());
            modulo.auditoria("Operaciones", "Reporte", "Consulta de Asistencia por Personal", "");

        }

        private void personalSinMarcacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalSinMarcacion());
            modulo.auditoria("Operaciones", "Reporte", "Personal sin Marcacion", "");

        }

        private void estadoDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmEstadoPersonal());
            modulo.auditoria("Operaciones", "Reporte", "Estado de Personal", "");

        }

        private void crearUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.frmCreacionUnidad());
            modulo.auditoria("Comercial", "Unidad", "Creacion de Unidad", "");

        }

        private void creacionDeSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.frmCreacionSedes());
            modulo.auditoria("Comercial", "Sede", "Creacion de Sede", "");

        }

        private void asistenciaDePersonalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmAsistenciaPersonal());
            modulo.auditoria("Comercial", "Reporte", "Asistencia de Personal", "");

        }

        private void asistenciaDePersonalDetalladoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmAsistenciaPersonalDetallado());
            modulo.auditoria("Comercial", "Reporte", "Asistencia de Personal Detallado", "");

        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmConusltaAsistenciaPersonal());
            modulo.auditoria("Comercial", "Reporte", "Consulta de Asistencia por Personal", "");

        }

        private void detalleDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmDetalleEmpleado());
            modulo.auditoria("Comercial", "Reporte", "Detalle de Empleados", "");

        }

        private void codigoYEstadoPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Logistica.Reporte.frmReportePersonal());
            modulo.auditoria("Logistica", "Reportes", "Codigo y Estado Personal", "");

        }

        private void nuevaEntradaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.entrada.frmEntradaProducto());
            modulo.auditoria("Logistica", "Almacen", "Entrada de Producto", "Nueva entrada de Producto");

        }

        private void buscarSalidaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.entrada.frmBuscarEntradaProducto());
            modulo.auditoria("Logistica", "Almacen", "Entrada de Producto", "Buscar entrada de Producto");

        }

        private void historialDeSalidaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.entrada.HistorialEntradaProducto());
            modulo.auditoria("Logistica", "Almacen", "Entrada de Producto", "Historial de Entrada de Producto");

        }

        private void nuevaSalidaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.salida.frmSalidaDeProducto());
            modulo.auditoria("Logistica", "Almacen", "Salida de Producto", "Nueva Salida de Producto");

        }

        private void buscarSalidaDeProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.salida.frmBuscarSalidaProducto());
            modulo.auditoria("Logistica", "Almacen", "Salida de Producto", "Buscar Salida de Producto");

        }

        private void historialDeSalidaDeProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.salida.frmHistorialSalidaProducto());
            modulo.auditoria("Logistica", "Almacen", "Salida de Producto", "Historial de Salida de Producto");

        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.producto.frmNuevoProducto());
            modulo.auditoria("Logistica", "Almacen", "Producto en Almacen", "Nuevo Producto");

        }

        private void registrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.Proveedores.frmRegistrarProveedor());
            modulo.auditoria("Logistica", "Almacen", "Proveedores", "Registrar Proveedor");

        }

        private void listaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modulo.auditoria("Logistica", "Almacen", "Proveedores", "Lista de Proveedores");

        }

        private void inventariadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Planillas
        private void registroDeDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmRegistrarDatosLaborales());
            modulo.auditoria("Planilla", "Personal", "Datos Laborales Empleados", "");

        }

        private void actualizarDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmActualizarDatosLaboralesPlanilla());
            modulo.auditoria("Planilla", "Personal", "Actualizar Laborales Empleados", "");

        }

        private void actualizarComisionAFPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.AFP.frmActualizarComisionAFP());
            modulo.auditoria("Planilla", "AFP", "Actualizar Comision AFP", "");

        }

        private void reporteDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmReporteAsistenciaPersonal());
            modulo.auditoria("Planilla", "Reporte", "Reporte de Asistencia", "");

        }

        private void reporteDeDatosGeneralesDePlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmDatosGeneralesPlanilla());
            modulo.auditoria("Planilla", "Reporte", "Reporte de Datos Generales de Planilla", "");

        }

        private void historialEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmHistorialDatosEmpleado());
            modulo.auditoria("Planilla", "Reporte", "Historial Empleado", "");

        }

        private void bajasDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
            modulo.auditoria("Planilla", "Reporte", "Bajas de Empleados", "");

        }

        private void marcacionPorFechaYTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmReportedeMarcacionpoFecahYturno());
            modulo.auditoria("Planilla", "Reporte", "Marcacion por Fecha y Turno", "");

        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.fmrConsultaDeAsistenciaPorPersonal());
            modulo.auditoria("Planilla", "Reporte", "Consulta de Asistencia por Personal", "");

        }

        private void reporteDeTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmPagoTurnosEmpleados());
            modulo.auditoria("Planilla", "Reporte", "Reporte de Turno", "");

        }

        private void archivoPLAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.Plame.frmPlataformaPlame());
            modulo.auditoria("Planilla", "PLAME", "Archivo PLAME", "");

        }

        private void calculoPorDiasLaboradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmPlataformaCalculoPlanilla());
            modulo.auditoria("Planilla", "Plataforma Planilla", "Calculo por Dias Laborados", "");

        }

        private void calculoDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeVacaciones());
            modulo.auditoria("Planilla", "Plataforma Planilla", "Calculo de Vacaciones", "");

        }

        private void calcularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeOtrasLicencia());
            modulo.auditoria("Planilla", "Plataforma Planilla", "Calculo de otras Licencias", "");

        }

        private void calculoDeDescansoMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeDescansoMedico());
            modulo.auditoria("Planilla", "Plataforma Planilla", "Calculo de Descanso Medico", "");

        }

        private void calculoDeCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.CTS.frmCalculoCTS());
            modulo.auditoria("Planilla", "Plataforma Planilla", "Calculo de CTS", "");

        }

        private void calculoGratificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.GRATIFICACION.frmCalculoGrati());
            modulo.auditoria("Planilla", "Plataforma Planilla", "Calculo Gratificacion", "");

        }

        private void cargaDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.CargaDeDatos.frmCargaDeDatosAsistencia());
            modulo.auditoria("Planilla", "Carga de Datos", "Carga de Asistencia", "");

        }

        private void cargaDeDatosCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.CTS.frmCargaDeDatosCTS());
            modulo.auditoria("Planilla", "Carga de Datos", "Carga de Datos CTS", "");

        }

        private void cargaDeDatosGratificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.GRATIFICACION.frmGuardarGrati());
            modulo.auditoria("Planilla", "Carga de Datos", "Carga de Datos Gratificacion", "");

        }

        private void cargaDeBloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.CargaDeDatos.frmBloqueosPersonal());
            modulo.auditoria("Planilla", "Carga de Datos", "Carga de Bloqueos de Personal", "");

        }

        private void historialDePlanillaPorDiasLaboradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialPlanillaDiasLaborados());
            modulo.auditoria("Planilla", "Historial Planilla", "Historial de planilla por dias laborados", "");

        }

        private void historialDePlanillaDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialPlanillaVacaciones());
            modulo.auditoria("Planilla", "Historial Planilla", "Historial de planilla de vacaciones", "");

        }

        private void historialDePlanillaDeOtrasLicenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialOtrasLicencias());
            modulo.auditoria("Planilla", "Historial Planilla", "Historial de planilla de otras licencias", "");

        }

        private void historialDePlanillaDeDescansoMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialDescansoMedico());
            modulo.auditoria("Planilla", "Historial Planilla", "Historial de planilla de descanso medico", "");

        }

        private void historialDePlanillaDeCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialCTS());
            modulo.auditoria("Planilla", "Historial Planilla", "Historial de planilla de CTS", "");

        }

        private void historialDePlanillaDeGratificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialGrati());
            modulo.auditoria("Planilla", "Historial Planilla", "Historial de planilla de Gratificacion", "");

        }

        private void listaDePersonalBloqueosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.Bloqueos.frmCuadroDeBloqueos());
            modulo.auditoria("Planilla", "Bloqueos Personal", "Lista de Personal Bloqueos", "");

        }

        private void sueldoPersonalUnidadSueldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.SueldoEmpleado.frmSueldoEmpleado());
            modulo.auditoria("Planilla", "Sueldo Unidad Puesto", "Sueldo Personal Unidad - Sueldo", "");

        }

        //SUCAMEC
        private void datosPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Sucamec.frmPersonalConsulta());
            modulo.auditoria("Sucamec", "Datos Personal", "", "");

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmReporteGenrenalPersonal());
            modulo.auditoria("Sucamec", "Reportes", "Reporte General", "");

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorUnidad());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Unidad");

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorSede());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Sede");

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEdad());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Edad");

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEmpresa());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Empresa");

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmEstaturaPersonal());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Estatura");

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmTurnoEmpleado());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Turno");

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorFechaIngreso());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Fecha Ingreso");

        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonaIndividual());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia de Personal");

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGneralPersonal());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia General de Personal");

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonalPorUnidad());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia por Unidad");

        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGeneralPersonalPorSede());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia por Sede");

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Reporte de Baja de Personal");

        }

        private void reporteDeAsistenciaPorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmConsultadeAsistenciaPersonal());
            modulo.auditoria("Sucamec", "Reporte de Asistencia por Personal", "", "");

        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void activarModoAdministradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmContrasena());
            modulo.auditoria("Administrador", "Activar Modo Administrador", "", "");

        }

        private void postulanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.Postulante.frmPostulante());
            modulo.auditoria("RRHH", "Modulo de postulante", "", "");
        }

        private void consultaDeAsistenciaPersonalCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmReportePersonalGeneral());
            modulo.auditoria("Operaciones", "Reporte", "Modulo de asistencia personal completo", "");
        }

        private void planillaPorUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Contabilidad.frmPlanillaCompletaContabilidadResumen());
            modulo.auditoria("Contabilidad", "Reporte", "Planilla por Unidad", "");
        }

        private void migrarAsistenciaAAndroidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.Android.frmMigrarAndroidAsistencia());
            modulo.auditoria("Modulo de Centro de Control", "Migracion de asistencia a android", "", "");
        }

        private void registroPersonalC4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.RRHHC4.frmRegistroC4());
            modulo.auditoria("Recursos Humanos", "Registro Personal C4", "", "");
        }

        private void personalActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmReporteRRHHPersonalActivo());
            modulo.auditoria("Recursos Humanos", "Personal Activo RRHH", "", "");
        }
    }
}

