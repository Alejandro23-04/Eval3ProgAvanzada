using Eval3ProgAvanzada.Database;
using Eval3ProgAvanzada.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eval3ProgAvanzada.Controllers
{
    public class usuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public usuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.usuarios.ToList();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
    }
}
