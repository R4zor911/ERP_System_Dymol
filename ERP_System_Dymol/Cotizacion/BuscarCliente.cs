using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_System_Dymol.Cotizacion
{
    public class BuscarCliente
    {
        public BuscarCliente()
        {

        }

        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public int IdCliente { get; set; }
        public string tipo { get; set; }
        public string direccion { get; set; }
        public string codigo { get; set; }

        public BuscarCliente(string nom, string ciu, string est, int id, string tip, string dir, string cod)
        {
            this.nombre = nom;
            this.ciudad = ciu;
            this.estado = est;
            this.IdCliente = id;
            this.tipo = tip;
            this.direccion = dir;
            this.codigo = cod;

        }
    }
}