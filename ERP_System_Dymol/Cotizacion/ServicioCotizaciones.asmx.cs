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
    }
}
