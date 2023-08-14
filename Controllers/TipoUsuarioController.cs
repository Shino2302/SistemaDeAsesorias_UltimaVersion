using Microsoft.AspNetCore.Mvc;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private readonly IGenericDatos<TipoUsuario> _tipoUsuario;
        public TipoUsuarioController(IGenericDatos<TipoUsuario> tipoUsuario)
        {
            _tipoUsuario = tipoUsuario;
        }

        public IActionResult Listar()
        {
            List<TipoUsuario> lista = _tipoUsuario.GetList();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(TipoUsuario model)
        {
            bool tipoUsuarioGuardado = _tipoUsuario.Guardar(model);
            if (tipoUsuarioGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
         [HttpPost]
        public IActionResult Eliminar(int idTU)
        {
            bool TUEliminado = _tipoUsuario.Eliminar(idTU);
            if (TUEliminado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                // Manejar el caso en que la eliminación no fue exitosa
                return RedirectToAction("Listar");
            }
        }
    }
}
