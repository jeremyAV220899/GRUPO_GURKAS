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
    class LlenadoDatosPlanilla
    {
        Datos.Conexiondbo conexiondbo = new Datos.Conexiondbo();
        int id_empresa = Datos.EmpresaID._empresaid;
        public void ObtenerBancoPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Nombre_Banco FROM T_BANCO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Banco ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de la Empresa \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerPuestolPlanilla(ComboBox cd)
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
        public void obtenerTipoLicenciaPLANILLA(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Desp_TipoLicencia FROM t_tipos_licencias", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Tipo de Licencia ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de Tipo de Licencia \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerMonedaPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select id_moneda,moneda  from t_tipo_moneda", conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["moneda"] = "--- Seleccione una Moneda ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "id_moneda";
                cd.DisplayMember = "moneda";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de las Monedas \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerRegimenPensionarioPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionRegimenPensionario from t_RegimenPensionario", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Regimen de Pension ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Regimen de Pension \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerAFPPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionAfp from t_afp", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Una AFP/ONP ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de la AFP/ONP \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ObtenerAFPPLANILLASACTUALIZAR(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionAfp from t_afp WHERE id_afp IN (1,2,3,4,5)", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Una AFP/ONP ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de la AFP/ONP \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ObtenerTipoComisionAFPPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionTipoComisionAFP from t_TipoComisionAFP", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Tipo de Comision ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Tipo de Comision \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTipoComisionAFPPLANILLASACTUALIZAR(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionTipoComisionAFP from t_TipoComisionAFP  WHERE ID_TipoComisionAFP IN (1,2)", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Tipo de Comision ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Tipo de Comision \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ObtenerMovimientoAFPPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionMoviminetoComisionAFP from t_Movimiento_AFP", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Tipo de Movimineto de AFP ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Movimineto de AFP \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTipoTrabajdorPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select  DescripcionTipoTrabajador from T_TipoTrabajador", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Tipo de Trabajador ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de tipo de los Tipo de Trabajador \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerBonoFamiliarPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionBonoFamiliar  from T_BonoFamiliar", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Bono Familiar ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de tipo de los Bonos Familiar \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTipoRemuneracionPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionTipoRemuneracion from t_TipoRemuneracion", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Tipo de Pago ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de Tipo de Pago \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerPeriodoRemuneracionPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select DescripcionPeriodo_remuneracion from t_Periodo_remuneracion", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Periodo ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado del Periodo de remuneracion \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerBonoFeriadoPLANILLAS(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select ESTADO_BONO  from T_BONO_FERIADO", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Uno ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de tipo de los Bonos Familiar \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerEmpresaPLANILLA(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT NOMBRE_EMPRESA FROM T_EMPRESA  ", conexiondbo.conexionBD());
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
        public void ObtenerPersonalPLANILLA(ComboBox cd)
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
        public void ObtenerUnidadPlanillas(ComboBox cd)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COD_UNIDAD,RAZON_SOCIAL FROM T_UNIDAD where ID_EMPRESA = "+ id_empresa + " and ID_ESTADO_UNIDAD = 2   order by RAZON_SOCIAL asc", conexiondbo.conexionBD());
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
    }
}
