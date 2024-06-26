﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace OrderApi.Application.Interfaces

{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);   
        Task<List<T>> GetByIdListAsync(string foreignKeyName, int id);   
        Task<T> GetUserByUserNameAsync(string userName);   
        void Create(T entity);   
        void Update(T entity);   
        void Delete(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filtre);
    }
}
