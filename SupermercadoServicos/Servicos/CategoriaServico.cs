using SupermercadoRepositorio.Repositorios;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Categorias;
using SupermercadoServicos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
            var vategoria = _categoriaRepositorio.ObterPorId(id);

            var
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }
        //retorna alista criada
        return categoriasDto;
    
}

        public List<CategoriaDto> ObterTodos()
        {
            //busca lista de categoria no bd
            var vategorias = _categoriaRepositorio.ObterTodos();
            //cria uma lista de categoria dto, pq a camada de serviço retorna DTO para a camada de aplicação
            var categoriasDto = new List<CategoriaDto>();
            //percorre a lista de categorias no BD
            foreach(var categoria in vategorias)
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
            //adiciona a categoriaDto na lista de dtos
            categoriasDto.Add(categoriasDto)
        }
        //retorna alista criada
        return categoriasDtos;
    }
}
