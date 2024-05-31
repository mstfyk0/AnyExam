using Microsoft.EntityFrameworkCore;
using OrderApi.Application.Interfaces;
using OrderApi.Persistence.Context;
using System.Linq.Expressions;

namespace OrderApi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;

        public Repository(OrderContext context)
        {
            _context = context;
           
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

        public async Task<List<T>> GetByIdListAsync(string foreignKeyName, int id)
        {
            return await _context.Set<T>().Where(p=> EF.Property<int>(p, foreignKeyName) == id ).ToListAsync();
        }

        public async Task<T> GetUserByUserNameAsync(string userName)
        {

            return await _context.Set<T>().Where(p => EF.Property<string>(p, "UserName") == userName).FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}
