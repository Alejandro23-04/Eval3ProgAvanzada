using Eval3ProgAvanzada.Database;
using Microsoft.AspNetCore.Mvc;

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
            var movements = _context.movimientos.Include(m => m.herramientaId).Include(m => m.UserId).ToList();
            return View(movements);
        }
    }
}
