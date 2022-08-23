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
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasMany(x => x.Sessions).WithOne(x => x.Room).HasForeignKey(x=>x.RoomId);
            builder.HasMany(x => x.Seats).WithOne(x => x.Room).HasForeignKey(x=>x.RoomId);
        }
    }
}
