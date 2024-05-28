using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OrderApi.Application.Interfaces;
using OrderApi.Persistence.Context;
using System.Linq.Expressions;

namespace OrderApi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;
        private readonly IDbContextTransaction _transaction=null;

        public Repository(OrderContext context)
        {
            _context = context;
            _transaction= _context.Database.BeginTransaction();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filtre)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filtre);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
