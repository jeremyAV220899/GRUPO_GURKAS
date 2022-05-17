using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Datos
{
    class ConexionMysql
    {
        public  MySqlConnection ObtenerConexion()
        {

            MySqlConnection vConn = new MySqlConnection("Data Source=67.222.149.58; port = 3306;User Id=gurkasne;Password=Gurk@$2022; database=gurkasne_movile");
                try
                {
                vConn.Open();
                   
                } catch (Exception ex)
                {
                  
                }
            return vConn;
        }

        public MySqlConnection ObtenerConexionPostulantes()
        {

            MySqlConnection vConn = new MySqlConnection("Data Source=67.222.149.58; port = 3306;User Id=gurkasne;Password=Gurk@$2022; database=gurkasne_postulante");
            try
            {
                vConn.Open();

            }
            catch (Exception ex)
            {

            }
            return vConn;
        }
    }
}
