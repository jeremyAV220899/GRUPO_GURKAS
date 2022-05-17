using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl_Gurkas.Datos
{
    class eliminar
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public void ActualizarAsistenciaPersonal(string ip_pc, string nombre_pc, DateTime Fecha, string nombre_usurio, string cod_Asistencia_personal, string detalle)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarAsistencia ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = Fecha;
            cmd.Parameters.AddWithValue("@cod_asistencia", SqlDbType.VarChar).Value = cod_Asistencia_personal;
            cmd.Parameters.AddWithValue("@nombrePC_lap", SqlDbType.VarChar).Value = nombre_pc;
            cmd.Parameters.AddWithValue("@USERNAME", SqlDbType.VarChar).Value = nombre_usurio;
            cmd.Parameters.AddWithValue("@ipPCLaptop", SqlDbType.VarChar).Value = ip_pc;
            cmd.Parameters.AddWithValue("@detalle", SqlDbType.VarChar).Value = detalle;
            cmd.ExecuteNonQuery();
        }
    }
}
