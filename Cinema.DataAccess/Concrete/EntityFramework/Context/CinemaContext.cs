using Cinema.DataAccess.Concrete.EntityFramework.Maps;
using Cinema.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Concrete.EntityFramework.Context
{
    public class CinemaContext:IdentityDbContext<AppIdentityUser,AppIdentityRole,int>
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new DepartmentMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new MovieMap());
            builder.ApplyConfiguration(new ReservationMap());
            builder.ApplyConfiguration(new RoomMap());
            builder.ApplyConfiguration(new RoomMap());
            builder.ApplyConfiguration(new SessionMap());
            builder.ApplyConfiguration(new TicketMap());
            //builder.Entity<Employee>().Property(x => x.AppIdentityUserId).UseIdentityColumn(1);
            //builder.Entity<Customer>().Property(x => x.AppIdentityUserId).UseIdentityColumn(1);
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

    }
}
