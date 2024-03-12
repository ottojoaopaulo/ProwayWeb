using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorios.Entidades;

namespace SupermercadoRepositorios.BancoDados
{
    internal class SupermercadoContexto : DbContext
    {
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //dotnet tool install --global dotnet-ef

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell\\Desktop\\joao\\C#\\C-sharp-n51\\17 02 2024\\Banco de Dados\\BancoDados.mbf.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True");
        }
    }
}
