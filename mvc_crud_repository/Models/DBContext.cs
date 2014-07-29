using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_crud_repository.Models
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=LivrariaConnectionString")
        {           
        }

        public DbSet<Livro> Livros { get; set; }
    }
}