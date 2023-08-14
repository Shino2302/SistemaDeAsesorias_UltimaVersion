using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeAsesorias.Datos;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class LoginRegisterController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        /*[HttpPost]
        public IActionResult Login()*/
    }
}
