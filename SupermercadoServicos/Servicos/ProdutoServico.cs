using SupermercadoRepositorio.Modelos;
using SupermercadoRepositorio.Repositorios;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Produtos;
using SupermercadoServicos.Interface;

namespace SupermercadoServicos.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ProdutoServico()
        {
            _produtoRepositorio = new ProdutoRepositorio();
            _categoriaRepositorio = new CategoriaRepositorio();
        }
        public void Apagar(int id)
        {
            _produtoRepositorio.Apagar(id);
        }

        public int Cadastrar(ProdutoCadastrarDto produtoCadastrarDto)
        {
            var categoria = _categoriaRepositorio.ObterPorId(produtoCadastrarDto.CategoriaId);
            var produto = new Produto
            {
                //Categoria = categoria,
                CategoriaId = categoria.Id,
                Nome = produtoCadastrarDto.Nome,
                PrecoUnitario = produtoCadastrarDto.PrecoUnitario,
                DataVencimento = produtoCadastrarDto.DataVencimento
            };
            _produtoRepositorio.Cadastrar(produto);
            return produto.Id;
        }

        public void Editar(ProdutoEditarDto produtoEditarDto)
        {
            throw new NotImplementedException();
        }

        public ProdutoDto ObterPorId(int id)
        {
            var produto = _produtoRepositorio.ObterPorId(id);
            return ConstrirProdutoDto(produto);
        }

        public List<ProdutoDto> ObterTodos()
        {
            var produtosDtos = new List<ProdutoDto>();
            var produtos = _produtoRepositorio.ObterTodos(new ProdutoFiltros());
            foreach (var produto in produtos)
                produtosDtos.Add(ConstrirProdutoDto(produto));
            return produtosDtos;
        }
        private ProdutoDto ConstrirProdutoDto(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                PrecoUnitario = produto.PrecoUnitario,
                Categoria = produto.Categoria.Nome,
                DataVencimento = produto.DataVencimento,
            };
        }
    }
}
