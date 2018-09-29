using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP_System_Dymol.Cliente
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public string Clientes(string nombre, string rfc, string colonia, int ciudad, int estado, int pais, string puesto, string telefono, string email)
        {


            return "";

        }


    }
    
}