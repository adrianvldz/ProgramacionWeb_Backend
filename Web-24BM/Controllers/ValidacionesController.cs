using Microsoft.AspNetCore.Mvc;
using Web_24BM.Models;

namespace Web_24BM.Controllers
{
    public class ValidacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarFormulario(Curriculum model)
        {
            string mensaje ="";
            if(ModelState.IsValid)
            {
                mensaje = "Datos Válidos";

                TempData["msj"] = mensaje;
                return View("Curriculum");
            }
            else
            {
                mensaje = "Datos incorrectos";
                TempData["msj"] = mensaje;

                return View("Index");
            }
            
        }

        [Route("Editar")]
        public IActionResult Editar()
        {
            return View("Editar");
        }

        
    }
}
