using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

///
using System.ComponentModel.DataAnnotations;

namespace Semana13.ViewModel
{
    public class vwPedidoFecha
    {
        /// campos a motrar en la vista parcial
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Cargo { get; set; }
        public string Cliente { get; set; }
        public string Vendedor { get; set; }
    }
}