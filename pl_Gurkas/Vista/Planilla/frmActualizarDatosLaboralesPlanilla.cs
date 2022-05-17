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
    public partial class frmActualizarDatosLaboralesPlanilla : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDatosPlanilla Llenadocbo = new Datos.LlenadoDatosPlanilla();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();

        public frmActualizarDatosLaboralesPlanilla()
        {
            InitializeComponent();
        }

        private void frmActualizarDatosLaboralesPlanilla_Load(object sender, EventArgs e)
        {
            txtSueldoBaActual.Enabled = false;
            txtxSueldoBrutoActual.Enabled = false;
            dtpFechaInicioActual.Enabled = false;
            Llenadocbo.ObtenerPersonalPLANILLA(cboempleadoActivo);
            Llenadocbo.ObtenerBancoPLANILLAS(cboBanco);
            Llenadocbo.ObtenerBancoPLANILLAS(cbobancoNuevo);
            Llenadocbo.ObtenerBonoFamiliarPLANILLAS(cboAsignacionFamiliar);
            Llenadocbo.ObtenerBonoFeriadoPLANILLAS(cboBonoFeriado);
            Llenadocbo.ObtenerBonoFamiliarPLANILLAS(cboAsignacionFamiliarNuevo);
            Llenadocbo.ObtenerBonoFeriadoPLANILLAS(cboBonoFeriadonuevo);

            Llenadocbo.ObtenerRegimenPensionarioPLANILLAS(cboRegimenPensionario);
            Llenadocbo.ObtenerAFPPLANILLAS(cboAFP);
            Llenadocbo.ObtenerTipoComisionAFPPLANILLAS(cboTipoComicion);
            Llenadocbo.ObtenerMovimientoAFPPLANILLAS(cboMovimientoAFP);

            Llenadocbo.ObtenerRegimenPensionarioPLANILLAS(cboregimenpensionarionuevo);
            Llenadocbo.ObtenerAFPPLANILLAS(cboafpnuevo);
            Llenadocbo.ObtenerTipoComisionAFPPLANILLAS(cbotipocomisionnuevo);
            Llenadocbo.ObtenerMovimientoAFPPLANILLAS(cbomovimientoafpnuevo);

            cboBanco.Enabled = false;
            cboAsignacionFamiliar.Enabled = false;
            cboBonoFeriado.Enabled = false;
            txtBonoArmado.Enabled = false;
            txtBonificacion.Enabled = false;
            txtMovilidad.Enabled = false;
            txtcuenta.Enabled = false;

            cboRegimenPensionario.Enabled = false;
            cboAFP.Enabled = false;
            cboTipoComicion.Enabled = false;
            cboMovimientoAFP.Enabled = false;
            txtAFPCUSS.Enabled = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM v_buscar_empelado_sueldo WHERE Cod_empleado = '" + cod_empleado + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtSueldoBaActual.Text = recorre["SUELDO_BASICO"].ToString();
                    txtxSueldoBrutoActual.Text = recorre["SUELDO_BRUTO"].ToString();
                    dtpFechaInicioActual.Text = (recorre["FECHA_INICIO"].ToString());
                    txtBonoArmado.Text = (recorre["BONO_ARMADO"].ToString());
                    txtBonificacion.Text = (recorre["BonoProductividad_BONIFICACION"].ToString());
                    txtMovilidad.Text = (recorre["BonoProduccion_MOVILIDAD"].ToString());
                    cboBanco.SelectedIndex = Convert.ToInt32((recorre["id_banco"].ToString()));
                    cboAsignacionFamiliar.SelectedIndex = Convert.ToInt32((recorre["ID_BonoFamiliar"].ToString()));
                    cboBonoFeriado.SelectedIndex = Convert.ToInt32((recorre["ID_FERIADO"].ToString()));
                    txtcuenta.Text = (recorre["Cta_sueldo"].ToString());
                    cboRegimenPensionario.SelectedIndex = Convert.ToInt32((recorre["id_ReguimenPensionario"].ToString()));
                    cboAFP.SelectedIndex = Convert.ToInt32((recorre["id_afp"].ToString()));
                    txtAFPCUSS.Text = (recorre["AFP_CUPSS"].ToString());
                    cboTipoComicion.SelectedIndex = Convert.ToInt32((recorre["ID_TipoComisionAFP"].ToString()));
                    cboMovimientoAFP.SelectedIndex = Convert.ToInt32((recorre["ID_MovimientoAFP"].ToString()));


                    txtBasico.Text = recorre["SUELDO_BASICO"].ToString();
                    txtBruto.Text = recorre["SUELDO_BRUTO"].ToString();
                    dtpNuevoSueldo.Text = (recorre["FECHA_INICIO"].ToString());
                    txtbonoarmandonuevo.Text = (recorre["BONO_ARMADO"].ToString());
                    txtbonificacionnuevo.Text = (recorre["BonoProductividad_BONIFICACION"].ToString());
                    txtmovilidadnuevo.Text = (recorre["BonoProduccion_MOVILIDAD"].ToString());
                    cbobancoNuevo.SelectedIndex = Convert.ToInt32((recorre["id_banco"].ToString()));
                    txtcuentanuevo.Text = (recorre["Cta_sueldo"].ToString());
                    cboAsignacionFamiliarNuevo.SelectedIndex = Convert.ToInt32((recorre["ID_BonoFamiliar"].ToString()));
                    cboBonoFeriadonuevo.SelectedIndex = Convert.ToInt32((recorre["ID_FERIADO"].ToString()));
                    cboregimenpensionarionuevo.SelectedIndex = Convert.ToInt32((recorre["id_ReguimenPensionario"].ToString()));
                    cboafpnuevo.SelectedIndex = Convert.ToInt32((recorre["id_afp"].ToString()));
                    txtafpcusppnuevo.Text = (recorre["AFP_CUPSS"].ToString());
                    cbotipocomisionnuevo.SelectedIndex = Convert.ToInt32((recorre["ID_TipoComisionAFP"].ToString()));
                    cbomovimientoafpnuevo.SelectedIndex = Convert.ToInt32((recorre["ID_MovimientoAFP"].ToString()));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cod_empleado = cboempleadoActivo.SelectedValue.ToString();
            DateTime fechaInicio = dtpFechaInicioActual.Value;
            DateTime fechaFin = dtpNuevoSueldo.Value;
            decimal SueldoBasico = Convert.ToDecimal(txtBasico.Text);
            decimal SueldoBruto = Convert.ToDecimal(txtBruto.Text);
            decimal bonoarmado = Convert.ToDecimal(txtbonoarmandonuevo.Text);
            decimal bonificaion = Convert.ToDecimal(txtbonificacionnuevo.Text);
            decimal movilidad = Convert.ToDecimal(txtmovilidadnuevo.Text);
            int banco = cbobancoNuevo.SelectedIndex;
            string cuenta = txtcuentanuevo.Text;

            int familiar = cboAsignacionFamiliarNuevo.SelectedIndex;
            int bonoferiado = cboBonoFeriadonuevo.SelectedIndex;
            int regimen_pensionario = cboregimenpensionarionuevo.SelectedIndex;
            int afp = cboafpnuevo.SelectedIndex;
            string afpcussp = txtafpcusppnuevo.Text;
            int tipo_comision = cbotipocomisionnuevo.SelectedIndex;
            int movimiento_afp = cbomovimientoafpnuevo.SelectedIndex;

            try
            {
                actualizar.ActualizarDatosLaboralesSueldo(cod_empleado, fechaInicio, fechaFin, SueldoBasico, SueldoBruto, bonoarmado, bonificaion, movilidad, banco, cuenta,
                   familiar, bonoferiado, regimen_pensionario, afp, afpcussp, tipo_comision, movimiento_afp);
                MessageBox.Show("Datos Actualizados correctamente", "registro Actualizado correctamente");
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("No se puede Actualizar el sueldo del personal ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO  Actualizar datos personal \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
