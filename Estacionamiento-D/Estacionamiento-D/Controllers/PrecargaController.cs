using Estacionamiento_D.Data;
using Estacionamiento_D.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estacionamiento_D.Controllers
{
    public class PrecargaController : Controller
    {
        private readonly EstacionamientoDb _midb;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly SignInManager<Persona> _signInManager;

        public PrecargaController(
            EstacionamientoDb contexto,
            UserManager<Persona> userManager,
            RoleManager<Rol> roleManager,
            SignInManager<Persona> signInManager
            )
        {
            this._midb = contexto;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }


        public IActionResult Seed()
        {
            CrearRoles().Wait();
            CrearClientes().Wait();
            CrearDirecciones();


            return RedirectToAction("Index","Home");
        }

        private async Task CrearRoles()
        {
            await _roleManager.CreateAsync(new Rol("Administrador"));
            await _roleManager.CreateAsync(new Rol("Cliente"));
            await _roleManager.CreateAsync(new Rol("Empleado"));
            await _roleManager.CreateAsync(new Rol("ModoDios"));
        }

        private void CrearDirecciones()
        {
            //
        }

        private async Task CrearClientes()
        {
            Cliente cliente1 = new Cliente() { 
                Nombre = "Pablo",
                Apellido="Marmol",
                Email= "pablo@ort.edu.ar",
                UserName = "pablo@ort.edu.ar",
                FechaAlta = DateTime.Now                
            };
            var resultado = await _userManager.CreateAsync(cliente1,"Password1!");

            if (resultado.Succeeded)
            {
                await _userManager.AddToRoleAsync(cliente1,"Cliente");
            }



        }
    }
}
