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
    public partial class frmCreacionSedes : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.ConexionMysql conexions = new Datos.ConexionMysql();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.LlenadoDeDatosComercial Llenadocbo = new Datos.LlenadoDeDatosComercial();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();
        Datos.agregarDatosMysql registrarMYSQL = new Datos.agregarDatosMysql();
        Datos.actualizarmysql actualizarMYSQL = new Datos.actualizarmysql();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public frmCreacionSedes()
        {
            InitializeComponent();
        }
        private void registarSede()
        {
            try
            {
                string codSede = txtCodSede.Text;
                string NombreSede = txtNombreSede.Text;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string Direccion = txtDireccion.Text;
                string Contacto = txtContacto.Text;
                string Correo = txtCorreo.Text;
                int Celular = (int)Convert.ToInt64(txtCelular.Text);
                string centroCosto = txtCentroCosto.Text;
                string unidad = cboUnidad.SelectedValue.ToString();

                string longitud = txtlongitud.Text;
                string latitud = txtlatitud.Text;

                int estadoSede = cboEstadoSede.SelectedIndex;
                DateTime fActivacion = dtpActivacion.Value;
                DateTime fBaja = dtpBaja.Value;

                registrar.RegistrarSede(codSede, NombreSede,
                  codDep, codPro, codDist, Direccion, Contacto, Correo,
                  Celular, centroCosto, unidad, estadoSede, fActivacion, fBaja, latitud, longitud);

                registrarMYSQL.RegistroSede(codSede, NombreSede, estadoSede, latitud, longitud, Direccion, unidad);

                MessageBox.Show("Datos registrado correptamente", "Correpto");
                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                GenerarCodigo();
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("No se puede Regristrar la Sede ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO  Registrar Sede \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void ActualizarSede()
        {
            try
            {
                string codSede = txtCodSede.Text;
                string NombreSede = txtNombreSede.Text;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string Direccion = txtDireccion.Text;
                string Contacto = txtContacto.Text;
                string Correo = txtCorreo.Text;
                int Celular = (int)Convert.ToInt64(txtCelular.Text);
                string centroCosto = txtCentroCosto.Text;
                string unidad = cboUnidad.SelectedValue.ToString();

                string longitud = txtlongitud.Text;
                string latitud = txtlatitud.Text;

                int estadoSede = cboEstadoSede.SelectedIndex;
                DateTime fActivacion = dtpActivacion.Value;
                DateTime fBaja = dtpBaja.Value;

                actualizar.ActualizarSede(codSede, NombreSede,
                  codDep, codPro, codDist, Direccion, Contacto, Correo,
                  Celular, centroCosto, unidad, estadoSede, fActivacion, fBaja, latitud, longitud);

                actualizarMYSQL.ActualizarSede(codSede, NombreSede, estadoSede, latitud, longitud, Direccion, unidad);
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
                    MessageBox.Show("No se puede Actualizar la Sede ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO  Actualizar Sede \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void BuscarSede( string codSede)
        {
            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM T_SEDE WHERE Cod_sede = '" + codSede + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtCodSede.Text = recorre["Cod_sede"].ToString();
                    txtNombreSede.Text = recorre["Nombre_sede"].ToString();
                    cboDepartamento.SelectedValue = recorre["Cod_Departamento"].ToString();
                    cboProvincia.SelectedValue = recorre["cod_Provincia"].ToString();
                    cboDis.SelectedValue = recorre["Cod_Distrito"].ToString();
                    txtDireccion.Text = recorre["Direccion"].ToString();
                    txtContacto.Text = (recorre["Contacto_sede"].ToString());
                    txtCorreo.Text = recorre["Correo"].ToString();
                    txtCelular.Text = recorre["celular"].ToString();
                    txtCentroCosto.Text = recorre["Centro_costo_sede"].ToString();
                    cboUnidad.SelectedValue = recorre["Cod_unidad"].ToString();

                    txtlatitud.Text = recorre["latitud"].ToString();
                    txtlongitud.Text = recorre["longitud"].ToString();

                    cboEstadoSede.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_SEDE"].ToString());
                    dtpActivacion.Text = (recorre["FECHA_ACTIVACION_SEDE"].ToString());
                    dtpBaja.Text = (recorre["FECHA_BAJA_SEDE"].ToString());
                }
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("No se encontro ningun registro ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN EL PROCESO ALMACENADO  Buscar Sede \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void GenerarCodigo()
        {
            string resultado = "";
            SqlCommand comando = new SqlCommand("select count(COD_SEDE) as 't' from T_SEDE ", conexion.conexionBD());

            SqlDataReader recorre = comando.ExecuteReader();
            while (recorre.Read())
            {
                resultado = recorre["t"].ToString();
            }
            int numero = Convert.ToInt32(resultado);
            txtCodSede.Text = "CS0" + (numero + 1);
        }
        private void llenadocbo()
        {
            Llenadocbo.ObtenerEstadoSedeComercial(cboEstadoSede);
            Llenadocbo.ObtenerDepartamentoComercial(cboDepartamento);
            Llenadocbo.ObtenerUnidadComercial(cboUnidad);
            Llenadocbo.ObtenerUnidadComercial(cboUnidadb);
        }
        private void frmCreacionSedes_Load(object sender, EventArgs e)
        {
            dgvRegistroSede.RowHeadersVisible = false;
            dgvRegistroSede.AllowUserToAddRows = false;
            txtCodSede.Enabled = false;
            GenerarCodigo();
            llenadocbo();
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

        private void cboUnidadb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidadb.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidadb.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeComercial(cboSede, cod_unidad);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.LimpiarGroupBox(groupBox2);
            LimpiarDatos.LimpiarGroupBox(groupBox3);
            LimpiarDatos.LimpiarCampo(this);
            GenerarCodigo();
            txtCodSede.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Sede";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Sede";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
                modulo.auditoriaFunciones("Comercial", "Cerrar", " Cerrado del modulo de Sede");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codSede = cboSede.SelectedValue.ToString();
            BuscarSede(codSede);
            modulo.auditoriaFunciones("Comercial", "Buscar Sede", "Busqueda de la sede : " + codSede);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codsede = txtCodSede.Text;
            ActualizarSede();
            modulo.auditoriaFunciones("Comercial", "Actualizar  sede", "se Actualizar la  sede  : " + codsede);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string codsede =  txtCodSede.Text;
            registarSede();
            modulo.auditoriaFunciones("Comercial", "Agregar nueva sede", "se agrego la nueva sede  : " + codsede);
        }

      
    }
}
