namespace ImobiliariaDL.Repository
{
    public interface IUnitOfWork
    {
        public IImoveisRepository Imoveis { get; }
        public IImagemRepository Imagens { get; }
        public Task Commit();
    }
}
