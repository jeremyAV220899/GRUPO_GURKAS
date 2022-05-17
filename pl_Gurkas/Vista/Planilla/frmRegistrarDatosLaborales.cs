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

namespace pl_Gurkas.Vista.Planilla
{
    public partial class frmRegistrarDatosLaborales : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        public frmRegistrarDatosLaborales()
        {
            InitializeComponent();
        }
        private void limpiar()
        {
            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.LimpiarGroupBox(gb2);
            LimpiarDatos.LimpiarGroupBox(groupBox3);
        }
        private void showDialogs(String message, Color bdColor)
        {
            Vista.MensajeEmergente.DialogForm dialog = new Vista.MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        }
        private void LLenadoComboBox()
        {

            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerBancoPLANILLAS(cboBanco);
            Llenadocbo.ObtenerMonedaPLANILLAS(cboTipoMoneda);
            Llenadocbo.ObtenerBancoPLANILLAS(cboBancoCTS);
            Llenadocbo.ObtenerMonedaPLANILLAS(cboTipMonCTS);
            Llenadocbo.ObtenerRegimenPensionarioPLANILLAS(cboRegimenPensionario);
            Llenadocbo.ObtenerAFPPLANILLAS(cboAFP);
            Llenadocbo.ObtenerTipoComisionAFPPLANILLAS(cboTipoComicion);
            Llenadocbo.ObtenerMovimientoAFPPLANILLAS(cboMovimientoAFP);
            Llenadocbo.ObtenerTipoTrabajdorPLANILLAS(cboTipoTrabajador);
            Llenadocbo.ObtenerBonoFamiliarPLANILLAS(cboAsignacionFamiliar);
            Llenadocbo.ObtenerTipoRemuneracionPLANILLAS(cboTipoPago);
            Llenadocbo.ObtenerPeriodoRemuneracionPLANILLAS(cboPeriodidadRemuneracion);
            Llenadocbo.ObtenerBonoFeriadoPLANILLAS(cboBonoFeriado);
        }
        private void frmRegistrarDatosLaborales_Load(object sender, EventArgs e)
        {
            LLenadoComboBox();
            dgvDatosLaborales.RowHeadersVisible = false;
            dgvDatosLaborales.AllowUserToAddRows = false;
            btneliminar.Enabled = false;
            txtcod.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codEmpleado = cboempleadoActivo.SelectedValue.ToString();

                SqlCommand comando = new SqlCommand("SELECT * FROM V_DatosLaborales WHERE Cod_empleado = '" + codEmpleado + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtcod.Text = recorre["Cod_empleado"].ToString();
                    dtpFechaInicio.Text = (recorre["FECHA_INICIO"].ToString());
                    cboTipoTrabajador.SelectedIndex = Convert.ToInt32(recorre["ID_TipoTrabajador"].ToString());
                    txtSueldoBa.Text = recorre["SUELDO_BASICO"].ToString();
                    txtxSueldoBruto.Text = recorre["SUELDO_BRUTO"].ToString();
                    cboAsignacionFamiliar.SelectedIndex = Convert.ToInt32(recorre["ID_BonoFamiliar"].ToString());
                    cboTipoPago.SelectedIndex = Convert.ToInt32(recorre["ID_TipoRemuneracion"].ToString());
                    cboPeriodidadRemuneracion.SelectedIndex = Convert.ToInt32(recorre["ID_Periodo_remuneracion"].ToString());
                    txtbonoArmado.Text = recorre["BONO_ARMADO"].ToString();
                    txtbonificaion.Text = recorre["BonoProductividad_BONIFICACION"].ToString();
                    cboBanco.SelectedIndex = Convert.ToInt32(recorre["id_banco"].ToString());
                    txtCtaBancaria.Text = (recorre["CTA_SUELDO"].ToString());
                    cboTipoMoneda.SelectedIndex = Convert.ToInt32(recorre["id_moneda"].ToString());
                    cboBancoCTS.SelectedIndex = Convert.ToInt32(recorre["id_banco_CTS"].ToString());
                    txtctacts.Text = (recorre["CTA_CTS"].ToString());
                    cboTipMonCTS.SelectedIndex = Convert.ToInt32(recorre["id_moneda_CTA_CTS"].ToString());
                    cboRegimenPensionario.SelectedIndex = Convert.ToInt32(recorre["id_ReguimenPensionario"].ToString());
                    cboAFP.SelectedIndex = Convert.ToInt32(recorre["id_afp"].ToString());
                    txtAFPCUSS.Text = recorre["AFP_CUPSS"].ToString();
                    cboTipoComicion.SelectedIndex = Convert.ToInt32(recorre["ID_TipoComisionAFP"].ToString());
                    cboMovimientoAFP.SelectedIndex = Convert.ToInt32(recorre["ID_MovimientoAFP"].ToString());
                    txtmovilidad.Text = recorre["BonoProduccion_MOVILIDAD"].ToString();
                    cboBonoFeriado.SelectedIndex = Convert.ToInt32(recorre["ID_FERIADO"].ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro";
            const string mensaje = "Estas seguro que deseas cerra el Registro ?";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtCtaBancaria_TextChanged(object sender, EventArgs e)
        {
            if (cboBanco.SelectedIndex == 1)
            {
                txtCtaBancaria.MaxLength = 20;
            }
            else if (cboBanco.SelectedIndex == 2)
            {
                txtCtaBancaria.MaxLength = 17;
            }
            else if (cboBanco.SelectedIndex == 3)
            {
                txtCtaBancaria.MaxLength = 24;
            }
            else if (cboBanco.SelectedIndex == 4)
            {
                txtCtaBancaria.MaxLength = 15;
            }
            else if (cboBanco.SelectedIndex == 5)
            {
                txtCtaBancaria.MaxLength = 20;
            }
            else if (cboBanco.SelectedIndex == 6)
            {
                txtCtaBancaria.MaxLength = 20;
            }
            else if (cboBanco.SelectedIndex == 7)
            {
                txtCtaBancaria.MaxLength = 14;
            }
        }

        private void txtctacts_TextChanged(object sender, EventArgs e)
        {
            if (cboBanco.SelectedIndex == 1)
            {
                txtCtaBancaria.MaxLength = 20;
            }
            else if (cboBanco.SelectedIndex == 2)
            {
                txtCtaBancaria.MaxLength = 17;
            }
            else if (cboBanco.SelectedIndex == 3)
            {
                txtCtaBancaria.MaxLength = 24;
            }
            else if (cboBanco.SelectedIndex == 4)
            {
                txtCtaBancaria.MaxLength = 15;
            }
            else if (cboBanco.SelectedIndex == 5)
            {
                txtCtaBancaria.MaxLength = 20;
            }
            else if (cboBanco.SelectedIndex == 6)
            {
                txtCtaBancaria.MaxLength = 20;
            }
            else if (cboBanco.SelectedIndex == 7)
            {
                txtCtaBancaria.MaxLength = 14;
            }
        }

        private void txtAFPCUSS_TextChanged(object sender, EventArgs e)
        {
            txtAFPCUSS.MaxLength = 15;
        }

        private void cboAFP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAFP.SelectedIndex == 1)
            {
                txtAFPCUSS.Enabled = true;
                txtAFPCUSS.Text = "";
                cboTipoComicion.SelectedIndex = 0;
                cboTipoComicion.Enabled = true;
                cboMovimientoAFP.SelectedIndex = 0;
                cboMovimientoAFP.Enabled = true;
            }
            else if (cboAFP.SelectedIndex == 2)
            {
                txtAFPCUSS.Enabled = true;
                txtAFPCUSS.Text = "";
                cboTipoComicion.SelectedIndex = 0;
                cboTipoComicion.Enabled = true;
                cboMovimientoAFP.SelectedIndex = 0;
                cboMovimientoAFP.Enabled = true;
            }
            else if (cboAFP.SelectedIndex == 3)
            {
                txtAFPCUSS.Enabled = true;
                txtAFPCUSS.Text = "";
                cboTipoComicion.SelectedIndex = 0;
                cboTipoComicion.Enabled = true;
                cboMovimientoAFP.SelectedIndex = 0;
                cboMovimientoAFP.Enabled = true;
            }
            else if (cboAFP.SelectedIndex == 4)
            {
                txtAFPCUSS.Enabled = true;
                txtAFPCUSS.Text = "";
                cboTipoComicion.SelectedIndex = 0;
                cboTipoComicion.Enabled = true;
                cboMovimientoAFP.SelectedIndex = 0;
                cboMovimientoAFP.Enabled = true;
            }
            else if (cboAFP.SelectedIndex == 5)
            {
                txtAFPCUSS.Enabled = true;
                txtAFPCUSS.Text = "";
                cboTipoComicion.SelectedIndex = 0;
                cboTipoComicion.Enabled = true;
                cboMovimientoAFP.SelectedIndex = 0;
                cboMovimientoAFP.Enabled = true;
            }
            else if (cboAFP.SelectedIndex == 6)
            {
                txtAFPCUSS.Enabled = false;
                txtAFPCUSS.Text = "NO TIENE";
                cboTipoComicion.SelectedIndex = 3;
                cboTipoComicion.Enabled = false;
                cboMovimientoAFP.SelectedIndex = 2;
                cboMovimientoAFP.Enabled = false;
            }
            else if (cboAFP.SelectedIndex == 7)
            {
                txtAFPCUSS.Enabled = false;
                txtAFPCUSS.Text = "NO TIENE";
                cboTipoComicion.SelectedIndex = 4;
                cboTipoComicion.Enabled = false;
                cboMovimientoAFP.SelectedIndex = 3;
                cboMovimientoAFP.Enabled = false;
            }
            else if (cboAFP.SelectedIndex == 8)
            {
                txtAFPCUSS.Enabled = false;
                txtAFPCUSS.Text = "NO TIENE";
                cboTipoComicion.SelectedIndex = 5;
                cboTipoComicion.Enabled = false;
                cboMovimientoAFP.SelectedIndex = 4;
                cboMovimientoAFP.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            DateTime fechaInicio = dtpFechaInicio.Value;
            int TipoTrabajador = cboTipoTrabajador.SelectedIndex;
            decimal SueldoBasico = Convert.ToDecimal(txtSueldoBa.Text);
            decimal SueldoBruto = Convert.ToDecimal(txtxSueldoBruto.Text);
            decimal bonificacion = Convert.ToDecimal(txtbonificaion.Text);
            decimal movilidad = Convert.ToDecimal(txtmovilidad.Text);
            int AsignacionFamiliar = cboAsignacionFamiliar.SelectedIndex;
            int TipoPago = cboTipoPago.SelectedIndex;
            int PeriodoRemuneracion = cboPeriodidadRemuneracion.SelectedIndex;
            int bancosueldo = cboBanco.SelectedIndex;
            string cuentaBancaria = txtCtaBancaria.Text;
            int SueldoMoneda = cboTipoMoneda.SelectedIndex;
            int bancocts = cboBancoCTS.SelectedIndex;
            string cuentacts = txtctacts.Text;
            int ctsMoneda = cboTipMonCTS.SelectedIndex;
            int RegimenPensionario = cboRegimenPensionario.SelectedIndex;
            int afp = cboAFP.SelectedIndex;
            string afpcuss = txtAFPCUSS.Text;
            int tipocomicion = cboTipoComicion.SelectedIndex;
            int movimientoAFp = cboMovimientoAFP.SelectedIndex;
            decimal bonoarmado = Convert.ToDecimal(txtbonoArmado.Text);
            int bonoferiado = cboBonoFeriado.SelectedIndex;

            try
            {
                actualizar.ActualizarDatosLaborales(cod_empleado, fechaInicio, TipoTrabajador, SueldoBasico, SueldoBruto
                    , AsignacionFamiliar, TipoPago, PeriodoRemuneracion, bancosueldo, cuentaBancaria, SueldoMoneda
                    , bancocts, cuentacts, ctsMoneda, RegimenPensionario, afp, afpcuss, tipocomicion, movimientoAFp,
                    bonificacion, movilidad, bonoarmado, bonoferiado);
                MessageBox.Show("Datos Actualizados correctamente", "registro Actualizado correctamente");
                limpiar();
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("No se puede Actualizar los Datos del personal ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO  Actualizar datos personal \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            DateTime fechaInicio = dtpFechaInicio.Value;
            int TipoTrabajador = cboTipoTrabajador.SelectedIndex;
            decimal SueldoBasico = Convert.ToDecimal(txtSueldoBa.Text);
            decimal SueldoBruto = Convert.ToDecimal(txtxSueldoBruto.Text);
            decimal bonificacion = Convert.ToDecimal(txtbonificaion.Text);
            decimal movilidad = Convert.ToDecimal(txtmovilidad.Text);
            decimal bonoarmado = Convert.ToDecimal(txtbonoArmado.Text);
            int AsignacionFamiliar = cboAsignacionFamiliar.SelectedIndex;
            int TipoPago = cboTipoPago.SelectedIndex;
            int PeriodoRemuneracion = cboPeriodidadRemuneracion.SelectedIndex;
            int bancosueldo = cboBanco.SelectedIndex;
            string cuentaBancaria = txtCtaBancaria.Text;
            int SueldoMoneda = cboTipoMoneda.SelectedIndex;
            int bancocts = cboBancoCTS.SelectedIndex;
            string cuentacts = txtctacts.Text;
            int ctsMoneda = cboTipMonCTS.SelectedIndex;
            int RegimenPensionario = cboRegimenPensionario.SelectedIndex;
            int afp = cboAFP.SelectedIndex;
            string afpcuss = txtAFPCUSS.Text;
            int tipocomicion = cboTipoComicion.SelectedIndex;
            int movimientoAFp = cboMovimientoAFP.SelectedIndex;
            int bonoferiado = cboBonoFeriado.SelectedIndex;
            try
            {
                registrar.RegistrarDatosLaborales(cod_empleado, fechaInicio, TipoTrabajador, SueldoBasico, SueldoBruto
                    , AsignacionFamiliar, TipoPago, PeriodoRemuneracion, bancosueldo, cuentaBancaria, SueldoMoneda
                    , bancocts, cuentacts, ctsMoneda, RegimenPensionario, afp, afpcuss, tipocomicion, movimientoAFp,
                    bonificacion, movilidad, bonoarmado, bonoferiado);
                MessageBox.Show("Datos registrado correctamente", "registro registrado correctamente");
                limpiar();
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("No se puede registrar los datos " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO  Al registrar los datos personales \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
