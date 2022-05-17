using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Datos
{
    class actualizarmysql
    {
        Datos.ConexionMysql conexion = new Datos.ConexionMysql();
        MySqlCommand comand;

        public void ActualizarPersonalUsuario(string codEmpleado, string Nombre, string ApPaterno,
          string ApMaterno, string NombreCompleto,
        string NumDOc, string cod_unidad, string cod_sede, int id_puesto, int id_estado)
        {

            string query = "update t_usuario  set Nombre ='" + Nombre +
                "',	Apellidos = '" + ApPaterno+" "+ ApMaterno + "', id_estado =" + id_estado
                + ",nombre_completo ='" + NombreCompleto + "',cod_unidad ='" + cod_unidad +
                "', cod_sede ='" + cod_sede + "', id_puesto =" + id_puesto + ", cod_unidad ='"+ cod_unidad
                + "',  dni = '" + NumDOc+"' "+
                " where cod_empleado ='" + codEmpleado + "'";
            comand = new MySqlCommand(query, conexion.ObtenerConexion());
            comand.ExecuteNonQuery();
        }
        public void ActualizarUnidad(string cod_unidad, string razon_social, string nombre_comercial,
          int ID_ESTADO, string latitude, string longitude, string direccion, int ID_EMPRESA)
        {
            string query = "update T_UNIDAD  set RAZON_SOCIAL ='" + razon_social +
                "',NOMBRE_COMERCIAL = '" + nombre_comercial + "', ID_ESTADO =" + ID_ESTADO 
                + ",latitude ='" + latitude + "',longitude ='" + longitude +
                "', DIRECCION ='" + direccion + "', ID_EMPRESA =" + ID_EMPRESA +
                " where COD_UNIDAD ='" + cod_unidad + "'";
          

            comand = new MySqlCommand(query, conexion.ObtenerConexion());
            comand.ExecuteNonQuery();
        }

        public void ActualizarSede(string COD_SEDE, string NOMBRE_SEDE, int id_estado_sede, string latitud, string longitud
            , string direccion, string cod_unidad)
        {
            string query = "update T_SEDE  set NOMBRE_SEDE ='" + NOMBRE_SEDE +
                "',direccion = '" + direccion + "', id_estado_sede =" + id_estado_sede
                + ",latitud ='" + latitud + "',longitud ='" + longitud + "',cod_unidad ='" + cod_unidad +
                "' where COD_SEDE ='" + COD_SEDE + "'";
            comand = new MySqlCommand(query, conexion.ObtenerConexion());
            comand.ExecuteNonQuery();
        }
    }
}
