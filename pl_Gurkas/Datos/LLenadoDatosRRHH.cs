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
 
    class LLenadoDatosRRHH
    {
        Datos.Conexiondbo conexiondbo = new Datos.Conexiondbo();
        int id_empresa = Datos.EmpresaID._empresaid;
        public void ObtenerEmpresaRRHH(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT NOMBRE_EMPRESA FROM T_EMPRESA where ID_EMPRESA = " + id_empresa, conexiondbo.conexionBD());
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
        public void ObtenerEmpresaRRHH_2(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT NOMBRE_EMPRESA FROM T_EMPRESA" , conexiondbo.conexionBD());
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
        public void ObtenerTipoDocumentoRRHH(ComboBox cd)
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
        public void ObtenerTipoSexoRRHH(ComboBox cd)
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
        public void ObtenerExpRRHHC4(ComboBox cd)
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
        public void ObtenerEstadoPermiteMarcacion( ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select descripcion_estado_personal from t_descripcion_estado_personal_modulo_tareaje", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione Un Estado para Marcacion ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion del estado que permite la marcacion\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ObtenerBreveteRRHH(ComboBox cd)
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
        public void ObtenerNacionalidadRRHH(ComboBox cd)
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
        public void ObtenerHorasLaboralesdRRHH(ComboBox cd)
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
        public void ObtenerEstadoCivilRRHH(ComboBox cd)
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
        public void ObtenerGradoInstruccionRRHH(ComboBox cd)
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
        public void ObtenerEstadoPersonalRRHH(ComboBox cd)
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
        public void ObtenerPuestolRRHH(ComboBox cd)
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
        public void ObtenerTipoContratoRRHH(ComboBox cd)
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
        public void ObtenerTurnoRRHH(ComboBox cd)
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
        public void ObtenerMesRRHH(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT mes FROM t_mes_planilla", conexiondbo.conexionBD());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.Items.Add(dr[0].ToString());
                }
                cd.Items.Insert(0, "--- Seleccione un mes ---");
                cd.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la imformacion de los mes \n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ObtenerTallaRRHH(ComboBox cd)
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
        public void ObtenerEstadoArmadoRRHH(ComboBox cd)
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
        public void ObtenerDepartamentoRRHH(ComboBox cd)
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
        public void ObtenerProvinciaRRHH(ComboBox cd, string Cod_Departamento)
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
        public void ObtenerDistritosRRHH(ComboBox cd, string Cod_Provincia)
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

        public void ObtenerUnidadRRHHEmpresa(ComboBox cd,int empresa)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COD_UNIDAD,RAZON_SOCIAL FROM T_UNIDAD where ID_ESTADO_UNIDAD = 2 and ID_EMPRESA =" + empresa + " order by RAZON_SOCIAL asc", conexiondbo.conexionBD());
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

        public void ObtenerUnidadRRHH(ComboBox cd)
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
        public void ObtenerSedeRRHH(ComboBox cd, string cod_unidad)
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
        public void ObtenerPersonalRRHH(ComboBox cd)
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
        public void ObtenerUnidadRRHHGeneral(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT cod_unidad,razon_social FROM t_unidad where ID_ESTADO_UNIDAD = 2 order by Razon_social asc", conexiondbo.conexionBD());
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
        public void ObtenerEmpresaRRHHGeneral(ComboBox cd)
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
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de la empresa \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerPersonalRRHHGeneral(ComboBox cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select Cod_empleado,NOMBRE_COMPLETO from T_MAE_PERSONAL  order by APELLIDO_PATERNO asc", conexiondbo.conexionBD());
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
        public void ObtenerBancoRRHH(ComboBox cd)
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
        public void ObtenerMonedaRRHH(ComboBox cd)
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
        public void ObtenerRegimenPensionarioRRHH(ComboBox cd)
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
        public void ObtenerAFPRRHH(ComboBox cd, int regimen)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select id_afp,DescripcionAfp from t_afp where  id_ReguimenPensionario = " + regimen, conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DescripcionAfp"] = "---Seleccione una AFP / ONP---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "id_afp";
                cd.DisplayMember = "DescripcionAfp";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de la AFP/ONP \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTipoComisionAFPRRHH(ComboBox cd, int regimen)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select ID_TipoComisionAFP,DescripcionTipoComisionAFP  from t_TipoComisionAFP where id_ReguimenPensionario = " + regimen, conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DescripcionTipoComisionAFP"] = "---Seleccione una Tipo Comision---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "ID_TipoComisionAFP";
                cd.DisplayMember = "DescripcionTipoComisionAFP";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Tipo de Comision \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerMovimientoAFPRRHH(ComboBox cd, int regimen)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select ID_MovimientoAFP , DescripcionMoviminetoComisionAFP from t_Movimiento_AFP where id_ReguimenPensionario = " + regimen, conexiondbo.conexionBD());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow fila = dt.NewRow();
                fila["DescripcionMoviminetoComisionAFP"] = "---Seleccione una Tipo de movimiento AFP / ONP ---";
                dt.Rows.InsertAt(fila, 0);
                cd.ValueMember = "ID_MovimientoAFP";
                cd.DisplayMember = "DescripcionMoviminetoComisionAFP";
                cd.DataSource = dt;
                cd.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("No se puede obtener el listado de los Movimineto de AFP \n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ObtenerTipoTrabajdorRRHH(ComboBox cd)
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
        public void ObtenerBonoFamiliarRRHH(ComboBox cd)
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
        public void ObtenerTipoRemuneracionRRHH(ComboBox cd)
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
        public void ObtenerPeriodoRemuneracionRRHH(ComboBox cd)
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
    }
}
