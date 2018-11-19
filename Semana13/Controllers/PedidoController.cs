using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// definied
using Semana13.Models;

namespace Semana13.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        NeptunoEntities db = new NeptunoEntities();
        public ActionResult ListarPedidoFecha()
        {
            ViewBag.Idcliente = new SelectList(db.Clientes, "IdCliente", "NombreCompañia");
            return View();
        }

        // metodo para la vista parcial
        public PartialViewResult ListadoPedidoFechaCliente(DateTime fecha_inicio, DateTime fecha_fin, string cliente)
        {
            /// obtener los pedidos filtrados por fecha y cliente
            var listado = db.Pedidos.Where(p => p.FechaPedido >= fecha_inicio && p.FechaPedido <= fecha_fin && p.IdCliente == cliente);

            List<ViewModel.vwPedidoFecha> colccion = new
            List<ViewModel.vwPedidoFecha>();
            // llenar la coleccion de las propiedades de vwpedidofecha
            foreach(Pedidos pedido in listado){
                ViewModel.vwPedidoFecha ped = new ViewModel.vwPedidoFecha();
                ped.IdPedido = pedido.IdPedido;
                ped.FechaPedido = Convert.ToDateTime(pedido.FechaPedido);
                ped.FechaEntrega = Convert.ToDateTime(pedido.FechaEntrega);
                ped.Cargo = Convert.ToDecimal(pedido.Cargo);
                ped.Cliente = pedido.Clientes.NombreCompañia;
                ped.Vendedor = pedido.Empleados.Apellidos;

                colccion.Add(ped);
            }
            return PartialView("ListaPedidoFecha_PV", colccion);
        }

    }
}