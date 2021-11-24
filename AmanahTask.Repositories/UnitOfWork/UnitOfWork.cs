using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AmanahTask.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IServiceProvider _serviceProvider;
     
        public UnitOfWork(DataContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public T Repository<T>() where T : class

        {
            var interfaceType = typeof(T).GetInterface($"I{typeof(T).Name}");
            
             T repo =(T) _serviceProvider.GetRequiredService(interfaceType);
         
             return repo;
        }
     
        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
        public IDbContextTransaction BeginTransaction()
        {
            IDbContextTransaction res = _context.Database.BeginTransaction();
            return res;
        }

    }
}
