using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;


namespace ERP_System_Dymol.Cotizacion
{
    /// <summary>
    /// Descripción breve de ServicioCotizaciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ServicioCotizaciones : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        
        public static string conex = ConfigurationManager.ConnectionStrings["conexionPrimera"].ToString();

        // CARGAR COTIZACIONES
        [WebMethod]
        public string LoadCotizaciones() // string -  void(to use Context)
        {
            string query = "CargarCotizaciones";
            List<TablaCotizaciones> LstCotizaciones = new List<TablaCotizaciones>();
            TablaCotizaciones lista;

            SqlConnection sql = new SqlConnection(conex);            
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()){
                lista = new TablaCotizaciones();
                lista.fecha = reader["fecha"].ToString();
                lista.nombre = reader["nombre"].ToString();
                lista.ciudad = reader["ciudad"].ToString();
                lista.estado = reader["estado"].ToString();
                lista.subtotal = reader["subtotal"].ToString();
                lista.descuento = reader["descuento"].ToString();
                lista.impuesto = reader["impuesto"].ToString();
                lista.total = reader["total"].ToString();
                lista.IdCliente = int.Parse(reader["IdCliente"].ToString());
                lista.id = int.Parse(reader["id"].ToString());
                
                LstCotizaciones.Add(lista);
            }
            reader.Close();
            sql.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            //Serializar Js
            string datos = js.Serialize(LstCotizaciones);
            return datos;

            //Verificar Json en pagina .asmx
            //Context.Response.Write(js.Serialize(LstCotizaciones));

            //Convertir Lista a Json
            //string datos = JsonConvert.SerializeObject(LstCotizaciones);
            //return datos;

        }

        //  BUSCAR CLIENTE 
        [WebMethod]
        public string Cliente(string email)
        {
            List<BuscarCliente> LstCliente = new List<BuscarCliente>();
            BuscarCliente lista;

            string query = "BuscarCliente";
            SqlConnection sql = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista = new BuscarCliente();
                lista.nombre = reader["nombre"].ToString();
                lista.ciudad = reader["municipio"].ToString();
                lista.estado = reader["estado"].ToString();
                lista.IdCliente = int.Parse(reader["ID"].ToString());
                lista.tipo = reader["descripcion"].ToString();
                lista.direccion = reader["direccion"].ToString();
                lista.codigo = reader["codigoPostal"].ToString();
                LstCliente.Add(lista);
            }
            reader.Close();
            sql.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string datos = js.Serialize(LstCliente);
            return datos;

        }
        [WebMethod]
        public string InsertQuotation(List<string>userdata,List<string>names,List<string>descriptions,List<string>prices)
        {

            string[] quotation = userdata.ToArray();
            string[] name = names.ToArray();
            string[] description = descriptions.ToArray();
            string[] price = prices.ToArray();

            string query = "InsertQuotation";
            SqlConnection sqlcon = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha",quotation[0]);
            cmd.Parameters.AddWithValue("@nombre", quotation[1]);
            cmd.Parameters.AddWithValue("@direccion", quotation[2]);
            cmd.Parameters.AddWithValue("@ciudad", quotation[3]);
            cmd.Parameters.AddWithValue("@estado", quotation[4]);
            cmd.Parameters.AddWithValue("@cp", quotation[5]);
            cmd.Parameters.AddWithValue("@subtotal", quotation[6]);
            cmd.Parameters.AddWithValue("@descuento", quotation[7]);
            cmd.Parameters.AddWithValue("@impuesto", quotation[8]);
            cmd.Parameters.AddWithValue("@total", quotation[9]);
            cmd.Parameters.AddWithValue("@IdCliente", ((object)quotation[10]) ?? DBNull.Value);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            int IdCotizacion = GetLastId();
            
            for(int x = 0; x < name.Count(); x++)
            {
                string nam = name[x];
                string des = description[x];
                string pri = prices[x];

                InsertDetails(nam, des, pri, IdCotizacion);
            }
        

            
            return "";
        }
        private int GetLastId()
        {
            string query = "SELECT MAX(id) as Id FROM tbl_Cotizaciones";
            SqlConnection conexion = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int id = 0;
            if (reader.Read())
            {
                id = Convert.ToInt32(reader["Id"]);
            }
            conexion.Close();
            return id;
        }

        private void InsertDetails(string nam,string des, string pri,int id)
        {
            string query = "InsertDetails";
            SqlConnection SqlCon = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query,SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre",nam);
            cmd.Parameters.AddWithValue("@descripcion", des);
            cmd.Parameters.AddWithValue("@costo", pri);
            cmd.Parameters.AddWithValue("@IdCotizacion", id);
            SqlCon.Open();
            cmd.ExecuteNonQuery();
            SqlCon.Close();
        }
        private int SendEmail()
        {
            return 0;
        }
        [WebMethod]
        public string DeleteQuotation(int customerId)
        {
            string query = "DeleteQuotation";
            SqlConnection con = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",customerId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "";
        }


    }
}
