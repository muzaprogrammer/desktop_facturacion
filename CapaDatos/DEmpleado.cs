using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleado
    {
        private int _Id;
        private string _Nombres;
        private string _Apellidos;
        private string _TipoDoc;
        private string _NumeroDoc;
        private string _Direccion;
        private DateTime _FechaNacimiento;
        private DateTime _FechaIngreso;
        private double _sueldo;
        private string _Genero;
        private string _Telefono;
        private string _Turno;
        private string _User;
        private string _Pasword;
        private string _TextoBuscar;
        private string _TextoBuscarr;
        private string _Acceso;

        public DEmpleado()
        {
        }

        public DEmpleado(int id, string nombres, string apellidos, string tipoDoc, string numeroDoc, string direccion, DateTime fechaNacimiento, DateTime fechaIngreso, double sueldo, string genero, string telefono, string turno, string user, string pasword, string textoBuscar, string textoBuscarr, string acceso)
        {
            _Id = id;
            _Nombres = nombres;
            _Apellidos = apellidos;
            _TipoDoc = tipoDoc;
            _NumeroDoc = numeroDoc;
            _Direccion = direccion;
            _FechaNacimiento = fechaNacimiento;
            _FechaIngreso = fechaIngreso;
            _sueldo = sueldo;
            _Genero = genero;
            _Telefono = telefono;
            _Turno = turno;
            _User = user;
            _Pasword = pasword;
            _TextoBuscar = textoBuscar;
            _TextoBuscarr = textoBuscarr;
            _Acceso = acceso;
        }

        public int Id { get => _Id; set => _Id = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string TipoDoc { get => _TipoDoc; set => _TipoDoc = value; }
        public string NumeroDoc { get => _NumeroDoc; set => _NumeroDoc = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public DateTime FechaIngreso { get => _FechaIngreso; set => _FechaIngreso = value; }
        public double Sueldo { get => _sueldo; set => _sueldo = value; }
        public string Genero { get => _Genero; set => _Genero = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Turno { get => _Turno; set => _Turno = value; }
        public string User { get => _User; set => _User = value; }
        public string Pasword { get => _Pasword; set => _Pasword = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string TextoBuscarr { get => _TextoBuscarr; set => _TextoBuscarr = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }

        public DataTable Login(DEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("EMPLEADOS");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SRLOGIN";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@USUARIO";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Empleado.User;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPasword = new SqlParameter();
                ParPasword.ParameterName = "@PASWORD";
                ParPasword.SqlDbType = SqlDbType.VarChar;
                ParPasword.Size = 50;
                ParPasword.Value = Empleado.Pasword;
                SqlCmd.Parameters.Add(ParPasword);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                string msm = Convert.ToString(ex);
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
