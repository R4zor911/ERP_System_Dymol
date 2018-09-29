using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace ERP_System_Dymol
{
    public class DatosCliente
    {
        [WebMethod]
        public void Clientes(string nombre, string rfc, string colonia, int? ciudad, int? estado, int? pais, int? puesto, int? telefono, string email)
        {


        }
    }
}