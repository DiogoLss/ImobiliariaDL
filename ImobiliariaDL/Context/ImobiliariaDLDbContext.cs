using ImobiliariaDL.Models;
using Microsoft.EntityFrameworkCore;

namespace ImobiliariaDL.Context
{
    public class ImobiliariaDLDbContext : DbContext
    {
        public ImobiliariaDLDbContext(DbContextOptions<ImobiliariaDLDbContext> options) : base(options)
        {
        }
        public DbSet<Imovel> Imoveis;
        public DbSet<Imagem> Imagens;
        public DbSet<Endereco> Endereco;
    }
}
