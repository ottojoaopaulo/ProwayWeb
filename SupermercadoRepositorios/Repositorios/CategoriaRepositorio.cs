using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using System.Data;

namespace SupermercadoRepositorio.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly SupermercadoContexto _contexto;

        public CategoriaRepositorio()
        {
            _contexto = new SupermercadoContexto();
        }
        public List<Categoria> ObterTodos()
        {
            return _contexto.Categorias.ToList();
        }

        public void Cadastrar(Categoria categoria)
        {
            _contexto.Categorias.Add(categoria);
            _contexto.SaveChanges();
        }

        public void Atualizar(Categoria categoria)
        {
            _contexto.Categorias.Update(categoria);
            _contexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var categoria = ObterPorId(id);
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }

        public Categoria ObterPorId(int id)
        {
            return _contexto.Categorias.Where(x=> x.Id == id).FirstOrDefault();
        }
    }
}
