using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

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
        public string Clientes(string nombre, string rfc, string colonia, int ciudad, int estado, int pais, string puesto, string telefono, string email, int tipoEmpleado, string base64, string cp)
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
            cmd.Parameters.AddWithValue("@img", base64);
            cmd.Parameters.AddWithValue("@cp",cp);
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
            return "";
        }

        [WebMethod]
        public string galeria()
        {
            DataTable dt = getTablas();
            List<Contactos> lista = new List<Contactos>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Contactos(dr));
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            string datos = js.Serialize(lista);
            return datos;
        }
        [WebMethod]
        public string getEstados()
        {
            DataTable dt = TablaEstados();
            List<ListItem> lista = new List<ListItem>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new ListItem(dr["Estado"].ToString(), dr["ID"].ToString()));
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string datos = js.Serialize(lista);
            return datos;
        }
        [WebMethod]
        public string getMunicipios(int IdEstdo)
        {
            DataTable dt = TablaMunicipios(IdEstdo);
            List<ListItem> lista = new List<ListItem>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new ListItem(dr["municipio"].ToString(), dr["id"].ToString()));
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string datos = js.Serialize(lista);
            return datos;
        }

        public DataTable getTablas()
        {
            string query = "getClientes";
            
            DataTable dt = new DataTable();
            SqlConnection sqlCone = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sqlCone);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Accion",1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);               
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];                    
            return dt;
        }

        public DataTable TablaEstados()
        {
            string query = "estadosMunicipios";

            DataTable dt = new DataTable();
            SqlConnection sqlCone = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sqlCone);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Accion", 1);
            cmd.Parameters.AddWithValue("@Estado", 0);
            cmd.Parameters.AddWithValue("@Municipio", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable TablaMunicipios(int idEstado)
        {
            string query = "estadosMunicipios";

            DataTable dt = new DataTable();
            SqlConnection sqlCone = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sqlCone);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Accion", 2);
            cmd.Parameters.AddWithValue("@Estado", idEstado);
            cmd.Parameters.AddWithValue("@Municipio", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }

    }
    public class Contactos
    {
        public Contactos() { }

        public int ID  {get;set;}
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Colonia { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Img { get; set; }

        public string CodigoPostal { get; set; }

        public Contactos(DataRow dr)
        {
            ID = (int)dr["ID"];
            Nombre = (string)dr["nombre"];
            RFC = (string)dr["rfc"];
            Colonia = (string)dr["colonia"];
            Telefono = (string)dr["telefono"];
            Email = (string)dr["email"];
            Img = (string)dr["Img"];
            CodigoPostal = (string)dr["CodigoPostal"];

        }
    }
    public class Estados
    {
        int ID { get; set; }
        string Estado { get; set; }


        public Estados(DataRow dr)
        {
            ID = (int)dr["ID"];
            Estado = (string)dr["Estado"];
        }
    }

    public class Municipios
    {
        int ID { get; set; }
        string Municipio { get; set; }


        public Municipios(DataRow dr)
        {
            ID = (int)dr["ID"];
            Municipio = (string)dr["municipio"];
        }
    }
}
