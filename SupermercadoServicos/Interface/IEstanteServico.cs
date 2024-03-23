using SupermercadoServicos.Dtos.Estantes;

namespace SupermercadoServicos.Interface
{
    internal interface IEstanteServico
    {
        List<EstanteDto> ObterTodos();
        EstanteDto ObterPorId(int id);
        int Cadastrar(EstanteCadastrarDto estanteCadastrarDto);
        void Editar(EstanteEditarDto estanteEditarDto);
        void Apagar(int id);
    }
}
