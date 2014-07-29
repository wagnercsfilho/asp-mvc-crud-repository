using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc_crud_repository.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Titulo { get; set; }
        public string Autor { get; set; }

        [Column("Ano")]
        [Display(Name = "Ano Publicacao")]
        public string anoPublicacao { get; set; }

        [Column("Preco")]
        [Display(Name = "Preco")]
        public decimal Preco { get; set; }
    }
}