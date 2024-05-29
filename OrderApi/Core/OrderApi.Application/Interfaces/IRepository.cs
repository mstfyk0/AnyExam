using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace OrderApi.Application.Interfaces

{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);   
        Task<List<T>> GetByIdListAsync(int id);   
        Task<T> GetByUserNameAsync(string userName);   
        void Create(T entity);   
        void Update(T entity);   
        void Delete(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filtre);
    }
}
