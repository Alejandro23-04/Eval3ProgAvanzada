using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eval3ProgAvanzada.Database;
using Eval3ProgAvanzada.Models;

namespace Eval3ProgAvanzada.Controllers
{
    public class modeloesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public modeloesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: modeloes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Modelos.Include(m => m.marca);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: modeloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modelos == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos
                .Include(m => m.marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: modeloes/Create
        public IActionResult Create()
        {
            ViewData["marcaId"] = new SelectList(_context.Marcas, "Id", "Nombre");
            return View();
        }

        // POST: modeloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,marcaId")] modelo modelo)
        {

            if (ModelState.IsValid)
            {                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["marcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.marcaId);
            return View(modelo);
        }

        // GET: modeloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modelos == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            ViewData["marcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.marcaId);
            return View(modelo);
        }

        // POST: modeloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,marcaId")] modelo modelo)
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
                    if (!modeloExists(modelo.Id))
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
            ViewData["marcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.marcaId);
            return View(modelo);
        }

        // GET: modeloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modelos == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos
                .Include(m => m.marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: modeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modelos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Modelos'  is null.");
            }
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo != null)
            {
                _context.Modelos.Remove(modelo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool modeloExists(int id)
        {
          return (_context.Modelos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
