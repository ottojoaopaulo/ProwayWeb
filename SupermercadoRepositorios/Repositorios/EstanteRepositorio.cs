using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using System.Data;

namespace SupermercadoRepositorio.Repositorios
{
    public class EstanteRepositorio : IEstanteRepositorio
    {
        private readonly SupermercadoContexto _contexto;
        public EstanteRepositorio()
        {
            _contexto = new SupermercadoContexto();
        }

        public void Apagar(int id)
        {
            var estante = ObterPorId(id);
            _contexto.Estantes.Remove(estante);
            _contexto.SaveChanges();
        }

        public void Atualizar(Estante estante)
        {
            _contexto.Estantes.Update(estante);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Estante estante)
        {
            _contexto.Estantes.Add(estante);
            _contexto.SaveChanges();
        }

        public Estante ObterPorId(int id)
        {
            return _contexto.Estantes.Where(x=> x.Id == id).FirstOrDefault();
        }

        public List<Estante> ObterTodos(string pesquisa)
        {
            return _contexto.Estantes.Where(x => x.Nome.Contains(pesquisa)).ToList();
        }
    }
}
