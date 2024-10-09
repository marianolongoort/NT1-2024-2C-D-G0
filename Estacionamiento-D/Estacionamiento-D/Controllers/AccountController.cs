using Estacionamiento_D.Data;
using Estacionamiento_D.Models;
using Estacionamiento_D.Models.Viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;

namespace Estacionamiento_D.Controllers
{
    public class AccountController : Controller
    {
        private readonly EstacionamientoDb _contexto;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly SignInManager<Persona> _signInManager;

        public AccountController(
            EstacionamientoDb contexto,
            UserManager<Persona> userManager,
            RoleManager<Rol> roleManager,
            SignInManager<Persona> signInManager            
            )
        {
            this._contexto = contexto;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroUsuario viewModel)
        {

            if (ModelState.IsValid)
            {
                //queremos registrar
                Cliente cliente = new Cliente();
                cliente.Email = viewModel.Email;
                cliente.UserName = viewModel.Email;                

                var resultadCreate = await _userManager.CreateAsync(cliente,viewModel.Password);

                if (resultadCreate.Succeeded)
                {
                    //si está ok, sigo 
                    await _userManager.AddToRoleAsync(cliente,"Cliente");
                    //iniciamos sesión con elusuario.
                    await _signInManager.SignInAsync(cliente,viewModel.RememberMe);

                    //defino a donde lo quiero enviar al usuario.
                    return RedirectToAction("Details","Clientes",new { id = cliente.Id});
                }
                //se presento un error lo manejo.

            }

            return View();
        }

        public IActionResult IniciarSesion()
        {           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Models.Viewmodels.Login modelo)
        {
            
            if (ModelState.IsValid)
            {
                var resultadoInicioSesion = await _signInManager.PasswordSignInAsync(modelo.Email, modelo.Password, modelo.RememberMe, false);

                if (resultadoInicioSesion.Succeeded)
                {
                    
                    if (User.IsInRole("Cliente")) { return RedirectToAction("Index", "Clientes"); }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
            }
            return View(modelo);
        }


        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
