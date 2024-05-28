using Microsoft.EntityFrameworkCore.Storage;
using OrderApi.Application.Interfaces;
using OrderApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Persistence.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderContext  _context;
        private readonly IDbContextTransaction _transaction = null;

        public UnitOfWork(OrderContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }

        public int Save() => _context.SaveChanges();
        public Task<bool> Commit(bool state = true)
        {
            Save();
            if (state)
                _transaction.Commit();
            else
                _transaction.Rollback();

            Dispose();
            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
