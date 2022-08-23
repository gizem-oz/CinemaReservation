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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.AppIdentityUserId);
            builder.HasMany(x => x.Reservations).WithOne(x => x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.AppIdentityUser).WithOne(x => x.Customer);
        }
    }
}
