using MySql.Data.MySqlClient;
using Reportes.Models.ViewModel;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Reportes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string nombre="")
        {
            ViewBag.nombre = nombre;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Report()
        {

            List<ventas> lista = new List<ventas>();

            string conexion = "Server=localhost; Database=proyectoFotos; uid=root; pwd=root;";

            try
            {
                using (var con = new MySqlConnection(conexion))
                {
                    con.Open();
                    string consulta = "Select IdVenta,nCliente,descripcion,precioTotal,fechaCompra from Ventas";
                    var cmd = new MySqlCommand(consulta, con);
                    MySqlDataReader lector = cmd.ExecuteReader();
                    while (lector.Read())
                    {
                        var venta = new ventas();
                        venta.IdVenta = lector[0].ToString();
                        venta.nCliente = lector[1].ToString();
                        venta.descripcion = lector[2].ToString();
                        venta.precioTotal = lector[3].ToString();
                        venta.fechaCompra = lector[4].ToString();
                        lista.Add(venta);
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return View(lista);
        }

        public ActionResult Print()
        {

            return new ActionAsPdf("Report")
            { FileName = "ReporteVentasAaron.pdf" };
        }
    }
}