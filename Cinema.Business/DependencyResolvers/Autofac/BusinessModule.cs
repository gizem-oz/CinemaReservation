using Autofac;
using Cinema.Business.Abstract;
using Cinema.Business.Concrete;
using Cinema.DataAccess.Abstract;
using Cinema.DataAccess.Concrete.EntityFramework;
using Cinema.DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.DependencyResolvers.Autofac
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            


            builder.RegisterType<CategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CustomerDal>().As<ICustomerDal>();
            builder.RegisterType<DepartmentDal>().As<IDepartmentDal>();
            builder.RegisterType<EmployeeDal>().As<IEmployeeDal>();
            builder.RegisterType<MovieDal>().As<IMovieDal>();
            builder.RegisterType<PaymentDal>().As<IPaymentDal>();
            builder.RegisterType<ReservationDal>().As<IReservationDal>();
            builder.RegisterType<RoomDal>().As<IRoomDal>();
            builder.RegisterType<SessionDal>().As<ISessionDal>();
            builder.RegisterType<TicketDal>().As<ITicketDal>();
            builder.RegisterType<SeatDal>().As<ISeatDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
            builder.RegisterType<MovieManager>().As<IMovieService>();
            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<ReservationManager>().As<IReservationService>();
            builder.RegisterType<RoomManager>().As<IRoomService>();
            builder.RegisterType<SessionManager>().As<ISessionService>();
            builder.RegisterType<TicketManager>().As<ITicketService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<SeatManager>().As<ISeatService>();
        }
    }
}
