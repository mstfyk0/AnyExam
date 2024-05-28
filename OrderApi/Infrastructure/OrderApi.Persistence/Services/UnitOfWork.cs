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
        private readonly IDbContextTransaction transaction = null;

        public UnitOfWork(OrderContext context)
        {
            _context = context;
        }

        public int Save() => _context.SaveChanges();
        public bool Commit(bool state = true)
        {
            Save();
            if (state)
                transaction.Commit();
            else
                transaction.Rollback();

            Dispose();
            return true;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
