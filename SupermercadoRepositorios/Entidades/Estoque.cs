namespace SupermercadoRepositorios.Entidades
{
    public class Estoque
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
    }
}
