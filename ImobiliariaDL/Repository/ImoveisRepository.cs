using ImobiliariaDL.Context;
using ImobiliariaDL.Models;

namespace ImobiliariaDL.Repository
{
    public class ImoveisRepository : Repository<Imovel>, IImoveisRepository
    {
        public ImoveisRepository(ImobiliariaDLDbContext context) : base(context)
        {
        }
    }
}
