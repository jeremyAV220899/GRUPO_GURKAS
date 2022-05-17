using System;
using System.Data;
using System.Data.SqlClient;

namespace pl_Gurkas.Datos
{
    class registrar
    {
        Datos.Conexiondbo  conexion = new Datos.Conexiondbo();

        public void RegistrarPersonal(string codEmpleado, string Nombre, string ApPaterno, string ApMaterno, string NombreCompleto,
          int edad, int tipoDoc, string NumDOc, int sexo, DateTime Femision, DateTime Fcaducacion, DateTime Fnacimineto, int brevete,
          string nbrevete, int Nacionalidad, int codDep, int codPro, int codDist, string Domicilio, int Telefono, int Celular,
          string Correo, int GradoInstruccion, int EstadoCivil, int EstadoPersonal, int CargoLaboral, int Empresa, int TipoContrato,
          DateTime fechaInicio, DateTime fechaFin, string Sede, int turno, int tallacamisa, int tallapantalon, int tallacalzado, decimal estatura,
          int horas, string codUbigeo, string unidad, int idArmado, DateTime finiciolaboral, DateTime ffinlaboral , DateTime factivacionPersonal , DateTime fdestaquePersonal)
        {
            SqlCommand cmd = new SqlCommand("SP_InsetarPersonalMae ", conexion.conexionBD());

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


        public void RegistrarPersonalC4(string codEmpleado, decimal estaturac4, string Empresa1, string Empresa2, string Empresa3,
                                        DateTime FechaEmisionC4, DateTime FCaducidadC4, DateTime InicioExp1, DateTime InicioExp2, DateTime InicioExp3,
                                         DateTime FinExp1, DateTime FinExp2, DateTime FinExp3,
                                        int GradoInstruccionExp, int Experiencia1, int Experiencia2, int Experiencia3)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_datos_c4 ", conexion.conexionBD());

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
        public void RegistrarPersonalSucamec(string codEmpleado, string sucamec, string arma, string Empresa1, string Empresa2, string Empresa3,
                                       DateTime FechaVigenciaSucamec, DateTime FechaVigenciaArma, DateTime InicioExp1, DateTime InicioExp2, DateTime InicioExp3,
                                        DateTime FinExp1, DateTime FinExp2, DateTime FinExp3
                                       , int Experiencia1, int Experiencia2, int Experiencia3)
        {
            SqlCommand cmd = new SqlCommand("sp_registrar_sucamec ", conexion.conexionBD());

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

        public void Registrardescansomedico(string cod_empleado, DateTime f_inicio, DateTime f_fin, int n_dias, string area, string n_ciit
         , string diagnostico, string centro_medico, string contigencia, decimal renta, decimal sucamec, decimal alimentos, decimal botas,
          decimal multa, decimal excesopago, decimal covid, decimal papeles, decimal prestamos, decimal equipo)
        {
            SqlCommand cmd = new SqlCommand("sp_registrar_descanso_medico ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@fecha_inicio", SqlDbType.VarChar).Value = f_inicio;
            cmd.Parameters.AddWithValue("@fecha_fin", SqlDbType.VarChar).Value = f_fin;
            cmd.Parameters.AddWithValue("@n_dias", SqlDbType.Int).Value = n_dias;
            cmd.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = area;
            cmd.Parameters.AddWithValue("@n_ciit", SqlDbType.VarChar).Value = n_ciit;
            cmd.Parameters.AddWithValue("@diagnostico", SqlDbType.VarChar).Value = diagnostico;
            cmd.Parameters.AddWithValue("@centro_asistencia", SqlDbType.VarChar).Value = centro_medico;
            cmd.Parameters.AddWithValue("@contingencia", SqlDbType.VarChar).Value = contigencia;
            cmd.Parameters.AddWithValue("@renta_quinta", SqlDbType.Decimal).Value = renta;
            cmd.Parameters.AddWithValue("@sucamec", SqlDbType.Decimal).Value = sucamec;
            cmd.Parameters.AddWithValue("@alimento", SqlDbType.Decimal).Value = alimentos;
            cmd.Parameters.AddWithValue("@botas", SqlDbType.Decimal).Value = botas;
            cmd.Parameters.AddWithValue("@multa", SqlDbType.Decimal).Value = multa;
            cmd.Parameters.AddWithValue("@excesopago", SqlDbType.Decimal).Value = excesopago;
            cmd.Parameters.AddWithValue("@covid", SqlDbType.Decimal).Value = covid;
            cmd.Parameters.AddWithValue("@papeles", SqlDbType.Decimal).Value = papeles;
            cmd.Parameters.AddWithValue("@prestamos", SqlDbType.Decimal).Value = prestamos;
            cmd.Parameters.AddWithValue("@equipos", SqlDbType.Decimal).Value = equipo;
            cmd.ExecuteNonQuery();
        }

        public void registrarSueldoUnidadPuesto(string cod_unidad,double rmv ,double sueldo,int puesto)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_sueldo_unidad_puesto ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_unidad", SqlDbType.VarChar).Value = cod_unidad;
            cmd.Parameters.AddWithValue("@mv", SqlDbType.Decimal).Value = rmv;
            cmd.Parameters.AddWithValue("@sueldo", SqlDbType.Decimal).Value = sueldo;
            cmd.Parameters.AddWithValue("@idpuesto", SqlDbType.Int).Value = puesto;
            cmd.ExecuteNonQuery();
        }

        public void registrarProveedor(string codProveedor, string Nombre, string ruc, string observacion, int codDep, int codPro,
                                        int codDist, string direccion, string Telefono, string Celular, string Correo, DateTime fregistro,
                                        string paginaweb, string nota, string rubo, string nombre_contacto, string telefono1, string telefono2)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_proveedores ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_proveedor", SqlDbType.VarChar).Value = codProveedor;
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

        public void RegistrarAsistenciasVacacionesDescansoM(string cod_empleado, int priodo_inicio, int periodo_fin,
          int dias_acumulados, int dias_vendidos, int dias_disfrutados, DateTime finicio, DateTime ffin, decimal sueldo)
        {
            SqlCommand cmd = new SqlCommand("sp_registrar_vacaciones_descansoM_Planilla ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@periodo_inicio", SqlDbType.Int).Value = priodo_inicio;
            cmd.Parameters.AddWithValue("@periodo_fin", SqlDbType.Int).Value = periodo_fin;
            cmd.Parameters.AddWithValue("@fecha_inicio", SqlDbType.VarChar).Value = finicio;
            cmd.Parameters.AddWithValue("@fecha_fin", SqlDbType.VarChar).Value = ffin;
            cmd.Parameters.AddWithValue("@dias_acumulados", SqlDbType.Int).Value = dias_acumulados;
            cmd.Parameters.AddWithValue("@dias_vendidos", SqlDbType.Int).Value = dias_vendidos;
            cmd.Parameters.AddWithValue("@dias_disfrutados", SqlDbType.Int).Value = dias_disfrutados;
            cmd.Parameters.AddWithValue("@sueldo", SqlDbType.Decimal).Value = sueldo;
            cmd.ExecuteNonQuery();
        }
        public void Registrarotraslicencias(string cod_empleado, int dias, DateTime finicio, DateTime fin,
         int tipo_licencia, string tipo_documento, string area)
        {
            SqlCommand cmd = new SqlCommand("sp_registrar_otras_licencias_planilla ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@tipos_licencias", SqlDbType.Int).Value = tipo_licencia;
            cmd.Parameters.AddWithValue("@dias", SqlDbType.Int).Value = dias;
            cmd.Parameters.AddWithValue("@tipo_documento", SqlDbType.VarChar).Value = tipo_documento;
            cmd.Parameters.AddWithValue("@fecha_inicio", SqlDbType.VarChar).Value = finicio;
            cmd.Parameters.AddWithValue("@fecha_fin", SqlDbType.VarChar).Value = fin;
            cmd.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = area;
            cmd.ExecuteNonQuery();
        }
        public void RegistrarAsistenciaAdministrador(string cod_empleado, DateTime FechaInicio, int codTurno, string codunidad,
     string codSede, string tipoasistencia)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_asistencia_admi ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@FechaInicio", SqlDbType.VarChar).Value = FechaInicio;
            cmd.Parameters.AddWithValue("@codTurno", SqlDbType.Int).Value = codTurno;
            cmd.Parameters.AddWithValue("@codunidad", SqlDbType.VarChar).Value = codunidad;
            cmd.Parameters.AddWithValue("@codSede", SqlDbType.VarChar).Value = codSede;
            cmd.Parameters.AddWithValue("@tipoasistencia", SqlDbType.VarChar).Value = tipoasistencia;
            cmd.ExecuteNonQuery();
        }
        public void InsertarFamiliarColaborador(string codEmpleado, string Esposo, string dniespo, string hijo1, string dni1,
       string hijo2, string dni2, string hijo3, string dni3, string hijo4, string dni4,int cantidad_hijos)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarFamiliarColaborador ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_Familiares", SqlDbType.VarChar).Value = codEmpleado;
            cmd.Parameters.AddWithValue("@Cod_empleado", SqlDbType.VarChar).Value = codEmpleado;
            cmd.Parameters.AddWithValue("@Hijo_a_1", SqlDbType.VarChar).Value = hijo1;
            cmd.Parameters.AddWithValue("@DNI_1", SqlDbType.VarChar).Value = dni1;
            cmd.Parameters.AddWithValue("@Hijo_a_2", SqlDbType.VarChar).Value = hijo2;
            cmd.Parameters.AddWithValue("@DNI_2", SqlDbType.VarChar).Value = dni2;
            cmd.Parameters.AddWithValue("@Hijo_a_3", SqlDbType.VarChar).Value = hijo3;
            cmd.Parameters.AddWithValue("@DNI_3", SqlDbType.VarChar).Value = dni3;
            cmd.Parameters.AddWithValue("@Hijo_a_4", SqlDbType.VarChar).Value = hijo4;
            cmd.Parameters.AddWithValue("@DNI_4", SqlDbType.VarChar).Value = dni4;
            cmd.Parameters.AddWithValue("@Esposa_o", SqlDbType.VarChar).Value = Esposo;
            cmd.Parameters.AddWithValue("@DNI_esp_con", SqlDbType.VarChar).Value = dniespo;
            cmd.Parameters.AddWithValue("@cantidadHijos", SqlDbType.Int).Value = cantidad_hijos;
            cmd.ExecuteNonQuery();
        }
        public void RegistrarPlanilla(DateTime fecha, DateTime fechaGenerada)
        {
            // SqlCommand cmd = new SqlCommand("SP_insertarHitoricoPlanilla ", conexion.ConexionBD());
            SqlCommand cmd = new SqlCommand("sp_planilla_guardar_15_30 ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaGenerado", SqlDbType.VarChar).Value = fecha;
            cmd.Parameters.AddWithValue("@fechaGeneradosistema", SqlDbType.VarChar).Value = fechaGenerada;
            cmd.ExecuteNonQuery();
        }
        public void RegistrarUnidad(string codUnidad, string RazonSocial, string RUC, string NombreComercial, int codDep, int codPro, int codDist, string Direccion,
          string RepresentanteLegal, string dni, string cargo, string contacto, int Telefono, int Celular, string Correo, string centroCosto
             , DateTime Factivacion, DateTime Fbaja, int empresa, int estadoUnidad, string latitud, string longitud)
        {
            SqlCommand cmd = new SqlCommand("SP_RegistrarUnidad ", conexion.conexionBD());
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

        public void RegistrarSede(string codSede, string NombreSede, int codDep, int codPro, int codDist, string Direccion,
        string Contacto, string Correo, int Celular, string centroCosto, string unidad, 
        int estadoSede,DateTime fActivacion, DateTime fBaja,string latitud, string longitud )
        {
            SqlCommand cmd = new SqlCommand("SP_RegistrarSede ", conexion.conexionBD());
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

            cmd.Parameters.AddWithValue("@longitud", SqlDbType.VarChar).Value = longitud;
            cmd.Parameters.AddWithValue("@latitud", SqlDbType.VarChar).Value = latitud;
            cmd.ExecuteNonQuery();
        }
        public void RegistrarNuevoUsuario(string cod_empleado, string empleado, string _username, string _password, int area,
         DateTime fechaCreacion, DateTime fechaVencimiento)
        {
            SqlCommand cmd = new SqlCommand("sp_registrarUsuario ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = empleado;
            cmd.Parameters.AddWithValue("@cod_empelado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = _username;
            cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = _password;
            cmd.Parameters.AddWithValue("@idrol", SqlDbType.Int).Value = area;
            cmd.Parameters.AddWithValue("@fechaCreacion", SqlDbType.Int).Value = fechaCreacion;
            cmd.Parameters.AddWithValue("@fechaVencimiento", SqlDbType.Int).Value = fechaVencimiento;
            cmd.ExecuteNonQuery();
        }
        public void RegistrarNuevoUnidadUsuarip(string cod_empleado, string unidad, int estado)
        {
            SqlCommand cmd = new SqlCommand("sp_registrar_unidad_usuarios ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_empleado", SqlDbType.VarChar).Value = cod_empleado;
            cmd.Parameters.AddWithValue("@cod_unidad", SqlDbType.VarChar).Value = unidad;
            cmd.Parameters.AddWithValue("@estado", SqlDbType.Int).Value = estado;
            cmd.ExecuteNonQuery();

        }
        public void RegistrarDatosLaboralesRRHH(string cod_empleado, DateTime fechaInicio, int TipoTrabajador, 
            decimal SueldoBasico, decimal SueldoBruto, int AsignacionFamiliar,
            int TipoPago, int PeriodoRemuneracion, int bancosueldo, string cuentaBancaria, int SueldoMoneda,
            int RegimenPensionario, int afp, string afpcuss, int tipocomicion, int movimientoAFp)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarDatosLaboralesRRHH ", conexion.conexionBD());
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
        public void RegistrarDatosLaborales(string cod_empleado, DateTime fechaInicio, int TipoTrabajador, 
            decimal SueldoBasico, decimal SueldoBruto, int AsignacionFamiliar,
        int TipoPago, int PeriodoRemuneracion, int bancosueldo, string cuentaBancaria, int SueldoMoneda, 
        int bancocts, string cuentacts, int ctsMoneda,
        int RegimenPensionario, int afp, string afpcuss, int tipocomicion, int movimientoAFp,
        decimal bonificacion, decimal movilidad, decimal bonoarmado, int bonoferiado)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarDatosLaborales ", conexion.conexionBD());
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
        public void generar_planilla_cts()
        {
            SqlCommand cmd = new SqlCommand("sp_subir_cts_parte_1 ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }
        public void generar_planilla_grati()
        {
            SqlCommand cmd = new SqlCommand("sp_calculo_grati ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }
        public void generar_planilla(DateTime fechainicio, DateTime fechafin)
        {
            SqlCommand cmd = new SqlCommand("sp_realizar_calculo_planilla ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaInicio", SqlDbType.VarChar).Value = fechainicio;
            cmd.Parameters.AddWithValue("@fechaFin", SqlDbType.Int).Value = fechafin;
            cmd.ExecuteNonQuery();
        }
        public void generar_planillaTotal(DateTime fechainicio, DateTime fechafin)
        {
            SqlCommand cmd = new SqlCommand("sp_calculo_planilla_Total ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaInicio", SqlDbType.VarChar).Value = fechainicio;
            cmd.Parameters.AddWithValue("@fechaFin", SqlDbType.Int).Value = fechafin;
            cmd.ExecuteNonQuery();
        }
        public void generar_planilla_bloqueos(DateTime fechainicio, DateTime fechafin)
        {
            SqlCommand cmd = new SqlCommand("sp_realizar_calculo_planilla_bloqueos ", conexion.conexionBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaInicio", SqlDbType.VarChar).Value = fechainicio;
            cmd.Parameters.AddWithValue("@fechaFin", SqlDbType.Int).Value = fechafin;
            cmd.ExecuteNonQuery();
        }
    }
}
