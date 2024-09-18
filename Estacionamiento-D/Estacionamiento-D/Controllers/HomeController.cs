using Estacionamiento_D.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Estacionamiento_D.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult MostrarNombre(string nombre = "ND") {         
            return View(model:nombre); 
        }

        public int Sumar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }
    }
}
