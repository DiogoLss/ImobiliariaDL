using ImobiliariaDL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ImobiliariaDL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ImobiliariaDLDbContext _context;
        public Repository(ImobiliariaDLDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }
        public void Adicionar(T objeto)
        {
            _context.Set<T>().Add(objeto);
        }
        public void Atualizar(T objeto)
        {
            _context.Entry(objeto).State = EntityState.Modified;
            _context.Set<T>().Update(objeto);
        }
        public void Deletar(T objecto)
        {
            _context.Set<T>().Remove(objecto);
        }
    }
}
