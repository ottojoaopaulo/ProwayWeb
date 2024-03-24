using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProwayWebMvc.Models.Produtos
{
    public class ProdutoCadastrarViewModel
    {
        [Required(ErrorMessage = "Nome e obrigatorio")]
        [Length(3, 150, ErrorMessage = "Nome deve conter no minimo 3 caracteres e no maximo 150")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Preco Unitario e necessário")]
        [DisplayName("Preco Unitario")]
        public decimal? PrecoUnitario { get; set; }

        [Required(ErrorMessage = "Categoria e obrigatoria")]
        [DisplayName("Categoria")]
        public int? CategoriaId { get; set; }

        [Required(ErrorMessage = "Data de vencimento e obrigatoria")]
        [DisplayName("Data de Vencimento")]
        public DateTime? DataVencimento { get; set; }
        [DisplayName("Observação")]
        public string? Observacao { get; set; }
    }
}   

