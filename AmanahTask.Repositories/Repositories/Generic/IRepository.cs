using AmanahTask.Models;
using System.Linq;

namespace AmanahTask.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(long id);
        IQueryable<T> GetAll();
        T Add(T model);
        T Edit(T model);
        void Delete(long id);
        void Remove(long id);
    }
}
