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
    class LlenadoDatosSucamec
    {
        Datos.Conexiondbo conexiondbo = new Datos.Conexiondbo();
        int id_empresa = Datos.EmpresaID._empresaid;
        public void ObtenerEmpresaSucamec_2(ComboBox cd)
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
                MessageBox.Show("No se puede obtener la imformacion de la Empresa \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerTipoDocumentoSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESP_TIPO_DOCT FROM T_TIPO_DOCUMENTO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Tipo Documento ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de los Tipo de documentos \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerTipoSexoSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESP_SEXO FROM T_SEXO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Sexo ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de tipo de Sexo \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerBreveteSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESCP_TIPO_BREVETE FROM T_TIPO_BREVETE", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Tipo Brevete ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de tipo de brevete \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerNacionalidadSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESP_NACIONALIDAD FROM T_NACIONALIDAD", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Una Nacionalidad ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de tipo de Nacionalidad \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerHorasLaboralesSucamec(ComboBox cd)
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
        public void ObtenerEstadoCivilSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESP_ESTADO_CIVIL FROM T_ESTADO_CIVIL", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Tipo de Estado Civil ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de estado Civil \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerGradoInstruccionSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESP_GRADO_INSTRUCCION FROM T_GRADO_INSTRUCCION", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Grado de Instruccion ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de grado de Instruccion \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerEstadoPersonalSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESCP_ESTADO_PERSONAL FROM T_ESTADO_PERSONAL", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Estado Personal ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de estado personal \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerPuestoSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESCP_PUESTO FROM T_PUESTO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Puesto ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de Puesto de empleado \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerTipoContratoSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESCP_TIPO_CONTRATO FROM T_TIPO_CONTRATO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Tipo Contrato ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de Tipo Contrato \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerTurnoSucamec(ComboBox cd)
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
        public void ObtenerTallaSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESP_TALLA_PRENDA FROM T_TALLA_PRENDA", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Talla ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de las Tallas  \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerEstadoArmadoSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT DESCP_ESTADO_ARMADO FROM T_ESTADO_ARMADO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un Tipo  ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de tipo de armado \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerDepartamentoSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COD_DEPARTAMENTO,DESCP_DEPARTAMENTO FROM t_Departamento", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DESCP_DEPARTAMENTO"] = "--- Seleccione un Departamento ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "COD_DEPARTAMENTO";
                cd.DisplayMember = "DESCP_DEPARTAMENTO";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Departamento \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerUnidadSucamec(ComboBox cd)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COD_UNIDAD,RAZON_SOCIAL FROM T_UNIDAD where ID_ESTADO_UNIDAD = 2 and ID_EMPRESA =" + id_empresa + " order by RAZON_SOCIAL asc", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["RAZON_SOCIAL"] = "--- Seleccione una Unidad ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "COD_UNIDAD";
                cd.DisplayMember = "RAZON_SOCIAL";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de las Unidades \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerSedeSucamec(ComboBox cd, string cod_unidad)
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
        public void ObtenerPersonalSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select Cod_empleado,NOMBRE_COMPLETO from T_MAE_PERSONAL WHERE ID_EMPRESA = " + id_empresa + " order by APELLIDO_PATERNO asc", conexiondbo.conexionBD());
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
        public void ObtenerExpSucamec(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT desp_expe FROM t_experiencia", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione una opcion ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de tipo de experiencia \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerProvinciaSucamec(ComboBox cd, string Cod_Departamento)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COD_PROVINCIA,DESCP_provincia FROM t_Provincia where COD_DEPARTAMENTO = @Cod_Departamento", conexiondbo.conexionBD());
                cmd.Parameters.AddWithValue("COD_DEPARTAMENTO", Cod_Departamento);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DESCP_provincia"] = "--- Seleccione una Provincia ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "COD_PROVINCIA";
                cd.DisplayMember = "DESCP_provincia";
                cd.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de las Provincia \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerDistritosSucamec(ComboBox cd, string Cod_Provincia)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COD_distrito,DESCP_Distrito FROM t_Distrito where COD_PROVINCIA = @Cod_Provincia", conexiondbo.conexionBD());
                cmd.Parameters.AddWithValue("COD_PROVINCIA", Cod_Provincia);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DESCP_Distrito"] = "--- Seleccione un Distrito ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "COD_distrito";
                cd.DisplayMember = "DESCP_Distrito";
                cd.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Distritos \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
