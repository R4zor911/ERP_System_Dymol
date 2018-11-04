using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_System_Dymol.Cotizacion
{
    public class QuotationCharts
    {
        public QuotationCharts()
        {

        }

    }
    public class QuotationStatus
    {
        public QuotationStatus()
        {

        }

        public int aceptadas { get; set; }
        public int canceladas { get; set; }

        public QuotationStatus(int ace, int can)
        {
            this.aceptadas = ace;
            this.canceladas = can;
        }
    } 
}