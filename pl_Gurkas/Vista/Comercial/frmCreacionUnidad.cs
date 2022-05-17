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

namespace pl_Gurkas.Vista.Comercial
{
    public partial class frmCreacionUnidad : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDeDatosComercial Llenadocbo = new Datos.LlenadoDeDatosComercial();
        Datos.registrar registrar = new Datos.registrar();
        Datos.agregarDatosMysql registrarmysql = new Datos.agregarDatosMysql();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Datos.actualizarmysql actualizarmysql = new Datos.actualizarmysql();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public frmCreacionUnidad()
        {
            InitializeComponent();
        }
        private void registarUnidad()
        {
            try
            {
                string codUnidad = txtCodUnidad.Text;
                string RazonSocial = txtRazonSocial.Text;
                string RUC = txtRuc.Text;
                string NombreComercial = txtNombreComercial.Text;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string Direccion = txtDireccion.Text;
                string RepresentanteLegal = txtRepresentanteLegal.Text;
                string dni = txtDni.Text;
                string cargo = txtCargo.Text;
                string contacto = txtContacto.Text;
                int Telefono = (int)Convert.ToInt64(txtTelefono.Text);
                int Celular = (int)Convert.ToInt64(txtCelular.Text);
                string Correo = txtCorreo.Text;
                string centroCosto = txtCentroCosto.Text;

                string latitud = txtLatitud.Text;
                string longitud = txtlongitud.Text;

                int empresa = cboEmpresa.SelectedIndex;
                int estadoUnidad = cboEstadoUnidad.SelectedIndex;
                DateTime Factivacion = dtpActivacion.Value;
                DateTime Fbaja = dtpBaja.Value;

                registrar.RegistrarUnidad(codUnidad, RazonSocial, RUC, NombreComercial,
                  codDep, codPro, codDist, Direccion, RepresentanteLegal, dni, cargo, contacto, Telefono,
                  Celular, Correo, centroCosto, Factivacion, Fbaja, empresa, estadoUnidad, latitud, longitud);

                registrarmysql.RegistroUnidad(codUnidad, RazonSocial, NombreComercial, estadoUnidad, latitud, longitud, Direccion, empresa);

                MessageBox.Show("Datos registrado correptamente", "Correpto");
                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                GenerarCodigo();
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("No se puede Regristrar la Unidad");
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void ActualizarUnidad()
        {
            try
            {
                string codUnidad = txtCodUnidad.Text;
                string RazonSocial = txtRazonSocial.Text;
                string RUC = txtRuc.Text;
                string NombreComercial = txtNombreComercial.Text;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string Direccion = txtDireccion.Text;
                string RepresentanteLegal = txtRepresentanteLegal.Text;
                string dni = txtDni.Text;
                string cargo = txtCargo.Text;
                string contacto = txtContacto.Text;
                int Telefono = (int)Convert.ToInt64(txtTelefono.Text);
                int Celular = (int)Convert.ToInt64(txtCelular.Text);
                string Correo = txtCorreo.Text;
                string centroCosto = txtCentroCosto.Text;

                string latitud = txtLatitud.Text;
                string longitud = txtlongitud.Text;

                int empresa = cboEmpresa.SelectedIndex;
                int estadoUnidad = cboEstadoUnidad.SelectedIndex;
                DateTime Factivacion = dtpActivacion.Value;
                DateTime Fbaja = dtpBaja.Value;
                 actualizar.ActualizarUnidad(codUnidad, RazonSocial, RUC, NombreComercial,
                  codDep, codPro, codDist, Direccion, RepresentanteLegal, dni, cargo, contacto, Telefono,
                  Celular, Correo, centroCosto, Factivacion, Fbaja, empresa, estadoUnidad, latitud, longitud);
            
                actualizarmysql.ActualizarUnidad(codUnidad, RazonSocial, NombreComercial, estadoUnidad, latitud, longitud, Direccion, empresa);
                
                MessageBox.Show("Datos actualizado correptamente", "Correpto");


                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                LimpiarDatos.LimpiarCampo(this);
                GenerarCodigo();
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("No se puede Actualizar la Unidad" + ex);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void BuscarUnidad(string codUnidad)
        {
            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM T_UNIDAD WHERE Cod_unidad = '" + codUnidad + "'", conexion.conexionBD());
                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtCodUnidad.Text = recorre["COD_UNIDAD"].ToString();
                    txtRazonSocial.Text = recorre["RAZON_SOCIAL"].ToString();
                    txtRuc.Text = recorre["RUC"].ToString();
                    txtNombreComercial.Text = recorre["NOMBRE_COMERCIAL"].ToString();
                    cboDepartamento.SelectedValue = recorre["COD_DEPARTAMENTO"].ToString();
                    cboProvincia.SelectedValue = recorre["COD_PROVINCIA"].ToString();
                    cboDis.SelectedValue = recorre["COD_DISTRITO"].ToString();
                    txtDireccion.Text = recorre["DIRECCION"].ToString();
                    txtRepresentanteLegal.Text = (recorre["REPRESENTANTE_LEGAL"].ToString());
                    txtDni.Text = recorre["DOCT_IDENT_REPRE_LEG"].ToString();
                    txtCargo.Text = (recorre["CARGO_REPRE_LEG"].ToString());
                    txtContacto.Text = (recorre["CONTACTO"].ToString());
                    txtTelefono.Text = recorre["TELEFONO"].ToString();
                    txtCelular.Text = recorre["CELULAR"].ToString();
                    txtCorreo.Text = recorre["CORREO"].ToString();
                    txtCentroCosto.Text = recorre["CENTRO_COSTO"].ToString();

                    txtLatitud.Text = recorre["latitud"].ToString();
                    txtlongitud.Text = recorre["longitud"].ToString();

                    cboEmpresa.SelectedIndex = Convert.ToInt32(recorre["ID_EMPRESA"].ToString());
                    cboEstadoUnidad.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_UNIDAD"].ToString());
                    dtpActivacion.Text = (recorre["FECHA_ACTIVACION_UNIDAD"].ToString());
                    dtpBaja.Text = (recorre["FECHA_BAJA_UNIDAD"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + ex, "ERROR");
            }
        }
        public void GenerarCodigo()
        {
            string resultado = "";
            SqlCommand comando = new SqlCommand("select count(COD_UNIDAD) as 't' from T_UNIDAD ", conexion.conexionBD());

            SqlDataReader recorre = comando.ExecuteReader();
            while (recorre.Read())
            {
                resultado = recorre["t"].ToString();
            }
            int numero = Convert.ToInt32(resultado);
            txtCodUnidad.Text = "CA00" + (numero + 1);
        }
        private void llenadocbo()
        {
            Llenadocbo.ObtenerEmpresaComercial(cboEmpresa);
            Llenadocbo.ObtenerEstadoUnidadComercial(cboEstadoUnidad);
            Llenadocbo.ObtenerDepartamentoComercial(cboDepartamento);
            Llenadocbo.ObtenerUnidadComercial(cboUnidad);
        }

        private void frmCreacionUnidad_Load(object sender, EventArgs e)
        {
            llenadocbo();
            dgvRegistroUnidad.RowHeadersVisible = false;
            dgvRegistroUnidad.AllowUserToAddRows = false;
            txtCodUnidad.Enabled = false;

            GenerarCodigo();
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue.ToString() != null)
            {
                string Cod_Departamento = cboDepartamento.SelectedValue.ToString();
                Llenadocbo.ObtenerProvinciaComercial(cboProvincia, Cod_Departamento);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue.ToString() != null)
            {
                string Cod_Provincia = cboProvincia.SelectedValue.ToString();
                Llenadocbo.ObtenerDistritosComercial(cboDis, Cod_Provincia);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Unidad";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Unidad";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
                modulo.auditoriaFunciones("Comercial", "Cerrar Modulo", "Cerrar el Modulo de Creacion de nueva Unidad");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.LimpiarGroupBox(groupBox3);
            LimpiarDatos.LimpiarCampo(this);
            GenerarCodigo();
            txtCodUnidad.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codUnidad = cboUnidad.SelectedValue.ToString();
            BuscarUnidad(codUnidad);
            modulo.auditoriaFunciones("Comercial","Buscar Unidad","Busqueda de la unidad : " + codUnidad);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codUnidad = txtCodUnidad.Text;
            ActualizarUnidad();
            modulo.auditoriaFunciones("Comercial", "Actualizar Datos de la Unidad", "Actualizar datos de la unidad : " + codUnidad);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string  codUnidad = txtCodUnidad.Text;
            registarUnidad();
            modulo.auditoriaFunciones("Comercial", "Registrar una nueva Unidad", "Registro de la unidad : " + codUnidad);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
