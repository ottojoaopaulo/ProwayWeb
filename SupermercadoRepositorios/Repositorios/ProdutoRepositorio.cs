using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorio.Modelos;
using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using System.Data;

namespace SupermercadoRepositorio.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private SupermercadoContexto _contexto;

        public ProdutoRepositorio() 
        {
            _contexto = new SupermercadoContexto();
        }

        public void Cadastrar(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
        }

        public List<Produto> ObterTodos(ProdutoFiltros produtoFiltros)
        {
            return _contexto.Produtos.Include(x => x.Categoria).ToList();
        }

        public int ObterQuantidadeTotalRegistros()
        {
            return _contexto.Produtos.Count();
        }

        public void Apagar(int id)
        {
            var produto = ObterPorId(id);
            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();
        }
        public Produto ObterPorId (int id)
        {
            return _contexto.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Atualizar(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            _contexto.SaveChanges();
        }
    }
}
