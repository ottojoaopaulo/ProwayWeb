using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadoRepositorios.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column("preco_unitario")]
        public decimal PrecoUnitario { get; set; }
        [Column("id_categoria")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
