using AmanahTask.Models;

namespace AmanahTask.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DataContext context):base(context)
        {
        }
    }
}
