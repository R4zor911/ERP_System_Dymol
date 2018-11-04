using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_System_Dymol.Cotizacion
{
    public class TablaCotizaciones
    {
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string subtotal { get; set; }
        public string descuento { get; set; }
        public string impuesto { get; set; }
        public string total { get; set; }
        public int IdCliente { get; set; }
        public int id { get; set; }
        public string peticion { get; set; }

        public TablaCotizaciones(string fec, string nom, string ciu, string est, string sub, string des, string imp, string tot, int idc, int idquotation, string pet)
        {
            fecha = fec;
            nombre = nom;
            ciudad = ciu;
            estado = est;
            subtotal = sub;
            descuento = des;
            impuesto = imp;
            total = tot;
            IdCliente = idc;
            id = idquotation;
            peticion = pet;

        }

        public TablaCotizaciones()
        {
        }
    }
    public class CotizacionesAceptadas
    {
        public CotizacionesAceptadas()
        {

        }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string subtotal { get; set; }
        public string descuento { get; set; }
        public string impuesto { get; set; }
        public string total { get; set; }
        public int IdCliente { get; set; }
        public int id { get; set; }
        public string peticion { get; set; }

        public CotizacionesAceptadas(string fec, string nom, string ciu, string est, string sub, string des, string imp, string tot, int idc, int idquotation, string pet)
        {
            fecha = fec;
            nombre = nom;
            ciudad = ciu;
            estado = est;
            subtotal = sub;
            descuento = des;
            impuesto = imp;
            total = tot;
            IdCliente = idc;
            id = idquotation;
            peticion = pet;

        }
    }

    public class CotizacionesCanceladas
    {
        public CotizacionesCanceladas()
        {

        }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string subtotal { get; set; }
        public string descuento { get; set; }
        public string impuesto { get; set; }
        public string total { get; set; }
        public int IdCliente { get; set; }
        public int id { get; set; }
        public string peticion { get; set; }

        public CotizacionesCanceladas(string fec, string nom, string ciu, string est, string sub, string des, string imp, string tot, int idc, int idquotation, string pet)
        {
            fecha = fec;
            nombre = nom;
            ciudad = ciu;
            estado = est;
            subtotal = sub;
            descuento = des;
            impuesto = imp;
            total = tot;
            IdCliente = idc;
            id = idquotation;
            peticion = pet;

        }
    }

}
