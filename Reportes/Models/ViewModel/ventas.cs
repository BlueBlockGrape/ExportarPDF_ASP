using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes.Models.ViewModel
{
    public class ventas
    {
        public string IdVenta { get; set; }
        public string nCliente { get; set; }
        public string descripcion { get; set; }
        public string precioTotal { get; set; }
        public string fechaCompra { get; set; }
    }
}