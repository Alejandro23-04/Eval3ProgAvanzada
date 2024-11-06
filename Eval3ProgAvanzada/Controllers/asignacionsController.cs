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
    public class asignacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public asignacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: asignacions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asignaciones.Include(a => a.Herramienta).Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: asignacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Herramienta)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: asignacions/Create
        public IActionResult Create()
        {
            ViewData["herramientaId"] = new SelectList(_context.Herramientas, "Id", "Estado");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: asignacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,herramientaId,usuarioId,FechaAsignacion,FechaDevolucion")] asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["herramientaId"] = new SelectList(_context.Herramientas, "Id", "Estado", asignacion.herramientaId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", asignacion.usuarioId);
            return View(asignacion);
        }

        // GET: asignacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["herramientaId"] = new SelectList(_context.Herramientas, "Id", "Estado", asignacion.herramientaId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", asignacion.usuarioId);
            return View(asignacion);
        }

        // POST: asignacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,herramientaId,usuarioId,FechaAsignacion,FechaDevolucion")] asignacion asignacion)
        {
            if (id != asignacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!asignacionExists(asignacion.Id))
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
            ViewData["herramientaId"] = new SelectList(_context.Herramientas, "Id", "Estado", asignacion.herramientaId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", asignacion.usuarioId);
            return View(asignacion);
        }

        // GET: asignacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Herramienta)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Asignaciones'  is null.");
            }
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool asignacionExists(int id)
        {
          return (_context.Asignaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
