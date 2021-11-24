using Microsoft.EntityFrameworkCore.Storage;

namespace AmanahTask.Repositories
{
    public interface IUnitOfWork
    {
        T Repository<T>() where T : class;
        int Commit();
        void Rollback();
        IDbContextTransaction BeginTransaction();
    }
}
