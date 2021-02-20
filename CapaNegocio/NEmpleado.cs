using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEmpleado
    {
        public static DataTable Login(string usuario, string pasword)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.User = usuario;
            Obj.Pasword = pasword;
            return Obj.Login(Obj);
        }
    }    
}
