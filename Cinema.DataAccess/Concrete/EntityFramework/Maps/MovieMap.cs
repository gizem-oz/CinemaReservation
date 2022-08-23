using Cinema.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Concrete.EntityFramework.Maps
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasMany(x => x.Sessions).WithOne(x => x.Movie).HasForeignKey(x=>x.MovieId);
        }
    }
}
