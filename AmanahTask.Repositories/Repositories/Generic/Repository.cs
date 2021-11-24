
using AmanahTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AmanahTask.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private DbSet<T> _dbSet;
        private readonly DataContext _context;
        public long UserID { get; set; } = 1;
        protected string[] defaultExcludedEditProperties = new string[]  { "CreatedDate","ID"};
        public Repository(DataContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public T Add(T model)
        {
            _context.Set<T>().Add(model);
            return model;
        }
        public virtual T Edit(T entity)
        {
            if (defaultExcludedEditProperties.Any())
            {
                var oldEntity = _context.Set<T>().Local.FirstOrDefault(e => e.ID == entity.ID);
                if (oldEntity != null)
                    _context.Entry<T>(oldEntity).State = EntityState.Detached;

                _dbSet.Attach(entity);
                foreach (var name in defaultExcludedEditProperties)
                {
                    _context.Entry(entity).Property(name).IsModified = false;
                }
                var takenProp = _context.Entry<T>(entity).CurrentValues.Properties.Select(x => x.Name).Except(defaultExcludedEditProperties);
                foreach (var name in takenProp)
                {
                    _context.Entry(entity).Property(name).IsModified = true;
                }
                entity.UpdatedDate = DateTime.Now;
            }
            else
            {
                entity.UpdatedDate = DateTime.Now;
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
            return entity;
        }


        public virtual void Remove(long id)
        {
            T entity = _dbSet.Where(x => !x.IsDeleted).FirstOrDefault(i => i.ID == id);
            entity.IsDeleted = true;
            entity.UpdatedDate = DateTime.Now;
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public virtual void Delete(long id)
        {
            T entity = _dbSet.FirstOrDefault(i => i.ID == id);
            _dbSet.Remove(entity);
        }
        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x=>!x.IsDeleted).AsQueryable();
        }

        public virtual  T GetById(long id)
        {
            return _context.Set<T>().FirstOrDefault(x => !x.IsDeleted && x.ID == id);
        }

    }
}
