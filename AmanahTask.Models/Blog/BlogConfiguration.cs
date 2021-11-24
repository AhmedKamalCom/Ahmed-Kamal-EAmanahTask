using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmanahTask.Models
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
         

           // builder.HasOne(x => x.City).WithMany(x => x.Zones).HasForeignKey(x => x.CityID).IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
    }
}
