using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_System_Dymol.Cotizacion
{
    public class QuotationPreviewTable
    {
        public QuotationPreviewTable()
        {

        }
        public string servicio { get; set; }
        public string descripcion { get; set; }
        public string costo { get; set; }

        public QuotationPreviewTable(string ser, string des, string cos)
        {
            this.servicio = ser;
            this.descripcion = des;
            this.costo = cos;
        }
    }
    public class QuotationPreview
    {
        public QuotationPreview()
        {

        }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public string direccion { get; set; }
        public string cp { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string subtotal { get; set; }
        public string descuento { get; set; }
        public string impuesto { get; set; }
        public string total { get; set; }

        public QuotationPreview(string nom,string fec,string dir,string cod,string ciu, string est, string sub, string des, string imp, string tot)
        {
            this.nombre = nom;
            this.fecha = fec;
            this.direccion = dir;
            this.cp = cod;
            this.ciudad = ciu;
            this.estado = est;
            this.subtotal = sub;
            this.descuento = des;
            this.impuesto = imp;
            this.total = tot;

        }

    }

    
}