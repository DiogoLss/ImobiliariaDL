using ImobiliariaDL.Context;
using ImobiliariaDL.Models;

namespace ImobiliariaDL.Repository
{
    public class ImagemRepository : Repository<Imagem>, IImagemRepository
    {
        public ImagemRepository(ImobiliariaDLDbContext context) : base(context)
        {
        }
        public IEnumerable<Imagem> GetImagensImovel(int idImovel)
        {
            var images = Get().Where(i => i.ImovelId == idImovel).ToList();
            return images;
        }
        //public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        //{
        //    return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        //}
    }
}
