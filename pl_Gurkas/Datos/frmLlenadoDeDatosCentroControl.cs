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
    class frmLlenadoDeDatosCentroControl
    {
        Datos.Conexiondbo conexiondbo = new Datos.Conexiondbo();

        string cod_empleado = Datos.CodEmplado._codempleado;

        public void ObtenerUnidadCentroControl(ComboBox cd)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("select cod_unidad,razon_social from v_unidad_usuario where cod_empleado =  '" + cod_empleado + "'", conexiondbo.conexionBD());
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
        public void ObtenerTurnoCentroControl(ComboBox cd)
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
        public void ObtenerSedeCentroControl(ComboBox cd, string cod_unidad)
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

        public void ObtenerTipoAsistenciaCentroControl(DataGridViewComboBoxColumn cbo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT ID_TIPOASISTENCIA,Desp_TipoAsistencia FROM V_TIPOASISTENCIA", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DESP_TIPOASISTENCIA"] = "------";
                dt.Rows.InsertAt(fila, 0);
                cbo.ValueMember = "ID_TIPOASISTENCIA";
                cbo.DisplayMember = "DESP_TIPOASISTENCIA";
                cbo.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado del brevete \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTipoPostulante(DataGridViewComboBoxColumn cbo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT idEstadoPostulante,EstadoPostulante FROM t_estadoPostulante", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["EstadoPostulante"] = "------";
                dt.Rows.InsertAt(fila, 0);
                cbo.ValueMember = "idEstadoPostulante";
                cbo.DisplayMember = "EstadoPostulante";
                cbo.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado del brevete \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerUnidadEmpresaCentroControl(ComboBox cd, string cod_unidad)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select ID_EMPRESA , NOMBRE_EMPRESA from v_empresa_unidad where COD_UNIDAD = @COD_UNIDAD", conexiondbo.conexionBD());
                cmd.Parameters.AddWithValue("COD_UNIDAD", cod_unidad);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["NOMBRE_EMPRESA"] = "--- Seleccione una empresa ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "ID_EMPRESA";
                cd.DisplayMember = "NOMBRE_EMPRESA";
                cd.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de las empresa \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ObtenerHorasLaboralesCentroControl(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESCP_HORAS_LABORALES FROM T_HORAS_LABORALES", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Tipo de Horas ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de Horas Laborales \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ObtenerPersonalCentroControl(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select Cod_empleado,NOMBRE_COMPLETO from v_tareaje_personal_Activo_busqueda order by APELLIDO_PATERNO asc", conexiondbo.conexionBD());
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
        public void ObtenerEmpresaCentroControl(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT NOMBRE_EMPRESA FROM T_EMPRESA " , conexiondbo.conexionBD());
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
                MessageBox.Show("No se puede obtener la imformacion de la Empresa \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerOrdenamientoCentroControl(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select  NombreOrdenamiento from T_ORDEAMINETO_CENTRO_CONTROL", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Tipo Ordenamiento ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener los Ordenamiento  \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTipoAsistenciaCentroControl(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select  ID_TIPOASISTENCIA,DESP_TIPOASISTENCIA from T_TIPO_ASISTENCIA", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DESP_TIPOASISTENCIA"] = "---Seleccione Tipo de Marcacion---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "ID_TIPOASISTENCIA";
                cd.DisplayMember = "DESP_TIPOASISTENCIA";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado del brevete \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
