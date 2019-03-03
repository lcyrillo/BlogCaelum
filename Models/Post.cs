using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Preencha o Titulo")]
        [StringLength(50, ErrorMessage="Titulo Maior Que 50 Caracteres")]
        [Display(Name="Titulo")]
        public string Titulo { get; set; }
        [Required(ErrorMessage="Preencha o Resumo")]
        public string Resumo { get; set; }
        [Required(ErrorMessage="Preencha a Categoria")]
        public string Categoria { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }
    }
}
