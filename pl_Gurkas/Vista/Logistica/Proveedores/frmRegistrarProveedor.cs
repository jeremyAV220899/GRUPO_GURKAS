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

namespace pl_Gurkas.Vista.Logistica.Proveedores
{
    public partial class frmRegistrarProveedor : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LimpiarDatos LimpiarDatos = new Datos.LimpiarDatos();
        Datos.llenadoDatosLogistica Llenadocbo = new Datos.llenadoDatosLogistica();
        Datos.registrar registrar = new Datos.registrar();
        Datos.Actualizar actualizar = new Datos.Actualizar();

        public frmRegistrarProveedor()
        {
            InitializeComponent();
        }
        private void showDialogs(String message, Color bdColor)
        {
            Vista.MensajeEmergente.DialogForm dialog = new Vista.MensajeEmergente.DialogForm(message, bdColor);
            dialog.Show();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public void GenerarCodigo()
        {
            string resultado = "";
            SqlCommand comando = new SqlCommand("select count(cod_proveedor) as 't' from t_proverdores ", conexion.conexionBD());

            SqlDataReader recorre = comando.ExecuteReader();
            while (recorre.Read())
            {
                resultado = recorre["t"].ToString();
            }
            int numero = Convert.ToInt32(resultado);
            if (numero< 10 )
            {
                txtcodproveedor.Text = "PROV000" + (numero + 1);
            }
            if (numero >9 && numero <100)
            {
                txtcodproveedor.Text = "PROV00" + (numero + 1);
            }
            if (numero>99 && numero <1000)
            {
                txtcodproveedor.Text = "PROV0" + (numero + 1);
            }
        }

        private void ValidarCamposVacios()
        {
          
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
            if (txtcodproveedor.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Codigo", "Advertencia");
            }
            if (txtNombreProveedor.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Nombre", "Advertencia");
            }
            if (txtruc.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un RUC", "Advertencia");
            }
            if (txtObservacion.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una observacion", "Advertencia");
            }
            if (txtDireccion.Text.Length == 0)
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
            if (txtcomentario.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un comentario", "Advertencia");
            }
            if (txtpaginaweb.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una pagina web", "Advertencia");
            }
            if (txtRubro.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Rubro", "Advertencia");
            }
            if (txtnombrecontacto.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un nombre de contacto", "Advertencia");
            }
            if (txtTelefono1.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un telefono 1", "Advertencia");
            }
            if (txtTelefono2.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un telefono 2", "Advertencia");
            }
        }
        private void ActualizarPersonal()
        {
            try
            {
                string cod_proveedor_cbo = cboProveedor.SelectedValue.ToString();
                string Nombre = txtNombreProveedor.Text;
                string ruc = txtruc.Text;
                string observacion = txtObservacion.Text;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string direccion = txtDireccion.Text;
                string Telefono = txtTelefono.Text;
                string Celular = txtCelular.Text;
                string Correo = txtCorreo.Text;
                DateTime fregistro = dtpFechaInicio.Value;
                string paginaweb = txtpaginaweb.Text;
                string nota = txtcomentario.Text;
                string rubo = txtRubro.Text;
                string nombre_contacto = txtnombrecontacto.Text;
                string telefono1 = txtTelefono1.Text;
                string telefono2 = txtTelefono2.Text;

                actualizar.actualizarProveedor(cod_proveedor_cbo, Nombre, ruc, observacion, codDep, codPro,
                    codDist, direccion, Telefono, Celular, Correo, fregistro, paginaweb, nota, rubo,
                    nombre_contacto, telefono1, telefono2);
                MessageBox.Show("Datos actualizado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                // LimpiarDatos.LimpiarCampo(this);

                showDialogs("Datos Actualizados", Color.FromArgb(0, 200, 81));
                GenerarCodigo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede Actualizar los datos \n"+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
            }
        }
        private void RegistrarProveedor()
        {
            try
            {
                string codProveedor = txtcodproveedor.Text;
                string Nombre = txtNombreProveedor.Text;
                string ruc = txtruc.Text;
                string observacion = txtObservacion.Text;
                string Departamento = cboDepartamento.SelectedValue.ToString();
                int codDep = (int)Convert.ToInt64(Departamento);
                string Provincia = cboProvincia.SelectedValue.ToString();
                int codPro = (int)Convert.ToInt64(Provincia);
                string Distrito = cboDis.SelectedValue.ToString();
                int codDist = (int)Convert.ToInt64(Distrito);
                string direccion = txtDireccion.Text;
                string Telefono = txtTelefono.Text;
                string Celular = txtCelular.Text;
                string Correo = txtCorreo.Text;
                DateTime fregistro = dtpFechaInicio.Value;
                string paginaweb = txtpaginaweb.Text;
                string nota = txtcomentario.Text;
                string rubo = txtRubro.Text;
                string nombre_contacto = txtnombrecontacto.Text;
                string telefono1 = txtTelefono1.Text;
                string telefono2 = txtTelefono2.Text;

                registrar.registrarProveedor( codProveedor,  Nombre,  ruc,  observacion,  codDep,  codPro,
                    codDist,  direccion,  Telefono,  Celular,  Correo,  fregistro,paginaweb,  nota,  rubo, 
                    nombre_contacto,  telefono1,  telefono2);
                MessageBox.Show("Datos registrado correptamente", "Correpto");

                LimpiarDatos.LimpiarGroupBox(groupBox1);
                LimpiarDatos.LimpiarGroupBox(groupBox3);
                // LimpiarDatos.LimpiarCampo(this);

                showDialogs("Datos Registrados", Color.FromArgb(0, 200, 81));
                GenerarCodigo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                showDialogs("Advertencia", Color.FromArgb(255, 187, 51));
            }
        }
        private void frmRegistrarProveedor_Load(object sender, EventArgs e)
        {
            Llenadocbo.ObtenerDepartamentoLogistica(cboDepartamento);
            Llenadocbo.ObtenerProveedoresLogistico(cboProveedor);
            txtcodproveedor.Enabled = false;
            GenerarCodigo();
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue.ToString() != null)
            {
                string Cod_Departamento = cboDepartamento.SelectedValue.ToString();
                Llenadocbo.ObtenerProvinciaLogistica(cboProvincia, Cod_Departamento);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue.ToString() != null)
            {
                string Cod_Provincia = cboProvincia.SelectedValue.ToString();
                Llenadocbo.ObtenerDistritosLogistica(cboDis, Cod_Provincia);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ValidarCamposVacios();
            RegistrarProveedor();


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos.LimpiarGroupBox(groupBox1);
            LimpiarDatos.LimpiarGroupBox(groupBox3);
            //LimpiarDatos.LimpiarCampo(this);
            txtNombreProveedor.Focus();
            GenerarCodigo();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ValidarCamposVacios();
            ActualizarPersonal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_provedor = cboProveedor.SelectedValue.ToString();

                SqlCommand comando = new SqlCommand("select *from t_proverdores where cod_proveedor = '" + cod_provedor + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtcodproveedor.Text = recorre["cod_proveedor"].ToString();
                    txtNombreProveedor.Text = recorre["nombre_proveedor"].ToString();
                    txtruc.Text = recorre["ruc"].ToString();
                    txtObservacion.Text = recorre["observaciones"].ToString();
                    cboDepartamento.SelectedValue = recorre["departamento"].ToString();
                    cboProvincia.SelectedValue = recorre["provincia"].ToString();
                    cboDis.SelectedValue = recorre["distrito"].ToString();
                    txtDireccion.Text = recorre["direccion"].ToString();
                    txtTelefono.Text = recorre["telefono"].ToString();
                    txtCelular.Text = recorre["celular"].ToString();
                    txtCorreo.Text = recorre["correo"].ToString();
                    dtpFechaInicio.Text = (recorre["fecha_registro"].ToString());
                    txtpaginaweb.Text = recorre["pagina_web"].ToString();
                    txtcomentario.Text = recorre["nota_comentario"].ToString();
                    txtRubro.Text = recorre["rubro"].ToString();
                    txtnombrecontacto.Text = recorre["nombre_contacto"].ToString();
                    txtTelefono1.Text = recorre["telefono1"].ToString();
                    txtTelefono2.Text = recorre["telefono2"].ToString();

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }
    }
}
