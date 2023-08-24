using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class ConsultaAsesoriaController : Controller
    {
        private InterMultiDatos<ConsultaAsesoria> _ConsultaAsesoria;

        public ConsultaAsesoriaController(InterMultiDatos<ConsultaAsesoria> Consulta)
        {
            _ConsultaAsesoria = Consulta;
        }

        public IActionResult Listar()
        {
            List<ConsultaAsesoria> lista = _ConsultaAsesoria.GetList();
            return View(lista);
        }
        
       
    }
}
