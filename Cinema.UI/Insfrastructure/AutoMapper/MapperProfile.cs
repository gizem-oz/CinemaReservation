using AutoMapper;
using Cinema.Entities.Concrete;
using Cinema.Entities.Dtos;
using Cinema.UI.Models.ViewModels;
using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Insfrastructure.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {

            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Category, CategoryConvertVM>().ReverseMap();

            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Customer, CustomerConvertVM>().ReverseMap();

            CreateMap<Department,DepartmentVM>().ReverseMap();
            CreateMap<Department, DepartmentConvertVM>().ReverseMap();

            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Employee, EmployeeConvertVM>().ReverseMap();

            CreateMap<Movie, MovieVM>().ReverseMap();
            CreateMap<Movie, MovieConvertVM>().ReverseMap();

            CreateMap<Reservation, ReservationVM>().ReverseMap();
            CreateMap<Reservation, ReservationConvertVM>().ReverseMap();

            CreateMap<Room, RoomVM>().ReverseMap();
            CreateMap<Room, RoomConvertVM>().ReverseMap();
            
            CreateMap<Seat, SeatVM>().ReverseMap();
            CreateMap<Seat, SeatConvertVM>().ReverseMap();

            CreateMap<Reservation, ReservationDto>().ReverseMap();
        }
    }
}
