using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl_Gurkas.Datos
{
    class Conexiondbo
    {
        public SqlConnection conexionBD()
        {
            SqlConnection cn = new SqlConnection("Data Source=DCGURKAS;Initial Catalog=GRUPO_GURKAS;User ID=sa;Password=Gurkas2019");
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
            else
            {
                cn.Open();
            }
            return cn;
        }
    }
}
