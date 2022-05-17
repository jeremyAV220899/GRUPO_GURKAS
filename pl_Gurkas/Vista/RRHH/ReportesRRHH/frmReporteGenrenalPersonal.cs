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

namespace pl_Gurkas.Vista.RRHH.ReportesRRHH
{
    public partial class frmReporteGenrenalPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Datos.ExportarExcel Excel = new Datos.ExportarExcel();

        public frmReporteGenrenalPersonal()
        {
            InitializeComponent();
        }
        private void ConsultarAsistenciaPersonal(String Cod_Trabajador, DateTime fechaInicio, DateTime FechaFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_PersonalAsistenciaGeneralRRHH  @Cod_empleado,@fechainicio, @fechafin";
                comando.Parameters.AddWithValue("Cod_empleado", Cod_Trabajador);
                comando.Parameters.AddWithValue("fechainicio", fechaInicio);
                comando.Parameters.AddWithValue("fechafin", FechaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio";
                dt.Columns[6].ColumnName = "Sede ";
                dt.Columns[7].ColumnName = "Tipo Asistencia";
                dt.Columns[8].ColumnName = "Fecha Asistencia";
                dt.Columns[9].ColumnName = "Turno";
                dt.Columns[10].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void ConsultarAsistencia(DateTime fechaInicio, DateTime FechaFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHH_AsistenciaGeneralPersonalReporte  @fechaInicio, @FechaFin";
                comando.Parameters.AddWithValue("fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("FechaFin", FechaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio";
                dt.Columns[6].ColumnName = "Sede ";
                dt.Columns[7].ColumnName = "Tipo Asistencia";
                dt.Columns[8].ColumnName = "Fecha Asistencia";
                dt.Columns[9].ColumnName = "Turno";
                dt.Columns[10].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void ConsultarAsistenciaSede(DateTime fechaInicio, DateTime FechaFin, string Sede)
        {
            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHH_AsistenciaGeneralPersonalSede_ReporteGeneral @Sede, @fechaInicio, @FechaFin";
                comando.Parameters.AddWithValue("Sede", Sede);
                comando.Parameters.AddWithValue("fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("FechaFin", FechaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio";
                dt.Columns[6].ColumnName = "Sede ";
                dt.Columns[7].ColumnName = "Tipo Asistencia";
                dt.Columns[8].ColumnName = "Fecha Asistencia";
                dt.Columns[9].ColumnName = "Turno";
                dt.Columns[10].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception)
            {
                /*
                 MessageBox.Show("", "");
                */
                throw;
            }
        }
        private void ConsultarPersonalSede(string sede)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_PERSONALSEDE  @cod_sede";

                comando.Parameters.AddWithValue("cod_sede", sede);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void ConsultarAsistenciaCodigo(int CodEmpresa)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHHEmpresaPersonalGeneral  @Cod_empresa";
                comando.Parameters.AddWithValue("Cod_empresa", CodEmpresa);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }

        }
        private void ConsultarFechaIngreso(DateTime fechaInicio, DateTime FechaFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHHFechaIngresoGeneral  @fechaInicio, @FechaFin";
                comando.Parameters.AddWithValue("fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("FechaFin", FechaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Inicio";
                dt.Columns[6].ColumnName = "Puesto ";
                dt.Columns[7].ColumnName = "Sede";
                dt.Columns[8].ColumnName = "Turno";
                dt.Columns[9].ColumnName = "Estado Personal";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
        private void ConsultaMes (int mes)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHHMESCONSULTA  @mes";
                comando.Parameters.AddWithValue("mes", mes);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Estado Empleado";
                dt.Columns[1].ColumnName = "Cod Empleado";
                dt.Columns[2].ColumnName = "Empleado";
                dt.Columns[3].ColumnName = "Num Identidad";
                dt.Columns[4].ColumnName = "Edad";
                dt.Columns[5].ColumnName = "Empresa";
                dt.Columns[6].ColumnName = "Fecha Nacimineto";
                dt.Columns[7].ColumnName = "Fecha Emision";
                dt.Columns[8].ColumnName = "Fecha Vencimiento";
                dt.Columns[9].ColumnName = "Sexo";
                dt.Columns[10].ColumnName = "Nacionalidad ";
                dt.Columns[11].ColumnName = "Departamento ";
                dt.Columns[12].ColumnName = "Provincia ";
                dt.Columns[13].ColumnName = "Distrito ";
                dt.Columns[14].ColumnName = "Direccion ";
                dt.Columns[15].ColumnName = "Telefono";
                dt.Columns[16].ColumnName = "Celular";
                dt.Columns[17].ColumnName = "Talla Prenda";
                dt.Columns[18].ColumnName = "Talla Pantalon";
                dt.Columns[19].ColumnName = "Calzado";
                dt.Columns[20].ColumnName = "Estatura";
                dt.Columns[21].ColumnName = "Correo";
                dt.Columns[22].ColumnName = "Grado Instruccion";
                dt.Columns[23].ColumnName = "Brevete";
                dt.Columns[24].ColumnName = "Numero Brevete";
                dt.Columns[25].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }

        private void ConsultarAsistencia(int edadInicio, int EdadFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_RRHHEdadConsultageneral  @edadInica, @edadFinal";
                comando.Parameters.AddWithValue("edadInica", edadInicio);
                comando.Parameters.AddWithValue("edadFinal", EdadFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Estado Empleado";
                dt.Columns[1].ColumnName = "Cod Empleado";
                dt.Columns[2].ColumnName = "Empleado";
                dt.Columns[3].ColumnName = "Num Identidad";
                dt.Columns[4].ColumnName = "Edad";
                dt.Columns[5].ColumnName = "Empresa";
                dt.Columns[6].ColumnName = "Fecha Nacimineto";
                dt.Columns[7].ColumnName = "Fecha Emision";
                dt.Columns[8].ColumnName = "Fecha Vencimiento";
                dt.Columns[9].ColumnName = "Sexo";
                dt.Columns[10].ColumnName = "Nacionalidad ";
                dt.Columns[11].ColumnName = "Departamento ";
                dt.Columns[12].ColumnName = "Provincia ";
                dt.Columns[13].ColumnName = "Distrito ";
                dt.Columns[14].ColumnName = "Direccion ";
                dt.Columns[15].ColumnName = "Telefono";
                dt.Columns[16].ColumnName = "Celular";
                dt.Columns[17].ColumnName = "Talla Prenda";
                dt.Columns[18].ColumnName = "Talla Pantalon";
                dt.Columns[19].ColumnName = "Calzado";
                dt.Columns[20].ColumnName = "Estatura";
                dt.Columns[21].ColumnName = "Correo";
                dt.Columns[22].ColumnName = "Grado Instruccion";
                dt.Columns[23].ColumnName = "Brevete";
                dt.Columns[24].ColumnName = "Numero Brevete";
                dt.Columns[25].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");

            }

        }
        private void ConsultaEstaturas(decimal estaturaInicio, decimal estaturaFin)
        {

            try
            {
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_ESTATURAPersonalGeneral  @estaturainicial, @estaturafinal";
                comando.Parameters.AddWithValue("estaturainicial", estaturaInicio);
                comando.Parameters.AddWithValue("estaturafinal", estaturaFin);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Identidad";
                dt.Columns[3].ColumnName = "Fecha Nacimineto";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Fecha Emision";
                dt.Columns[6].ColumnName = "Fecha Vencimiento";
                dt.Columns[7].ColumnName = "Sexo";
                dt.Columns[8].ColumnName = "Nacionalidad ";
                dt.Columns[9].ColumnName = "Departamento ";
                dt.Columns[10].ColumnName = "Provincia ";
                dt.Columns[11].ColumnName = "Distrito ";
                dt.Columns[12].ColumnName = "Direccion ";
                dt.Columns[13].ColumnName = "Telefono";
                dt.Columns[14].ColumnName = "Celular";
                dt.Columns[15].ColumnName = "Talla Prenda";
                dt.Columns[16].ColumnName = "Talla Pantalon";
                dt.Columns[17].ColumnName = "Calzado";
                dt.Columns[18].ColumnName = "Estatura";
                dt.Columns[19].ColumnName = "Correo";
                dt.Columns[20].ColumnName = "Grado Instruccion";
                dt.Columns[21].ColumnName = "Brevete";
                dt.Columns[22].ColumnName = "Numero Brevete";
                dt.Columns[23].ColumnName = "Puesto";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro nungun resultado \n\n " + ex, "ERROR");
            }
        }
        private void ConsultarAsistenciaPorTurno()
        {
            try
            {
                int turno = cboTurno.SelectedIndex;
                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_REPORTERRHH_PorTurnoGeneral  " + turno;


                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Asistencia";
                dt.Columns[1].ColumnName = "Empleado";
                dt.Columns[2].ColumnName = "Num Documento";
                dt.Columns[3].ColumnName = "Fecha Nacimiento";
                dt.Columns[4].ColumnName = "Empresa";
                dt.Columns[5].ColumnName = "Turno";
                dt.AcceptChanges();
                dgvReporteGeneral.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro ningun resultado" + ex, "error");
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Personal";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Personal";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                // obtenerip_nombre();
               // string username = Code.nivelUser._nombre;
                string detalle = "Cerrar Registro de Personal";
                string cod_buscado = "Cerro el registro de Personal";
                // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                this.Close();
            }
        }

        private void frmReporteGenrenalPersonal_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerPersonalRRHHGeneral(cboempleadoActivo);
            Llenadocbo.ObtenerEmpresaRRHHGeneral(cboEmpresa);
            Llenadocbo.ObtenerUnidadRRHHGeneral(cboUnidad);
            Llenadocbo.ObtenerTurnoRRHH(cboTurno);
            Llenadocbo.ObtenerMesRRHH(cbomes);
            Llenadocbo.ObtenerUnidadRRHHGeneral(cbounidadsede);
            dgvReporteGeneral.RowHeadersVisible = false;
            dgvReporteGeneral.AllowUserToAddRows = false;
        }

        private void cbounidadsede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbounidadsede.SelectedValue.ToString() != null)
            {
                string cod_unidad = cbounidadsede.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeRRHH(cbosedeunidad, cod_unidad);
            }
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeRRHH(cboSede, cod_unidad);
            }
        }

        private void btnConsultarAsistecniaPersonal_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();

            ConsultarAsistenciaPersonal(cod_empleado, dtpfechai.Value, dtpfechaf.Value);
        }

        private void btnConsultarAsistecniaGeneralPesonal_Click(object sender, EventArgs e)
        {
            ConsultarAsistencia(dtpFechaInicioGeneralPersonal.Value, dtpFechaFinGeneralPersonal.Value);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sede = cbosedeunidad.SelectedValue.ToString();
            ConsultarAsistenciaSede(dtpSedePersonal.Value, dtpSedeFin.Value, sede);
        }

        private void btnConsultarPersonalSede_Click(object sender, EventArgs e)
        {
            string Sede = cboSede.SelectedValue.ToString();
            ConsultarPersonalSede(Sede);
        }

        private void btnConsultarPersonalEmpresa_Click(object sender, EventArgs e)
        {
            int cod_empresa = cboEmpresa.SelectedIndex;
            ConsultarAsistenciaCodigo(cod_empresa);
        }

        private void btnConsultarFechaIngreso_Click(object sender, EventArgs e)
        {
            ConsultarFechaIngreso(dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void txtEdadInicio_TextChanged(object sender, EventArgs e)
        {
            txtEdadFin.MaxLength = 2;
        }

        private void txtEdadFin_TextChanged(object sender, EventArgs e)
        {
            txtEdadInicio.MaxLength = 2;
        }

        private void btnConsultarEdadPersonal_Click(object sender, EventArgs e)
        {
            if (txtEdadInicio.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Edad Inicial", "Advertencia");
            }
            else if (txtEdadFin.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Edad Final", "Advertencia");
            }
            else
            {
                int edadInicio = (int)Convert.ToInt64(txtEdadInicio.Text);
                int EdadFin = (int)Convert.ToInt64(txtEdadFin.Text);
                ConsultarAsistencia(edadInicio, EdadFin);
            }
        }

        private void txtEstaturaInicial_TextChanged(object sender, EventArgs e)
        {
            txtEstaturaInicial.MaxLength = 4;
        }

        private void txtEstaturaFin_TextChanged(object sender, EventArgs e)
        {
            txtEstaturaFin.MaxLength = 4;
        }

        private void btnConsultarEstatura_Click(object sender, EventArgs e)
        {
            if (txtEstaturaInicial.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Estatura Inicial", "Advertencia");
            }
            else if (txtEstaturaFin.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Estatura Final", "Advertencia");
            }
            else
            {
                decimal estaturaInicio = Convert.ToDecimal(txtEstaturaInicial.Text);
                decimal estaturaFin = Convert.ToDecimal(txtEstaturaFin.Text);
                ConsultaEstaturas(estaturaInicio, estaturaFin);
            }
        }

        private void btnConsultarTurno_Click(object sender, EventArgs e)
        {
            ConsultarAsistenciaPorTurno();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportarDatosBarra(dgvReporteGeneral, progressBar1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mes = cbomes.SelectedIndex;
            ConsultaMes(mes);
        }
    }
}
