
using Microsoft.AspNetCore.Mvc;
using ProwayWebMvc.Models.Categoria;
using ProwayWebMvc.Models.Estante;
using SupermercadoServicos.Servicos;

namespace ProwayWebMvc.Controllers
{
    [Route("estante")]
    public class EstanteController : Controller
    {
        private readonly IEstanteServico estanteServico;
        public EstanteController()
        {
            _estanteServico = new EstanteServico();
        }
        public IActionResult Index()
        {
            var estanteDtos = new _estanteServico.ObterTodos();
            var viewModels = new List<EstanteIndexViewModel>();
            foreach(var dto in estanteDtos)
            {
                var viewModel = new EstanteIndexViewModel
                {
                    Nome = dto.Nome,
                    Sigla = dto.Sigla,
                };
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }

        [HttpGet("novo")]
        public IActionResult novo()
        {
            var viewModel = new EstanteCadastrarViewModel();
            return View(viewModel);
        }


        [HttpPost("novo")]
        public IActionResult Create([FromForm] EstanteCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Novo", viewModel);
            }

            var dto = new EstanteCadastrarDto
            {
                Nome = viewModel.Nome,
            };

            var id = _estanteServico.Cadastrar(dto);

            return RedirectToAction("Index");
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery]int id)
        {
            var estante = _estanteServico.ObterPorId(id);

            var vielwModel = new CategoriaEditarViewModel
            {
                Id = estante.Id,
                Nome = estante.Nome,
            };

            return View(vielwModel);
        }

        [HttpPost("editar")]
        public IActionResult Update([FromQuery] EstanteEditarViewModel viewModel)

        {
            if (!ModelState.IsValid)
            {
                return View("Editar", viewModel);
            }
            var estanteEditarDto = new EstanteEditarDto
            {
                Nome = viewModel.Nome,
                Id = viewModel.Id,
            };

            _estanteServico.Editar(estanteEditarDto);

            return RedirectToAction("index");
        }
        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _estanteServico.Apagar(id);

            return RedirectToAction("Index");
        }

    }
}
