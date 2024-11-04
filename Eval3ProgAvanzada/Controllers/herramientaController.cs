using Eval3ProgAvanzada.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eval3ProgAvanzada.Controllers
{
    public class HerramientaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HerramientaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var herramientas = _context.herramientas.ToList();
            return View("herramientaIndex", herramientas); // Especifica la vista 'herramientaIndex'
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Herramienta tool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tool);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tool);
        }
    }
}
