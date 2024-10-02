using Estacionamiento_D.Data;
using Estacionamiento_D.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Estacionamiento_D.Controllers
{
    public class PrecargaController : Controller
    {
        private readonly EstacionamientoDb _midb;

        public PrecargaController(EstacionamientoDb midb)
        {
            this._midb = midb;
        }


        public IActionResult Seed()
        {
            CrearPersonas();
            CrearDirecciones();


            return RedirectToAction("Index","Home");
        }

        private void CrearDirecciones()
        {
            throw new NotImplementedException();
        }

        private void CrearPersonas()
        {
            Persona persona1 = new Persona() { 
                Nombre = "Pablo",
                Apellido="Marmol",
                Email= "pablo@ort.edu.ar"
            };
            _midb.Personas.Add(persona1);
            _midb.SaveChanges();
        }
    }
}
