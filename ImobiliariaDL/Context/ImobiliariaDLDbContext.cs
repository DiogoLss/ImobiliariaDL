using ImobiliariaDL.Models;
using Microsoft.EntityFrameworkCore;

namespace ImobiliariaDL.Context
{
    public class ImobiliariaDLDbContext : DbContext
    {
        public ImobiliariaDLDbContext(DbContextOptions<ImobiliariaDLDbContext> options) : base(options)
        {
        }
        public DbSet<Imovel>? Imoveis { get; set; }
        public DbSet<Imagem>? Imagens { get; set; }
        public DbSet<Endereco>? Endereco { get; set; }
    }
}
