
using AmanahTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AmanahTask.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> optionsBuilder) : base(optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Blog
            modelBuilder.ApplyConfiguration<Blog>(new BlogConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
        #region Blog
        public DbSet<Blog> Blogs { get; set; }
        #endregion
    }
}