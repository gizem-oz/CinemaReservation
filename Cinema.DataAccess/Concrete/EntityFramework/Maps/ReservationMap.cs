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
    public class ReservationMap : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasMany(x => x.Tickets).WithOne(x => x.Reservation).HasForeignKey(x=>x.ReservationId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Seat).WithMany(x => x.Reservations).HasForeignKey(x => x.SeatId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
