﻿using System;
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
    public class TelefonosController : Controller
    {
        private readonly EstacionamientoDb _miDb;

        public TelefonosController(EstacionamientoDb midb)
        {
            _miDb = midb;
        }

        public IActionResult Index()
        {
            var estacionamientoDb = _miDb.Telefonos.Include(t => t.Cliente);
            return View(estacionamientoDb.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        //solicitud de formulario
        //[HttpGet]
        public IActionResult Create()
        {
            var clientesEnDb = _miDb.Clientes;

            ViewBag.ClienteId = new SelectList(clientesEnDb, "Id", "NombreCompleto");
            return View();
        }

        //Entregar y procesar el formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(telefono);
                _miDb.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", telefono.ClienteId);
            return View(telefono);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Set<Cliente>(), "Id", "Apellido", telefono.ClienteId);
            return View(telefono);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,TipoTelefono,ClienteId")] Telefono telefono)
        {
            if (id != telefono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(telefono);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.Id))
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
            ViewData["ClienteId"] = new SelectList(_miDb.Set<Cliente>(), "Id", "Apellido", telefono.ClienteId);
            return View(telefono);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefono = await _miDb.Telefonos.FindAsync(id);
            if (telefono != null)
            {
                _miDb.Telefonos.Remove(telefono);
            }

            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
            return _miDb.Telefonos.Any(e => e.Id == id);
        }
    }
}
