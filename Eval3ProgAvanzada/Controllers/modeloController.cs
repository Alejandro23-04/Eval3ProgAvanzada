using Eval3ProgAvanzada.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Eval3ProgAvanzada.Controllers
{
    public class modeloController : Controller
    {
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.marca, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,MarcaId")] modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.marca, "Id", "Nombre", modelo.marcaId);
            return View(modelo);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = _context.Modelos.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.MarcaId);
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,MarcaId")] Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.MarcaId);
            return View(modelo);
        }

        private bool ModeloExists(object id)
        {
            throw new NotImplementedException();
        }
    }
}
