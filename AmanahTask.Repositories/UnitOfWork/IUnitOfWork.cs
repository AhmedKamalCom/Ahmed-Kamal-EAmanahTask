using AmanahTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace AmanahTask.Repositories
{
    public interface IUnitOfWork
    {
       // Dictionary<Type, object> Repositories { get; set; }
        T Repository<T>() where T : class;
       // IRepository<T> TestRepository<T>() where T : class;
        int Commit();
        void Rollback();
        IDbContextTransaction BeginTransaction();
    }
}
