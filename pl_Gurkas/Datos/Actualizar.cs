using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl_Gurkas.Datos
{
    class Actualizar
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public void ActualizarPersonal(string codEmpleado, string Nombre, string ApPaterno, string ApMaterno, string NombreCompleto,
          int edad, int tipoDoc, string NumDOc, int sexo, DateTime Femision, DateTime Fcaducacion, DateTime Fnacimineto, int brevete,
          string nbrevete, int Nacionalidad, int codDep, int codPro, int codDist, string Domicilio, int Telefono, int Celular,
          string Correo, int GradoInstruccion, int EstadoCivil, int EstadoPersonal, int CargoLaboral, int Empresa, int TipoContrato,
          DateTime fechaInicio, DateTime fechaFin, string Sede, int turno, int tallacamisa, int tallapantalon, int tallacalzado, decimal estatura,
          int horas, string codUbigeo, string unidad, int idArmado, DateTime finiciolaboral, DateTime ffinlaboral, DateTime factivacionPersonal, DateTime fdestaquePersonal)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarPersonalMae ", conexion.conexionBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = codEmpleado;
            cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = Nombre;
            cmd.Parameters.AddWithValue("@Apellido_p", SqlDbType.VarChar).Value = ApPaterno;
            cmd.Parameters.AddWithValue("@Apellido_m", SqlDbType.VarChar).Value = ApMaterno;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = NombreCompleto;
            cmd.Parameters.AddWithValue("@Edad", SqlDbType.Int).Value = edad;
            cmd.Parameters.AddWithValue("@Id_tipo_doc", SqlDbType.Int).Value = tipoDoc;
            cmd.Parameters.AddWithValue("@Doc_ident", SqlDbType.Int).Value = NumDOc;
            cmd.Parameters.AddWithValue("@Id_sexo", SqlDbType.Int).Value = sexo;
            cmd.Parameters.AddWithValue("@Fecha_emesion_doc_iden", SqlDbType.VarChar).Value = Femision;
            cmd.Parameters.AddWithValue("@Fecha_caducidad_doc_iden", SqlDbType.VarChar).Value = Fcaducacion;
            cmd.Parameters.AddWithValue("@Fecha_nacim", SqlDbType.VarChar).Value = Fnacimineto;
            cmd.Parameters.AddWithValue("@Brevete", SqlDbType.Int).Value = brevete;
            cmd.Parameters.AddWithValue("@N_Brevete", SqlDbType.VarChar).Value = nbrevete;
            cmd.Parameters.AddWithValue("@Cod_Nacionalidad", SqlDbType.Int).Value = Nacionalidad;
            cmd.Parameters.AddWithValue("@Cod_Departamento", SqlDbType.Int).Value = codDep;
            cmd.Parameters.AddWithValue("@Cod_Provincia", SqlDbType.Int).Value = codPro;
            cmd.Parameters.AddWithValue("@Cod_Distrito", SqlDbType.Int).Value = codDist;
            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Domicilio;
            cmd.Parameters.AddWithValue("@Telefonofijo", SqlDbType.Int).Value = Telefono;
            cmd.Parameters.AddWithValue("@Celular", SqlDbType.Int).Value = Celular;
            cmd.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.AddWithValue("@Id_GradoInstruccion", SqlDbType.Int).Value = GradoInstruccion;
            cmd.Parameters.AddWithValue("@Id_EstadoCivil", SqlDbType.Int).Value = EstadoCivil;
            cmd.Parameters.AddWithValue("@id_hora", SqlDbType.Int).Value = horas;
            cmd.Parameters.AddWithValue("@codUbigeo", SqlDbType.VarChar).Value = codUbigeo;

            cmd.Parameters.AddWithValue("@Cod_EstadoPersonal", SqlDbType.Int).Value = EstadoPersonal;
            cmd.Parameters.AddWithValue("@Cod_Puesto", SqlDbType.Int).Value = CargoLaboral;
            cmd.Parameters.AddWithValue("@Cod_empresa", SqlDbType.Int).Value = Empresa;
            cmd.Parameters.AddWithValue("@Id_TipoContrato", SqlDbType.Int).Value = TipoContrato;
            cmd.Parameters.AddWithValue("@Fecha_Cont_inicio", SqlDbType.VarChar).Value = fechaInicio;
            cmd.Parameters.AddWithValue("@Fecha_Cont_fin", SqlDbType.VarChar).Value = fechaFin;
            cmd.Parameters.AddWithValue("@Cod_sede", SqlDbType.Int).Value = Sede;
            cmd.Parameters.AddWithValue("@cod_unidad", SqlDbType.Int).Value = unidad;
            cmd.Parameters.AddWithValue("@Cod_turno", SqlDbType.Int).Value = turno;

            cmd.Parameters.AddWithValue("@Id_TallaPrenda", SqlDbType.Int).Value = tallacamisa;
            cmd.Parameters.AddWithValue("@Talla_pantalon", SqlDbType.Int).Value = tallapantalon;
            cmd.Parameters.AddWithValue("@Talla_zapato", SqlDbType.Int).Value = tallacalzado;
            cmd.Parameters.AddWithValue("@Estatura", SqlDbType.Decimal).Value = estatura;

            cmd.Parameters.AddWithValue("@ID_ESTADO_ARMADO", SqlDbType.Int).Value = idArmado;
            cmd.Parameters.AddWithValue("@FECHA_INICIO_LABORAL", SqlDbType.VarChar).Value = finiciolaboral;
            cmd.Parameters.AddWithValue("@FECHA_FIN_LABORAL", SqlDbType.VarChar).Value = ffinlaboral;
            cmd.Parameters.AddWithValue("@FECHA_ACTIVACION_PERSONAL", SqlDbType.VarChar).Value = factivacionPersonal;
            cmd.Parameters.AddWithValue("@FECHA_DESTAQUE_PERSONAL", SqlDbType.VarChar).Value = fdestaquePersonal;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarPersonalC4(string codEmpleado, decimal estaturac4, string Empresa1, string Empresa2, string Empresa3,
                                        DateTime FechaEmisionC4, DateTime FCaducidadC4, DateTime InicioExp1, DateTime InicioExp2, DateTime InicioExp3,
                                         DateTime FinExp1, DateTime FinExp2, DateTime FinExp3,
                                        int GradoInstruccionExp, int Experiencia1, int Experiencia2, int Experiencia3)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_datos_c4 ", conexion.conexionBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_emplead", SqlDbType.VarChar).Value = codEmpleado;
            cmd.Parameters.AddWithValue("@estatura", SqlDbType.Decimal).Value = estaturac4;
            cmd.Parameters.AddWithValue("@exp_empresa_nombre_1", SqlDbType.VarChar).Value = Empresa1;
            cmd.Parameters.AddWithValue("@exp_empresa_nombre_2", SqlDbType.VarChar).Value = Empresa2;
            cmd.Parameters.AddWithValue("@exp_empresa_nombre_3", SqlDbType.VarChar).Value = Empresa3;

            cmd.Parameters.AddWithValue("@fecha_emision_c4", SqlDbType.VarChar).Value = FechaEmisionC4;
            cmd.Parameters.AddWithValue("@fecha_caducacion_c4", SqlDbType.VarChar).Value = FCaducidadC4;
            cmd.Parameters.AddWithValue("@f_inicio_empresa_1", SqlDbType.VarChar).Value = InicioExp1;
            cmd.Parameters.AddWithValue("@f_inicio_empresa_2", SqlDbType.VarChar).Value = InicioExp2;
            cmd.Parameters.AddWithValue("@f_inicio_empresa_3", SqlDbType.VarChar).Value = InicioExp3;
            cmd.Parameters.AddWithValue("@f_fin_empresa_1", SqlDbType.VarChar).Value = FinExp1;
            cmd.Parameters.AddWithValue("@f_fin_empresa_2", SqlDbType.VarChar).Value = FinExp2;
            cmd.Parameters.AddWithValue("@f_fin_empresa_3", SqlDbType.VarChar).Value = FinExp3;

            cmd.Parameters.AddWithValue("@ID_GRADO_INSTRUCCION", SqlDbType.Int).Value = GradoInstruccionExp;
            cmd.Parameters.AddWithValue("@id_experiencia_1", SqlDbType.Int).Value = Experiencia1;
            cmd.Parameters.AddWithValue("@id_experiencia_2", SqlDbType.Int).Value = Experiencia2;
            cmd.Parameters.AddWithValue("@id_experiencia_3", SqlDbType.Int).Value = Experiencia3;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarPersonalSucamec(string codEmpleado, string sucamec, string arma, string Empresa1, string Empresa2, string Empresa3,
                                       DateTime FechaVigenciaSucamec, DateTime FechaVigenciaArma, DateTime InicioExp1, DateTime InicioExp2, DateTime InicioExp3,
                                        DateTime FinExp1, DateTime FinExp2, DateTime FinExp3
                                       , int Experiencia1, int Experiencia2, int Experiencia3)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_sucamec ", conexion.conexionBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = codEmpleado;
            cmd.Parameters.AddWithValue("@carnet_sucamec", SqlDbType.VarChar).Value = sucamec;
            cmd.Parameters.AddWithValue("@licencia_arma", SqlDbType.VarChar).Value = arma;

            cmd.Parameters.AddWithValue("@exp_empresa_nombre_1", SqlDbType.VarChar).Value = Empresa1;
            cmd.Parameters.AddWithValue("@exp_empresa_nombre_2", SqlDbType.VarChar).Value = Empresa2;
            cmd.Parameters.AddWithValue("@exp_empresa_nombre_3", SqlDbType.VarChar).Value = Empresa3;

            cmd.Parameters.AddWithValue("@fecha_vigencia_sucamec", SqlDbType.VarChar).Value = FechaVigenciaSucamec;
            cmd.Parameters.AddWithValue("@fecha_vigencia_licencia", SqlDbType.VarChar).Value = FechaVigenciaArma;

            cmd.Parameters.AddWithValue("@f_inicio_empresa_1", SqlDbType.VarChar).Value = InicioExp1;
            cmd.Parameters.AddWithValue("@f_inicio_empresa_2", SqlDbType.VarChar).Value = InicioExp2;
            cmd.Parameters.AddWithValue("@f_inicio_empresa_3", SqlDbType.VarChar).Value = InicioExp3;

            cmd.Parameters.AddWithValue("@f_fin_empresa_1", SqlDbType.VarChar).Value = FinExp1;
            cmd.Parameters.AddWithValue("@f_fin_empresa_2", SqlDbType.VarChar).Value = FinExp2;
            cmd.Parameters.AddWithValue("@f_fin_empresa_3", SqlDbType.VarChar).Value = FinExp3;

            cmd.Parameters.AddWithValue("@id_experiencia_1", SqlDbType.Int).Value = Experiencia1;
            cmd.Parameters.AddWithValue("@id_experiencia_2", SqlDbType.Int).Value = Experiencia2;
            cmd.Parameters.AddWithValue("@id_experiencia_3", SqlDbType.Int).Value = Experiencia3;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarUnidad(string codUnidad, string RazonSocial, string RUC, string NombreComercial, int codDep, int codPro, int codDist, string Direccion,
           string RepresentanteLegal, string dni, string cargo, string contacto, int Telefono, int Celular, string Correo, string centroCosto
            , DateTime Factivacion, DateTime  Fbaja,int empresa,int estadoUnidad, string latitud, string longitud)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarUnidad ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_unidad", SqlDbType.VarChar).Value = codUnidad;
            cmd.Parameters.AddWithValue("@Razon_social", SqlDbType.VarChar).Value = RazonSocial;
            cmd.Parameters.AddWithValue("@RUC", SqlDbType.VarChar).Value = RUC;
            cmd.Parameters.AddWithValue("@Nombre_comercial", SqlDbType.VarChar).Value = NombreComercial;
            cmd.Parameters.AddWithValue("@Cod_Departamento", SqlDbType.Int).Value = codDep;
            cmd.Parameters.AddWithValue("@Cod_Provincia", SqlDbType.Int).Value = codPro;
            cmd.Parameters.AddWithValue("@Cod_Distrito", SqlDbType.Int).Value = codDist;
            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.AddWithValue("@Repres_legal", SqlDbType.VarChar).Value = RepresentanteLegal;
            cmd.Parameters.AddWithValue("@DNI_repres_legal", SqlDbType.Int).Value = dni;
            cmd.Parameters.AddWithValue("@Cargo_re_legal", SqlDbType.Int).Value = cargo;
            cmd.Parameters.AddWithValue("@Contacto", SqlDbType.Int).Value = contacto;
            cmd.Parameters.AddWithValue("@Telefono", SqlDbType.Int).Value = Telefono;
            cmd.Parameters.AddWithValue("@Celular_contacto", SqlDbType.Int).Value = Celular;
            cmd.Parameters.AddWithValue("@Correo_contacto", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.AddWithValue("@Centro_costo", SqlDbType.Int).Value = centroCosto;
            cmd.Parameters.AddWithValue("@fechaActivacion", SqlDbType.VarChar).Value = Factivacion;
            cmd.Parameters.AddWithValue("@fechaBaja", SqlDbType.VarChar).Value = Fbaja;
            cmd.Parameters.AddWithValue("@idEmpresa", SqlDbType.Int).Value = empresa;
            cmd.Parameters.AddWithValue("@EstadoUnidad", SqlDbType.Int).Value = estadoUnidad;
            cmd.Parameters.AddWithValue("@longitud", SqlDbType.VarChar).Value = longitud;
            cmd.Parameters.AddWithValue("@latitud", SqlDbType.VarChar).Value = latitud;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarSueldoUnidadPuesto(string cod_unidad, double rmv, double sueldo, int puesto,int id)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_sueldo_unidad_puesto ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_unidad", SqlDbType.VarChar).Value = cod_unidad;
            cmd.Parameters.AddWithValue("@mv", SqlDbType.Decimal).Value = rmv;
            cmd.Parameters.AddWithValue("@sueldo", SqlDbType.Decimal).Value = sueldo;
            cmd.Parameters.AddWithValue("@idpuesto", SqlDbType.Int).Value = puesto;
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarSede(string codSede, string NombreSede, int codDep, int codPro, int codDist, string Direccion,
        string Contacto, string Correo, int Celular, string centroCosto, string unidad, int estadoSede,DateTime fActivacion, DateTime fBaja
            , string latitud, string longitud)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarSede ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_sede", SqlDbType.VarChar).Value = codSede;
            cmd.Parameters.AddWithValue("@Nombre_sede", SqlDbType.VarChar).Value = NombreSede;
            cmd.Parameters.AddWithValue("@Cod_Departamento", SqlDbType.Int).Value = codDep;
            cmd.Parameters.AddWithValue("@cod_Provincia", SqlDbType.Int).Value = codPro;
            cmd.Parameters.AddWithValue("@Cod_Distrito", SqlDbType.Int).Value = codDist;
            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.AddWithValue("@Contacto_sede", SqlDbType.VarChar).Value = Contacto;
            cmd.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.AddWithValue("@celular", SqlDbType.Int).Value = Celular;
            cmd.Parameters.AddWithValue("@Centro_costo_sede", SqlDbType.VarChar).Value = centroCosto;
            cmd.Parameters.AddWithValue("@Cod_unidad", SqlDbType.VarChar).Value = unidad;

            cmd.Parameters.AddWithValue("@Estado", SqlDbType.Int).Value = estadoSede;
            cmd.Parameters.AddWithValue("@fActivaion", SqlDbType.VarChar).Value = fActivacion;
            cmd.Parameters.AddWithValue("@fBaja", SqlDbType.VarChar).Value = fBaja;

            cmd.Parameters.AddWithValue("@latitud", SqlDbType.VarChar).Value = latitud;
            cmd.Parameters.AddWithValue("@longitud", SqlDbType.VarChar).Value = longitud;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarUsuario(string cod_empleado, int area, int estado, string observaciones)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarUser ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@idCargouser", SqlDbType.Int).Value = area;
            cmd.Parameters.AddWithValue("@idestadouser", SqlDbType.Int).Value = estado;
           // cmd.Parameters.AddWithValue("@observaciones", SqlDbType.VarChar).Value = observaciones;
            cmd.ExecuteNonQuery();
        }
        public void actualizarProveedor(string cod_proveedor_cbo, string Nombre, string ruc, string observacion, int codDep, int codPro,
                                       int codDist, string direccion, string Telefono, string Celular, string Correo, DateTime fregistro,
                                       string paginaweb, string nota, string rubo, string nombre_contacto, string telefono1, string telefono2)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_proveedores ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_proveedor", SqlDbType.VarChar).Value = cod_proveedor_cbo;
            cmd.Parameters.AddWithValue("@nombre_proveedor", SqlDbType.VarChar).Value = Nombre;
            cmd.Parameters.AddWithValue("@ruc", SqlDbType.VarChar).Value = ruc;
            cmd.Parameters.AddWithValue("@observaciones", SqlDbType.VarChar).Value = observacion;
            cmd.Parameters.AddWithValue("@departamento", SqlDbType.Int).Value = codDep;
            cmd.Parameters.AddWithValue("@provincia", SqlDbType.Int).Value = codPro;
            cmd.Parameters.AddWithValue("@distrito", SqlDbType.Int).Value = codDist;
            cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = direccion;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.AddWithValue("@celular", SqlDbType.VarChar).Value = Celular;
            cmd.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.AddWithValue("@fecha_registro", SqlDbType.VarChar).Value = fregistro;
            cmd.Parameters.AddWithValue("@pagina_web", SqlDbType.VarChar).Value = paginaweb;
            cmd.Parameters.AddWithValue("@nota_comentario", SqlDbType.VarChar).Value = nota;
            cmd.Parameters.AddWithValue("@rubro", SqlDbType.VarChar).Value = rubo;
            cmd.Parameters.AddWithValue("@nombre_contacto", SqlDbType.VarChar).Value = nombre_contacto;
            cmd.Parameters.AddWithValue("@telefono1", SqlDbType.VarChar).Value = telefono1;
            cmd.Parameters.AddWithValue("@telefono2", SqlDbType.VarChar).Value = telefono2;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarAsistenciaPersonal(string ip_pc, string nombre_pc, int turno_correcto, string unidad_correcta, string sede_correcta, string personal_correcta,
          string tipoasistencia_correcta, DateTime Fecha, string nombre_usurio, string cod_Asistencia_personal)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarAsistencia ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_sede ", SqlDbType.VarChar).Value = sede_correcta;
            cmd.Parameters.AddWithValue("@Cod_Turno", SqlDbType.VarChar).Value = turno_correcto;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = personal_correcta;
            cmd.Parameters.AddWithValue("@id_tipoAsistencia", SqlDbType.VarChar).Value = tipoasistencia_correcta;
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = Fecha;
            cmd.Parameters.AddWithValue("@cod_asistencia", SqlDbType.VarChar).Value = cod_Asistencia_personal;
            cmd.Parameters.AddWithValue("@nombrePC_lap", SqlDbType.VarChar).Value = nombre_pc;
            cmd.Parameters.AddWithValue("@USERNAME", SqlDbType.VarChar).Value = nombre_usurio;
            cmd.Parameters.AddWithValue("@ipPCLaptop", SqlDbType.VarChar).Value = ip_pc;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarDatosLaboralesSueldo(string cod_empleado, DateTime fechaInicio, DateTime fechaFin, decimal SueldoBasico,
           decimal SueldoBruto, decimal bono_armado, decimal bonificacion, decimal movilidad, int banco, string cuenta,
           int familiar, int bonoferiado, int regimen_pensionario, int afp, string afpcussp, int tipo_comision, int movimiento_afp)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarDatos ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@Cod_Sueldo", SqlDbType.Decimal).Value = SueldoBasico;
            cmd.Parameters.AddWithValue("@idSueldoReal", SqlDbType.Decimal).Value = SueldoBruto;
            cmd.Parameters.AddWithValue("@FechaInicioContrato", SqlDbType.VarChar).Value = fechaInicio;
            cmd.Parameters.AddWithValue("@FechaInicioFin", SqlDbType.VarChar).Value = fechaFin;
            cmd.Parameters.AddWithValue("@bono_armado", SqlDbType.Decimal).Value = bono_armado;
            cmd.Parameters.AddWithValue("@bonificaion", SqlDbType.Decimal).Value = bonificacion;
            cmd.Parameters.AddWithValue("@produccion", SqlDbType.Decimal).Value = movilidad;
            cmd.Parameters.AddWithValue("@cuenta", SqlDbType.VarChar).Value = cuenta;
            cmd.Parameters.AddWithValue("@banco", SqlDbType.Int).Value = banco;
            cmd.Parameters.AddWithValue("@cod_familiar", SqlDbType.Int).Value = familiar;
            cmd.Parameters.AddWithValue("@id_bono_feriado", SqlDbType.Int).Value = bonoferiado;
            cmd.Parameters.AddWithValue("@regimen_pensionario", SqlDbType.Int).Value = regimen_pensionario;
            cmd.Parameters.AddWithValue("@cod_afp", SqlDbType.Int).Value = afp;
            cmd.Parameters.AddWithValue("@tipo_comision", SqlDbType.Int).Value = tipo_comision;
            cmd.Parameters.AddWithValue("@movimiento_afp", SqlDbType.Int).Value = movimiento_afp;
            cmd.Parameters.AddWithValue("@afpcuss", SqlDbType.VarChar).Value = afpcussp;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarContraUser(string cod_empleado, string _username, string _password
           , DateTime fechaCreacion, DateTime fechaVencimiento)
        {
            SqlCommand cmd = new SqlCommand("sp_ActualizarContra ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empelado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = _username;
            cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = _password;
            cmd.Parameters.AddWithValue("@fechaCreacion", SqlDbType.Int).Value = fechaCreacion;
            cmd.Parameters.AddWithValue("@fechaVencimiento", SqlDbType.Int).Value = fechaVencimiento;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarNuevoUnidadUsuarip(string cod_empleado, string unidad, int estado)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_unidad_usuarios ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@cod_unidad", SqlDbType.VarChar).Value = unidad;
            cmd.Parameters.AddWithValue("@estado", SqlDbType.Int).Value = estado;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarDatosLaborales_rrhh(string cod_empleado, DateTime fechaInicio, int TipoTrabajador,
            decimal SueldoBasico, decimal SueldoBruto, int AsignacionFamiliar,
            int TipoPago, int PeriodoRemuneracion, int bancosueldo, string cuentaBancaria, int SueldoMoneda,
            int RegimenPensionario, int afp, string afpcuss, int tipocomicion, int movimientoAFp)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarDatosLaborales_rrhh ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@Cod_RegimenPensionario", SqlDbType.Int).Value = RegimenPensionario;
            cmd.Parameters.AddWithValue("@Cod_AFP", SqlDbType.Int).Value = afp;
            cmd.Parameters.AddWithValue("@AFP_CUPSS", SqlDbType.VarChar).Value = afpcuss;
            cmd.Parameters.AddWithValue("@Cod_comision_afp", SqlDbType.Int).Value = tipocomicion;
            cmd.Parameters.AddWithValue("@Cod_Movimiento_AFP", SqlDbType.Int).Value = movimientoAFp;
            cmd.Parameters.AddWithValue("@Cod_Ocupacion", SqlDbType.Int).Value = TipoTrabajador;
            cmd.Parameters.AddWithValue("@cod_banco", SqlDbType.Int).Value = bancosueldo;
            cmd.Parameters.AddWithValue("@Cta_sueldo", SqlDbType.VarChar).Value = cuentaBancaria;
            cmd.Parameters.AddWithValue("@cod_moneda", SqlDbType.Int).Value = SueldoMoneda;
            cmd.Parameters.AddWithValue("@Cod_Sueldo", SqlDbType.Decimal).Value = SueldoBasico;
            cmd.Parameters.AddWithValue("@Cod_TipoRemuneracion", SqlDbType.Int).Value = TipoPago;
            cmd.Parameters.AddWithValue("@Cod_Periodo_remuneracion", SqlDbType.Int).Value = PeriodoRemuneracion;
            cmd.Parameters.AddWithValue("@idSueldoReal", SqlDbType.Decimal).Value = SueldoBruto;
            cmd.Parameters.AddWithValue("@Cod_Familiar", SqlDbType.Int).Value = AsignacionFamiliar;
            cmd.Parameters.AddWithValue("@FechaInicioContrato", SqlDbType.VarChar).Value = fechaInicio;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarEstadoPerosnal(string cod_empleado, int estadoPersnal,int EstadoPeronsalTareaje)
        {
            SqlCommand cmd = new SqlCommand("sp_Actualizar_estado_personal ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@estadoPersnal", SqlDbType.Int).Value = estadoPersnal;
            cmd.Parameters.AddWithValue("@EstadoPeronsalTareaje", SqlDbType.Int).Value = EstadoPeronsalTareaje;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarDatosLaborales(string cod_empleado, DateTime fechaInicio,
            int TipoTrabajador, decimal SueldoBasico, decimal SueldoBruto, int AsignacionFamiliar,
            int TipoPago, int PeriodoRemuneracion, int bancosueldo, string cuentaBancaria, int SueldoMoneda,
            int bancocts, string cuentacts, int ctsMoneda,
            int RegimenPensionario, int afp, string afpcuss, int tipocomicion, int movimientoAFp,
            decimal bonificacion, decimal movilidad
            , decimal bonoarmado, int bonoferiado)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarDatosLaborales ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@Cod_RegimenPensionario", SqlDbType.Int).Value = RegimenPensionario;
            cmd.Parameters.AddWithValue("@Cod_AFP", SqlDbType.Int).Value = afp;
            cmd.Parameters.AddWithValue("@AFP_CUPSS", SqlDbType.VarChar).Value = afpcuss;
            cmd.Parameters.AddWithValue("@Cod_comision_afp", SqlDbType.Int).Value = tipocomicion;
            cmd.Parameters.AddWithValue("@Cod_Movimiento_AFP", SqlDbType.Int).Value = movimientoAFp;
            cmd.Parameters.AddWithValue("@Cod_Ocupacion", SqlDbType.Int).Value = TipoTrabajador;
            cmd.Parameters.AddWithValue("@cod_banco", SqlDbType.Int).Value = bancosueldo;
            cmd.Parameters.AddWithValue("@Cta_sueldo", SqlDbType.VarChar).Value = cuentaBancaria;
            cmd.Parameters.AddWithValue("@cod_moneda", SqlDbType.Int).Value = SueldoMoneda;
            cmd.Parameters.AddWithValue("@Cod_Banco_cts", SqlDbType.Int).Value = bancocts;
            cmd.Parameters.AddWithValue("@Cta_CTS", SqlDbType.VarChar).Value = cuentacts;
            cmd.Parameters.AddWithValue("@cod_moneda_CTS", SqlDbType.Int).Value = ctsMoneda;
            cmd.Parameters.AddWithValue("@Cod_Sueldo", SqlDbType.Decimal).Value = SueldoBasico;
            cmd.Parameters.AddWithValue("@Cod_TipoRemuneracion", SqlDbType.Int).Value = TipoPago;
            cmd.Parameters.AddWithValue("@Cod_Periodo_remuneracion", SqlDbType.Int).Value = PeriodoRemuneracion;
            cmd.Parameters.AddWithValue("@idSueldoReal", SqlDbType.Decimal).Value = SueldoBruto;
            cmd.Parameters.AddWithValue("@Cod_Familiar", SqlDbType.Int).Value = AsignacionFamiliar;
            cmd.Parameters.AddWithValue("@FechaInicioContrato", SqlDbType.VarChar).Value = fechaInicio;
            cmd.Parameters.AddWithValue("@BonoProductividad_1", SqlDbType.Decimal).Value = bonificacion;
            cmd.Parameters.AddWithValue("@BonoProduccion_1", SqlDbType.Decimal).Value = movilidad;
            cmd.Parameters.AddWithValue("@Bonoarmado", SqlDbType.Decimal).Value = bonoarmado;
            cmd.Parameters.AddWithValue("@bonoferiado", SqlDbType.Int).Value = bonoferiado;
            cmd.ExecuteNonQuery();
        }
        public void ActualizarEmpresa(string cod_empleado, int empresa)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarempleado ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@id_empresa", SqlDbType.Int).Value = empresa;
            //cmd.Parameters.AddWithValue("@idestadouser", SqlDbType.Int).Value = estado;
            // cmd.Parameters.AddWithValue("@observaciones", SqlDbType.VarChar).Value = observaciones;
            cmd.ExecuteNonQuery();
        }
        public void actualizarAFPMixta(int comision, int afp, decimal csf, decimal cass, decimal ps, decimal aofp, decimal mra
           , DateTime fecha, DateTime fecha_i)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarAFPMixta ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_AFP", SqlDbType.Int).Value = afp;
            cmd.Parameters.AddWithValue("@Cod_TipoComisionAFP", SqlDbType.Int).Value = comision;
            cmd.Parameters.AddWithValue("@CSF_AFP", SqlDbType.Decimal).Value = csf;
            cmd.Parameters.AddWithValue("@cass_afp", SqlDbType.Decimal).Value = cass;
            cmd.Parameters.AddWithValue("@PS_AFP", SqlDbType.Decimal).Value = ps;
            cmd.Parameters.AddWithValue("@AOFP_AFP", SqlDbType.Decimal).Value = aofp;
            cmd.Parameters.AddWithValue("@RMA_AFP", SqlDbType.Decimal).Value = mra;
            cmd.Parameters.AddWithValue("@fecha_i", SqlDbType.Decimal).Value = fecha_i;
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.Decimal).Value = fecha;
            cmd.ExecuteNonQuery();
        }
        public void actualizarAFPFlujo(int comision, int afp, decimal csf, decimal ps,
            decimal aofp, decimal mra, DateTime fecha, DateTime fecha_i)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarAFPFlujo ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_AFP", SqlDbType.Int).Value = afp;
            cmd.Parameters.AddWithValue("@Cod_TipoComisionAFP", SqlDbType.Int).Value = comision;
            cmd.Parameters.AddWithValue("@CSF_F_AFP", SqlDbType.Decimal).Value = csf;
            cmd.Parameters.AddWithValue("@PS_AFP", SqlDbType.Decimal).Value = ps;
            cmd.Parameters.AddWithValue("@AOFP_AFP", SqlDbType.Decimal).Value = aofp;
            cmd.Parameters.AddWithValue("@RMA_AFP", SqlDbType.Decimal).Value = mra;
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.Int).Value = fecha;
            cmd.Parameters.AddWithValue("@fecha_i", SqlDbType.Int).Value = fecha_i;
            cmd.ExecuteNonQuery();
        }
        public void actualizarestadounidad(string cod_unidad, int estado)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarUnidadEstado ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_Estado", SqlDbType.Int).Value = estado;
            cmd.Parameters.AddWithValue("@cod_unidad", SqlDbType.VarChar).Value = cod_unidad;

            cmd.ExecuteNonQuery();
        }
        public void actualizarestadoSede(string cod_sede, int estado)
        {
            SqlCommand cmd = new SqlCommand("SP_ActualizarSedeEstado ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_sede", SqlDbType.VarChar).Value = cod_sede;
            cmd.Parameters.AddWithValue("@id_Estado", SqlDbType.Int).Value = estado;
            cmd.ExecuteNonQuery();
        }
    }
}
