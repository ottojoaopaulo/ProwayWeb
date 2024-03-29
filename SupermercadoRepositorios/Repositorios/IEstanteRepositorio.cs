﻿using SupermercadoRepositorios.Entidades;

namespace SupermercadoRepositorio.Repositorios
{
    public interface IEstanteRepositorio
    {
        void Cadastrar(Estante estante);
        List<Estante> ObterTodos(string pesquisa);
        Estante ObterPorId(int id);
        void Atualizar(Estante estante);
        void Apagar(int id);
    }
}
