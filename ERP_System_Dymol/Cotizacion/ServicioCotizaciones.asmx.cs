using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.Net;
using System.Net.Mail;
using System.IO;


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
                lista.peticion = reader["peticion"].ToString();
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
        public string InsertQuotation(List<string>userdata,List<string>names,List<string>descriptions,List<string>prices, string email, string url)
        {
           

            string[] quotation = userdata.ToArray();
            string[] name = names.ToArray();
            string[] description = descriptions.ToArray();
            string[] price = prices.ToArray();

            
            // Insertar cotizacion
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

            //EMAIL FUNCION obtener de una vez Correo y nombre
            string MailUser = quotation[1];
            string MailAddress = email;

            // Recibir URL para redireccionar en html de correo
            string FixedUrl = url += IdCotizacion.ToString(); 
            SendEmail(MailUser,MailAddress,FixedUrl);
            
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
        
        private void SendEmail(string name, string email, string url)
        {

            // Obtener configuración desde WebConfig (previamente establecidos)
            string emailSender = ConfigurationManager.AppSettings["usernameOutlook"].ToString();
            string emailSenderPassword = ConfigurationManager.AppSettings["passwordOutlook"].ToString();
            string emailSenderHost = ConfigurationManager.AppSettings["smtpOutlook"].ToString();
            int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["portOutlook"]);
            Boolean emailSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["SSL"]);

            //Obtener archivo html desde directorio local de servidor de la aplicacion
            string FilePath = Server.MapPath("~/Otros/emailScratch.html");
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();



            // Remplazar texto por url
            string urlQuotation = url;
            MailText = MailText.Replace("#AQUI", urlQuotation.Trim());

            // Remplazar [usuario] por company/user name
            MailText = MailText.Replace("[usuario]", name.Trim());
            // Crear Asunto para EMAIL 
            string subject = "Revisión de Cotización - MaquinadosDYMOL";
           
            // CONFIGURACIÓN     M A I L       M E S S A G E

            // Clase base para envio de Email
            MailMessage mailmsg = new MailMessage();
            
            // Hacer Verdadero porque nuestro cuerpo es html
            mailmsg.IsBodyHtml = true;
            // Configurar "De" + Email
            mailmsg.From = new MailAddress(emailSender);
            // Configurar "Para"  + Email
            mailmsg.To.Add(email);
            // Configurar "Asunto"
            mailmsg.Subject = subject;
            // Configurar Body de correo
            mailmsg.Body = MailText;


            // CONFIGURAR  S M T P
            SmtpClient smtp = new SmtpClient();

            // Configurar Host
            smtp.Host = emailSenderHost;
            // Configurar Puerto
            smtp.Port = emailSenderPort;
            // Configurar SSL ---> True / False
            smtp.EnableSsl = emailSSL;

            // Configurar credenciales
            NetworkCredential credentials = new NetworkCredential(emailSender, emailSenderPassword);
            smtp.Credentials = credentials;

            // Enviar - El metodo "Send" enviará el MailMessage configurado.
            smtp.Send(mailmsg);
            

        }


        [WebMethod]
        public string DeleteQuotation(int Id)
        {
            string query = "DeleteQuotation";
            SqlConnection con = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "";
        }

        [WebMethod]
        public string CustomerPreview(int dato)
        {
            List<QuotationPreview> LstCotizacion = new List<QuotationPreview>();
            QuotationPreview lista = new QuotationPreview();

            string query = "BuscarCotizacion";
            SqlConnection sql = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", dato);
            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.nombre = reader["nombre"].ToString();
                lista.fecha = reader["fecha"].ToString();
                lista.direccion = reader["direccion"].ToString();
                lista.cp = reader["cp"].ToString();
                lista.ciudad = reader["ciudad"].ToString();
                lista.estado = reader["estado"].ToString();
                lista.subtotal = reader["subtotal"].ToString();
                lista.descuento = reader["descuento"].ToString();
                lista.impuesto = reader["impuesto"].ToString();
                lista.total = reader["total"].ToString();
                LstCotizacion.Add(lista);
            }
            reader.Close();
            sql.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string datos = js.Serialize(LstCotizacion);
            return datos;
        }

        [WebMethod]
        public string CustomerQuotationDetails(int dato)
        {
            string query = "BuscarCotizacionDetalle";
            List<QuotationPreviewTable> LstCotizacionDetalles = new List<QuotationPreviewTable>();
            QuotationPreviewTable lista;

            SqlConnection sql = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", dato);
            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista = new QuotationPreviewTable();
                lista.servicio = reader["nombre"].ToString();
                lista.descripcion = reader["descripcion"].ToString();
                lista.costo = reader["costo"].ToString();
                

                LstCotizacionDetalles.Add(lista);
            }
            reader.Close();
            sql.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            //Serializar Js
            string datos = js.Serialize(LstCotizacionDetalles);
            return datos;
        }


        [WebMethod]
        public string AcceptQuotation(int Id)
        {
            string query = "Update tbl_Cotizaciones Set peticion = 1 Where id = '"+Id+"' ";
            SqlConnection con = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "";
        }
        [WebMethod]
        public string CancelQuotation(int Id)
        {
            string query = "Update tbl_Cotizaciones set peticion = 2 Where id = '"+Id+"'";
            SqlConnection con = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "";
        }

        [WebMethod]
        public int Status(int Id)
        {
            int id = 0;
            string Query = "Select peticion from tbl_Cotizaciones Where id = '"+Id+"'";
            SqlConnection con = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt16(reader["peticion"]);
            }
            reader.Close();
            con.Close();

            Id = id;
            return Id;
        }


        [WebMethod]
        public string AcceptedQuotations()
        {
            string query = "CargarCotizaciones";
            List<CotizacionesAceptadas> LstAceptadas = new List<CotizacionesAceptadas>();
            CotizacionesAceptadas listaAceptadas;
            SqlConnection sql = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listaAceptadas = new CotizacionesAceptadas();
                listaAceptadas.fecha = reader["fecha"].ToString();
                listaAceptadas.nombre = reader["nombre"].ToString();
                listaAceptadas.ciudad = reader["ciudad"].ToString();
                listaAceptadas.estado = reader["estado"].ToString();
                listaAceptadas.subtotal = reader["subtotal"].ToString();
                listaAceptadas.descuento = reader["descuento"].ToString();
                listaAceptadas.impuesto = reader["impuesto"].ToString();
                listaAceptadas.total = reader["total"].ToString();
                listaAceptadas.IdCliente = int.Parse(reader["IdCliente"].ToString());
                listaAceptadas.id = int.Parse(reader["id"].ToString());
                listaAceptadas.peticion = reader["peticion"].ToString();
                LstAceptadas.Add(listaAceptadas);
            }
            reader.Close();
            sql.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            //Serializar Js
            string aceptados = js.Serialize(LstAceptadas);
            return aceptados;

        }

        [WebMethod]
        public string CancelledQuotations()
        {
            string query = "CancelledQuotations";
            List<CotizacionesCanceladas> LstCanceladas = new List<CotizacionesCanceladas>();
            CotizacionesCanceladas listaCanceladas;

            SqlConnection sql = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listaCanceladas = new CotizacionesCanceladas();
                listaCanceladas.fecha = reader["fecha"].ToString();
                listaCanceladas.nombre = reader["nombre"].ToString();
                listaCanceladas.ciudad = reader["ciudad"].ToString();
                listaCanceladas.estado = reader["estado"].ToString();
                listaCanceladas.subtotal = reader["subtotal"].ToString();
                listaCanceladas.descuento = reader["descuento"].ToString();
                listaCanceladas.impuesto = reader["impuesto"].ToString();
                listaCanceladas.total = reader["total"].ToString();
                listaCanceladas.IdCliente = int.Parse(reader["IdCliente"].ToString());
                listaCanceladas.id = int.Parse(reader["id"].ToString());
                listaCanceladas.peticion = reader["peticion"].ToString();
                LstCanceladas.Add(listaCanceladas);
            }
            reader.Close();
            sql.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            //Serializar Js
            string cancelados = js.Serialize(LstCanceladas);
            return cancelados;
        }


        [WebMethod]
        public string QuotationStatus()
        {
            string query = "QuotationStatus";
            List<QuotationStatus> lstQuotation = new List<QuotationStatus>();
            QuotationStatus lista;
            SqlConnection con = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista = new QuotationStatus();
                lista.aceptadas = int.Parse(reader["Aceptadas"].ToString());
                lista.canceladas = int.Parse(reader["Canceladas"].ToString());
                lstQuotation.Add(lista);
            }
            reader.Close();
            con.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string datos = js.Serialize(lstQuotation);
            return datos;
        }
    }
}
