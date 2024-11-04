using Eval3ProgAvanzada.Database;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Eval3ProgAvanzada.Controllers
{
    public class movimientoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public movimientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movements = _context.movimientos.Include(m => m.herramientaId).Include(m => m.userId).ToList();
            return View(movements);
        }
    }
}
