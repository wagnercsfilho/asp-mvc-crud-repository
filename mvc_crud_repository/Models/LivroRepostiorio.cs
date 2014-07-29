using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_crud_repository.Models
{
    public class LivroRepostiorio : ILivroRepositorio  
    {
        private DBContext _context;

        public LivroRepostiorio(DBContext dbcontext)
        {
            this._context = dbcontext;
        }

        public IEnumerable<Livro> GetLivros()
        {
            return _context.Livros.ToList();
        }

        public Livro GetLivroPorID(int livroId)
        {
            return _context.Livros.Find(livroId);
        }

        public void InserirLivro(Livro livro)
        {
            _context.Livros.Add(livro);
        }

        public void DeletarLivro(int bookID)
        {
            var livro =_context.Livros.Find(bookID);
            _context.Livros.Remove(livro);
        }

        public void AtualizarLivro(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}