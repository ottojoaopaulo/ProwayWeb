using Microsoft.AspNetCore.Mvc;

namespace ProwayWebMvc.Controllers
{
    [Route("calculadora")]
    public class CalculadoraController : Controller
    {
        
        [HttpGet]
        public IActionResult Index() 
        { 
            return View();
        }

        [HttpGet]
        [Route ("somar")]
        public IActionResult SomarCalculadora()
        {
            return View();
        }

        [HttpGet]
        [Route("subtrair")]
        public IActionResult SubtrairCalculadora()
        {
            return View("subtrair");
        }

        [HttpGet]
        [Route("sum")]

        public IActionResult sum (
            [FromQuery] int numero01,
            [FromQuery] int numero02)
        {
            var soma = numero01 + numero02;
            return Ok($"Soma: {soma} ");
        }

        [HttpGet]
        [Route("CalcularImc")]
        public IActionResult CalcularImc()
        {
            return View();
        }

        [HttpGet]
        [Route("ProcessImc")]
        public IActionResult ProcessImc(
            [FromQuery] double peso,
            [FromQuery] double altura,
            [FromQuery] int idade,
            [FromQuery] string nome) 
        {
            var imc = peso / (altura * altura);
            return Ok($"Nome: {nome} de Idade: {idade} com IMC: {imc}");
        }

        [HttpPost]
        [Route("ProcessImc")]
        public IActionResult ProcessImcPost(
            [FromForm] double peso,
            [FromForm] double altura,
            [FromForm] int idade,
            [FromForm] string nome)
        {
            var imc = peso / (altura * altura);
            return Ok($"Nome: {nome} de Idade: {idade} com IMC: {imc}");
        }


    }   
}
