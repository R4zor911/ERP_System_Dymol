using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ERP_System_Dymol
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        public static string conex = ConfigurationManager.ConnectionStrings["conexionPrimera"].ToString();

        [WebMethod]   
        public string Clientes(string nombre, string rfc, string colonia, int ciudad, int estado, int pais, string puesto, string telefono, string email, int tipoEmpleado)
        {
            string query = "ManejoDeClientes";
            SqlConnection sql = new SqlConnection(conex);
            
            SqlCommand cmd = new SqlCommand(query,sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Accion",1);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@rfc", rfc);
            cmd.Parameters.AddWithValue("@Colonia",colonia);
            cmd.Parameters.AddWithValue("@ciudad",ciudad);
            cmd.Parameters.AddWithValue("@Estado",estado);
            cmd.Parameters.AddWithValue("@Telefono",telefono);
            cmd.Parameters.AddWithValue("@Email",email);
            cmd.Parameters.AddWithValue("@Tipo",tipoEmpleado);
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
            return "";
        }
    }
}
