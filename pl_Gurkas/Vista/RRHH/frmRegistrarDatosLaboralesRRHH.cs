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
    public partial class frmRegistrarDatosLaboralesRRHH : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LLenadoDatosRRHH Llenadocbo = new Datos.LLenadoDatosRRHH();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        public frmRegistrarDatosLaboralesRRHH()
        {
            InitializeComponent();
        }
        private void limpiar()
        {
            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.LimpiarGroupBox(groupBox2);
            LimpiarDatos.LimpiarGroupBox(groupBox4);
            LimpiarDatos.LimpiarGroupBox(groupBox5);
            LimpiarDatos.LimpiarGroupBox(groupBox6);
            LimpiarDatos.LimpiarCampo(this);
            txtCodEmpleado.Focus();
            cboTipoPago.SelectedIndex = 1;
            cboPeriodidadRemuneracion.SelectedIndex = 2;
        }
        private void showDialogs(String message, Color bdColor)
        {
            Vista.MensajeEmergente.DialogForm dialog = new Vista.MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        } 
        private void BuscarAVP(string codAVP)
        {
            try
            {

                SqlCommand comando = conexion.conexionBD().CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SP_BuscarPersonal  @Cod_empleado";
                comando.Parameters.AddWithValue("Cod_empleado", codAVP);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(comando);
                dta.Fill(dt);
                dt.Columns[0].ColumnName = "Cod Empleado";
                dt.Columns[1].ColumnName = "Nombre Completo Empleado";
                dt.Columns[2].ColumnName = "Banco";
                dt.Columns[3].ColumnName = "CTA SUELDO";
                dt.Columns[4].ColumnName = "MONEDA";
                dt.Columns[5].ColumnName = "Regimen Pensinsionario";
                dt.Columns[6].ColumnName = "AFP / ONP ";
                dt.Columns[7].ColumnName = "AFP CUPSS";
                dt.Columns[8].ColumnName = "TIPO COMISION AFP";
                dt.Columns[9].ColumnName = "Movimiento AFP";
                dt.Columns[10].ColumnName = "Tipo Trabajador";
                dt.Columns[11].ColumnName = "SUELDO BASICO";
                dt.Columns[12].ColumnName = "SUELDO BRUTO";
                dt.Columns[13].ColumnName = "BONO FAMILIAR";
                dt.Columns[14].ColumnName = "TIPO REMUNERACION";
                dt.Columns[15].ColumnName = "PERIODO REMUNERACION";
                dt.AcceptChanges();
                dgvRegistroPersonal.DataSource = dt;
                DateTime fecha = DateTime.Now;
                //obtenerip_nombre();
                //string username = Code.nivelUser._nombre;
                string detalle = "Buscar Datos";
                string cod_buscado = "Codigo de empleado Buscado : " + codAVP;
               // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                showDialogs("Datos Encontrados", Color.FromArgb(0, 200, 81));

            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun dato registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                showDialogs("ERROR", Color.FromArgb(255, 53, 71));
            }
        }

        private void cantidad_caracteres()
        {
            txtTelefono.MaxLength = 7;
            txtCelular.MaxLength = 9;
            txtEdadEmp.MaxLength = 2;
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
            Llenadocbo.ObtenerDepartamentoRRHH(cboDepartamento);
            Llenadocbo.ObtenerUnidadRRHH(cboUnidad);
            Llenadocbo.ObtenerPersonalRRHH(cboempleadoActivo);
            Llenadocbo.ObtenerBancoRRHH(cboBanco);
            Llenadocbo.ObtenerMonedaRRHH(cboTipoMoneda);
            Llenadocbo.ObtenerRegimenPensionarioRRHH(cboRegimenPensionario);
           // Llenadocbo.ObtenerAFPRRHH(cboAFP);
           // Llenadocbo.ObtenerTipoComisionAFPRRHH(cboTipoComicion);
           // Llenadocbo.ObtenerMovimientoAFPRRHH(cboMovimientoAFP);
            Llenadocbo.ObtenerTipoTrabajdorRRHH(cboTipoTrabajador);
            Llenadocbo.ObtenerBonoFamiliarRRHH(cboAsignacionFamiliar);
            Llenadocbo.ObtenerTipoRemuneracionRRHH(cboTipoPago);
            Llenadocbo.ObtenerPeriodoRemuneracionRRHH(cboPeriodidadRemuneracion);
        }
        private void frmRegistrarDatosLaboralesRRHH_Load(object sender, EventArgs e)
        {
            txtNumBrevete.Text = "NO TIENE";
            txtNumBrevete.Enabled = true;
            txtCodEmpleado.Enabled = false;

            cantidad_caracteres();
            LLenadoComboBox();
            dgvRegistroPersonal.RowHeadersVisible = false;
            dgvRegistroPersonal.AllowUserToAddRows = false;
            cboTipoPago.SelectedIndex = 1;
            cboTipoTrabajador.SelectedIndex = 2;
            cboPeriodidadRemuneracion.SelectedIndex = 2;
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
                    dtpFechaInicio.Text = (recorre["FECHA_INICIO_LABORAL"].ToString());
                    //dtpFechaInicio.Text = (recorre["FECHA_INICIO_CONTRATO"].ToString());
                    dtpFechaFin.Text = (recorre["FECHA_FIN_CONTRATO"].ToString());
                    string unidad = recorre["Razon_social"].ToString();
                    cboUnidad.SelectedIndex = cboUnidad.FindStringExact(unidad);
                    string sede = recorre["Nombre_sede"].ToString();
                    cboSede.SelectedIndex = cboSede.FindStringExact(sede);
                    cboEstadoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_PERSONAL"].ToString());
                    cboTurnoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_TURNO_EMPLEADO"].ToString());
                   // cboTallaPrenda.SelectedIndex = Convert.ToInt32(recorre["ID_TALLA_PRENDA"].ToString());
                   // txtTallaPantalonEmp.Text = recorre["Talla_pantalon"].ToString();
                  //  txtTallaCalzadoEmp.Text = recorre["Talla_zapato"].ToString();
                  //  txtEstaturaEmp.Text = recorre["ESTATURA_PERSONAL"].ToString();
                    cboHorasLaborales.SelectedIndex = Convert.ToInt32(recorre["ID_HORAS_LABORALES"].ToString());
                    txtCodUbigeo.Text = recorre["COD_UBIGEO"].ToString();
                    cboDepartamento.SelectedValue = recorre["Cod_Departamento"].ToString();
                    cboProvincia.SelectedValue = recorre["Cod_Provincia"].ToString();
                    cboDis.SelectedValue = recorre["Cod_Distrito"].ToString();

                    // cboArmado.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_ARMADO"].ToString());
                     dtpFechaInicio.Text = (recorre["FECHA_INICIO_LABORAL"].ToString());
                    //   dtpFechaFinLaboral.Text = (recorre["FECHA_FIN_LABORAL"].ToString());
                    //   dtpFechaActivacion.Text = (recorre["FECHA_ACTIVACION_PERSONAL"].ToString());
                    //   dtpUltimoDestaque.Text = (recorre["FECHA_DESTAQUE_PERSONAL"].ToString());
                }
                BuscarAVP(codEmpleado);
            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
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

                int cod_puesto = cboCargoLaboral.SelectedIndex;
                SqlCommand cmd = new SqlCommand("select MV , sueldo from t_unidad_puesto_sueldo where cod_unidad = @cod_unidad and id_puesto_empleado = @cod_puesto ", conexion.conexionBD());
                cmd.Parameters.AddWithValue("cod_unidad", cod_unidad);
                cmd.Parameters.AddWithValue("cod_puesto", cod_puesto);
                SqlDataReader recorre = cmd.ExecuteReader();
                while (recorre.Read())
                {
                    txtSueldoBa.Text = recorre["MV"].ToString();
                    txtxSueldoBruto.Text = recorre["sueldo"].ToString();
                }
            }
        }
        private void ValidarCamposVacios()
        {
            if (cboBanco.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Banco", "Advertencia");
            }
            if (cboTipoMoneda.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un tipo de moneda", "Advertencia");
            }
            if (cboRegimenPensionario.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de regimen Pensionario", "Advertencia");
            }
            if (cboAFP.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo Tipo de AFP/ONP", "Advertencia");
            }
            if (cboTipoComicion.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar una Tipo de Comicion", "Advertencia");
            }
            if (cboMovimientoAFP.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Movimineto de AFP", "Advertencia");
            }
            if (cboTipoTrabajador.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Trabajador", "Advertencia");
            }
            if (cboAsignacionFamiliar.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar Si cuenta con Asignacion Familiar", "Advertencia");
            }
            if (cboTipoPago.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Pago", "Advertencia");
            }
            if (cboPeriodidadRemuneracion.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Periodo de Remuneracion", "Advertencia");
            }
            if (txtCtaBancaria.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar La Cuenta Bancaria", "Advertencia");
            }
            if (txtAFPCUSS.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar el AFPCUSS ", "Advertencia");
            }
            if (txtSueldoBa.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar el Sueldo Basico", "Advertencia");
            }
            if (txtxSueldoBruto.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar el Sueldo Bruto", "Advertencia");
            }
        }
        private void cboAFP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAFP.SelectedValue.ToString() != null)
            {
                string cod_afp = cboAFP.SelectedValue.ToString();

                if (cod_afp.Equals("1"))
                {
                    txtAFPCUSS.Enabled = true;
                    txtAFPCUSS.Text = "";
                    cboTipoComicion.SelectedIndex = 0;
                    cboTipoComicion.Enabled = true;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = true;
                }
                else if (cod_afp.Equals("2"))
                {
                    txtAFPCUSS.Enabled = true;
                    txtAFPCUSS.Text = "";
                    cboTipoComicion.SelectedIndex = 0;
                    cboTipoComicion.Enabled = true;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = true;
                }
                else if (cod_afp.Equals("3"))
                {
                    txtAFPCUSS.Enabled = true;
                    txtAFPCUSS.Text = "";
                    cboTipoComicion.SelectedIndex = 0;
                    cboTipoComicion.Enabled = true;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = true;
                }
                else if (cod_afp.Equals("4"))
                {
                    txtAFPCUSS.Enabled = true;
                    txtAFPCUSS.Text = "";
                    cboTipoComicion.SelectedIndex = 0;
                    cboTipoComicion.Enabled = true;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = true;
                }
                else if (cod_afp.Equals("5"))
                {
                    txtAFPCUSS.Enabled = true;
                    txtAFPCUSS.Text = "";
                    cboTipoComicion.SelectedIndex = 0;
                    cboTipoComicion.Enabled = true;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = true;
                }
                else if (cod_afp.Equals("6"))
                {
                    txtAFPCUSS.Enabled = false;
                    txtAFPCUSS.Text = "ONP";
                    cboTipoComicion.SelectedIndex = 1;
                    cboTipoComicion.Enabled = false;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = false;
                }
                else if (cod_afp.Equals("7"))
                {
                    txtAFPCUSS.Enabled = false;
                    txtAFPCUSS.Text = "PENSIONISTA";
                    cboTipoComicion.SelectedIndex = 1;
                    cboTipoComicion.Enabled = false;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = false;
                }
                else if (cod_afp.Equals("8"))
                {
                    txtAFPCUSS.Enabled = false;
                    txtAFPCUSS.Text = "SIN REGIMEN PENSIONARIO";
                    cboTipoComicion.SelectedIndex = 1;
                    cboTipoComicion.Enabled = false;
                    cboMovimientoAFP.SelectedIndex = 1;
                    cboMovimientoAFP.Enabled = false;
                }
            }
              

          
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

        private void cboTipoDocIdentEmp_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
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
                  //string username = Code.nivelUser._nombre;
                  string detalle = "Cerrar Registro de Personal";
                  string cod_buscado = "Cerro el registro de Personal";
                 // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                  this.Close();
              }

        }

        private void btnAgregarPlanillaDatos_Click(object sender, EventArgs e)
        {
            string codEmpleado = txtCodEmpleado.Text;
            int TipoTrabajador = cboTipoTrabajador.SelectedIndex;
            decimal SueldoBasico = Convert.ToDecimal(txtSueldoBa.Text);
            decimal SueldoBruto = Convert.ToDecimal(txtxSueldoBruto.Text);
            int AsignacionFamiliar = cboAsignacionFamiliar.SelectedIndex;
            int TipoPago = cboTipoPago.SelectedIndex;
            int PeriodoRemuneracion = cboPeriodidadRemuneracion.SelectedIndex;
            int bancosueldo = cboBanco.SelectedIndex;
            string cuentaBancaria = txtCtaBancaria.Text;
            int SueldoMoneda = cboTipoMoneda.SelectedIndex;
            int RegimenPensionario = cboRegimenPensionario.SelectedIndex;
            int afp = Convert.ToInt32(cboAFP.SelectedValue.ToString());
            string afpcuss = txtAFPCUSS.Text;
            int tipocomicion = Convert.ToInt32(cboTipoComicion.SelectedValue.ToString());
            int movimientoAFp = Convert.ToInt32(cboMovimientoAFP.SelectedValue.ToString());
            DateTime fechaInicio = dtpFechaInicio.Value;
            try
            {
                ValidarCamposVacios();
                const string titulo = "Actualizar datos en el Sistema";
                const string mensaje = "Por favor verificar  la Imformacion antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICAR DATOS ANTES DE GUARDAR";
                var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resutlado == DialogResult.Yes)
                {
                    registrar.RegistrarDatosLaboralesRRHH(codEmpleado, fechaInicio, TipoTrabajador, SueldoBasico, SueldoBruto
                    , AsignacionFamiliar, TipoPago, PeriodoRemuneracion, bancosueldo, cuentaBancaria, SueldoMoneda,
                    RegimenPensionario, afp, afpcuss, tipocomicion, movimientoAFp);
                    MessageBox.Show("Datos Laborados Registrado Exitosamente", "Registrado");
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede registrar los datos laborales" + ex, "ERROR");
            }
        }

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            string codEmpleado = txtCodEmpleado.Text;
            int TipoTrabajador = cboTipoTrabajador.SelectedIndex;
            decimal SueldoBasico = Convert.ToDecimal(txtSueldoBa.Text);
            decimal SueldoBruto = Convert.ToDecimal(txtxSueldoBruto.Text);
            int AsignacionFamiliar = cboAsignacionFamiliar.SelectedIndex;
            int TipoPago = cboTipoPago.SelectedIndex;
            int PeriodoRemuneracion = cboPeriodidadRemuneracion.SelectedIndex;
            int bancosueldo = cboBanco.SelectedIndex;
            string cuentaBancaria = txtCtaBancaria.Text;
            int SueldoMoneda = cboTipoMoneda.SelectedIndex;
            int RegimenPensionario = cboRegimenPensionario.SelectedIndex;
            int afp = Convert.ToInt32(cboAFP.SelectedValue.ToString());
            string afpcuss = txtAFPCUSS.Text;
            int tipocomicion =  Convert.ToInt32(cboTipoComicion.SelectedValue.ToString());
            int movimientoAFp = Convert.ToInt32(cboMovimientoAFP.SelectedValue.ToString());  
            DateTime fechaInicio = dtpFechaInicio.Value;
            try
            {
                ValidarCamposVacios();
                const string titulo = "Actualizar datos en el Sistema";
                const string mensaje = "Por favor verificar  la Imformacion antes de guardar en el sistema \n SI  =  GUARDAR IMFORMACION \n NO  =  VERIFICAR DATOS ANTES DE GUARDAR";
                var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resutlado == DialogResult.Yes)
                {
                    actualizar.ActualizarDatosLaborales_rrhh(codEmpleado, fechaInicio, TipoTrabajador, SueldoBasico, SueldoBruto
                    , AsignacionFamiliar, TipoPago, PeriodoRemuneracion, bancosueldo, cuentaBancaria, SueldoMoneda,
                    RegimenPensionario, afp, afpcuss, tipocomicion, movimientoAFp);
                    MessageBox.Show("Datos Laborados Actualizado Exitosamente", "Registrado");
                    limpiar();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede Actualizado los datos laborales" + ex, "ERROR");
            }
        }

        private void dgvRegistroPersonal_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string codEmpleado = txtCodEmpleado.Text;

                SqlCommand comando = new SqlCommand("SELECT * FROM V_DetallePersonal_total WHERE Cod_empleado = '" + codEmpleado + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    cboBanco.SelectedIndex = Convert.ToInt32(recorre["id_banco"].ToString());
                    txtCtaBancaria.Text = recorre["CTA_SUELDO"].ToString();
                    cboTipoMoneda.SelectedIndex = Convert.ToInt32(recorre["id_moneda"].ToString());
                    cboRegimenPensionario.SelectedIndex = Convert.ToInt32(recorre["id_ReguimenPensionario"].ToString());
                    cboAFP.SelectedIndex = Convert.ToInt32(recorre["id_afp"].ToString());
                    txtAFPCUSS.Text = recorre["AFP_CUPSS"].ToString();
                    cboTipoComicion.SelectedIndex = Convert.ToInt32(recorre["ID_TipoComisionAFP"].ToString());
                    cboMovimientoAFP.SelectedIndex = Convert.ToInt32(recorre["ID_MovimientoAFP"].ToString());
                    cboTipoTrabajador.SelectedIndex = Convert.ToInt32(recorre["ID_TipoTrabajador"].ToString());
                    txtSueldoBa.Text = recorre["SUELDO_BASICO"].ToString();
                    txtxSueldoBruto.Text = recorre["SUELDO_BRUTO"].ToString();
                    cboAsignacionFamiliar.SelectedIndex = Convert.ToInt32(recorre["ID_BonoFamiliar"].ToString());
                    cboTipoPago.SelectedIndex = Convert.ToInt32(recorre["ID_TipoRemuneracion"].ToString());
                    cboPeriodidadRemuneracion.SelectedIndex = Convert.ToInt32(recorre["ID_Periodo_remuneracion"].ToString());
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro " + err, "ERROR");
            }
        }

        private void cboRegimenPensionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenPensionario.SelectedIndex.ToString() != null)
            {
                int id_regimenpensionario = cboRegimenPensionario.SelectedIndex;
                Llenadocbo.ObtenerAFPRRHH(cboAFP, id_regimenpensionario);
                Llenadocbo.ObtenerTipoComisionAFPRRHH(cboTipoComicion, id_regimenpensionario);
                Llenadocbo.ObtenerMovimientoAFPRRHH(cboMovimientoAFP, id_regimenpensionario);
            }
        }
    }
}
