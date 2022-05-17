using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl_Gurkas.Datos
{
  
   class AuditoriaModulos
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public void auditoria(string moduloPrincipal , string ModuloSegundario,string ModuloTercero,string ModuloCuarto)
        {
            string hora = DateTime.Now.ToString("hh:mm:ss tt");
            string _nombre = Datos.DatosUsuario._usuario;
            int id_empresa = Datos.EmpresaID._empresaid;

            SqlCommand comando2 = new SqlCommand("sp_insertarHistorialModulo", conexion.conexionBD());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("@Usuario", _nombre);
            comando2.Parameters.AddWithValue("@Modulo", moduloPrincipal);
            comando2.Parameters.AddWithValue("@SubModulo2", ModuloSegundario);
            comando2.Parameters.AddWithValue("@SubModulo3", ModuloTercero);
            comando2.Parameters.AddWithValue("@SubModulo4", ModuloCuarto);
            comando2.Parameters.AddWithValue("@hora", hora);
            comando2.Parameters.AddWithValue("@empresa", id_empresa);
            comando2.ExecuteNonQuery();
        }

        public void auditoriaFunciones(string modulo, string boton, string resumen)
        {
            string hora = DateTime.Now.ToString("hh:mm:ss tt");
            string _nombre = Datos.DatosUsuario._usuario;
            int id_empresa = Datos.EmpresaID._empresaid;

            SqlCommand comando2 = new SqlCommand("sp_insertar_historico_botones", conexion.conexionBD());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("@modulo", modulo);
            comando2.Parameters.AddWithValue("@Botton", boton);
            comando2.Parameters.AddWithValue("@resumen", resumen);
            comando2.Parameters.AddWithValue("@usuario", _nombre);
            comando2.Parameters.AddWithValue("@empresa", id_empresa);
            comando2.Parameters.AddWithValue("@hora", hora);
            comando2.ExecuteNonQuery();
        }
    }
}
