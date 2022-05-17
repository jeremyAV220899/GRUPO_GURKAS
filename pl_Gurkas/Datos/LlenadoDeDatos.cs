using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Datos
{
    class LlenadoDeDatos
    {
        Datos.Conexiondbo conexiondbo = new Datos.Conexiondbo();

        public void ObtenerEmpresa(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT NOMBRE_EMPRESA FROM T_EMPRESA", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Una Empresa ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener el listado de la empresa de la Base de Datos" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerSede(ComboBox cd, string cod_unidad)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select COD_SEDE , NOMBRE_SEDE from T_SEDE where COD_UNIDAD = @COD_UNIDAD and ID_ESTADO_SEDE = 2 ", conexiondbo.conexionBD());
                cmd.Parameters.AddWithValue("COD_UNIDAD", cod_unidad);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["NOMBRE_SEDE"] = "--- Seleccione una sede ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "COD_SEDE";
                cd.DisplayMember = "NOMBRE_SEDE";
                cd.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de las sedes \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerAsistencias(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select  id_TipoAsistencia,Desp_TipoAsistencia from T_TIPO_ASISTENCIA", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["Desp_TipoAsistencia"] = "---Seleccione Tipo de Marcacion---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "id_TipoAsistencia";
                cd.DisplayMember = "Desp_TipoAsistencia";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado del brevete \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTurno(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESCP_TURNO FROM T_TURNO_EMPLEADO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Turno ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de los turno \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerAreaAdministrador(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select ROL  from T_ROL_USURIO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Una Area ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de area de usuario \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerPersonal(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select Cod_empleado,NOMBRE_COMPLETO from T_MAE_PERSONAL   order by APELLIDO_PATERNO asc", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["NOMBRE_COMPLETO"] = "---Seleccione un Empleado---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "Cod_empleado";
                cd.DisplayMember = "NOMBRE_COMPLETO";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado del Empleados \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerEstadoUser(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DESP_ESTADO_USUARIO  from T_ESTADO_USUARIO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Estado ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de rol  \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerUsuario(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select COD_EMPLEADO,Nombre  from T_USUARIO where ID_ESTADO_USUARIO = 1", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["Nombre"] = "--- Seleccione un Usuario ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "COD_EMPLEADO";
                cd.DisplayMember = "Nombre";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Usuarios \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerUnidad(ComboBox cd)
        {
         
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COD_UNIDAD,RAZON_SOCIAL FROM t_unidad where ID_ESTADO_UNIDAD = 2 order by RAZON_SOCIAL asc", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["razon_social"] = "--- Seleccione una Unidad ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "cod_unidad";
                cd.DisplayMember = "razon_social";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de las Unidades \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EstadoUsuarioUnidad(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESP_ESTADO_UNIAD FROM T_ESTADO_UNIDAD_USUARIO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Estado ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Estados \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
