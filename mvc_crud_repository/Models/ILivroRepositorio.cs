using System;
using System.Collections.Generic;

namespace mvc_crud_repository.Models
{
    interface ILivroRepositorio : IDisposable
    {
        IEnumerable<Livro> GetLivros();
        Livro GetLivroPorID(int livroId);
        void InserirLivro(Livro livro);
        void DeletarLivro(int bookID);
        void AtualizarLivro(Livro livro);
        void Salvar();
    }
}