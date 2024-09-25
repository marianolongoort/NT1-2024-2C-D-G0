using Estacionamiento_D.Data;
using Estacionamiento_D.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamiento_D.Controllers
{
    public class Test2Controller : Controller
    {
        private readonly EstacionamientoDb _miDb;

        public Test2Controller(EstacionamientoDb miDb)
        {
            this._miDb = miDb;
        }

        public IActionResult Index()
        {
            //necesito acceder a la DB.
            //entonces quiero un objeto de db.
            List<Persona> personasEnDb = _miDb.Personas.ToList();

            return View(personasEnDb);
        }

        public IActionResult Details(int id) {
            var personaEnDb = _miDb.Personas.Find(id);
            
            var personaEnDb2 = _miDb.Personas
                                        .Include(persona => persona.Direccion)                                        
                                    .FirstOrDefault(persona => persona.Id == id);
            
            
            var personaEnDb3 = _miDb.Personas.Where(persona =>  persona.Nombre == "Pedro" &&
                                                                persona.Apellido == "Picapiedra"
                                                                );

            return View(personaEnDb2);

        }
    }
}
