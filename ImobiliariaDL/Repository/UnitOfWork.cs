using ImobiliariaDL.Context;

namespace ImobiliariaDL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ImagemRepository? _imagensRepository;
        private ImoveisRepository? _imoveisRepository;
        private readonly ImobiliariaDLDbContext _context;
        public UnitOfWork(ImobiliariaDLDbContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        public IImagemRepository Imagens
        {
            get
            {
                return _imagensRepository = _imagensRepository ?? new ImagemRepository(_context);
            }
        }
        public IImoveisRepository Imoveis
        {
            get
            {
                return _imoveisRepository = _imoveisRepository ?? new ImoveisRepository(_context);
            }
        }
    }
}
