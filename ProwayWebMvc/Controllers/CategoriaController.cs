using Microsoft.AspNetCore.Mvc;
using ProwayWebMvc.Models.Categoria;
using SupermercadoRepositorio.Repositorios;
using SupermercadoServicos.Dtos.Categorias;
using SupermercadoServicos.Interface;
using SupermercadoServicos.Servicos;

namespace ProwayWebMvc.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServico _categoriaServico;
        public CategoriaController()
        {
            _categoriaServico = new CategoriaServico();
        }
        public IActionResult Index()
        {
            var categoriaDtos = _categoriaServico.ObterTodos();
            var viewModels = new List<CategoriaIndexViewModel>();
            foreach(var dto in categoriaDtos)
            {
                var viewModel = new CategoriaIndexViewModel
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                };
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }

        [HttpGet("novo")]
        public IActionResult Novo()
        {
            var viewModel = new CategoriaCadastrarViewModel();
            return View(viewModel); 
        }

        [HttpPost("novo")]
        public IActionResult Create([FromForm]string CategoriaCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Novo", viewModel);
            }

            var dto = new CategoriaCadastrarDto
            {
                Nome.viewModel.Nome,
            };

            var int = _categoriaServico.Cadastrar(dto);

            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _categoriaRepositorio.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("editar")]

        public IActionResult Editar([FromQuery] int id)
        {
            var repositorio = new CategoriaRepositorio();
            var categoria = repositorio.ObterPorId(id);

            var vielwModel = new CategoriaEditarViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };

            return View(vielwModel);
        }

        [HttpPost("editar")]

        public IActionResult Update([FromForm] CategoriaEditarViewModel viewModel)

        {
            if (!ModelState.IsValid)
            {
                return View("Editar" , viewModel);
            }
            var categoria = 
            {
                Nome = viewModel.Nome,
                Id = viewModel.Id
            };

            _categoriaServico.Editar(categoriaEditarDto);

            return RedirectToAction("index");
        }
     }
}
