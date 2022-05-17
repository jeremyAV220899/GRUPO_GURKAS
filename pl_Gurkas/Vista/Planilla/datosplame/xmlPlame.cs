using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Planilla.datosplame
{
    public partial class xmlPlame : Form
    {
        public xmlPlame()
        {
            InitializeComponent();
        }

        private void xmlPlame_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
           // OpenFileDialog1.InitialDirectory = "C:\\Users\\fraccion\\Desktop";
            OpenFileDialog1.Filter = "xml files (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
            OpenFileDialog1.FilterIndex = 2;
            OpenFileDialog1.RestoreDirectory = true;
            OpenFileDialog1.Multiselect = true;

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(@"C:\Users\user\Desktop\modelo\prueba.xml");
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
           // cuadrotxt.AppendText("Archivos Listos Para Su Analisis");
        }
    }
}
