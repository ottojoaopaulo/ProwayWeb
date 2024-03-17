using SupermercadoServicos.Dtos.Categorias;

namespace SupermercadoServicos.Interface
{
    public interface ICategoriaServico
    {
        List<CategoriaDto> ObterTodos();
        CategoriaDto ObterPorId(int id);
        int Cadastrar(CategoriaCadastrarDto categoriaCadastrarDto);
        void Editar(CategoriaEditarDto categoriaEditarDto);
        void Apagar(int id);
    }
}
