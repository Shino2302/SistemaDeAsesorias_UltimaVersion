using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class GrupoController : Controller
    {
        private IGenericDatos<Grupo> _grupo;
        private IGenericDatos<CuatriCarrera> _cuatriCarrera;
        public GrupoController(IGenericDatos<Grupo> grupo, IGenericDatos<CuatriCarrera> cuatriCarrera){
            _grupo = grupo;
            _cuatriCarrera = cuatriCarrera;
        }
        public IActionResult Listar(){
            List<Grupo> lista = _grupo.GetList();
            return View(lista);
        }
        public IActionResult Guardar(){
            List<CuatriCarrera>lista = _cuatriCarrera.GetList();
            List<SelectListItem> listC = lista.ConvertAll(
                item => new SelectListItem()
                {
                    Text = item.IdCarrera1.ToString(),
                    Value = item.IdCC.ToString(),
                    Selected = false
                });
            ViewBag.Lista = listC;
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Grupo model){
            bool grupoGuardado = _grupo.Guardar(model);
            if(grupoGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
       [HttpPost]
        public IActionResult Eliminar(int idGrupo)
        {
            bool grupoEliminado = _grupo.Eliminar(idGrupo);
            if (grupoEliminado)
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