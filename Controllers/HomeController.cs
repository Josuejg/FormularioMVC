using FormularioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FormularioMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ContactViewModel
            {
                NuevoMensaje = new ContactMessage(),
                Mensajes = _context.ContactMessages.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(model.NuevoMensaje);
                _context.SaveChanges();
                TempData["Mensaje"] = "Mensaje enviado correctamente.";
                return RedirectToAction("Index");
            }

            model.Mensajes = _context.ContactMessages.ToList();
            return View("Index", model);
        }
    }
}
