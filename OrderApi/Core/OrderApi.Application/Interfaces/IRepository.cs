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
        Task<bool> CreateAsync(T entity);   
        Task<bool> UpdateAsync(T entity);   
        Task<bool> DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filtre);
    }
}
