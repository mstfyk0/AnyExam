using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OrderApi.Application.Interfaces;
using OrderApi.Persistence.Context;
using System.Linq.Expressions;

namespace OrderApi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> , IUnitOfWork where T : class
    {
        private readonly OrderContext _context;
        private readonly IDbContextTransaction _transaction=null;

        public Repository(OrderContext context)
        {
            _context = context;
            _transaction= _context.Database.BeginTransaction();
        }

        public Task<bool> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.FromResult(true);
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

        public Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.FromResult(true);
        }

        public int Save() => _context.SaveChanges();
        public bool Commit(bool state = true)
        {
            Save();
            if (state)
                _transaction.Commit();
            else
                _transaction.Rollback();

            Dispose();
            return true;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
