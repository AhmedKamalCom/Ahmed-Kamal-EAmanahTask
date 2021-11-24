using AmanahTask.Models;
using AmanahTask.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace AmanahTask.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly HttpContext _httpContext;

       // private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        //public Dictionary<Type, object> Repositories
        //{
        //    get { return _repositories; }
        //    set { Repositories = value; }
        //}
        public UnitOfWork(DataContext context, IHttpContextAccessor accessor, IServiceProvider serviceProvider)
        {
            _httpContext = accessor.HttpContext;
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public T Repository<T>() where T : class

        {
            var interfaceType = typeof(T).GetInterface($"I{typeof(T).Name}");
            
             T repo =(T) _serviceProvider.GetRequiredService(interfaceType);
         
             return repo;
        }
        //public IRepository<T> TestRepository<T>() where T : class
        //{
        //if (Repositories.Keys.Contains(typeof(T)))
        //{
        //    return Repositories[typeof(T)] as T;
        //}

        //    var interfaceType = typeof(T).GetInterface($"I{typeof(T).Name}");

        //    // T repo =(T) _serviceProvider.GetRequiredService(interfaceType);
        //    var respositoryType = typeof(IRepository<T>);
        //   var repo = (Repository<T> ) _serviceProvider.GetRequiredService(respositoryType);

        //    // T repo = (T)Activator.CreateInstance(typeof(T), new object[] { _context });

        //    Repositories.Add(typeof(T), repo);
        //    return repo;
        //}
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
