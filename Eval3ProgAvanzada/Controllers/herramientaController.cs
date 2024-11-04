using Eval3ProgAvanzada.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eval3ProgAvanzada.Controllers
{
    public class herramientaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public herramientaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var herramientas = _context.herramientas.ToList();
            return View(herramientas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.herramienta tool)
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

