using System.ComponentModel.DataAnnotations;

namespace ProwayWebMvc.Models.Categoria
{
    public class CategoriaCadastrarViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Campo deve conter no minimo 3 caracteres")]
        [MaxLength(25, ErrorMessage = "Campo deve conter no maximo 25 caracteres")]
        public string Nome { get; set; }
    }
}
