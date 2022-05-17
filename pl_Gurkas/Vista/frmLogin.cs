using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDeDatos llenadocbo = new Datos.LlenadoDeDatos();
        Datos.Login login = new Datos.Login();
        string ip = "", nombrepc = "";
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
                ip = /*"Direccion IP: "+*/hostIPs[i].ToString();

            }
            nombrepc = /*"Nombre de la computadora: " + */strHostName;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int empresa = cboEmpresa.SelectedIndex;
            string nombre_emp = cboEmpresa.GetItemText(cboEmpresa.SelectedItem);
            string usurname = txtUser.Text.ToUpper();
            string pass = txtPass.Text.ToUpper();

            if (empresa == 0)
            {
                MessageBox.Show("Debe elejir una Empresa", "GRUPO GURKAS");
            }
            if (txtUser.Text.Length == 0 && txtPass.Text.Length == 0) 
            {
                const string titulo = "Falta Usuario y Contraseña";
                const string mensaje = "Falta ingresar el usuario y la contraseña";
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUser.Text.Length == 0)
            {
                const string titulo = "Falta Usuario";
                const string mensaje = "Falta ingresar el usuario";
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPass.Text.Length == 0)
            {
                const string titulo = "Falta Contraseña";
                const string mensaje = "Falta ingresar la Contraseña";
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Datos.EmpresaID._empresaid = empresa;
                
                login.InicioSesion(this,usurname, pass, empresa, nombre_emp);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            const string titulo = "Salir";
            const string mensaje = "Estas seguro que deseas Cerrar el Sistema";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                obtenerip_nombre();
                //string username = tsNombre.Text;
                //  string detalle = "Cerrar el Sistema";
                //  registrar.RegistrarLogin(fecha, nombrepc, username, ipuser, detalle);
                Application.Exit();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            obtenerip_nombre();
            llenadocbo.ObtenerEmpresa(cboEmpresa);
            lblip.Text = ip;
            lblnombre.Text = nombrepc;
            lblip.Visible = false;
            lblnombre.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }
    }
}
