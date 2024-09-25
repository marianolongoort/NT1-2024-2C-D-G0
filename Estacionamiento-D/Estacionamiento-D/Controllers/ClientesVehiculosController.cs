using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estacionamiento_D.Data;
using Estacionamiento_D.Models;

namespace Estacionamiento_D.Controllers
{
    public class ClientesVehiculosController : Controller
    {
        private readonly EstacionamientoDb _context;

        public ClientesVehiculosController(EstacionamientoDb context)
        {
            _context = context;
        }

        // GET: ClientesVehiculos
        public async Task<IActionResult> Index()
        {
            var estacionamientoDb = _context.ClienteVehiculo.Include(c => c.Cliente).Include(c => c.Vehiculo);
            return View(await estacionamientoDb.ToListAsync());
        }

        // GET: ClientesVehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClienteVehiculo
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Patente");
            return View();
        }

        // POST: ClientesVehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,VehiculoId")] ClienteVehiculo clienteVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Id", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClienteVehiculo.FindAsync(id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Id", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // POST: ClientesVehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,VehiculoId")] ClienteVehiculo clienteVehiculo)
        {
            if (id != clienteVehiculo.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteVehiculoExists(clienteVehiculo.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Id", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClienteVehiculo
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // POST: ClientesVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteVehiculo = await _context.ClienteVehiculo.FindAsync(id);
            if (clienteVehiculo != null)
            {
                _context.ClienteVehiculo.Remove(clienteVehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteVehiculoExists(int id)
        {
            return _context.ClienteVehiculo.Any(e => e.ClienteId == id);
        }
    }
}
