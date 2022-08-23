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
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.AppIdentityUserId);
            builder.Property(x => x.FirstName).HasMaxLength(25);
            builder.Property(x => x.LastName).HasMaxLength(25);
            builder.Property(x => x.Adress).HasMaxLength(60);
            builder.Property(x => x.PhoneNumber).HasMaxLength(11);
            builder.HasMany(x => x.Reservations).WithOne(x => x.Employee).HasForeignKey(x=>x.EmployeeId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.AppIdentityUser).WithOne(x => x.Employee);
        }
    }
}
