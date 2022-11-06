using ImobiliariaDL.Models;

namespace ImobiliariaDL.Repository
{
    public interface IImagemRepository : IRepository<Imagem>
    {
        public IQueryable<Imagem> GetImagensImovel(int idImovel);
    }
}
