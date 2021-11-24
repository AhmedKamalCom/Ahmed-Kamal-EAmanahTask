using AmanahTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmanahTask.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DataContext context):base(context)
        {
        }
    }
}
