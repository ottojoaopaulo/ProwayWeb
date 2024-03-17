
using Microsoft.AspNetCore.Mvc;
using SupermercadoRepositorio.Repositorios;
using SupermercadoRepositorios.Entidades;

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
        [HttpPost("novo")]
        public IActionResult Create([FromForm] string nome, [FromForm] string sigla)
        {
            var estante = new Estante();
            estante.Nome = nome;
            estante.Sigla = sigla;

            var repositorio = new EstanteRepositorio();
            repositorio.Cadastrar(estante);
            return RedirectToAction("Index");
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery]int id)
        {
            var repositorio = new EstanteRepositorio();
            var estante = repositorio.ObterPorId(id);

            ViewBag.Estante = estante;
            return View();
        }

        [HttpPost("editar")]
        public IActionResult Update([FromQuery]int id, [FromForm] string nome)
        {
            var repositorio = new EstanteRepositorio();
            var estante = repositorio.ObterPorId(id);
            estante.Nome = nome;

            repositorio.Atualizar(estante);
            return RedirectToAction("index");
        }
        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            var repositorio = new EstanteRepositorio();
            repositorio.Apagar(id);

            return RedirectToAction("Index");
        }

    }
}
