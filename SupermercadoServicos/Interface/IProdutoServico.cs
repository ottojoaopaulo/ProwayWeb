using SupermercadoServicos.Dtos.Produtos;

namespace SupermercadoServicos.Interface
{
    public interface IProdutoServico
    {
        List<ProdutoDto> ObterTodos();
        ProdutoDto ObterPorId(int id);
        int Cadastrar(ProdutoCadastrarDto produtoCadastrarDto);
        void Editar(ProdutoEditarDto produtoEditarDto);
        void Apagar(int id);
    }
}
