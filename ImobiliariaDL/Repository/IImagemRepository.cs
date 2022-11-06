using ImobiliariaDL.Models;

namespace ImobiliariaDL.Repository
{
    public interface IImagemRepository : IRepository<Imagem>
    {
        public IEnumerable<Imagem> GetImagensImovel(int idImovel);
    }
}
