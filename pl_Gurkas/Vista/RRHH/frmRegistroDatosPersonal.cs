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

namespace pl_Gurkas.Vista.RRHH
{
    public partial class frmRegistroDatosPersonal : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ConexionMysql conexionmysql = new Datos.ConexionMysql();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.registrar registrar = new  Datos.registrar();
        Datos.agregarDatosMysql registrarmysql = new Datos.agregarDatosMysql();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Datos.actualizarmysql actualizarmysql = new Datos.actualizarmysql();
        public frmRegistroDatosPersonal()
        {
            InitializeComponent();
        }
        private void showDialogs(String message, Color bdColor)
        {
            Vista.MensajeEmergente.DialogForm dialog = new Vista.MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        }
        private void ValidarCamposVacios()
        {
            if (cboTipoDocIdentEmp.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Documento", "Advertencia");
            }
            if (cboArmado.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar si el tranajador es armado", "Advertencia");
            }
            if (cboSexoEmp.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Sexo", "Advertencia");
            }
            if (cboBrevete.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Brevete", "Advertencia");
            }
            if (cboNacionalidad.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Nacionalidad", "Advertencia");
            }
            if (cboDepartamento.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Departamento", "Advertencia");
            }
            if (cboProvincia.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Provincia", "Advertencia");
            }
            if (cboDis.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Distrito", "Advertencia");
            }
            if (cboHorasLaborales.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Cantidad de Horas de Trabajo", "Advertencia");
            }
            if (cboEstadoCivilEmp.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Estado Civil", "Advertencia");
            }
            if (cboGradoInstruccionEmp.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Grado de Instruccion", "Advertencia");
            }
            if (cboEstadoEmp.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Estado", "Advertencia");
            }
            if (cboCargoLaboral.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Cargo Laboral", "Advertencia");
            }
            if (cboEmpresa.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Empresa", "Advertencia");
            }
            if (cboTipoContratoEmp.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Contrato", "Advertencia");
            }
            if (cboUnidad.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Unida", "Advertencia");
            }
            if (cboSede.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Sede", "Advertencia");
            }
            if (cboTurnoEmp.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Turno", "Advertencia");
            }
            if (cboTallaPrenda.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Talla de Prenda", "Advertencia");
            }
            if (txtCodEmpleado.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Codigo", "Advertencia");
            }
            if (txtNombreEmp.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Nombre", "Advertencia");
            }
            if (txtApPaternoEmp.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Apellido Paterno", "Advertencia");
            }
            if (txtApMateEmp.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Apellido Materno", "Advertencia");
            }
            if (txtNumDocIdentEmpl.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Numero de Identidad", "Advertencia");
            }
            if (txtNumDocIdentEmpl.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Direccion", "Advertencia");
            }
            if (txtCelular.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Numero de Celular", "Advertencia");
            }
            if (txtTelefono.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Numero Telefonico", "Advertencia");
            }
            if (txtCorreo.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Correo", "Advertencia");
            }
            if (txtTallaCalzadoEmp.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Talla de Calzado", "Advertencia");
            }
            if (txtTallaPantalonEmp.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Talla de Pantalon", "Advertencia");
            }
            if (txtEstaturaEmp.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Estatura", "Advertencia");
            }
        }
        private void ActualizarPersonal()
        {
            try
            {
                string codEmpleado = txtCodEmpleado.Text;
                string Nombre = txtNombreEmp.Text;
                string ApPaterno = txtApPaternoEmp.Text;
                string ApMaterno = txtApMateEmp.Text;
                string NombreCompleto = txtApPaternoEmp.Text + " " + txtApMateEmp.Text + " " + txtNombreEmp.Text;
                int edad = (int)Convert.ToInt64(txtEdadEmp.Text);
                int tipoDoc = cboTipoDocIdentEmp.SelectedIndex;
                string NumDOc = txtNumDocIdentEmpl.Text;
                int sexo = cboSexoEmp.SelectedIndex;
                DateTime Femision = dtpEmicion.Value;
                DateTime Fcaducacion = dtpCaducacion.Value;
                DateTime Fnacimineto = dtpNacimiento.Value;
                int brevete = cboBrevete.SelectedIndex;
                string nbrevete = txtNumBrevete.Text;
                int Nacionalidad = cboNacionalidad.SelectedIndex;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string Domicilio = txtDomicilio.Text;
                int Telefono = (int)Convert.ToInt64(txtTelefono.Text);
                int Celular = (int)Convert.ToInt64(txtCelular.Text);
                string Correo = txtCorreo.Text;
                int GradoInstruccion = cboGradoInstruccionEmp.SelectedIndex;
                int EstadoCivil = cboEstadoCivilEmp.SelectedIndex;
                string codUbigeo = txtCodUbigeo.Text;

                int EstadoPersonal = cboEstadoEmp.SelectedIndex;
                int CargoLaboral = cboCargoLaboral.SelectedIndex;
                int Empresa = cboEmpresa.SelectedIndex;
                int TipoContrato = cboTipoContratoEmp.SelectedIndex;
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;
                string Sede = cboSede.SelectedValue.ToString();
                string unidad = cboUnidad.SelectedValue.ToString();
                int turno = cboTurnoEmp.SelectedIndex;
                int hora = cboHorasLaborales.SelectedIndex;
                int tallacamisa = cboTallaPrenda.SelectedIndex;

                int tallapantalon = (int)Convert.ToInt64(txtTallaPantalonEmp.Text);
                int tallacalzado = (int)Convert.ToInt64(txtTallaCalzadoEmp.Text);
                decimal estatura = Convert.ToDecimal(txtEstaturaEmp.Text);

                int Armado = cboArmado.SelectedIndex;
                DateTime fechaInicioLaboral = dtpFinicioLaboral.Value;
                DateTime fechaFinLaboral = dtpFechaFinLaboral.Value;
                DateTime FechaActivacion = dtpFechaActivacion.Value;
                DateTime FechaDestaque = dtpUltimoDestaque.Value;

              actualizar.ActualizarPersonal(codEmpleado, Nombre, ApPaterno, ApMaterno, NombreCompleto, edad,
                   tipoDoc, NumDOc, sexo, Femision, Fcaducacion, Fnacimineto, brevete, nbrevete, Nacionalidad,
                   codDep, codPro, codDist, Domicilio, Telefono, Celular, Correo, GradoInstruccion, EstadoCivil,
                   EstadoPersonal, CargoLaboral, Empresa, TipoContrato, fechaInicio, fechaFin, Sede, turno, tallacamisa,
                   tallapantalon, tallacalzado, estatura, hora, codUbigeo, unidad,Armado, fechaInicioLaboral, fechaFinLaboral, FechaActivacion, FechaDestaque);
                
                actualizarmysql.ActualizarPersonalUsuario(codEmpleado, Nombre, ApPaterno, ApMaterno,
                    NombreCompleto, NumDOc, unidad, Sede, CargoLaboral, EstadoPersonal);

                MessageBox.Show("Datos actualizado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox2);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                LimpiarDatos.LimpiarGroupBox(groupBox4);
                showDialogs("Datos Actualizados", Color.FromArgb(0, 200, 81));

            }
            catch (Exception err)
            {
                try
                {
                    MessageBox.Show("No se puede Actualizar el Regristrar del Personal, Verifique los campos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO  registro del personal" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    showDialogs("ERROR", Color.FromArgb(255, 53, 71));
                }
            }
        }
        private void LLenadoComboBox()
        {
            Llenadocbo.ObtenerEmpresaRRHH_2(cboEmpresa);
            Llenadocbo.ObtenerTipoDocumentoRRHH(cboTipoDocIdentEmp);
            Llenadocbo.ObtenerTipoSexoRRHH(cboSexoEmp);
            Llenadocbo.ObtenerBreveteRRHH(cboBrevete);
            Llenadocbo.ObtenerNacionalidadRRHH(cboNacionalidad);
            Llenadocbo.ObtenerHorasLaboralesdRRHH(cboHorasLaborales);
            Llenadocbo.ObtenerEstadoCivilRRHH(cboEstadoCivilEmp);
            Llenadocbo.ObtenerGradoInstruccionRRHH(cboGradoInstruccionEmp);
            Llenadocbo.ObtenerEstadoPersonalRRHH(cboEstadoEmp);
            Llenadocbo.ObtenerPuestolRRHH(cboCargoLaboral);
            Llenadocbo.ObtenerTipoContratoRRHH(cboTipoContratoEmp);
            Llenadocbo.ObtenerTurnoRRHH(cboTurnoEmp);
            Llenadocbo.ObtenerTallaRRHH(cboTallaPrenda);
            Llenadocbo.ObtenerEstadoArmadoRRHH(cboArmado);
            Llenadocbo.ObtenerDepartamentoRRHH(cboDepartamento);
         //   Llenadocbo.ObtenerUnidadRRHH(cboUnidad);
            Llenadocbo.ObtenerPersonalRRHH(cboempleadoActivo);
        }
        private void RegistrarPersonal()
        {
            try
            {
                string codEmpleado = txtCodEmpleado.Text;
                string Nombre = txtNombreEmp.Text;
                string ApPaterno = txtApPaternoEmp.Text;
                string ApMaterno = txtApMateEmp.Text;
                string NombreCompleto = txtApPaternoEmp.Text + " " + txtApMateEmp.Text + " " + txtNombreEmp.Text;
                int edad = (int)Convert.ToInt64(txtEdadEmp.Text);
                int tipoDoc = cboTipoDocIdentEmp.SelectedIndex;
                string NumDOc = txtNumDocIdentEmpl.Text;
                int sexo = cboSexoEmp.SelectedIndex;
                DateTime Femision = dtpEmicion.Value;
                DateTime Fcaducacion = dtpCaducacion.Value;
                DateTime Fnacimineto = dtpNacimiento.Value;
                int brevete = cboBrevete.SelectedIndex;
                string nbrevete = txtNumBrevete.Text;
                int Nacionalidad = cboNacionalidad.SelectedIndex;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string Domicilio = txtDomicilio.Text;
                int Telefono = (int)Convert.ToInt64(txtTelefono.Text);
                int Celular = (int)Convert.ToInt64(txtCelular.Text);
                string Correo = txtCorreo.Text;
                int GradoInstruccion = cboGradoInstruccionEmp.SelectedIndex;
                int EstadoCivil = cboEstadoCivilEmp.SelectedIndex;
                string codUbigeo = txtCodUbigeo.Text;

                int EstadoPersonal = cboEstadoEmp.SelectedIndex;
                int CargoLaboral = cboCargoLaboral.SelectedIndex;
                string Empresa = cboEmpresa.SelectedIndex.ToString();
                int emp = (int)Convert.ToInt64(Empresa);
                int TipoContrato = cboTipoContratoEmp.SelectedIndex;
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;
                string Sede = cboSede.SelectedValue.ToString();
                string unidad = cboUnidad.SelectedValue.ToString();
                int turno = cboTurnoEmp.SelectedIndex;
                int hora = cboHorasLaborales.SelectedIndex;
                int tallacamisa = cboTallaPrenda.SelectedIndex;

                int tallapantalon = (int)Convert.ToInt64(txtTallaPantalonEmp.Text);
                int tallacalzado = (int)Convert.ToInt64(txtTallaCalzadoEmp.Text);
                decimal estatura = Convert.ToDecimal(txtEstaturaEmp.Text);

                int Armado = cboArmado.SelectedIndex;
                DateTime fechaInicioLaboral = dtpFinicioLaboral.Value;
                DateTime fechaFinLaboral = dtpFechaFinLaboral.Value;
                DateTime FechaActivacion = dtpFechaActivacion.Value;
                DateTime FechaDestaque = dtpUltimoDestaque.Value;

               registrar.RegistrarPersonal(codEmpleado, Nombre, ApPaterno, ApMaterno, NombreCompleto, edad,
                   tipoDoc, NumDOc, sexo, Femision, Fcaducacion, Fnacimineto, brevete, nbrevete, Nacionalidad,
                   codDep, codPro, codDist, Domicilio, Telefono, Celular, Correo, GradoInstruccion, EstadoCivil,
                   EstadoPersonal, CargoLaboral, emp, TipoContrato, fechaInicio, fechaFin, Sede, turno, tallacamisa,
                   tallapantalon, tallacalzado, estatura, hora, codUbigeo, unidad,Armado,fechaInicioLaboral,fechaFinLaboral,FechaActivacion,FechaDestaque);
            
                registrarmysql.RegistrarPersonalUsuario(codEmpleado, Nombre, ApPaterno, ApMaterno,
                     NombreCompleto, NumDOc, unidad,Sede, CargoLaboral, EstadoPersonal);
                MessageBox.Show("Datos registrado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox2);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                LimpiarDatos.LimpiarGroupBox(groupBox4);
               // LimpiarDatos.LimpiarCampo(this);

                showDialogs("Datos Registrados", Color.FromArgb(0, 200, 81));
            }
            catch(Exception ex)
            {
                MessageBox.Show( ""+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
            }
        }

        private void cantidad_caracteres()
        {
            txtTelefono.MaxLength = 7;
            txtCelular.MaxLength = 9;
            txtTallaPantalonEmp.MaxLength = 2;
            txtTallaCalzadoEmp.MaxLength = 2;
            txtEstaturaEmp.MaxLength = 4;
            txtEdadEmp.MaxLength = 2;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.LimpiarGroupBox(groupBox2);
            LimpiarDatos.LimpiarGroupBox(groupBox3);
            LimpiarDatos.LimpiarGroupBox(groupBox4);
            //LimpiarDatos.LimpiarCampo(this);
            txtCodEmpleado.Focus();
        }

        private void frmRegistroDatosPersonal_Load(object sender, EventArgs e)
        {
            txtNumBrevete.Text = "NO TIENE";
            txtNumBrevete.Enabled = true;
            txtCodEmpleado.Enabled = false;
            cantidad_caracteres();
            LLenadoComboBox();
            dgvRegistroPersonal.RowHeadersVisible = false;
            dgvRegistroPersonal.AllowUserToAddRows = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Personal";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Personal";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
              //  DateTime fecha = DateTime.Now;
              //  obtenerip_nombre();
               // string username = Code.nivelUser._nombre;
               // string detalle = "Cerrar Registro de Personal";
               // string cod_buscado = "Cerro el registro de Personal";
               // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                this.Close();
            }
        }
        private void txtNumDocIdentEmpl_TextChanged(object sender, EventArgs e)
        {
            if (cboTipoDocIdentEmp.SelectedIndex == 1)
            {
                txtNumDocIdentEmpl.MaxLength = 8;
            }
            if (cboTipoDocIdentEmp.SelectedIndex == 2)
            {
                txtNumDocIdentEmpl.MaxLength = 11;
            }
            if (cboTipoDocIdentEmp.SelectedIndex == 3)
            {
                txtNumDocIdentEmpl.MaxLength = 9;
            }
            if (cboTipoDocIdentEmp.SelectedIndex == 3)
            {
                txtNumDocIdentEmpl.MaxLength = 9;
            }
        }

        private void dtpNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaNacicimento = dtpNacimiento.Value;
            DateTime now = DateTime.Today;
            int edad = DateTime.Today.Year - fechaNacicimento.Year;
            if (DateTime.Today < fechaNacicimento.AddYears(edad))
                edad--;

            txtEdadEmp.Text = Convert.ToString(edad);
            txtEdadEmp.Enabled = false;
        }

        private void cboBrevete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBrevete.SelectedIndex == 2)
            {
                txtNumBrevete.Clear();
                txtNumBrevete.Enabled = true;
            }
            else if (cboBrevete.SelectedIndex == 3)
            {
                txtNumBrevete.Clear();
                txtNumBrevete.Enabled = true;
            }
            else
            {
                txtNumBrevete.Text = "NO TIENE";
                txtNumBrevete.Enabled = false;
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue.ToString() != null)
            {
                string Cod_Departamento = cboDepartamento.SelectedValue.ToString();
                Llenadocbo.ObtenerProvinciaRRHH(cboProvincia, Cod_Departamento);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue.ToString() != null)
            {
                string Cod_Provincia = cboProvincia.SelectedValue.ToString();
                Llenadocbo.ObtenerDistritosRRHH(cboDis, Cod_Provincia);
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

        private void cboCargoLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod_puesto = cboCargoLaboral.SelectedIndex;
            SqlCommand cmd = new SqlCommand("select COD_EMPLEADO  from T_PUESTO where  ID_PUESTO = @ID_PUESTO ", conexion.conexionBD());
            cmd.Parameters.AddWithValue("ID_PUESTO", cod_puesto);
            SqlDataReader recorre = cmd.ExecuteReader();
            while (recorre.Read())
            {
                txtCodEmpleado.Text = recorre["COD_EMPLEADO"].ToString() + txtNumDocIdentEmpl.Text;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ValidarCamposVacios();
            RegistrarPersonal();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ValidarCamposVacios();
            ActualizarPersonal();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codEmpleado = cboempleadoActivo.SelectedValue.ToString();
                SqlCommand comando = new SqlCommand("SELECT * FROM V_DetallePersonal WHERE Cod_empleado = '" + codEmpleado + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtCodEmpleado.Text = recorre["Cod_empleado"].ToString();
                    txtNombreEmp.Text = recorre["NOMBRE_EMPLEADO"].ToString();
                    txtApPaternoEmp.Text = recorre["APELLIDO_PATERNO"].ToString();
                    txtApMateEmp.Text = recorre["APELLIDO_MATERNO"].ToString();
                    txtEdadEmp.Text = recorre["EDAD_EMPLEADO"].ToString();
                    cboTipoDocIdentEmp.SelectedIndex = Convert.ToInt32(recorre["ID_TIPO_DOCT"].ToString());
                    txtNumDocIdentEmpl.Text = recorre["DOCT_IDENT"].ToString();
                    cboSexoEmp.SelectedIndex = Convert.ToInt32(recorre["Id_sexo"].ToString());
                    dtpCaducacion.Text = (recorre["FECHA_CADUCIDAD_DOC_IDENTIDAD"].ToString());
                    dtpEmicion.Text = (recorre["FECHA_EMISION_DOC_IDENTIDAD"].ToString());
                    dtpNacimiento.Text = (recorre["FECHA_NACIMIENTO_EMPLEADO"].ToString());
                    cboBrevete.SelectedIndex = Convert.ToInt32(recorre["ID_TIPO_BREVETE"].ToString());
                    txtNumBrevete.Text = recorre["NUM_BREVETE"].ToString();
                    cboNacionalidad.SelectedIndex = Convert.ToInt32(recorre["ID_NACIONALIDAD"].ToString());
                    txtDomicilio.Text = recorre["DIRECCION_PERSONAL"].ToString();
                    txtTelefono.Text = recorre["TELEFONO"].ToString();
                    txtCelular.Text = recorre["Celular"].ToString();
                    txtCorreo.Text = recorre["Correo"].ToString();
                    cboGradoInstruccionEmp.SelectedIndex = Convert.ToInt32(recorre["ID_GRADO_INSTRUCCION"].ToString());
                    cboEstadoCivilEmp.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_CIVIL"].ToString());
                    cboCargoLaboral.SelectedIndex = Convert.ToInt32(recorre["ID_PUESTO"].ToString());
                    cboEmpresa.SelectedIndex = Convert.ToInt32(recorre["ID_EMPRESA"].ToString());
                    cboTipoContratoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_TIPO_CONTRATO"].ToString());
                    dtpFechaInicio.Text = (recorre["FECHA_INICIO_CONTRATO"].ToString());
                    dtpFechaFin.Text = (recorre["FECHA_FIN_CONTRATO"].ToString());
                   
                    cboEstadoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_PERSONAL"].ToString());
                    cboTurnoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_TURNO_EMPLEADO"].ToString());
                    cboTallaPrenda.SelectedIndex = Convert.ToInt32(recorre["ID_TALLA_PRENDA"].ToString());
                    txtTallaPantalonEmp.Text = recorre["Talla_pantalon"].ToString();
                    txtTallaCalzadoEmp.Text = recorre["Talla_zapato"].ToString();
                    txtEstaturaEmp.Text = recorre["ESTATURA_PERSONAL"].ToString();
                    cboHorasLaborales.SelectedIndex = Convert.ToInt32(recorre["ID_HORAS_LABORALES"].ToString());
                    txtCodUbigeo.Text = recorre["COD_UBIGEO"].ToString();
                    cboDepartamento.SelectedValue = recorre["Cod_Departamento"].ToString();
                    cboProvincia.SelectedValue = recorre["Cod_Provincia"].ToString();
                    cboDis.SelectedValue = recorre["Cod_Distrito"].ToString();

                    cboArmado.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_ARMADO"].ToString());
                    dtpFinicioLaboral.Text = (recorre["FECHA_INICIO_LABORAL"].ToString());
                    dtpFechaFinLaboral.Text = (recorre["FECHA_FIN_LABORAL"].ToString());
                    dtpFechaActivacion.Text = (recorre["FECHA_ACTIVACION_PERSONAL"].ToString());
                    dtpUltimoDestaque.Text = (recorre["FECHA_DESTAQUE_PERSONAL"].ToString());


                    string unidad = recorre["Razon_social"].ToString();
                    cboUnidad.SelectedIndex = cboUnidad.FindStringExact(unidad);
                    string sede = recorre["Nombre_sede"].ToString();
                    cboSede.SelectedIndex = cboSede.FindStringExact(sede);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.SelectedIndex.ToString() != null)
            {
                int cod_empresa = cboEmpresa.SelectedIndex;
                Llenadocbo.ObtenerUnidadRRHHEmpresa(cboUnidad, cod_empresa);
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFinicioLaboral.Value = dtpFechaInicio.Value;
        }
    }
}
