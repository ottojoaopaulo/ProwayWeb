using SupermercadoRepositorio.Repositorios;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Categorias;
using SupermercadoServicos.Interface;

namespace SupermercadoServicos.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {
        private ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServico()
        {
            _categoriaRepositorio = new CategoriaRepositorio();
        }
        public void Apagar(int id)
        {
            _categoriaRepositorio.Apagar(id);
        }

        public int Cadastrar(CategoriaCadastrarDto categoriaCadastrarDto)
        {
            var categoria = new Categoria();
            categoria.Nome = categoriaCadastrarDto.Nome;

            _categoriaRepositorio.Cadastrar(categoria);

            return categoria.Id;
        }

        public void Editar(CategoriaEditarDto categoriaEditarDto)
        {
            var categoria = _categoriaRepositorio.ObterPorId(categoriaEditarDto.Id);
            categoria.Nome = categoriaEditarDto.Nome;

            _categoriaRepositorio.Atualizar(categoria);
        }

        public CategoriaDto ObterPorId(int id)
        {
            var categoria = _categoriaRepositorio.ObterPorId(id);

            var categoriaDto = new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
            return categoriaDto;

        }
        public List<CategoriaDto> ObterTodos()
        {
            var categorias = _categoriaRepositorio.ObterTodos();
            var categoriaDtos = new List<CategoriaDto>();
            foreach (var categoria in categorias)
            {
                var categoriaDto = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };
                categoriaDtos.Add(categoriaDto);
            }

            //retorna alista criada
            return categoriaDtos;
        }
    }
    
}

