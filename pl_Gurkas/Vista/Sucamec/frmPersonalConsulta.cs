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

namespace pl_Gurkas.Vista.Sucamec
{
    public partial class frmPersonalConsulta : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDatosSucamec Llenadocbo = new Datos.LlenadoDatosSucamec();
        Datos.registrar registrar = new Datos.registrar();
        Datos.agregarDatosMysql registrarmysql = new Datos.agregarDatosMysql();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Datos.actualizarmysql actualizarmysql = new Datos.actualizarmysql();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();

        public frmPersonalConsulta()
        {
            InitializeComponent();
        }
        private void ActualizarPersonal()
        {
            try
            {
                string codEmpleado = txtCodEmpleado.Text;
                string sucamec = txtSucamec.Text;
                string arma = txtLienciaArma.Text;

                string Empresa1 = txtEmpresa1.Text;
                string Empresa2 = txtEmpresa2.Text;
                string Empresa3 = txtEmpresa3.Text;

                DateTime FechaVigenciaSucamec = dtpFechaVigenciaSucamec.Value;
                DateTime FechaVigenciaArma = dtpFechaVigenciaArma.Value;

                DateTime InicioExp1 = edtInicioExp1.Value;
                DateTime InicioExp2 = edtInicioExp2.Value;
                DateTime InicioExp3 = edtInicioExp2.Value;

                DateTime FinExp1 = edtFinExp1.Value;
                DateTime FinExp2 = edtFinExp2.Value;
                DateTime FinExp3 = edtFinExp3.Value;


                int Experiencia1 = cboExperiencia1.SelectedIndex;
                int Experiencia2 = cboExperiencia2.SelectedIndex;
                int Experiencia3 = cboExperiencia3.SelectedIndex;

                actualizar.ActualizarPersonalSucamec(codEmpleado, sucamec, arma, Empresa1, Empresa2, Empresa3, FechaVigenciaSucamec,
                    FechaVigenciaArma, InicioExp1, InicioExp2, InicioExp3, FinExp1, FinExp2, FinExp3, Experiencia1,
                    Experiencia2, Experiencia3);

                MessageBox.Show("Datos actualizado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox2);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                LimpiarDatos.LimpiarGroupBox(groupBox4);
                LimpiarDatos.LimpiarGroupBox(groupBox5);
                LimpiarDatos.LimpiarGroupBox(groupBox6);
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
        private void showDialogs(String message, Color bdColor)
        {
            Vista.MensajeEmergente.DialogForm dialog = new Vista.MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        }
        private void CantidadExperiencia()
        {
            cboEmpresasExp.Items.Insert(0, "Personal Sin Experiencia");
            cboEmpresasExp.Items.Insert(1, "Con Expreciencia de 1 Empresa");
            cboEmpresasExp.Items.Insert(2, "Con Expreciencia de 2 Empresa");
            cboEmpresasExp.Items.Insert(3, "Con Expreciencia de 3 Empresa");
            cboEmpresasExp.SelectedIndex = 0;
        }
        private void LLenadoComboBox()
        {
            Llenadocbo.ObtenerEmpresaSucamec_2(cboEmpresa);
            Llenadocbo.ObtenerTipoDocumentoSucamec(cboTipoDocIdentEmp);
            Llenadocbo.ObtenerTipoSexoSucamec(cboSexoEmp);
            Llenadocbo.ObtenerBreveteSucamec(cboBrevete);
            Llenadocbo.ObtenerNacionalidadSucamec(cboNacionalidad);
            Llenadocbo.ObtenerHorasLaboralesSucamec(cboHorasLaborales);
            Llenadocbo.ObtenerEstadoCivilSucamec(cboEstadoCivilEmp);
            Llenadocbo.ObtenerGradoInstruccionSucamec(cboGradoInstruccionEmp);
            Llenadocbo.ObtenerEstadoPersonalSucamec(cboEstadoEmp);
            Llenadocbo.ObtenerPuestoSucamec(cboCargoLaboral);
            Llenadocbo.ObtenerTipoContratoSucamec(cboTipoContratoEmp);
            Llenadocbo.ObtenerTurnoSucamec(cboTurnoEmp);
            Llenadocbo.ObtenerTallaSucamec(cboTallaPrenda);
            Llenadocbo.ObtenerEstadoArmadoSucamec(cboArmado);
            Llenadocbo.ObtenerDepartamentoSucamec(cboDepartamento);
            Llenadocbo.ObtenerUnidadSucamec(cboUnidad);
            Llenadocbo.ObtenerPersonalSucamec(cboempleadoActivo);

            Llenadocbo.ObtenerExpSucamec(cboExperiencia1);
            Llenadocbo.ObtenerExpSucamec(cboExperiencia2);
            Llenadocbo.ObtenerExpSucamec(cboExperiencia3);
        }
        private void blotext()
        {
            txtCodEmpleado.Enabled = false;
            txtNombreEmp.Enabled = false;
            txtApPaternoEmp.Enabled = false;
            txtApMateEmp.Enabled = false;
            txtEdadEmp.Enabled = false;
            cboTipoDocIdentEmp.Enabled = false;
            txtNumDocIdentEmpl.Enabled = false;
            cboSexoEmp.Enabled = false;
            dtpCaducacion.Enabled = false;
            dtpEmicion.Enabled = false;
            dtpNacimiento.Enabled = false;
            cboBrevete.Enabled = false;
            txtNumBrevete.Enabled = false;
            cboNacionalidad.Enabled = false;
            txtDomicilio.Enabled = false;
            txtTelefono.Enabled = false;
            txtCelular.Enabled = false;
            txtCorreo.Enabled = false;
            cboGradoInstruccionEmp.Enabled = false;
            cboEstadoCivilEmp.Enabled = false;
            cboCargoLaboral.Enabled = false;
            cboEmpresa.Enabled = false;
            cboTipoContratoEmp.Enabled = false;
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;

            cboEstadoEmp.Enabled = false;
            cboTurnoEmp.Enabled = false;
            cboTallaPrenda.Enabled = false;
            txtTallaPantalonEmp.Enabled = false;
            txtTallaCalzadoEmp.Enabled = false;
            txtEstaturaEmp.Enabled = false;
            cboHorasLaborales.Enabled = false;
            txtCodUbigeo.Enabled = false;
            cboDepartamento.Enabled = false;
            cboProvincia.Enabled = false;
            cboDis.Enabled = false;

            cboArmado.Enabled = false;
            dtpFinicioLaboral.Enabled = false;
            dtpFechaFinLaboral.Enabled = false;
            dtpFechaActivacion.Enabled = false;
            dtpUltimoDestaque.Enabled = false;
            cboUnidad.Enabled = false;
            cboSede.Enabled = false;
        }
        private void RegistrarPersonal()
        {
            try
            {
                string codEmpleado = txtCodEmpleado.Text;
                string sucamec = txtSucamec.Text;
                string arma = txtLienciaArma.Text;

                string Empresa1 = txtEmpresa1.Text;
                string Empresa2 = txtEmpresa2.Text;
                string Empresa3 = txtEmpresa3.Text;

                DateTime FechaVigenciaSucamec = dtpFechaVigenciaSucamec.Value;
                DateTime FechaVigenciaArma = dtpFechaVigenciaArma.Value;

                DateTime InicioExp1 = edtInicioExp1.Value;
                DateTime InicioExp2 = edtInicioExp2.Value;
                DateTime InicioExp3 = edtInicioExp2.Value;

                DateTime FinExp1 = edtFinExp1.Value;
                DateTime FinExp2 = edtFinExp2.Value;
                DateTime FinExp3 = edtFinExp3.Value;


                int Experiencia1 = cboExperiencia1.SelectedIndex;
                int Experiencia2 = cboExperiencia2.SelectedIndex;
                int Experiencia3 = cboExperiencia3.SelectedIndex;

                registrar.RegistrarPersonalSucamec(codEmpleado, sucamec, arma, Empresa1, Empresa2, Empresa3, FechaVigenciaSucamec,
                    FechaVigenciaArma, InicioExp1, InicioExp2, InicioExp3, FinExp1, FinExp2, FinExp3, Experiencia1,
                    Experiencia2, Experiencia3);

                MessageBox.Show("Datos registrado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox2);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                LimpiarDatos.LimpiarGroupBox(groupBox4);
                LimpiarDatos.LimpiarGroupBox(groupBox5);
                LimpiarDatos.LimpiarGroupBox(groupBox6);
                // LimpiarDatos.LimpiarCampo(this);

                showDialogs("Datos Registrados", Color.FromArgb(0, 200, 81));
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
            }
        }

        private void frmPersonalConsulta_Load(object sender, EventArgs e)
        {
            LLenadoComboBox();
            blotext();
            CantidadExperiencia();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codEmpleado = cboempleadoActivo.SelectedValue.ToString();

                SqlCommand comando = new SqlCommand("SELECT * FROM V_DetallePersonal_Sucamec WHERE Cod_empleado = '" + codEmpleado + "'", conexion.conexionBD());

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
                    string unidad = recorre["Razon_social"].ToString();
                    cboUnidad.SelectedIndex = cboUnidad.FindStringExact(unidad);
                    string sede = recorre["Nombre_sede"].ToString();
                    cboSede.SelectedIndex = cboSede.FindStringExact(sede);
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


                    
                    txtSucamec.Text = recorre["carnet_sucamec"].ToString();
                    txtLienciaArma.Text = (recorre["licencia_arma"].ToString());

                    dtpFechaVigenciaSucamec.Text = (recorre["fecha_vigencia_sucamec"].ToString());
                    dtpFechaVigenciaArma.Text = (recorre["fecha_vigencia_licencia"].ToString());

                    txtEmpresa1.Text = recorre["exp_empresa_nombre_1"].ToString();
                    txtEmpresa2.Text = recorre["exp_empresa_nombre_2"].ToString();
                    txtEmpresa3.Text = recorre["exp_empresa_nombre_3"].ToString();

                    edtInicioExp1.Text = (recorre["f_inicio_empresa_1"].ToString());
                    edtInicioExp2.Text = (recorre["f_inicio_empresa_2"].ToString());
                    edtInicioExp3.Text = (recorre["f_inicio_empresa_3"].ToString());
                    edtFinExp1.Text = (recorre["f_fin_empresa_1"].ToString());
                    edtFinExp2.Text = (recorre["f_fin_empresa_2"].ToString());
                    edtFinExp3.Text = (recorre["f_fin_empresa_3"].ToString());

                    cboExperiencia1.SelectedIndex = Convert.ToInt32(recorre["id_experiencia_1"].ToString());
                    cboExperiencia2.SelectedIndex = Convert.ToInt32(recorre["id_experiencia_2"].ToString());
                    cboExperiencia3.SelectedIndex = Convert.ToInt32(recorre["id_experiencia_3"].ToString());
                }
                if (cboExperiencia1.SelectedIndex == 2)
                {
                   cboEmpresasExp.SelectedIndex = 1;
                    txtEmpresa1.Enabled = true;
                    txtEmpresa2.Enabled = false;
                    txtEmpresa3.Enabled = false;

                    edtInicioExp1.Enabled = true;
                    edtInicioExp2.Enabled = false;
                    edtInicioExp3.Enabled = false;

                    edtFinExp1.Enabled = true;
                    edtFinExp2.Enabled = false;
                    edtFinExp3.Enabled = false;

                    cboExperiencia1.Enabled = true;
                    cboExperiencia2.Enabled = false;
                    cboExperiencia3.Enabled = false;
                }
                if (cboExperiencia2.SelectedIndex == 2)
                {
                    cboEmpresasExp.SelectedIndex = 2;
                    txtEmpresa1.Enabled = true;
                    txtEmpresa2.Enabled = true;
                    txtEmpresa3.Enabled = false;

                    edtInicioExp1.Enabled = true;
                    edtInicioExp2.Enabled = true;
                    edtInicioExp3.Enabled = false;

                    edtFinExp1.Enabled = true;
                    edtFinExp2.Enabled = true;
                    edtFinExp3.Enabled = false;

                    cboExperiencia1.Enabled = true;
                    cboExperiencia2.Enabled = true;
                    cboExperiencia3.Enabled = false;
                }
                if (cboExperiencia3.SelectedIndex == 2)
                {
                  cboEmpresasExp.SelectedIndex = 3;
                    txtEmpresa1.Enabled = true;
                    txtEmpresa2.Enabled = true;
                    txtEmpresa3.Enabled = true;

                    edtInicioExp1.Enabled = true;
                    edtInicioExp2.Enabled = true;
                    edtInicioExp3.Enabled = true;

                    edtFinExp1.Enabled = true;
                    edtFinExp2.Enabled = true;
                    edtFinExp3.Enabled = true;

                    cboExperiencia1.Enabled = true;
                    cboExperiencia2.Enabled = true;
                    cboExperiencia3.Enabled = true;
                }
                 modulo.auditoriaFunciones("Sucamec", "Buscar personal", "Busqueda de personal : " + codEmpleado);
            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
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
                modulo.auditoriaFunciones("Sucamec", "Salir del modulo Buscar personal", "Cerrar el modulo de Consulta de asistencia de personal");
            }
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeSucamec(cboSede, cod_unidad);
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue.ToString() != null)
            {
                string Cod_Departamento = cboDepartamento.SelectedValue.ToString();
                Llenadocbo.ObtenerProvinciaSucamec(cboProvincia, Cod_Departamento);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue.ToString() != null)
            {
                string Cod_Provincia = cboProvincia.SelectedValue.ToString();
                Llenadocbo.ObtenerDistritosSucamec(cboDis, Cod_Provincia);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RegistrarPersonal();
        }

        private void cboEmpresasExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmpresasExp.SelectedIndex == 0)
            {
                txtEmpresa1.Text = "NO TIENE EXPRECIENCIA EMPRESA 1";
                txtEmpresa1.Enabled = false;
                txtEmpresa2.Text = "NO TIENE EXPRECIENCIA EMPRESA 2";
                txtEmpresa2.Enabled = false;
                txtEmpresa3.Text = "NO TIENE EXPRECIENCIA EMPRESA 3";
                txtEmpresa3.Enabled = false;

                edtInicioExp1.Enabled = false;
                edtInicioExp2.Enabled = false;
                edtInicioExp3.Enabled = false;

                edtFinExp1.Enabled = false;
                edtFinExp2.Enabled = false;
                edtFinExp3.Enabled = false;

                cboExperiencia1.Enabled = false;
                cboExperiencia2.Enabled = false;
                cboExperiencia3.Enabled = false;

                cboExperiencia1.SelectedIndex = 1;
                cboExperiencia2.SelectedIndex = 1;
                cboExperiencia3.SelectedIndex = 1;

            }
            else if (cboEmpresasExp.SelectedIndex == 1)
            {
                //txtEmpresa1.Text = "";
                txtEmpresa1.Enabled = true;
                txtEmpresa2.Text = "NO TIENE EXPRECIENCIA EMPRESA 2";
                txtEmpresa2.Enabled = false;
                txtEmpresa3.Text = "NO TIENE EXPRECIENCIA EMPRESA 3";
                txtEmpresa3.Enabled = false;

                edtInicioExp1.Enabled = true;
                edtInicioExp2.Enabled = false;
                edtInicioExp3.Enabled = false;

                edtFinExp1.Enabled = true;
                edtFinExp2.Enabled = false;
                edtFinExp3.Enabled = false;

                cboExperiencia1.Enabled = true;
                cboExperiencia2.Enabled = false;
                cboExperiencia3.Enabled = false;

                cboExperiencia1.SelectedIndex = 2;
                cboExperiencia2.SelectedIndex = 1;
                cboExperiencia3.SelectedIndex = 1;
            }
            else if (cboEmpresasExp.SelectedIndex == 2)
            {
              //  txtEmpresa1.Text = "";
                txtEmpresa1.Enabled = true;
               // txtEmpresa2.Text = "";
                txtEmpresa2.Enabled = true;
                txtEmpresa3.Text = "NO TIENE EXPRECIENCIA EMPRESA 3";
                txtEmpresa3.Enabled = false;

                edtInicioExp1.Enabled = true;
                edtInicioExp2.Enabled = true;
                edtInicioExp3.Enabled = false;

                edtFinExp1.Enabled = true;
                edtFinExp2.Enabled = true;
                edtFinExp3.Enabled = false;

                cboExperiencia1.Enabled = true;
                cboExperiencia2.Enabled = true;
                cboExperiencia3.Enabled = false;

                cboExperiencia1.SelectedIndex = 2;
                cboExperiencia2.SelectedIndex = 2;
                cboExperiencia3.SelectedIndex = 1;
            }
            else if (cboEmpresasExp.SelectedIndex == 3)
            {
              //  txtEmpresa1.Text = "";
                txtEmpresa1.Enabled = true;
               // txtEmpresa2.Text = "";
                txtEmpresa2.Enabled = true;
               // txtEmpresa3.Text = "";
                txtEmpresa3.Enabled = true;

                edtInicioExp1.Enabled = true;
                edtInicioExp2.Enabled = true;
                edtInicioExp3.Enabled = true;

                edtFinExp1.Enabled = true;
                edtFinExp2.Enabled = true;
                edtFinExp3.Enabled = true;

                cboExperiencia1.Enabled = true;
                cboExperiencia2.Enabled = true;
                cboExperiencia3.Enabled = true;

                cboExperiencia1.SelectedIndex = 2;
                cboExperiencia2.SelectedIndex = 2;
                cboExperiencia3.SelectedIndex = 2;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.LimpiarGroupBox(groupBox2);
            LimpiarDatos.LimpiarGroupBox(groupBox3);
            LimpiarDatos.LimpiarGroupBox(groupBox4);
            LimpiarDatos.LimpiarGroupBox(groupBox5);
            LimpiarDatos.LimpiarGroupBox(groupBox6);
            //LimpiarDatos.LimpiarCampo(this);
            cboempleadoActivo.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPersonal();
        }
    }
}
