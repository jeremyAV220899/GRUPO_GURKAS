using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.PantallaInicio
{
    public partial class frmPantallaPrincipal : Form
    {
        public frmPantallaPrincipal()
        {
            InitializeComponent();
        }
        public int _conexion = 0;
        string result = "";
        int estado = 0;
        /*ping para saber si hay internet*/
        public void conexioninternet()
        {
            System.Uri Url = new System.Uri("http://www.google.com/");
            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objResp;
            try
            {
                DateTime fecha = DateTime.Now;
                String anio = Convert.ToString(fecha.Year);
                objResp = WebRequest.GetResponse();
                result = "Su dispositivo está correctamente conectado INTERNET" + " Copyright © " + anio;
                estado = 1;
                objResp.Close();
                WebRequest = null;
            }
            catch (Exception ex)
            {
                result = "Error al intentar conectarse a internet " + ex.Message;
                estado = 2;
                WebRequest = null;
            }
        }
        /*ping al servidor */
        private void conexionvpn()
        {
            Ping Pings = new Ping();
            int timeout = 10;

            if (Pings.Send("26.11.117.148", timeout).Status == IPStatus.Success)
            {
                DateTime fecha = DateTime.Now;
                String anio = Convert.ToString(fecha.Year);
                result = "Su dispositivo está correctamente conectado VPN " + " Copyright © " + anio;
                estado = 1;
            }
            else
            {
                result = "Error al intentar conectarse al sistema ";
                estado = 2;
            }
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (estado == 1)
            {
                Vista.frmLogin login = new Vista.frmLogin();
                login.Show();
                this.Hide();
            }
            if (estado == 2)
            {
                const string titulo = "ERROR";
                const string mensaje = "Verifique la conexion";
                var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resutlado == DialogResult.Yes)
                {
                    MessageBox.Show("Verifique su conexion al servidor o internet", "GRUPO GURKAS S.A.C.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmPantallaPrincipal_Load(object sender, EventArgs e)
        {
            if (_conexion == 1)
            {
                conexioninternet();
                lblResultado.Text = result;
                if (estado == 1)
                {
                    lblResultado.ForeColor = Color.Black;
                }
                if (estado == 2)
                {
                    lblEstado.ForeColor = Color.Red;
                    lblResultado.ForeColor = Color.Red;
                }
            }
           if(_conexion == 2)
           {
                conexionvpn();
                lblResultado.Text = result;
                if (estado == 1)
                {
                    lblResultado.ForeColor = Color.Black;
                }
                if (estado == 2)
                {
                    lblEstado.ForeColor = Color.Red;
                    lblResultado.ForeColor = Color.Red;
                }
           }
        }
    }
}
