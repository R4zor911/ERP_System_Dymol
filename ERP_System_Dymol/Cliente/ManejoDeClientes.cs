using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ERP_System_Dymol.Cliente
{
    public class ManejoDeClientes
    {
        [WebMethod]
        public string Clientes(string nombre, string rfc, string colonia, int ciudad, int estado, int pais, string puesto, string telefono, string email)
        {


            return "";

        }
    }
}