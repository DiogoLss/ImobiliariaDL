using ImobiliariaDL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImobiliariaDL.Context
{
    public class ImobiliariaDLDbContext : IdentityDbContext
    {
        public ImobiliariaDLDbContext(DbContextOptions<ImobiliariaDLDbContext> options) : base(options)
        {
        }
        public DbSet<Imovel>? Imoveis { get; set; }
        public DbSet<Imagem>? Imagens { get; set; }
    }
}
