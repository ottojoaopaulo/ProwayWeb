using SupermercadoRepositorio.Repositorios;
using SupermercadoServicos.Dtos.Estantes;
using SupermercadoServicos.Interface;

namespace SupermercadoServicos.Servicos
{
    public class EstanteServico : IEstanteServico
    {
        private IEstanteRepositorio estanteRepositorio;
        public EstanteServico()
        {
            _estanteRepositorio = new EstanteRepositorio();
        }
        public void Apagar(int id)
        {
            _estanteRepositorio.Apagar(id);
        }
        public int Cadastrar(EstanteCadastrarDto estanteCadastrarDto)
        {
            var estante = new EstanteCadastrarDto();
            estante.Nome = estanteCadastrarDto.Nome;

            _estanteRepositorio.Cadastrar(estante);
            return estante.Id;
        }

        public void Editar(EstanteEditarDto estanteEditarDto)
        {
            var estante = _estanteRepositorio.ObterPorId(estanteEditarDto.Id);
            estante.Nome = estanteEditarDto.Nome;

            _estanteRepositorio.Atualizar(estante);
        }
        public EstanteDto ObterPorId(int id)
        {
            var estante = _estanteRepositorio.ObterPorId(id);

            var estanteDto = new EstanteDto
            {
                Id = estante.Id,
                Nome = estante.Nome
            };
            return estanteDto;
        }
        public List<EstanteDto> ObterTodos()
        {
            var estantes = _estanteRepositorio.ObterTodos();
            var estanteDtos = new List<EstanteDto>();
            foreach (var estante in estantes)
            {
                var estanteDtos = new EstanteDtos
                {
                    Id = estante.Id,
                    Nome = estante.Nome
                };
                estanteDtos.Add(estanteDto);
            }

            //retorna alista criada
            return estanteDto;
        }

    }
}
