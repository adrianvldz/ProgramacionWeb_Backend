using Microsoft.AspNetCore.Mvc;
using Web_24BM.Models;

namespace Web_24BM.Controllers
{
    public class EjemploController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Texto = "Esto es un texto desde ejemplo controller";
            TempData["texto2"] = "Texto de sesión";

            Ejemplo model = new Ejemplo();

            model.Titulo = "alejandra cruz";
            model.Parrafo = "Esto es un parrafo";

            return View(model);
        }
        [HttpPost]

        public IActionResult Index(Ejemplo ejemplo)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
    }
}
