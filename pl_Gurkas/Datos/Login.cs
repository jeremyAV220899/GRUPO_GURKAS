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
   
    class Login
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();
        public void InicioSesion(Form login,string usuario,string password,int cod_empresa,string nombre_empresa)
        {
            try
            {
                SqlCommand comando = new SqlCommand("sp_inicio_sesion", conexion.conexionBD());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contrasena ", password);
                comando.ExecuteNonQuery();
                SqlDataAdapter sqlDatAdap = new SqlDataAdapter(comando);
                DataTable dtab = new DataTable();
                sqlDatAdap.Fill(dtab);
                if (dtab.Rows.Count == 1)
                {
                    string _username = dtab.Rows[0][0].ToString();
                    string _password = dtab.Rows[0][1].ToString();
                    string _rol = dtab.Rows[0][2].ToString();
                    int _cod_rol =Convert.ToInt32(dtab.Rows[0][3].ToString());
                    string _nombre = dtab.Rows[0][4].ToString();
                    Datos.CodEmplado._codempleado = dtab.Rows[0][5].ToString(); 
                    if (_username.Equals(usuario) && _password.Equals(password))
                    {
                        if (cod_empresa == 1)
                        {
                            login.Hide();
                            Vista.Principal.frmPrincipalGrupoGurkas grupogurkas = new Vista.Principal.frmPrincipalGrupoGurkas();
                            grupogurkas._idempresa = cod_empresa;
                            grupogurkas._nombreempresa = nombre_empresa;
                            grupogurkas._usuario = _nombre;
                            grupogurkas._perfil = _rol;
                            grupogurkas._codrol = _cod_rol;
                            grupogurkas.Show();

                            Datos.DatosUsuario._idempresa = cod_empresa;
                            Datos.DatosUsuario._nombreempresa = nombre_empresa;
                            Datos.DatosUsuario._usuario = _nombre;
                            Datos.DatosUsuario._perfil = _rol;
                            Datos.DatosUsuario._codrol = _cod_rol;

                            modulo.auditoria("Inicio De Sistema Grupo Gurkas", "Inicio De Sistema Grupo Gurkas", "", "");

                        }
                        if (cod_empresa == 2)
                        {
                            login.Hide();
                            Vista.Principal.frmPrincipalConsorcioGurkas consorciogurkas = new Vista.Principal.frmPrincipalConsorcioGurkas();
                            consorciogurkas._idempresa = cod_empresa;
                            consorciogurkas._nombreempresa = nombre_empresa;
                            consorciogurkas._usuario = _nombre;
                            consorciogurkas._perfil = _rol;
                            consorciogurkas._codrol = _cod_rol;
                            consorciogurkas.Show();

                            Datos.DatosUsuario._idempresa = cod_empresa;
                            Datos.DatosUsuario._nombreempresa = nombre_empresa;
                            Datos.DatosUsuario._usuario = _nombre;
                            Datos.DatosUsuario._perfil = _rol;
                            Datos.DatosUsuario._codrol = _cod_rol;

                            modulo.auditoria("Inicio De Sistema Consorcio Gurkas", "Inicio De Sistema Consorcio Gurkas", "", "");
                        }
                    }
                }
                else
                {
                    const string titulo = "Error en credenciales.";
                    const string mensaje = "Error en tu USUARIO o CONTRASEÑA, verifica y vuelve a ingresar";
                    MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void IniciarSesionAdmin(Form login,string usuario, string password)
        {
            SqlCommand comando = new SqlCommand("sp_inicio_sesion_admin", conexion.conexionBD());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena ", password);
            comando.ExecuteNonQuery();
            SqlDataAdapter sqlDatAdap = new SqlDataAdapter(comando);
            DataTable dtab = new DataTable();
            sqlDatAdap.Fill(dtab);
            if (dtab.Rows.Count == 1)
            {
                login.Hide();
                Vista.Principal.frmPrincialAdministrador admin = new Vista.Principal.frmPrincialAdministrador();
                admin.Show();
            }
            else
            {
                const string titulo = "Error en credenciales.";
                const string mensaje = "Error en tu USUARIO o CONTRASEÑA, verifica y vuelve a ingresar";
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
