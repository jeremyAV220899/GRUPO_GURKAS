using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl_Gurkas.Datos
{
    class agregarDatosMysql
    {
        Datos.ConexionMysql conexion = new Datos.ConexionMysql();
        MySqlCommand comand;

        public void RegistrarPersonalUsuario(string codEmpleado, string Nombre, string ApPaterno,
            string ApMaterno, string NombreCompleto,
          string NumDOc,string cod_unidad , string cod_sede,int id_puesto,int id_estado)
        {

            string query = "insert into t_usuario(dni,Nombre,Apellidos,correo,nombre_completo,cod_empleado,cod_unidad" +
                ",cod_sede,pass,id_puesto,id_estado)" +
                " values('" + NumDOc + "','" + Nombre + "','"+ ApPaterno + " " + ApMaterno+ 
                "','SIN CORREO','" + NombreCompleto +"','"
                + codEmpleado+"','" + cod_unidad +"','"+cod_sede +"','"+ "SIN CONTRA"+"',"+id_puesto
                +","+id_estado+ ")";
            comand = new MySqlCommand(query, conexion.ObtenerConexion());
            comand.ExecuteNonQuery();
        }

        public void RegistroUnidad (string cod_unidad, string razon_social, string nombre_comercial,
            int ID_ESTADO, string latitude, string longitude,string direccion,int ID_EMPRESA)
        {
            string query = "insert into T_UNIDAD(COD_UNIDAD,RAZON_SOCIAL,NOMBRE_COMERCIAL,ID_ESTADO,latitude,longitude,DIRECCION,ID_EMPRESA) " +
                "values('" + cod_unidad + "','" + razon_social +
                "', '" + nombre_comercial + "', " + ID_ESTADO + ",'" + latitude + "','" + longitude + "','" + direccion 
                +"',"+ ID_EMPRESA  +")";
            comand = new MySqlCommand(query, conexion.ObtenerConexion());
            comand.ExecuteNonQuery();
        }
        public void RegistroSede(string COD_SEDE, string NOMBRE_SEDE,int id_estado_sede,string latitud, string longitud
            , string direccion , string cod_unidad)
        {
            string query = "insert into T_SEDE(COD_SEDE,NOMBRE_SEDE,id_estado_sede,latitud,longitud,direccion,cod_unidad)" +
              "values('" + COD_SEDE + "','" + NOMBRE_SEDE +
                "', " + id_estado_sede + ", '" + latitud + "','" + longitud + "', '" 
                + direccion + "', '" + cod_unidad + "')";
            comand = new MySqlCommand(query, conexion.ObtenerConexion());
            comand.ExecuteNonQuery();
        }

        public void RegistroAsistencia(int id,string tipoasistencia, string cod_empleado, string fechaVista, string sede
           , string unidad, DateTime fecha)
        {
            string f = fecha.ToString("yyyy/MM/dd");
            string fi = f.Replace("/","-");

            string query = "insert into T_ASISTENCIA_PERSONAL (id,cod_empleado,fechaVista,fecha,sede,tipoasistencia,unidad) " +
              "values("+ id + ",'" + cod_empleado + "','" + fi +
                "',' " + fi + "', '" + sede + "','" + tipoasistencia + "', '"
                + unidad + "')";
            comand = new MySqlCommand(query, conexion.ObtenerConexion());
            comand.ExecuteNonQuery();
        }
    }
}
