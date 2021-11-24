
using AmanahTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AmanahTask.Repositories
{
    public class DataContext : DbContext
    {

        private static IConfiguration Configuration;
        public static void setConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }



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