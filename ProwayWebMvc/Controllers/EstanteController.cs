
using Microsoft.AspNetCore.Mvc;
using SupermercadoRepositorio.Repositorios;

namespace ProwayWebMvc.Controllers
{
    [Route("estante")]
    public class EstanteController : Controller
    {

        public IActionResult Index()
        {
            var repositorio = new EstanteRepositorio();
            var estantes = repositorio.ObterTodos("");
            ViewBag.Estante = estantes;
            return View();
        }

        [HttpGet("novo")]
        public IActionResult novo()
        {
            return View();
        }
    }
}
