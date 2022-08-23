using AutoMapper;
using Cinema.Business.Abstract;
using Cinema.Entities.Concrete;
using Cinema.Entities.Dtos;
using Cinema.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Controllers
{
    [Authorize(Roles ="User")]
    public class UserActionController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly ISeatService _seatService;
        public UserActionController(IReservationService reservationService, IMapper mapper,IAuthService authService, ISeatService seatService)
        {
            _seatService = seatService;
            _mapper = mapper;
            _reservationService = reservationService;
            _authService = authService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ReservationDto model)
        {
            var user = await _authService.GetUserByName(User.Identity.Name);
            model.CustomerId = user.Id;
            model.RoomId = 1;
            var seat = await _seatService.GetSeatById(model.SeatId);
            Reservation reservation = _mapper.Map<Reservation>(model);
            await _reservationService.Add(reservation);
            seat.Status = false;
            await _seatService.Update(seat);
            return RedirectToAction("UserIndex","Home");
        }
        public async Task<IActionResult> Reservation()
        {
            var user = await _authService.GetUserByName(User.Identity.Name);
            var reservationList = await _reservationService.GetReservation(user.Id);
            return View(reservationList);
        }

    }
}
