using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProwayWebMvc.Models.Produtos;
using SupermercadoServicos.Dtos.Categorias;
using SupermercadoServicos.Dtos.Produtos;
using SupermercadoServicos.Interface;
using SupermercadoServicos.Servicos;

namespace ProwayWebMvc.Controllers
{
    [Route("produto")]
    public class ProdutoController : Controller
    {
        
        private readonly IProdutoServico _produtoServico;
        private readonly ICategoriaServico _categoriaServico;

        public ProdutoController()
        {
            _produtoServico = new ProdutoServico();
            _categoriaServico = new CategoriaServico();
        }
        public IActionResult Index()
        {
            var produtosDtos = _produtoServico.ObterTodos();
            var produtoIndexViewModels = ProdutoIndexViewModel.ConstruirCom(produtosDtos);
            
            return View(produtoIndexViewModels);
        }
        [HttpGet("novo")]
        public IActionResult Cadastrar()

        {
            PreecherCategoriaViewBag();

            var produtoCadastrarViewModel = new ProdutoCadastrarViewModel();
            return View(produtoCadastrarViewModel);

        }

        private void PreecherCategoriaViewBag()
        {
            var categoriaDtos = _categoriaServico.ObterTodos();
            ViewBag.CategoriaDtos = ConstrirSelectListItemDasCategorias(categoriaDtos);
        }

        private List<SelectListItem> ConstrirSelectListItemDasCategorias(
            List<CategoriaDto> categoriaDtos)
        {
            var items = new List<SelectListItem>();
            foreach(var dto in categoriaDtos)
                items.Add(new SelectListItem(dto.Nome, dto.Id.ToString()));
            return items;
        }

        [HttpPost("novo")]
        public IActionResult Cadastrar([FromForm] ProdutoCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                PreecherCategoriaViewBag();
                return View(viewModel);
            }
            var produtoDto = new ProdutoCadastrarDto
            {
                Nome = viewModel.Nome,
                CategoriaId = viewModel.CategoriaId.GetValueOrDefault(),
                PrecoUnitario = viewModel.PrecoUnitario.GetValueOrDefault(),
                DataVencimento = viewModel.DataVencimento.GetValueOrDefault(),
                Observacao = viewModel.Observacao
            };
            var id = _produtoServico.Cadastrar(produtoDto);
            return RedirectToActionPreserveMethod("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery]int id)
        {
            _produtoServico.Apagar(id);
            return RedirectToAction(nameof(Index));        }
        }
}
